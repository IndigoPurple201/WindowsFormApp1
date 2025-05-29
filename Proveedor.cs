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
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Proveedor : Form
    {
        public event Action ProveedorAgregado;
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
        public Proveedor()
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);

            this.MouseDown += new MouseEventHandler(Proveedores_MouseDown);
        }

        private void Proveedores_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE, 0);
            }
        }

        private void Proveedor_Load(object sender, EventArgs e)
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
            cargarDatosDGV();
            ObtenerSiguienteNumero();
            txtFolio.Enabled = false;
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

        private void ConfigurarDataGridView()
        {
            dgvProveedores.BackgroundColor = Color.White;
            dgvProveedores.BorderStyle = BorderStyle.None;
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvProveedores.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvProveedores.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvProveedores.Columns.Count == 0)
            {
                dgvProveedores.Columns.Add("Numero", "Número");
                dgvProveedores.Columns.Add("Descripcion", "Descripción");
            }
            dgvProveedores.Columns["Descripcion"].ReadOnly = false;
            dgvProveedores.Columns["Numero"].ReadOnly = true;
            foreach (DataGridViewColumn column in dgvProveedores.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void cargarDatosDGV()
        {
            try
            {
                string query = "SELECT idProveedor AS Numero, Descripcion FROM Proveedor_Compra;";
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvProveedores.Rows.Clear();
                        while (reader.Read())
                        {
                            int index = dgvProveedores.Rows.Add();
                            dgvProveedores.Rows[index].Cells["Numero"].Value = reader["Numero"];
                            dgvProveedores.Rows[index].Cells["Descripcion"].Value = reader["Descripcion"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(bordeOriginal, 3))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
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
                        string query = "INSERT INTO Proveedor_Compra(Descripcion) VALUES (@descripcion);";
                        using (SqlCommand insertCmd = new SqlCommand(query, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@descripcion", txtProveedor.Text);
                            insertCmd.ExecuteNonQuery();
                            ProveedorAgregado?.Invoke();
                            MessageBox.Show("Registro agredado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarControles();
                        }
                    }
                    cargarDatosDGV();
                    ObtenerSiguienteNumero();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void ObtenerSiguienteNumero()
        {
            try
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(idProveedor), 0) + 1 FROM Proveedor_Compra;";
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea acutalizar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                bool cambiosRealizados = false;
                foreach (DataGridViewRow row in dgvProveedores.Rows)
                {
                    if (row.Cells["Descripcion"].Value == null) continue;
                    var valorOriginal = row.Cells["Descripcion"].Tag?.ToString() ?? "";
                    var valorNuevo = row.Cells["Descripcion"].Value.ToString().ToUpper();
                    row.Cells["Descripcion"].Tag = valorNuevo;
                    if (!valorOriginal.Equals(valorNuevo))
                    {
                        int idProveedor = Convert.ToInt32(row.Cells["Numero"].Value);
                        try
                        {
                            string queryUpdate = "UPDATE Proveedor_Compra SET Descripcion = @descripcion WHERE idProveedor = @idProveedor;";
                            using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                            {
                                conexion.Open();
                                using (SqlCommand updateCmd = new SqlCommand(queryUpdate, conexion))
                                {
                                    updateCmd.Parameters.AddWithValue("@descripcion", valorNuevo);
                                    updateCmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                                    updateCmd.ExecuteNonQuery();
                                    ProveedorAgregado?.Invoke();
                                }
                            }
                            cambiosRealizados = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al actualizar marca ID " + idProveedor + ": " + ex.Message);
                        }
                    }
                }
                if (cambiosRealizados)
                {
                    MessageBox.Show("Registro actualizado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatosDGV();
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatosDGV();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una marca para eliminar.");
                return;
            }
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar el(los) registro(s) seleccionada(s)?",
                                                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes) return;
            foreach (DataGridViewRow row in dgvProveedores.SelectedRows)
            {
                if (row.Cells["Numero"].Value == null) continue;
                int idProveedor = Convert.ToInt32(row.Cells["Numero"].Value);
                try
                {
                    string queryDelete = "DELETE FROM Proveedor_Compra WHERE idProveedor = @idProveedor;";
                    using (SqlConnection conexion = conexionSQL.ObtenerConexion())
                    {
                        conexion.Open();
                        using (SqlCommand deleteCmd = new SqlCommand(queryDelete, conexion))
                        {
                            deleteCmd.Parameters.AddWithValue("@idProveedor", idProveedor);
                            deleteCmd.ExecuteNonQuery();
                            ProveedorAgregado?.Invoke();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar marca ID " + idProveedor + ": " + ex.Message);
                    return;
                }
            }
            MessageBox.Show("Registro eliminado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cargarDatosDGV();
            ObtenerSiguienteNumero();
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

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
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
            if (string.IsNullOrWhiteSpace(txtProveedor.Text))
            {
                mensajeError += "- Especifique un nombre de proveedor valido.\n";
                esValido = false;
            }
            if (!esValido)
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
