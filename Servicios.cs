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
    public partial class Servicios: Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_SYSCOMMAND = 0x112;
        private const int SC_MOVE = 0xF012;
        private Control controlActivo = null;
        private Point mouseDownLocation;
        private ConexionSQL conexionSQL;
        public Servicios()
        {
            InitializeComponent();
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL(udlFilePath);
            this.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            //this.MouseMove += new MouseEventHandler(Hardware_MouseMove);
            panelBarra.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            label1.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            panel1.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            panel2.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            panel3.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            tabPage1.MouseDown += new MouseEventHandler(Servicios_MouseDown);
        }

        private void Servicios_Load(object sender, EventArgs e)
        {
            conexionSQL.ProbarConexion();
            LlenarBoxEstatus();
            BloquearControles(this, true);
            this.MouseDown += new MouseEventHandler(Servicios_MouseDown);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }
            this.Click += QuitarFoco;
            dateEntrada.Enabled = false;
            dateSalida.Enabled = false;
            dateReparacion.Enabled = false;
            dateRefaccionPedido.Enabled = false;
            dateRefaccionEntrega.Enabled = false;
            dateExternoPedido.Enabled = false;
            dateExternoEntrega.Enabled = false;
        }

        private void LlenarBoxEstatus()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    String query = "SELECT estatus.descripcion FROM estatus WHERE estatus.id_estatus = 1;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxEstatus.Items.Clear();
                        while (reader.Read())
                        {
                            boxEstatus.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Servicios_MouseDown(object sender, MouseEventArgs e)
        {
            if (validarComboBox())
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE, 0);
            }
        }

        private void panelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void tabPage1_MouseDownn(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLocation = e.Location;
            }
        }

        private void BloquearControles(Control parent, bool bloquear)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enabled = !bloquear;
                }

                if (ctrl.HasChildren)
                {
                    BloquearControles(ctrl, bloquear);
                }
            }
            btnNuevo.Enabled = bloquear;
            btnAceptar.Enabled = !bloquear;
            btnCancelar.Enabled = !bloquear;
            btnActualizar.Enabled = !bloquear;
            btnEliminar.Enabled = !bloquear;
            btnBuscar.Enabled = !bloquear;
            btnSalir.Enabled = bloquear;
        }

        private void LimpiarControles()
        {
            txtServicio.Clear();
            txtFolio.Clear();
            txtConsecutivo.Clear();
            txtFalla.Clear();
            txtSolicito.Clear();
            txtRecogio.Clear();
        }

        private void RestablecerComboBox(ComboBox comboBox, string valorPredeterminado)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(valorPredeterminado);
            comboBox.SelectedIndex = 0;
        }


        private void RestablecerComboBoxSinPredeterminado(ComboBox comboBox)
        {
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = -1;
                comboBox.ResetText();
            }
        }

        private bool validarComboBox()
        {
            return boxEstatus.DroppedDown || boxExterno.DroppedDown;
        }

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(this, false);
            btnSalir.Enabled = true;
            dateEntrada.Enabled = true;
            if (boxEstatus.Items.Count == 1)
            {
                boxEstatus.SelectedIndex = 0;
                boxEstatus.Enabled = false;
            }
            tabControl1.SelectedTab = tabPage1;
            radioCpu.Checked = true;
            txtServicio.Text = "1";
            txtServicio.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            BloquearControles(this, true);
            if (boxEstatus.Items.Count == 1)
            {
                boxEstatus.SelectedIndex = -1;
            }
            dateEntrada.Enabled = false;
            tabControl1.SelectedTab = tabPage1;
            radioCpu.Checked = false;
            radioPeriferico.Checked = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
