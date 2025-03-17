namespace WinFormsApp1
{
    partial class BuscarPerifericos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarPerifericos));
            label4 = new Label();
            panel1 = new Panel();
            radioNumSerie = new RadioButton();
            radioActivo = new RadioButton();
            radioDidecon = new RadioButton();
            radioDepartamento = new RadioButton();
            radioFolio = new RadioButton();
            panelBusqueda = new Panel();
            txtBuscarNumero = new TextBox();
            txtBuscarActivo = new TextBox();
            txtBuscarDidecon = new TextBox();
            label3 = new Label();
            boxBuscarDepartamento = new ComboBox();
            txtBuscarFolio = new TextBox();
            btnBuscar = new Button();
            btnActualizar = new Button();
            btnCerrar2 = new Button();
            btnEliminar = new Button();
            dgvPerifericos = new DataGridView();
            buttonSalir = new PictureBox();
            panel1.SuspendLayout();
            panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPerifericos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(28, 28);
            label4.Name = "label4";
            label4.Size = new Size(180, 15);
            label4.TabIndex = 82;
            label4.Text = "ELIJA UN CAMPO DE BUSQUEDA";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(radioNumSerie);
            panel1.Controls.Add(radioActivo);
            panel1.Controls.Add(radioDidecon);
            panel1.Controls.Add(radioDepartamento);
            panel1.Controls.Add(radioFolio);
            panel1.Location = new Point(29, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 38);
            panel1.TabIndex = 81;
            // 
            // radioNumSerie
            // 
            radioNumSerie.AutoSize = true;
            radioNumSerie.Cursor = Cursors.Hand;
            radioNumSerie.FlatStyle = FlatStyle.System;
            radioNumSerie.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioNumSerie.Location = new Point(456, 8);
            radioNumSerie.Name = "radioNumSerie";
            radioNumSerie.Size = new Size(94, 20);
            radioNumSerie.TabIndex = 4;
            radioNumSerie.TabStop = true;
            radioNumSerie.Text = "NUM SERIE";
            radioNumSerie.UseVisualStyleBackColor = true;
            radioNumSerie.CheckedChanged += radioNumSerie_CheckedChanged;
            // 
            // radioActivo
            // 
            radioActivo.AutoSize = true;
            radioActivo.Cursor = Cursors.Hand;
            radioActivo.FlatStyle = FlatStyle.System;
            radioActivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioActivo.Location = new Point(312, 8);
            radioActivo.Name = "radioActivo";
            radioActivo.Size = new Size(138, 20);
            radioActivo.TabIndex = 3;
            radioActivo.TabStop = true;
            radioActivo.Text = "ATC CONTRALORIA";
            radioActivo.UseVisualStyleBackColor = true;
            radioActivo.CheckedChanged += radioActivo_CheckedChanged;
            // 
            // radioDidecon
            // 
            radioDidecon.AutoSize = true;
            radioDidecon.Cursor = Cursors.Hand;
            radioDidecon.FlatStyle = FlatStyle.System;
            radioDidecon.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioDidecon.Location = new Point(220, 8);
            radioDidecon.Name = "radioDidecon";
            radioDidecon.Size = new Size(84, 20);
            radioDidecon.TabIndex = 2;
            radioDidecon.TabStop = true;
            radioDidecon.Text = "DIDECON";
            radioDidecon.UseVisualStyleBackColor = true;
            radioDidecon.CheckedChanged += radioDidecon_CheckedChanged;
            // 
            // radioDepartamento
            // 
            radioDepartamento.AutoSize = true;
            radioDepartamento.Cursor = Cursors.Hand;
            radioDepartamento.FlatStyle = FlatStyle.System;
            radioDepartamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioDepartamento.Location = new Point(95, 8);
            radioDepartamento.Name = "radioDepartamento";
            radioDepartamento.Size = new Size(124, 20);
            radioDepartamento.TabIndex = 1;
            radioDepartamento.TabStop = true;
            radioDepartamento.Text = "DEPARTAMENTO";
            radioDepartamento.UseVisualStyleBackColor = true;
            radioDepartamento.CheckedChanged += radioDepartamento_CheckedChanged;
            // 
            // radioFolio
            // 
            radioFolio.AutoSize = true;
            radioFolio.Cursor = Cursors.Hand;
            radioFolio.FlatStyle = FlatStyle.System;
            radioFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioFolio.Location = new Point(10, 8);
            radioFolio.Name = "radioFolio";
            radioFolio.Size = new Size(83, 20);
            radioFolio.TabIndex = 0;
            radioFolio.TabStop = true;
            radioFolio.Text = "NUMERO";
            radioFolio.UseVisualStyleBackColor = true;
            radioFolio.CheckedChanged += radioFolio_CheckedChanged;
            // 
            // panelBusqueda
            // 
            panelBusqueda.BorderStyle = BorderStyle.FixedSingle;
            panelBusqueda.Controls.Add(txtBuscarNumero);
            panelBusqueda.Controls.Add(txtBuscarActivo);
            panelBusqueda.Controls.Add(txtBuscarDidecon);
            panelBusqueda.Controls.Add(label3);
            panelBusqueda.Controls.Add(boxBuscarDepartamento);
            panelBusqueda.Controls.Add(txtBuscarFolio);
            panelBusqueda.Location = new Point(29, 96);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(309, 59);
            panelBusqueda.TabIndex = 80;
            // 
            // txtBuscarNumero
            // 
            txtBuscarNumero.Location = new Point(7, 27);
            txtBuscarNumero.Name = "txtBuscarNumero";
            txtBuscarNumero.Size = new Size(291, 23);
            txtBuscarNumero.TabIndex = 88;
            txtBuscarNumero.TextChanged += txtBuscarNumero_TextChanged;
            // 
            // txtBuscarActivo
            // 
            txtBuscarActivo.Location = new Point(7, 27);
            txtBuscarActivo.Name = "txtBuscarActivo";
            txtBuscarActivo.Size = new Size(291, 23);
            txtBuscarActivo.TabIndex = 88;
            txtBuscarActivo.KeyPress += txtBuscarActivo_KeyPress;
            // 
            // txtBuscarDidecon
            // 
            txtBuscarDidecon.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarDidecon.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBuscarDidecon.Location = new Point(7, 27);
            txtBuscarDidecon.Name = "txtBuscarDidecon";
            txtBuscarDidecon.Size = new Size(291, 23);
            txtBuscarDidecon.TabIndex = 78;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 6);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 78;
            // 
            // boxBuscarDepartamento
            // 
            boxBuscarDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            boxBuscarDepartamento.FormattingEnabled = true;
            boxBuscarDepartamento.Location = new Point(7, 27);
            boxBuscarDepartamento.Name = "boxBuscarDepartamento";
            boxBuscarDepartamento.Size = new Size(291, 23);
            boxBuscarDepartamento.TabIndex = 76;
            // 
            // txtBuscarFolio
            // 
            txtBuscarFolio.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarFolio.Location = new Point(7, 27);
            txtBuscarFolio.Name = "txtBuscarFolio";
            txtBuscarFolio.Size = new Size(291, 23);
            txtBuscarFolio.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(344, 96);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(89, 23);
            btnBuscar.TabIndex = 78;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(496, 339);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(89, 23);
            btnActualizar.TabIndex = 86;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar2
            // 
            btnCerrar2.Cursor = Cursors.Hand;
            btnCerrar2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar2.Location = new Point(686, 339);
            btnCerrar2.Name = "btnCerrar2";
            btnCerrar2.Size = new Size(89, 23);
            btnCerrar2.TabIndex = 85;
            btnCerrar2.Text = "CERRAR";
            btnCerrar2.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(591, 339);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(89, 23);
            btnEliminar.TabIndex = 84;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvPerifericos
            // 
            dgvPerifericos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPerifericos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPerifericos.Location = new Point(28, 173);
            dgvPerifericos.Name = "dgvPerifericos";
            dgvPerifericos.Size = new Size(747, 150);
            dgvPerifericos.TabIndex = 83;
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = SystemColors.Control;
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.Image = (Image)resources.GetObject("buttonSalir.Image");
            buttonSalir.Location = new Point(763, 12);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(25, 27);
            buttonSalir.SizeMode = PictureBoxSizeMode.StretchImage;
            buttonSalir.TabIndex = 87;
            buttonSalir.TabStop = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // BuscarPerifericos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 382);
            Controls.Add(buttonSalir);
            Controls.Add(btnActualizar);
            Controls.Add(btnCerrar2);
            Controls.Add(btnEliminar);
            Controls.Add(dgvPerifericos);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(panelBusqueda);
            Controls.Add(btnBuscar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BuscarPerifericos";
            Text = "BuscarPerifericos";
            Load += BuscarPerifericos_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPerifericos).EndInit();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Panel panel1;
        private RadioButton radioNumSerie;
        private RadioButton radioActivo;
        private RadioButton radioDidecon;
        private RadioButton radioDepartamento;
        private RadioButton radioFolio;
        private Panel panelBusqueda;
        private TextBox txtBuscarDidecon;
        private Label label3;
        private ComboBox boxBuscarDepartamento;
        private TextBox txtBuscarFolio;
        private Button btnBuscar;
        private Button btnActualizar;
        private Button btnCerrar2;
        private Button btnEliminar;
        private DataGridView dgvPerifericos;
        private PictureBox buttonSalir;
        private TextBox txtBuscarActivo;
        private TextBox txtBuscarNumero;
    }
}