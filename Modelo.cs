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
    public partial class Modelo : Form
    {
        public event Action ModeloAgregada;
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

        private Control controlActivo = null;
        private Point mouseDownLocation;
        private string connectionString = "Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;";
        public Modelo(string marca)
        {
            InitializeComponent();
            txtMarca.Text = marca;
            txtMarca.Enabled = false;

            this.MouseDown += new MouseEventHandler(Marca_MouseDown);
            this.MouseMove += new MouseEventHandler(Marca_MouseMove);
        }

        private void Modelo_Load(object sender, EventArgs e)
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
            label7.Text = txtMarca.Text;
        }

        private void cargarDatosDGV()
        {
            try
            {
                string query = "SELECT modelos.id_modelo AS Numero, modelos.descripcion AS Descripcion, tipos.descripcion AS Tipo, tipos.refaccion Refaccion FROM modelos JOIN tipos ON modelos.tipo = tipos.id_tipo JOIN marcas ON marcas.id_marca = modelos.marca WHERE marcas.descripcion = @marca;";
                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvModelos.Rows.Clear();
                            while (reader.Read())
                            {
                                int index = dgvModelos.Rows.Add();
                                dgvModelos.Rows[index].Cells["Numero"].Value = reader["Numero"];
                                dgvModelos.Rows[index].Cells["Descripcion"].Value = reader["Descripcion"];
                                dgvModelos.Rows[index].Cells["Tipo"].Value = reader["Tipo"];
                                dgvModelos.Rows[index].Cells["Refaccion"].Value = reader["Refaccion"];

                                // Guardamos el valor original en el Tag de la celda "Descripcion"
                                dgvModelos.Rows[index].Cells["Descripcion"].Tag = reader["Descripcion"];
                            }
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
            dgvModelos.BackgroundColor = Color.White;
            dgvModelos.BorderStyle = BorderStyle.None;


            dgvModelos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvModelos.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvModelos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


            dgvModelos.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvModelos.DefaultCellStyle.SelectionForeColor = Color.White;


            dgvModelos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvModelos.Columns.Count == 0)
            {
                dgvModelos.Columns.Add("Numero", "Número");
                dgvModelos.Columns.Add("Descripcion", "Descripción");
                dgvModelos.Columns.Add("Tipo", "Tipo");
                dgvModelos.Columns.Add("Refaccion", "Refaccion");
            }

            dgvModelos.Columns["Numero"].ReadOnly = false;
            dgvModelos.Columns["Descripcion"].ReadOnly = true;
            dgvModelos.Columns["Tipo"].ReadOnly = true;
            dgvModelos.Columns["Refaccion"].ReadOnly = true;
        }

        private void LimpiarControles()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox textBox)
                {
                    // Si el TextBox es el de la marca, NO lo limpiamos
                    if (textBox.Name != "txtMarca")
                    {
                        textBox.Clear();
                    }
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
            }
        }

        private void btnCerrar2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtModelo_TextChanged(object sender, EventArgs e)
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
            txtMarca.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            txtMarca.Enabled = false;
            BloquearControles(true);
        }

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

        private void BloquearControles(bool bloquear)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enabled = !bloquear; // Deshabilita o habilita los controles
                }
            }
            btnNuevo.Enabled = bloquear;    // "Nuevo" solo está habilitado cuando los demás están bloqueados
            btnAceptar.Enabled = !bloquear; // "Aceptar" solo se habilita cuando los controles están activos
            btnCancelar.Enabled = !bloquear; // "Cancelar" solo se habilita cuando los controles están activos
        }
    }
}
