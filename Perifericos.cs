using Microsoft.Data.SqlClient;
using System;
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
        private string connectionString = "Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;";
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
            BloquearControles(true);
            this.MouseDown += new MouseEventHandler(Periferico_MouseDown);
            LlenarBoxDidecon();
            LlenarBoxTipo();
            LlenarBoxMarca();
            ConfigurarNumSerie(boxNumSerie);
            ConfigurarBoxActivo(boxActivo);
            ConfigurarBoxActivoSistemas(boxActSistemas);
            boxMarca.SelectedIndexChanged += boxMarca_SelectedIndexChanged;
            btnNuevoModelo.Enabled = false;
        }
        private void BloquearControles(bool bloquear)
        {
            btnNuevo.Enabled = bloquear;
            btnAceptar.Enabled = !bloquear;
            btnCancelar.Enabled = !bloquear;
            btnNuevoMarca.Enabled = !bloquear;
            //btnNuevoModelo.Enabled = !bloquear;
            txtFolio.Enabled = !bloquear;
            boxDidecon.Enabled = !bloquear;
            boxTipo.Enabled = !bloquear;
            boxTipo.Enabled = !bloquear;
            boxNumSerie.Enabled = !bloquear;
            boxModelo.Enabled = !bloquear;
            boxMarca.Enabled = !bloquear;
            boxActivo.Enabled = !bloquear;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
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
                        string queryInsert = @"INSERT INTO perifericos (folio, didecon, tipo, marca, modelo, sn, activos, activocontraloria, idestatus, fechacaptura, fechaalta, fechafactura, fechabaja, valorfactura, nomproveedor, numerofactura) VALUES (@folio, @didecon, @tipo, @marca, @modelo, '-', '-', '-', 7, GETDATE(), '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', 0.00, '-', '-');";
                        using (SqlCommand insertCmd = new SqlCommand(queryInsert, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@folio", txtFolio.Text);
                            insertCmd.Parameters.AddWithValue("@didecon", didecon);
                            insertCmd.Parameters.AddWithValue("@tipo", idTipo);
                            insertCmd.Parameters.AddWithValue("@marca", idMarca);
                            insertCmd.Parameters.AddWithValue("@modelo", idModelo);
                            insertCmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Registro guardado con éxito.");
                        LimpiarControles();
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
            List<Control> controlesALimpiar = new List<Control> { txtFolio, boxDidecon, boxTipo, boxNumSerie, boxMarca, boxModelo, boxModelo, boxActivo };
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
                        else
                        {
                            if (comboBox.Items.Contains("-"))
                            {
                                comboBox.SelectedItem = "-";
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

        private void txtBuscarFolio_KeyPress(object sender, KeyPressEventArgs e)
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
                using (SqlConnection conn = new SqlConnection(connectionString))
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
                using (SqlConnection conn = new SqlConnection(connectionString))
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
                using (SqlConnection conn = new SqlConnection(connectionString))
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

                using (SqlConnection conn = new SqlConnection(connectionString))
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

        private void ConfigurarNumSerie(ComboBox boxNumSerie)
        {
            boxNumSerie.Items.Clear();
            boxNumSerie.Items.Add("-");  // Agregar opción por defecto
            boxNumSerie.Items.Add("SN");
            boxNumSerie.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxNumSerie.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxNumSerie.TextChanged += boxNumSerie_TextChanged;
        }

        private void ConfigurarBoxActivo(ComboBox boxActivo)
        {
            boxActivo.Items.Clear();
            boxActivo.Items.Add("-");  // Agregar opción por defecto
            boxActivo.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxActivo.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxActivo.KeyPress += boxActivo_KeyPress;
        }

        private void ConfigurarBoxActivoSistemas(ComboBox boxActivo)
        {
            boxActivo.Items.Clear();
            boxActivo.Items.Add("-");  // Agregar opción por defecto
            boxActivo.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxActivo.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxActivo.KeyPress += boxActivoSistemas_KeyPress;
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
            if (!esValido)
            {
                MessageBox.Show(mensajeError, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }
    }
}
