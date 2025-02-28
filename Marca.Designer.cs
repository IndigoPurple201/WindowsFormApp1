namespace WinFormsApp1
{
    partial class Marca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Marca));
            btnCerrar = new PictureBox();
            txtFolio = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtMarca = new TextBox();
            btnNuevo = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label3 = new Label();
            dgvMarcas = new DataGridView();
            btnEliminar = new Button();
            panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(559, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(25, 27);
            btnCerrar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnCerrar.TabIndex = 34;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // txtFolio
            // 
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFolio.Location = new Point(133, 67);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(245, 23);
            txtFolio.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 62);
            label1.Name = "label1";
            label1.Size = new Size(106, 30);
            label1.TabIndex = 34;
            label1.Text = "NUMERO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(36, 121);
            label2.Name = "label2";
            label2.Size = new Size(91, 21);
            label2.TabIndex = 36;
            label2.Text = "Descripcion";
            // 
            // txtMarca
            // 
            txtMarca.BorderStyle = BorderStyle.FixedSingle;
            txtMarca.Font = new Font("Segoe UI", 9F);
            txtMarca.Location = new Point(133, 119);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(245, 23);
            txtMarca.TabIndex = 37;
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(99, 168);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(89, 23);
            btnNuevo.TabIndex = 38;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(194, 168);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(89, 23);
            btnAceptar.TabIndex = 39;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(289, 168);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 23);
            btnCancelar.TabIndex = 40;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(36, 228);
            label3.Name = "label3";
            label3.Size = new Size(145, 21);
            label3.TabIndex = 41;
            label3.Text = "Marcas Registradas";
            // 
            // dgvMarcas
            // 
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarcas.Location = new Point(43, 261);
            dgvMarcas.Name = "dgvMarcas";
            dgvMarcas.Size = new Size(522, 150);
            dgvMarcas.TabIndex = 42;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(476, 427);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(89, 23);
            btnEliminar.TabIndex = 43;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // Marca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 471);
            Controls.Add(btnEliminar);
            Controls.Add(dgvMarcas);
            Controls.Add(label3);
            Controls.Add(btnNuevo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txtMarca);
            Controls.Add(label2);
            Controls.Add(txtFolio);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Marca";
            Text = "Marca";
            Load += Marca_Load;
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox btnCerrar;
        private TextBox txtFolio;
        private Label label1;
        private Label label2;
        private TextBox txtMarca;
        private Button btnNuevo;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label3;
        private DataGridView dgvMarcas;
        private Button btnEliminar;
    }
}