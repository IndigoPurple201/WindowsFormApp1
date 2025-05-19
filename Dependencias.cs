using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WinFormsApp1
{
    public partial class Dependencias : Form
    {
        public event Action DependenciaAgregada;
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
        public Dependencias()
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL(udlFilePath);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);

            this.MouseDown += new MouseEventHandler(Dependencias_MouseDown);
            //this.MouseMove += new MouseEventHandler(Marca_MouseMove)
        }

        private void Dependencias_Load(object sender, EventArgs e)
        {
            BloquearControles(true);
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
            ObtenerSiguienteNumero();
            txtFolio.Enabled = false;
        }
        private void Dependencias_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE | 0x0001, 0);
            }
        }

        private void ControlSeleccionado(object sender, EventArgs e)
        {
            if (sender is TextBox || sender is ComboBox)
            {
                controlActivo = sender as Control;
            }
        }

        private void CargarDatosDGV()
        {
            try
            {
                string query = "SELECT dependencias.id_dependencia AS Numero, dependencias.descripcion AS Descripcion FROM dependencias;";
                using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvDependencias.Rows.Clear();
                        while (reader.Read())
                        {
                            int index = dgvDependencias.Rows.Add();
                            dgvDependencias.Rows[index].Cells["Numero"].Value = reader["Numero"];
                            dgvDependencias.Rows[index].Cells["Descripcion"].Value = reader["Descripcion"];
                        }
                    }
                }
                dgvDependencias.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvDependencias.BackgroundColor = Color.White;
            dgvDependencias.BorderStyle = BorderStyle.None;
            dgvDependencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDependencias.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvDependencias.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvDependencias.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvDependencias.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDependencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvDependencias.Columns.Count == 0)
            {
                dgvDependencias.Columns.Add("Numero", "Número");
                dgvDependencias.Columns.Add("Descripcion", "Descripción");
            }
            dgvDependencias.Columns["Descripcion"].ReadOnly = false;
            dgvDependencias.Columns["Numero"].ReadOnly = true;
        }

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear entrada no numérica
            }
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 4)
            {
                e.Handled = true;
            }
        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            BloquearControles(true);
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                try
                {
                    using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                    {
                        conexion.Open();
                        string query = "INSERT INTO dependencias (id_dependencia, descripcion) VALUES (@id_dependencia, @descripcion);";
                        using (SqlCommand insertCmd = new SqlCommand(query, conexion))
                        {
                            insertCmd.Parameters.AddWithValue("@id_dependencia", txtFolio.Text);
                            insertCmd.Parameters.AddWithValue("@descripcion", txtDepartamento.Text);
                            insertCmd.ExecuteNonQuery();
                            DependenciaAgregada?.Invoke();
                            MessageBox.Show("Dependencia agregada correctamente");
                        }
                    }
                    LimpiarControles();
                    CargarDatosDGV();
                    ObtenerSiguienteNumero();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool cambiosRealizados = false;
            foreach (DataGridViewRow row in dgvDependencias.Rows)
            {
                if (row.Cells["Descripcion"].Value == null) continue;
                var valorOriginal = row.Cells["Descripcion"].Tag?.ToString() ?? "";
                var valorNuevo = row.Cells["Descripcion"].Value.ToString();
                if (!valorOriginal.Equals(valorNuevo))
                {
                    int idDependencia = Convert.ToInt32(row.Cells["Numero"].Value);
                    try
                    {
                        string queryUpdate = "UPDATE dependencias SET descripcion = @descripcion WHERE id_dependencia = @id_dependencia;";
                        using (SqlConnection connection = conexionSQL.ObtenerConexion())
                        {
                            connection.Open();
                            using (SqlCommand updateCmd = new SqlCommand(queryUpdate, connection))
                            {
                                updateCmd.Parameters.AddWithValue("@descripcion", valorNuevo);
                                updateCmd.Parameters.AddWithValue("@id_dependencia", idDependencia);
                                updateCmd.ExecuteNonQuery();
                                DependenciaAgregada?.Invoke();
                            }
                        }
                        cambiosRealizados = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            if (cambiosRealizados)
            {
                MessageBox.Show("Dependencia(s) actualizada(s) correctamente.");
                CargarDatosDGV();
            }
            else
            {
                MessageBox.Show("No se realizaron cambios.");
                CargarDatosDGV();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDependencias.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una dependencia para eliminar.");
                return;
            }
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar la(s) dependencia(s) seleccionada(s)?",
                                                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes) return;
            foreach (DataGridViewRow row in dgvDependencias.SelectedRows)
            {
                if (row.Cells["Numero"].Value == null) continue;
                int idDependencia = Convert.ToInt32(row.Cells["Numero"].Value);
                try
                {
                    string queryDelete = "DELETE FROM dependencias WHERE id_dependencia = @id_dependencia;";
                    using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                    {
                        conexion.Open();
                        using (SqlCommand deleteCmd = new SqlCommand(queryDelete, conexion))
                        {
                            deleteCmd.Parameters.AddWithValue("@id_dependencia", idDependencia);
                            deleteCmd.ExecuteNonQuery();
                            DependenciaAgregada?.Invoke();
                            MessageBox.Show("Dependencia eliminada");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error. " + ex);
                }
            }
            CargarDatosDGV();
            ObtenerSiguienteNumero();
        }


        private void LimpiarControles()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    if (textBox.Name != "txtFolio")
                    {
                        textBox.Clear();
                    }
                }
            }
        }

        private void BloquearControles(bool bloquear)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox && ctrl != txtFolio)
                {
                    ctrl.Enabled = !bloquear; // Deshabilita o habilita los controles
                }
            }
            btnNuevo.Enabled = bloquear;    // "Nuevo" solo está habilitado cuando los demás están bloqueados
            btnAceptar.Enabled = !bloquear; // "Aceptar" solo se habilita cuando los controles están activos
            btnCancelar.Enabled = !bloquear; // "Cancelar" solo se habilita cuando los controles están activos
        }

        private void ObtenerSiguienteNumero()
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(id_dependencia), 0) + 1 FROM dependencias;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
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



        private void QuitarFoco(object sender, EventArgs e)
        {
            if (controlActivo != null && !controlActivo.Bounds.Contains(this.PointToClient(Cursor.Position)))
            {
                this.ActiveControl = null;
                controlActivo = null;
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(bordeOriginal, 3))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validarCampos()
        {
            bool esValido = true;
            string mensajeError = "Faltan los siguientes campos:\n";
            if (string.IsNullOrWhiteSpace(txtFolio.Text))
            {
                mensajeError += "- Especifique un numero valido.\n";
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtDepartamento.Text))
            {
                mensajeError += "- Especifique un nombre de departamento valido.\n";
                esValido = false;
            }
            if (!esValido)
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.Close();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try 
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    string query = "SELECT id_dependencia, descripcion FROM dependencias;";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ReportDocument report = new ReportDocument();
                    report.Load(@"Reportes\rptdependencias.rpt");

                    report.SetDataSource(dt);

                    Form visor = new Form();
                    CrystalDecisions.Windows.Forms.CrystalReportViewer visorCrystal = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                    visorCrystal.Dock = DockStyle.Fill;
                    visorCrystal.ReportSource = report;
                    visor.Controls.Add(visorCrystal);
                    visor.WindowState = FormWindowState.Maximized;
                    visor.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message);
            }
        }
    }
}
