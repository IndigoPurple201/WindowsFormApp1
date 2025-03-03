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

        [DllImport("user32.dll")]
        private static extern void MessageBeep(uint uType);
        private const uint MB_ICONERROR = 0x10; // Sonido de error del sistema

        private Control controlActivo = null;
        private Point mouseDownLocation;
        private string connectionString = "Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;";
        public Modelo(string marca)
        {
            InitializeComponent();
            txtMarca.Text = marca;
            txtMarca.Enabled = false;

            this.MouseDown += new MouseEventHandler(Modelo_MouseDown);
            //this.MouseMove += new MouseEventHandler(Modelo_MouseMove);
        }

        private void Modelo_Load(object sender, EventArgs e)
        {
            BloquearControles(true);
            ConexionSQL conexion = new ConexionSQL();
            conexion.ProbarConexion();
            
            this.MouseDown += new MouseEventHandler(Modelo_MouseDown);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }
            this.Click += QuitarFoco;
            ConfigurarDataGridView();
            cargarDatosDGV();
            label7.Text = txtMarca.Text;
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT tipos.descripcion FROM tipos;";
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

            dgvModelos.Columns["Numero"].ReadOnly = true;
            dgvModelos.Columns["Descripcion"].ReadOnly = false;
            dgvModelos.Columns["Tipo"].ReadOnly = false;
            dgvModelos.Columns["Refaccion"].ReadOnly = true;
        }

        private void cargarDatosDGV()
        {
            try
            {
                string query = @"SELECT modelos.id_modelo AS Numero, modelos.descripcion AS Descripcion, modelos.tipo AS idTipo, tipos.descripcion AS Tipo, tipos.refaccion AS Refaccion FROM modelos JOIN tipos ON modelos.tipo = tipos.id_tipo JOIN marcas ON marcas.id_marca = modelos.marca WHERE marcas.descripcion = @marca;";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvModelos.Rows.Clear();

                            if (dgvModelos.Columns.Count == 0)
                            {
                                dgvModelos.Columns.Add("Numero", "Número");
                                dgvModelos.Columns.Add("Descripcion", "Descripción");
                                dgvModelos.Columns.Add("Refaccion", "Refacción");
                                DataGridViewComboBoxColumn comboTipo = new DataGridViewComboBoxColumn
                                {
                                    Name = "Tipo",
                                    HeaderText = "Tipo",
                                    DataPropertyName = "idTipo",
                                    DisplayMember = "descripcionTipo",
                                    ValueMember = "id_tipo"
                                };
                                using (SqlConnection conexionTipos = new SqlConnection(connectionString))
                                {
                                    conexionTipos.Open();
                                    string queryTipos = "SELECT id_tipo, descripcion FROM tipos;";
                                    using (SqlCommand cmdTipos = new SqlCommand(queryTipos, conexionTipos))
                                    using (SqlDataReader readerTipos = cmdTipos.ExecuteReader())
                                    {
                                        DataTable dtTipos = new DataTable();
                                        dtTipos.Load(readerTipos);
                                        comboTipo.DataSource = dtTipos;
                                    }
                                }
                                dgvModelos.Columns.Add(comboTipo);
                            }
                            while (reader.Read())
                            {
                                int index = dgvModelos.Rows.Add();
                                dgvModelos.Rows[index].Cells["Numero"].Value = reader["Numero"];
                                dgvModelos.Rows[index].Cells["Descripcion"].Value = reader["Descripcion"];
                                dgvModelos.Rows[index].Cells["Refaccion"].Value = reader["Refaccion"];
                                dgvModelos.Rows[index].Cells["Tipo"].Value = reader["Tipo"];
                            }
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
                    // Si el TextBox es el de la marca, NO lo limpiamos
                    if (textBox.Name != "txtMarca")
                    {
                        textBox.Clear();
                    }
                }
                else if (ctrl is ComboBox comboBox)
                {
                    if (comboBox.Items.Contains("-"))
                    {
                        comboBox.SelectedItem = "-";
                    }
                    else
                    {
                        comboBox.SelectedIndex = -1;
                        comboBox.Text = String.Empty;
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string idMarca = "";
                        string idTipo = "";
                        string queryMarca = "SELECT marcas.id_marca FROM marcas WHERE marcas.descripcion = @descripcionMarca;";
                        using (SqlCommand cmd = new SqlCommand(queryMarca, connection))
                        {
                            cmd.Parameters.AddWithValue("@descripcionMarca", txtMarca.Text);
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
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery,connection))   
                        {
                            insertCmd.Parameters.AddWithValue("@folio", txtFolio.Text); 
                            insertCmd.Parameters.AddWithValue("@descripcion", txtModelo.Text);
                            insertCmd.Parameters.AddWithValue("@marca", idMarca);
                            insertCmd.Parameters.AddWithValue("@tipo", idTipo);
                            insertCmd.ExecuteNonQuery();
                            ModeloAgregada.Invoke();
                            MessageBox.Show("Modelo agregado correctamente");
                            LimpiarControles();
                        }
                        cargarDatosDGV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            txtMarca.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            txtMarca.Enabled = false;
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
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enabled = !bloquear; // Deshabilita o habilita los controles
                }
            }
            btnNuevo.Enabled = bloquear;    // "Nuevo" solo está habilitado cuando los demás están bloqueados
            btnAceptar.Enabled = !bloquear; // "Aceptar" solo se habilita cuando los controles están activos
            btnCancelar.Enabled = !bloquear; // "Cancelar" solo se habilita cuando los controles están activos
        }

        private void Modelo_MouseDown(object sender, MouseEventArgs e)
        {
            if (validarComboBox()) // Si el ComboBox está abierto, no mover la ventana
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
