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
        private string connectionString = "Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;";
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
            //LlenarBoXModelo();
            LlenarBoxDepartamento();

            this.Click += QuitarFoco;
            foreach (Control control in this.Controls)
            {
                control.Click += ControlSeleccionado;
            }

            BloquearControles(true);

            ConfigurarBoxArea(boxArea);
            ConfigurarBoxResponsable(boxResponsable);
            ConfigurarBoxDireccion(boxDireccion);
            ConfigurarNumSerie(boxNumSerie);
            ConfigurarBoxActivo(boxActivo);
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
            if (ValidarCampos())
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    try
                    {
                        conexion.Open();
                        string idDependencia = "";
                        string queryDependencia = "SELECT id_dependencia FROM dependencias WHERE descripcion = @descripcion ORDER BY id_dependencia;";
                        using (SqlCommand cmd = new SqlCommand(queryDependencia, conexion))
                        {
                            cmd.Parameters.AddWithValue("@descripcion", boxDepartamento.Text);
                            object result = cmd.ExecuteScalar();
                            idDependencia = (result != null) ? result.ToString() : "";
                        }
                        //MessageBox.Show(idDependencia.ToString());
                        int idMarca = 0;
                        string queryMarca = "SELECT id_marca FROM marcas WHERE descripcion = @marca ORDER BY id_marca;";
                        using (SqlCommand cmd = new SqlCommand(queryMarca, conexion))
                        {
                            cmd.Parameters.AddWithValue("@marca", boxMarca.Text);
                            object result = cmd.ExecuteScalar();
                            idMarca = (result != null) ? Convert.ToInt32(result) : 0;
                        }
                        //MessageBox.Show(idMarca.ToString());
                        int idModelo = 0;
                        string queryModelo = "SELECT id_modelo FROM modelos WHERE descripcion = @modelo ORDER BY id_modelo;";
                        using (SqlCommand cmd = new SqlCommand(queryModelo, conexion))
                        {
                            cmd.Parameters.AddWithValue("@modelo", boxModelo.Text);
                            object result = cmd.ExecuteScalar();
                            idModelo = (result != null) ? Convert.ToInt32(result) : 0;
                        }
                        //MessageBox.Show(idModelo.ToString());
                        string insertQuery = @"
                                             INSERT INTO hardware (folio, depto, area, didecon, responsable, ip, sn, procesador, memoria, disco_duro, grupo, nombre, activos, marca, modelo, activocontraloria, idestatus, fechacaptura, fechaalta, fechafactura, fechabaja, valorfactura, nomproveedor, idtipo, numerofactura) 
                                             VALUES (@folio, @depto, @area, @didecon, @responsable, @ip, @sn, @procesador, @memoria, @disco_duro, '-', '-', '-', @marca, @modelo, @activocontraloria, 1, GETDATE(), '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', 0.00, '-', 7, '-');";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conexion))
                         {
                                    insertCmd.Parameters.AddWithValue("@folio", txtFolio.Text);
                                    insertCmd.Parameters.AddWithValue("@depto", idDependencia);
                                    insertCmd.Parameters.AddWithValue("@area", boxArea.Text);
                                    insertCmd.Parameters.AddWithValue("@didecon", txtDidecon.Text);
                                    insertCmd.Parameters.AddWithValue("@responsable", boxResponsable.Text);
                                    insertCmd.Parameters.AddWithValue("@ip", boxDireccion.Text);
                                    insertCmd.Parameters.AddWithValue("@sn", boxNumSerie.Text);
                                    insertCmd.Parameters.AddWithValue("@procesador", txtProcesador.Text);
                                    insertCmd.Parameters.AddWithValue("@memoria", boxMemoria.Text);
                                    insertCmd.Parameters.AddWithValue("@disco_duro", textDisco.Text);
                                    insertCmd.Parameters.AddWithValue("@marca", idMarca);
                                    insertCmd.Parameters.AddWithValue("@modelo", idModelo);
                                    insertCmd.Parameters.AddWithValue("@activocontraloria", boxActivo.Text);
                                    insertCmd.ExecuteNonQuery();
                                    MessageBox.Show("Registro insertado correctamente.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
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

        private void txtProcesador_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
            // Validación con regex
            string pattern = @"^(INTEL|AMD|PENTIUM)\s+[A-Za-z0-9]+(\s+[A-Za-z0-9]+)?(\s+PRO)?$";
            if (!Regex.IsMatch(txt.Text, pattern, RegexOptions.IgnoreCase))
            {
                txt.ForeColor = System.Drawing.Color.Red; // Indicar error
            }
            else
            {
                txt.ForeColor = System.Drawing.Color.Black; // Entrada válida
            }
        }

        private void textDisco_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
            string pattern = @"^\d+\s*(GB|TB)$";

            if (!Regex.IsMatch(txt.Text, pattern, RegexOptions.IgnoreCase))
            {
                txt.ForeColor = System.Drawing.Color.Red; // Indicar error
            }
            else
            {
                txt.ForeColor = System.Drawing.Color.Black; // Entrada válida
            }
        }

        private void LlenarBoxMarca()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
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

        private void boxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarBoXModelo();
        }

        private void LlenarBoXModelo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    String query1 = "SELECT id_marca FROM marcas WHERE descripcion = @marca;";
                    int idMarca = 0;
                    using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                    {
                        cmd1.Parameters.AddWithValue("@marca", boxMarca.Text);
                        object result = cmd1.ExecuteScalar();
                        idMarca = (result != null) ? Convert.ToInt32(result) : 0;
                    }
                    if (idMarca == 0)
                        return;
                    boxModelo.Items.Clear();
                    String query2 = "SELECT descripcion from modelos where marca = @idMarca;";
                    using (SqlCommand cmd2 = new SqlCommand(query2, conn))
                    {
                        cmd2.Parameters.AddWithValue("@idMarca", idMarca);
                        using (SqlDataReader reader2 = cmd2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                boxModelo.Items.Add(reader2["descripcion"].ToString());
                            }
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error1: " + ex.Message);
            }
        }

        private void LlenarBoxDepartamento()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
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
                if (ctrl is TextBox || ctrl is ComboBox)
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
                if (ctrl is TextBox && !string.IsNullOrEmpty((ctrl as TextBox).Text))
                {
                    (ctrl as TextBox).Clear();
                }
                else if (ctrl is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                    comboBox.Text = string.Empty;
                }
            }
        }

        private void ConfigurarBoxArea(ComboBox boxArea)
        {
            boxArea.Items.Clear();
            boxArea.Items.Add("-");  // Agregar opción por defecto
            boxArea.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxArea.SelectedIndex = 0; // Seleccionar "-" por defecto
            boxArea.Tag = "limpiar"; // Marcar que debe limpiarse

            boxArea.TextChanged += boxArea_TextChanged;
            boxArea.KeyPress += boxArea_KeyPress;
        }

        private void ConfigurarBoxResponsable(ComboBox boxResponsable)
        {
            boxResponsable.Items.Clear();
            boxResponsable.Items.Add("-");  // Agregar opción por defecto
            boxResponsable.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxResponsable.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxResponsable.TextChanged += boxResponsable_TextChanged;
            boxResponsable.KeyPress += boxResponsable_KeyPress;
        }

        private void ConfigurarBoxDireccion(ComboBox boxDireccion)
        {
            boxDireccion.Items.Clear();
            boxDireccion.Items.Add("-");  // Agregar opción por defecto
            boxDireccion.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxDireccion.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxDireccion.TextChanged += boxDireccion_TextChanged;
            boxDireccion.KeyPress += boxDireccion_KeyPress;
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

        private void boxArea_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Convertir a mayúsculas
            comboBox.Text = comboBox.Text.ToUpper();

            // Mover el cursor al final
            comboBox.SelectionStart = comboBox.Text.Length;
        }

        private void boxArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios y teclas de control (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquear entrada
            }
        }

        private void boxResponsable_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Convertir a mayúsculas
            comboBox.Text = comboBox.Text.ToUpper();

            // Mover el cursor al final
            comboBox.SelectionStart = comboBox.Text.Length;
        }

        private void boxResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras, espacios y teclas de control (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Bloquear entrada
            }
        }
        private void boxDireccion_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.Text == "-" || comboBox.Text == "SN")
            {
                comboBox.ForeColor = Color.Black;
                return;
            }

            //Expresion regular para validar una direccion IP
            string pattern = @"^(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])(\.(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])){3}$";
            if (!Regex.IsMatch(comboBox.Text, pattern) && comboBox.Text.Length > 0)
            {
                comboBox.ForeColor = Color.Red; // Indicar error en rojo
            }
            else
            {
                comboBox.ForeColor = Color.Black; // IP válida en negro

            }
        }

        private void boxDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Evitar que se ingresen más de 15 dígitos
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 15)
            {
                e.Handled = true;
            }

            //Permitirsolo numerosy puntos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Evitar que haya puntos seguidos
            if (e.KeyChar == '.' && (comboBox.Text.EndsWith(".") || comboBox.Text.Split('.').Length > 3))
            {
                e.Handled = true;
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

        private bool ValidarCampos()
        {
            bool esValido = true;
            string mensajeError = "Los siguientes campos son inválidos:\n";
            if (txtFolio.Text.Length != 4 || !int.TryParse(txtFolio.Text, out _))
            {
                mensajeError += "- El folio debe tener 4 dígitos.\n";
                esValido = false;
            }
            if (txtDidecon.Text.Length != 7 || !int.TryParse(txtDidecon.Text, out _))
            {
                mensajeError += "- El DIDECON debe tener 7 dígitos.\n";
                esValido = false;
            }
            string ipPattern = @"^(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])(\.(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])){3}$";
            if (boxDireccion.Text != "-" && boxDireccion.Text != "SN" && !Regex.IsMatch(boxDireccion.Text, ipPattern))
            {
                mensajeError += "- La dirección debe ser una IP válida (Ej: 192.168.1.1) o '-' / 'SN'.\n";
                esValido = false;
            }
            string procesadorPattern = @"^(INTEL|AMD|PENTIUM)\s+[A-Za-z0-9]+(\s+[A-Za-z0-9]+)?(\s+PRO)?$";
            if (!Regex.IsMatch(txtProcesador.Text, procesadorPattern, RegexOptions.IgnoreCase))
            {
                mensajeError += "- El procesador debe ser Intel, AMD o Pentium (Ej: 'Intel Core i5').\n";
                esValido = false;
            }
            string discoPattern = @"^\d+\s*(GB|TB)$";
            if (!Regex.IsMatch(textDisco.Text, discoPattern, RegexOptions.IgnoreCase))
            {
                mensajeError += "- El disco duro debe estar en formato correcto (Ej: '500 GB' o '1 TB').\n";
                esValido = false;
            }
            if (boxMarca.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxMarca.Text))
            {
                mensajeError += "- Selecciona una marca válida.\n";
                esValido = false;
            }
            if (boxModelo.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxModelo.Text))
            {
                mensajeError += "- Selecciona un modelo válido.\n";
                esValido = false;
            }
            if (boxDepartamento.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxDepartamento.Text))
            {
                mensajeError += "- Selecciona un departamento válido.\n";
                esValido = false;
            }
            if (boxResponsable.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxResponsable.Text))
            {
                mensajeError += "- Selecciona un responsable válido.\n";
                esValido = false;
            }
            if (boxArea.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxArea.Text))
            {
                mensajeError += "- Selecciona un área válida.\n";
                esValido = false;
            }
            if (boxActivo.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxActivo.Text))
            {
                mensajeError += "- Selecciona un activo válido.\n";
                esValido = false;
            }
            if (boxMemoria.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxMemoria.Text))
            {
                mensajeError += "- Selecciona una memoria válida.\n";
                esValido = false;
            }
            if (boxNumSerie.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxNumSerie.Text))
            {
                mensajeError += "- Selecciona un número de serie válido.\n";
                esValido = false;
            }
            if(!esValido)
            {
                MessageBox.Show(mensajeError, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return esValido;
        }
    }
}
