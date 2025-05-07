using Microsoft.Data.SqlClient;
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
    public partial class Servicios: Form
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
        public Servicios()
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL(udlFilePath);
            this.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            //this.MouseMove += new MouseEventHandler(Hardware_MouseMove);
            panelBarra.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            label1.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            panel1.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            panel2.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            panel3.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            tabPage1.MouseDown += new MouseEventHandler(Servicios_MouseDown);
        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            conexionSQL.ProbarConexion();
            LlenarBoxEstatus();
            BloquearControles(this, true);
            this.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }
            this.Click += QuitarFoco;
            dateEntrada.Enabled = false;
            dateSalida.Enabled = false;
            dateReparacion.Enabled = false;
            dateRefaccionPedido.Enabled = false;
            dateRefaccionEntrega.Enabled = false;
            dateExternoPedido.Enabled = false;
            dateExternoEntrega.Enabled = false;
            ObtenerSiguienteNumero();
        }

        private void ObtenerSiguienteNumero()
        {
            try 
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(id_servicio), 0) + 1 AS SiguienteNumero FROM servicios;";
                    using (SqlCommand cmd = new SqlCommand(query,connection))
                    {
                        object result = cmd.ExecuteScalar();
                        txtServicio.Text = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LlenarBoxEstatus()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    String query = "SELECT estatus.descripcion FROM estatus;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxEstatus.Items.Clear();
                        while (reader.Read())
                        {
                            boxEstatus.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                    int indexRecibido = boxEstatus.Items.IndexOf("RECIBIDO");
                    if (indexRecibido >= 0)
                    {
                        boxEstatus.SelectedIndex = indexRecibido;
                        boxEstatus.Enabled = false; // Bloquear el ComboBox
                    }
                    else
                    {
                        MessageBox.Show("El estatus 'Recibido' no se encontró.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Servicios_MouseDown(object sender, MouseEventArgs e)
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

        private void panelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void tabPage1_MouseDownn(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void BloquearControles(Control parent, bool bloquear)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enabled = !bloquear;
                }

                if (ctrl.HasChildren)
                {
                    BloquearControles(ctrl, bloquear);
                }
            }
            btnNuevo.Enabled = bloquear;
            btnAceptar.Enabled = !bloquear;
            btnCancelar.Enabled = !bloquear;
            btnActualizar.Enabled = !bloquear;
            btnEliminar.Enabled = !bloquear;
            btnBuscar.Enabled = !bloquear;
            btnSalir.Enabled = bloquear;
        }

        private void LimpiarControles()
        {
            //txtServicio.Clear();
            txtFolio.Clear();
            txtDidecon.Clear();
            txtFalla.Clear();
            txtSolicito.Clear();
            txtRecogio.Clear();
            txtServicio.Clear();
        }

        private void RestablecerComboBox(ComboBox comboBox, string valorPredeterminado)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(valorPredeterminado);
            comboBox.SelectedIndex = 0;
        }


        private void RestablecerComboBoxSinPredeterminado(ComboBox comboBox)
        {
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = -1;
                comboBox.ResetText();
            }
        }

        private bool validarComboBox()
        {
            return boxEstatus.DroppedDown || boxExterno.DroppedDown;
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(this, false);
            btnSalir.Enabled = true;
            dateEntrada.Enabled = true;
            if (boxEstatus.Items.Count == 1)
            {
                boxEstatus.SelectedIndex = 0;
                boxEstatus.Enabled = false;
            }
            tabControl1.SelectedTab = tabPage1;
            radioCpu.Checked = true;
            txtServicio.Enabled = false;
            boxEstatus.Enabled = false;
            ObtenerSiguienteNumero();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            BloquearControles(this, true);
            LlenarBoxEstatus();
            if (boxEstatus.Items.Count == 1)
            {
                boxEstatus.SelectedIndex = -1;
            }
            dateEntrada.Enabled = false;
            tabControl1.SelectedTab = tabPage1;
            radioCpu.Checked = false;
            radioPeriferico.Checked = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                DateTime fechaSeleccionada = dateEntrada.Value;
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    int idEstatus = 0;
                    string queryEstatus = "SELECT id_estatus FROM estatus WHERE descripcion = @estatus ORDER BY id_estatus;";
                    using (SqlCommand cmd = new SqlCommand(queryEstatus, connection))
                    {
                        cmd.Parameters.AddWithValue("@estatus", boxEstatus.Text);
                        object result = cmd.ExecuteScalar();
                        idEstatus = (result != null) ? Convert.ToInt32(result) : 0;
                    }
                    string queryInsert = "INSERT INTO servicios(id_servicio, folio, didecon, fecha_llegada, falla, reporto, estatus) VALUES (@id_servicio, @folio, @didecon, @fecha_llegada, @falla, @reporto, @estatus);";
                    using (SqlCommand insertCmd = new SqlCommand(queryInsert, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@id_servicio", txtServicio.Text);
                        insertCmd.Parameters.AddWithValue("@folio", txtFolio.Text);
                        insertCmd.Parameters.AddWithValue("@didecon", txtDidecon.Text);
                        insertCmd.Parameters.AddWithValue("fecha_llegada", fechaSeleccionada);
                        insertCmd.Parameters.AddWithValue("@falla", txtFalla.Text);
                        insertCmd.Parameters.AddWithValue("@reporto", txtSolicito.Text);
                        insertCmd.Parameters.AddWithValue("@estatus", idEstatus);
                        insertCmd.ExecuteNonQuery();    
                    }
                    string queryUpdate = "UPDATE hardware SET idestatus = 1 WHERE hardware.folio = @folio;";
                    using (SqlCommand updateCmd = new SqlCommand(queryUpdate, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@folio", txtFolio.Text);
                        updateCmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Registro guardado con éxito.");
                    LimpiarControles();
                    BloquearControles(this, true);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var buscarPerifericos = new BuscarPerifericos("CPU"))
            {
                buscarPerifericos.FormClosed += (s, args) => ObtenerSiguienteNumero();
                if (buscarPerifericos.ShowDialog() == DialogResult.OK)
                {
                    string folio = buscarPerifericos.FolioSeleccionado;
                    if (!string.IsNullOrEmpty(folio))
                    {
                        CargarDatosPorFolio(folio);
                    }
            txtDidecon.Enabled = false;
            txtFolio.Enabled = false;
        }

        private void CargarDatosPorFolio(string folio)
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"SELECT hardware.folio AS Numero, 
                                        hardware.didecon AS Didecon, 
                                        estatus.descripcion AS Estatus
                                    FROM hardware 
                                    JOIN estatus ON hardware.idestatus = estatus.id_estatus 
                                    WHERE hardware.folio = @folio;";
                    using (SqlCommand cmd = new SqlCommand(query,conn))
                    {
                        cmd.Parameters.AddWithValue("@folio", folio);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFolio.Text = reader["Numero"].ToString();
                                txtDidecon.Text = reader["Didecon"].ToString();
                                boxEstatus.Text = reader["Estatus"].ToString();
                            }
                            else 
                            {
                                MessageBox.Show("No se encontraron datos para ese folio");
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

        private bool ValidarCampos()
        {
            bool esValido = true;
            string mensajeError = "Los siguientes campos son invalidos: \n";
            if (string.IsNullOrWhiteSpace(txtFolio.Text))
            {
                mensajeError += "- Especifique un folio valido. \n";
                esValido = false;
            }
            else 
            {
                if (!ExisteFolio(txtFolio.Text))
                {
                    mensajeError += "- El folio no existe. \n";
                    esValido = false;
                }
            }
            if (string.IsNullOrWhiteSpace(txtDidecon.Text))
            {
                mensajeError += "- Especifique un didecon valido. \n";
                esValido = false;
            }
            else
            {
                if (!ExisteDidecon(txtDidecon.Text))
                {
                    mensajeError += "- El didecon no existe. \n";
                    esValido = false;
                }
            }
            if (string.IsNullOrWhiteSpace(txtServicio.Text))
            {
                mensajeError += "- Especifique un servicio valido.\n";
                esValido = false;
            }
            if (boxEstatus.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxEstatus.Text))
            {
                mensajeError += "- Seleccione un estatus valido.\n";
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtFalla.Text))
            {
                mensajeError += "- Especifique una falla.\n";
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtSolicito.Text))
            {
                mensajeError += "- Especifique quien solicito el servicio.\n";
                esValido = false;
            }
            if(!esValido)
            {
                MessageBox.Show(mensajeError, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }

        private bool ExisteFolio(string folio)
        {
            bool existe = false;
            try 
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM hardware WHERE folio = @folio";
                    using (SqlCommand cmd = new SqlCommand(query,connection))
                    {
                        cmd.Parameters.AddWithValue("@folio",folio);
                        existe = (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return existe;
        }

        private bool ExisteDidecon(string didecon)
        {
            bool existe = false;
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM hardware WHERE didecon = @didecon;";
                    using (SqlCommand cmd = new SqlCommand(query,connection))
                    {
                        cmd.Parameters.AddWithValue("@didecon",didecon);
                        existe = (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return existe;
        }
    }
}
