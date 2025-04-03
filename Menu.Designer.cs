namespace WinFormsApp1
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            menuInventario = new ToolStripMenuItem();
            toolHardware = new ToolStripMenuItem();
            toolPeriferico = new ToolStripMenuItem();
            menuCatalogos = new ToolStripMenuItem();
            toolDependencias = new ToolStripMenuItem();
            toolTipos = new ToolStripMenuItem();
            toolMarcas = new ToolStripMenuItem();
            toolModelos = new ToolStripMenuItem();
            menuReportes = new ToolStripMenuItem();
            menuSalir = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuInventario, menuCatalogos, menuReportes, menuSalir });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.RightToLeft = RightToLeft.No;
            menuStrip1.Size = new Size(1920, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuInventario
            // 
            menuInventario.DropDownItems.AddRange(new ToolStripItem[] { toolHardware, toolPeriferico });
            menuInventario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuInventario.Name = "menuInventario";
            menuInventario.Size = new Size(119, 25);
            menuInventario.Text = "INVENTARIO";
            // 
            // toolHardware
            // 
            toolHardware.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolHardware.Name = "toolHardware";
            toolHardware.Size = new Size(152, 22);
            toolHardware.Text = "HARDWARE";
            toolHardware.Click += toolHardware_Click;
            // 
            // toolPeriferico
            // 
            toolPeriferico.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolPeriferico.Name = "toolPeriferico";
            toolPeriferico.Size = new Size(152, 22);
            toolPeriferico.Text = "PERIFERICOS";
            toolPeriferico.Click += toolPeriferico_Click;
            // 
            // menuCatalogos
            // 
            menuCatalogos.DropDownItems.AddRange(new ToolStripItem[] { toolDependencias, toolTipos, toolMarcas, toolModelos });
            menuCatalogos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuCatalogos.Name = "menuCatalogos";
            menuCatalogos.Size = new Size(113, 25);
            menuCatalogos.Text = "CATALOGOS";
            // 
            // toolDependencias
            // 
            toolDependencias.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolDependencias.Name = "toolDependencias";
            toolDependencias.Size = new Size(170, 22);
            toolDependencias.Text = "DEPENDENCIAS";
            // 
            // toolTipos
            // 
            toolTipos.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolTipos.Name = "toolTipos";
            toolTipos.Size = new Size(170, 22);
            toolTipos.Text = "TIPOS";
            // 
            // toolMarcas
            // 
            toolMarcas.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolMarcas.Name = "toolMarcas";
            toolMarcas.Size = new Size(170, 22);
            toolMarcas.Text = "MARCAS";
            toolMarcas.Click += toolMarca_Click;
            // 
            // toolModelos
            // 
            toolModelos.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolModelos.Name = "toolModelos";
            toolModelos.Size = new Size(170, 22);
            toolModelos.Text = "MODELOS";
            toolModelos.Click += toolModelo_Click;
            // 
            // menuReportes
            // 
            menuReportes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuReportes.Name = "menuReportes";
            menuReportes.Size = new Size(100, 25);
            menuReportes.Text = "REPORTES";
            // 
            // menuSalir
            // 
            menuSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuSalir.Name = "menuSalir";
            menuSalir.Size = new Size(65, 25);
            menuSalir.Text = "SALIR";
            menuSalir.Click += menuSalir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.escudo;
            pictureBox1.Location = new Point(52, 44);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1794, 936);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1920, 1061);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MENU";
            Text = "MENU";
            Load += Menu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuInventario;
        private ToolStripMenuItem menuCatalogos;
        private ToolStripMenuItem menuReportes;
        private ToolStripMenuItem menuSalir;
        private ToolStripMenuItem toolHardware;
        private ToolStripMenuItem toolPeriferico;
        private ToolStripMenuItem toolDependencias;
        private ToolStripMenuItem toolTipos;
        private ToolStripMenuItem toolMarcas;
        private ToolStripMenuItem toolModelos;
        private PictureBox pictureBox1;
    }
}