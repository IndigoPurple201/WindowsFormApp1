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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuInventario = new System.Windows.Forms.ToolStripMenuItem();
            this.toolHardware = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPeriferico = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDependencias = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolModelos = new System.Windows.Forms.ToolStripMenuItem();
            this.pROVEEDORESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuServicios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInventario,
            this.menuCatalogos,
            this.menuReportes,
            this.menuServicios,
            this.menuSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(1370, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuInventario
            // 
            this.menuInventario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolHardware,
            this.toolPeriferico,
            this.toolCompras});
            this.menuInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuInventario.Name = "menuInventario";
            this.menuInventario.Size = new System.Drawing.Size(119, 25);
            this.menuInventario.Text = "INVENTARIO";
            // 
            // toolHardware
            // 
            this.toolHardware.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolHardware.Name = "toolHardware";
            this.toolHardware.Size = new System.Drawing.Size(152, 22);
            this.toolHardware.Text = "HARDWARE";
            this.toolHardware.Click += new System.EventHandler(this.toolHardware_Click);
            // 
            // toolPeriferico
            // 
            this.toolPeriferico.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolPeriferico.Name = "toolPeriferico";
            this.toolPeriferico.Size = new System.Drawing.Size(152, 22);
            this.toolPeriferico.Text = "PERIFERICOS";
            this.toolPeriferico.Click += new System.EventHandler(this.toolPeriferico_Click);
            // 
            // toolCompras
            // 
            this.toolCompras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolCompras.Name = "toolCompras";
            this.toolCompras.Size = new System.Drawing.Size(152, 22);
            this.toolCompras.Text = "COMPRAS";
            this.toolCompras.Click += new System.EventHandler(this.toolCompras_Click);
            // 
            // menuCatalogos
            // 
            this.menuCatalogos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolDependencias,
            this.toolMarcas,
            this.toolModelos,
            this.pROVEEDORESToolStripMenuItem});
            this.menuCatalogos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuCatalogos.Name = "menuCatalogos";
            this.menuCatalogos.Size = new System.Drawing.Size(113, 25);
            this.menuCatalogos.Text = "CATALOGOS";
            // 
            // toolDependencias
            // 
            this.toolDependencias.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolDependencias.Name = "toolDependencias";
            this.toolDependencias.Size = new System.Drawing.Size(170, 22);
            this.toolDependencias.Text = "DEPENDENCIAS";
            this.toolDependencias.Click += new System.EventHandler(this.toolDependencias_Click);
            // 
            // toolMarcas
            // 
            this.toolMarcas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolMarcas.Name = "toolMarcas";
            this.toolMarcas.Size = new System.Drawing.Size(170, 22);
            this.toolMarcas.Text = "MARCAS";
            this.toolMarcas.Click += new System.EventHandler(this.toolMarca_Click);
            // 
            // toolModelos
            // 
            this.toolModelos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolModelos.Name = "toolModelos";
            this.toolModelos.Size = new System.Drawing.Size(170, 22);
            this.toolModelos.Text = "MODELOS";
            this.toolModelos.Click += new System.EventHandler(this.toolModelo_Click);
            // 
            // pROVEEDORESToolStripMenuItem
            // 
            this.pROVEEDORESToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pROVEEDORESToolStripMenuItem.Name = "pROVEEDORESToolStripMenuItem";
            this.pROVEEDORESToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.pROVEEDORESToolStripMenuItem.Text = "PROVEEDORES";
            this.pROVEEDORESToolStripMenuItem.Click += new System.EventHandler(this.pROVEEDORESToolStripMenuItem_Click);
            // 
            // menuReportes
            // 
            this.menuReportes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(100, 25);
            this.menuReportes.Text = "REPORTES";
            this.menuReportes.Click += new System.EventHandler(this.menuReporte_Click);
            // 
            // menuServicios
            // 
            this.menuServicios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.menuServicios.Name = "menuServicios";
            this.menuServicios.Size = new System.Drawing.Size(102, 25);
            this.menuServicios.Text = "SERVICIOS";
            this.menuServicios.Click += new System.EventHandler(this.menuServicios_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(65, 25);
            this.menuSalir.Text = "SALIR";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinFormsApp1.Properties.Resources.escudo;
            this.pictureBox1.Location = new System.Drawing.Point(64, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1144, 525);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "MENU";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private ToolStripMenuItem toolMarcas;
        private ToolStripMenuItem toolModelos;
        private PictureBox pictureBox1;
        private ToolStripMenuItem menuServicios;
        private ToolStripMenuItem toolCompras;
        private ToolStripMenuItem pROVEEDORESToolStripMenuItem;
    }
}