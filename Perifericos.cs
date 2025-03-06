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
    public partial class Perifericos : Form
    {
        public event Action MarcaAgregada;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private Color bordeOriginal = Color.Black;
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private string connectionString = "Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;";

        private Hardware hardware;
        public Perifericos(Hardware form1)
        {
            InitializeComponent();
            hardware = form1;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(3);
            this.MouseDown += new MouseEventHandler(Periferico_MouseDown);
            panelBarra.MouseDown += new MouseEventHandler(Periferico_MouseDown);
            label1.MouseDown += new MouseEventHandler(Periferico_MouseDown);
        }

        private void Perifericos_Load(object sender, EventArgs e)
        {
            this.MouseDown += new MouseEventHandler(Periferico_MouseDown);
            ConfigurarDataGridView();
            CargarDatosDGV();
        }

        private void CargarDatosDGV()
        {
            try
            {
                string query = "SELECT perifericos.folio AS Numero, perifericos.didecon AS Didecon, tipos.descripcion AS Tipo, marcas.descripcion AS Marca, modelos.descripcion AS Modelo, perifericos.sn AS Num_Serie, perifericos.activocontraloria AS Activo, perifericos.fechacaptura AS Fecha FROM perifericos JOIN tipos ON tipos.id_tipo = perifericos.tipo JOIN marcas ON marcas.id_marca = perifericos.marca JOIN modelos ON modelos.id_modelo = perifericos.modelo;";
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                            dgvPerifericos.Rows[index].Cells["Num_Serie"].Value = reader["Num_Serie"].ToString();
                            dgvPerifericos.Rows[index].Cells["Activo"].Value = reader["Activo"].ToString();
                            dgvPerifericos.Rows[index].Cells["Fecha"].Value = reader["Fecha"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvPerifericos.BackgroundColor = Color.White;
            dgvPerifericos.BorderStyle = BorderStyle.None;


            dgvPerifericos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvPerifericos.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvPerifericos.AlternatingRowsDefaultCellStyle.BackColor = Color.White;


            dgvPerifericos.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvPerifericos.DefaultCellStyle.SelectionForeColor = Color.White;


            dgvPerifericos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (dgvPerifericos.Columns.Count == 0)
            {
                dgvPerifericos.Columns.Add("Numero", "Número");
                dgvPerifericos.Columns.Add("Didecon", "Didecon");
                dgvPerifericos.Columns.Add("Tipo", "Tipo");
                dgvPerifericos.Columns.Add("Marca", "Marca");
                dgvPerifericos.Columns.Add("Modelo", "Modelo");
                dgvPerifericos.Columns.Add("Num_Serie", "Num_Serie");
                dgvPerifericos.Columns.Add("Activo", "Activo");
                dgvPerifericos.Columns.Add("Fecha", "Fecha");
            }

            //dgvPerifericos.Columns["Descripcion"].ReadOnly = false;
            //dgvPerifericos.Columns["Numero"].ReadOnly = true;
        }

        private void Periferico_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE, 0);
            }
        }

        private void panelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Verifica que el clic sea con el botón izquierdo
            {
                mouseDownLocation = e.Location; // Guarda la posición del mouse al hacer clic
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Verifica que el clic sea con el botón izquierdo
            {
                mouseDownLocation = e.Location; // Guarda la posición del mouse al hacer clic
            }
        }

        //private void panelBarra_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left) // Si el botón del mouse sigue presionado
        //    {
        //        this.Left += e.X - mouseDownLocation.X;
        //        this.Top += e.Y - mouseDownLocation.Y;
        //    }
        //}

        private void panelBarra_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 4)) // Borde negro
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, panelBarra.Width - 1, panelBarra.Height - 1));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.Black, 3)) // Borde rojo y grosor de 3px
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }
        }

        private void btnHardware_Click(object sender, EventArgs e)
        {
            hardware.Show();
            this.Close();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
