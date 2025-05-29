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
    public partial class BuscarCompras : Form
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
        public string ServicioSeleccionado { get; private set; }

        [DllImport("user32.dll")]
        private static extern void MessageBeep(uint uType);
        private const uint MB_ICONERROR = 0x10; // Sonido de error del sistema
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private ConexionSQL conexionSQL;
        private string tipoFiltro = "";
        public BuscarCompras(string tipo)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);
            this.MouseDown += new MouseEventHandler(BuscarCompras_MouseDown);
            tipoFiltro = tipo;
        }

        private void BuscarCompras_Load(object sender, EventArgs e)
        {
            conexionSQL = new ConexionSQL();
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }
            this.Click += QuitarFoco;
            ConfigurarDataGridView();
            CargarDatosDGV();
        }

        private void BuscarCompras_MouseDown(object sender, MouseEventArgs e)
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
            dgvBuscarCompras.BackgroundColor = Color.White;
            dgvBuscarCompras.BorderStyle = BorderStyle.None;
            dgvBuscarCompras.AllowUserToAddRows = false;
            dgvBuscarCompras.RowHeadersVisible = false;
            dgvBuscarCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBuscarCompras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvBuscarCompras.RowTemplate.Height = 20;
            dgvBuscarCompras.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvBuscarCompras.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvBuscarCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvBuscarCompras.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvBuscarCompras.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvBuscarCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBuscarCompras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBuscarCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBuscarCompras.ColumnHeadersHeight = 35; // Aumenta la altura del encabezado
            dgvBuscarCompras.EnableHeadersVisualStyles = false;
            dgvBuscarCompras.AllowUserToResizeRows = false;
            dgvBuscarCompras.AllowUserToResizeColumns = false;
            if (tipoFiltro == "ORDEN")
            {
                if (dgvBuscarCompras.Columns.Count == 0)
                {
                    dgvBuscarCompras.Columns.Add("Orden Compra", "Orden Compra");
                    dgvBuscarCompras.Columns.Add("Folio", "Folio");
                    dgvBuscarCompras.Columns.Add("Proveedor", "Proveedor");
                    dgvBuscarCompras.Columns.Add("Departamento", "Departamento");
                    dgvBuscarCompras.Columns.Add("Entrega", "Entrega");
                    dgvBuscarCompras.Columns.Add("Recibe", "Recibe");
                }
            }
            else if(tipoFiltro == "DETALLES")
            { 
                dgvBuscarCompras.Columns.Add("Numero", "Numero");
                dgvBuscarCompras.Columns.Add("Orden Compra", "Orden Compra");
                dgvBuscarCompras.Columns.Add("Descripcion", "Descripcion");
                dgvBuscarCompras.Columns.Add("Cantidad", "Cantidad");
                dgvBuscarCompras.Columns.Add("Medida", "Medida");
                dgvBuscarCompras.Columns.Add("Precio", "Precio");
                dgvBuscarCompras.Columns.Add("Total", "Total");
            }
            dgvBuscarCompras.ReadOnly = true;
            foreach (DataGridViewColumn column in dgvBuscarCompras.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void CargarDatosDGV()
        {
            string query = "";
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    if (tipoFiltro == "ORDEN")
                    {
                        query = @"
                        SELECT idOrdenCompra AS 'Orden Compra', 
                            FolioCompras AS Folio, 
                            Proveedor_Compra.Descripcion AS Proveedor, 
                            dependencias.descripcion AS Departamento, 
                            fecha AS Fecha, entrega AS Entrega, 
                            recibe AS Recibe 
                        FROM OrdenCompra
                        JOIN Proveedor_Compra ON OrdenCompra.idProveedor = Proveedor_Compra.idProveedor
                        JOIN dependencias ON OrdenCompra.iddepto = dependencias.id_dependencia
                        ORDER BY idOrdenCompra ASC
                        ;";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvBuscarCompras.Rows.Clear();
                            while (reader.Read())
                            {
                                int row = dgvBuscarCompras.Rows.Add();
                                dgvBuscarCompras.Rows[row].Cells["Orden Compra"].Value = reader["Orden Compra"];
                                dgvBuscarCompras.Rows[row].Cells["Folio"].Value = reader["Folio"];
                                dgvBuscarCompras.Rows[row].Cells["Proveedor"].Value = reader["Proveedor"];
                                dgvBuscarCompras.Rows[row].Cells["Departamento"].Value = reader["Departamento"];
                                dgvBuscarCompras.Rows[row].Cells["Entrega"].Value = reader["Entrega"];
                                dgvBuscarCompras.Rows[row].Cells["Recibe"].Value = reader["Recibe"];
                            }
                        }
                    }
                    else if (tipoFiltro == "DETALLES")
                    {
                        query = @"
                        SELECT idDetalle AS Numero, 
                            idOrdenCompra AS 'Orden Compra', 
                            Descripcion, cantidad AS Cantidad, 
                            medida AS Medida, 
                            precio AS Precio, 
                            total AS Total 
                        FROM DetalleCompra
                        ORDER BY idDetalle ASC
                        ;";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvBuscarCompras.Rows.Clear();
                            while (reader.Read())
                            {
                                int row = dgvBuscarCompras.Rows.Add();
                                dgvBuscarCompras.Rows[row].Cells["Numero"].Value = reader["Numero"];
                                dgvBuscarCompras.Rows[row].Cells["Orden Compra"].Value = reader["Orden Compra"];
                                dgvBuscarCompras.Rows[row].Cells["Descripcion"].Value = reader["Descripcion"];
                                dgvBuscarCompras.Rows[row].Cells["Cantidad"].Value = reader["Cantidad"];
                                dgvBuscarCompras.Rows[row].Cells["Medida"].Value = reader["Medida"];
                                dgvBuscarCompras.Rows[row].Cells["Precio"].Value = reader["Precio"];
                                dgvBuscarCompras.Rows[row].Cells["Total"].Value = reader["Total"];
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvBuscarCompras.SelectedRows.Count != 1)
            {
                MessageBox.Show("Por favor, seleccione una fila.");
                return;
            }

            if (tipoFiltro == "ORDEN")
            {
                ServicioSeleccionado = dgvBuscarCompras.SelectedRows[0].Cells["Orden Compra"].Value.ToString();
            }
            else if (tipoFiltro == "DETALLES")
            {
                ServicioSeleccionado = dgvBuscarCompras.SelectedRows[0].Cells["NUMERO"].Value.ToString();
            }

            if (!string.IsNullOrEmpty(ServicioSeleccionado))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo obtener el folio.");
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
            parpadeoActivo = true;
            parpadeoContador = 0;

            if (parpadeoTimer == null)
            {
                parpadeoTimer = new System.Windows.Forms.Timer();
                parpadeoTimer.Interval = 150;
                parpadeoTimer.Tick += (sender, e) =>
                {
                    if (parpadeoContador >= 6)
                    {
                        parpadeoTimer.Stop();
                        bordeOriginal = Color.Black;
                        this.Invalidate(); 
                        parpadeoActivo = false;
                    }
                    else
                    {
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
    }
}
