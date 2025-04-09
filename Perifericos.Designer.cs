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
            this.panelBarra = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSalir = new System.Windows.Forms.PictureBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.Numero = new System.Windows.Forms.Label();
            this.boxDidecon = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.boxTipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNuevoModelo = new System.Windows.Forms.Button();
            this.btnNuevoMarca = new System.Windows.Forms.Button();
            this.boxModelo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.boxMarca = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.boxNumSerie = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.boxActivo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.boxActSistemas = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxNumFactura = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxValorFactura = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.boxProveedor = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.boxEstatus = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBarra
            // 
            this.panelBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.panelBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBarra.Controls.Add(this.label1);
            this.panelBarra.Controls.Add(this.buttonSalir);
            this.panelBarra.Location = new System.Drawing.Point(0, 0);
            this.panelBarra.Name = "panelBarra";
            this.panelBarra.Size = new System.Drawing.Size(666, 36);
            this.panelBarra.TabIndex = 33;
            this.panelBarra.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBarra_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(273, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 28);
            this.label1.TabIndex = 48;
            this.label1.Text = "PERIFERICOS";
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.buttonSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalir.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalir.Image")));
            this.buttonSalir.Location = new System.Drawing.Point(635, 4);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(21, 23);
            this.buttonSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonSalir.TabIndex = 32;
            this.buttonSalir.TabStop = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // txtFolio
            // 
            this.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.Location = new System.Drawing.Point(174, 50);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(181, 23);
            this.txtFolio.TabIndex = 35;
            this.txtFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFolio_KeyPress);
            // 
            // Numero
            // 
            this.Numero.AutoSize = true;
            this.Numero.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numero.Location = new System.Drawing.Point(61, 50);
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(106, 30);
            this.Numero.TabIndex = 34;
            this.Numero.Text = "NUMERO";
            // 
            // boxDidecon
            // 
            this.boxDidecon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxDidecon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxDidecon.FormattingEnabled = true;
            this.boxDidecon.Location = new System.Drawing.Point(174, 75);
            this.boxDidecon.Name = "boxDidecon";
            this.boxDidecon.Size = new System.Drawing.Size(181, 23);
            this.boxDidecon.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 36;
            this.label2.Text = "DIDECON";
            // 
            // boxTipo
            // 
            this.boxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxTipo.FormattingEnabled = true;
            this.boxTipo.Location = new System.Drawing.Point(174, 201);
            this.boxTipo.Name = "boxTipo";
            this.boxTipo.Size = new System.Drawing.Size(181, 23);
            this.boxTipo.TabIndex = 39;
            this.boxTipo.SelectedIndexChanged += new System.EventHandler(this.boxTipo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(115, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 21);
            this.label5.TabIndex = 38;
            this.label5.Text = "TIPO";
            // 
            // btnNuevoModelo
            // 
            this.btnNuevoModelo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoModelo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoModelo.Location = new System.Drawing.Point(359, 225);
            this.btnNuevoModelo.Name = "btnNuevoModelo";
            this.btnNuevoModelo.Size = new System.Drawing.Size(75, 20);
            this.btnNuevoModelo.TabIndex = 51;
            this.btnNuevoModelo.Text = "GESTIONAR\r\n";
            this.btnNuevoModelo.UseVisualStyleBackColor = true;
            this.btnNuevoModelo.Click += new System.EventHandler(this.btnNuevoModelo_Click);
            // 
            // btnNuevoMarca
            // 
            this.btnNuevoMarca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoMarca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoMarca.Location = new System.Drawing.Point(359, 177);
            this.btnNuevoMarca.Name = "btnNuevoMarca";
            this.btnNuevoMarca.Size = new System.Drawing.Size(75, 20);
            this.btnNuevoMarca.TabIndex = 50;
            this.btnNuevoMarca.Text = "GESTIONAR MARCAS";
            this.btnNuevoMarca.UseVisualStyleBackColor = true;
            this.btnNuevoMarca.Click += new System.EventHandler(this.btnNuevoMarca_Click);
            // 
            // boxModelo
            // 
            this.boxModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxModelo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxModelo.FormattingEnabled = true;
            this.boxModelo.Location = new System.Drawing.Point(174, 226);
            this.boxModelo.Name = "boxModelo";
            this.boxModelo.Size = new System.Drawing.Size(181, 23);
            this.boxModelo.TabIndex = 49;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(88, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 48;
            this.label10.Text = "MODELO";
            // 
            // boxMarca
            // 
            this.boxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxMarca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxMarca.FormattingEnabled = true;
            this.boxMarca.Location = new System.Drawing.Point(174, 176);
            this.boxMarca.Name = "boxMarca";
            this.boxMarca.Size = new System.Drawing.Size(181, 23);
            this.boxMarca.TabIndex = 47;
            this.boxMarca.SelectedIndexChanged += new System.EventHandler(this.boxMarca_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(97, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 21);
            this.label8.TabIndex = 46;
            this.label8.Text = "MARCA";
            // 
            // boxNumSerie
            // 
            this.boxNumSerie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxNumSerie.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxNumSerie.FormattingEnabled = true;
            this.boxNumSerie.Location = new System.Drawing.Point(174, 151);
            this.boxNumSerie.Name = "boxNumSerie";
            this.boxNumSerie.Size = new System.Drawing.Size(181, 23);
            this.boxNumSerie.TabIndex = 53;
            this.boxNumSerie.TextChanged += new System.EventHandler(this.boxNumSerie_TextChanged);
            this.boxNumSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxNumSerie_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(72, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 21);
            this.label9.TabIndex = 52;
            this.label9.Text = "NUM. SERIE";
            // 
            // boxActivo
            // 
            this.boxActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxActivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxActivo.FormattingEnabled = true;
            this.boxActivo.Location = new System.Drawing.Point(174, 101);
            this.boxActivo.Name = "boxActivo";
            this.boxActivo.Size = new System.Drawing.Size(181, 23);
            this.boxActivo.TabIndex = 55;
            this.boxActivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxActivo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 21);
            this.label6.TabIndex = 54;
            this.label6.Text = "ACT. CONTRALORIA";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(384, 432);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(81, 20);
            this.btnNuevo.TabIndex = 56;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(471, 432);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(84, 20);
            this.btnAceptar.TabIndex = 57;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(561, 432);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(77, 20);
            this.btnCancelar.TabIndex = 58;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // boxActSistemas
            // 
            this.boxActSistemas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxActSistemas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxActSistemas.FormattingEnabled = true;
            this.boxActSistemas.Location = new System.Drawing.Point(174, 126);
            this.boxActSistemas.Name = "boxActSistemas";
            this.boxActSistemas.Size = new System.Drawing.Size(181, 23);
            this.boxActSistemas.TabIndex = 76;
            this.boxActSistemas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxActivoSistemas_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 21);
            this.label3.TabIndex = 75;
            this.label3.Text = "ACT. SISTEMAS";
            // 
            // boxNumFactura
            // 
            this.boxNumFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxNumFactura.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxNumFactura.FormattingEnabled = true;
            this.boxNumFactura.Location = new System.Drawing.Point(174, 251);
            this.boxNumFactura.Name = "boxNumFactura";
            this.boxNumFactura.Size = new System.Drawing.Size(181, 23);
            this.boxNumFactura.TabIndex = 78;
            this.boxNumFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxNumeroFactura_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 77;
            this.label4.Text = "NUM. FACTURA";
            // 
            // boxValorFactura
            // 
            this.boxValorFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxValorFactura.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxValorFactura.FormattingEnabled = true;
            this.boxValorFactura.Location = new System.Drawing.Point(174, 276);
            this.boxValorFactura.Name = "boxValorFactura";
            this.boxValorFactura.Size = new System.Drawing.Size(181, 23);
            this.boxValorFactura.TabIndex = 80;
            this.boxValorFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxValorFactura_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 21);
            this.label7.TabIndex = 79;
            this.label7.Text = "VALOR FACTURA";
            // 
            // boxProveedor
            // 
            this.boxProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxProveedor.FormattingEnabled = true;
            this.boxProveedor.Location = new System.Drawing.Point(174, 302);
            this.boxProveedor.Name = "boxProveedor";
            this.boxProveedor.Size = new System.Drawing.Size(181, 23);
            this.boxProveedor.TabIndex = 82;
            this.boxProveedor.TextChanged += new System.EventHandler(this.boxProveedor_TextChanged);
            this.boxProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxProveedor_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(66, 303);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 21);
            this.label11.TabIndex = 81;
            this.label11.Text = "PROVEEDOR";
            // 
            // boxEstatus
            // 
            this.boxEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxEstatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxEstatus.FormattingEnabled = true;
            this.boxEstatus.Location = new System.Drawing.Point(174, 327);
            this.boxEstatus.Name = "boxEstatus";
            this.boxEstatus.Size = new System.Drawing.Size(181, 23);
            this.boxEstatus.TabIndex = 84;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(91, 328);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 21);
            this.label12.TabIndex = 83;
            this.label12.Text = "ESTATUS";
            // 
            // txtNotas
            // 
            this.txtNotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotas.Location = new System.Drawing.Point(174, 353);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotas.Size = new System.Drawing.Size(420, 63);
            this.txtNotas.TabIndex = 86;
            this.txtNotas.TextChanged += new System.EventHandler(this.txtNotas_TextChanged);
            this.txtNotas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNotas_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(101, 352);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 21);
            this.label13.TabIndex = 85;
            this.label13.Text = "NOTAS";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(458, 321);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 21);
            this.label14.TabIndex = 87;
            this.label14.Text = "FECHA";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(521, 324);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(73, 20);
            this.dateTimePicker1.TabIndex = 88;
            this.dateTimePicker1.Value = new System.DateTime(2025, 3, 14, 9, 28, 11, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(171, 432);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscar.Size = new System.Drawing.Size(81, 20);
            this.btnBuscar.TabIndex = 89;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(258, 432);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnActualizar.Size = new System.Drawing.Size(97, 20);
            this.btnActualizar.TabIndex = 90;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // Perifericos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 478);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.boxEstatus);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.boxProveedor);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.boxValorFactura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.boxNumFactura);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxActSistemas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.boxActivo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.boxNumSerie);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnNuevoModelo);
            this.Controls.Add(this.btnNuevoMarca);
            this.Controls.Add(this.boxModelo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.boxMarca);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.boxTipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.boxDidecon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.Numero);
            this.Controls.Add(this.panelBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Perifericos";
            this.Text = "<";
            this.Load += new System.EventHandler(this.Perifericos_Load);
            this.panelBarra.ResumeLayout(false);
            this.panelBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Panel panelBarra;
        private System.Windows.Forms.PictureBox buttonSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label Numero;
        private System.Windows.Forms.ComboBox boxDidecon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNuevoModelo;
        private System.Windows.Forms.Button btnNuevoMarca;
        private System.Windows.Forms.ComboBox boxModelo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox boxMarca;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox boxNumSerie;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox boxActivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox boxActSistemas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxNumFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox boxValorFactura;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox boxProveedor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox boxEstatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnActualizar;

    }
}