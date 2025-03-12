namespace WinFormsApp1
{
    partial class Perifericos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Perifericos));
            panelBarra = new Panel();
            label1 = new Label();
            buttonSalir = new PictureBox();
            txtFolio = new TextBox();
            Numero = new Label();
            boxDidecon = new ComboBox();
            label2 = new Label();
            boxTipo = new ComboBox();
            label5 = new Label();
            btnNuevoModelo = new Button();
            btnNuevoMarca = new Button();
            boxModelo = new ComboBox();
            label10 = new Label();
            boxMarca = new ComboBox();
            label8 = new Label();
            boxNumSerie = new ComboBox();
            label9 = new Label();
            boxActivo = new ComboBox();
            label6 = new Label();
            btnNuevo = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            btnActualizar = new Button();
            btnCerrar2 = new Button();
            btnEliminar = new Button();
            dgvPerifericos = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            btnHardware = new Button();
            panelBusqueda = new Panel();
            txtBuscarNumSerie = new TextBox();
            txtBuscarActivo = new TextBox();
            txtBuscarDidecon = new TextBox();
            label3 = new Label();
            boxBuscarDepartamento = new ComboBox();
            txtBuscarFolio = new TextBox();
            panel1 = new Panel();
            radioNumSerie = new RadioButton();
            radioActivo = new RadioButton();
            radioDidecon = new RadioButton();
            radioDepartamento = new RadioButton();
            radioFolio = new RadioButton();
            label4 = new Label();
            panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPerifericos).BeginInit();
            panelBusqueda.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBarra
            // 
            panelBarra.BackColor = Color.FromArgb(0, 120, 212);
            panelBarra.BorderStyle = BorderStyle.FixedSingle;
            panelBarra.Controls.Add(label1);
            panelBarra.Location = new Point(0, 0);
            panelBarra.Name = "panelBarra";
            panelBarra.Size = new Size(777, 37);
            panelBarra.TabIndex = 33;
            panelBarra.Paint += panelBarra_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(318, 2);
            label1.Name = "label1";
            label1.Size = new Size(142, 30);
            label1.TabIndex = 48;
            label1.Text = "PERIFERICOS";
            // 
            // buttonSalir
            // 
            buttonSalir.BackColor = Color.FromArgb(0, 120, 212);
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.Image = (Image)resources.GetObject("buttonSalir.Image");
            buttonSalir.Location = new Point(745, 5);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(25, 27);
            buttonSalir.SizeMode = PictureBoxSizeMode.StretchImage;
            buttonSalir.TabIndex = 32;
            buttonSalir.TabStop = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // txtFolio
            // 
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFolio.Location = new Point(156, 66);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(188, 23);
            txtFolio.TabIndex = 35;
            txtFolio.KeyPress += txtFolio_KeyPress;
            // 
            // Numero
            // 
            Numero.AutoSize = true;
            Numero.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Numero.Location = new Point(35, 56);
            Numero.Name = "Numero";
            Numero.Size = new Size(106, 30);
            Numero.TabIndex = 34;
            Numero.Text = "NUMERO";
            // 
            // boxDidecon
            // 
            boxDidecon.DropDownStyle = ComboBoxStyle.DropDownList;
            boxDidecon.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boxDidecon.FormattingEnabled = true;
            boxDidecon.Location = new Point(128, 102);
            boxDidecon.Name = "boxDidecon";
            boxDidecon.Size = new Size(216, 23);
            boxDidecon.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 102);
            label2.Name = "label2";
            label2.Size = new Size(78, 21);
            label2.TabIndex = 36;
            label2.Text = "DIDECON";
            // 
            // boxTipo
            // 
            boxTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxTipo.Font = new Font("Segoe UI", 9F);
            boxTipo.FormattingEnabled = true;
            boxTipo.Location = new Point(528, 104);
            boxTipo.Name = "boxTipo";
            boxTipo.Size = new Size(233, 23);
            boxTipo.TabIndex = 39;
            boxTipo.SelectedIndexChanged += boxTipo_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(479, 106);
            label5.Name = "label5";
            label5.Size = new Size(43, 21);
            label5.TabIndex = 38;
            label5.Text = "TIPO";
            // 
            // btnNuevoModelo
            // 
            btnNuevoModelo.Cursor = Cursors.Hand;
            btnNuevoModelo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoModelo.Location = new Point(467, 179);
            btnNuevoModelo.Name = "btnNuevoModelo";
            btnNuevoModelo.Size = new Size(145, 23);
            btnNuevoModelo.TabIndex = 51;
            btnNuevoModelo.Text = "GESTIONAR MODELOS";
            btnNuevoModelo.UseVisualStyleBackColor = true;
            btnNuevoModelo.Click += btnNuevoModelo_Click;
            // 
            // btnNuevoMarca
            // 
            btnNuevoMarca.Cursor = Cursors.Hand;
            btnNuevoMarca.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoMarca.Location = new Point(618, 178);
            btnNuevoMarca.Name = "btnNuevoMarca";
            btnNuevoMarca.Size = new Size(143, 23);
            btnNuevoMarca.TabIndex = 50;
            btnNuevoMarca.Text = "GESTIONAR MARCAS";
            btnNuevoMarca.UseVisualStyleBackColor = true;
            btnNuevoMarca.Click += btnNuevoMarca_Click;
            // 
            // boxModelo
            // 
            boxModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxModelo.Font = new Font("Segoe UI", 9F);
            boxModelo.FormattingEnabled = true;
            boxModelo.Location = new Point(528, 141);
            boxModelo.Name = "boxModelo";
            boxModelo.Size = new Size(233, 23);
            boxModelo.TabIndex = 49;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(448, 143);
            label10.Name = "label10";
            label10.Size = new Size(74, 21);
            label10.TabIndex = 48;
            label10.Text = "MODELO";
            // 
            // boxMarca
            // 
            boxMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            boxMarca.Font = new Font("Segoe UI", 9F);
            boxMarca.FormattingEnabled = true;
            boxMarca.Location = new Point(528, 68);
            boxMarca.Name = "boxMarca";
            boxMarca.Size = new Size(233, 23);
            boxMarca.TabIndex = 47;
            boxMarca.SelectedIndexChanged += boxMarca_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(458, 70);
            label8.Name = "label8";
            label8.Size = new Size(64, 21);
            label8.TabIndex = 46;
            label8.Text = "MARCA";
            // 
            // boxNumSerie
            // 
            boxNumSerie.DropDownStyle = ComboBoxStyle.DropDownList;
            boxNumSerie.Font = new Font("Segoe UI", 9F);
            boxNumSerie.FormattingEnabled = true;
            boxNumSerie.Location = new Point(128, 178);
            boxNumSerie.Name = "boxNumSerie";
            boxNumSerie.Size = new Size(216, 23);
            boxNumSerie.TabIndex = 53;
            boxNumSerie.TextChanged += boxNumSerie_TextChanged;
            boxNumSerie.KeyPress += boxNumSerie_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(29, 178);
            label9.Name = "label9";
            label9.Size = new Size(93, 21);
            label9.TabIndex = 52;
            label9.Text = "NUM. SERIE";
            // 
            // boxActivo
            // 
            boxActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxActivo.Font = new Font("Segoe UI", 9F);
            boxActivo.FormattingEnabled = true;
            boxActivo.Location = new Point(191, 141);
            boxActivo.Name = "boxActivo";
            boxActivo.Size = new Size(153, 23);
            boxActivo.TabIndex = 55;
            boxActivo.KeyPress += boxActivo_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(29, 143);
            label6.Name = "label6";
            label6.Size = new Size(150, 21);
            label6.TabIndex = 54;
            label6.Text = "ACT. CONTRALORIA";
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(129, 217);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 56;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(224, 217);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 57;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(319, 217);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 23);
            btnCancelar.TabIndex = 58;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(482, 561);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(89, 23);
            btnActualizar.TabIndex = 62;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar2
            // 
            btnCerrar2.Cursor = Cursors.Hand;
            btnCerrar2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar2.Location = new Point(672, 561);
            btnCerrar2.Name = "btnCerrar2";
            btnCerrar2.Size = new Size(89, 23);
            btnCerrar2.TabIndex = 61;
            btnCerrar2.Text = "CERRAR";
            btnCerrar2.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(577, 561);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(89, 23);
            btnEliminar.TabIndex = 60;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // dgvPerifericos
            // 
            dgvPerifericos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPerifericos.Location = new Point(23, 400);
            dgvPerifericos.Name = "dgvPerifericos";
            dgvPerifericos.Size = new Size(738, 150);
            dgvPerifericos.TabIndex = 59;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(345, 361);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 71;
            button1.Text = "BUSCAR";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(427, 361);
            button2.Name = "button2";
            button2.Size = new Size(107, 23);
            button2.TabIndex = 72;
            button2.Text = "REESTABLECER";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnHardware
            // 
            btnHardware.Cursor = Cursors.Hand;
            btnHardware.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHardware.Location = new Point(23, 561);
            btnHardware.Name = "btnHardware";
            btnHardware.Size = new Size(89, 23);
            btnHardware.TabIndex = 74;
            btnHardware.Text = "HARDWARE";
            btnHardware.UseVisualStyleBackColor = true;
            btnHardware.Click += btnHardware_Click;
            // 
            // panelBusqueda
            // 
            panelBusqueda.BorderStyle = BorderStyle.FixedSingle;
            panelBusqueda.Controls.Add(txtBuscarNumSerie);
            panelBusqueda.Controls.Add(txtBuscarActivo);
            panelBusqueda.Controls.Add(txtBuscarDidecon);
            panelBusqueda.Controls.Add(label3);
            panelBusqueda.Controls.Add(boxBuscarDepartamento);
            panelBusqueda.Controls.Add(txtBuscarFolio);
            panelBusqueda.Location = new Point(23, 325);
            panelBusqueda.Name = "panelBusqueda";
            panelBusqueda.Size = new Size(309, 59);
            panelBusqueda.TabIndex = 75;
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
            label3.Location = new Point(11, 6);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 78;
            // 
            // boxBuscarDepartamento
            // 
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
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(radioNumSerie);
            panel1.Controls.Add(radioActivo);
            panel1.Controls.Add(radioDidecon);
            panel1.Controls.Add(radioDepartamento);
            panel1.Controls.Add(radioFolio);
            panel1.Location = new Point(23, 281);
            panel1.Name = "panel1";
            panel1.Size = new Size(535, 38);
            panel1.TabIndex = 76;
            // 
            // radioNumSerie
            // 
            radioNumSerie.AutoSize = true;
            radioNumSerie.FlatStyle = FlatStyle.System;
            radioNumSerie.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioNumSerie.Location = new Point(434, 9);
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
            radioActivo.FlatStyle = FlatStyle.System;
            radioActivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioActivo.Location = new Point(294, 9);
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
            radioDidecon.FlatStyle = FlatStyle.System;
            radioDidecon.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioDidecon.Location = new Point(204, 9);
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
            radioDepartamento.FlatStyle = FlatStyle.System;
            radioDepartamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioDepartamento.Location = new Point(81, 9);
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
            radioFolio.FlatStyle = FlatStyle.System;
            radioFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioFolio.Location = new Point(10, 9);
            radioFolio.Name = "radioFolio";
            radioFolio.Size = new Size(65, 20);
            radioFolio.TabIndex = 0;
            radioFolio.TabStop = true;
            radioFolio.Text = "FOLIO";
            radioFolio.UseVisualStyleBackColor = true;
            radioFolio.CheckedChanged += radioFolio_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 257);
            label4.Name = "label4";
            label4.Size = new Size(180, 15);
            label4.TabIndex = 77;
            label4.Text = "ELIJA UN CAMPO DE BUSQUEDA";
            // 
            // Perifericos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 597);
            Controls.Add(label4);
            Controls.Add(panel1);
            Controls.Add(panelBusqueda);
            Controls.Add(btnHardware);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(btnActualizar);
            Controls.Add(btnCerrar2);
            Controls.Add(btnEliminar);
            Controls.Add(dgvPerifericos);
            Controls.Add(btnNuevo);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(boxActivo);
            Controls.Add(label6);
            Controls.Add(boxNumSerie);
            Controls.Add(label9);
            Controls.Add(btnNuevoModelo);
            Controls.Add(btnNuevoMarca);
            Controls.Add(boxModelo);
            Controls.Add(label10);
            Controls.Add(boxMarca);
            Controls.Add(label8);
            Controls.Add(boxTipo);
            Controls.Add(label5);
            Controls.Add(boxDidecon);
            Controls.Add(label2);
            Controls.Add(txtFolio);
            Controls.Add(Numero);
            Controls.Add(buttonSalir);
            Controls.Add(panelBarra);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Perifericos";
            Text = "Z";
            Load += Perifericos_Load;
            panelBarra.ResumeLayout(false);
            panelBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPerifericos).EndInit();
            panelBusqueda.ResumeLayout(false);
            panelBusqueda.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelBarra;
        private PictureBox buttonSalir;
        private Label label1;
        private TextBox txtFolio;
        private Label Numero;
        private ComboBox boxDidecon;
        private Label label2;
        private ComboBox boxTipo;
        private Label label5;
        private Button btnNuevoModelo;
        private Button btnNuevoMarca;
        private ComboBox boxModelo;
        private Label label10;
        private ComboBox boxMarca;
        private Label label8;
        private ComboBox boxNumSerie;
        private Label label9;
        private ComboBox boxActivo;
        private Label label6;
        private Button btnNuevo;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnActualizar;
        private Button btnCerrar2;
        private Button btnEliminar;
        private DataGridView dgvPerifericos;
        private Button button1;
        private Button button2;
        private Button btnHardware;
        private Panel panelBusqueda;
        private ComboBox boxBuscarDepartamento;
        private TextBox txtBuscarFolio;
        private Panel panel1;
        private RadioButton radioFolio;
        private RadioButton radioDepartamento;
        private Label label3;
        private Label label4;
        private TextBox txtBuscarDidecon;
        private RadioButton radioNumSerie;
        private RadioButton radioActivo;
        private RadioButton radioDidecon;
        private TextBox txtBuscarActivo;
        private TextBox txtBuscarNumSerie;
    }
}