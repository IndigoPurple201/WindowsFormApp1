namespace WinFormsApp1
{
    partial class Servicios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Servicios));
            this.panelBarra = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSalir = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateExternoEntrega = new System.Windows.Forms.DateTimePicker();
            this.dateExternoPedido = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBarra
            // 
            this.panelBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.panelBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBarra.Controls.Add(this.label1);
            this.panelBarra.Controls.Add(this.buttonSalir);
            this.panelBarra.Location = new System.Drawing.Point(-1, 0);
            this.panelBarra.Name = "panelBarra";
            this.panelBarra.Size = new System.Drawing.Size(829, 36);
            this.panelBarra.TabIndex = 33;
            this.panelBarra.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBarra_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(341, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "SERVICIOS";
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.buttonSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalir.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalir.Image")));
            this.buttonSalir.Location = new System.Drawing.Point(799, 6);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(21, 23);
            this.buttonSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonSalir.TabIndex = 32;
            this.buttonSalir.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateExternoEntrega);
            this.panel1.Controls.Add(this.dateExternoPedido);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dateRefaccionEntrega);
            this.panel1.Controls.Add(this.dateRefaccionPedido);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateReparacion);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateSalida);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateEntrada);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.boxEstatus);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 442);
            this.panel1.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "ESTATUS";
            // 
            // boxEstatus
            // 
            this.boxEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxEstatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boxEstatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxEstatus.FormattingEnabled = true;
            this.boxEstatus.Location = new System.Drawing.Point(9, 31);
            this.boxEstatus.Name = "boxEstatus";
            this.boxEstatus.Size = new System.Drawing.Size(172, 23);
            this.boxEstatus.TabIndex = 58;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(5, 73);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(130, 21);
            this.label22.TabIndex = 90;
            this.label22.Text = "FECHA ENTRADA";
            // 
            // dateEntrada
            // 
            this.dateEntrada.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateEntrada.Location = new System.Drawing.Point(9, 97);
            this.dateEntrada.Name = "dateEntrada";
            this.dateEntrada.Size = new System.Drawing.Size(172, 29);
            this.dateEntrada.TabIndex = 91;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 21);
            this.label3.TabIndex = 92;
            this.label3.Text = "FECHA SALIDA";
            // 
            // dateSalida
            // 
            this.dateSalida.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateSalida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateSalida.Location = new System.Drawing.Point(9, 162);
            this.dateSalida.Name = "dateSalida";
            this.dateSalida.Size = new System.Drawing.Size(172, 29);
            this.dateSalida.TabIndex = 93;
            // 
            // dateReparacion
            // 
            this.dateReparacion.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateReparacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateReparacion.Location = new System.Drawing.Point(9, 230);
            this.dateReparacion.Name = "dateReparacion";
            this.dateReparacion.Size = new System.Drawing.Size(172, 29);
            this.dateReparacion.TabIndex = 95;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 21);
            this.label4.TabIndex = 94;
            this.label4.Text = ":: FECHA REPARACION ::";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 15);
            this.label5.TabIndex = 96;
            this.label5.Text = ":: FECHA REFACCION ::";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 97;
            this.label6.Text = "PEDIDO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 98;
            this.label7.Text = "ENTREGA";
            // 
            // dateRefaccionPedido
            // 
            this.dateRefaccionPedido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateRefaccionPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateRefaccionPedido.Location = new System.Drawing.Point(69, 294);
            this.dateRefaccionPedido.Name = "dateRefaccionPedido";
            this.dateRefaccionPedido.Size = new System.Drawing.Size(111, 23);
            this.dateRefaccionPedido.TabIndex = 35;
            // 
            // dateRefaccionEntrega
            // 
            this.dateRefaccionEntrega.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateRefaccionEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateRefaccionEntrega.Location = new System.Drawing.Point(69, 321);
            this.dateRefaccionEntrega.Name = "dateRefaccionEntrega";
            this.dateRefaccionEntrega.Size = new System.Drawing.Size(111, 23);
            this.dateRefaccionEntrega.TabIndex = 99;
            // 
            // dateExternoEntrega
            // 
            this.dateExternoEntrega.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateExternoEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateExternoEntrega.Location = new System.Drawing.Point(70, 404);
            this.dateExternoEntrega.Name = "dateExternoEntrega";
            this.dateExternoEntrega.Size = new System.Drawing.Size(111, 23);
            this.dateExternoEntrega.TabIndex = 104;
            // 
            // dateExternoPedido
            // 
            this.dateExternoPedido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dateExternoPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateExternoPedido.Location = new System.Drawing.Point(70, 377);
            this.dateExternoPedido.Name = "dateExternoPedido";
            this.dateExternoPedido.Size = new System.Drawing.Size(111, 23);
            this.dateExternoPedido.TabIndex = 100;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 15);
            this.label8.TabIndex = 103;
            this.label8.Text = "ENTREGA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 383);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 15);
            this.label9.TabIndex = 102;
            this.label9.Text = "PEDIDO";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 359);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 15);
            this.label10.TabIndex = 101;
            this.label10.Text = ":: FECHA EXTERNO ::";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtFalla);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.boxExterno);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtConsecutivo);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtFolio);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.radioPeriferico);
            this.panel2.Controls.Add(this.radioCpu);
            this.panel2.Controls.Add(this.txtServicio);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(237, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 442);
            this.panel2.TabIndex = 35;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(732, 502);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(78, 29);
            this.btnNuevo.TabIndex = 36;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(636, 502);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(90, 29);
            this.btnActualizar.TabIndex = 99;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(540, 502);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 29);
            this.btnEliminar.TabIndex = 100;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(237, 502);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 29);
            this.btnBuscar.TabIndex = 101;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(16, 502);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 29);
            this.btnCancelar.TabIndex = 102;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 21);
            this.label11.TabIndex = 7;
            this.label11.Text = "SERVICIO RECIBIDO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 21);
            this.label12.TabIndex = 105;
            this.label12.Text = "SERVICIO";
            // 
            // txtServicio
            // 
            this.txtServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServicio.Location = new System.Drawing.Point(103, 37);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.Size = new System.Drawing.Size(110, 23);
            this.txtServicio.TabIndex = 106;
            // 
            // radioCpu
            // 
            this.radioCpu.AutoSize = true;
            this.radioCpu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radioCpu.Location = new System.Drawing.Point(231, 35);
            this.radioCpu.Name = "radioCpu";
            this.radioCpu.Size = new System.Drawing.Size(58, 25);
            this.radioCpu.TabIndex = 107;
            this.radioCpu.TabStop = true;
            this.radioCpu.Text = "CPU";
            this.radioCpu.UseVisualStyleBackColor = true;
            // 
            // radioPeriferico
            // 
            this.radioPeriferico.AutoSize = true;
            this.radioPeriferico.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.radioPeriferico.Location = new System.Drawing.Point(299, 35);
            this.radioPeriferico.Name = "radioPeriferico";
            this.radioPeriferico.Size = new System.Drawing.Size(111, 25);
            this.radioPeriferico.TabIndex = 108;
            this.radioPeriferico.TabStop = true;
            this.radioPeriferico.Text = "PERIFERICO";
            this.radioPeriferico.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(43, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 21);
            this.label13.TabIndex = 109;
            this.label13.Text = "FOLIO";
            // 
            // txtFolio
            // 
            this.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.Location = new System.Drawing.Point(103, 74);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(110, 23);
            this.txtFolio.TabIndex = 110;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(230, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(202, 21);
            this.label14.TabIndex = 111;
            this.label14.Text = "DIR. DEPTO. CONSECUTIVO";
            // 
            // txtConsecutivo
            // 
            this.txtConsecutivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsecutivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsecutivo.Location = new System.Drawing.Point(438, 72);
            this.txtConsecutivo.Name = "txtConsecutivo";
            this.txtConsecutivo.Size = new System.Drawing.Size(110, 23);
            this.txtConsecutivo.TabIndex = 112;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(355, 109);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 21);
            this.label15.TabIndex = 113;
            this.label15.Text = "EXTERNO";
            // 
            // boxExterno
            // 
            this.boxExterno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxExterno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boxExterno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxExterno.FormattingEnabled = true;
            this.boxExterno.Location = new System.Drawing.Point(438, 107);
            this.boxExterno.Name = "boxExterno";
            this.boxExterno.Size = new System.Drawing.Size(110, 23);
            this.boxExterno.TabIndex = 114;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(43, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 21);
            this.label16.TabIndex = 115;
            this.label16.Text = "FALLA";
            // 
            // txtFalla
            // 
            this.txtFalla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFalla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFalla.Location = new System.Drawing.Point(103, 146);
            this.txtFalla.Multiline = true;
            this.txtFalla.Name = "txtFalla";
            this.txtFalla.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFalla.Size = new System.Drawing.Size(445, 63);
            this.txtFalla.TabIndex = 116;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(21, 230);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 21);
            this.label17.TabIndex = 117;
            this.label17.Text = "SOLICITÓ";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(103, 228);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 23);
            this.textBox1.TabIndex = 118;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(21, 295);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(181, 21);
            this.label18.TabIndex = 119;
            this.label18.Text = "SERVICIO ENTREGADO";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(8, 327);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 21);
            this.label19.TabIndex = 120;
            this.label19.Text = "RECOGIDO";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(105, 324);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(445, 23);
            this.textBox2.TabIndex = 121;
            // 
            // Servicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 538);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Servicios";
            this.Text = "Servicios";
            this.Load += new System.EventHandler(this.Servicios_Load);
            this.panelBarra.ResumeLayout(false);
            this.panelBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelBarra;
        private Label label1;
        private PictureBox buttonSalir;
        private Panel panel1;
        private Label label2;
        private ComboBox boxEstatus;
        private Label label22;
        private Label label3;
        private DateTimePicker dateEntrada;
        private Label label5;
        private DateTimePicker dateReparacion;
        private Label label4;
        private DateTimePicker dateSalida;
        private DateTimePicker dateRefaccionEntrega;
        private DateTimePicker dateRefaccionPedido;
        private Label label7;
        private Label label6;
        private DateTimePicker dateExternoEntrega;
        private DateTimePicker dateExternoPedido;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnNuevo;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnBuscar;
        private Button btnCancelar;
        private Label label11;
        private Label label12;
        private TextBox txtFolio;
        private Label label13;
        private RadioButton radioPeriferico;
        private RadioButton radioCpu;
        private TextBox txtServicio;
        private Label label15;
        private TextBox txtConsecutivo;
        private Label label14;
        private Label label16;
        private ComboBox boxExterno;
        private TextBox txtFalla;
        private Label label17;
        private TextBox textBox2;
        private Label label19;
        private Label label18;
        private TextBox textBox1;
    }
}