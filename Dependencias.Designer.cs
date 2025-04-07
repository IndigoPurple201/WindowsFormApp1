namespace WinFormsApp1
{
    partial class Dependencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dependencias));
            btnCerrar = new PictureBox();
            btnNuevo = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtDepartamento = new TextBox();
            label2 = new Label();
            txtFolio = new TextBox();
            label1 = new Label();
            label4 = new Label();
            dgvDependencias = new DataGridView();
            label3 = new Label();
            btnActualizar = new Button();
            btnCerrar2 = new Button();
            btnEliminar = new Button();
            btnImprimir = new Button();
            ((System.ComponentModel.ISupportInitialize)btnCerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDependencias).BeginInit();
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
            btnCerrar.TabIndex = 35;
            btnCerrar.TabStop = false;
            btnCerrar.Click += btnCerrar_Click_1;
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(137, 122);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(89, 23);
            btnNuevo.TabIndex = 45;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(232, 122);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(89, 23);
            btnAceptar.TabIndex = 46;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(327, 122);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 23);
            btnCancelar.TabIndex = 47;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtDepartamento
            // 
            txtDepartamento.BorderStyle = BorderStyle.FixedSingle;
            txtDepartamento.Font = new Font("Segoe UI", 9F);
            txtDepartamento.Location = new Point(139, 81);
            txtDepartamento.Name = "txtDepartamento";
            txtDepartamento.Size = new Size(245, 23);
            txtDepartamento.TabIndex = 44;
            txtDepartamento.TextChanged += txtDepartamento_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 83);
            label2.Name = "label2";
            label2.Size = new Size(109, 21);
            label2.TabIndex = 43;
            label2.Text = "DESCRIPCION";
            // 
            // txtFolio
            // 
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFolio.Location = new Point(139, 52);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(245, 23);
            txtFolio.TabIndex = 42;
            txtFolio.KeyPress += txtFolio_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 45);
            label1.Name = "label1";
            label1.Size = new Size(106, 30);
            label1.TabIndex = 41;
            label1.Text = "NUMERO";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(30, 188);
            label4.Name = "label4";
            label4.Size = new Size(354, 13);
            label4.TabIndex = 50;
            label4.Text = "SELECCIONE UNO O MAS REGISTROS PARA ACTUALIZAR O ELIMINAR";
            // 
            // dgvDependencias
            // 
            dgvDependencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDependencias.Location = new Point(30, 217);
            dgvDependencias.Name = "dgvDependencias";
            dgvDependencias.Size = new Size(528, 150);
            dgvDependencias.TabIndex = 49;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 162);
            label3.Name = "label3";
            label3.Size = new Size(257, 21);
            label3.TabIndex = 48;
            label3.Text = "DEPARTAMENTOS REGISTRADOS";
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(279, 373);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(89, 23);
            btnActualizar.TabIndex = 53;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnCerrar2
            // 
            btnCerrar2.Cursor = Cursors.Hand;
            btnCerrar2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar2.Location = new Point(469, 373);
            btnCerrar2.Name = "btnCerrar2";
            btnCerrar2.Size = new Size(89, 23);
            btnCerrar2.TabIndex = 52;
            btnCerrar2.Text = "CERRAR";
            btnCerrar2.UseVisualStyleBackColor = true;
            btnCerrar2.Click += btnCerrar2_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(374, 373);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(89, 23);
            btnEliminar.TabIndex = 51;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Cursor = Cursors.Hand;
            btnImprimir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnImprimir.Location = new Point(30, 373);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(89, 23);
            btnImprimir.TabIndex = 54;
            btnImprimir.Text = "IMPRIMIR";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // Dependencias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 417);
            Controls.Add(btnImprimir);
            Controls.Add(btnActualizar);
            Controls.Add(btnCerrar2);
            Controls.Add(btnEliminar);
            Controls.Add(label4);
            Controls.Add(dgvDependencias);
            Controls.Add(label3);
            Controls.Add(btnNuevo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(txtDepartamento);
            Controls.Add(label2);
            Controls.Add(txtFolio);
            Controls.Add(label1);
            Controls.Add(btnCerrar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dependencias";
            Text = "Dependencias";
            Load += Dependencias_Load;
            ((System.ComponentModel.ISupportInitialize)btnCerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDependencias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox btnCerrar;
        private Button btnNuevo;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtDepartamento;
        private Label label2;
        private TextBox txtFolio;
        private Label label1;
        private Label label4;
        private DataGridView dgvDependencias;
        private Label label3;
        private Button btnActualizar;
        private Button btnCerrar2;
        private Button btnEliminar;
        private Button btnImprimir;
    }
}