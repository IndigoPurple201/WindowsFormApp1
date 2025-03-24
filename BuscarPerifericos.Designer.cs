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
            panel1 = new Panel();
            radioPerifericos = new RadioButton();
            radioActivoCPU = new RadioButton();
            radioDirIP = new RadioButton();
            radioDepartamentoCPU = new RadioButton();
            radioNumeroCPU = new RadioButton();
            radioNumSerie = new RadioButton();
            radioActivo = new RadioButton();
            radioDidecon = new RadioButton();
            radioDepartamento = new RadioButton();
            radioFolio = new RadioButton();
            panelBusqueda = new Panel();
            boxBuscarTipo = new ComboBox();
            boxBuscarMarca = new ComboBox();
            txtBuscarActivoCPU = new TextBox();
            txtBuscarDirCPU = new TextBox();
            boxBuscarDepartmanentoCPU = new ComboBox();
            txtBuscarFolioCPU = new TextBox();
            txtBuscarNumero = new TextBox();
            txtBuscarActivo = new TextBox();
            txtBuscarDidecon = new TextBox();
            label3 = new Label();
            boxBuscarDepartamento = new ComboBox();
            txtBuscarFolio = new TextBox();
            btnBuscar = new Button();
            btnCerrar2 = new Button();
            btnEliminar = new Button();
            dgvPerifericos = new DataGridView();
            buttonSalir = new PictureBox();
            label1 = new Label();
            btnActualizar = new Button();
            label4 = new Label();
            panel1.SuspendLayout();
            panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPerifericos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(radioPerifericos);
            panel1.Controls.Add(radioActivoCPU);
            panel1.Controls.Add(radioDirIP);
            panel1.Controls.Add(radioDepartamentoCPU);
            panel1.Controls.Add(radioNumeroCPU);
            panel1.Controls.Add(radioNumSerie);
            panel1.Controls.Add(radioActivo);
            panel1.Controls.Add(radioDidecon);
            panel1.Controls.Add(radioDepartamento);
            panel1.Controls.Add(radioFolio);
            panel1.Location = new Point(29, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 38);
            panel1.TabIndex = 81;
            // 
            // radioPerifericos
            // 
            radioPerifericos.AutoSize = true;
            radioPerifericos.Cursor = Cursors.Hand;
            radioPerifericos.FlatStyle = FlatStyle.System;
            radioPerifericos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioPerifericos.Location = new Point(447, 8);
            radioPerifericos.Name = "radioPerifericos";
            radioPerifericos.Size = new Size(103, 20);
            radioPerifericos.TabIndex = 9;
            radioPerifericos.TabStop = true;
            radioPerifericos.Text = "PERIFERICOS";
            radioPerifericos.UseVisualStyleBackColor = true;
            radioPerifericos.CheckedChanged += radioPerifericos_CheckedChanged;
            // 
            // radioActivoCPU
            // 
            radioActivoCPU.AutoSize = true;
            radioActivoCPU.Cursor = Cursors.Hand;
            radioActivoCPU.FlatStyle = FlatStyle.System;
            radioActivoCPU.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioActivoCPU.Location = new Point(310, 8);
            radioActivoCPU.Name = "radioActivoCPU";
            radioActivoCPU.Size = new Size(138, 20);
            radioActivoCPU.TabIndex = 8;
            radioActivoCPU.TabStop = true;
            radioActivoCPU.Text = "ATC CONTRALORIA";
            radioActivoCPU.UseVisualStyleBackColor = true;
            radioActivoCPU.CheckedChanged += radioActivoCPU_CheckedChanged;
            // 
            // radioDirIP
            // 
            radioDirIP.AutoSize = true;
            radioDirIP.Cursor = Cursors.Hand;
            radioDirIP.FlatStyle = FlatStyle.System;
            radioDirIP.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioDirIP.Location = new Point(220, 8);
            radioDirIP.Name = "radioDirIP";
            radioDirIP.Size = new Size(69, 20);
            radioDirIP.TabIndex = 7;
            radioDirIP.TabStop = true;
            radioDirIP.Text = "DIR. IP";
            radioDirIP.UseVisualStyleBackColor = true;
            radioDirIP.CheckedChanged += radioDirIP_CheckedChanged; 
            // 
            // radioDepartamentoCPU
            // 
            radioDepartamentoCPU.AutoSize = true;
            radioDepartamentoCPU.Cursor = Cursors.Hand;
            radioDepartamentoCPU.FlatStyle = FlatStyle.System;
            radioDepartamentoCPU.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioDepartamentoCPU.Location = new Point(90, 8);
            radioDepartamentoCPU.Name = "radioDepartamentoCPU";
            radioDepartamentoCPU.Size = new Size(124, 20);
            radioDepartamentoCPU.TabIndex = 6;
            radioDepartamentoCPU.TabStop = true;
            radioDepartamentoCPU.Text = "DEPARTAMENTO";
            radioDepartamentoCPU.UseVisualStyleBackColor = true;
            radioDepartamentoCPU.CheckedChanged += radioDepartamentoCPU_CheckedChanged;
            // 
            // radioNumeroCPU
            // 
            radioNumeroCPU.AutoSize = true;
            radioNumeroCPU.Cursor = Cursors.Hand;
            radioNumeroCPU.FlatStyle = FlatStyle.System;
            radioNumeroCPU.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioNumeroCPU.Location = new Point(7, 8);
            radioNumeroCPU.Name = "radioNumeroCPU";
            radioNumeroCPU.Size = new Size(83, 20);
            radioNumeroCPU.TabIndex = 5;
            radioNumeroCPU.TabStop = true;
            radioNumeroCPU.Text = "NUMERO";
            radioNumeroCPU.UseVisualStyleBackColor = true;
            radioNumeroCPU.CheckedChanged += radioNumeroCPU_CheckedChanged;
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
            //radioActivo.CheckedChanged += radioActivo_CheckedChanged;
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
            panelBusqueda.Controls.Add(boxBuscarTipo);
            panelBusqueda.Controls.Add(boxBuscarMarca);
            panelBusqueda.Controls.Add(txtBuscarActivoCPU);
            panelBusqueda.Controls.Add(txtBuscarDirCPU);
            panelBusqueda.Controls.Add(boxBuscarDepartmanentoCPU);
            panelBusqueda.Controls.Add(txtBuscarFolioCPU);
            panelBusqueda.Controls.Add(txtBuscarNumero);
            panelBusqueda.Controls.Add(txtBuscarActivo);
            panelBusqueda.Controls.Add(txtBuscarDidecon);
            panelBusqueda.Controls.Add(label3);
            panelBusqueda.Controls.Add(boxBuscarDepartamento);
            panelBusqueda.Controls.Add(txtBuscarFolio);
            panelBusqueda.Location = new Point(29, 86);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(309, 59);
            panelBusqueda.TabIndex = 80;
            // 
            // boxBuscarTipo
            // 
            boxBuscarTipo.FormattingEnabled = true;
            boxBuscarTipo.Location = new Point(176, 27);
            boxBuscarTipo.Name = "boxBuscarTipo";
            boxBuscarTipo.Size = new Size(121, 23);
            boxBuscarTipo.TabIndex = 92;
            // 
            // boxBuscarMarca
            // 
            boxBuscarMarca.FormattingEnabled = true;
            boxBuscarMarca.Location = new Point(10, 27);
            boxBuscarMarca.Name = "boxBuscarMarca";
            boxBuscarMarca.Size = new Size(121, 23);
            boxBuscarMarca.TabIndex = 90;
            // 
            // txtBuscarActivoCPU
            // 
            txtBuscarActivoCPU.Location = new Point(8, 27);
            txtBuscarActivoCPU.Name = "txtBuscarActivoCPU";
            txtBuscarActivoCPU.Size = new Size(291, 23);
            txtBuscarActivoCPU.TabIndex = 91;
            // 
            // txtBuscarDirCPU
            // 
            txtBuscarDirCPU.Location = new Point(7, 27);
            txtBuscarDirCPU.Name = "txtBuscarDirCPU";
            txtBuscarDirCPU.Size = new Size(291, 23);
            txtBuscarDirCPU.TabIndex = 90;
            // 
            // boxBuscarDepartmanentoCPU
            // 
            boxBuscarDepartmanentoCPU.FormattingEnabled = true;
            boxBuscarDepartmanentoCPU.Location = new Point(7, 27);
            boxBuscarDepartmanentoCPU.Name = "boxBuscarDepartmanentoCPU";
            boxBuscarDepartmanentoCPU.Size = new Size(290, 23);
            boxBuscarDepartmanentoCPU.TabIndex = 90;
            // 
            // txtBuscarFolioCPU
            // 
            txtBuscarFolioCPU.Location = new Point(6, 26);
            txtBuscarFolioCPU.Name = "txtBuscarFolioCPU";
            txtBuscarFolioCPU.Size = new Size(291, 23);
            txtBuscarFolioCPU.TabIndex = 89;
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
            txtBuscarDidecon.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
            btnBuscar.Location = new Point(344, 86);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(89, 23);
            btnBuscar.TabIndex = 78;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCerrar2
            // 
            btnCerrar2.Cursor = Cursors.Hand;
            btnCerrar2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar2.Location = new Point(686, 349);
            btnCerrar2.Name = "btnCerrar2";
            btnCerrar2.Size = new Size(89, 23);
            btnCerrar2.TabIndex = 85;
            btnCerrar2.Text = "CERRAR";
            btnCerrar2.UseVisualStyleBackColor = true;
            btnCerrar2.Click += btnCerrar2_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(591, 349);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(89, 23);
            btnEliminar.TabIndex = 84;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvPerifericos
            // 
            dgvPerifericos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvPerifericos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPerifericos.Location = new Point(28, 188);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 161);
            label1.Name = "label1";
            label1.Size = new Size(354, 13);
            label1.TabIndex = 88;
            label1.Text = "SELECCIONE UNO O MAS REGISTROS PARA ACTUALIZAR O ELIMINAR";
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(496, 349);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(89, 23);
            btnActualizar.TabIndex = 89;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(28, 18);
            label4.Name = "label4";
            label4.Size = new Size(180, 15);
            label4.TabIndex = 82;
            label4.Text = "ELIJA UN CAMPO DE BUSQUEDA";
            // 
            // BuscarPerifericos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 382);
            Controls.Add(btnActualizar);
            Controls.Add(label1);
            Controls.Add(buttonSalir);
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
        private Button btnCerrar2;
        private Button btnEliminar;
        private DataGridView dgvPerifericos;
        private PictureBox buttonSalir;
        private TextBox txtBuscarActivo;
        private TextBox txtBuscarNumero;
        private Label label1;
        private Button btnActualizar;
        private Label label4;
        private RadioButton radioNumeroCPU;
        private RadioButton radioPerifericos;
        private RadioButton radioActivoCPU;
        private RadioButton radioDirIP;
        private RadioButton radioDepartamentoCPU;
        private TextBox txtBuscarActivoCPU;
        private TextBox txtBuscarDirCPU;
        private ComboBox boxBuscarDepartmanentoCPU;
        private TextBox txtBuscarFolioCPU;
        private ComboBox boxBuscarTipo;
        private ComboBox boxBuscarMarca;
    }
}