namespace WinFormsApp1
{
    partial class CambiarPerifericos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambiarPerifericos));
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscar2 = new System.Windows.Forms.Button();
            this.txtBuscarActivo2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar1 = new System.Windows.Forms.Button();
            this.txtBuscarActivo1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvPerifericos1 = new System.Windows.Forms.DataGridView();
            this.pbFlechaDerecha = new System.Windows.Forms.PictureBox();
            this.buttonSalir = new System.Windows.Forms.PictureBox();
            this.pbFlechaIzquierda = new System.Windows.Forms.PictureBox();
            this.dgvPerifericos2 = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerifericos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlechaDerecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlechaIzquierda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerifericos2)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 15);
            this.label4.TabIndex = 83;
            this.label4.Text = "ACTIVOS DE EQUIPOS";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnBuscar2);
            this.panel1.Controls.Add(this.txtBuscarActivo2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnBuscar1);
            this.panel1.Controls.Add(this.txtBuscarActivo1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(17, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 33);
            this.panel1.TabIndex = 84;
            // 
            // btnBuscar2
            // 
            this.btnBuscar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar2.Location = new System.Drawing.Point(609, 4);
            this.btnBuscar2.Name = "btnBuscar2";
            this.btnBuscar2.Size = new System.Drawing.Size(36, 23);
            this.btnBuscar2.TabIndex = 96;
            this.btnBuscar2.Text = "...";
            this.btnBuscar2.UseVisualStyleBackColor = true;
            this.btnBuscar2.Click += new System.EventHandler(this.btnBuscar2_Click);
            // 
            // txtBuscarActivo2
            // 
            this.txtBuscarActivo2.Location = new System.Drawing.Point(487, 5);
            this.txtBuscarActivo2.Name = "txtBuscarActivo2";
            this.txtBuscarActivo2.Size = new System.Drawing.Size(116, 20);
            this.txtBuscarActivo2.TabIndex = 95;
            this.txtBuscarActivo2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarActivo2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(378, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 94;
            this.label2.Text = "ACTIVO EQUIPO 2";
            // 
            // btnBuscar1
            // 
            this.btnBuscar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar1.Location = new System.Drawing.Point(238, 5);
            this.btnBuscar1.Name = "btnBuscar1";
            this.btnBuscar1.Size = new System.Drawing.Size(36, 23);
            this.btnBuscar1.TabIndex = 85;
            this.btnBuscar1.Text = "...";
            this.btnBuscar1.UseVisualStyleBackColor = true;
            this.btnBuscar1.Click += new System.EventHandler(this.btnBuscar1_Click);
            // 
            // txtBuscarActivo1
            // 
            this.txtBuscarActivo1.Location = new System.Drawing.Point(116, 6);
            this.txtBuscarActivo1.Name = "txtBuscarActivo1";
            this.txtBuscarActivo1.Size = new System.Drawing.Size(116, 20);
            this.txtBuscarActivo1.TabIndex = 92;
            this.txtBuscarActivo1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarActivo1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 85;
            this.label1.Text = "ACTIVO EQUIPO 1";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(686, 45);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(79, 22);
            this.btnBuscar.TabIndex = 85;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvPerifericos1
            // 
            this.dgvPerifericos1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerifericos1.Location = new System.Drawing.Point(17, 89);
            this.dgvPerifericos1.Name = "dgvPerifericos1";
            this.dgvPerifericos1.Size = new System.Drawing.Size(403, 226);
            this.dgvPerifericos1.TabIndex = 89;
            // 
            // pbFlechaDerecha
            // 
            this.pbFlechaDerecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFlechaDerecha.Image = ((System.Drawing.Image)(resources.GetObject("pbFlechaDerecha.Image")));
            this.pbFlechaDerecha.Location = new System.Drawing.Point(433, 165);
            this.pbFlechaDerecha.Name = "pbFlechaDerecha";
            this.pbFlechaDerecha.Size = new System.Drawing.Size(45, 33);
            this.pbFlechaDerecha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFlechaDerecha.TabIndex = 91;
            this.pbFlechaDerecha.TabStop = false;
            this.pbFlechaDerecha.Click += new System.EventHandler(this.pbFlechaDerecha_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalir.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalir.Image")));
            this.buttonSalir.Location = new System.Drawing.Point(886, 9);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(21, 23);
            this.buttonSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonSalir.TabIndex = 88;
            this.buttonSalir.TabStop = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // pbFlechaIzquierda
            // 
            this.pbFlechaIzquierda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFlechaIzquierda.Image = ((System.Drawing.Image)(resources.GetObject("pbFlechaIzquierda.Image")));
            this.pbFlechaIzquierda.Location = new System.Drawing.Point(433, 204);
            this.pbFlechaIzquierda.Name = "pbFlechaIzquierda";
            this.pbFlechaIzquierda.Size = new System.Drawing.Size(45, 33);
            this.pbFlechaIzquierda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFlechaIzquierda.TabIndex = 92;
            this.pbFlechaIzquierda.TabStop = false;
            this.pbFlechaIzquierda.Click += new System.EventHandler(this.pbFlechaIzquierda_Click);
            // 
            // dgvPerifericos2
            // 
            this.dgvPerifericos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerifericos2.Location = new System.Drawing.Point(489, 89);
            this.dgvPerifericos2.Name = "dgvPerifericos2";
            this.dgvPerifericos2.Size = new System.Drawing.Size(403, 226);
            this.dgvPerifericos2.TabIndex = 93;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(734, 321);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(74, 25);
            this.btnAceptar.TabIndex = 94;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(814, 321);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 25);
            this.btnCancelar.TabIndex = 95;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CambiarPerifericos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 350);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvPerifericos2);
            this.Controls.Add(this.pbFlechaIzquierda);
            this.Controls.Add(this.pbFlechaDerecha);
            this.Controls.Add(this.dgvPerifericos1);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CambiarPerifericos";
            this.Text = "CambiarPerifericos";
            this.Load += new System.EventHandler(this.CambiarPerifericos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerifericos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlechaDerecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFlechaIzquierda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerifericos2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label4;
        private Panel panel1;
        private Label label1;
        private Button btnBuscar1;
        private TextBox txtBuscarActivo1;
        private TextBox txtBuscarActivo2;
        private Label label2;
        private Button btnBuscar;
        private PictureBox buttonSalir;
        private DataGridView dgvPerifericos1;
        private PictureBox pbFlechaDerecha;
        private PictureBox pbFlechaIzquierda;
        private DataGridView dgvPerifericos2;
        private Button btnBuscar2;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}