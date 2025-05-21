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
    public partial class Menu : Form
    {
        private Form formularioConectar;
        private bool cerrarDesdeBotonSalir = false;
        public Menu(Form conectar)
        {
            InitializeComponent();
            this.formularioConectar = conectar;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormClosing += Menu_FormClosing;
        }

        private void toolHardware_Click(object sender, EventArgs e)
        {
            Hardware hardware = new Hardware();
            hardware.ShowDialog();
        }

        private void toolPeriferico_Click(object sender, EventArgs e)
        {
            Perifericos periferico = new Perifericos();
            periferico.ShowDialog();
        }

        private void toolMarca_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.ShowDialog();
        }

        private void toolDependencias_Click(object sender, EventArgs e)
        {
            Dependencias dependencias = new Dependencias();
            dependencias.ShowDialog();
        }

        private void toolModelo_Click(object sender, EventArgs e)
        {
            Modelo modelo = new Modelo("", "SIN TIPO");
            modelo.ShowDialog();
        }

        private void menuReporte_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.ShowDialog();
        }   

        private void menuServicios_Click(object sender, EventArgs e)
        {
            Servicios servicios = new Servicios();
            servicios.ShowDialog();
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir al menú de inicio?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cerrarDesdeBotonSalir = true;
                formularioConectar.Show();
                this.Close();
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrarDesdeBotonSalir)
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    formularioConectar.Show();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
