namespace WinFormsApp1
{
    partial class Tipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tipos));
            btnCerrar = new PictureBox();
            txtFolio = new TextBox();
            label1 = new Label();
            txtDescripcion = new TextBox();
            label2 = new Label();
            boxRefaccion = new ComboBox();
            label3 = new Label();
            btnNuevo = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label4 = new Label();
            label5 = new Label();
            dgvTipos = new DataGridView();
            btnActualizar = new Button();
            btnCerrar2 = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTipos).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.Image = (Image)resources.GetObject("btnCerrar.Image");
            btnCerrar.Location = new Point(552, 12);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(25, 27);
            btnCerrar.SizeMode = PictureBoxSizeMode.StretchImage;
            btnCerrar.TabIndex = 36;
            btnCerrar.TabStop = false;
            // 
            // txtFolio
            // 
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFolio.Location = new Point(140, 54);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(245, 23);
            txtFolio.TabIndex = 44;
            txtFolio.KeyPress += txtFolio_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 47);
            label1.Name = "label1";
            label1.Size = new Size(106, 30);
            label1.TabIndex = 43;
            label1.Text = "NUMERO";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BorderStyle = BorderStyle.FixedSingle;
            txtDescripcion.Font = new Font("Segoe UI", 9F);
            txtDescripcion.Location = new Point(140, 83);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(245, 23);
            txtDescripcion.TabIndex = 46;
            txtDescripcion.TextChanged += txtDescripcion_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(31, 85);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 45;
            label2.Text = "DESCRIPCION";
            // 
            // boxRefaccion
            // 
            boxRefaccion.DropDownStyle = ComboBoxStyle.DropDownList;
            boxRefaccion.FlatStyle = FlatStyle.Popup;
            boxRefaccion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boxRefaccion.FormattingEnabled = true;
            boxRefaccion.Location = new Point(140, 112);
            boxRefaccion.Name = "boxRefaccion";
            boxRefaccion.Size = new Size(245, 23);
            boxRefaccion.TabIndex = 47;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(44, 114);
            label3.Name = "label3";
            label3.Size = new Size(93, 21);
            label3.TabIndex = 48;
            label3.Text = "REFACCION";
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(138, 153);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(89, 23);
            btnNuevo.TabIndex = 49;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(233, 153);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(89, 23);
            btnAceptar.TabIndex = 50;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(328, 153);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 23);
            btnCancelar.TabIndex = 51;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(31, 200);
            label4.Name = "label4";
            label4.Size = new Size(166, 21);
            label4.TabIndex = 52;
            label4.Text = "TIPOS REGISTRADOS";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 221);
            label5.Name = "label5";
            label5.Size = new Size(354, 13);
            label5.TabIndex = 53;
            label5.Text = "SELECCIONE UNO O MAS REGISTROS PARA ACTUALIZAR O ELIMINAR";
            // 
            // dgvTipos
            // 
            dgvTipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipos.Location = new Point(31, 247);
            dgvTipos.Name = "dgvTipos";
            dgvTipos.Size = new Size(528, 150);
            dgvTipos.TabIndex = 54;
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(280, 403);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(89, 23);
            btnActualizar.TabIndex = 57;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar2
            // 
            btnCerrar2.Cursor = Cursors.Hand;
            btnCerrar2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar2.Location = new Point(470, 403);
            btnCerrar2.Name = "btnCerrar2";
            btnCerrar2.Size = new Size(89, 23);
            btnCerrar2.TabIndex = 56;
            btnCerrar2.Text = "CERRAR";
            btnCerrar2.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(375, 403);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(89, 23);
            btnEliminar.TabIndex = 55;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // Tipos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 453);
            Controls.Add(btnActualizar);
            Controls.Add(btnCerrar2);
            Controls.Add(btnEliminar);
            Controls.Add(dgvTipos);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnNuevo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(label3);
            Controls.Add(boxRefaccion);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Controls.Add(txtFolio);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Tipos";
            Text = "Tipos";
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox btnCerrar;
        private TextBox txtFolio;
        private Label label1;
        private TextBox txtDescripcion;
        private Label label2;
        private ComboBox boxRefaccion;
        private Label label3;
        private Button btnNuevo;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label4;
        private Label label5;
        private DataGridView dgvTipos;
        private Button btnActualizar;
        private Button btnCerrar2;
        private Button btnEliminar;
    }
}