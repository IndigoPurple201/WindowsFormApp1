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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioPerifericos = new System.Windows.Forms.RadioButton();
            this.radioActivoCPU = new System.Windows.Forms.RadioButton();
            this.radioDirIP = new System.Windows.Forms.RadioButton();
            this.radioDepartamentoCPU = new System.Windows.Forms.RadioButton();
            this.radioNumeroCPU = new System.Windows.Forms.RadioButton();
            this.radioNumSerie = new System.Windows.Forms.RadioButton();
            this.radioActivo = new System.Windows.Forms.RadioButton();
            this.radioDidecon = new System.Windows.Forms.RadioButton();
            this.radioDepartamento = new System.Windows.Forms.RadioButton();
            this.radioFolio = new System.Windows.Forms.RadioButton();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.boxBuscarTipo = new System.Windows.Forms.ComboBox();
            this.txtBuscarActivoCPU = new System.Windows.Forms.TextBox();
            this.txtBuscarDirCPU = new System.Windows.Forms.TextBox();
            this.boxBuscarMarca = new System.Windows.Forms.ComboBox();
            this.boxBuscarDepartmanentoCPU = new System.Windows.Forms.ComboBox();
            this.txtBuscarFolioCPU = new System.Windows.Forms.TextBox();
            this.txtBuscarNumero = new System.Windows.Forms.TextBox();
            this.txtBuscarActivo = new System.Windows.Forms.TextBox();
            this.txtBuscarDidecon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxBuscarDepartamento = new System.Windows.Forms.ComboBox();
            this.txtBuscarFolio = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCerrar2 = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvPerifericos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSalir = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerifericos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioPerifericos);
            this.panel1.Controls.Add(this.radioActivoCPU);
            this.panel1.Controls.Add(this.radioDirIP);
            this.panel1.Controls.Add(this.radioDepartamentoCPU);
            this.panel1.Controls.Add(this.radioNumeroCPU);
            this.panel1.Controls.Add(this.radioNumSerie);
            this.panel1.Controls.Add(this.radioActivo);
            this.panel1.Controls.Add(this.radioDidecon);
            this.panel1.Controls.Add(this.radioDepartamento);
            this.panel1.Controls.Add(this.radioFolio);
            this.panel1.Location = new System.Drawing.Point(25, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 33);
            this.panel1.TabIndex = 81;
            // 
            // radioPerifericos
            // 
            this.radioPerifericos.AutoSize = true;
            this.radioPerifericos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioPerifericos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioPerifericos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioPerifericos.Location = new System.Drawing.Point(445, 9);
            this.radioPerifericos.Name = "radioPerifericos";
            this.radioPerifericos.Size = new System.Drawing.Size(103, 20);
            this.radioPerifericos.TabIndex = 9;
            this.radioPerifericos.TabStop = true;
            this.radioPerifericos.Text = "PERIFERICOS";
            this.radioPerifericos.UseVisualStyleBackColor = true;
            this.radioPerifericos.CheckedChanged += new System.EventHandler(this.radioPerifericos_CheckedChanged);
            // 
            // radioActivoCPU
            // 
            this.radioActivoCPU.AutoSize = true;
            this.radioActivoCPU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioActivoCPU.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioActivoCPU.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioActivoCPU.Location = new System.Drawing.Point(295, 8);
            this.radioActivoCPU.Name = "radioActivoCPU";
            this.radioActivoCPU.Size = new System.Drawing.Size(138, 20);
            this.radioActivoCPU.TabIndex = 8;
            this.radioActivoCPU.TabStop = true;
            this.radioActivoCPU.Text = "ATC CONTRALORIA";
            this.radioActivoCPU.UseVisualStyleBackColor = true;
            this.radioActivoCPU.CheckedChanged += new System.EventHandler(this.radioActivoCPU_CheckedChanged);
            // 
            // radioDirIP
            // 
            this.radioDirIP.AutoSize = true;
            this.radioDirIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioDirIP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioDirIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDirIP.Location = new System.Drawing.Point(211, 8);
            this.radioDirIP.Name = "radioDirIP";
            this.radioDirIP.Size = new System.Drawing.Size(69, 20);
            this.radioDirIP.TabIndex = 7;
            this.radioDirIP.TabStop = true;
            this.radioDirIP.Text = "DIR. IP";
            this.radioDirIP.UseVisualStyleBackColor = true;
            this.radioDirIP.CheckedChanged += new System.EventHandler(this.radioDirIP_CheckedChanged);
            // 
            // radioDepartamentoCPU
            // 
            this.radioDepartamentoCPU.AutoSize = true;
            this.radioDepartamentoCPU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioDepartamentoCPU.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioDepartamentoCPU.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDepartamentoCPU.Location = new System.Drawing.Point(89, 8);
            this.radioDepartamentoCPU.Name = "radioDepartamentoCPU";
            this.radioDepartamentoCPU.Size = new System.Drawing.Size(124, 20);
            this.radioDepartamentoCPU.TabIndex = 6;
            this.radioDepartamentoCPU.TabStop = true;
            this.radioDepartamentoCPU.Text = "DEPARTAMENTO";
            this.radioDepartamentoCPU.UseVisualStyleBackColor = true;
            this.radioDepartamentoCPU.CheckedChanged += new System.EventHandler(this.radioDepartamentoCPU_CheckedChanged);
            // 
            // radioNumeroCPU
            // 
            this.radioNumeroCPU.AutoSize = true;
            this.radioNumeroCPU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioNumeroCPU.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioNumeroCPU.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNumeroCPU.Location = new System.Drawing.Point(6, 8);
            this.radioNumeroCPU.Name = "radioNumeroCPU";
            this.radioNumeroCPU.Size = new System.Drawing.Size(83, 20);
            this.radioNumeroCPU.TabIndex = 5;
            this.radioNumeroCPU.TabStop = true;
            this.radioNumeroCPU.Text = "NUMERO";
            this.radioNumeroCPU.UseVisualStyleBackColor = true;
            this.radioNumeroCPU.CheckedChanged += new System.EventHandler(this.radioNumeroCPU_CheckedChanged);
            // 
            // radioNumSerie
            // 
            this.radioNumSerie.AutoSize = true;
            this.radioNumSerie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioNumSerie.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioNumSerie.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioNumSerie.Location = new System.Drawing.Point(446, 8);
            this.radioNumSerie.Name = "radioNumSerie";
            this.radioNumSerie.Size = new System.Drawing.Size(94, 20);
            this.radioNumSerie.TabIndex = 4;
            this.radioNumSerie.TabStop = true;
            this.radioNumSerie.Text = "NUM SERIE";
            this.radioNumSerie.UseVisualStyleBackColor = true;
            this.radioNumSerie.CheckedChanged += new System.EventHandler(this.radioNumSerie_CheckedChanged);
            // 
            // radioActivo
            // 
            this.radioActivo.AutoSize = true;
            this.radioActivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioActivo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioActivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioActivo.Location = new System.Drawing.Point(296, 7);
            this.radioActivo.Name = "radioActivo";
            this.radioActivo.Size = new System.Drawing.Size(138, 20);
            this.radioActivo.TabIndex = 3;
            this.radioActivo.TabStop = true;
            this.radioActivo.Text = "ATC CONTRALORIA";
            this.radioActivo.UseVisualStyleBackColor = true;
            this.radioActivo.CheckedChanged += new System.EventHandler(this.radioActivo_CheckedChanged);
            // 
            // radioDidecon
            // 
            this.radioDidecon.AutoSize = true;
            this.radioDidecon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioDidecon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioDidecon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDidecon.Location = new System.Drawing.Point(218, 7);
            this.radioDidecon.Name = "radioDidecon";
            this.radioDidecon.Size = new System.Drawing.Size(84, 20);
            this.radioDidecon.TabIndex = 2;
            this.radioDidecon.TabStop = true;
            this.radioDidecon.Text = "DIDECON";
            this.radioDidecon.UseVisualStyleBackColor = true;
            this.radioDidecon.CheckedChanged += new System.EventHandler(this.radioDidecon_CheckedChanged);
            // 
            // radioDepartamento
            // 
            this.radioDepartamento.AutoSize = true;
            this.radioDepartamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioDepartamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioDepartamento.Location = new System.Drawing.Point(100, 7);
            this.radioDepartamento.Name = "radioDepartamento";
            this.radioDepartamento.Size = new System.Drawing.Size(124, 20);
            this.radioDepartamento.TabIndex = 1;
            this.radioDepartamento.TabStop = true;
            this.radioDepartamento.Text = "DEPARTAMENTO";
            this.radioDepartamento.UseVisualStyleBackColor = true;
            this.radioDepartamento.CheckedChanged += new System.EventHandler(this.radioDepartamento_CheckedChanged);
            // 
            // radioFolio
            // 
            this.radioFolio.AutoSize = true;
            this.radioFolio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioFolio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioFolio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioFolio.Location = new System.Drawing.Point(9, 7);
            this.radioFolio.Name = "radioFolio";
            this.radioFolio.Size = new System.Drawing.Size(83, 20);
            this.radioFolio.TabIndex = 0;
            this.radioFolio.TabStop = true;
            this.radioFolio.Text = "NUMERO";
            this.radioFolio.UseVisualStyleBackColor = true;
            this.radioFolio.CheckedChanged += new System.EventHandler(this.radioFolio_CheckedChanged);
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBusqueda.Controls.Add(this.boxBuscarTipo);
            this.panelBusqueda.Controls.Add(this.txtBuscarActivoCPU);
            this.panelBusqueda.Controls.Add(this.txtBuscarDirCPU);
            this.panelBusqueda.Controls.Add(this.boxBuscarMarca);
            this.panelBusqueda.Controls.Add(this.boxBuscarDepartmanentoCPU);
            this.panelBusqueda.Controls.Add(this.txtBuscarFolioCPU);
            this.panelBusqueda.Controls.Add(this.txtBuscarNumero);
            this.panelBusqueda.Controls.Add(this.txtBuscarActivo);
            this.panelBusqueda.Controls.Add(this.txtBuscarDidecon);
            this.panelBusqueda.Controls.Add(this.label3);
            this.panelBusqueda.Controls.Add(this.boxBuscarDepartamento);
            this.panelBusqueda.Controls.Add(this.txtBuscarFolio);
            this.panelBusqueda.Location = new System.Drawing.Point(25, 77);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(265, 72);
            this.panelBusqueda.TabIndex = 80;
            // 
            // boxBuscarTipo
            // 
            this.boxBuscarTipo.FormattingEnabled = true;
            this.boxBuscarTipo.Location = new System.Drawing.Point(153, 34);
            this.boxBuscarTipo.Name = "boxBuscarTipo";
            this.boxBuscarTipo.Size = new System.Drawing.Size(104, 21);
            this.boxBuscarTipo.TabIndex = 92;
            // 
            // txtBuscarActivoCPU
            // 
            this.txtBuscarActivoCPU.Location = new System.Drawing.Point(7, 33);
            this.txtBuscarActivoCPU.Name = "txtBuscarActivoCPU";
            this.txtBuscarActivoCPU.Size = new System.Drawing.Size(250, 20);
            this.txtBuscarActivoCPU.TabIndex = 91;
            this.txtBuscarActivoCPU.TextChanged += new System.EventHandler(this.txtBuscarActivoCPU_TextChanged);
            this.txtBuscarActivoCPU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarActivoCPU_KeyPress);
            // 
            // txtBuscarDirCPU
            // 
            this.txtBuscarDirCPU.Location = new System.Drawing.Point(6, 33);
            this.txtBuscarDirCPU.Name = "txtBuscarDirCPU";
            this.txtBuscarDirCPU.Size = new System.Drawing.Size(250, 20);
            this.txtBuscarDirCPU.TabIndex = 90;
            this.txtBuscarDirCPU.TextChanged += new System.EventHandler(this.txtBuscarDirCPU_TextChanged);
            this.txtBuscarDirCPU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarDirCPU_KeyPress);
            // 
            // boxBuscarMarca
            // 
            this.boxBuscarMarca.FormattingEnabled = true;
            this.boxBuscarMarca.Location = new System.Drawing.Point(7, 33);
            this.boxBuscarMarca.Name = "boxBuscarMarca";
            this.boxBuscarMarca.Size = new System.Drawing.Size(104, 21);
            this.boxBuscarMarca.TabIndex = 90;
            // 
            // boxBuscarDepartmanentoCPU
            // 
            this.boxBuscarDepartmanentoCPU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxBuscarDepartmanentoCPU.FormattingEnabled = true;
            this.boxBuscarDepartmanentoCPU.Location = new System.Drawing.Point(6, 33);
            this.boxBuscarDepartmanentoCPU.Name = "boxBuscarDepartmanentoCPU";
            this.boxBuscarDepartmanentoCPU.Size = new System.Drawing.Size(249, 21);
            this.boxBuscarDepartmanentoCPU.TabIndex = 90;
            // 
            // txtBuscarFolioCPU
            // 
            this.txtBuscarFolioCPU.Location = new System.Drawing.Point(5, 33);
            this.txtBuscarFolioCPU.Name = "txtBuscarFolioCPU";
            this.txtBuscarFolioCPU.Size = new System.Drawing.Size(250, 20);
            this.txtBuscarFolioCPU.TabIndex = 89;
            this.txtBuscarFolioCPU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarFolioCPU_KeyPress);
            // 
            // txtBuscarNumero
            // 
            this.txtBuscarNumero.Location = new System.Drawing.Point(6, 33);
            this.txtBuscarNumero.Name = "txtBuscarNumero";
            this.txtBuscarNumero.Size = new System.Drawing.Size(250, 20);
            this.txtBuscarNumero.TabIndex = 88;
            this.txtBuscarNumero.TextChanged += new System.EventHandler(this.txtBuscarNumero_TextChanged);
            // 
            // txtBuscarActivo
            // 
            this.txtBuscarActivo.Location = new System.Drawing.Point(6, 33);
            this.txtBuscarActivo.Name = "txtBuscarActivo";
            this.txtBuscarActivo.Size = new System.Drawing.Size(250, 20);
            this.txtBuscarActivo.TabIndex = 88;
            this.txtBuscarActivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarActivo_KeyPress);
            // 
            // txtBuscarDidecon
            // 
            this.txtBuscarDidecon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarDidecon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarDidecon.Location = new System.Drawing.Point(6, 33);
            this.txtBuscarDidecon.Name = "txtBuscarDidecon";
            this.txtBuscarDidecon.Size = new System.Drawing.Size(250, 23);
            this.txtBuscarDidecon.TabIndex = 78;
            this.txtBuscarDidecon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDidecon_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 78;
            // 
            // boxBuscarDepartamento
            // 
            this.boxBuscarDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxBuscarDepartamento.FormattingEnabled = true;
            this.boxBuscarDepartamento.Location = new System.Drawing.Point(6, 33);
            this.boxBuscarDepartamento.Name = "boxBuscarDepartamento";
            this.boxBuscarDepartamento.Size = new System.Drawing.Size(250, 21);
            this.boxBuscarDepartamento.TabIndex = 76;
            // 
            // txtBuscarFolio
            // 
            this.txtBuscarFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarFolio.Location = new System.Drawing.Point(6, 33);
            this.txtBuscarFolio.Name = "txtBuscarFolio";
            this.txtBuscarFolio.Size = new System.Drawing.Size(250, 20);
            this.txtBuscarFolio.TabIndex = 0;
            this.txtBuscarFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarFolio_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(296, 77);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(76, 20);
            this.btnBuscar.TabIndex = 78;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCerrar2
            // 
            this.btnCerrar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar2.Location = new System.Drawing.Point(566, 314);
            this.btnCerrar2.Name = "btnCerrar2";
            this.btnCerrar2.Size = new System.Drawing.Size(98, 20);
            this.btnCerrar2.TabIndex = 85;
            this.btnCerrar2.Text = "CERRAR";
            this.btnCerrar2.UseVisualStyleBackColor = true;
            this.btnCerrar2.Click += new System.EventHandler(this.btnCerrar2_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(462, 314);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(98, 20);
            this.btnEliminar.TabIndex = 84;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvPerifericos
            // 
            this.dgvPerifericos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPerifericos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerifericos.Location = new System.Drawing.Point(24, 175);
            this.dgvPerifericos.Name = "dgvPerifericos";
            this.dgvPerifericos.Size = new System.Drawing.Size(640, 130);
            this.dgvPerifericos.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 13);
            this.label1.TabIndex = 88;
            this.label1.Text = "SELECCIONE UNO O MAS REGISTROS PARA ACTUALIZAR O ELIMINAR";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(358, 314);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(98, 20);
            this.btnActualizar.TabIndex = 89;
            this.btnActualizar.Text = "SELECCIONAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 15);
            this.label4.TabIndex = 82;
            this.label4.Text = "ELIJA UN CAMPO DE BUSQUEDA";
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
            this.buttonSalir.TabIndex = 87;
            this.buttonSalir.TabStop = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // BuscarPerifericos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 350);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.btnCerrar2);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvPerifericos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BuscarPerifericos";
            this.Text = "BuscarPerifericos";
            this.Load += new System.EventHandler(this.BuscarPerifericos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerifericos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioNumSerie;
        private System.Windows.Forms.RadioButton radioActivo;
        private System.Windows.Forms.RadioButton radioDidecon;
        private System.Windows.Forms.RadioButton radioDepartamento;
        private System.Windows.Forms.RadioButton radioFolio;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.TextBox txtBuscarDidecon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxBuscarDepartamento;
        private System.Windows.Forms.TextBox txtBuscarFolio;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCerrar2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvPerifericos;
        private System.Windows.Forms.PictureBox buttonSalir;
        private System.Windows.Forms.TextBox txtBuscarActivo;
        private System.Windows.Forms.TextBox txtBuscarNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioNumeroCPU;
        private System.Windows.Forms.RadioButton radioPerifericos;
        private System.Windows.Forms.RadioButton radioActivoCPU;
        private System.Windows.Forms.RadioButton radioDirIP;
        private System.Windows.Forms.RadioButton radioDepartamentoCPU;
        private System.Windows.Forms.TextBox txtBuscarActivoCPU;
        private System.Windows.Forms.TextBox txtBuscarDirCPU;
        private System.Windows.Forms.ComboBox boxBuscarDepartmanentoCPU;
        private System.Windows.Forms.TextBox txtBuscarFolioCPU;
        private System.Windows.Forms.ComboBox boxBuscarTipo;
        private System.Windows.Forms.ComboBox boxBuscarMarca;
    }
}