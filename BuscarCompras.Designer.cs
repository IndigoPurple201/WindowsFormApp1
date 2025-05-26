namespace WinFormsApp1
{
    partial class BuscarCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarCompras));
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvBuscarCompras = new System.Windows.Forms.DataGridView();
            this.buttonSalir = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(622, 265);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 29);
            this.btnActualizar.TabIndex = 113;
            this.btnActualizar.Text = "SELECCIONAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvBuscarCompras
            // 
            this.dgvBuscarCompras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvBuscarCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarCompras.Location = new System.Drawing.Point(14, 51);
            this.dgvBuscarCompras.Name = "dgvBuscarCompras";
            this.dgvBuscarCompras.Size = new System.Drawing.Size(708, 198);
            this.dgvBuscarCompras.TabIndex = 112;
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalir.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalir.Image")));
            this.buttonSalir.Location = new System.Drawing.Point(701, 12);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(21, 23);
            this.buttonSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonSalir.TabIndex = 111;
            this.buttonSalir.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 21);
            this.label4.TabIndex = 114;
            this.label4.Text = "ELIJA UN REGISTRO DE COMPRA";
            // 
            // BuscarCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 309);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvBuscarCompras);
            this.Controls.Add(this.buttonSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuscarCompras";
            this.Text = "BuscarCompras";
            this.Load += new System.EventHandler(this.BuscarCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnActualizar;
        private DataGridView dgvBuscarCompras;
        private PictureBox buttonSalir;
        private Label label4;
    }
}