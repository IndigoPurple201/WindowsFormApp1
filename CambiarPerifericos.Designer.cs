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
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.buttonSalir = new System.Windows.Forms.PictureBox();
            this.picture2 = new System.Windows.Forms.PictureBox();
            this.dgvPerifericos2 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerifericos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(704, 33);
            this.panel1.TabIndex = 84;
            // 
            // btnBuscar2
            // 
            this.btnBuscar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar2.Location = new System.Drawing.Point(656, 4);
            this.btnBuscar2.Name = "btnBuscar2";
            this.btnBuscar2.Size = new System.Drawing.Size(36, 23);
            this.btnBuscar2.TabIndex = 96;
            this.btnBuscar2.Text = "...";
            this.btnBuscar2.UseVisualStyleBackColor = true;
            // 
            // txtBuscarActivo2
            // 
            this.txtBuscarActivo2.Location = new System.Drawing.Point(556, 5);
            this.txtBuscarActivo2.Name = "txtBuscarActivo2";
            this.txtBuscarActivo2.Size = new System.Drawing.Size(94, 20);
            this.txtBuscarActivo2.TabIndex = 95;
            this.txtBuscarActivo2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarActivo2_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(447, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 94;
            this.label2.Text = "ACTIVO EQUIPO 2";
            // 
            // btnBuscar1
            // 
            this.btnBuscar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar1.Location = new System.Drawing.Point(216, 3);
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
            this.txtBuscarActivo1.Size = new System.Drawing.Size(94, 20);
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
            this.btnBuscar.Location = new System.Drawing.Point(727, 43);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(77, 25);
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
            // picture1
            // 
            this.picture1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture1.Image = ((System.Drawing.Image)(resources.GetObject("picture1.Image")));
            this.picture1.Location = new System.Drawing.Point(433, 165);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(45, 33);
            this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture1.TabIndex = 91;
            this.picture1.TabStop = false;
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalir.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalir.Image")));
            this.buttonSalir.Location = new System.Drawing.Point(868, 10);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(21, 23);
            this.buttonSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonSalir.TabIndex = 88;
            this.buttonSalir.TabStop = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // picture2
            // 
            this.picture2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture2.Image = ((System.Drawing.Image)(resources.GetObject("picture2.Image")));
            this.picture2.Location = new System.Drawing.Point(433, 204);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(45, 33);
            this.picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture2.TabIndex = 92;
            this.picture2.TabStop = false;
            // 
            // dgvPerifericos2
            // 
            this.dgvPerifericos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerifericos2.Location = new System.Drawing.Point(489, 89);
            this.dgvPerifericos2.Name = "dgvPerifericos2";
            this.dgvPerifericos2.Size = new System.Drawing.Size(403, 226);
            this.dgvPerifericos2.TabIndex = 93;
            // 
            // CambiarPerifericos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 350);
            this.Controls.Add(this.dgvPerifericos2);
            this.Controls.Add(this.picture2);
            this.Controls.Add(this.picture1);
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
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
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
        private PictureBox picture1;
        private PictureBox picture2;
        private DataGridView dgvPerifericos2;
        private Button btnBuscar2;
    }
}