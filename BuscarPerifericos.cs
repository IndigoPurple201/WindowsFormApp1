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
    public partial class BuscarPerifericos : Form
    {
        public event Action MarcaAgregada;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private System.Windows.Forms.Timer parpadeoTimer;
        private int parpadeoContador = 0;
        private Color bordeOriginal = Color.Black;
        private Color panelOriginal;
        private bool parpadeoActivo = false;
        private string tipoFiltro = "";
        public string FolioSeleccionado { get; private set; }
        [DllImport("user32.dll")]
        private static extern void MessageBeep(uint uType);
        private const uint MB_ICONERROR = 0x10;
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private ConexionSQL conexionSQL;
        public BuscarPerifericos(string tipo)
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);

            this.MouseDown += new MouseEventHandler(BuscarPerifericos_MouseDown);
            tipoFiltro = tipo;
        }

        private void BuscarPerifericos_Load(object sender, EventArgs e)
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
            ConfigurarDataGridView();
            if (tipoFiltro == "CPU" || tipoFiltro == "CPU-2")
            {
                CargarDatosDGV();
                label3.Text = "NUMERO:";
                boxBuscarDepartmanentoCPU.Visible = false;
                txtBuscarDirCPU.Visible = false;
                txtBuscarActivoCPU.Visible = false;
                boxBuscarMarca.Visible = false;
                boxBuscarTipo.Visible = false;
                txtBuscarFolioCPU.Visible = true;
                radioNumeroCPU.Checked = true;
                txtBuscarFolioCPU.Focus();

                txtBuscarFolio.Visible = false;
                boxBuscarDepartamento.Visible = false;
                txtBuscarDidecon.Visible = false;
                txtBuscarActivo.Visible = false;
                txtBuscarNumero.Visible = false;

                radioFolio.Visible = false;
                radioDepartamento.Visible = false;
                radioDidecon.Visible = false;
                radioNumSerie.Visible = false;
                radioActivo.Visible = false;
            }
            else if(tipoFiltro == "PERIFERICOS" || tipoFiltro == "PERIFERICOS-2")
            {
                CargarDatosDGV();
                label3.Text = "NUMERO:";
                boxBuscarDepartamento.Visible = false;
                txtBuscarDidecon.Visible = false;
                txtBuscarActivo.Visible = false;
                txtBuscarNumero.Visible = false;
                txtBuscarFolio.Visible = true;
                radioFolio.Checked = true;
                txtBuscarFolio.Focus();

                txtBuscarFolioCPU.Visible = false;
                boxBuscarDepartmanentoCPU.Visible = false;
                txtBuscarDirCPU.Visible = false;
                txtBuscarActivoCPU.Visible = false;
                boxBuscarMarca.Visible = false;
                boxBuscarTipo.Visible = false;

                radioNumeroCPU.Visible = false;
                radioDepartamentoCPU.Visible = false;
                radioDirIP.Visible = false;
                radioActivoCPU.Visible = false;
                radioPerifericos.Visible = false;

            }
            configurarBoxMarca(boxBuscarMarca);
            configurarBoxTipo(boxBuscarTipo);   
        }   

        private void BuscarPerifericos_MouseDown(object sender, MouseEventArgs e)
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

        private void ConfigurarDataGridView()
        {
            dgvPerifericos.BackgroundColor = Color.White;
            dgvPerifericos.BorderStyle = BorderStyle.None;
            dgvPerifericos.AllowUserToAddRows = false;
            dgvPerifericos.RowHeadersVisible = false;
            dgvPerifericos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPerifericos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvPerifericos.RowTemplate.Height = 20;
            dgvPerifericos.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvPerifericos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvPerifericos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvPerifericos.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvPerifericos.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPerifericos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPerifericos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPerifericos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPerifericos.ColumnHeadersHeight = 35;
            dgvPerifericos.EnableHeadersVisualStyles = false;
            dgvPerifericos.AllowUserToResizeRows = false;
            dgvPerifericos.AllowUserToResizeColumns = false;
            if (tipoFiltro == "CPU")
            {
                if (dgvPerifericos.Columns.Count == 0)
                {
                    dgvPerifericos.Columns.Add("Numero", "Número");
                    dgvPerifericos.Columns.Add("Didecon", "Didecon");
                    dgvPerifericos.Columns.Add("Act. Contraloria", "Act. Contraloria");
                    dgvPerifericos.Columns.Add("Dir. IP", "Dir. IP");
                    dgvPerifericos.Columns.Add("Responsable", "Responsable");
                    dgvPerifericos.Columns.Add("Tipo", "Tipo");
                    dgvPerifericos.Columns.Add("Marca", "Marca");
                    dgvPerifericos.Columns.Add("Modelo", "Modelo");
                    dgvPerifericos.Columns.Add("Procesador", "Procesador");
                    dgvPerifericos.Columns.Add("Estatus", "Estatus");
                }
            }
            else
            {
                if (dgvPerifericos.Columns.Count == 0)
                {
                    dgvPerifericos.Columns.Add("Numero", "Número");
                    dgvPerifericos.Columns.Add("Didecon", "Didecon");
                    dgvPerifericos.Columns.Add("Tipo", "Tipo");
                    dgvPerifericos.Columns.Add("Marca", "Marca");
                    dgvPerifericos.Columns.Add("Modelo", "Modelo");
                    dgvPerifericos.Columns.Add("N. Serie", "N. Serie");
                    dgvPerifericos.Columns.Add("Act. Contraloria", "Act. Contraloria");
                    dgvPerifericos.Columns.Add("Departamento", "Departamento");
                    dgvPerifericos.Columns.Add("Area", "Area");
                    dgvPerifericos.Columns.Add("Responsable", "Responsable");
                    dgvPerifericos.Columns.Add("Estatus", "Estatus");
                }
            }
            foreach (DataGridViewColumn column in dgvPerifericos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void CargarDatosDGV()
        {
            try
            {
                string query = "";
                if (tipoFiltro == "CPU" || tipoFiltro == "CPU-2")
                {
                    query = @"SELECT hardware.folio AS Numero, 
                            hardware.didecon AS Didecon, 
                            hardware.activocontraloria AS 'Act. Contraloria', 
                            hardware.ip AS 'Dir. IP', 
                            hardware.responsable AS 'Responsable',
							tipos.descripcion AS Tipo,
                            marcas.descripcion AS Marca, 
							modelos.descripcion AS Modelo, 
                            hardware.procesador AS Procesador,
                            estatus.descripcion AS Estatus
                        FROM hardware 
                        JOIN tipos on tipos.id_tipo = hardware.idtipo
                        JOIN estatus ON estatus.id_estatus = hardware.idestatus
					    JOIN marcas ON marcas.id_marca = hardware.marca
						JOIN modelos ON modelos.id_modelo = hardware.modelo
                        WHERE tipos.descripcion IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')";
                    if (tipoFiltro == "CPU-2")
                    {
                        query += " AND estatus.descripcion = 'ACTIVO'";
                    }
                    query += " ORDER BY hardware.folio ASC;";
                }
                else if(tipoFiltro == "PERIFERICOS" || tipoFiltro == "PERIFERICOS-2")
                {
                    query = @"SELECT perifericos.folio AS Numero, 
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
                        WHERE tipos.descripcion NOT IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')";
                    if (tipoFiltro == "PERIFERICOS-2")
                    {
                        query += " AND estatus.descripcion = 'ACTIVO'";
                    }
                    query += " ORDER BY perifericos.folio ASC;";
                }
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvPerifericos.Rows.Clear();
                        dgvPerifericos.Columns.Clear();
                        if (tipoFiltro == "CPU" || tipoFiltro == "CPU-2")
                        {
                            dgvPerifericos.Columns.Add("Numero", "Número");
                            dgvPerifericos.Columns.Add("Didecon", "Didecon");
                            dgvPerifericos.Columns.Add("Act. Contraloria", "Act. Contraloria");
                            dgvPerifericos.Columns.Add("Dir. IP", "Dir. IP");
                            dgvPerifericos.Columns.Add("Responsable", "Responsable");
                            dgvPerifericos.Columns.Add("Tipo", "Tipo");
                            dgvPerifericos.Columns.Add("Marca", "Marca");
                            dgvPerifericos.Columns.Add("Modelo", "Modelo");
                            dgvPerifericos.Columns.Add("Procesador", "Procesador");
                            dgvPerifericos.Columns.Add("Estatus", "Estatus");
                            while (reader.Read())
                            {
                                int index = dgvPerifericos.Rows.Add();
                                dgvPerifericos.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                dgvPerifericos.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                dgvPerifericos.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                dgvPerifericos.Rows[index].Cells["Dir. IP"].Value = reader["Dir. IP"].ToString();
                                dgvPerifericos.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                dgvPerifericos.Rows[index].Cells["Tipo"].Value = reader["Tipo"];    
                                dgvPerifericos.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                dgvPerifericos.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                dgvPerifericos.Rows[index].Cells["Procesador"].Value = reader["Procesador"].ToString();
                                dgvPerifericos.Rows[index].Cells["Estatus"].Value = reader["Estatus"].ToString();
                            }
                        }
                        else if (tipoFiltro == "PERIFERICOS" || tipoFiltro == "PERIFERICOS-2")
                        {
                            dgvPerifericos.Columns.Add("Numero", "Número");
                            dgvPerifericos.Columns.Add("Didecon", "Didecon");
                            dgvPerifericos.Columns.Add("Tipo", "Tipo");
                            dgvPerifericos.Columns.Add("Marca", "Marca");
                            dgvPerifericos.Columns.Add("Modelo", "Modelo");
                            dgvPerifericos.Columns.Add("N. Serie", "N. Serie");
                            dgvPerifericos.Columns.Add("Act. Contraloria", "Act. Contraloria");
                            dgvPerifericos.Columns.Add("Departamento", "Departamento");
                            dgvPerifericos.Columns.Add("Area", "Área");
                            dgvPerifericos.Columns.Add("Responsable", "Responsable");
                            dgvPerifericos.Columns.Add("Estatus", "Estatus");
                            while (reader.Read())
                            {
                                int index = dgvPerifericos.Rows.Add();
                                dgvPerifericos.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                dgvPerifericos.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                dgvPerifericos.Rows[index].Cells["Tipo"].Value = reader["Tipo"];
                                dgvPerifericos.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                dgvPerifericos.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                dgvPerifericos.Rows[index].Cells["N. Serie"].Value = reader["N. Serie"].ToString();
                                dgvPerifericos.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                dgvPerifericos.Rows[index].Cells["Departamento"].Value = reader["Departamento"].ToString();
                                dgvPerifericos.Rows[index].Cells["Area"].Value = reader["Area"].ToString();
                                dgvPerifericos.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                dgvPerifericos.Rows[index].Cells["Estatus"].Value = reader["Estatus"].ToString();
                            }
                        }
                    }
                }
                if (tipoFiltro == "CPU" || tipoFiltro == "CPU-2")
                {
                    dgvPerifericos.Columns["Numero"].ReadOnly = true;
                    dgvPerifericos.Columns["Didecon"].ReadOnly = true;
                    dgvPerifericos.Columns["Act. Contraloria"].ReadOnly = true;
                    dgvPerifericos.Columns["Dir. IP"].ReadOnly = true;
                    dgvPerifericos.Columns["Responsable"].ReadOnly = true;
                    dgvPerifericos.Columns["Tipo"].ReadOnly = true;
                    dgvPerifericos.Columns["Marca"].ReadOnly = true;
                    dgvPerifericos.Columns["Modelo"].ReadOnly = true;
                    dgvPerifericos.Columns["Procesador"].ReadOnly = true;
                    dgvPerifericos.Columns["Estatus"].ReadOnly = true;
                    dgvPerifericos.Columns["Numero"].DisplayIndex = 0;
                    dgvPerifericos.Columns["Didecon"].DisplayIndex = 1;
                    dgvPerifericos.Columns["Act. Contraloria"].DisplayIndex = 2;
                    dgvPerifericos.Columns["Dir. IP"].DisplayIndex = 3;
                    dgvPerifericos.Columns["Responsable"].DisplayIndex = 4;
                    dgvPerifericos.Columns["Tipo"].DisplayIndex = 5;
                    dgvPerifericos.Columns["Marca"].DisplayIndex = 6;
                    dgvPerifericos.Columns["Modelo"].DisplayIndex = 7;
                    dgvPerifericos.Columns["Procesador"].DisplayIndex = 8;
                    dgvPerifericos.Columns["Estatus"].DisplayIndex = 9;
                }
                else if (tipoFiltro == "PERIFERICOS" || tipoFiltro == "PERIFERICOS-2")
                {
                    dgvPerifericos.Columns["Numero"].ReadOnly = true;
                    dgvPerifericos.Columns["Didecon"].ReadOnly = true;
                    dgvPerifericos.Columns["Tipo"].ReadOnly = true;
                    dgvPerifericos.Columns["Marca"].ReadOnly = true;
                    dgvPerifericos.Columns["Modelo"].ReadOnly = true;
                    dgvPerifericos.Columns["N. Serie"].ReadOnly = true;
                    dgvPerifericos.Columns["Act. Contraloria"].ReadOnly = true;
                    dgvPerifericos.Columns["Departamento"].ReadOnly = true;
                    dgvPerifericos.Columns["Area"].ReadOnly = true;
                    dgvPerifericos.Columns["Responsable"].ReadOnly = true;
                    dgvPerifericos.Columns["Estatus"].ReadOnly = true;
                    dgvPerifericos.Columns["Numero"].DisplayIndex = 0;
                    dgvPerifericos.Columns["Didecon"].DisplayIndex = 1;
                    dgvPerifericos.Columns["Tipo"].DisplayIndex = 2;
                    dgvPerifericos.Columns["Marca"].DisplayIndex = 3;
                    dgvPerifericos.Columns["Modelo"].DisplayIndex = 4;
                    dgvPerifericos.Columns["N. Serie"].DisplayIndex = 5;
                    dgvPerifericos.Columns["Act. Contraloria"].DisplayIndex = 6;
                    dgvPerifericos.Columns["Departamento"].DisplayIndex = 7;
                    dgvPerifericos.Columns["Area"].DisplayIndex = 8;
                    dgvPerifericos.Columns["Responsable"].DisplayIndex = 9;
                    dgvPerifericos.Columns["Estatus"].DisplayIndex = 10;
                }
                dgvPerifericos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvPerifericos.ScrollBars = ScrollBars.Both;
                dgvPerifericos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }


        private void txtBuscarActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            // Evitar que se ingresen más de 15 dígitos
            if (!char.IsControl(e.KeyChar) && txtBox.Text.Length >= 15)
            {
                e.Handled = true;
            }

            //Permitirsolo numerosy puntos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void txtBuscarFolioCPU_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBuscarDirCPU_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt.Text == ".   " || txt.Text == "SN")
            {
                txt.ForeColor = Color.Black;
                return;
            }

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

        private void txtBuscarDirCPU_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtBuscarActivoCPU_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final
            txt.SelectionStart = txt.Text.Length;
        }

        private void txtBuscarActivoCPU_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Evitar que se ingresen más de 50 caracteres
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 50)
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

        private void txtBuscarNumero_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtBox.Text = txtBox.Text.ToUpper();

            txtBox.SelectionStart = txtBox.Text.Length;
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

        private void cargarDepartamentos()
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT dependencias.descripcion FROM dependencias;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (tipoFiltro == "CPU" || tipoFiltro == "CPU-2")
                            {
                                boxBuscarDepartmanentoCPU.Items.Add(reader["descripcion"].ToString());
                            }
                            else 
                            {
                                boxBuscarDepartamento.Items.Add(reader["descripcion"].ToString());
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

        private void cargarMarcas()
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT marcas.descripcion FROM marcas;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            boxBuscarMarca.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cargarTipos()
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT tipos.descripcion FROM tipos WHERE tipos.descripcion NOT IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE');";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            boxBuscarTipo.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void radioFolio_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFolio.Checked)
            {
                label3.Text = "NUMERO:";
                boxBuscarDepartamento.Visible = false;
                txtBuscarDidecon.Visible = false;
                txtBuscarActivo.Visible = false;
                txtBuscarNumero.Visible = false;
                txtBuscarFolio.Visible = true;
                txtBuscarFolio.Focus();
                boxBuscarDepartamento.SelectedIndex = -1;
                txtBuscarDidecon.Text = "";
                txtBuscarActivo.Text = "";
                txtBuscarNumero.Text = "";
            }
        }

        private void radioNumeroCPU_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNumeroCPU.Checked)
            {
                label3.Text = "NUMERO:";
                boxBuscarDepartmanentoCPU.Visible = false;
                txtBuscarDirCPU.Visible = false;
                txtBuscarActivoCPU.Visible = false;
                boxBuscarMarca.Visible = false;
                boxBuscarTipo.Visible = false;
                txtBuscarFolioCPU.Visible = true;
                txtBuscarFolioCPU.Focus();
                boxBuscarDepartmanentoCPU.SelectedIndex = -1;
                txtBuscarDirCPU.Text = "";
                txtBuscarActivoCPU.Text = "";
                boxBuscarMarca.SelectedItem = ".";
                boxBuscarTipo.SelectedItem = "--TODOS--"; 
            }
        }

        private void radioDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDepartamento.Checked)
            {
                label3.Text = "DEPARTAMENTO:";
                boxBuscarDepartamento.Visible = true;
                txtBuscarDidecon.Visible = false;
                txtBuscarActivo.Visible = false;
                txtBuscarNumero.Visible = false;
                txtBuscarFolio.Visible = false;
                cargarDepartamentos();
                boxBuscarDepartamento.Focus();
                txtBuscarFolio.Text = "";
                txtBuscarDidecon.Text = "";
                txtBuscarActivo.Text = "";
                txtBuscarNumero.Text = "";
            }
        }

        private void radioDepartamentoCPU_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDepartamentoCPU.Checked)
            {
                label3.Text = "DEPARTAMENTO:";
                boxBuscarDepartmanentoCPU.Visible = true;
                txtBuscarDirCPU.Visible = false;
                txtBuscarActivoCPU.Visible = false;
                boxBuscarMarca.Visible = false;
                boxBuscarTipo.Visible = false;
                txtBuscarFolioCPU.Visible = false;
                cargarDepartamentos();
                boxBuscarDepartmanentoCPU.Focus();
                txtBuscarFolioCPU.Text = "";
                txtBuscarDirCPU.Text = "";
                txtBuscarActivoCPU.Text = "";
                boxBuscarMarca.SelectedItem = ".";
                boxBuscarTipo.SelectedItem = "--TODOS--";
            }
        }

        private void radioDidecon_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDidecon.Checked)
            {
                label3.Text = "DIDECON:";
                boxBuscarDepartamento.Visible = false;
                txtBuscarDidecon.Visible = true;
                txtBuscarActivo.Visible = false;
                txtBuscarNumero.Visible = false;
                txtBuscarFolio.Visible = false;
                txtBuscarDidecon.Focus();
                txtBuscarFolio.Text = "";
                boxBuscarDepartamento.SelectedIndex = -1;
                txtBuscarActivo.Text = "";
                txtBuscarNumero.Text = "";
            }
        }

        private void radioDirIP_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDirIP.Checked)
            {
                label3.Text = "DIR IP:";
                boxBuscarDepartmanentoCPU.Visible = false;
                txtBuscarDirCPU.Visible = true;
                txtBuscarActivoCPU.Visible = false;
                boxBuscarMarca.Visible = false;
                boxBuscarTipo.Visible = false;
                txtBuscarFolioCPU.Visible = false;
                //txtBuscarDirCPU.Text = "DIR IP";
                txtBuscarDirCPU.Focus();
                txtBuscarFolioCPU.Text = "";
                boxBuscarDepartmanentoCPU.SelectedIndex = -1;
                txtBuscarActivoCPU.Text = "";
                boxBuscarMarca.SelectedItem = ".";
                boxBuscarTipo.SelectedItem = "--TODOS--";
            }
        }

        private void radioActivoCPU_CheckedChanged(object sender, EventArgs e)
        {
            if (radioActivoCPU.Checked)
            {
                label3.Text = "ACTIVO CONTRALORIA:";
                boxBuscarDepartmanentoCPU.Visible = false;
                txtBuscarDirCPU.Visible = false;
                txtBuscarActivoCPU.Visible = true;
                boxBuscarMarca.Visible = false;
                boxBuscarTipo.Visible = false;
                txtBuscarFolioCPU.Visible = false;
                //txtBuscarActivoCPU.Text = "ACTIVO CONTRALORIA";
                txtBuscarActivoCPU.Focus();
                txtBuscarFolioCPU.Text = "";
                boxBuscarDepartmanentoCPU.SelectedIndex = -1;
                txtBuscarDirCPU.Text = "";
                boxBuscarMarca.SelectedItem = ".";
                boxBuscarTipo.SelectedItem = "--TODOS--";
            }
        }

        private void radioActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioActivo.Checked)
            {
                label3.Text = "ACTIVO CONTRALORIA:";
                boxBuscarDepartamento.Visible = false;
                txtBuscarDidecon.Visible = false;
                txtBuscarActivo.Visible = true;
                txtBuscarNumero.Visible = false;
                txtBuscarFolio.Visible = false;
                txtBuscarActivo.Focus();
                txtBuscarFolio.Text = "";
                boxBuscarDepartamento.SelectedIndex = -1;
                txtBuscarDidecon.Text = "";
                txtBuscarNumero.Text = "";
            }
        }

        private void radioPerifericos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPerifericos.Checked)
            {
                label3.Text = "MARCA Y TIPO:";
                txtBuscarFolioCPU.Visible = false;
                boxBuscarDepartmanentoCPU.Visible = false;
                txtBuscarDirCPU.Visible = false;
                txtBuscarActivoCPU.Visible = false;
                boxBuscarMarca.Visible = true;
                boxBuscarTipo.Visible = true;
                cargarTipos();
                cargarMarcas();
                txtBuscarFolioCPU.Text = "";
                boxBuscarDepartmanentoCPU.SelectedIndex = -1;
                txtBuscarDirCPU.Text = "";
                txtBuscarActivoCPU.Text = "";
            }
        }

        private void radioNumSerie_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNumSerie.Checked)
            {
                label3.Text = "NUM SERIE:";
                boxBuscarDepartamento.Visible = false;
                txtBuscarDidecon.Visible = false;
                txtBuscarActivo.Visible = false;
                txtBuscarNumero.Visible = true;
                txtBuscarFolio.Visible = false;
                txtBuscarNumero.Focus();
                txtBuscarFolio.Text = "";
                boxBuscarDepartamento.SelectedIndex = -1;
                txtBuscarDidecon.Text = "";
                txtBuscarActivo.Text = "";
            }
        }

        private void configurarBoxMarca(ComboBox boxBuscarMarca)
        {
            boxBuscarMarca.Items.Clear();
            boxBuscarMarca.Items.Add(".");
            boxBuscarMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            boxBuscarMarca.SelectedIndex = 0;
        }

        private void configurarBoxTipo(ComboBox boxBuscarTipo)
        {
            boxBuscarTipo.Items.Clear();
            boxBuscarTipo.Items.Add("--TODOS--");
            boxBuscarTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxBuscarTipo.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                string queryAux = "";
                List<SqlParameter> parametros = new List<SqlParameter>();
                if (tipoFiltro == "CPU" || tipoFiltro == "CPU-2")
                {
                    query = @"SELECT hardware.folio AS Numero, 
                        hardware.didecon AS Didecon, 
                        hardware.activocontraloria AS 'Act. Contraloria', 
                        hardware.ip AS 'Dir. IP', 
                        hardware.responsable AS 'Responsable',
					    tipos.descripcion AS Tipo,
                        marcas.descripcion AS Marca, 
					    modelos.descripcion AS Modelo, 
                        hardware.procesador AS Procesador,
                        estatus.descripcion AS Estatus
                    FROM hardware 
                    JOIN tipos on tipos.id_tipo = hardware.idtipo
                    JOIN estatus ON estatus.id_estatus = hardware.idestatus
			        JOIN marcas ON marcas.id_marca = hardware.marca
				    JOIN modelos ON modelos.id_modelo = hardware.modelo
                    JOIN dependencias ON dependencias.id_dependencia = hardware.depto
                    WHERE tipos.descripcion IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')";
                    if (tipoFiltro == "CPU-2")
                    {
                        query += " AND estatus.descripcion = 'ACTIVO'";
                    }
                    queryAux = query;
                }
                else if(tipoFiltro == "PERIFERICOS" || tipoFiltro == "PERIFERICOS-2")
                {
                    query = @"SELECT perifericos.folio AS Numero, 
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
                    WHERE tipos.descripcion NOT IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')";
                    if (tipoFiltro == "PERIFERICOS-2")
                    {
                        query += " AND estatus.descripcion = 'ACTIVO'";
                    }
                }
                if (tipoFiltro == "CPU" || tipoFiltro == "CPU-2")
                {
                    if (radioNumeroCPU.Checked)
                    {
                        if (string.IsNullOrEmpty(txtBuscarFolioCPU.Text))
                        {
                            MessageBox.Show("Ingrese un número de folio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += " AND hardware.folio = @filtro";
                        parametros.Add(new SqlParameter("@filtro", txtBuscarFolioCPU.Text.Trim()));
                    }
                    else if (radioDepartamentoCPU.Checked)
                    {
                        if (boxBuscarDepartmanentoCPU.SelectedIndex == -1 || boxBuscarDepartmanentoCPU.SelectedItem == null)
                        {
                            MessageBox.Show("Ingrese un departamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += " AND dependencias.descripcion = @filtro";
                        parametros.Add(new SqlParameter("@filtro", boxBuscarDepartmanentoCPU.SelectedItem.ToString()));
                    }
                    else if (radioDirIP.Checked)
                    {
                        if (string.IsNullOrEmpty(txtBuscarDirCPU.Text))
                        {
                            MessageBox.Show("Ingrese una dir. ip.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += " AND hardware.ip = @filtro";
                        parametros.Add(new SqlParameter("@filtro", txtBuscarDirCPU.Text.Trim()));
                    }
                    else if (radioActivoCPU.Checked)
                    {
                        if (string.IsNullOrEmpty(txtBuscarActivoCPU.Text))
                        {
                            MessageBox.Show("Ingrese un Act. Contraloria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += " AND hardware.activocontraloria = @filtro";
                        parametros.Add(new SqlParameter("@filtro",txtBuscarActivoCPU.Text.Trim()));
                    }
                    else if (radioPerifericos.Checked)
                    {
                        if (boxBuscarMarca.SelectedIndex == -1 || boxBuscarMarca.SelectedItem == null ||
                            boxBuscarTipo.SelectedIndex == -1 || boxBuscarTipo.SelectedItem == null)
                        {
                            MessageBox.Show("Ingrese parámetros de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        query = @"SELECT hardware.folio AS 'Numero', 
                                    hardware.didecon AS 'Didecon', 
                                    hardware.activos AS 'Act. Sistemas', 
                                    hardware.activocontraloria AS 'Act Contraloria',
                                    hardware.responsable AS 'Responsable',
                                    m2.descripcion AS 'Marca CPU',
                                    modelos.descripcion AS 'Modelo CPU',
                                    hardware.procesador AS 'Procesador',
                                    m1.descripcion AS 'Marca Periferico',
                                    tipos.descripcion AS 'Tipo Periferico',
                                    estatus.descripcion AS 'Estatus'
                                FROM perifericos
                                JOIN marcas m1 ON m1.id_marca = perifericos.marca
                                JOIN tipos ON tipos.id_tipo = perifericos.tipo
                                JOIN hardware ON hardware.didecon = perifericos.didecon
                                JOIN marcas m2 ON m2.id_marca = hardware.marca
                                JOIN modelos ON modelos.id_modelo = hardware.modelo
                                JOIN estatus ON estatus.id_estatus = perifericos.idestatus
                                WHERE m1.descripcion = @marca";
                        if (tipoFiltro == "CPU-2")
                        {
                            query += " AND estatus.descripcion = 'ACTIVO'";
                        }
                        parametros.Add(new SqlParameter("@marca", Convert.ToString(boxBuscarMarca.SelectedItem)));

                        if (boxBuscarTipo.SelectedItem.ToString() != "--TODOS--")
                        {
                            query += " AND tipos.descripcion = @tipo";
                            parametros.Add(new SqlParameter("@tipo", Convert.ToString(boxBuscarTipo.SelectedItem)));
                        }
                        else
                        {
                            query += " AND tipos.descripcion NOT IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un campo de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    query += " ORDER BY hardware.folio ASC;";
                }
                else if(tipoFiltro == "PERIFERICOS" || tipoFiltro == "PERIFERICOS-2")
                {
                    if (radioFolio.Checked)
                    {
                        if (string.IsNullOrEmpty(txtBuscarFolio.Text))
                        {
                            MessageBox.Show("Ingrese un número de folio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += " AND perifericos.folio = @filtro";
                        parametros.Add(new SqlParameter("@filtro", txtBuscarFolio.Text.Trim()));
                    }
                    else if (radioDepartamento.Checked)
                    {
                        if (boxBuscarDepartamento.SelectedIndex == -1 || boxBuscarDepartamento.SelectedItem == null)
                        {
                            MessageBox.Show("Ingrese un departamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += " AND dependencias.descripcion = @filtro";
                        parametros.Add(new SqlParameter("@filtro", boxBuscarDepartamento.SelectedItem.ToString()));
                    }
                    else if (radioDidecon.Checked)
                    {
                        if (string.IsNullOrEmpty(txtBuscarDidecon.Text))
                        {
                            MessageBox.Show("Ingrese un Didecon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += " AND hardware.didecon = @filtro";
                        parametros.Add(new SqlParameter("@filtro", txtBuscarDidecon.Text.Trim()));
                    }
                    else if (radioActivo.Checked)
                    {
                        if (string.IsNullOrEmpty(txtBuscarActivo.Text))
                        {
                            MessageBox.Show("Ingrese un Act. Contraloria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += " AND perifericos.activocontraloria = @filtro";
                        parametros.Add(new SqlParameter("@filtro", txtBuscarActivo.Text.Trim()));
                    }
                    else if (radioNumSerie.Checked)
                    {
                        if (string.IsNullOrEmpty(txtBuscarNumero.Text))
                        {
                            MessageBox.Show("Ingrese un Num Serie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        query += " AND perifericos.sn = @filtro";
                        parametros.Add(new SqlParameter("@filtro", txtBuscarNumero.Text.Trim()));
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un campo de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                 
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        foreach (var parametro in parametros)
                        {
                            cmd.Parameters.Add(parametro);
                        }
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvPerifericos.Rows.Clear();
                            dgvPerifericos.Columns.Clear();
                            if (tipoFiltro == "CPU" || tipoFiltro == "CPU-2")
                            {
                                if (radioPerifericos.Checked)
                                {
                                    dgvPerifericos.Columns.Add("Numero", "Número");
                                    dgvPerifericos.Columns.Add("Didecon", "Didecon");
                                    dgvPerifericos.Columns.Add("Act. Sistemas", "Act. Sistemas");
                                    dgvPerifericos.Columns.Add("Act. Contraloria", "Act. Contraloria");
                                    dgvPerifericos.Columns.Add("Responsable", "Responsable");
                                    dgvPerifericos.Columns.Add("Marca CPU", "Marca CPU");
                                    dgvPerifericos.Columns.Add("Modelo CPU", "Modelo CPU");
                                    dgvPerifericos.Columns.Add("Procesador", "Procesador");
                                    dgvPerifericos.Columns.Add("Marca Periferico", "Marca Periferico");
                                    dgvPerifericos.Columns.Add("Tipo Periferico", "Tipo Periferico");
                                    dgvPerifericos.Columns.Add("Estatus", "Estatus");
                                    while (reader.Read())
                                    {
                                        int index = dgvPerifericos.Rows.Add();
                                        dgvPerifericos.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Act. Sistemas"].Value = reader["Act. Sistemas"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Act. Contraloria"].Value = reader["Act Contraloria"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Marca CPU"].Value = reader["Marca CPU"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Modelo CPU"].Value = reader["Modelo CPU"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Procesador"].Value = reader["Procesador"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Marca Periferico"].Value = reader["Marca Periferico"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Tipo Periferico"].Value = reader["Tipo Periferico"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Estatus"].Value = reader["Estatus"].ToString();
                                    }

                                }
                                else
                                {
                                    dgvPerifericos.Columns.Add("Numero", "Número");
                                    dgvPerifericos.Columns.Add("Didecon", "Didecon");
                                    dgvPerifericos.Columns.Add("Act. Contraloria", "Act. Contraloria");
                                    dgvPerifericos.Columns.Add("Dir. IP", "Dir. IP");
                                    dgvPerifericos.Columns.Add("Responsable", "Responsable");
                                    dgvPerifericos.Columns.Add("Tipo", "Tipo");
                                    dgvPerifericos.Columns.Add("Marca", "Marca");
                                    dgvPerifericos.Columns.Add("Modelo", "Modelo");
                                    dgvPerifericos.Columns.Add("Procesador", "Procesador");
                                    dgvPerifericos.Columns.Add("Estatus", "Estatus");
                                    while (reader.Read())
                                    {
                                        int index = dgvPerifericos.Rows.Add();
                                        dgvPerifericos.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Dir. IP"].Value = reader["Dir. IP"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Tipo"].Value = reader["Tipo"];
                                        dgvPerifericos.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Procesador"].Value = reader["Procesador"].ToString();
                                        dgvPerifericos.Rows[index].Cells["Estatus"].Value = reader["Estatus"].ToString();
                                    }
                                }
                            }
                            else if(tipoFiltro == "PERIFERICOS" || tipoFiltro == "PERIFERICOS-2")
                            {
                                dgvPerifericos.Columns.Add("Numero", "Número");
                                dgvPerifericos.Columns.Add("Didecon", "Didecon");
                                dgvPerifericos.Columns.Add("Marca", "Marca");
                                dgvPerifericos.Columns.Add("Modelo", "Modelo");
                                dgvPerifericos.Columns.Add("N. Serie", "N. Serie");
                                dgvPerifericos.Columns.Add("Act. Contraloria", "Act. Contraloria");
                                dgvPerifericos.Columns.Add("Departamento", "Departamento");
                                dgvPerifericos.Columns.Add("Area", "Área");
                                dgvPerifericos.Columns.Add("Responsable", "Responsable");
                                dgvPerifericos.Columns.Add("Estatus", "Estatus");
                                dgvPerifericos.Columns.Add("Tipo", "Tipo");
                                while (reader.Read())
                                {
                                    int index = dgvPerifericos.Rows.Add();
                                    dgvPerifericos.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                    dgvPerifericos.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                    dgvPerifericos.Rows[index].Cells["Tipo"].Value = reader["Tipo"];
                                    dgvPerifericos.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                    dgvPerifericos.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                    dgvPerifericos.Rows[index].Cells["N. Serie"].Value = reader["N. Serie"].ToString();
                                    dgvPerifericos.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                    dgvPerifericos.Rows[index].Cells["Departamento"].Value = reader["Departamento"].ToString();
                                    dgvPerifericos.Rows[index].Cells["Area"].Value = reader["Area"].ToString();
                                    dgvPerifericos.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                    dgvPerifericos.Rows[index].Cells["Estatus"].Value = reader["Estatus"];
                                }
                            }
                        }
                    }
                }
                query = queryAux;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPerifericos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una periferico para eliminar.");
                return;
            }
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar lo(s) perifericos(s) seleccionado(s)?",
                                                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes) return;
            foreach (DataGridViewRow row in dgvPerifericos.SelectedRows)
            {
                if (row.Cells["Numero"].Value == null) continue;
                int idPeriferico = Convert.ToInt32(row.Cells["Numero"].Value);
                try
                {
                    string query = "DELETE from perifericos WHERE perifericos.folio = @idPeriferico;";
                    using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                    {
                        conexion.Open();
                        using (SqlCommand queryDelete = new SqlCommand(query, conexion))
                        {
                            queryDelete.Parameters.AddWithValue("@idPeriferico", idPeriferico);
                            queryDelete.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el periferico: " + ex.Message);
                }
                MessageBox.Show("Registro eliminado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvPerifericos.SelectedRows.Count != 1)
            {
                MessageBox.Show("Seleccione un unico registro");
                return;
            }
            FolioSeleccionado = dgvPerifericos.SelectedRows[0].Cells["Numero"].Value.ToString();
            if (!string.IsNullOrEmpty(FolioSeleccionado))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo obtener el folio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
