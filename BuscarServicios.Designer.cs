namespace WinFormsApp1
{
    partial class BuscarServicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarServicios));
            this.buttonSalir = new System.Windows.Forms.PictureBox();
            this.dgvServicios = new System.Windows.Forms.DataGridView();
            this.boxDepartamento = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.radioCpu = new System.Windows.Forms.RadioButton();
            this.radioPeriferico = new System.Windows.Forms.RadioButton();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalir.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalir.Image")));
            this.buttonSalir.Location = new System.Drawing.Point(699, 10);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(21, 23);
            this.buttonSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonSalir.TabIndex = 88;
            this.buttonSalir.TabStop = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // dgvServicios
            // 
            this.dgvServicios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicios.Location = new System.Drawing.Point(12, 92);
            this.dgvServicios.Name = "dgvServicios";
            this.dgvServicios.Size = new System.Drawing.Size(708, 198);
            this.dgvServicios.TabIndex = 93;
            // 
            // boxDepartamento
            // 
            this.boxDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxDepartamento.FormattingEnabled = true;
            this.boxDepartamento.Location = new System.Drawing.Point(12, 35);
            this.boxDepartamento.Name = "boxDepartamento";
            this.boxDepartamento.Size = new System.Drawing.Size(226, 21);
            this.boxDepartamento.TabIndex = 94;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(244, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(82, 23);
            this.btnBuscar.TabIndex = 95;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // radioCpu
            // 
            this.radioCpu.AutoSize = true;
            this.radioCpu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioCpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCpu.Location = new System.Drawing.Point(12, 64);
            this.radioCpu.Name = "radioCpu";
            this.radioCpu.Size = new System.Drawing.Size(50, 17);
            this.radioCpu.TabIndex = 108;
            this.radioCpu.TabStop = true;
            this.radioCpu.Text = "CPU";
            this.radioCpu.UseVisualStyleBackColor = true;
            this.radioCpu.CheckedChanged += new System.EventHandler(this.radioCpu_CheckedChanged);
            // 
            // radioPeriferico
            // 
            this.radioPeriferico.AutoSize = true;
            this.radioPeriferico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioPeriferico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPeriferico.Location = new System.Drawing.Point(76, 64);
            this.radioPeriferico.Name = "radioPeriferico";
            this.radioPeriferico.Size = new System.Drawing.Size(99, 17);
            this.radioPeriferico.TabIndex = 109;
            this.radioPeriferico.TabStop = true;
            this.radioPeriferico.Text = "PERIFERICO";
            this.radioPeriferico.UseVisualStyleBackColor = true;
            this.radioPeriferico.CheckedChanged += new System.EventHandler(this.radioPeriferico_CheckedChanged);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(620, 296);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 29);
            this.btnActualizar.TabIndex = 110;
            this.btnActualizar.Text = "SELECCIONAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 15);
            this.label4.TabIndex = 111;
            this.label4.Text = "ELIJA UN DEPARTAMENTO";
            // 
            // BuscarServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 339);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.radioPeriferico);
            this.Controls.Add(this.radioCpu);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.boxDepartamento);
            this.Controls.Add(this.dgvServicios);
            this.Controls.Add(this.buttonSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuscarServicios";
            this.Text = "BuscarServicios";
            this.Load += new System.EventHandler(this.BuscarServicios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox buttonSalir;
        private DataGridView dgvServicios;
        private ComboBox boxDepartamento;
        private Button btnBuscar;
        private RadioButton radioCpu;
        private RadioButton radioPeriferico;
        private Button btnActualizar;
        private Label label4;
    }
}