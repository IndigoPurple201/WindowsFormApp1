using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer.CommonControls;
using CrystalDecisions.ReportAppServer.DataDefModel;
using CrystalDecisions.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Compras : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private ConexionSQL conexionSQL;
        public Compras()
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL();
            this.MouseDown += new MouseEventHandler(Compras_MouseDown);
            //this.MouseMove += new MouseEventHandler(Hardware_MouseMove);
            panelBarra.MouseDown += new MouseEventHandler(Compras_MouseDown);
            panel1.MouseDown += new MouseEventHandler(Compras_MouseDown);
            panel2.MouseDown += new MouseEventHandler(Compras_MouseDown);
            label1.MouseDown += new MouseEventHandler(Compras_MouseDown);
            label7.MouseDown += new MouseEventHandler(Compras_MouseDown);
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            conexionSQL.ProbarConexion();
            LlenarBoxProveedor();
            LlenarBoxDepartamento();
            LlenarBoxCompras();
            BloquearControles(panel2, true, btnNuevo);
            BloquearControles(panel1, true, btnNuevo2);
            this.MouseDown += new MouseEventHandler(Compras_MouseDown);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }
            //this.Click += QuitarFoco;
            dateTimePicker1.Value = DateTime.Now;
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalles.BackgroundColor = Color.White;
            dgvDetalles.BorderStyle = BorderStyle.None;
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.RowHeadersVisible = false;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvDetalles.RowTemplate.Height = 20;
            dgvDetalles.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvDetalles.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvDetalles.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvDetalles.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDetalles.ColumnHeadersHeight = 35; // Aumenta la altura del encabezado
            dgvDetalles.EnableHeadersVisualStyles = false;
            dgvDetalles.AllowUserToResizeRows = false;
            dgvDetalles.AllowUserToResizeColumns = false;
            if (dgvDetalles.Columns.Count == 0)
            {
                dgvDetalles.Columns.Add("Orden Compra", "Orden Compra");
                dgvDetalles.Columns.Add("Numero", "Numero");
                dgvDetalles.Columns.Add("Descripcion", "Descripcion");
                dgvDetalles.Columns.Add("Cantidad", "Cantidad");
                dgvDetalles.Columns.Add("Medida", "Medida");
                dgvDetalles.Columns.Add("Precio", "Precio");
                dgvDetalles.Columns.Add("Total", "Total");
            }
            dgvDetalles.ReadOnly = true;
            foreach (DataGridViewColumn column in dgvDetalles.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ObtenerSiguienteNumero()
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(idOrdenCompra), 0) + 1 AS SiguienteNumero FROM OrdenCompra;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        txtOrden.Text = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ObtenerSiguienteNumero2()
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(idDetalle), 0) + 1 AS SiguienteNumero FROM DetalleCompra;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        txtFolioDetalle.Text = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LlenarBoxProveedor()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT Descripcion FROM Proveedor_Compra;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxProveedor.Items.Clear();
                        while (reader.Read())
                        {
                            boxProveedor.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LlenarBoxCompras()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT idOrdenCompra AS Numero FROM OrdenCompra;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxCompra.Items.Clear();
                        while (reader.Read())
                        {
                            boxCompra.Items.Add(reader["Numero"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LlenarBoxDepartamento()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT descripcion FROM dependencias;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxDepartamento.Items.Clear();
                        while (reader.Read())
                        {
                            boxDepartamento.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string query = "";
            string queryId1 = "";
            string queryId2 = "";
            if (validarCampos1())
            {
                try
                {
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        string idDependencia = "";
                        queryId1 = "SELECT id_dependencia FROM dependencias WHERE descripcion = @descripcion;";
                        using (SqlCommand cmd = new SqlCommand(queryId1, connection))
                        {
                            cmd.Parameters.AddWithValue("@descripcion", boxDepartamento.Text);
                            object result = cmd.ExecuteScalar();
                            idDependencia = (result != null) ? result.ToString() : "";
                        }
                        string idProveedor = "";
                        queryId2 = "SELECT idProveedor FROM Proveedor_Compra WHERE descripcion = @descripcion;";
                        using (SqlCommand cmd = new SqlCommand(queryId2, connection))
                        {
                            cmd.Parameters.AddWithValue("@descripcion", boxProveedor.Text);
                            object result = cmd.ExecuteScalar();
                            idProveedor = (result != null) ? result.ToString() : "";
                        }
                        query = "INSERT INTO OrdenCompra(idOrdenCompra, idProveedor, iddepto, FolioCompras, fecha, entrega, recibe) VALUES (@idOrdenCompra, @idProveedor, @iddepto, @FolioCompras, @fecha, @entrega, @recibe);";
                        using (SqlCommand insertCmd = new SqlCommand(query, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@idOrdenCompra", txtOrden.Text);
                            insertCmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                            insertCmd.Parameters.AddWithValue("@iddepto", idDependencia ?? (object)DBNull.Value);
                            insertCmd.Parameters.AddWithValue("@FolioCompras", string.IsNullOrWhiteSpace(txtFolioOrden.Text) ? DBNull.Value : (object)txtFolioOrden.Text);
                            insertCmd.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
                            insertCmd.Parameters.AddWithValue("@entrega", string.IsNullOrWhiteSpace(txtEntrega.Text) ? DBNull.Value : (object)txtEntrega.Text);
                            insertCmd.Parameters.AddWithValue("@recibe", string.IsNullOrWhiteSpace(txtRecibe.Text) ? DBNull.Value : (object)txtRecibe.Text);
                            insertCmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Orden de compra registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarControles();
                        LlenarBoxCompras();
                        BloquearControles(panel2, true, btnNuevo);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea acutalizar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txtOrden.Text))
                {
                    string queryUpdate = "";
                    string queryId1 = "";
                    string queryId2 = "";
                    DateTime nuevaFecha = dateTimePicker1.Value;
                    try 
                    {
                        using (SqlConnection connection = conexionSQL.ObtenerConexion())
                        {
                            connection.Open();
                            int idProveedor = 0;
                            int idDependencia = 0;
                            queryId1 = "SELECT idProveedor FROM Proveedor_Compra WHERE Descripcion = @descripcionProveedor;";
                            using (SqlCommand cmd = new SqlCommand(queryId1, connection))
                            {
                                cmd.Parameters.AddWithValue("@descripcionProveedor", boxProveedor.Text);
                                object result = cmd.ExecuteScalar();
                                idProveedor = (result != null) ? Convert.ToInt32(result) : 0;
                            }
                            queryId2 = "SELECT id_dependencia FROM dependencias WHERE descripcion = @descripcionDepartamento;";
                            using (SqlCommand cmd2 = new SqlCommand(queryId2, connection))
                            {
                                cmd2.Parameters.AddWithValue("@descripcionDepartamento", boxDepartamento.Text);
                                object result = cmd2.ExecuteScalar();
                                idDependencia = (result != null) ? Convert.ToInt32(result) : 0;
                            }
                            queryUpdate = @"
                            UPDATE OrdenCompra SET
                                idOrdenCompra = @nuevoIdOrdenCompra,
                                idProveedor = @nuevoIdProveedor,
                                iddepto = @nuevoIddepto,
                                FolioCompras = @nuevoFolioCompras,
                                fecha = @nuevoFecha,
                                entrega = @nuevoEntrega,
                                recibe = @nuevoRecibe
                            WHERE idOrdenCompra = @idOrdenCompra
                            ;";
                            using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate,connection))
                            {
                                cmdUpdate.Parameters.AddWithValue("@nuevoIdOrdenCompra", txtOrden.Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@nuevoIdProveedor", idProveedor);
                                cmdUpdate.Parameters.AddWithValue("@nuevoIddepto", idDependencia);
                                cmdUpdate.Parameters.AddWithValue("@nuevoFolioCompras", string.IsNullOrWhiteSpace(txtFolioOrden.Text) ? DBNull.Value : (object)txtFolioOrden.Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@nuevoFecha", nuevaFecha);
                                cmdUpdate.Parameters.AddWithValue("@nuevoEntrega", string.IsNullOrWhiteSpace(txtEntrega.Text) ? DBNull.Value : (object)txtEntrega.Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@nuevoRecibe", string.IsNullOrWhiteSpace(txtRecibe.Text) ? DBNull.Value : (object)txtRecibe.Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@idOrdenCompra", txtOrden.Text.Trim());
                                cmdUpdate.ExecuteNonQuery();
                            }
                            MessageBox.Show("Registro actualizado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarControles();
                            BloquearControles(panel2, true, btnNuevo);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningun servicio para actualizar");
                }
            }
        }

        private void btnActualizar2_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea acutalizar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(txtFolioDetalle.Text))
                {
                    string queryUpdate = "";
                    try 
                    {
                        using (SqlConnection connection = conexionSQL.ObtenerConexion())
                        {
                            connection.Open();
                            queryUpdate = @"
                            UPDATE DetalleCompra SET
                                idOrdenCompra = @nuevoIdOrdenCompra,
                                Descripcion = @nuevoDescripcion,
                                cantidad = @nuevoCantidad,
                                medida = @nuevoMedida,
                                precio = @nuevoPrecio,
                                total = @nuevoTotal
                                WHERE idDetalle = @idDetalle
                            ;";
                            using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate,connection))
                            {
                                cmdUpdate.Parameters.AddWithValue("@nuevoIdOrdenCompra", boxCompra.Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@nuevoDescripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? DBNull.Value : (object)txtDescripcion.Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@nuevoCantidad", string.IsNullOrWhiteSpace(txtCantidad.Text) ? DBNull.Value : (object)Convert.ToInt32(txtCantidad.Text.Trim()));
                                cmdUpdate.Parameters.AddWithValue("@nuevoMedida", string.IsNullOrWhiteSpace(txtMedida.Text) ? DBNull.Value : (object)txtMedida.Text.Trim());
                                cmdUpdate.Parameters.AddWithValue("@nuevoPrecio", string.IsNullOrWhiteSpace(txtPrecio.Text) ? DBNull.Value : (object)Convert.ToDecimal(txtPrecio.Text.Trim()));
                                cmdUpdate.Parameters.AddWithValue("@nuevoTotal", string.IsNullOrWhiteSpace(txtTotal.Text) ? DBNull.Value : (object)Convert.ToDecimal(txtTotal.Text.Trim()));
                                cmdUpdate.Parameters.AddWithValue("@idDetalle", txtFolioDetalle.Text.Trim());
                                cmdUpdate.ExecuteNonQuery();
                            }
                            MessageBox.Show("Registro actualizado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarControles();
                            LimpiarControles2();
                            BloquearControles(panel1, true, btnNuevo2);
                            dgvDetalles.Rows.Clear();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ningun servicio para actualizar");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar lo(s) registros(s) seleccionado(s)?",
                                            "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes)
            {
                return;
            }
            else
            {
                int idOrdenCompra = Convert.ToInt32(txtOrden.Text.Trim());
                try
                {
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();

                        string queryCheck = "SELECT COUNT(*) FROM DetalleCompra WHERE idOrdenCompra = @idOrdenCompra;";
                        using (SqlCommand cmdCheck = new SqlCommand(queryCheck, connection))
                        {
                            cmdCheck.Parameters.AddWithValue("@idOrdenCompra", idOrdenCompra);
                            int cantidadDetalles = (int)cmdCheck.ExecuteScalar();

                            if (cantidadDetalles > 0)
                            {
                                MessageBox.Show("No se puede eliminar esta orden porque tiene detalles asociados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string queryDelete = "DELETE FROM OrdenCompra WHERE idOrdenCompra = @idOrdenCompra";
                        using (SqlCommand cmd = new SqlCommand(queryDelete, connection))
                        {
                            cmd.Parameters.AddWithValue("@idOrdenCompra", idOrdenCompra);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                MessageBox.Show("Registro eliminado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
                LlenarBoxCompras();
                BloquearControles(panel1, true, btnNuevo);
                dgvDetalles.Rows.Clear();
            }
        }

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar lo(s) registros(s) seleccionado(s)?",
                                            "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes)
            {
                return;
            }
            else
            {
                int idOrdenCompra = Convert.ToInt32(txtOrden.Text.Trim());
                try
                {
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        string query = "DELETE FROM DetalleCompra WHERE idDetalle = @idDetalle;";
                        using (SqlCommand cmd = new SqlCommand(query,connection))
                        {
                            cmd.Parameters.AddWithValue("@idDetalle", txtFolioDetalle.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                MessageBox.Show("Registro eliminado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
                LimpiarControles2();
                LlenarBoxCompras();
                BloquearControles(panel2, true, btnNuevo2);
                dgvDetalles.Rows.Clear();
            }
        }

        private void btnAceptar2_Click(object sender, EventArgs e)
        {
            string query = "";
            if (validarCampos2())
            {
                try
                {
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        query = "INSERT INTO DetalleCompra (idOrdenCompra, Descripcion, cantidad, medida, precio, total) VALUES (@idOrdenCompra, @Descripcion, @cantidad, @medida, @precio, @total);";
                        using (SqlCommand insertCmd = new SqlCommand(query, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@idOrdenCompra", boxCompra.Text);
                            insertCmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(txtDescripcion.Text) ? DBNull.Value : (object)txtDescripcion.Text);
                            insertCmd.Parameters.AddWithValue("@cantidad", string.IsNullOrWhiteSpace(txtCantidad.Text) ? DBNull.Value : (object)Convert.ToInt32(txtCantidad.Text));
                            insertCmd.Parameters.AddWithValue("@medida", string.IsNullOrWhiteSpace(txtMedida.Text) ? DBNull.Value : (object)txtMedida.Text);
                            insertCmd.Parameters.AddWithValue("@precio", string.IsNullOrWhiteSpace(txtPrecio.Text) ? DBNull.Value : (object)Convert.ToDecimal(txtPrecio.Text));
                            insertCmd.Parameters.AddWithValue("@total", string.IsNullOrWhiteSpace(txtTotal.Text) ? DBNull.Value : (object)Convert.ToDecimal(txtTotal.Text));
                            insertCmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Detalles de compra registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarControles2();
                        BloquearControles(panel1, true, btnNuevo2 );
                        dgvDetalles.Rows.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnRegistros_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOrden.Text))
            {
                try
                {
                    using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                    {
                        int idOrdenCompra = Convert.ToInt32(txtOrden.Text.Trim());
                        conexion.Open();

                        string validarQuery = "SELECT COUNT(*) FROM OrdenCompra WHERE idOrdenCompra = @idOrdenCompra";
                        using (SqlCommand validarCmd = new SqlCommand(validarQuery, conexion))
                        {
                            validarCmd.Parameters.AddWithValue("@idOrdenCompra", idOrdenCompra);
                            int existe = (int)validarCmd.ExecuteScalar();

                            if (existe == 0)
                            {
                                MessageBox.Show("El id de orden de compra especificado no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string query = "SELECT idOrdenCompra AS 'Orden Compra', idDetalle as Numero, Descripcion AS Descripcion, cantidad AS Cantidad, medida AS Medida, precio AS Precio, total AS Total FROM DetalleCompra WHERE idOrdenCompra = @idOrdenCompra;";
                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@idOrdenCompra", idOrdenCompra);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                dgvDetalles.Rows.Clear();
                                while (reader.Read())
                                {
                                    int rowIndex = dgvDetalles.Rows.Add();
                                    dgvDetalles.Rows[rowIndex].Cells["Orden Compra"].Value = reader["Orden Compra"];
                                    dgvDetalles.Rows[rowIndex].Cells["Numero"].Value = reader["Numero"];
                                    dgvDetalles.Rows[rowIndex].Cells["Descripcion"].Value = reader["Descripcion"];
                                    dgvDetalles.Rows[rowIndex].Cells["Cantidad"].Value = reader["Cantidad"];
                                    dgvDetalles.Rows[rowIndex].Cells["Medida"].Value = reader["Medida"];
                                    dgvDetalles.Rows[rowIndex].Cells["Precio"].Value = reader["Precio"];
                                    dgvDetalles.Rows[rowIndex].Cells["Total"].Value = reader["Total"];
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un folio de orden de compra válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void ControlSeleccionado(object sender, EventArgs e)
        {
            if (sender is TextBox || sender is ComboBox)
            {
                controlActivo = sender as Control;
            }
        }

        //private void QuitarFoco(object sender, EventArgs e)
        //{
        //    if (controlActivo != null && !controlActivo.Bounds.Contains(this.PointToClient(Cursor.Position)))
        //    {
        //        this.ActiveControl = null;
        //        controlActivo = null;
        //    }
        //}

        private void Compras_MouseDown(object sender, MouseEventArgs e)
        {
            if (validarComboBox())
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE, 0);
            }
        }

        private bool validarComboBox()
        {
            return boxProveedor.DroppedDown || boxDepartamento.DroppedDown;
        }

        private void BloquearControles(Control parent, bool bloquear, Button origen)
        {
            BloquearTodo(parent, bloquear);

            if (origen == btnNuevo)
            {
                // Esto afecta controles relacionados al panel2 (grupo 1)
                btnNuevo.Enabled = bloquear;
                btnAceptar.Enabled = !bloquear;
                btnCancelar.Enabled = !bloquear;
                btnActualizar.Enabled = !bloquear;
                btnEliminar.Enabled = !bloquear;
                btnBuscar.Enabled = !bloquear;
                btnRegistros.Enabled = !bloquear;
                btnImprimir.Enabled = !bloquear;
                btnNuevoProveedor.Enabled = !bloquear;
            }
            else if (origen == btnNuevo2)
            {
                // Esto afecta controles relacionados al panel1 (grupo 2)
                btnNuevo2.Enabled = bloquear;
                btnAceptar2.Enabled = !bloquear;
                btnCancelar2.Enabled = !bloquear;
                btnActualizar2.Enabled = !bloquear;
                btnEliminar2.Enabled = !bloquear;
                btnBuscar2.Enabled = !bloquear;
            }
        }

        private void BloquearTodo(Control parent, bool bloquear)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox || ctrl is DateTimePicker)
                {
                    ctrl.Enabled = !bloquear;
                }

                if (ctrl.HasChildren)
                {
                    BloquearTodo(ctrl, bloquear);
                }
            }
        }

        private void LimpiarControles()
        {
            txtOrden.Clear();
            boxProveedor.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            txtFolioOrden.Clear();
            boxDepartamento.SelectedIndex = -1;
            txtEntrega.Clear();
            txtRecibe.Clear();
        }

        private void LimpiarControles2()
        {
            boxCompra.SelectedIndex = -1;
            txtFolioDetalle.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtMedida.Clear();
            txtTotal.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(panel2, false, btnNuevo);
            if (string.IsNullOrEmpty(txtFolioOrden.Text))
            {
                ObtenerSiguienteNumero();
            }
            txtOrden.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnNuevo2_Click(object sender, EventArgs e)
        {
            BloquearControles(panel1, false, btnNuevo2);
            ObtenerSiguienteNumero2();
            txtFolioDetalle.Enabled = false;
            btnActualizar2.Enabled = false;
            btnEliminar2.Enabled = false;
            dgvDetalles.Rows.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            BloquearControles(panel2, true, btnNuevo);
            txtOrden.Enabled = false;
            dgvDetalles.Rows.Clear();
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            LimpiarControles2();
            BloquearControles(panel1, true, btnNuevo2);
            txtFolioDetalle.Enabled = false;
            dgvDetalles.Rows.Clear();
        }

        private void panelBarra_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 4)) // Borde negro
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, panelBarra.Width - 1, panelBarra.Height - 1));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.Black, 3)) // Borde rojo y grosor de 3px
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFolioOrden_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }

        private void txtEntrega_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }
        private void txtRecibe_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Permitir solo números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear entrada no numérica
            }
            // Evitar que se ingresen más de 4 dígitos
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 4)
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Permitir solo números, punto decimal y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear entrada no numérica
            }
            // Evitar que se ingresen más de 8 dígitos
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 8)
            {
                e.Handled = true;
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Permitir solo números, punto decimal y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear entrada no numérica
            }
            // Evitar que se ingresen más de 8 dígitos
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 8)
            {
                e.Handled = true;
            }
        }

        private void txtMedida_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string idOrdenCompra = txtOrden.Text.Trim();
                    string queryId = "SELECT idOrdenCompra FROM OrdenCompra WHERE idOrdenCompra = @idOrdenCompra;";
                    SqlCommand cmd = new SqlCommand(queryId,connection);
                    cmd.Parameters.AddWithValue("@idOrdenCompra", idOrdenCompra);
                    idOrdenCompra = cmd.ExecuteScalar()?.ToString();
                    if (string.IsNullOrEmpty(idOrdenCompra))
                    {
                        MessageBox.Show("No se encontró el id departamento seleccionado");
                        return;
                    }

                    string query = $"SELECT DetalleCompra.idOrdenCompra, DetalleCompra.descripcion, DetalleCompra.cantidad, DetalleCompra.medida, DetalleCompra.precio, DetalleCompra.total, OrdenCompra.idOrdenCompra, OrdenCompra.Fecha, OrdenCompra.Entrega, OrdenCompra.Recibe, OrdenCompra.FolioCompras, Proveedor_Compra.Descripcion, dependencias.id_dependencia, dependencias.descripcion FROM inventarios.dbo.DetalleCompra DetalleCompra, inventarios.dbo.OrdenCompra OrdenCompra, inventarios.dbo.Proveedor_Compra Proveedor_Compra, inventarios.dbo.dependencias dependencias WHERE DetalleCompra.idOrdenCompra = OrdenCompra.idOrdenCompra AND OrdenCompra.idProveedor = Proveedor_Compra.idProveedor AND OrdenCompra.idDepto = dependencias.id_dependencia AND OrdenCompra.idOrdenCompra = '{idOrdenCompra}'ORDER BY dependencias.id_dependencia ASC;";
                    SqlDataAdapter da = new SqlDataAdapter(query,connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ReportDocument report = new ReportDocument();
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string reportPath = Path.Combine(basePath, "Reportes", "rptOrdenCompra.rpt");
                    if (!File.Exists(reportPath))
                    {
                        MessageBox.Show("⚠️ El archivo de reporte no se encontró:\n" + reportPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    report.Load(reportPath);
                    report.SetDataSource(dt);

                    foreach (CrystalDecisions.CrystalReports.Engine.Table table in report.Database.Tables)
                    {
                        var logonInfo = table.LogOnInfo;
                        logonInfo.ConnectionInfo.IntegratedSecurity = true; // o configura user/password si no hay dominio
                        table.ApplyLogOnInfo(logonInfo);
                    }

                    Form visor = new Form();
                    CrystalDecisions.Windows.Forms.CrystalReportViewer visorCrystal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                    visorCrystal.Dock = DockStyle.Fill;
                    visorCrystal.ReportSource = report;
                    visor.Controls.Add(visorCrystal);
                    visor.WindowState = FormWindowState.Maximized;
                    visor.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool validarCampos1()
        {
            bool esValido = true;
            string mensajeError = "Los siguientes campos son invalidos: \n";
            if (string.IsNullOrWhiteSpace(txtFolioOrden.Text))
            {
                mensajeError += "- Especifique un folio valido\n";
                esValido = false;
            }
            if (dateTimePicker1.Value.Date > DateTime.Now.Date)
            {
                mensajeError += "- Especifique una fecha valida.\n";
                esValido = false;
            }
            if (boxProveedor.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxProveedor.Text))
            {
                mensajeError += "- Seleccione un proveedor valido.\n";
                esValido = false;
            }
            if (boxDepartamento.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxDepartamento.Text))
            {
                mensajeError += "- Seleccione un departamento valido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtEntrega.Text))
            {
                mensajeError += "- Especifique quien entrega\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtRecibe.Text))
            {
                mensajeError += "- Especifique quien recibe\n";
                esValido = false;
            }
            if (!esValido)
            {
                MessageBox.Show(mensajeError, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }

        private bool validarCampos2()
        {
            bool esValido = true;
            string mensajeError = "Los siguientes campos son invalidos: \n";
            if (boxCompra.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxCompra.Text))
            {
                mensajeError += "- Seleccione una orden de compra valida.\n";
                esValido = false;
            }
            if (!esValido)
            {
                MessageBox.Show(mensajeError, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var buscarCompras =  new BuscarCompras("ORDEN"))
            {
                if (buscarCompras.ShowDialog() == DialogResult.OK)
                {
                    string servicioSeleccionado = buscarCompras.ServicioSeleccionado;
                    if (!string.IsNullOrEmpty(servicioSeleccionado))
                    {
                        CargarDatosPorFolio(servicioSeleccionado);
                        btnActualizar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnAceptar.Enabled = false;
                    }
                }
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            using (var buscarCompras = new BuscarCompras("DETALLES"))
            {
                if (buscarCompras.ShowDialog() == DialogResult.OK)
                {
                    string servicioSeleccionado = buscarCompras.ServicioSeleccionado;
                    if (!string.IsNullOrEmpty(servicioSeleccionado))
                    {
                        CargarDatosPorFolio2(servicioSeleccionado);
                        btnActualizar2.Enabled = true;
                        btnEliminar2.Enabled = true;
                        btnAceptar2.Enabled = false;
                    }
                }
            }
        }

        private void CargarDatosPorFolio(string servicioSeleccionado)
        {
            try
            {
                string query = "";
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    query = @"
                    SELECT OrdenCompra.idOrdenCompra,
                        OrdenCompra.FolioCompras,
                        OrdenCompra.fecha,
                        OrdenCompra.idProveedor,
                        OrdenCompra.iddepto,
                        OrdenCompra.entrega,
                        OrdenCompra.recibe
                    FROM OrdenCompra
                    WHERE idOrdenCompra = @idOrdenCompra;";
                    using (SqlCommand cmd = new SqlCommand(query,connection))
                    {
                        cmd.Parameters.AddWithValue("@idOrdenCompra", servicioSeleccionado);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtOrden.Text = reader["idOrdenCompra"].ToString();
                                txtFolioOrden.Text = reader["FolioCompras"].ToString();
                                dateTimePicker1.Value = Convert.ToDateTime(reader["fecha"]);
                                txtEntrega.Text = reader["entrega"].ToString();
                                txtRecibe.Text = reader["recibe"].ToString();

                                int idProveedor = Convert.ToInt32(reader["idProveedor"]);
                                int idDepartamento = Convert.ToInt32(reader["iddepto"]);
                                reader.Close();

                                string nombreProveedor = "";
                                using (SqlCommand cmdProveedor = new SqlCommand("SELECT Descripcion FROM Proveedor_Compra WHERE idProveedor = @idProveedor;", connection))
                                {
                                    cmdProveedor.Parameters.AddWithValue("@idProveedor", idProveedor);
                                    var resultProveedor = cmdProveedor.ExecuteScalar();
                                    if (resultProveedor != null)
                                    {
                                        nombreProveedor = resultProveedor.ToString();
                                    }
                                }

                                string nombreDepartamento = "";
                                using (SqlCommand cmdDepartamento = new SqlCommand("SELECT descripcion FROM dependencias WHERE id_dependencia = @id_dependencia;", connection))
                                {
                                    cmdDepartamento.Parameters.AddWithValue("@id_dependencia", idDepartamento);
                                    var resultDepartamento = cmdDepartamento.ExecuteScalar();
                                    if (resultDepartamento != null)
                                    {
                                        nombreDepartamento = resultDepartamento.ToString();
                                    }
                                }

                                boxProveedor.SelectedIndex = boxProveedor.FindStringExact(nombreProveedor);
                                boxDepartamento.SelectedIndex = boxDepartamento.FindStringExact(nombreDepartamento);
                            }
                            else 
                            {
                                MessageBox.Show("No se encontraron datos para el folio seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosPorFolio2(string servicioSeleccionado)
        {
            try 
            {
                string query1 = "";
                string query2 = "";
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    query1 = @"
                            SELECT idDetalle AS Numero, 
                                idOrdenCompra AS 'Orden Compra', 
                                Descripcion, cantidad AS Cantidad, 
                                medida AS Medida, 
                                precio AS Precio, 
                                total AS Total 
                            FROM DetalleCompra
                            WHERE idDetalle = @idDetalle;
                            ;";
                    using (SqlCommand cmd = new SqlCommand(query1,connection))
                    {
                        cmd.Parameters.AddWithValue("@idDetalle", servicioSeleccionado);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                boxCompra.SelectedIndex = boxCompra.FindStringExact(reader["Orden Compra"].ToString());
                                txtFolioDetalle.Text = reader["Numero"].ToString();
                                txtDescripcion.Text = reader["Descripcion"].ToString();
                                txtCantidad.Text = reader["Cantidad"].ToString();
                                txtMedida.Text = reader["Medida"].ToString();
                                txtPrecio.Text = reader["Precio"].ToString();
                                txtTotal.Text = reader["Total"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para el folio seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    query2 = @"SELECT OrdenCompra.idOrdenCompra,
                                OrdenCompra.FolioCompras,
                                OrdenCompra.fecha,
                                OrdenCompra.idProveedor,
                                OrdenCompra.iddepto,
                                OrdenCompra.entrega,
                                OrdenCompra.recibe
                            FROM DetalleCompra
                            JOIN OrdenCompra ON DetalleCompra.idOrdenCompra = DetalleCompra.idOrdenCompra
                            WHERE DetalleCompra.idDetalle = @idDetalle
                    ;";
                    using (SqlCommand cmd = new SqlCommand(query2, connection))
                    {
                        cmd.Parameters.AddWithValue("@idDetalle", servicioSeleccionado);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtOrden.Text = reader["idOrdenCompra"].ToString();
                                txtFolioOrden.Text = reader["FolioCompras"].ToString();
                                dateTimePicker1.Value = Convert.ToDateTime(reader["fecha"]);
                                txtEntrega.Text = reader["entrega"].ToString();
                                txtRecibe.Text = reader["recibe"].ToString();

                                int idProveedor = Convert.ToInt32(reader["idProveedor"]);
                                int idDepartamento = Convert.ToInt32(reader["iddepto"]);
                                reader.Close();

                                string nombreProveedor = "";
                                using (SqlCommand cmdProveedor = new SqlCommand("SELECT Descripcion FROM Proveedor_Compra WHERE idProveedor = @idProveedor;", connection))
                                {
                                    cmdProveedor.Parameters.AddWithValue("@idProveedor", idProveedor);
                                    var resultProveedor = cmdProveedor.ExecuteScalar();
                                    if (resultProveedor != null)
                                    {
                                        nombreProveedor = resultProveedor.ToString();
                                    }
                                }

                                string nombreDepartamento = "";
                                using (SqlCommand cmdDepartamento = new SqlCommand("SELECT descripcion FROM dependencias WHERE id_dependencia = @id_dependencia;", connection))
                                {
                                    cmdDepartamento.Parameters.AddWithValue("@id_dependencia", idDepartamento);
                                    var resultDepartamento = cmdDepartamento.ExecuteScalar();
                                    if (resultDepartamento != null)
                                    {
                                        nombreDepartamento = resultDepartamento.ToString();
                                    }
                                }

                                boxProveedor.SelectedIndex = boxProveedor.FindStringExact(nombreProveedor);
                                boxDepartamento.SelectedIndex = boxDepartamento.FindStringExact(nombreDepartamento);
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para el folio seleccionado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.ProveedorAgregado += LlenarBoxProveedor;
            proveedor.ShowDialog();
        }
    }
}
