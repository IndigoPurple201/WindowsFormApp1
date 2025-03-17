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

        [DllImport("user32.dll")]
        private static extern void MessageBeep(uint uType);
        private const uint MB_ICONERROR = 0x10; // Sonido de error del sistema

        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private ConexionSQL conexionSQL = new ConexionSQL();
        public BuscarPerifericos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);

            this.MouseDown += new MouseEventHandler(BuscarPerifericos_MouseDown);
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
            CargarDatosDGV();
            label3.Text = "NUMERO:";
            boxBuscarDepartamento.Visible = false;
            txtBuscarDidecon.Visible = false;
            txtBuscarActivo.Visible = false;
            txtBuscarNumero.Visible = false;
            txtBuscarFolio.Visible = true;
            txtBuscarFolio.Focus();
            //ConfigurarBoxBuscarActivo(boxBuscarActivo);
            //ConfigurarBuscarNumSerie(boxBuscarNumSerie);
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
            dgvPerifericos.ColumnHeadersHeight = 35; // Aumenta la altura del encabezado
            dgvPerifericos.EnableHeadersVisualStyles = false;

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
            }
        }

        private void CargarDatosDGV()
        {
            try
            {
                string query = "SELECT perifericos.folio AS Numero, perifericos.didecon AS Didecon, tipos.descripcion AS Tipo, marcas.descripcion AS Marca, modelos.descripcion AS Modelo, perifericos.sn AS 'N. Serie', perifericos.activocontraloria AS 'Act. Contraloria', dependencias.descripcion AS Departamento, hardware.area AS Area, hardware.responsable AS Responsable FROM perifericos JOIN tipos ON tipos.id_tipo = perifericos.tipo JOIN marcas ON marcas.id_marca = perifericos.marca JOIN modelos ON modelos.id_modelo = perifericos.modelo JOIN hardware ON hardware.didecon = perifericos.didecon JOIN dependencias ON dependencias.id_dependencia = hardware.depto WHERE tipos.descripcion != 'CPU';";
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvPerifericos.Rows.Clear();
                        while (reader.Read())
                        {
                            int index = dgvPerifericos.Rows.Add();
                            dgvPerifericos.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                            dgvPerifericos.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                            dgvPerifericos.Rows[index].Cells["Tipo"].Value = reader["Tipo"].ToString();
                            dgvPerifericos.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                            dgvPerifericos.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                            dgvPerifericos.Rows[index].Cells["N. Serie"].Value = reader["N. Serie"].ToString();
                            dgvPerifericos.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                            dgvPerifericos.Rows[index].Cells["Departamento"].Value = reader["Departamento"].ToString();
                            dgvPerifericos.Rows[index].Cells["Area"].Value = reader["Area"].ToString();
                            dgvPerifericos.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();
                        }
                    }
                }
                dgvPerifericos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvPerifericos.ScrollBars = ScrollBars.Both;
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
                            boxBuscarDepartamento.Items.Add(reader["descripcion"].ToString());
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
            }
        }

        private void radioActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioActivo.Checked)
            {
                label3.Text = "ACT CONTRALORIA:";
                boxBuscarDepartamento.Visible = false;
                txtBuscarDidecon.Visible = false;
                txtBuscarActivo.Visible = true;
                txtBuscarNumero.Visible = false;
                txtBuscarFolio.Visible = false;
                txtBuscarActivo.Focus();    
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
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = "SELECT perifericos.folio AS Numero, perifericos.didecon AS Didecon, tipos.descripcion AS Tipo, marcas.descripcion AS Marca, modelos.descripcion AS Modelo, perifericos.sn AS 'N. Serie', perifericos.activocontraloria AS 'Act. Contraloria', dependencias.descripcion AS Departamento, hardware.area AS Area, hardware.responsable AS Responsable FROM perifericos JOIN tipos ON tipos.id_tipo = perifericos.tipo JOIN marcas ON marcas.id_marca = perifericos.marca JOIN modelos ON modelos.id_modelo = perifericos.modelo JOIN hardware ON hardware.didecon = perifericos.didecon JOIN dependencias ON dependencias.id_dependencia = hardware.depto WHERE tipos.descripcion != 'CPU'";
            string filtro = "";
            if (radioFolio.Checked)
            {
                if (string.IsNullOrEmpty(txtBuscarFolio.Text))
                {
                    MessageBox.Show("Ingrese un número de folio válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                filtro = txtBuscarFolio.Text.Trim();
                query += " AND perifericos.folio = @folio";
            }
            else if (radioDepartamento.Checked)
            {
                if (boxBuscarDepartamento.SelectedIndex == -1 || boxBuscarDepartamento.SelectedItem == null)
                {
                    MessageBox.Show("Ingrese un departamento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                filtro = boxBuscarDepartamento.SelectedItem.ToString().Trim();
                query += " AND dependencias.descripcion = @departamento";
            }
            else if (radioDidecon.Checked)
            {
                if (string.IsNullOrEmpty(txtBuscarDidecon.Text))
                {
                    MessageBox.Show("Ingrese un Didecon.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                filtro = txtBuscarDidecon.Text.Trim();
                query += " AND hardware.didecon = @didecon";
            }
            else if (radioActivo.Checked)
            {
                if (string.IsNullOrEmpty(txtBuscarActivo.Text))
                {
                    MessageBox.Show("Ingrese un Act. Contraloria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                filtro = txtBuscarActivo.Text.Trim();
                query += " AND perifericos.activocontraloria = @activo";
            }
            else if (radioNumSerie.Checked)
            {
                if (string.IsNullOrEmpty(txtBuscarNumero.Text))
                {
                    MessageBox.Show("Ingrese un Num Serie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                filtro = txtBuscarNumero.Text.Trim();
                query += " AND perifericos.sn = @serial";
            }

            if (string.IsNullOrEmpty(filtro))
            {
                MessageBox.Show("Seleccione un campo de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (radioFolio.Checked)
                        {
                            cmd.Parameters.AddWithValue("@folio", filtro.Trim());
                        }
                        else if (radioDepartamento.Checked)
                        {
                            cmd.Parameters.AddWithValue("@departamento", filtro.Trim());
                        }
                        else if (radioDidecon.Checked)
                        {
                            cmd.Parameters.AddWithValue("@didecon", filtro.Trim());
                        }
                        else if (radioActivo.Checked)
                        {
                            cmd.Parameters.AddWithValue("@activo", filtro.Trim());
                        }
                        else if (radioNumSerie.Checked)
                        {
                            cmd.Parameters.AddWithValue("@serial", filtro);
                        }
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvPerifericos.Rows.Clear();
                            while (reader.Read())
                            {
                                int index = dgvPerifericos.Rows.Add();
                                dgvPerifericos.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                                dgvPerifericos.Rows[index].Cells["Didecon"].Value = reader["Didecon"].ToString();
                                dgvPerifericos.Rows[index].Cells["Tipo"].Value = reader["Tipo"].ToString();
                                dgvPerifericos.Rows[index].Cells["Marca"].Value = reader["Marca"].ToString();
                                dgvPerifericos.Rows[index].Cells["Modelo"].Value = reader["Modelo"].ToString();
                                dgvPerifericos.Rows[index].Cells["N. Serie"].Value = reader["N. Serie"].ToString();
                                dgvPerifericos.Rows[index].Cells["Act. Contraloria"].Value = reader["Act. Contraloria"].ToString();
                                dgvPerifericos.Rows[index].Cells["Departamento"].Value = reader["Departamento"].ToString();
                                dgvPerifericos.Rows[index].Cells["Area"].Value = reader["Area"].ToString();
                                dgvPerifericos.Rows[index].Cells["Responsable"].Value = reader["Responsable"].ToString();

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
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
    }
}
