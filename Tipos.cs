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

namespace WinFormsApp1
{
    public partial class Tipos : Form
    {
        public event Action TipoAgregado;
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
        string tipoFiltro = "";
        public Tipos(string tipo)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);

            this.MouseDown += new MouseEventHandler(Tipos_MouseDown);
            //this.MouseMove += new MouseEventHandler(Marca_MouseMove)
            tipoFiltro = tipo;
        }

        private void Tipos_Load(object sender, EventArgs e)
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
            boxRefaccion.Items.Clear();
            boxRefaccion.Items.Add("S");
            boxRefaccion.Items.Add("N");
            boxRefaccion.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Tipos_MouseDown(object sender, MouseEventArgs e)
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
                string query = "SELECT tipos.id_tipo AS Numero, tipos.descripcion AS Descripcion, tipos.refaccion AS Refaccion FROM tipos;";
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvTipos.Rows.Clear();
                        while (reader.Read())
                        {
                            int index = dgvTipos.Rows.Add();
                            dgvTipos.Rows[index].Cells["Numero"].Value = reader["Numero"].ToString();
                            dgvTipos.Rows[index].Cells["Descripcion"].Value = reader["Descripcion"].ToString();
                            dgvTipos.Rows[index].Cells["Refaccion"].Value = reader["Refaccion"].ToString();
                        }
                    }
                }
                dgvTipos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvTipos.BackgroundColor = Color.White;
            dgvTipos.BorderStyle = BorderStyle.None;


            dgvTipos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvTipos.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvTipos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


            dgvTipos.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvTipos.DefaultCellStyle.SelectionForeColor = Color.White;


            dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvTipos.Columns.Count == 0)
            {
                dgvTipos.Columns.Add("Numero", "Número");
                dgvTipos.Columns.Add("Descripcion", "Descripción");
                dgvTipos.Columns.Add("Refaccion", "Refacción");
            }
            dgvTipos.Columns["Refaccion"].ReadOnly = false;
            dgvTipos.Columns["Descripcion"].ReadOnly = false;
            dgvTipos.Columns["Numero"].ReadOnly = true;
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

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
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
            boxRefaccion.Enabled = !bloquear; // "Refacción" solo se habilita cuando los controles están activos
        }

        private void ObtenerSiguienteNumero()
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(id_tipo), 0) + 1 AS SiguienteNumero FROM tipos;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        txtFolio.Text = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
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
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        string query = "INSERT INTO tipos (id_tipo, descripcion, refaccion) VALUES (@id_tipo, @descripcion, @refaccion);";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@id_tipo", txtFolio.Text);
                            cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                            cmd.Parameters.AddWithValue("@refaccion", boxRefaccion.Text);
                            cmd.ExecuteNonQuery();
                            if (tipoFiltro != "SIN TIPO")
                            {
                                TipoAgregado.Invoke();
                            }
                            MessageBox.Show("Tipo agregado correctamente");
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
            foreach (DataGridViewRow row in dgvTipos.Rows)
            {
                if (row.IsNewRow) continue;
                string nuevoIdTipo = row.Cells["Numero"].Value.ToString();
                string nuevoDescripcion = row.Cells["Descripcion"].Value.ToString();
                string nuevoRefaccion = row.Cells["Refaccion"].Value.ToString();
                try
                {
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        string query = "UPDATE tipos SET descripcion = @descripcion, refaccion = @refaccion WHERE id_tipo = @id_tipo;";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@id_tipo", nuevoIdTipo);
                            cmd.Parameters.AddWithValue("@descripcion", nuevoDescripcion);
                            cmd.Parameters.AddWithValue("@refaccion", nuevoRefaccion);
                            cmd.ExecuteNonQuery();
                            if (tipoFiltro != "SIN TIPO")
                            {
                                TipoAgregado.Invoke();
                            }
                        }
                    }
                    cambiosRealizados = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
            if (dgvTipos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un tipo para eliminar");
                return;
            }
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar lo(s) modelos(s) seleccionado(s)?",
                                            "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes) return;
            foreach (DataGridViewRow row in dgvTipos.SelectedRows)
            {
                if (row.Cells["Numero"].Value == null) continue;
                int idTipo = Convert.ToInt32(row.Cells["Numero"].Value);
                try
                {
                    string query = "DELETE FROM tipos WHERE id_tipo = @id_tipo;";
                    using (SqlConnection connection = conexionSQL.ObtenerConexion())
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand(query,connection))
                        {
                            cmd.Parameters.AddWithValue("@id_tipo", idTipo);
                            cmd.ExecuteNonQuery();
                            if (tipoFiltro != "SIN TIPO")
                            {
                                TipoAgregado.Invoke();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            MessageBox.Show("Tipo(s) eliminado correctamente");
            CargarDatosDGV();
            ObtenerSiguienteNumero();
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

        private bool validarCampos()
        {
            bool esValido = true;
            string mensajeError = "Faltan los siguientes campos:\n";
            if (string.IsNullOrWhiteSpace(txtFolio.Text))
            {
                mensajeError += "- Especifique un numero valido.\n";
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                mensajeError += "- Especifique una descripcion valida.\n";
                esValido = false;
            }
            if (boxRefaccion.SelectedIndex == 1 || string.IsNullOrWhiteSpace(boxRefaccion.Text))
            {
                mensajeError += "- Especifique una refaccion valida.\n";
                esValido = false;
            }
            return esValido;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
