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
    public partial class Marca : Form
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
        private string connectionString = "Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;";
        public Marca()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);

            this.MouseDown += new MouseEventHandler(Marca_MouseDown);
            //this.MouseMove += new MouseEventHandler(Marca_MouseMove);
        }

        private void Marca_Load(object sender, EventArgs e)
        {
            BloquearControles(true);
            ConexionSQL conexion = new ConexionSQL();
            conexion.ProbarConexion();

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
        }

        private void cargarDatosDGV()
        {
            try
            {
                string query = "SELECT marcas.id_marca AS Numero, marcas.descripcion AS Descripcion FROM marcas";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvMarcas.Rows.Clear(); // Limpiar las filas existentes antes de agregar nuevas

                        while (reader.Read())
                        {
                            int index = dgvMarcas.Rows.Add();
                            dgvMarcas.Rows[index].Cells["Descripcion"].Value = reader["Descripcion"];
                            dgvMarcas.Rows[index].Cells["Numero"].Value = reader["Numero"];

                            // Guardamos el valor original en el Tag de la celda "Descripcion"
                            dgvMarcas.Rows[index].Cells["Descripcion"].Tag = reader["Descripcion"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }


        private void ConfigurarDataGridView()
        {
            dgvMarcas.BackgroundColor = Color.White;
            dgvMarcas.BorderStyle = BorderStyle.None;


            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvMarcas.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvMarcas.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


            dgvMarcas.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvMarcas.DefaultCellStyle.SelectionForeColor = Color.White;


            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvMarcas.Columns.Count == 0)
            {
                dgvMarcas.Columns.Add("Numero", "Número");
                dgvMarcas.Columns.Add("Descripcion", "Descripción");
            }

            dgvMarcas.Columns["Descripcion"].ReadOnly = false;
            dgvMarcas.Columns["Numero"].ReadOnly = true;
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

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Convertir todo el texto a mayúsculas
            txt.Text = txt.Text.ToUpper();
            // Mover el cursor al final para evitar que vuelva atrás
            txt.SelectionStart = txt.Text.Length;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    try
                    {
                        conexion.Open();
                        string query = "INSERT INTO marcas (id_marca, descripcion) VALUES (@id_marca, @descripcion)";
                        using (SqlCommand insertCmd = new SqlCommand(query, conexion))
                        {
                            insertCmd.Parameters.AddWithValue("@id_marca", txtFolio.Text);
                            insertCmd.Parameters.AddWithValue("@descripcion", txtMarca.Text);
                            insertCmd.ExecuteNonQuery();
                            MarcaAgregada?.Invoke();
                            MessageBox.Show("Marca agregada correctamente");
                            LimpiarControles();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                cargarDatosDGV();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool cambiosRealizados = false;
            foreach (DataGridViewRow row in dgvMarcas.Rows)
            {
                if (row.Cells["Descripcion"].Value == null) continue; // Evitar errores con valores nulos
                var valorOriginal = row.Cells["Descripcion"].Tag?.ToString() ?? "";
                var valorNuevo = row.Cells["Descripcion"].Value.ToString();
                if (!valorOriginal.Equals(valorNuevo))
                {
                    int idMarca = Convert.ToInt32(row.Cells["Numero"].Value);
                    try
                    {
                        string queryUpdate = "UPDATE marcas SET descripcion = @descripcion WHERE id_marca = @id_marca";
                        using (SqlConnection conexion = new SqlConnection(connectionString))
                        {
                            conexion.Open();
                            using (SqlCommand updateCmd = new SqlCommand(queryUpdate, conexion))
                            {
                                updateCmd.Parameters.AddWithValue("@descripcion", valorNuevo);
                                updateCmd.Parameters.AddWithValue("@id_marca", idMarca);
                                updateCmd.ExecuteNonQuery();
                                MarcaAgregada?.Invoke();
                            }
                        }
                        cambiosRealizados = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar marca ID " + idMarca + ": " + ex.Message);
                    }
                }
            }
            if (cambiosRealizados)
            {
                MessageBox.Show("Marca(s) actualizada(s) correctamente.");
                cargarDatosDGV();
            }
            else
            {
                MessageBox.Show("No se realizaron cambios.");
                cargarDatosDGV();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una marca para eliminar.");
                return;
            }
            DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar la(s) marca(s) seleccionada(s)?",
                                                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion != DialogResult.Yes) return;
            foreach (DataGridViewRow row in dgvMarcas.SelectedRows)
            {
                if (row.Cells["Numero"].Value == null) continue;
                int idMarca = Convert.ToInt32(row.Cells["Numero"].Value);
                try
                {
                    string queryDelete = "DELETE FROM marcas WHERE id_marca = @id_marca";
                    using (SqlConnection conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();
                        using (SqlCommand deleteCmd = new SqlCommand(queryDelete, conexion))
                        {
                            deleteCmd.Parameters.AddWithValue("@id_marca", idMarca);
                            deleteCmd.ExecuteNonQuery();
                            MarcaAgregada?.Invoke();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar marca ID " + idMarca + ": " + ex.Message);
                    return;
                }
            }
            MessageBox.Show("Marca(s) eliminada(s) correctamente.");
            cargarDatosDGV();
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

        private void LimpiarControles()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void Marca_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE, 0);
            }
        }

        //private void Marca_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        this.Left += e.X - mouseDownLocation.X;
        //        this.Top += e.Y - mouseDownLocation.Y;
        //    }
        //}

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(false);
        }

        private void BloquearControles(bool bloquear)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Enabled = !bloquear; // Deshabilita o habilita los controles
                }
            }
            btnNuevo.Enabled = bloquear;    // "Nuevo" solo está habilitado cuando los demás están bloqueados
            btnAceptar.Enabled = !bloquear; // "Aceptar" solo se habilita cuando los controles están activos
            btnCancelar.Enabled = !bloquear; // "Cancelar" solo se habilita cuando los controles están activos
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            BloquearControles(true);
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
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                mensajeError += "- Especifique un nombre de marca valido.\n";
                esValido = false;
            }
            if (!esValido)
            {
                MessageBox.Show(mensajeError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return esValido;
        }

    }
}
