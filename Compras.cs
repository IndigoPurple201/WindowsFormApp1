using CrystalDecisions.ReportAppServer.CommonControls;
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
    public partial class Compras : Form
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
        public Compras()
        {
            InitializeComponent();            
            string udlFilePath = @"conexion.udl";
            conexionSQL = new ConexionSQL();
            this.MouseDown += new MouseEventHandler(Compras_MouseDown);
            //this.MouseMove += new MouseEventHandler(Hardware_MouseMove);
            panelBarra.MouseDown += new MouseEventHandler(Compras_MouseDown);
            panel1.MouseDown += new MouseEventHandler(Compras_MouseDown);
            panel2.MouseDown += new MouseEventHandler(Compras_MouseDown);
            label1.MouseDown += new MouseEventHandler(Compras_MouseDown);
            label7.MouseDown += new MouseEventHandler(Compras_MouseDown);
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            conexionSQL.ProbarConexion();
            LlenarBoxProveedor();
            LlenarBoxDepartamento();
            BloquearControles(panel2, true, btnNuevo);
            BloquearControles(panel1, true, btnNuevo2);
            this.MouseDown += new MouseEventHandler(Compras_MouseDown);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox)
                {
                    ctrl.Enter += ControlSeleccionado;
                }
            }
            this.Click += QuitarFoco;
        }

        private void ObtenerSiguienteNumero()
        {
            try 
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(idOrdenCompra), 0) + 1 AS SiguienteNumero FROM OrdenCompra;";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        object result = cmd.ExecuteScalar();
                        txtOrden.Text = result.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ObtenerSiguienteNumero2()
        {
            try 
            {
                using (SqlConnection connection = conexionSQL.ObtenerConexion())
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(idDetalle), 0) + 1 AS SiguienteNumero FROM DetalleCompra;";
                    using (SqlCommand cmd = new SqlCommand(query,connection))
                    {
                        object result = cmd.ExecuteScalar();
                        txtFolioDetalle.Text = result.ToString();   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LlenarBoxProveedor()
        {
            try 
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT Descripcion FROM Proveedor_Compra;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxProveedor.Items.Clear();
                        while (reader.Read())
                        {
                            boxProveedor.Items.Add(reader["descripcion"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LlenarBoxDepartamento()
        {
            try
            {
                using (SqlConnection conn = conexionSQL.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT descripcion FROM dependencias;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        boxDepartamento.Items.Clear();
                        while (reader.Read())
                        {
                            boxDepartamento.Items.Add(reader["descripcion"].ToString());
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

        private void Compras_MouseDown(object sender, MouseEventArgs e)
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

        private bool validarComboBox()
        {
            return boxProveedor.DroppedDown || boxDepartamento.DroppedDown;
        }

        private void BloquearControles(Control parent, bool bloquear, Button origen)
        {
            BloquearTodo(parent, bloquear);

            if (origen == btnNuevo)
            {
                // Esto afecta controles relacionados al panel2 (grupo 1)
                btnNuevo.Enabled = bloquear;
                btnAceptar.Enabled = !bloquear;
                btnCancelar.Enabled = !bloquear;
                btnActualizar.Enabled = !bloquear;
                btnEliminar.Enabled = !bloquear;
                btnBuscar.Enabled = !bloquear;
            }
            else if (origen == btnNuevo2)
            {
                // Esto afecta controles relacionados al panel1 (grupo 2)
                btnNuevo2.Enabled = bloquear;
                btnAceptar2.Enabled = !bloquear;
                btnCancelar2.Enabled = !bloquear;
                btnActualizar2.Enabled = !bloquear;
                btnEliminar2.Enabled = !bloquear;
                btnBuscar2.Enabled = !bloquear;
                btnImprimir.Enabled = !bloquear;
            }
        }

        private void BloquearTodo(Control parent, bool bloquear)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox || ctrl is DateTimePicker)
                {
                    ctrl.Enabled = !bloquear;
                }

                if (ctrl.HasChildren)
                {
                    BloquearTodo(ctrl, bloquear);
                }
            }
        }

        private void LimpiarControles()
        {
            txtOrden.Clear();
            boxProveedor.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;  
            txtFolioOrden.Clear();
            boxDepartamento.SelectedIndex = -1;
            txtEntrega.Clear();
            txtRecibe.Clear();
        }

        private void LimpiarControles2()
        {
            boxCompra.SelectedIndex = -1;
            txtFolioDetalle.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtMedida.Clear();
            txtTotal.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BloquearControles(panel2,false, btnNuevo);
            ObtenerSiguienteNumero();
            txtOrden.Enabled = false;   
        }

        private void btnNuevo2_Click(object sender, EventArgs e)
        {
            BloquearControles(panel1, false, btnNuevo2);
            ObtenerSiguienteNumero2();
            txtFolioDetalle.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            BloquearControles(panel2, true, btnNuevo);
            txtOrden.Enabled = false;
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            LimpiarControles2();
            BloquearControles(panel1, true, btnNuevo2);
            txtFolioDetalle.Enabled = false;
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

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFolioOrden_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }

        private void txtEntrega_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }
        private void txtRecibe_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }
        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Permitir solo números, punto decimal y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear entrada no numérica
            }
            // Evitar que se ingresen más de 8 dígitos
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 8)
            {
                e.Handled = true;
            }
        }

        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Permitir solo números, punto decimal y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear entrada no numérica
            }
            // Evitar que se ingresen más de 8 dígitos
            if (!char.IsControl(e.KeyChar) && txt.Text.Length >= 8)
            {
                e.Handled = true;
            }
        }

        private void txtMedida_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Text = txt.Text.ToUpper();
            txt.SelectionStart = txt.Text.Length;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar2_Click(object sender, EventArgs e)
        {

        }
    }
}
