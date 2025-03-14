using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class BuscarPerifericos : Form
    {
        private string connectionString = "Server=COMPRAS-SERV\\SQLEXPRESS; Database=inventarios; Integrated Security=True; Encrypt=False;"; 
        public BuscarPerifericos()
        {
            InitializeComponent();
        }

        private void BuscarPerifericos_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarDatosDGV();
            label3.Text = "NUMERO:";
            boxBuscarDepartamento.Visible = false;
            txtBuscarDidecon.Visible = false;
            boxBuscarActivo.Visible = false;
            boxBuscarNumSerie.Visible = false;
            txtBuscarFolio.Visible = true;
            txtBuscarFolio.Focus();
            ConfigurarBoxBuscarActivo(boxBuscarActivo);
            ConfigurarBuscarNumSerie(boxBuscarNumSerie);
        }

        private void CargarDatosDGV()
        {
            try
            {
                string query = "SELECT perifericos.folio AS Numero, perifericos.didecon AS Didecon, tipos.descripcion AS Tipo, marcas.descripcion AS Marca, modelos.descripcion AS Modelo, perifericos.sn AS 'N. Serie', perifericos.activocontraloria AS 'Act. Contraloria', dependencias.descripcion AS Departamento, hardware.area AS Area, hardware.responsable AS Responsable FROM perifericos JOIN tipos ON tipos.id_tipo = perifericos.tipo JOIN marcas ON marcas.id_marca = perifericos.marca JOIN modelos ON modelos.id_modelo = perifericos.modelo JOIN hardware ON hardware.didecon = perifericos.didecon JOIN dependencias ON dependencias.id_dependencia = hardware.depto WHERE tipos.descripcion != 'CPU';";
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

        private void boxActivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            // Evitar que se ingresen más de 15 dígitos
            if (!char.IsControl(e.KeyChar) && comboBox.Text.Length >= 15)
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

        private void ConfigurarBoxBuscarActivo(ComboBox boxActivo)
        {
            boxActivo.Items.Clear();
            boxActivo.Items.Add("-");  // Agregar opción por defecto
            boxActivo.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxActivo.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxActivo.KeyPress += boxActivo_KeyPress;
        }

        private void ConfigurarBuscarNumSerie(ComboBox boxNumSerie)
        {
            boxNumSerie.Items.Clear();
            boxNumSerie.Items.Add("-");  // Agregar opción por defecto
            boxNumSerie.Items.Add("SN");
            boxNumSerie.DropDownStyle = ComboBoxStyle.DropDown; // Permite escribir manualmente
            boxNumSerie.SelectedIndex = 0; // Seleccionar "-" por defecto

            boxNumSerie.TextChanged += boxNumSerie_TextChanged;
        }

        private void cargarDepartamentos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
                boxBuscarActivo.Visible = false;
                boxBuscarNumSerie.Visible = false;
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
                boxBuscarActivo.Visible = false;
                boxBuscarNumSerie.Visible = false;
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
                boxBuscarActivo.Visible = false;
                boxBuscarNumSerie.Visible = false;
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
                boxBuscarActivo.Visible = true;
                boxBuscarNumSerie.Visible = false;
                txtBuscarFolio.Visible = false;
                boxBuscarActivo.Focus();
            }
        }

        private void radioNumSerie_CheckedChanged(object sender, EventArgs e)
        {
            if (radioNumSerie.Checked)
            {
                label3.Text = "NUM SERIE:";
                boxBuscarDepartamento.Visible = false;
                txtBuscarDidecon.Visible = false;
                boxBuscarActivo.Visible = false;
                boxBuscarNumSerie.Visible = true;
                txtBuscarFolio.Visible = false;
                boxBuscarNumSerie.Focus();
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
                if (boxBuscarActivo.SelectedIndex == -1 || boxBuscarActivo.SelectedItem == null)
                {
                    MessageBox.Show("Ingrese un Act. Contraloria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                filtro = boxBuscarActivo.Text.Trim();
                query += " AND perifericos.activocontraloria = @activo";
            }
            else if (radioNumSerie.Checked)
            {
                if (boxBuscarActivo.SelectedIndex == -1 || boxBuscarActivo.SelectedItem == null)
                {
                    MessageBox.Show("Ingrese un Num Serie.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                filtro = boxBuscarNumSerie.Text.Trim();
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
                using (SqlConnection connection = new SqlConnection(connectionString))
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

    }
}
