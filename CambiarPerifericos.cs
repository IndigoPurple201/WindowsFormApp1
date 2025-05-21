using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CambiarPerifericos: Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private System.Windows.Forms.Timer parpadeoTimer;
        private int parpadeoContador = 0;
        private Color bordeOriginal = Color.Black;
        private Color panelOriginal;
        private bool parpadeoActivo = false;
        [DllImport("user32.dll")]
        private static extern void MessageBeep(uint uType);
        private const uint MB_ICONERROR = 0x10;
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private ConexionSQL conexionSQL;
        public CambiarPerifericos()
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL(udlFilePath);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);
            this.MouseDown += new MouseEventHandler(CambiarPerifericos_MouseDown);
            this.MouseClick += new MouseEventHandler(CambiarPerifericos_MouseClick);
        }

        private void CambiarPerifericos_Load(object sender, EventArgs e)
        {
            conexionSQL.ProbarConexion();
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }
            this.Click += QuitarFoco;
            ConfigurarDataGridView1();
            ConfigurarDataGridView2();
        }

        private void CambiarPerifericos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + 0x2 + 0x9, 0);
            }
        }

        private void ControlSeleccionado(object sender, EventArgs e)
        {
            if (sender is TextBox || sender is ComboBox)
            {
                controlActivo = sender as Control;
            }
        }

        private void QuitarFoco(object sender, EventArgs e)
        {
            if (controlActivo != null && !controlActivo.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                this.ActiveControl = null;
                controlActivo = null;
            }
        }

        private void ConfigurarDataGridView1()
        {
            dgvPerifericos1.BackgroundColor = Color.White;
            dgvPerifericos1.BorderStyle = BorderStyle.None;
            dgvPerifericos1.AllowUserToAddRows = false;
            dgvPerifericos1.RowHeadersVisible = false;
            dgvPerifericos1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPerifericos1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvPerifericos1.RowTemplate.Height = 20;
            dgvPerifericos1.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvPerifericos1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvPerifericos1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvPerifericos1.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvPerifericos1.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPerifericos1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPerifericos1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPerifericos1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPerifericos1.ColumnHeadersHeight = 35; // Aumenta la altura del encabezado
            dgvPerifericos1.EnableHeadersVisualStyles = false;
            dgvPerifericos1.AllowUserToResizeRows = false;
            dgvPerifericos1.AllowUserToResizeColumns = false;
            if (dgvPerifericos1.Columns.Count == 0)
            {
                dgvPerifericos1.Columns.Add("Numero", "Número");
                dgvPerifericos1.Columns.Add("Didecon", "Didecon");
                dgvPerifericos1.Columns.Add("Tipo", "Tipo");
                dgvPerifericos1.Columns.Add("Marca", "Marca");
                dgvPerifericos1.Columns.Add("Modelo", "Modelo");
                dgvPerifericos1.Columns.Add("N. Serie", "N. Serie");
                dgvPerifericos1.Columns.Add("Act. Contraloria", "Act. Contraloria");
                dgvPerifericos1.Columns.Add("Departamento", "Departamento");
                dgvPerifericos1.Columns.Add("Area", "Area");
                dgvPerifericos1.Columns.Add("Responsable", "Responsable");
                dgvPerifericos1.Columns.Add("Estatus", "Estatus");
            }
            dgvPerifericos1.ReadOnly = true;
            foreach (DataGridViewColumn column in dgvPerifericos1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ConfigurarDataGridView2()
        {
            dgvPerifericos2.BackgroundColor = Color.White;
            dgvPerifericos2.BorderStyle = BorderStyle.None;
            dgvPerifericos2.AllowUserToAddRows = false;
            dgvPerifericos2.RowHeadersVisible = false;

            dgvPerifericos2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPerifericos2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvPerifericos2.RowTemplate.Height = 20;

            dgvPerifericos2.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvPerifericos2.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvPerifericos2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvPerifericos2.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvPerifericos2.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPerifericos2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPerifericos2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPerifericos2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPerifericos2.ColumnHeadersHeight = 35; // Aumenta la altura del encabezado
            dgvPerifericos2.EnableHeadersVisualStyles = false;
            dgvPerifericos2.AllowUserToResizeRows = false;
            dgvPerifericos2.AllowUserToResizeColumns = false;
            if (dgvPerifericos2.Columns.Count == 0)
            {
                dgvPerifericos2.Columns.Add("Numero", "Número");
                dgvPerifericos2.Columns.Add("Didecon", "Didecon");
                dgvPerifericos2.Columns.Add("Tipo", "Tipo");
                dgvPerifericos2.Columns.Add("Marca", "Marca");
                dgvPerifericos2.Columns.Add("Modelo", "Modelo");
                dgvPerifericos2.Columns.Add("N. Serie", "N. Serie");
                dgvPerifericos2.Columns.Add("Act. Contraloria", "Act. Contraloria");
                dgvPerifericos2.Columns.Add("Departamento", "Departamento");
                dgvPerifericos2.Columns.Add("Area", "Area");
                dgvPerifericos2.Columns.Add("Responsable", "Responsable");
                dgvPerifericos2.Columns.Add("Estatus", "Estatus");
            }
            dgvPerifericos2.ReadOnly = true;
            foreach (DataGridViewColumn column in dgvPerifericos2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void txtBuscarActivo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }

        private void txtBuscarActivo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                string query1 = "";
                string query2 = "";
                string didecon1 = "";
                string didecon2 = "";
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();

                    query2 = @"SELECT DISTINCT hardware.didecon FROM hardware WHERE hardware.activocontraloria = @activo;";

                    query1 = @"SELECT DISTINCT perifericos.folio AS Numero, 
                        perifericos.didecon AS Didecon,  
                        tipos.descripcion AS Tipo, 
                        marcas.descripcion AS Marca, 
                        modelos.descripcion AS Modelo, 
                        perifericos.sn AS 'N. Serie', 
                        perifericos.activocontraloria AS 'Act. Contraloria', 
                        dependencias.descripcion AS Departamento, 
                        hardware.area AS Area, 
                        hardware.responsable AS Responsable, 
                        estatus.descripcion AS Estatus 
                    FROM perifericos 
                    JOIN tipos ON tipos.id_tipo = perifericos.tipo 
                    JOIN marcas ON marcas.id_marca = perifericos.marca 
                    JOIN modelos ON modelos.id_modelo = perifericos.modelo 
                    JOIN hardware ON hardware.didecon = perifericos.didecon 
                    JOIN dependencias ON dependencias.id_dependencia = hardware.depto 
                    JOIN estatus ON estatus.id_estatus = perifericos.idestatus 
                    WHERE tipos.descripcion NOT IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')
                    AND estatus.descripcion = 'ACTIVO'
                    AND hardware.didecon = @didecon
                    ORDER BY Numero ASC;";

                    using (SqlCommand cmd = new SqlCommand(query2,connection))
                    {
                        cmd.Parameters.AddWithValue("@activo", txtBuscarActivo1.Text.Trim());
                        object result = cmd.ExecuteScalar();
                        didecon1 = (result != null) ? result.ToString() : null;
                    }

                    using (SqlCommand cmd = new SqlCommand(query2,connection))
                    {
                        cmd.Parameters.AddWithValue("@activo", txtBuscarActivo2.Text.Trim());
                        object result = cmd.ExecuteScalar();
                        didecon2 = (result != null) ? result.ToString() : null;
                    }

                    using (SqlCommand cmd = new SqlCommand(query1, connection))
                    {
                        cmd.Parameters.AddWithValue("@didecon", didecon1);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvPerifericos1.Rows.Clear();
                            dgvPerifericos1.Columns.Clear();

                            dgvPerifericos1.Columns.Add("Numero", "Número");
                            dgvPerifericos1.Columns.Add("Didecon", "Didecon");
                            dgvPerifericos1.Columns.Add("Tipo", "Tipo");
                            dgvPerifericos1.Columns.Add("Marca", "Marca");
                            dgvPerifericos1.Columns.Add("Modelo", "Modelo");
                            dgvPerifericos1.Columns.Add("N. Serie", "N. Serie");
                            dgvPerifericos1.Columns.Add("Act. Contraloria", "Act. Contraloria");
                            dgvPerifericos1.Columns.Add("Departamento", "Departamento");
                            dgvPerifericos1.Columns.Add("Area", "Area");
                            dgvPerifericos1.Columns.Add("Responsable", "Responsable");
                            dgvPerifericos1.Columns.Add("Estatus", "Estatus");
                            while (reader.Read())
                            {
                                int index = dgvPerifericos1.Rows.Add();
                                dgvPerifericos1.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                dgvPerifericos1.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                dgvPerifericos1.Rows[index].Cells["Tipo"].Value = reader["Tipo"].ToString();
                                dgvPerifericos1.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                dgvPerifericos1.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                dgvPerifericos1.Rows[index].Cells["N. Serie"].Value = reader["N. Serie"].ToString();
                                dgvPerifericos1.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                dgvPerifericos1.Rows[index].Cells["Departamento"].Value = reader["Departamento"].ToString();
                                dgvPerifericos1.Rows[index].Cells["Area"].Value = reader["Area"].ToString();
                                dgvPerifericos1.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                dgvPerifericos1.Rows[index].Cells["Estatus"].Value = reader["Estatus"].ToString();
                            }
                            this.BeginInvoke((MethodInvoker)delegate {
                                dgvPerifericos1.ClearSelection();
                            });
                        }
                    }

                    using (SqlCommand cmd2 = new SqlCommand(query1,connection))
                    {
                        cmd2.Parameters.AddWithValue("@didecon",didecon2);
                        using (SqlDataReader reader2 = cmd2.ExecuteReader())
                        {
                            dgvPerifericos2.Rows.Clear();
                            dgvPerifericos2.Columns.Clear();

                            dgvPerifericos2.Columns.Add("Numero", "Número");
                            dgvPerifericos2.Columns.Add("Didecon", "Didecon");
                            dgvPerifericos2.Columns.Add("Tipo", "Tipo");
                            dgvPerifericos2.Columns.Add("Marca", "Marca");
                            dgvPerifericos2.Columns.Add("Modelo", "Modelo");
                            dgvPerifericos2.Columns.Add("N. Serie", "N. Serie");
                            dgvPerifericos2.Columns.Add("Act. Contraloria", "Act. Contraloria");
                            dgvPerifericos2.Columns.Add("Departamento", "Departamento");
                            dgvPerifericos2.Columns.Add("Area", "Area");
                            dgvPerifericos2.Columns.Add("Responsable", "Responsable");
                            dgvPerifericos2.Columns.Add("Estatus", "Estatus");
                            while (reader2.Read())
                            {
                                int index = dgvPerifericos2.Rows.Add();
                                dgvPerifericos2.Rows[index].Cells["Numero"].Value = reader2["Numero"].ToString();
                                dgvPerifericos2.Rows[index].Cells["Didecon"].Value = reader2["Didecon"].ToString();
                                dgvPerifericos2.Rows[index].Cells["Tipo"].Value = reader2["Tipo"].ToString();
                                dgvPerifericos2.Rows[index].Cells["Marca"].Value = reader2["Marca"].ToString();
                                dgvPerifericos2.Rows[index].Cells["Modelo"].Value = reader2["Modelo"].ToString();
                                dgvPerifericos2.Rows[index].Cells["N. Serie"].Value = reader2["N. Serie"].ToString();
                                dgvPerifericos2.Rows[index].Cells["Act. Contraloria"].Value = reader2["Act. Contraloria"].ToString();
                                dgvPerifericos2.Rows[index].Cells["Departamento"].Value = reader2["Departamento"].ToString();
                                dgvPerifericos2.Rows[index].Cells["Area"].Value = reader2["Area"].ToString();
                                dgvPerifericos2.Rows[index].Cells["Responsable"].Value = reader2["Responsable"].ToString();
                                dgvPerifericos2.Rows[index].Cells["Estatus"].Value = reader2["Estatus"].ToString();
                            }
                            this.BeginInvoke((MethodInvoker)delegate {
                                dgvPerifericos2.ClearSelection();
                            });
                        }
                    }
                }
            }
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            string mensajeError = "Los siguientes campos son inválidos:\n";

            if (string.IsNullOrWhiteSpace(txtBuscarActivo1.Text))
            {
                mensajeError += "- Especifique un Activo 1 válido.\n";
                esValido = false;
            }
            else if (!ExisteActivo(txtBuscarActivo1.Text))
            {
                mensajeError += "- El Activo 1 ingresado no existe.\n";
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(txtBuscarActivo2.Text))
            {
                mensajeError += "- Especifique un Activo 2 válido.\n";
                esValido = false;
            }
            else if (!ExisteActivo(txtBuscarActivo2.Text))
            {
                mensajeError += "- El Activo 2 ingresado no existe.\n";
                esValido = false;
            }

            if (!esValido)
            {
                MessageBox.Show(mensajeError, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return esValido;
        }

        private bool ExisteActivo(string activo)
        {
            bool existe = false;
            string query = "SELECT COUNT(*) FROM hardware WHERE hardware.activocontraloria = @activo;";

            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@activo", activo);
                        existe = (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar el activo: " + ex.Message);
            }

            return existe;
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            //LimpiarControles();
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(bordeOriginal, 3))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCACTIVATE = 0x86;

            if (m.Msg == WM_NCACTIVATE && m.WParam.ToInt32() == 0 && !parpadeoActivo)
            {
                IniciarParpadeo();
                MessageBeep(MB_ICONERROR);
            }

            base.WndProc(ref m);
        }

        private void IniciarParpadeo()
        {
            parpadeoActivo = true;
            parpadeoContador = 0;

            if (parpadeoTimer == null)
            {
                parpadeoTimer = new System.Windows.Forms.Timer();
                parpadeoTimer.Interval = 150;
                parpadeoTimer.Tick += (sender, e) =>
                {
                    if (parpadeoContador >= 6)
                    {
                        parpadeoTimer.Stop();
                        bordeOriginal = Color.Black;
                        this.Invalidate();
                        parpadeoActivo = false;
                    }
                    else
                    {
                        bordeOriginal = (bordeOriginal == Color.Black) ? Color.White : Color.Black;
                        this.Invalidate();
                        parpadeoContador++;
                    }
                };
            }
            parpadeoTimer.Start();
        }

        private void btnBuscar1_Click(object sender, EventArgs e)
        {
            using (var buscarHardware = new BuscarPerifericos("CPU-2"))
            {
                if (buscarHardware.ShowDialog() == DialogResult.OK)
                {
                    string folio = buscarHardware .FolioSeleccionado;
                    if (!string.IsNullOrEmpty(folio))
                    {
                        try 
                        {
                            long activo = 0;
                            string query = "SELECT hardware.activocontraloria AS Actico FROM hardware WHERE hardware.folio = @folio;";
                            using (SqlConnection connection = conexionSQL.ObtenerConexion())
                            {
                                connection.Open();
                                using (SqlCommand cmd = new SqlCommand(query,connection))
                                {
                                    cmd.Parameters.AddWithValue("@folio", folio);
                                    object result = cmd.ExecuteScalar();
                                    activo = (result != null) ? Convert.ToInt64(result) : 0;

                                }
                            }
                            txtBuscarActivo1.Text = activo.ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se seleccionó ningún folio.");
                    }
                }
            }
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            using (var buscarHardware = new BuscarPerifericos("CPU-2"))
            {
                if (buscarHardware.ShowDialog() == DialogResult.OK)
                {
                    string folio = buscarHardware.FolioSeleccionado;
                    if (!string.IsNullOrEmpty(folio))
                    {
                        try 
                        {
                            long activo = 0;
                            string query = "SELECT hardware.activocontraloria AS Actico FROM hardware WHERE hardware.folio = @folio;";
                            using (SqlConnection connection = conexionSQL.ObtenerConexion())
                            {
                                connection.Open();
                                using (SqlCommand cmd = new SqlCommand(query,connection))
                                {
                                    cmd.Parameters.AddWithValue("@folio", folio);
                                    object result = cmd.ExecuteScalar();
                                    activo = (result != null) ? Convert.ToInt64(result) : 0;
                                }
                            }
                            txtBuscarActivo2.Text = activo.ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    else 
                    {
                        MessageBox.Show("No se seleccionó ningún folio.");
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbFlechaDerecha_Click(object sender, EventArgs e)
        {
            if (dgvPerifericos1.CurrentRow != null)
            {
                int index = dgvPerifericos2.Rows.Add();
                foreach (DataGridViewCell cell in dgvPerifericos1.CurrentRow.Cells)
                {
                    dgvPerifericos2.Rows[index].Cells[cell.ColumnIndex].Value = cell.Value;
                }
                dgvPerifericos1.Rows.RemoveAt(dgvPerifericos1.CurrentRow.Index);
            }
            else 
            {
                MessageBox.Show("No se ha seleccionado ningún elemento para mover.");
            }
        }

        private void pbFlechaIzquierda_Click(object sender, EventArgs e)
        {
            if (dgvPerifericos2.CurrentRow != null)
            {
                int index = dgvPerifericos1.Rows.Add();
                foreach (DataGridViewCell cell in dgvPerifericos2.CurrentRow.Cells)
                {
                    dgvPerifericos1.Rows[index].Cells[cell.ColumnIndex].Value = cell.Value;
                }
                dgvPerifericos2.Rows.RemoveAt(dgvPerifericos2.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún elemento para mover.");
            }
        }

        private void CambiarPerifericos_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dgvPerifericos1.Bounds.Contains(e.Location))
            {
                dgvPerifericos1.ClearSelection();
            }
            if (!dgvPerifericos2.Bounds.Contains(e.Location))
            {
                dgvPerifericos2.ClearSelection();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea cambiar los perifericos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                if (ValidarCampos())
                {
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        int registrosActualizados = 0;
                        string activo1 = txtBuscarActivo1.Text.Trim();
                        string didecon1 = ObtenerDideconDesdeActivo(connection, activo1);
                        if (didecon1 != null)
                        {
                            foreach (DataGridViewRow row in dgvPerifericos1.Rows)
                            {
                                if (row.Cells["Numero"].Value != null && row.Cells["Didecon"].Value != null)
                                {
                                    string dideconActual = row.Cells["Didecon"].Value.ToString();
                                    if (dideconActual != didecon1)
                                    {
                                        int folio = Convert.ToInt32(row.Cells["Numero"].Value);
                                        string queryUpdate = "UPDATE perifericos SET didecon = @nuevoDidecon WHERE folio = @folio";
                                        using (SqlCommand cmd = new SqlCommand(queryUpdate, connection))
                                        {
                                            cmd.Parameters.AddWithValue("@nuevoDidecon", didecon1);
                                            cmd.Parameters.AddWithValue("@folio", folio);
                                            registrosActualizados += cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }

                        string activo2 = txtBuscarActivo2.Text.Trim();
                        string didecon2 = ObtenerDideconDesdeActivo(connection, activo2);
                        if (didecon2 != null)
                        {
                            foreach (DataGridViewRow row in dgvPerifericos2.Rows)
                            {
                                if (row.Cells["Numero"].Value != null && row.Cells["Didecon"].Value != null)
                                {
                                    string dideconActual = row.Cells["Didecon"].Value.ToString();
                                    if (dideconActual != didecon2)
                                    {
                                        int folio = Convert.ToInt32(row.Cells["Numero"].Value);
                                        string queryUpdate = "UPDATE perifericos SET didecon = @nuevoDidecon WHERE folio = @folio";
                                        using (SqlCommand cmd = new SqlCommand(queryUpdate, connection))
                                        {
                                            cmd.Parameters.AddWithValue("@nuevoDidecon", didecon2);
                                            cmd.Parameters.AddWithValue("@folio", folio);
                                            registrosActualizados += cmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }
                        if (registrosActualizados > 0)
                        {
                            MessageBox.Show("Cambios realizados correctamente");
                            btnBuscar_Click(null, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron registros para actualizar.");
                        }
                    }
                }
            }
        }

        private string ObtenerDideconDesdeActivo(SqlConnection connection, string activoContraloria)
        {
            string query = "SELECt DISTINCT hardware.didecon FROM hardware WHERE hardware.activocontraloria = @activoContraloria;";
            using (SqlCommand cmd = new SqlCommand(query,connection))
            {
                cmd.Parameters.AddWithValue("@activoContraloria", activoContraloria);
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }
    }
}
