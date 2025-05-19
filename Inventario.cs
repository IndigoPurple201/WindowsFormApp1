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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WinFormsApp1
{
    public partial class Inventario: Form
    {
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
        private ConexionSQL conexionSQL;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        DataTable dtTodos = new DataTable();
        DataTable dtHardware = new DataTable();
        DataTable dtPeriferico = new DataTable();
        public Inventario()
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL(udlFilePath);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);

            this.MouseDown += new MouseEventHandler(Inventario_MouseDown);
        }

        private void Inventario_Load(object sender, EventArgs e)
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
            radioTodos.Checked = true;
            boxDepartamentos.Enabled = false;
            label1.Visible = false;
            txtFolio.Visible = false;
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
                            boxDepartamentos.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void radioTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (radioTodos.Checked)
            {
                label1.Visible = false;
                txtFolio.Visible = false;
                boxDepartamentos.Visible = true;
                boxDepartamentos.Enabled = false;
            }
        }

        private void radioUno_CheckedChanged(object sender, EventArgs e)
        {
            if (radioUno.Checked)
            {
                label1.Visible = false;
                txtFolio.Visible = false;
                boxDepartamentos.Visible = true;
                boxDepartamentos.Enabled = true;
                cargarDepartamentos();
            }
        }

        private void radioEquipo_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEquipo.Checked)
            {
                label1.Visible = true;
                txtFolio.Visible = true;
                boxDepartamentos.Visible = false;
                txtFolio.Focus();
            }
        }

        private void Inventario_MouseDown(object sender, MouseEventArgs e)
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                string queryId = "";
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    if (radioTodos.Checked)
                    {
                        try
                        {
                            query = "EXEC SpHardware '0000';";
                            SqlDataAdapter da = new SqlDataAdapter(query, connection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            ReportDocument report = new ReportDocument();
                            report.Load(@"C:\Users\Administrador\Documents\WinFormsApp1\Reportes\rptCpu_depto_detalle.rpt");

                            report.SetDataSource(dt);

                            Form visor = new Form();
                            CrystalDecisions.Windows.Forms.CrystalReportViewer visorCrystal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                            visorCrystal.Dock = DockStyle.Fill;
                            visorCrystal.ReportSource = report;
                            visor.Controls.Add(visorCrystal);
                            visor.WindowState = FormWindowState.Maximized;
                            visor.ShowDialog();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                    if (radioUno.Checked)
                    {
                        if (boxDepartamentos.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(boxDepartamentos.Text))
                        {
                            string descripcionDepartamento = boxDepartamentos.Text;
                            queryId = "SELECT id_dependencia FROM dependencias WHERE descripcion = @descripcion;";
                            SqlCommand cmd = new SqlCommand(queryId, connection);
                            cmd.Parameters.AddWithValue("@descripcion", descripcionDepartamento);
                            string idDepartamento = cmd.ExecuteScalar()?.ToString();
                            if (string.IsNullOrEmpty(idDepartamento))
                            {
                                MessageBox.Show("No se encontró el id departamento seleccionado");
                                return;
                            }

                            query = $"EXEC SpHardware '{idDepartamento}';";
                            SqlDataAdapter da = new SqlDataAdapter(query, connection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            ReportDocument report = new ReportDocument();
                            report.Load(@"C:\Users\Administrador\Documents\WinFormsApp1\Reportes\rptCpu_depto_detalle.rpt");
                            report.SetDataSource(dt);

                            Form visor = new Form();
                            CrystalDecisions.Windows.Forms.CrystalReportViewer visorCrystal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                            visorCrystal.Dock = DockStyle.Fill;
                            visorCrystal.ReportSource = report;
                            visor.Controls.Add(visorCrystal);
                            visor.WindowState = FormWindowState.Maximized;
                            visor.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un departamento");
                        }
                    }
                    if (radioEquipo.Checked)
                    {
                        if (!string.IsNullOrWhiteSpace(txtFolio.Text))
                        {
                            string folio = txtFolio.Text.Trim();
                            string depto = "0000";
                            query = "EXEC SpHardware @depto, @folio";
                            SqlCommand cmd = new SqlCommand(query, connection);
                            if (!string.IsNullOrEmpty(folio))
                                cmd.Parameters.AddWithValue("@folio", folio);
                            else
                                cmd.Parameters.AddWithValue("@folio", DBNull.Value);
                            cmd.Parameters.AddWithValue("@depto", depto);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            ReportDocument report = new ReportDocument();
                            report.Load(@"C:\Users\Administrador\Documents\WinFormsApp1\Reportes\rptCpu_depto_detalle.rpt");
                            report.SetDataSource(dt);

                            Form visor = new Form();
                            CrystalDecisions.Windows.Forms.CrystalReportViewer visorCrystal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                            visorCrystal.Dock = DockStyle.Fill;
                            visorCrystal.ReportSource = report;
                            visor.Controls.Add(visorCrystal);
                            visor.WindowState = FormWindowState.Maximized;
                            visor.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un folio");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el reporte. Por favor, intente nuevamente.");

                MessageBox.Show("Error: " + ex.Message);
                MessageBox.Show("Stack Trace: " + ex.StackTrace);

                if (ex.InnerException != null)
                {
                    MessageBox.Show("Inner Exception: " + ex.InnerException.Message);
                    MessageBox.Show("Inner Exception Stack Trace: " + ex.InnerException.StackTrace);
                }
            }
        }
    }
}
