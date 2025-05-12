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
            radioCpu.Enabled = !bloquear;
            radioPeriferico.Enabled = !bloquear;
            btnBuscar2.Enabled = bloquear;
            btnActualizar.Enabled = !bloquear;
            btnEliminar.Enabled = !bloquear;
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
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
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
            dateSalida.Enabled = false;
            dateReparacion.Enabled = false;
            dateRefaccionPedido.Enabled = false;
            dateRefaccionEntrega.Enabled = false;
            dateExternoPedido.Enabled = false;
            dateExternoEntrega.Enabled = false;
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
                string queryUpdate = "";
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
                    if (radioCpu.Checked == true)
                    {
                        queryUpdate = "UPDATE hardware SET idestatus = 1 WHERE hardware.folio = @folio;";
                    }
                    else if (radioPeriferico.Checked == true)
                    {
                        queryUpdate = "UPDATE perifericos SET idestatus = 1 WHERE perifericos.folio = @folio;";
                    }
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtServicio.Text))
            {
                string queryUpdate = "";
                string queryEstatus = "";
                DateTime nuevaFechaLlegada = dateEntrada.Value;
                DateTime nuevaFechSalida = dateSalida.Value;
                DateTime nuevaFechaReparacion = dateReparacion.Value;
                DateTime nuevaFechaRefaccionPedido = dateRefaccionPedido.Value;
                DateTime nuevaFechaRefaccionEntrega = dateRefaccionEntrega.Value;
                DateTime nuevaFechaExternoPedido = dateExternoPedido.Value;
                DateTime nuevaFechaExternoEntrega = dateExternoEntrega.Value;
                try 
                {
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        int idEstatus = 0;
                        queryEstatus = "SELECT id_estatus FROM estatus WHERE descripcion = @estatus ORDER BY id_estatus;";
                        using (SqlCommand cmd = new SqlCommand(queryEstatus, connection))
                        {
                            cmd.Parameters.AddWithValue("@estatus", boxEstatus.Text);
                            object result = cmd.ExecuteScalar();
                            idEstatus = (result != null) ? Convert.ToInt32(result) : 0;
                        }
                        queryUpdate = @"UPDATE servicios SET
                                    fecha_llegada = @nuevaFechaLlegada,
                                    fecha_salida = @nuevaFechSalida,
                                    fecha_reparacion = @nuevaFechaReparacion,
                                    fecha_refaccion_pedida = @nuevaFechaRefaccionPedido,
                                    fecha_refaccion_entrega = @nuevaFechaRefaccionEntrega,
                                    fecha_externo_llegada = @nuevaFechaExternoPedido,
                                    fecha_externo_salida = @nuevaFechaExternoEntrega,
                                    estatus = @idEstatus,
                                    falla = @falla,
                                    reporto = @reporto,
                                    recoge = @recoge,
                                    quien_reparo = @reparo,
                                    reparacion = @reparacion,
                                    reparacion_externa = @externa,
                                    refacciones = @refacciones
                        WHERE id_servicio = @id_servicio;";
                        using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate,connection))
                        {
                            cmdUpdate.Parameters.AddWithValue("@nuevaFechaLlegada",nuevaFechaLlegada);
                            cmdUpdate.Parameters.AddWithValue("@nuevaFechSalida", nuevaFechSalida);
                            cmdUpdate.Parameters.AddWithValue("@nuevaFechaReparacion", nuevaFechaReparacion);
                            cmdUpdate.Parameters.AddWithValue("@nuevaFechaRefaccionPedido", nuevaFechaRefaccionPedido);
                            cmdUpdate.Parameters.AddWithValue("@nuevaFechaRefaccionEntrega", nuevaFechaRefaccionEntrega);
                            cmdUpdate.Parameters.AddWithValue("@nuevaFechaExternoPedido", nuevaFechaExternoPedido);
                            cmdUpdate.Parameters.AddWithValue("@nuevaFechaExternoEntrega", nuevaFechaExternoEntrega);
                            cmdUpdate.Parameters.AddWithValue("@idEstatus",idEstatus);
                            cmdUpdate.Parameters.AddWithValue("@falla", txtFalla.Text);
                            cmdUpdate.Parameters.AddWithValue("@reporto", txtSolicito.Text);
                            cmdUpdate.Parameters.AddWithValue("@recoge", txtRecogio.Text);
                            cmdUpdate.Parameters.AddWithValue("@reparo", txtReparo.Text);
                            cmdUpdate.Parameters.AddWithValue("@reparacion", txtReparacionInterna.Text);
                            cmdUpdate.Parameters.AddWithValue("@externa", txtReparacionExterna.Text);
                            cmdUpdate.Parameters.AddWithValue("@refacciones", txtRefacciones.Text);
                            cmdUpdate.Parameters.AddWithValue("@id_servicio", txtServicio.Text);
                            cmdUpdate.ExecuteNonQuery();
                        }
                        MessageBox.Show("Registro actualizado con éxito.");
                        LimpiarControles();
                        BloquearControles(this, true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun servicio para actualizar");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (radioCpu.Checked == true)
            {
                using (var buscarPerifericos = new BuscarPerifericos("CPU-2"))
                {
                    buscarPerifericos.FormClosed += (s, args) => ObtenerSiguienteNumero();
                    if (buscarPerifericos.ShowDialog() == DialogResult.OK)
                    {
                        string folio = buscarPerifericos.FolioSeleccionado;
                        if (!string.IsNullOrEmpty(folio))
                        {
                            CargarDatosPorFolio(folio);
                        }
                        else
                        {
                            MessageBox.Show("No se selecciono ningun folio");
                        }
                    }
                }
            }
            else if (radioPeriferico.Checked == true)
            {
                using (var buscarPerifericos = new BuscarPerifericos("PERIFERICOS-2"))
                {
                    buscarPerifericos.FormClosed += (s, args) => ObtenerSiguienteNumero();
                    if (buscarPerifericos.ShowDialog() == DialogResult.OK)
                    {
                        string folio = buscarPerifericos.FolioSeleccionado;
                        if (!string.IsNullOrEmpty(folio))
                        {
                            CargarDatosPorFolio(folio);
                        }
                        else
                        {
                            MessageBox.Show("No se selecciono ningun folio");
                        }
                    }
                }
            }
            txtDidecon.Enabled = false;
            txtFolio.Enabled = false;
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            using (var buscarServicios = new BuscarServicios())
            {
                if (buscarServicios.ShowDialog() == DialogResult.OK)
                {
                    string folio = buscarServicios.FolioSeleccionado;
                    string tipo = buscarServicios.TipoSeleccionado;
                    if (tipo == "CPU")
                    {
                        radioCpu.Checked = true;
                        radioPeriferico.Checked = false;
                    }
                    else
                    {
                        radioCpu.Checked = false;
                        radioPeriferico.Checked = true;
                    }
                    if (!string.IsNullOrEmpty(folio))
                    {
                        boxEstatus.Enabled = true;
                        HabilitarDateTimePickers(this);
                        txtFalla.Enabled = true;
                        txtSolicito.Enabled = true;
                        txtRecogio.Enabled = true;
                        txtReparo.Enabled = true;
                        txtReparacionInterna.Enabled = true;
                        txtReparacionExterna.Enabled = true;
                        txtRefacciones.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnEliminar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnNuevo.Enabled = false;
                        btnActualizar.Enabled = true;
                        btnEliminar.Enabled = true;
                        CargarDatosPorFolio2(folio);
                    }
                }
            }
        }

        private void HabilitarDateTimePickers(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is DateTimePicker dtp)
                {
                    dtp.Enabled = true;
                }
                else if (ctrl.HasChildren)
                {
                    HabilitarDateTimePickers(ctrl);
                }
            }
        }

        private void CargarDatosPorFolio(string folio)
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    string query = "";
                    conn.Open();
                    if (radioCpu.Checked == true)
                    {
                        query = @"SELECT hardware.folio AS Numero, 
                                hardware.didecon AS Didecon, 
                                estatus.descripcion AS Estatus
                            FROM hardware 
                            JOIN estatus ON hardware.idestatus = estatus.id_estatus 
                            WHERE hardware.folio = @folio;";
                    }
                    else if(radioPeriferico.Checked == true)
                    {
                        query = @"SELECT perifericos.folio AS Numero, 
                                perifericos.didecon AS Didecon, 
                                estatus.descripcion AS Estatus 
                        FROM perifericos 
                        JOIN estatus ON perifericos.idestatus = estatus.id_estatus 
                        WHERE perifericos.folio = @folio;";
                    }
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

        private void CargarDatosPorFolio2(string folio)
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    string query = "";
                    conn.Open();
                    if (radioCpu.Checked == true)
                    {
                        query = @"SELECT hardware.folio AS Numero, 
	                            hardware.didecon AS Didecon, 
                                estatus.descripcion AS Estatus,
                                servicios.id_servicio AS idServicio,
	                            servicios.falla AS Falla,
	                            servicios.reporto AS Reporto,
                                servicios.recoge AS Recogio,
								servicios.quien_reparo AS Reparo,
								servicios.reparacion AS Reparacion,
								servicios.reparacion_externa AS Externa,
								servicios.refacciones AS Refacciones,
	                            servicios.fecha_llegada AS Llegada,
	                            servicios.fecha_salida AS Salida,
	                            servicios.fecha_reparacion AS Reparacion,
	                            servicios.fecha_refaccion_pedida AS RefaccionPedido,
	                            servicios.fecha_externo_salida AS RefaccionEntrega,
	                            servicios.fecha_externo_llegada AS ExternoLlegada,
                        FROM hardware 
                        JOIN servicios ON hardware.didecon = servicios.didecon
                        WHERE hardware.folio = @folio;";
                    }
                    else if (radioPeriferico.Checked == true)
                    {
                        query = @"SELECT perifericos.folio AS Numero, 
	                            perifericos.didecon AS Didecon, 
	                            estatus.descripcion AS Estatus,
                                servicios.id_servicio AS idServicio,
	                            servicios.falla AS Falla,
	                            servicios.reporto AS Reporto,
                                servicios.recoge AS Recogio,
                                servicios.quien_reparo AS Reparo,
								servicios.reparacion AS Reparacion,
								servicios.reparacion_externa AS Externa,
								servicios.refacciones AS Refacciones,
	                            servicios.fecha_llegada AS Llegada,
	                            servicios.fecha_salida AS Salida,
	                            servicios.fecha_reparacion AS Reparacion,
	                            servicios.fecha_refaccion_pedida AS RefaccionPedido,
	                            servicios.fecha_externo_salida AS RefaccionEntrega,
	                            servicios.fecha_externo_llegada AS ExternoLlegada,
                        FROM perifericos 
                        JOIN servicios ON perifericos.didecon = servicios.didecon
                        WHERE perifericos.folio = @folio;";
                    }

                    using (SqlCommand cmd = new SqlCommand(query,conn))
                    {
                        cmd.Parameters.AddWithValue("@folio", folio);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtServicio.Text = reader["idServicio"].ToString();
                                txtFolio.Text = reader["Numero"].ToString();
                                txtDidecon.Text = reader["Didecon"].ToString();
                                boxEstatus.Text = reader["Estatus"].ToString();
                                txtFalla.Text = reader["Falla"].ToString();
                                txtSolicito.Text = reader["Reporto"].ToString();
                                txtRecogio.Text = reader["Recogio"].ToString();
                                txtReparo.Text = reader["Reparo"].ToString();
                                txtReparacionInterna.Text = reader["Reparacion"].ToString();
                                txtReparacionExterna.Text = reader["Externa"].ToString();
                                txtRefacciones.Text = reader["Refacciones"].ToString();
                                dateEntrada.Value = reader["Llegada"] != DBNull.Value ? Convert.ToDateTime(reader["Llegada"]) : DateTime.Now;
                                dateSalida.Value = reader["Salida"] != DBNull.Value ? Convert.ToDateTime(reader["Salida"]) : DateTime.Now;
                                dateRefaccionPedido.Value = reader["RefaccionPedido"] != DBNull.Value ? Convert.ToDateTime(reader["RefaccionPedido"]) : DateTime.Now;
                                dateRefaccionEntrega.Value = reader["RefaccionEntrega"] != DBNull.Value ? Convert.ToDateTime(reader["RefaccionEntrega"]) : DateTime.Now;
                                dateExternoPedido.Value = reader["ExternoLlegada"] != DBNull.Value ? Convert.ToDateTime(reader["ExternoLlegada"]) : DateTime.Now;
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
            if (dateEntrada.Value.Date > DateTime.Now.Date)
            {
                mensajeError += "- Especifique una fecha valida.\n";
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
            string query = "";
            bool existe = false;
            try 
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    if (radioCpu.Checked == true)
                    {
                        query = "SELECT COUNT(1) FROM hardware WHERE folio = @folio";
                    }
                    else if (radioPeriferico.Checked == true)
                    {
                        query = "SELECT COUNT(1) FROM perifericos WHERE folio = @folio";
                    }
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@folio", folio);
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
                    string query = "";
                    connection.Open();
                    if (radioCpu.Checked == true)
                    {
                        query = "SELECT COUNT(1) FROM hardware WHERE didecon = @didecon;";
                    }
                    else if (radioPeriferico.Checked == true)
                    {
                        query = "SELECT COUNT(1) FROM perifericos WHERE didecon = @didecon;";
                    }
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@didecon", didecon);
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

        private void txtFalla_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
        }

        private void txtSolicito_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
        }
    }
}
