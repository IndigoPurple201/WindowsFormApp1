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
    public partial class BuscarServicios: Form
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
        public string FolioSeleccionado { get; private set; }
        public string TipoSeleccionado { get; private set; }
        [DllImport("user32.dll")]
        private static extern void MessageBeep(uint uType);
        private const uint MB_ICONERROR = 0x10; // Sonido de error del sistema
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private ConexionSQL conexionSQL;
        public BuscarServicios()
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);
            this.MouseDown += new MouseEventHandler(BuscarServicios_MouseDown);
        }
        private void BuscarServicios_Load(object sender, EventArgs e)
        {
            conexionSQL.ProbarConexion();
            LlenarBoxDepartamento();
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }
            this.Click += QuitarFoco;
            radioCpu.Checked = true;
            radioPeriferico.Checked = false;
            ConfigurarDataGridView();
            CargarDatosDGV();
        }

        private void BuscarServicios_MouseDown(object sender, MouseEventArgs e)
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
                        while(reader.Read())
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

        private void ConfigurarDataGridView()
        {
            dgvServicios.BackgroundColor = Color.White;
            dgvServicios.BorderStyle = BorderStyle.None;
            dgvServicios.AllowUserToAddRows = false;
            dgvServicios.RowHeadersVisible = false;

            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvServicios.RowTemplate.Height = 20;

            dgvServicios.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvServicios.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvServicios.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvServicios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvServicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvServicios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvServicios.ColumnHeadersHeight = 35; // Aumenta la altura del encabezado
            dgvServicios.EnableHeadersVisualStyles = false;
            dgvServicios.AllowUserToResizeRows = false;
            dgvServicios.AllowUserToResizeColumns = false;

            if (radioCpu.Checked == true)
            {
                if (dgvServicios.Columns.Count == 0)
                {
                    dgvServicios.Columns.Add("Numero", "Número");
                    dgvServicios.Columns.Add("Didecon", "Didecon");
                    dgvServicios.Columns.Add("Act. Contraloria", "Act. Contraloria");
                    dgvServicios.Columns.Add("Dir. IP", "Dir. IP");
                    dgvServicios.Columns.Add("Responsable", "Responsable");
                    dgvServicios.Columns.Add("Tipo", "Tipo");
                    dgvServicios.Columns.Add("Marca", "Marca");
                    dgvServicios.Columns.Add("Modelo", "Modelo");
                    dgvServicios.Columns.Add("Procesador", "Procesador");
                    dgvServicios.Columns.Add("Estatus", "Estatus");
                }
            }
            else if (radioPeriferico.Checked == true)
            {
                if (dgvServicios.Columns.Count == 0)
                {
                    dgvServicios.Columns.Add("Numero", "Número");
                    dgvServicios.Columns.Add("Didecon", "Didecon");
                    dgvServicios.Columns.Add("Tipo", "Tipo");
                    dgvServicios.Columns.Add("Marca", "Marca");
                    dgvServicios.Columns.Add("Modelo", "Modelo");
                    dgvServicios.Columns.Add("N. Serie", "N. Serie");
                    dgvServicios.Columns.Add("Act. Contraloria", "Act. Contraloria");
                    dgvServicios.Columns.Add("Departamento", "Departamento");
                    dgvServicios.Columns.Add("Area", "Area");
                    dgvServicios.Columns.Add("Responsable", "Responsable");
                    dgvServicios.Columns.Add("Estatus", "Estatus");
                }
            }
            foreach (DataGridViewColumn column in dgvServicios.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void CargarDatosDGV()
        {
            try
            {
                string query = "";
                if (radioCpu.Checked == true)
                {
                    query = @"SELECT 
                                hardware.folio AS Numero, 
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
                            JOIN tipos ON tipos.id_tipo = hardware.idtipo
                            JOIN marcas ON marcas.id_marca = hardware.marca
                            JOIN modelos ON modelos.id_modelo = hardware.modelo
                            JOIN servicios ON hardware.didecon = servicios.didecon
                            JOIN estatus ON estatus.id_estatus = servicios.estatus
                            WHERE tipos.descripcion IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')
                            AND estatus.descripcion IN ('RECIBIDO','REPARACION','EXTERNO','REFACCION')
                            ORDER BY hardware.folio ASC;";
                }
                else if (radioPeriferico.Checked == true)
                {
                    query = @"SELECT 
                            perifericos.folio AS Numero, 
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
                        JOIN servicios ON hardware.didecon = servicios.didecon
                        JOIN estatus ON estatus.id_estatus = servicios.estatus
                        WHERE tipos.descripcion NOT IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')
                        AND estatus.descripcion IN ('RECIBIDO','REPARACION','EXTERNO','REFACCION')
                        ORDER BY perifericos.folio ASC;";
                }
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvServicios.Rows.Clear();
                        dgvServicios.Columns.Clear();
                        if (radioCpu.Checked == true)
                        {
                            dgvServicios.Columns.Add("Numero", "Número");
                            dgvServicios.Columns.Add("Didecon", "Didecon");
                            dgvServicios.Columns.Add("Act. Contraloria", "Act. Contraloria");
                            dgvServicios.Columns.Add("Dir. IP", "Dir. IP");
                            dgvServicios.Columns.Add("Responsable", "Responsable");
                            dgvServicios.Columns.Add("Tipo", "Tipo");
                            dgvServicios.Columns.Add("Marca", "Marca");
                            dgvServicios.Columns.Add("Modelo", "Modelo");
                            dgvServicios.Columns.Add("Procesador", "Procesador");
                            dgvServicios.Columns.Add("Estatus", "Estatus");
                            while (reader.Read())
                            {
                                int index = dgvServicios.Rows.Add();
                                dgvServicios.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                dgvServicios.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                dgvServicios.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                dgvServicios.Rows[index].Cells["Dir. IP"].Value = reader["Dir. IP"].ToString();
                                dgvServicios.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                dgvServicios.Rows[index].Cells["Tipo"].Value = reader["Tipo"];
                                dgvServicios.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                dgvServicios.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                dgvServicios.Rows[index].Cells["Procesador"].Value = reader["Procesador"].ToString();
                                dgvServicios.Rows[index].Cells["Estatus"].Value = reader["Estatus"].ToString();
                            }
                        }
                        else if (radioPeriferico.Checked == true)
                        {
                            dgvServicios.Columns.Add("Numero", "Número");
                            dgvServicios.Columns.Add("Didecon", "Didecon");
                            dgvServicios.Columns.Add("Tipo", "Tipo");
                            dgvServicios.Columns.Add("Marca", "Marca");
                            dgvServicios.Columns.Add("Modelo", "Modelo");
                            dgvServicios.Columns.Add("N. Serie", "N. Serie");
                            dgvServicios.Columns.Add("Act. Contraloria", "Act. Contraloria");
                            dgvServicios.Columns.Add("Departamento", "Departamento");
                            dgvServicios.Columns.Add("Area", "Área");
                            dgvServicios.Columns.Add("Responsable", "Responsable");
                            dgvServicios.Columns.Add("Estatus", "Estatus");
                            while (reader.Read())
                            {
                                int index = dgvServicios.Rows.Add();
                                dgvServicios.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                dgvServicios.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                dgvServicios.Rows[index].Cells["Tipo"].Value = reader["Tipo"];
                                dgvServicios.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                dgvServicios.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                dgvServicios.Rows[index].Cells["N. Serie"].Value = reader["N. Serie"].ToString();
                                dgvServicios.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                dgvServicios.Rows[index].Cells["Departamento"].Value = reader["Departamento"].ToString();
                                dgvServicios.Rows[index].Cells["Area"].Value = reader["Area"].ToString();
                                dgvServicios.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                dgvServicios.Rows[index].Cells["Estatus"].Value = reader["Estatus"].ToString();
                            }
                        }
                    }
                }
                if (radioCpu.Checked == true)
                {
                    dgvServicios.Columns["Numero"].ReadOnly = true;
                    dgvServicios.Columns["Didecon"].ReadOnly = true;
                    dgvServicios.Columns["Act. Contraloria"].ReadOnly = true;
                    dgvServicios.Columns["Dir. IP"].ReadOnly = true;
                    dgvServicios.Columns["Responsable"].ReadOnly = true;
                    dgvServicios.Columns["Tipo"].ReadOnly = true;
                    dgvServicios.Columns["Marca"].ReadOnly = true;
                    dgvServicios.Columns["Modelo"].ReadOnly = true;
                    dgvServicios.Columns["Procesador"].ReadOnly = true;
                    dgvServicios.Columns["Estatus"].ReadOnly = true;
                    dgvServicios.Columns["Numero"].DisplayIndex = 0;
                    dgvServicios.Columns["Didecon"].DisplayIndex = 1;
                    dgvServicios.Columns["Act. Contraloria"].DisplayIndex = 2;
                    dgvServicios.Columns["Dir. IP"].DisplayIndex = 3;
                    dgvServicios.Columns["Responsable"].DisplayIndex = 4;
                    dgvServicios.Columns["Tipo"].DisplayIndex = 5;
                    dgvServicios.Columns["Marca"].DisplayIndex = 6;
                    dgvServicios.Columns["Modelo"].DisplayIndex = 7;
                    dgvServicios.Columns["Procesador"].DisplayIndex = 8;
                    dgvServicios.Columns["Estatus"].DisplayIndex = 9;
                }
                else if (radioPeriferico.Checked == true)
                {
                    dgvServicios.Columns["Numero"].ReadOnly = true;
                    dgvServicios.Columns["Didecon"].ReadOnly = true;
                    dgvServicios.Columns["Tipo"].ReadOnly = true;
                    dgvServicios.Columns["Marca"].ReadOnly = true;
                    dgvServicios.Columns["Modelo"].ReadOnly = true;
                    dgvServicios.Columns["N. Serie"].ReadOnly = true;
                    dgvServicios.Columns["Act. Contraloria"].ReadOnly = true;
                    dgvServicios.Columns["Departamento"].ReadOnly = true;
                    dgvServicios.Columns["Area"].ReadOnly = true;
                    dgvServicios.Columns["Responsable"].ReadOnly = true;
                    dgvServicios.Columns["Estatus"].ReadOnly = true;
                    dgvServicios.Columns["Numero"].DisplayIndex = 0;
                    dgvServicios.Columns["Didecon"].DisplayIndex = 1;
                    dgvServicios.Columns["Tipo"].DisplayIndex = 2;
                    dgvServicios.Columns["Marca"].DisplayIndex = 3;
                    dgvServicios.Columns["Modelo"].DisplayIndex = 4;
                    dgvServicios.Columns["N. Serie"].DisplayIndex = 5;
                    dgvServicios.Columns["Act. Contraloria"].DisplayIndex = 6;
                    dgvServicios.Columns["Departamento"].DisplayIndex = 7;
                    dgvServicios.Columns["Area"].DisplayIndex = 8;
                    dgvServicios.Columns["Responsable"].DisplayIndex = 9;
                    dgvServicios.Columns["Estatus"].DisplayIndex = 10;
                }
                dgvServicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvServicios.ScrollBars = ScrollBars.Both;
                dgvServicios.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void radioCpu_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatosDGV();
            if (boxDepartamento.SelectedIndex != 1)
            {
                boxDepartamento.SelectedIndex = -1;
            }
        }

        private void radioPeriferico_CheckedChanged(object sender, EventArgs e)
        {
            CargarDatosDGV();
            if (boxDepartamento.SelectedIndex != 1)
            {
                boxDepartamento.SelectedIndex = -1;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                {
                    conexion.Open();
                    if (radioCpu.Checked == true)
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
                        WHERE tipos.descripcion IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')
                        AND estatus.descripcion = 'RECIBIDO'";
                    }
                    else if (radioPeriferico.Checked == true)
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
                        WHERE tipos.descripcion NOT IN ('CPU','SERVIDOR','LAPTOP','ALL IN ONE')
                        AND estatus.descripcion = 'RECIBIDO'";
                    }
                    if (boxDepartamento.SelectedIndex == -1 || boxDepartamento.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor selecciona un departamento.");
                        return;
                    }
                    query += " AND dependencias.descripcion = @departamento";
                    using (SqlCommand cmd = new SqlCommand(query,conexion))
                    {
                        cmd.Parameters.AddWithValue("@departamento", boxDepartamento.SelectedItem.ToString());
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvServicios.Rows.Clear();
                            dgvServicios.Columns.Clear();
                            if (radioCpu.Checked == true)
                            {
                                dgvServicios.Columns.Add("Numero", "Número");
                                dgvServicios.Columns.Add("Didecon", "Didecon");
                                dgvServicios.Columns.Add("Act. Contraloria", "Act. Contraloria");
                                dgvServicios.Columns.Add("Dir. IP", "Dir. IP");
                                dgvServicios.Columns.Add("Responsable", "Responsable");
                                dgvServicios.Columns.Add("Tipo", "Tipo");
                                dgvServicios.Columns.Add("Marca", "Marca");
                                dgvServicios.Columns.Add("Modelo", "Modelo");
                                dgvServicios.Columns.Add("Procesador", "Procesador");
                                dgvServicios.Columns.Add("Estatus", "Estatus");
                                while (reader.Read())
                                {
                                    int index = dgvServicios.Rows.Add();
                                    dgvServicios.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                    dgvServicios.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                    dgvServicios.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                    dgvServicios.Rows[index].Cells["Dir. IP"].Value = reader["Dir. IP"].ToString();
                                    dgvServicios.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                    dgvServicios.Rows[index].Cells["Tipo"].Value = reader["Tipo"];
                                    dgvServicios.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                    dgvServicios.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                    dgvServicios.Rows[index].Cells["Procesador"].Value = reader["Procesador"].ToString();
                                    dgvServicios.Rows[index].Cells["Estatus"].Value = reader["Estatus"].ToString();
                                }
                            }
                            else if(radioPeriferico.Checked == true) 
                            {
                                dgvServicios.Columns.Add("Numero", "Número");
                                dgvServicios.Columns.Add("Didecon", "Didecon");
                                dgvServicios.Columns.Add("Tipo", "Tipo");
                                dgvServicios.Columns.Add("Marca", "Marca");
                                dgvServicios.Columns.Add("Modelo", "Modelo");
                                dgvServicios.Columns.Add("N. Serie", "N. Serie");
                                dgvServicios.Columns.Add("Act. Contraloria", "Act. Contraloria");
                                dgvServicios.Columns.Add("Departamento", "Departamento");
                                dgvServicios.Columns.Add("Area", "Área");
                                dgvServicios.Columns.Add("Responsable", "Responsable");
                                dgvServicios.Columns.Add("Estatus", "Estatus");
                                while (reader.Read())
                                {
                                    int index = dgvServicios.Rows.Add();
                                    dgvServicios.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                    dgvServicios.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                    dgvServicios.Rows[index].Cells["Tipo"].Value = reader["Tipo"];
                                    dgvServicios.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                    dgvServicios.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                    dgvServicios.Rows[index].Cells["N. Serie"].Value = reader["N. Serie"].ToString();
                                    dgvServicios.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                    dgvServicios.Rows[index].Cells["Departamento"].Value = reader["Departamento"].ToString();
                                    dgvServicios.Rows[index].Cells["Area"].Value = reader["Area"].ToString();
                                    dgvServicios.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                                    dgvServicios.Rows[index].Cells["Estatus"].Value = reader["Estatus"].ToString();
                                }
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

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvServicios.SelectedRows.Count != 1)
            {
                MessageBox.Show("Por favor selecciona un servicio.");
                return;
            }
            FolioSeleccionado = dgvServicios.SelectedRows[0].Cells["Numero"].Value.ToString();
            if (radioCpu.Checked == true)
            {
                TipoSeleccionado = "CPU";
            }
            else if (radioPeriferico.Checked == true)
            {
                TipoSeleccionado = "PERIFERICO";
            }
            if (!string.IsNullOrEmpty(FolioSeleccionado))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else 
            {
                MessageBox.Show("No se pudo obtener el folio..");
            }
        }
    }
}
