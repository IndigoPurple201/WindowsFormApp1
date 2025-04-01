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
            btnHardware = new Button();
            boxActSistemas = new ComboBox();
            label3 = new Label();
            boxNumFactura = new ComboBox();
            label4 = new Label();
            boxValorFactura = new ComboBox();
            label7 = new Label();
            boxProveedor = new ComboBox();
            label11 = new Label();
            boxEstatus = new ComboBox();
            label12 = new Label();
            txtNotas = new TextBox();
            label13 = new Label();
            label14 = new Label();
            dateTimePicker1 = new DateTimePicker();
            btnBuscar = new Button();
            btnActualizar = new Button();
            panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).BeginInit();
            SuspendLayout();
            // 
            // panelBarra
            // 
            panelBarra.BackColor = Color.FromArgb(0, 120, 212);
            panelBarra.BorderStyle = BorderStyle.FixedSingle;
            panelBarra.Controls.Add(label1);
            panelBarra.Controls.Add(buttonSalir);
            panelBarra.Location = new Point(0, 0);
            panelBarra.Name = "panelBarra";
            panelBarra.Size = new Size(707, 37);
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
            buttonSalir.Location = new Point(677, 5);
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
            txtFolio.Location = new Point(183, 58);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(210, 23);
            txtFolio.TabIndex = 35;
            txtFolio.KeyPress += txtFolio_KeyPress;
            // 
            // Numero
            // 
            Numero.AutoSize = true;
            Numero.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Numero.Location = new Point(71, 58);
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
            boxDidecon.Location = new Point(183, 87);
            boxDidecon.Name = "boxDidecon";
            boxDidecon.Size = new Size(210, 23);
            boxDidecon.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(99, 89);
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
            boxTipo.Location = new Point(183, 232);
            boxTipo.Name = "boxTipo";
            boxTipo.Size = new Size(210, 23);
            boxTipo.TabIndex = 39;
            boxTipo.SelectedIndexChanged += boxTipo_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(134, 234);
            label5.Name = "label5";
            label5.Size = new Size(43, 21);
            label5.TabIndex = 38;
            label5.Text = "TIPO";
            // 
            // btnNuevoModelo
            // 
            btnNuevoModelo.Cursor = Cursors.Hand;
            btnNuevoModelo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoModelo.Location = new Point(399, 260);
            btnNuevoModelo.Name = "btnNuevoModelo";
            btnNuevoModelo.Size = new Size(88, 23);
            btnNuevoModelo.TabIndex = 51;
            btnNuevoModelo.Text = "GESTIONAR\r\n";
            btnNuevoModelo.UseVisualStyleBackColor = true;
            btnNuevoModelo.Click += btnNuevoModelo_Click;
            // 
            // btnNuevoMarca
            // 
            btnNuevoMarca.Cursor = Cursors.Hand;
            btnNuevoMarca.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoMarca.Location = new Point(399, 204);
            btnNuevoMarca.Name = "btnNuevoMarca";
            btnNuevoMarca.Size = new Size(88, 23);
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
            boxModelo.Location = new Point(183, 261);
            boxModelo.Name = "boxModelo";
            boxModelo.Size = new Size(210, 23);
            boxModelo.TabIndex = 49;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(103, 263);
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
            boxMarca.Location = new Point(183, 203);
            boxMarca.Name = "boxMarca";
            boxMarca.Size = new Size(210, 23);
            boxMarca.TabIndex = 47;
            boxMarca.SelectedIndexChanged += boxMarca_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(113, 203);
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
            boxNumSerie.Location = new Point(183, 174);
            boxNumSerie.Name = "boxNumSerie";
            boxNumSerie.Size = new Size(210, 23);
            boxNumSerie.TabIndex = 53;
            boxNumSerie.TextChanged += boxNumSerie_TextChanged;
            boxNumSerie.KeyPress += boxNumSerie_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(84, 176);
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
            boxActivo.Location = new Point(183, 116);
            boxActivo.Name = "boxActivo";
            boxActivo.Size = new Size(210, 23);
            boxActivo.TabIndex = 55;
            boxActivo.KeyPress += boxActivo_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(27, 118);
            label6.Name = "label6";
            label6.Size = new Size(150, 21);
            label6.TabIndex = 54;
            label6.Text = "ACT. CONTRALORIA";
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(399, 498);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(88, 23);
            btnNuevo.TabIndex = 56;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(493, 498);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(89, 23);
            btnAceptar.TabIndex = 57;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(588, 498);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(85, 23);
            btnCancelar.TabIndex = 58;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnHardware
            // 
            btnHardware.Cursor = Cursors.Hand;
            btnHardware.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHardware.Location = new Point(27, 498);
            btnHardware.Name = "btnHardware";
            btnHardware.Size = new Size(89, 23);
            btnHardware.TabIndex = 74;
            btnHardware.Text = "HARDWARE";
            btnHardware.UseVisualStyleBackColor = true;
            btnHardware.Click += btnHardware_Click;
            // 
            // boxActSistemas
            // 
            boxActSistemas.DropDownStyle = ComboBoxStyle.DropDownList;
            boxActSistemas.Font = new Font("Segoe UI", 9F);
            boxActSistemas.FormattingEnabled = true;
            boxActSistemas.Location = new Point(183, 145);
            boxActSistemas.Name = "boxActSistemas";
            boxActSistemas.Size = new Size(210, 23);
            boxActSistemas.TabIndex = 76;
            boxActSistemas.KeyPress += boxActivoSistemas_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(61, 147);
            label3.Name = "label3";
            label3.Size = new Size(116, 21);
            label3.TabIndex = 75;
            label3.Text = "ACT. SISTEMAS";
            // 
            // boxNumFactura
            // 
            boxNumFactura.DropDownStyle = ComboBoxStyle.DropDownList;
            boxNumFactura.Font = new Font("Segoe UI", 9F);
            boxNumFactura.FormattingEnabled = true;
            boxNumFactura.Location = new Point(183, 290);
            boxNumFactura.Name = "boxNumFactura";
            boxNumFactura.Size = new Size(210, 23);
            boxNumFactura.TabIndex = 78;
            boxNumFactura.KeyPress += boxNumeroFactura_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(57, 292);
            label4.Name = "label4";
            label4.Size = new Size(120, 21);
            label4.TabIndex = 77;
            label4.Text = "NUM. FACTURA";
            // 
            // boxValorFactura
            // 
            boxValorFactura.DropDownStyle = ComboBoxStyle.DropDownList;
            boxValorFactura.Font = new Font("Segoe UI", 9F);
            boxValorFactura.FormattingEnabled = true;
            boxValorFactura.Location = new Point(183, 319);
            boxValorFactura.Name = "boxValorFactura";
            boxValorFactura.Size = new Size(210, 23);
            boxValorFactura.TabIndex = 80;
            boxValorFactura.KeyPress += boxValorFactura_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(49, 321);
            label7.Name = "label7";
            label7.Size = new Size(128, 21);
            label7.TabIndex = 79;
            label7.Text = "VALOR FACTURA";
            // 
            // boxProveedor
            // 
            boxProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            boxProveedor.Font = new Font("Segoe UI", 9F);
            boxProveedor.FormattingEnabled = true;
            boxProveedor.Location = new Point(183, 348);
            boxProveedor.Name = "boxProveedor";
            boxProveedor.Size = new Size(210, 23);
            boxProveedor.TabIndex = 82;
            boxProveedor.TextChanged += boxProveedor_TextChanged;
            boxProveedor.KeyPress += boxProveedor_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(77, 350);
            label11.Name = "label11";
            label11.Size = new Size(100, 21);
            label11.TabIndex = 81;
            label11.Text = "PROVEEDOR";
            // 
            // boxEstatus
            // 
            boxEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            boxEstatus.Font = new Font("Segoe UI", 9F);
            boxEstatus.FormattingEnabled = true;
            boxEstatus.Location = new Point(183, 377);
            boxEstatus.Name = "boxEstatus";
            boxEstatus.Size = new Size(210, 23);
            boxEstatus.TabIndex = 84;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(106, 379);
            label12.Name = "label12";
            label12.Size = new Size(71, 21);
            label12.TabIndex = 83;
            label12.Text = "ESTATUS";
            // 
            // txtNotas
            // 
            txtNotas.BorderStyle = BorderStyle.FixedSingle;
            txtNotas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNotas.Location = new Point(183, 406);
            txtNotas.Multiline = true;
            txtNotas.Name = "txtNotas";
            txtNotas.ScrollBars = ScrollBars.Vertical;
            txtNotas.Size = new Size(490, 72);
            txtNotas.TabIndex = 86;
            txtNotas.TextChanged += txtNotas_TextChanged;
            txtNotas.KeyPress += txtNotas_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(118, 406);
            label13.Name = "label13";
            label13.Size = new Size(59, 21);
            label13.TabIndex = 85;
            label13.Text = "NOTAS";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(525, 375);
            label14.Name = "label14";
            label14.Size = new Size(57, 21);
            label14.TabIndex = 87;
            label14.Text = "FECHA";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(588, 374);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(85, 23);
            dateTimePicker1.TabIndex = 88;
            dateTimePicker1.Value = new DateTime(2025, 3, 14, 9, 28, 11, 0);
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(183, 498);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.RightToLeft = RightToLeft.No;
            btnBuscar.Size = new Size(88, 23);
            btnBuscar.TabIndex = 89;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnActualizar.Location = new Point(277, 498);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.RightToLeft = RightToLeft.No;
            btnActualizar.Size = new Size(88, 23);
            btnActualizar.TabIndex = 90;
            btnActualizar.Text = "ACTUALIZAR";
            btnActualizar.UseVisualStyleBackColor = true;
            // 
            // Perifericos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 551);
            Controls.Add(btnActualizar);
            Controls.Add(btnBuscar);
            Controls.Add(dateTimePicker1);
            Controls.Add(label14);
            Controls.Add(txtNotas);
            Controls.Add(label13);
            Controls.Add(boxEstatus);
            Controls.Add(label12);
            Controls.Add(boxProveedor);
            Controls.Add(label11);
            Controls.Add(boxValorFactura);
            Controls.Add(label7);
            Controls.Add(boxNumFactura);
            Controls.Add(label4);
            Controls.Add(boxActSistemas);
            Controls.Add(label3);
            Controls.Add(btnHardware);
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
            Controls.Add(panelBarra);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Perifericos";
            Text = "<";
            Load += Perifericos_Load;
            panelBarra.ResumeLayout(false);
            panelBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).EndInit();
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
        private Button btnHardware;
        private ComboBox boxActSistemas;
        private Label label3;
        private ComboBox boxNumFactura;
        private Label label4;
        private ComboBox boxValorFactura;
        private Label label7;
        private ComboBox boxProveedor;
        private Label label11;
        private ComboBox boxEstatus;
        private Label label12;
        private TextBox txtNotas;
        private Label label13;
        private Label label14;
        private DateTimePicker dateTimePicker1;
        private Button btnBuscar;
        private Button btnActualizar;
    }
}