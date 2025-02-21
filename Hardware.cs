using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Hardware : Form
    {
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private bool isComboBoxOpen = false;
        public Hardware()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Hardware_MouseDown);
            this.MouseMove += new MouseEventHandler(Hardware_MouseMove);
            panelBarra.MouseDown += new MouseEventHandler(Hardware_MouseDown);
            panelBarra.MouseMove += new MouseEventHandler(Hardware_MouseMove);
        }
        private void Perifericos_Load_1(object sender, EventArgs e)
        {
            ConexionSQL conexion = new ConexionSQL();
            conexion.ProbarConexion();

            boxMemoria.Items.Clear();
            boxMemoria.Items.Add("4 GB");
            boxMemoria.Items.Add("8 GB");
            boxMemoria.Items.Add("12 GB");

            LlenarBoxMarca();
            LlenarBoXModelo();
            LlenarBoxDepartamento();

            this.Click += QuitarFoco;
            foreach (Control control in this.Controls)
            {
                control.Click += ControlSeleccionado;
            }

            BloquearControles(true);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles(); // Limpiar solo si hay algo en los controles
            BloquearControles(true); // Volver a bloquear todos los controles
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Botón 3 clickeado!");
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
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 3)
            {
                e.Handled = true;
            }
        }
        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;

            // Evitar que se ingresen más de 15 dígitos
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 15)
            {
                e.Handled = true;
            }

            //Permitirsolo numerosy puntos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Evitar que haya puntos seguidos
            if (e.KeyChar == '.' && (txt.Text.EndsWith(".") || txt.Text.Split('.').Length > 3))
            {
                e.Handled = true;
            }

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            //Expresion regular para validar una direccion IP
            string pattern = @"^(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])(\.(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])){3}$";
            if (!Regex.IsMatch(txt.Text, pattern) && txt.Text.Length > 0)
            {
                txt.ForeColor = Color.Red; // Indicar error en rojo
            }
            else
            {
                txt.ForeColor = Color.Black; // IP válida en negro
            }
        }

        private void txtDidecon_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea la entrada
            }
        }

        private void txtResponsable_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
        }

        private void textNumSerie_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
        }

        private void textDisco_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear entrada no numérica
            }
            // Evitar que se ingresen más de 3 dígitos
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 3)
            {
                e.Handled = true;
            }
        }
        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
        }

        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquea la entrada
            }
        }

        private void LlenarBoxMarca()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;"))
                {
                    conn.Open();
                    String query = "SELECT marcas.descripcion FROM marcas";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
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

        private void LlenarBoXModelo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;"))
                {
                    conn.Open();
                    String query = "SELECT modelos.descripcion FROM modelos";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            boxModelo.Items.Add(reader["descripcion"].ToString());
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
                using (SqlConnection conn = new SqlConnection("Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;"))
                {
                    conn.Open();
                    String query = "SELECT dependencias.descripcion FROM dependencias;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
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
            Application.Exit();
        }

        private void Hardware_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location; // Guarda la posición inicial del mouse
            }
        }
        private void Hardware_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - mouseDownLocation.X;
                this.Top += e.Y - mouseDownLocation.Y;
            }
        }

        private void panelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Verifica que el clic sea con el botón izquierdo
            {
                mouseDownLocation = e.Location; // Guarda la posición del mouse al hacer clic
            }
        }
        private void panelBarra_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Si el botón del mouse sigue presionado
            {
                this.Left += e.X - mouseDownLocation.X;
                this.Top += e.Y - mouseDownLocation.Y;
            }
        }
        private void BloquearControles(bool bloquear)
        {
            foreach (Control ctrl in this.Controls)
            {
                if(ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enabled = !bloquear; // Deshabilita o habilita los controles
                }
            }
            btnNuevo.Enabled = bloquear;    // "Nuevo" solo está habilitado cuando los demás están bloqueados
            btnAceptar.Enabled = !bloquear; // "Aceptar" solo se habilita cuando los controles están activos
            btnCancelar.Enabled = !bloquear; // "Cancelar" solo se habilita cuando los controles están activos
        }

        private void LimpiarControles()
        {
            foreach (Control ctrl in this.Controls)
            {
                if(ctrl is TextBox && !string.IsNullOrEmpty((ctrl as TextBox).Text))
                {
                    (ctrl as TextBox).Clear();
                }
                else if (ctrl is ComboBox && (ctrl as ComboBox).SelectedIndex != -1)
                {
                    (ctrl as ComboBox).SelectedIndex = -1; // Limpia la selección
                }
            }
        }
    }
}
