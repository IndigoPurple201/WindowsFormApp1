﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Perifericos : Form
    {
        public event Action MarcaAgregada;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private Color bordeOriginal = Color.Black;
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private ConexionSQL conexionSQL = new ConexionSQL();
        string didecon = "";

        private Hardware hardware;
        public Perifericos(Hardware form1)
        {
            InitializeComponent();
            hardware = form1;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);
            this.MouseDown += new MouseEventHandler(Periferico_MouseDown);
            panelBarra.MouseDown += new MouseEventHandler(Periferico_MouseDown);
            label1.MouseDown += new MouseEventHandler(Periferico_MouseDown);
        }

        private void Perifericos_Load(object sender, EventArgs e)
        {
            conexionSQL.ProbarConexion();
            BloquearControles(true);
            this.MouseDown += new MouseEventHandler(Periferico_MouseDown);
            LlenarBoxDidecon();
            LlenarBoxTipo();
            LlenarBoxMarca();
            LlenarBoxEstatus();
            ConfigurarNumSerie(boxNumSerie);
            ConfigurarBoxActivo(boxActivo);
            ConfigurarBoxActivoSistemas(boxActSistemas);
            ConfigurarBoxValorFactura(boxValorFactura);
            ConfigurarBoxNumeroFactura(boxNumFactura);
            ConfigurarBoxProveedor(boxProveedor);
            boxMarca.SelectedIndexChanged += boxMarca_SelectedIndexChanged;
            btnNuevoModelo.Enabled = false;
            txtFolio.Enabled = false;
        }
        private void BloquearControles(bool bloquear)
        {
            btnNuevo.Enabled = bloquear;
            btnAceptar.Enabled = !bloquear;
            btnCancelar.Enabled = !bloquear;
            btnNuevoMarca.Enabled = !bloquear;
            //btnNuevoModelo.Enabled = !bloquear;
            boxDidecon.Enabled = !bloquear;
            boxTipo.Enabled = !bloquear;
            boxTipo.Enabled = !bloquear;
            boxNumSerie.Enabled = !bloquear;
            boxModelo.Enabled = !bloquear;
            boxMarca.Enabled = !bloquear;
            boxActivo.Enabled = !bloquear;
            boxActSistemas.Enabled = !bloquear;
            boxValorFactura.Enabled = !bloquear;
            boxNumFactura.Enabled = !bloquear;
            boxProveedor.Enabled = !bloquear;
            txtNotas.Enabled = !bloquear;
            boxEstatus.Enabled = !bloquear;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            obtenerSiguienteNumero();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var buscarPerifericos = new BuscarPerifericos(""))
            {
                buscarPerifericos.FormClosed += (s, args) => obtenerSiguienteNumero();
                if (buscarPerifericos.ShowDialog() == DialogResult.OK)
                {
                    string folio = buscarPerifericos.FolioSeleccionado;
                    if (!string.IsNullOrEmpty(folio))
                    {
                        MessageBox.Show($"Seleccionaste el folio: {folio}");
                    }
                    else
                    {
                        MessageBox.Show("No se seleccionó ningún folio.");
                    }
                }
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                try
                {
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        String seleccion = boxDidecon.SelectedItem.ToString();
                        string[] partes = seleccion.Split('-');
                        if (partes.Length == 3)
                        {
                            didecon = partes[2];
                        }
                        else
                        {
                            MessageBox.Show("Error al procesar la selección.");
                        }
                        int idMarca = 0;
                        string queryMarca = "SELECT id_marca FROM marcas WHERE descripcion = @marca ORDER BY id_marca;";
                        using (SqlCommand cmd = new SqlCommand(queryMarca, connection))
                        {
                            cmd.Parameters.AddWithValue("@marca", boxMarca.Text);
                            object result = cmd.ExecuteScalar();
                            idMarca = (result != null) ? Convert.ToInt32(result) : 0;
                        }
                        int idTipo = 0;
                        string queryTipo = "SELECT id_tipo FROM tipos WHERE descripcion = @tipo ORDER BY id_tipo;";
                        using (SqlCommand cmd = new SqlCommand(queryTipo, connection))
                        {
                            cmd.Parameters.AddWithValue("@tipo", boxTipo.Text);
                            object result = cmd.ExecuteScalar();
                            idTipo = (result != null) ? Convert.ToInt32(result) : 0;
                        }
                        int idModelo = 0;
                        string queryModelo = "SELECT id_modelo FROM modelos WHERE descripcion = @modelo ORDER BY id_modelo;";
                        using (SqlCommand cmd = new SqlCommand(queryModelo, connection))
                        {
                            cmd.Parameters.AddWithValue("@modelo", boxModelo.Text);
                            object result = cmd.ExecuteScalar();
                            idModelo = (result != null) ? Convert.ToInt32(result) : 0;
                        }
                        int idEstatus = 0;
                        string queryEstatus = "SELECT id_estatus FROM estatus WHERE descripcion = @estatus ORDER BY id_estatus;";
                        using (SqlCommand cmd = new SqlCommand(queryEstatus, connection))
                        {
                            cmd.Parameters.AddWithValue("@estatus", boxEstatus.Text);
                            object result = cmd.ExecuteScalar();
                            idEstatus = (result != null) ? Convert.ToInt32(result) : 0;
                        }

                        string queryInsert = @"INSERT INTO perifericos (folio, didecon, tipo, marca, modelo, sn, Notas, activos, activocontraloria, idestatus, fechacaptura, fechaalta, fechafactura, fechabaja, valorfactura, nomproveedor, numerofactura) VALUES (@folio, @didecon, @tipo, @marca, @modelo, @sn, @notas, @activos, @activocontraloria, @idestatus, GETDATE(), '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', @valorfactura, @nombreproveedor, @numerofactura);";
                        using (SqlCommand insertCmd = new SqlCommand(queryInsert, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@folio", txtFolio.Text);
                            insertCmd.Parameters.AddWithValue("@didecon", didecon);
                            insertCmd.Parameters.AddWithValue("@tipo", idTipo);
                            insertCmd.Parameters.AddWithValue("@marca", idMarca);
                            insertCmd.Parameters.AddWithValue("@modelo", idModelo);
                            insertCmd.Parameters.AddWithValue("@sn", boxNumSerie.Text);
                            insertCmd.Parameters.AddWithValue("@notas", string.IsNullOrWhiteSpace(txtNotas.Text) ? (object)DBNull.Value : txtNotas.Text);
                            insertCmd.Parameters.AddWithValue("@activos", boxActSistemas.Text);
                            insertCmd.Parameters.AddWithValue("@activocontraloria", boxActivo.Text);
                            insertCmd.Parameters.AddWithValue("@idestatus", idEstatus);
                            insertCmd.Parameters.AddWithValue("@valorfactura", boxValorFactura.Text);
                            insertCmd.Parameters.AddWithValue("@nombreproveedor", boxProveedor.Text);
                            insertCmd.Parameters.AddWithValue("@numerofactura", boxNumFactura.Text);
                            insertCmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Registro guardado con éxito.");
                        LimpiarControles();
                        BloquearControles(true);
                        //obtenerSiguienteNumero();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LimpiarControles()
        {
            List<Control> controlesALimpiar = new List<Control> { txtFolio, boxDidecon, boxTipo, boxNumSerie, boxMarca, boxModelo, boxModelo, boxActivo, boxActSistemas, boxValorFactura, boxNumFactura, boxProveedor, txtNotas, boxEstatus };
            foreach (Control ctrl in this.Controls)
            {
                if (controlesALimpiar.Contains(ctrl))
                {
                    if (ctrl is TextBox textBox)
                    {
                        textBox.Clear();
                    }
                    else if (ctrl is ComboBox comboBox)
                    {
                        if (comboBox == boxModelo)
                        {
                            // Limpiar completamente el ComboBox de modelos
                            comboBox.Items.Clear();
                            comboBox.SelectedIndex = -1;
                            comboBox.Text = string.Empty;
                        }
                        else if (comboBox == boxActSistemas)
                        {
                            comboBox.SelectedItem = ".   ";
                        }
                        else
                        {
                            if (comboBox.Items.Contains(".   "))
                            {
                                comboBox.SelectedItem = ".   ";
                            }
                            else if (comboBox.Items.Contains("0.00"))
                            {
                                comboBox.SelectedItem = "0.00";
                            }
                            else
                            {
                                comboBox.SelectedIndex = -1;
                                comboBox.Text = string.Empty;
                            }
                        }
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            BloquearControles(true);
        }

        private void btnNuevoMarca_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.MarcaAgregada += LlenarBoxMarca;
            marca.ShowDialog();
        }

        private void btnNuevoModelo_Click(object sender, EventArgs e)
        {
            string marca = boxMarca.SelectedItem.ToString();
            Modelo modelo = new Modelo(marca, ""); // No filtra, permite todo excepto CPU
            modelo.ModeloAgregada += LlenarBoxModelo;
            modelo.ShowDialog();
        }

        private void Periferico_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE, 0);
            }
        }

        private void panelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Verifica que el clic sea con el botón izquierdo
            {
                mouseDownLocation = e.Location; // Guarda la posición del mouse al hacer clic
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Verifica que el clic sea con el botón izquierdo
            {
                mouseDownLocation = e.Location; // Guarda la posición del mouse al hacer clic
            }
        }

        //private void panelBarra_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left) // Si el botón del mouse sigue presionado
        //    {
        //        this.Left += e.X - mouseDownLocation.X;
        //        this.Top += e.Y - mouseDownLocation.Y;
        //    }
        //}

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

        private void btnHardware_Click(object sender, EventArgs e)
        {
            hardware.Show();
            this.Close();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
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


        private void LlenarBoxDidecon()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    String query = "SELECT hardware.folio, hardware.procesador, hardware.didecon FROM hardware;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxDidecon.Items.Clear();
                        while (reader.Read())
                        {
                            string item = $"{reader["folio"]}-{reader["procesador"]}-{reader["didecon"]}";
                            boxDidecon.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void LlenarBoxMarca()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT marcas.descripcion FROM marcas;";
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
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void LlenarBoxTipo()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT tipos.descripcion FROM tipos WHERE tipos.descripcion != 'CPU';";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void LlenarBoxEstatus()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT descripcion FROM estatus;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxEstatus.Items.Clear();
                        while (reader.Read())
                        {
                            boxEstatus.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void boxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarBoxModelo();
            if (boxMarca.SelectedItem != null && boxMarca.SelectedItem.ToString() != "-")
            {
                btnNuevoModelo.Enabled = true;
            }
            else
            {
                btnNuevoModelo.Enabled = false;
            }
        }

        private void boxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarBoxModelo();
        }

        private void LlenarBoxModelo()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(boxMarca.Text) || string.IsNullOrWhiteSpace(boxTipo.Text))
                    return;

                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    int idMarca = 0;
                    string query1 = "SELECT id_marca FROM marcas WHERE descripcion = @marca;";
                    using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                    {
                        cmd1.Parameters.AddWithValue("@marca", boxMarca.Text);
                        object result = cmd1.ExecuteScalar();
                        idMarca = (result != null) ? Convert.ToInt32(result) : 0;
                    }
                    int idTipo = 0;
                    string query2 = "SELECT id_tipo FROM tipos WHERE descripcion = @tipo;";
                    using (SqlCommand cmd2 = new SqlCommand(query2, conn))
                    {
                        cmd2.Parameters.AddWithValue("@tipo", boxTipo.Text);
                        object result = cmd2.ExecuteScalar();
                        idTipo = (result != null) ? Convert.ToInt32(result) : 0;
                    }
                    if (idMarca == 0 || idTipo == 0)
                        return;
                    boxModelo.Items.Clear();
                    string query3 = "SELECT descripcion FROM modelos WHERE marca = @marca AND tipo = @tipo;";
                    using (SqlCommand cmd3 = new SqlCommand(query3, conn))
                    {
                        cmd3.Parameters.AddWithValue("@marca", idMarca);
                        cmd3.Parameters.AddWithValue("@tipo", idTipo);
                        using (SqlDataReader reader = cmd3.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                boxModelo.Items.Add(reader["descripcion"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void boxNumSerie_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Convertir a mayúsculas
            comboBox.Text = comboBox.Text.ToUpper();

            // Mover el cursor al final
            comboBox.SelectionStart = comboBox.Text.Length;
        }

        private void boxNumSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Evitar que se ingresen más de 15 dígitos
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 15)
            {
                e.Handled = true;
            }

        }

        private void boxActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Evitar que se ingresen más de 15 dígitos
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 15)
            {
                e.Handled = true;
            }

            //Permitirsolo numerosy puntos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void boxActivoSistemas_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedItem?.ToString() == ".   ")
            {
                comboBox.SelectedIndex = -1;
                comboBox.Text = "";
            }

            // Evitar que se ingresen más de 15 dígitos
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 4)
            {
                e.Handled = true;
            }

            //Permitirsolo numerosy puntos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuscarDidecon_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Permitir solo números y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear entrada no numérica
            }
            // Evitar que se ingresen más de 7 dígitos
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 7)
            {
                e.Handled = true;
            }
        }

        private void boxValorFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Evitar que se ingresen más de 7 dígitos
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 7)
            {
                e.Handled = true;
            }

            // Permitir solo números y un punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Evitar más de un punto decimal 
            if (e.KeyChar == '.' && comboBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void boxNumeroFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Evitar que se ingresen más de 7 dígitos
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 7)
            {
                e.Handled = true;
            }

            // Permitir solo números y un punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Evitar más de un punto decimal 
            if (e.KeyChar == '.' && comboBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void boxProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            // Evitar que se ingresen más de 50 caracteres
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 50)
            {
                e.Handled = true;
            }
        }

        private void txtNotas_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Evitar que se ingresen más de 120 caracteres
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void boxProveedor_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Convertir a mayúsculas
            comboBox.Text = comboBox.Text.ToUpper();

            // Mover el cursor al final
            comboBox.SelectionStart = comboBox.Text.Length;
        }

        private void txtNotas_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }

        private void ConfigurarNumSerie(ComboBox boxNumSerie)
        {
            boxNumSerie.Items.Clear();
            boxNumSerie.Items.Add(".   ");  // Agregar opción por defecto
            boxNumSerie.Items.Add("SN");
            boxNumSerie.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxNumSerie.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxNumSerie.TextChanged += boxNumSerie_TextChanged;
        }

        private void ConfigurarBoxActivo(ComboBox boxActivo)
        {
            boxActivo.Items.Clear();
            boxActivo.Items.Add(".   ");  // Agregar opción por defecto
            boxActivo.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxActivo.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxActivo.KeyPress += boxActivo_KeyPress;
        }

        private void ConfigurarBoxActivoSistemas(ComboBox boxActivo)
        {
            boxActivo.Items.Clear();
            boxActivo.Items.Add(".   ");  // Agregar opción por defecto
            boxActivo.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxActivo.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxActivo.KeyPress += boxActivoSistemas_KeyPress;
        }

        private void ConfigurarBoxValorFactura(ComboBox boxValorFactura)
        {
            boxValorFactura.Items.Clear();
            boxValorFactura.Items.Add("0.00");  // Agregar opción por defecto   
            boxValorFactura.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxValorFactura.SelectedIndex = 0; // Seleccionar "-" por defecto
            boxValorFactura.KeyPress += boxValorFactura_KeyPress;
        }

        private void ConfigurarBoxNumeroFactura(ComboBox boxNumeroFactura)
        {
            boxNumeroFactura.Items.Clear();
            boxNumeroFactura.Items.Add(".   ");  // Agregar opción por defecto
            boxNumeroFactura.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxNumeroFactura.SelectedIndex = 0; // Seleccionar "-" por defecto
            boxNumeroFactura.KeyPress += boxNumeroFactura_KeyPress;
        }

        private void ConfigurarBoxProveedor(ComboBox boxProveedor)
        {
            boxProveedor.Items.Clear();
            boxProveedor.Items.Add(".   ");  // Agregar opción por defecto
            boxProveedor.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxProveedor.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxProveedor.TextChanged += boxProveedor_TextChanged;
        }

            private void obtenerSiguienteNumero()
            {
                try
                {
                    using(SqlConnection conexion = conexionSQL.ObtenerConexion())
                    {
                        conexion.Open();
                        string query = "SELECT ISNULL(MAX(folio), 0) + 1 AS SiguienteNumero FROM perifericos;";
                        using (SqlCommand cmd = new SqlCommand(query,conexion))
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

        private bool validarCampos()
        {
            bool esValido = true;
            string mensajeError = "Los siguientes campos son inválidos:\n";
            if (txtFolio.Text.Length != 4 || !int.TryParse(txtFolio.Text, out _))
            {
                mensajeError += "- El numero debe tener 4 dígitos.\n";
                esValido = false;
            }
            if (boxDidecon.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxDidecon.Text))
            {
                mensajeError += "- Selecciona un Didecon válido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxActivo.Text))
            {
                mensajeError += "- Selecciona un Act. Contraloria válido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxActivo.Text))
            {
                mensajeError += "- Selecciona un Num. Serie válido.\n";
                esValido = false;
            }
            if (boxMarca.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxMarca.Text))
            {
                mensajeError += "- Selecciona una Marca válida.\n";
                esValido = false;
            }
            if (boxTipo.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxTipo.Text))
            {
                mensajeError += "- Selecciona un Tipo válido.\n";
                esValido = false;
            }
            if (boxModelo.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxModelo.Text))
            {
                mensajeError += "- Selecciona un Modelo válido.\n";
                esValido = false;
            }
            if (boxActSistemas.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxActSistemas.Text))
            {
                mensajeError += "- Selecciona un Act. Sistemas válido.\n";
                esValido = false;
            }
            if (boxNumFactura.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxNumFactura.Text))
            {
                mensajeError += "- Selecciona un Num. Factura valido válido.\n";
                esValido = false;
            }
            if (boxValorFactura.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxValorFactura.Text))
            {
                mensajeError += "- Selecciona un Valor Factura válido.\n";
                esValido = false;
            }
            if (boxProveedor.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxProveedor.Text))
            {
                mensajeError += "- Selecciona un Proveedor válido.\n";
                esValido = false;
            }
            if (boxEstatus.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxEstatus.Text))
            {
                mensajeError += "- Selecciona un Estatus válido.\n";
                esValido = false;
            }
            if (!esValido)
            {
                MessageBox.Show(mensajeError, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }
    }
}
