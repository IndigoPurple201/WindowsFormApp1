namespace WinFormsApp1
{
    partial class Modelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modelo));
            txtModelo = new TextBox();
            label2 = new Label();
            txtFolio = new TextBox();
            label1 = new Label();
            btnNuevo = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label4 = new Label();
            btnActualizar = new Button();
            btnCerrar2 = new Button();
            btnEliminar = new Button();
            dgvModelos = new DataGridView();
            label3 = new Label();
            btnCerrar = new PictureBox();
            label5 = new Label();
            txtMarca = new TextBox();
            label6 = new Label();
            boxTipo = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvModelos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            SuspendLayout();
            // 
            // txtModelo
            // 
            txtModelo.BorderStyle = BorderStyle.FixedSingle;
            txtModelo.Font = new Font("Segoe UI", 9F);
            txtModelo.Location = new Point(134, 102);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(245, 23);
            txtModelo.TabIndex = 41;
            txtModelo.TextChanged += txtModelo_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 104);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 40;
            label2.Text = "DESCRIPCION";
            // 
            // txtFolio
            // 
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFolio.Location = new Point(134, 73);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(245, 23);
            txtFolio.TabIndex = 39;
            txtFolio.KeyPress += txtFolio_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 68);
            label1.Name = "label1";
            label1.Size = new Size(106, 30);
            label1.TabIndex = 38;
            label1.Text = "NUMERO";
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(100, 172);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(89, 23);
            btnNuevo.TabIndex = 42;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(195, 172);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(89, 23);
            btnAceptar.TabIndex = 43;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(290, 172);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 23);
            btnCancelar.TabIndex = 44;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(37, 238);
            label4.Name = "label4";
            label4.Size = new Size(354, 13);
            label4.TabIndex = 52;
            label4.Text = "SELECCIONE UNO O MAS REGISTROS PARA ACTUALIZAR O ELIMINAR";
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(287, 418);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(89, 23);
            btnActualizar.TabIndex = 51;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCerrar2
            // 
            btnCerrar2.Cursor = Cursors.Hand;
            btnCerrar2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar2.Location = new Point(477, 418);
            btnCerrar2.Name = "btnCerrar2";
            btnCerrar2.Size = new Size(89, 23);
            btnCerrar2.TabIndex = 50;
            btnCerrar2.Text = "CERRAR";
            btnCerrar2.UseVisualStyleBackColor = true;
            btnCerrar2.Click += btnCerrar2_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(382, 418);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(89, 23);
            btnEliminar.TabIndex = 49;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvModelos
            // 
            dgvModelos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvModelos.Location = new Point(38, 262);
            dgvModelos.Name = "dgvModelos";
            dgvModelos.Size = new Size(528, 150);
            dgvModelos.TabIndex = 48;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(37, 213);
            label3.Name = "label3";
            label3.Size = new Size(243, 21);
            label3.TabIndex = 47;
            label3.Text = "MODELOS REGISTRADOS PARA";
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(552, 12);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(25, 27);
            btnCerrar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnCerrar.TabIndex = 53;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(62, 44);
            label5.Name = "label5";
            label5.Size = new Size(64, 21);
            label5.TabIndex = 54;
            label5.Text = "MARCA";
            label5.TextAlign = ContentAlignment.TopRight;
            // 
            // txtMarca
            // 
            txtMarca.BorderStyle = BorderStyle.FixedSingle;
            txtMarca.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMarca.Location = new Point(134, 44);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(245, 23);
            txtMarca.TabIndex = 55;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(83, 133);
            label6.Name = "label6";
            label6.Size = new Size(43, 21);
            label6.TabIndex = 56;
            label6.Text = "TIPO";
            // 
            // boxTipo
            // 
            boxTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxTipo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boxTipo.FormattingEnabled = true;
            boxTipo.Location = new Point(134, 131);
            boxTipo.Name = "boxTipo";
            boxTipo.Size = new Size(245, 23);
            boxTipo.TabIndex = 57;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.Location = new Point(277, 213);
            label7.Name = "label7";
            label7.Size = new Size(0, 21);
            label7.TabIndex = 58;
            // 
            // Modelo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 471);
            Controls.Add(label7);
            Controls.Add(boxTipo);
            Controls.Add(label6);
            Controls.Add(txtMarca);
            Controls.Add(label5);
            Controls.Add(btnCerrar);
            Controls.Add(label4);
            Controls.Add(btnActualizar);
            Controls.Add(btnCerrar2);
            Controls.Add(btnEliminar);
            Controls.Add(dgvModelos);
            Controls.Add(label3);
            Controls.Add(btnNuevo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txtModelo);
            Controls.Add(label2);
            Controls.Add(txtFolio);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Modelo";
            Text = "Modelo";
            Load += Modelo_Load;
            ((System.ComponentModel.ISupportInitialize)dgvModelos).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtModelo;
        private Label label2;
        private TextBox txtFolio;
        private Label label1;
        private Button btnNuevo;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label4;
        private Button btnActualizar;
        private Button btnCerrar2;
        private Button btnEliminar;
        private DataGridView dgvModelos;
        private Label label3;
        private PictureBox btnCerrar;
        private Label label5;
        private TextBox txtMarca;
        private Label label6;
        private ComboBox boxTipo;
        private Label label7;
    }
}