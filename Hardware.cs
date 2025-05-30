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
    public partial class Hardware : Form
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

        public Hardware()
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL();
            this.MouseDown += new MouseEventHandler(Hardware_MouseDown);
            //this.MouseMove += new MouseEventHandler(Hardware_MouseMove);
            panelBarra.MouseDown += new MouseEventHandler(Hardware_MouseDown);
            label1.MouseDown += new MouseEventHandler(Hardware_MouseDown);
            //panelBarra.MouseMove += new MouseEventHandler(Hardware_MouseMove);
        }
        private void Hardware_Load(object sender, EventArgs e)
        {
            conexionSQL.ProbarConexion();
            LlenarBoxMarca();
            LlenarBoxDepartamento();
            LlenarBoxTipo();
            LlenarBoxEstatus();
            LlenarBoxProveedor();

            BloquearControles(true);

            ConfigurarBoxArea(boxArea);
            ConfigurarBoxResponsable(boxResponsable);
            ConfigurarBoxDireccion(boxDireccion);
            ConfigurarNumSerie(boxNumSerie);
            ConfigurarBoxActivo(boxActivo);
            ConfigurarBoxNombre(boxNombre);
            ConfigurarBoxActSistemas(boxActSistemas);
            ConfigurarBoxNumFactura(boxNumFactura);
            ConfigurarBoxValorFactura(boxValorFactura);
            ConfigurarBoxGrupo(boxGrupo);
            //obtenerSiguienteNumero();
            txtFolio.Enabled = false;
            btnActualizar.Enabled = false;

            this.MouseDown += new MouseEventHandler(Hardware_MouseDown);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }

            this.Click += QuitarFoco;

            boxMarca.SelectedIndexChanged += boxMarca_SelectedIndexChanged;
            btnNuevoModelo.Enabled = false;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
            obtenerSiguienteNumero();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles(); // Limpiar solo si hay algo en los controles
            BloquearControles(true); // Volver a bloquear todos los controles
            txtFolio.Enabled = false; // Deshabilitar el campo de folio
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                using (SqlConnection conexion = conexionSQL.ObtenerConexion())
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
                        int idEstatus = 0;
                        string queryEstatus = "SELECT id_estatus FROM estatus WHERE descripcion = @estatus ORDER BY id_estatus;";
                        using (SqlCommand cmd = new SqlCommand(queryEstatus, conexion))
                        {
                            cmd.Parameters.AddWithValue("@estatus", boxEstatus.Text);
                            object result = cmd.ExecuteScalar();
                            idEstatus = (result != null) ? Convert.ToInt32(result) : 0;
                        }
                        //MessageBox.Show(idEstatus.ToString());
                        int idTipo = 0;
                        string queryTipo = "SELECT id_tipo FROM tipos WHERE descripcion = @tipo ORDER BY id_tipo;";
                        using (SqlCommand cmd = new SqlCommand(queryTipo, conexion))
                        {
                            cmd.Parameters.AddWithValue("@tipo", boxTipo.Text);
                            object result = cmd.ExecuteScalar();
                            idTipo = (result != null) ? Convert.ToInt32(result) : 0;
                        }
                        //MessageBox.Show(idTipo.ToString());
                        string insertQuery = @"INSERT INTO hardware (folio, depto, area, didecon, responsable, ip, sn, procesador, memoria, disco_duro, grupo, nombre, activos, marca, modelo, activocontraloria, idestatus, fechacaptura, fechaalta, fechafactura, fechabaja, valorfactura, nomproveedor, idtipo, numerofactura) 
                                                                    VALUES (@folio, @depto, @area, @didecon, @responsable, @ip, @sn, @procesador, @memoria, @disco_duro, @grupo, @nombre, @activo, @marca, @modelo, @activocontraloria, @estatus, GETDATE(), '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', '1900-01-01 00:00:00.000', @valorFactura, @proveedor, @idTipo, @numeroFactura);";
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
                            insertCmd.Parameters.AddWithValue("@memoria", txtMemoria.Text);
                            insertCmd.Parameters.AddWithValue("@disco_duro", textDisco.Text);
                            insertCmd.Parameters.AddWithValue("@grupo", boxGrupo.Text);
                            insertCmd.Parameters.AddWithValue("@nombre", boxNombre.Text);
                            insertCmd.Parameters.AddWithValue("@activo", boxActSistemas.Text);
                            insertCmd.Parameters.AddWithValue("@marca", idMarca);
                            insertCmd.Parameters.AddWithValue("@modelo", idModelo);
                            insertCmd.Parameters.AddWithValue("@activocontraloria", boxActivo.Text);
                            insertCmd.Parameters.AddWithValue("@estatus", idEstatus);
                            insertCmd.Parameters.AddWithValue("@valorFactura", boxValorFactura.Text);
                            insertCmd.Parameters.AddWithValue("@proveedor", boxProveedor.Text);
                            insertCmd.Parameters.AddWithValue("@idTipo", idTipo);
                            insertCmd.Parameters.AddWithValue("@numeroFactura", boxNumFactura.Text);
                            insertCmd.ExecuteNonQuery();
                            MessageBox.Show("Registro insertado correctamente.","Confirmación",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            LimpiarControles();
                            BloquearControles(true);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea acutalizar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes) 
            {
                if (ValidarCampos())
                {
                    try
                    {
                        using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                        {
                            conexion.Open();
                            string idNuevoDependencia = "";
                            string queryDependencia = "SELECT id_dependencia FROM dependencias WHERE descripcion = @descripcion ORDER BY id_dependencia;";
                            using (SqlCommand cmd = new SqlCommand(queryDependencia, conexion))
                            {
                                cmd.Parameters.AddWithValue("@descripcion", boxDepartamento.Text);
                                object result = cmd.ExecuteScalar();
                                idNuevoDependencia = (result != null) ? result.ToString() : "";
                            }

                            string nuevoResponsable = boxResponsable.Text;
                            string nuevoNombre = boxNombre.Text;

                            int idNuevoMarca = 0;
                            string queryMarca = "SELECT id_marca FROM marcas WHERE descripcion = @marca ORDER BY id_marca;";
                            using (SqlCommand cmd = new SqlCommand(queryMarca, conexion))
                            {
                                cmd.Parameters.AddWithValue("@marca", boxMarca.Text);
                                object result = cmd.ExecuteScalar();
                                idNuevoMarca = (result != null) ? Convert.ToInt32(result) : 0;
                            }

                            int idNuevoModelo = 0;
                            string queryModelo = "SELECT id_modelo FROM modelos WHERE descripcion = @modelo ORDER BY id_modelo;";
                            using (SqlCommand cmd = new SqlCommand(queryModelo, conexion))
                            {
                                cmd.Parameters.AddWithValue("@modelo", boxModelo.Text);
                                object result = cmd.ExecuteScalar();
                                idNuevoModelo = (result != null) ? Convert.ToInt32(result) : 0;
                            }

                            string nuevoNumserie = boxNumSerie.Text;
                            string nuevoActivoSistemas = boxActSistemas.Text;
                            string nuevoActivo = boxActivo.Text;
                            string nuevoNumFactura = boxNumFactura.Text;
                            string nuevoValorFactura = boxValorFactura.Text;
                            string nuevoProveedor = boxProveedor.Text;

                            int idNuevoEstatus = 0;
                            string queryEstatus = "SELECT id_estatus FROM estatus WHERE descripcion = @estatus ORDER BY id_estatus;";
                            using (SqlCommand cmd = new SqlCommand(queryEstatus, conexion))
                            {
                                cmd.Parameters.AddWithValue("@estatus", boxEstatus.Text);
                                object result = cmd.ExecuteScalar();
                                idNuevoEstatus = (result != null) ? Convert.ToInt32(result) : 0;
                            }

                            int idNuevoTipo = 0;
                            string queryTipo = "SELECT id_tipo FROM tipos WHERE descripcion = @tipo ORDER BY id_tipo;";
                            using (SqlCommand cmd = new SqlCommand(queryTipo, conexion))
                            {
                                cmd.Parameters.AddWithValue("@tipo", boxTipo.Text);
                                object result = cmd.ExecuteScalar();
                                idNuevoTipo = (result != null) ? Convert.ToInt32(result) : 0;
                            }

                            string nuevoArea = boxArea.Text;
                            string nuevoDidecon = txtDidecon.Text;
                            string nuevoDirIP = boxDireccion.Text;
                            string nuevoGrupo = boxGrupo.Text;
                            string nuevoProcesador = txtProcesador.Text;
                            string nuevoMemoria = txtMemoria.Text;
                            string nuevoDisco = textDisco.Text;

                            string queryUpdate = @"UPDATE hardware SET depto = @idNuevoDependencia,
                                           responsable = @nuevoResponsable,
                                           nombre = @nuevoNombre,
                                           marca = @idNuevoMarca,
                                           modelo = @idNuevoModelo,
                                           sn =  @nuevoNumSerie,
                                           activos = @nuevoActivoSistemas,
                                           activocontraloria = @nuevoActivo,
                                           numerofactura = @nuevoNumFactura,
                                           idestatus = @idNuevoEstatus,
                                           idtipo = @idNuevoTipo,
                                           area = @nuevoArea,
                                           didecon = @nuevoDidecon,
                                           ip = @nuevoDirIp,
                                           grupo = @nuevoGrupo,
                                           procesador = @nuevoProcesador,
                                           memoria = @nuevoMemoria,
                                           disco_duro = @nuevoDisco
                                         WHERE hardware.folio = @folio;";
                            using (SqlCommand cmd = new SqlCommand(queryUpdate, conexion))
                            {
                                cmd.Parameters.AddWithValue("@idNuevoDependencia", idNuevoDependencia);
                                cmd.Parameters.AddWithValue("@nuevoResponsable", nuevoResponsable);
                                cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
                                cmd.Parameters.AddWithValue("@idNuevoMarca", idNuevoMarca);
                                cmd.Parameters.AddWithValue("@idNuevoModelo", idNuevoModelo);
                                cmd.Parameters.AddWithValue("@nuevoNumSerie", nuevoNumserie);
                                cmd.Parameters.AddWithValue("@nuevoActivoSistemas", nuevoActivoSistemas);
                                cmd.Parameters.AddWithValue("@nuevoActivo", nuevoActivo);
                                cmd.Parameters.AddWithValue("@nuevoNumFactura", nuevoNumFactura);
                                cmd.Parameters.AddWithValue("@idNuevoEstatus", idNuevoEstatus);
                                cmd.Parameters.AddWithValue("@idNuevoTipo", idNuevoTipo);
                                cmd.Parameters.AddWithValue("@nuevoArea", nuevoArea);
                                cmd.Parameters.AddWithValue("@nuevoDidecon", nuevoDidecon);
                                cmd.Parameters.AddWithValue("@nuevoDirIp", nuevoDirIP);
                                cmd.Parameters.AddWithValue("@nuevoGrupo", nuevoGrupo);
                                cmd.Parameters.AddWithValue("@nuevoProcesador", nuevoProcesador);
                                cmd.Parameters.AddWithValue("@nuevoMemoria", nuevoMemoria);
                                cmd.Parameters.AddWithValue("@nuevoDisco", nuevoDisco);
                                cmd.Parameters.AddWithValue("@folio", txtFolio.Text);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Registro actualizado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarControles();
                            }
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

        private void txtMemoria_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
            string pattern = @"^(2|4|8|16|32|64|128|256|512|1024|2048|3072|4096|6144|8192|12288|16384|24576|32768|49152|65536)\s(GB|TB)$";
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

        private void LlenarBoxEstatus()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    String query = "SELECT descripcion FROM estatus where id_estatus IN (7,8);";
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
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LlenarBoxTipo()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT descripcion FROM tipos WHERE descripcion IN ('CPU', 'MONITOR', 'ALL IN ONE', 'SERVIDOR');";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxEstatus.Items.Clear();
                        while (reader.Read())
                        {
                            boxTipo.Items.Add(reader["descripcion"].ToString());
                        }
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
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT Descripcion AS descripcion FROM Proveedor_Compra;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
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

        private void boxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarBoXModelo();
            if (boxMarca.SelectedItem != null && boxMarca.SelectedItem.ToString() != "-")
            {
                btnNuevoModelo.Enabled = true;
            }
            else
            {
                btnNuevoModelo.Enabled = false;
            }
        }

        private void LlenarBoXModelo()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
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
                    String query2 = "SELECT modelos.descripcion FROM modelos JOIN tipos ON tipos.id_tipo = modelos.tipo WHERE marca = @idMarca AND tipos.descripcion IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE');";
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
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
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
            this.Close();
        }

        private void Hardware_MouseDown(object sender, MouseEventArgs e)
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

        private void BloquearControles(bool bloquear)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enabled = !bloquear; // Deshabilita o habilita los controles
                }
            }

            txtFolio.Enabled = false; // Asegurar que txtFolio siempre esté bloqueado

            btnNuevo.Enabled = bloquear;    // "Nuevo" solo está habilitado cuando los demás están bloqueados
            btnAceptar.Enabled = !bloquear; // "Aceptar" solo se habilita cuando los controles están activos
            btnCancelar.Enabled = !bloquear; // "Cancelar" solo se habilita cuando los controles están activos
            btnNuevoMarca.Enabled = !bloquear;
            btnNuevoDepartamento.Enabled = !bloquear;
            btnNuevoProveedor.Enabled = !bloquear;
            //btnNuevoTipo.Enabled = !bloquear;
            btnBuscar.Enabled = !bloquear;
            if (btnActualizar.Enabled = true)
            {
                btnActualizar.Enabled = false;
            }
        }

        private void LimpiarControles()
        {
            // Limpiar TextBox
            txtFolio.Clear();
            txtProcesador.Clear();
            txtMemoria.Clear();
            textDisco.Clear();
            txtDidecon.Clear();

            // Limpiar ComboBox con opción predeterminada
            RestablecerComboBox(boxResponsable, ".   ");
            RestablecerComboBox(boxNombre, ".   ");
            RestablecerComboBox(boxNumSerie, ".   ");
            RestablecerComboBox(boxActSistemas, ".   ");
            RestablecerComboBox(boxActivo, ".   ");
            RestablecerComboBox(boxNumFactura, ".   ");
            RestablecerComboBox(boxValorFactura, "0.00");
            RestablecerComboBox(boxProveedor, ".   ");
            RestablecerComboBox(boxArea, ".   ");
            RestablecerComboBox(boxGrupo, ".   ");
            RestablecerComboBox(boxDireccion, ".   ");

            // Restablecer ComboBox que NO tienen opción predeterminada
            RestablecerComboBoxSinPredeterminado(boxDepartamento);
            RestablecerComboBoxSinPredeterminado(boxMarca);
            boxModelo.Items.Clear();
            boxModelo.SelectedIndex = -1;
            boxModelo.ResetText();
            RestablecerComboBoxSinPredeterminado(boxEstatus);
            RestablecerComboBoxSinPredeterminado(boxTipo);

            // Restablecer DateTimePicker
            dateTimePicker1.Value = DateTime.Today;
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

        private void ConfigurarBoxArea(ComboBox boxArea)
        {
            boxArea.Items.Clear();
            boxArea.Items.Add(".   ");  // Agregar opción por defecto
            boxArea.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxArea.SelectedIndex = 0; // Seleccionar "-" por defecto
            boxArea.Tag = "limpiar"; // Marcar que debe limpiarse

            boxArea.TextChanged += boxArea_TextChanged;
            boxArea.KeyPress += boxArea_KeyPress;
        }

        private void ConfigurarBoxResponsable(ComboBox boxResponsable)
        {
            boxResponsable.Items.Clear();
            boxResponsable.Items.Add(".   ");  // Agregar opción por defecto
            boxResponsable.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxResponsable.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxResponsable.TextChanged += boxResponsable_TextChanged;
            boxResponsable.KeyPress += boxResponsable_KeyPress;
        }

        private void ConfigurarBoxNombre(ComboBox boxNombre)
        {
            boxNombre.Items.Clear();
            boxNombre.Items.Add(".   ");  // Agregar opción por defecto
            boxNombre.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxNombre.SelectedIndex = 0; // Seleccionar "-" por defecto
            boxNombre.TextChanged += boxNombre_TextChanged;
        }

        private void ConfigurarBoxActSistemas(ComboBox boxActivoSistemas)
        {
            boxActivoSistemas.Items.Clear();
            boxActivoSistemas.Items.Add(".   ");  // Agregar opción por defecto
            boxActivoSistemas.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxActivoSistemas.SelectedIndex = 0; // Seleccionar "-" por defecto
            boxActivoSistemas.TextChanged += boxActSistemas_TextChanged;
            boxActivoSistemas.KeyPress += boxActSistemas_KeyPress;
        }

        private void ConfigurarBoxNumFactura(ComboBox boxNumFactura)
        {
            boxNumFactura.Items.Clear();
            boxNumFactura.Items.Add(".   ");  // Agregar opción por defecto
            boxNumFactura.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxNumFactura.SelectedIndex = 0; // Seleccionar "-" por defecto
            boxNumFactura.TextChanged += boxNumFactura_TextChanged;
            boxNumFactura.KeyPress += boxNumFactura_KeyPress;
        }

        private void ConfigurarBoxValorFactura(ComboBox boxValorFactura)
        {
            boxValorFactura.Items.Clear();
            boxValorFactura.Items.Add("0.00");  // Agregar opción por defecto
            boxValorFactura.DropDownStyle = ComboBoxStyle.DropDown;
            boxValorFactura.SelectedIndex = 0; // Seleccionar "0.00" por defecto
            boxValorFactura.KeyPress += boxValorFactura_KeyPress;

        }

        private void ConfigurarBoxDireccion(ComboBox boxDireccion)
        {
            boxDireccion.Items.Clear();
            boxDireccion.Items.Add(".   ");  // Agregar opción por defecto
            boxDireccion.Items.Add("SN");
            boxDireccion.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxDireccion.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxDireccion.TextChanged += boxDireccion_TextChanged;
            boxDireccion.KeyPress += boxDireccion_KeyPress;
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
            boxActivo.TextChanged += boxActivo_TextChanged;
            boxActivo.KeyPress += boxActivo_KeyPress;
        }

        private void ConfigurarBoxGrupo(ComboBox boxGrupo)
        {
            boxGrupo.Items.Clear();
            boxGrupo.Items.Add(".   ");  // Agregar opción por defecto
            boxGrupo.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxGrupo.SelectedIndex = 0; // Seleccionar "-" por defecto
            boxGrupo.TextChanged += boxGrupo_TextChanged;
            boxGrupo.KeyPress += boxGrupo_KeyPress;
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
            ComboBox comboBox = sender as ComboBox;
            // Evitar que se ingresen más de 30 caracteres
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 30)
            {
                e.Handled = true;
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

        private void boxNombre_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Convertir a mayúsculas
            comboBox.Text = comboBox.Text.ToUpper();

            // Mover el cursor al final
            comboBox.SelectionStart = comboBox.Text.Length;
        }

        private void boxActSistemas_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            // Convertir a mayúsculas
            comboBox.Text = comboBox.Text.ToUpper();
            // Mover el cursor al final
            comboBox.SelectionStart = comboBox.Text.Length;
        }

        private void boxActSistemas_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.Text == ".   ")
            {
                comboBox.Text = "";
            }

            if (comboBox.SelectionLength == comboBox.Text.Length)
            {
                comboBox.Text = "";
            }

            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 4)
            {
                e.Handled = true;
            }
        }


        private void boxNumFactura_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            // Convertir a mayúsculas
            comboBox.Text = comboBox.Text.ToUpper();
            // Mover el cursor al final
            comboBox.SelectionStart = comboBox.Text.Length;
        }

        private void boxNumFacuta_KeyPress(object sender, KeyPressEventArgs e)
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

        private void boxNumFactura_KeyPress(object sender, KeyPressEventArgs e)
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

        private void boxGrupo_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            // Convertir a mayúsculas
            comboBox.Text = comboBox.Text.ToUpper();
            // Mover el cursor al final
            comboBox.SelectionStart = comboBox.Text.Length;
        }

        private void boxGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Evitar que se ingresen más de 15 dígitos
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 15)
            {
                e.Handled = true;
            }
        }

        private void boxDireccion_TextChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.Text == ".   " || comboBox.Text == "SN")
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

        private void boxNumSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.Text == ".   ")
            {
                comboBox.Text = "";
            }

            if (comboBox.SelectionLength == comboBox.Text.Length)
            {
                comboBox.Text = "";
            }

            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 15)
            {
                e.Handled = true;
            }

        }

        private void boxActivo_TextChanged(object sender, EventArgs e)
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
            // Evitar que se ingresen más de 50 caracteres
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 50)
            {
                e.Handled = true;
            }
        }

        private void boxValorFactura_KeyPress(object sender, KeyPressEventArgs e)
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
            if (e.KeyChar == '.' && (comboBox.Text.EndsWith(".") || comboBox.Text.Split('.').Length > 1))
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

        private void boxProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            // Evitar que se ingresen más de 15 dígitos
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 15)
            {
                e.Handled = true;
            }
        }

        private void obtenerSiguienteNumero()
        {
            try
            {
                using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                {
                    conexion.Open();
                    string query = "SELECT ISNULL(MAX(folio), 0) + 1 AS SiguienteNumero FROM hardware;";
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
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
            string mensajeError = "Los siguientes campos son inválidos:\n";
            if (boxDepartamento.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxDepartamento.Text))
            {
                mensajeError += "- Selecciona un departamento válido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxArea.Text))
            {
                mensajeError += "- Selecciona un área válida.\n";
                esValido = false;
            }
            if (txtDidecon.Text.Length != 7 || !int.TryParse(txtDidecon.Text, out _))
            {
                mensajeError += "- El Didecon debe tener 7 dígitos.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxActivo.Text))
            {
                mensajeError += "- Selecciona un Act. Contraloria válido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxResponsable.Text))
            {
                mensajeError += "- Selecciona un responsable válido.\n";
                esValido = false;
            }
            if (string.IsNullOrEmpty(boxNombre.Text))
            {
                mensajeError += "- Selecciona un Nom. Equipo valido.\n";
                esValido = false;

            }
            string ipPattern = @"^(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])(\.(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])){3}$";
            if (boxDireccion.Text != ".   " && boxDireccion.Text != "SN" && !Regex.IsMatch(boxDireccion.Text, ipPattern))
            {
                mensajeError += "- La dirección debe ser una IP válida (Ej: 192.168.1.1) o '.   ' / 'SN'.\n";
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
            if (string.IsNullOrWhiteSpace(boxNumSerie.Text))
            {
                mensajeError += "- Selecciona un número de serie válido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxActSistemas.Text))
            {
                mensajeError += "- Selecciona un Act. Sistemas válido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxNumFactura.Text))
            {
                mensajeError += "- Selecciona un Num. Factura válido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxValorFactura.Text))
            {
                mensajeError += "- Selecciona un Valor Factura válido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxProveedor.Text))
            {
                mensajeError += "- Selecciona un Proveedor válido.\n";
                esValido = false;
            }
            if (boxEstatus.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxEstatus.Text))
            {
                mensajeError += "- Selecciona un estatus válido.\n";
                esValido = false;
            }
            if (boxTipo.SelectedIndex == -1 || string.IsNullOrWhiteSpace(boxTipo.Text))
            {
                mensajeError += "- Selecciona un tipo válido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(boxGrupo.Text))
            {
                mensajeError += "- Selecciona un grupo válido.\n";
                esValido = false;
            }
            string procesadorPattern = @"^(INTEL|AMD|PENTIUM)\s+[A-Za-z0-9]+(\s+[A-Za-z0-9]+)?(\s+PRO)?$";
            if (!Regex.IsMatch(txtProcesador.Text, procesadorPattern, RegexOptions.IgnoreCase))
            {
                mensajeError += "- El procesador debe ser Intel, AMD o Pentium (Ej: 'Intel Core i5').\n";
                esValido = false;
            }
            string memoriaPattern = @"^(2|4|8|16|32|64|128|256|512|1024|2048|3072|4096|6144|8192|12288|16384|24576|32768|49152|65536)\s(GB|TB)$";
            if (!Regex.IsMatch(txtMemoria.Text, memoriaPattern, RegexOptions.IgnoreCase))
            {
                mensajeError += "- La memoria debe estar en formato correcto (Ej: '8 GB' o '32 GB').\n";
                esValido = false;
            }
            string discoPattern = @"^\d+\s*(GB|TB)$";
            if (!Regex.IsMatch(textDisco.Text, discoPattern, RegexOptions.IgnoreCase))
            {
                mensajeError += "- El disco duro debe estar en formato correcto (Ej: '500 GB' o '1 TB').\n";
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
            return boxDepartamento.DroppedDown || boxMarca.DroppedDown || boxModelo.DroppedDown ||
                boxArea.DroppedDown || boxResponsable.DroppedDown || boxDireccion.DroppedDown ||
                boxNumSerie.DroppedDown || boxActivo.DroppedDown;
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
            Modelo modelo = new Modelo(marca, "CPU");
            modelo.ModeloAgregada += LlenarBoXModelo;
            modelo.ShowDialog();
        }

        private void btnNuevoDepartamento_Click(object sender, EventArgs e)
        {
            Dependencias dependencias = new Dependencias();
            dependencias.DependenciaAgregada += LlenarBoxDepartamento;
            dependencias.ShowDialog();
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.ProveedorAgregado += LlenarBoxProveedor;
            proveedor.ShowDialog();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (var buscarPerifericos = new BuscarPerifericos("CPU"))
            {
                buscarPerifericos.FormClosed += (s, args) => obtenerSiguienteNumero();
                if (buscarPerifericos.ShowDialog() == DialogResult.OK)
                {
                    string folio = buscarPerifericos.FolioSeleccionado;
                    if (!string.IsNullOrEmpty(folio))
                    {
                        CargarDatosPorFolio(folio);
                    }
                    else
                    {
                        MessageBox.Show("No seleccionaste ningun folio");
                    }
                }
            }
            btnAceptar.Enabled = false;
            btnActualizar.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CambiarPerifericos cambiarPerifericos = new CambiarPerifericos();
            cambiarPerifericos.ShowDialog();
        }

        private void AsignarValorComboBox(ComboBox comboBox, string valor)
        {
            if (!comboBox.Items.Contains(valor))
            {
                comboBox.Items.Add(valor);
            }
            comboBox.SelectedItem = valor;
        }

        private void CargarDatosPorFolio(string folio)
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = @"SELECT hardware.folio AS Numero, 
                                dependencias.descripcion AS Departamento, 
                                hardware.responsable AS Responsable, 
                                hardware.nombre AS Nombre, 
                                marcas.descripcion AS Marca, 
                                modelos.descripcion AS Modelo, 
                                hardware.sn AS Serial, 
                                hardware.activos AS 'Act. Sistemas', 
                                hardware.activocontraloria AS 'Act. Contraloria', 
                                hardware.numerofactura AS 'Num. Factura', 
                                hardware.valorfactura AS 'Valor Factura', 
                                hardware.nomproveedor AS 'Nom. Proveedor', 
                                estatus.descripcion AS 'Estatus', 
                                tipos.descripcion AS 'Tipo', 
                                hardware.area AS 'Area', 
                                hardware.didecon AS 'Didecon', 
                                hardware.ip AS 'Dir. IP', 
                                hardware.grupo AS 'Grupo', 
                                hardware.procesador AS 'Procesador', 
                                hardware.memoria AS 'Memoria', 
                                hardware.disco_duro AS 'Disco',        
                                hardware.fechacaptura AS 'Fecha'
                    FROM hardware 
                    JOIN dependencias ON dependencias.id_dependencia = hardware.depto 
                    JOIN marcas ON marcas.id_marca = hardware.marca
                    JOIN modelos ON modelos.id_modelo = hardware.modelo
                    JOIN estatus ON estatus.id_estatus = hardware.idestatus
                    JOIN tipos ON tipos.id_tipo = hardware.idtipo 
                    WHERE hardware.folio = @folio;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@folio", folio);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                //ComboBox
                                AsignarValorComboBox(boxDepartamento, reader["Departamento"].ToString());
                                AsignarValorComboBox(boxResponsable, reader["Responsable"].ToString());
                                AsignarValorComboBox(boxNombre, reader["Nombre"].ToString());
                                AsignarValorComboBox(boxMarca, reader["Marca"].ToString());
                                AsignarValorComboBox(boxModelo, reader["Modelo"].ToString());
                                AsignarValorComboBox(boxNumSerie, reader["Serial"].ToString());
                                AsignarValorComboBox(boxActSistemas, reader["Act. Sistemas"].ToString());
                                AsignarValorComboBox(boxActivo, reader["Act. Contraloria"].ToString());
                                AsignarValorComboBox(boxNumFactura, reader["Num. Factura"].ToString());
                                AsignarValorComboBox(boxValorFactura, reader["Valor Factura"].ToString());
                                AsignarValorComboBox(boxProveedor, reader["Nom. Proveedor"].ToString());
                                AsignarValorComboBox(boxEstatus, reader["Estatus"].ToString());
                                AsignarValorComboBox(boxTipo, reader["Tipo"].ToString());
                                AsignarValorComboBox(boxArea, reader["Area"].ToString());
                                AsignarValorComboBox(boxDireccion, reader["Dir. IP"].ToString());

                                //TextBox
                                txtFolio.Text = reader["Numero"].ToString();
                                txtProcesador.Text = reader["Procesador"].ToString();
                                txtMemoria.Text = reader["Memoria"].ToString();
                                textDisco.Text = reader["Disco"].ToString();
                                txtDidecon.Text = reader["Didecon"].ToString();

                                // DateTimePicker (manejo de valores nulos)
                                if (reader["Fecha"] != DBNull.Value)
                                {
                                    dateTimePicker1.Value = Convert.ToDateTime(reader["Fecha"]);
                                }
                                else
                                {
                                    dateTimePicker1.Value = DateTime.Today;
                                }

                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para el folio");
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
    }
}
