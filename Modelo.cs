﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Modelo : Form
    {
        public event Action ModeloAgregada;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;

        private System.Windows.Forms.Timer parpadeoTimer;
        private int parpadeoContador = 0;
        private Color bordeOriginal = Color.Black;
        private Color panelOriginal;
        private bool parpadeoActivo = false;
        private string tipoFiltro, tipoMarca;

        [DllImport("user32.dll")]
        private static extern void MessageBeep(uint uType);
        private const uint MB_ICONERROR = 0x10; // Sonido de error del sistema

        private Control controlActivo = null;
        private Point mouseDownLocation;
        private ConexionSQL conexionSQL;
        public Modelo(string marca, string tipo)
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL();
            tipoFiltro = tipo;
            tipoMarca = marca;
            this.MouseDown += new MouseEventHandler(Modelo_MouseDown);
            //this.MouseMove += new MouseEventHandler(Modelo_MouseMove);
        }

        private void Modelo_Load(object sender, EventArgs e)
        {

            BloquearControles(true);
            conexionSQL.ProbarConexion();

            this.MouseDown += new MouseEventHandler(Modelo_MouseDown);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }
            boxMarca.Enabled = false;
            if (tipoFiltro == "CPU" || tipoFiltro == "PERIFERICOS")
            {
                boxMarca.Items.Clear();
                boxMarca.Items.Add(tipoMarca);
                boxMarca.SelectedIndex = 0;
                label7.Text = tipoMarca;    
            }
            else
            {
                label3.Text = "MARCAS REGISTRADAS";
                label7.Text = "";
                LlenarBoxMarca();
                boxMarca.DropDownStyle = ComboBoxStyle.DropDownList;        
            }

            this.Click += QuitarFoco;
            ConfigurarDataGridView();
            cargarDatosDGV();
            LlenarComboBox();
            dgvModelos.ClearSelection();
            obtenerSiguienteNumero();
            txtFolio.Enabled = false;
        }

        private void LlenarComboBox()
        {
            try
            {
                string query;
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    if (tipoFiltro == "CPU")
                    {
                        query = "SELECT tipos.descripcion FROM tipos WHERE tipos.descripcion IN ('CPU', 'LAPTOP', 'SERVIDOR', 'ALL IN ONE');";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        using (SqlDataReader readear = cmd.ExecuteReader())
                        {
                            boxTipo.Items.Clear();
                            while (readear.Read())
                            {
                                boxTipo.Items.Add(readear["descripcion"].ToString());
                            }
                        }
                    }
                    else if (tipoFiltro == "PERIFERICOS")
                    {
                        query = "SELECT tipos.descripcion FROM tipos WHERE tipos.descripcion NOT IN ('CPU', 'LAPTOP', 'SERVIDOR', 'ALL IN ONE');";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        using (SqlDataReader readear = cmd.ExecuteReader())
                        {
                            boxTipo.Items.Clear();
                            while (readear.Read())
                            {
                                boxTipo.Items.Add(readear["descripcion"].ToString());
                            }
                        }
                    }
                    else 
                    {
                        query = "SELECT tipos.descripcion FROM tipos;";
                        using (SqlCommand cmd = new SqlCommand(query,conn))
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            boxTipo.Items.Clear();
                            while (reader.Read())
                            {
                                boxTipo.Items.Add(reader["descripcion"].ToString());
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

        private void LlenarBoxMarca()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    String query = "SELECT marcas.descripcion FROM marcas";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxMarca.Items.Clear();
                        while (reader.Read())
                        {
                            boxMarca.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvModelos.BackgroundColor = Color.White;
            dgvModelos.BorderStyle = BorderStyle.None;
            dgvModelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvModelos.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvModelos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvModelos.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvModelos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvModelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvModelos.Columns.Count == 0)
            {
                dgvModelos.Columns.Add("Numero", "Numero");
                dgvModelos.Columns.Add("Descripcion", "Descripción");
                dgvModelos.Columns.Add("Tipo", "Tipo");
                dgvModelos.Columns.Add("Refaccion", "Refaccion");
            }
            foreach (DataGridViewColumn column in dgvModelos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void cargarDatosDGV()
        {
            try
            {
                string query, queryTipos;
                //Si viene de Hardware, usar una consulta específica para CPU
                if (tipoFiltro == "CPU")
                {
                    query = @"SELECT modelos.id_modelo AS Numero, 
                                 modelos.descripcion AS Descripcion, 
                                 modelos.tipo AS idTipo, 
                                 tipos.descripcion AS Tipo, 
                                 tipos.refaccion AS Refaccion 
                    FROM modelos 
                    JOIN tipos ON modelos.tipo = tipos.id_tipo 
                    JOIN marcas ON marcas.id_marca = modelos.marca 
                    WHERE marcas.descripcion = @marca 
                    AND tipos.descripcion IN ('CPU','SERVIDOR','ALL IN ONE','LAPTOP');";
                }
                else if (tipoFiltro == "PERIFERICOS")
                {
                    //Si viene de Periféricos, excluir CPUs
                        query = @"SELECT modelos.id_modelo AS Numero, 
                                 modelos.descripcion AS Descripcion, 
                                 modelos.tipo AS idTipo, 
                                 tipos.descripcion AS Tipo, 
                                 tipos.refaccion AS Refaccion 
                    FROM modelos 
                    JOIN tipos ON modelos.tipo = tipos.id_tipo 
                    JOIN marcas ON marcas.id_marca = modelos.marca 
                    WHERE marcas.descripcion = @marca 
                    AND tipos.descripcion NOT IN ('CPU','SERVIDOR','ALL IN ONE','LAPTOP');";
                }
                else 
                {
                    //Si no, incluir todo
                    query = @"SELECT modelos.id_modelo AS Numero, 
                                 modelos.descripcion AS Descripcion, 
                                 modelos.tipo AS idTipo, 
                                 tipos.descripcion AS Tipo, 
                                 tipos.refaccion AS Refaccion 
                    FROM modelos 
                    JOIN tipos ON modelos.tipo = tipos.id_tipo 
                    JOIN marcas ON marcas.id_marca = modelos.marca;";
                }
                    using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                    {
                        conexion.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            if (tipoFiltro == "CPU" || tipoFiltro == "PERIFERICOS")
                            {
                                cmd.Parameters.AddWithValue("@marca", boxMarca.Text);
                            }
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                dgvModelos.Rows.Clear();
                                dgvModelos.Columns.Clear();

                                if (tipoFiltro == "CPU")
                                {
                                    DataTable dtTipos = new DataTable();
                                    using (SqlConnection conexionTipos = conexionSQL.ObtenerConexion())
                                    {
                                        conexionTipos.Open();
                                        queryTipos = "SELECT id_tipo, descripcion FROM tipos WHERE tipos.descripcion IN ('CPU', 'LAPTOP', 'SERVIDOR', 'ALL IN ONE');";
                                        using (SqlCommand cmdTipos = new SqlCommand(queryTipos, conexionTipos))
                                        using (SqlDataReader readerTipos = cmdTipos.ExecuteReader())
                                        {
                                            dtTipos.Load(readerTipos);
                                        }
                                    }
                                    dgvModelos.Columns.Add("Numero", "Número");
                                    dgvModelos.Columns.Add("Descripcion", "Descripción");
                                    dgvModelos.Columns.Add("Refaccion", "Refaccion");
                                    DataGridViewComboBoxColumn comboTipo = new DataGridViewComboBoxColumn
                                    {
                                        Name = "Tipo",
                                        HeaderText = "Tipo",
                                        DataPropertyName = "idTipo",
                                        DisplayMember = "descripcion",
                                        ValueMember = "id_tipo",
                                        DataSource = dtTipos,
                                        AutoComplete = true
                                    };
                                    dgvModelos.Columns.Add(comboTipo);
                                }
                                else if (tipoFiltro == "PERIFERICOS")
                                {
                                    DataTable dtTipos = new DataTable();
                                    using (SqlConnection conexionTipos = conexionSQL.ObtenerConexion())
                                    {
                                        conexionTipos.Open();
                                        queryTipos = "SELECT id_tipo, descripcion FROM tipos WHERE tipos.descripcion NOT IN ('CPU', 'LAPTOP', 'SERVIDOR', 'ALL IN ONE');";
                                        using (SqlCommand cmdTipos = new SqlCommand(queryTipos, conexionTipos))
                                        using (SqlDataReader readerTipos = cmdTipos.ExecuteReader())
                                        {
                                            dtTipos.Load(readerTipos);
                                        }
                                    }
                                    dgvModelos.Columns.Add("Numero", "Número");
                                    dgvModelos.Columns.Add("Descripcion", "Descripción");
                                    dgvModelos.Columns.Add("Refaccion", "Refacción");

                                    DataGridViewComboBoxColumn comboTipo = new DataGridViewComboBoxColumn
                                    {
                                        Name = "Tipo",
                                        HeaderText = "Tipo",
                                        DataPropertyName = "idTipo",
                                        DisplayMember = "descripcion",
                                        ValueMember = "id_tipo",
                                        DataSource = dtTipos,
                                        AutoComplete = true
                                    };
                                    dgvModelos.Columns.Add(comboTipo);
                                }
                                else
                                {
                                    DataTable dtTipos = new DataTable();
                                    using (SqlConnection conexionTipos = conexionSQL.ObtenerConexion())
                                    {
                                        conexionTipos.Open();
                                        queryTipos = "SELECT id_tipo, descripcion FROM tipos;";
                                        using (SqlCommand cmdTipos = new SqlCommand(queryTipos, conexionTipos))
                                        using (SqlDataReader readerTipos = cmdTipos.ExecuteReader())
                                        {
                                            dtTipos.Load(readerTipos);
                                        }
                                        dgvModelos.Columns.Add("Numero", "Número");
                                        dgvModelos.Columns.Add("Descripcion", "Descripción");
                                        dgvModelos.Columns.Add("Refaccion", "Refacción");
                                        DataGridViewComboBoxColumn comboTipo = new DataGridViewComboBoxColumn
                                        {
                                            Name = "Tipo",
                                            HeaderText = "Tipo",
                                            DataPropertyName = "idTipo",
                                            DisplayMember = "descripcion",
                                            ValueMember = "id_tipo",
                                            DataSource = dtTipos,
                                            AutoComplete = true
                                        };
                                        dgvModelos.Columns.Add(comboTipo);
                                    }
                                }

                                while (reader.Read())
                                {
                                    int index = dgvModelos.Rows.Add();
                                    dgvModelos.Rows[index].Cells["Numero"].Value = reader["Numero"];
                                    dgvModelos.Rows[index].Cells["Descripcion"].Value = reader["Descripcion"];
                                    dgvModelos.Rows[index].Cells["Tipo"].Value = reader["idTipo"];
                                    dgvModelos.Rows[index].Cells["Refaccion"].Value = reader["Refaccion"];
                                }
                                dgvModelos.Columns["Numero"].ReadOnly = true;
                                dgvModelos.Columns["Descripcion"].ReadOnly = false;
                                dgvModelos.Columns["Tipo"].ReadOnly = false;
                                dgvModelos.Columns["Refaccion"].ReadOnly = true;
                                dgvModelos.Columns["Numero"].DisplayIndex = 0;
                                dgvModelos.Columns["Descripcion"].DisplayIndex = 1;
                                dgvModelos.Columns["Refaccion"].DisplayIndex = 2;
                                dgvModelos.Columns["Tipo"].DisplayIndex = 3;
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
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
            parpadeoActivo = true; // Indica que el parpadeo está en proceso
            parpadeoContador = 0;

            if (parpadeoTimer == null)
            {
                parpadeoTimer = new System.Windows.Forms.Timer();
                parpadeoTimer.Interval = 150; // 150 ms
                parpadeoTimer.Tick += (sender, e) =>
                {
                    if (parpadeoContador >= 6) // 3 ciclos de parpadeo
                    {
                        parpadeoTimer.Stop();
                        bordeOriginal = Color.Black; // Restaurar borde
                        this.Invalidate(); // Redibujar
                        parpadeoActivo = false; // Permitir que se active de nuevo si es necesario
                    }
                    else
                    {
                        // Alternar entre blanco y negro
                        bordeOriginal = (bordeOriginal == Color.Black) ? Color.White : Color.Black;
                        this.Invalidate();
                        parpadeoContador++;
                    }
                };
            }

            parpadeoTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(bordeOriginal, 3))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        private void LimpiarControles()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    if (textBox.Name != "txtFolio")
                    {
                        textBox.Clear();
                    }
                }
                else if (ctrl is ComboBox comboBox)
                {
                    if (comboBox.Name == "boxMarca")
                    {
                        continue;
                    }

                    comboBox.SelectedIndex = -1;
                    comboBox.Text = String.Empty;

                    if (comboBox.Items.Contains("-"))
                    {
                        comboBox.SelectedItem = "-";
                    }
                }
            }
        }


        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    try
                    {
                        connection.Open();
                        string idMarca = "";
                        string idTipo = "";
                        string queryMarca = "SELECT marcas.id_marca FROM marcas WHERE marcas.descripcion = @descripcionMarca;";
                        using (SqlCommand cmd = new SqlCommand(queryMarca, connection))
                        {
                            cmd.Parameters.AddWithValue("@descripcionMarca", boxMarca.Text);
                            object result = cmd.ExecuteScalar();
                            idMarca = (result != null) ? result.ToString() : "";
                        }
                        string queryTipo = "SELECT tipos.id_tipo FROM tipos WHERE tipos.descripcion = @descripcionModelo;";
                        using (SqlCommand cmd = new SqlCommand(queryTipo, connection))
                        {
                            cmd.Parameters.AddWithValue("@descripcionModelo", boxTipo.Text);
                            object result = cmd.ExecuteScalar();
                            idTipo = (result != null) ? result.ToString() : "";
                        }
                        string insertQuery = "INSERT INTO modelos(id_modelo, descripcion, marca, cartuchos, tipo) VALUES(@folio, @descripcion, @marca, 0, @tipo);";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@folio", txtFolio.Text);
                            insertCmd.Parameters.AddWithValue("@descripcion", txtModelo.Text);
                            insertCmd.Parameters.AddWithValue("@marca", idMarca);
                            insertCmd.Parameters.AddWithValue("@tipo", idTipo);
                            insertCmd.ExecuteNonQuery();
                            if (tipoFiltro != "SIN TIPO")
                            {
                                ModeloAgregada.Invoke();
                            }
                            MessageBox.Show("Registro agredado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        LimpiarControles();
                        cargarDatosDGV();
                        obtenerSiguienteNumero();
                        BloquearControles(true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvModelos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un modelo para eliminar");
                return;
            }
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar lo(s) modelos(s) seleccionado(s)?",
                                            "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes) return;
            foreach (DataGridViewRow row in dgvModelos.SelectedRows)
            {
                if (row.Cells["Numero"].Value == null) continue;
                int idModelo = Convert.ToInt32(row.Cells["Numero"].Value);
                try
                {
                    string queryDelete = "DELETE FROM modelos WHERE id_modelo = @idModelo;";
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(queryDelete, connection))
                        {
                            cmd.Parameters.AddWithValue("@idModelo", idModelo);
                            cmd.ExecuteNonQuery();
                        }
                        if (tipoFiltro != "SIN TIPO")
                        {
                            ModeloAgregada.Invoke();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar modelo(s) ID " + idModelo + ": " + ex.Message);
                    return;
                }
            }
            MessageBox.Show("Registro eliminado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarDatosDGV();
            obtenerSiguienteNumero();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea acutalizar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                bool cambiosRealizados = false;
                foreach (DataGridViewRow row in dgvModelos.Rows)
                {
                    if (row.IsNewRow) continue;
                    int idModelo = Convert.ToInt32(row.Cells["Numero"].Value);
                    string nuevaDescripcion = row.Cells["Descripcion"].Value.ToString().ToUpper();
                    int nuevoIdTipo = Convert.ToInt32(row.Cells["Tipo"].Value);
                    row.Cells["Descripcion"].Value = nuevaDescripcion;
                    try
                    {
                        using (SqlConnection connection = conexionSQL.ObtenerConexion())
                        {
                            connection.Open();
                            string queryUpdate;
                            queryUpdate = "UPDATE modelos SET descripcion = @descripcion, tipo = @tipo WHERE id_modelo = @idModelo;";
                            using (SqlCommand cmd = new SqlCommand(queryUpdate, connection))
                            {
                                cmd.Parameters.AddWithValue("@descripcion", nuevaDescripcion);
                                cmd.Parameters.AddWithValue("@idModelo", idModelo);
                                cmd.Parameters.AddWithValue("@tipo", nuevoIdTipo);
                                cmd.ExecuteNonQuery();
                                if (tipoFiltro != "SIN TIPO")
                                {
                                    ModeloAgregada.Invoke();
                                }
                            }
                        }
                        cambiosRealizados = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex.Message);
                        return;
                    }
                }
                if (cambiosRealizados)
                {
                    MessageBox.Show("Registro actualizado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatosDGV();
                }
                else
                {
                    MessageBox.Show("Registro actualizado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatosDGV();
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            obtenerSiguienteNumero();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            boxMarca.Enabled = false;
            BloquearControles(true);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void BloquearControles(bool bloquear)
        {
            txtModelo.Enabled = !bloquear;
            boxTipo.Enabled = !bloquear;
            btnNuevo.Enabled = bloquear;    // "Nuevo" solo está habilitado cuando los demás están bloqueados
            btnAceptar.Enabled = !bloquear; // "Aceptar" solo se habilita cuando los controles están activos
            btnCancelar.Enabled = !bloquear; // "Cancelar" solo se habilita cuando los controles están activos
            if (tipoFiltro == "SIN TIPO")
            {
                    boxMarca.Enabled = !bloquear;
            }
        }

        private void Modelo_MouseDown(object sender, MouseEventArgs e)
        {
            if (validarComboBox())
                return;

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE, 0);
            }
        }

        //private void Modelo_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (validarComboBox())
        //    {
        //        return;
        //    }
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        this.Left += e.X - mouseDownLocation.X;
        //        this.Top += e.Y - mouseDownLocation.Y;
        //    }
        //}

        private void obtenerSiguienteNumero()
        {
            try
            {   
                using(SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(id_modelo), 0) + 1 AS SiguienteNumero FROM modelos;";
                    using(SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        txtFolio.Text = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            string mensajeError = "Faltan los siguientes campos:\n";
            if (string.IsNullOrWhiteSpace(txtFolio.Text))
            {
                mensajeError += "- Especifique un numero valido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                mensajeError += "- Especifique un modelo valido.\n";
                esValido = false;
            }
            if (boxTipo.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxTipo.Text))
            {
                mensajeError += "- Especifique un tipo de modelo valido.\n";
                esValido = false;
            }
            if (!esValido)
            {
                MessageBox.Show(mensajeError, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }

        private bool validarComboBox()
        {
            return boxTipo.DroppedDown;
        }
    }
}
