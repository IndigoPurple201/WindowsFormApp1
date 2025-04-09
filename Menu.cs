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
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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

        private void menuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
