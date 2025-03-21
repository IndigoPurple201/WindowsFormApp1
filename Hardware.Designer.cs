namespace WinFormsApp1
{
    partial class Hardware
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hardware));
            panelBarra = new Panel();
            label1 = new Label();
            buttonSalir = new PictureBox();
            btnNuevo = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            Numero = new Label();
            txtFolio = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtDidecon = new TextBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label7 = new Label();
            label8 = new Label();
            boxMarca = new ComboBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtProcesador = new TextBox();
            boxModelo = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            boxDepartamento = new ComboBox();
            label6 = new Label();
            boxArea = new ComboBox();
            boxResponsable = new ComboBox();
            boxDireccion = new ComboBox();
            boxNumSerie = new ComboBox();
            textDisco = new TextBox();
            boxActivo = new ComboBox();
            txtMemoria = new TextBox();
            btnNuevoMarca = new Button();
            btnNuevoModelo = new Button();
            btnPerifericos = new Button();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            boxEstatus = new ComboBox();
            label19 = new Label();
            boxTipo = new ComboBox();
            label20 = new Label();
            label21 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label22 = new Label();
            btnBuscar = new Button();
            boxNombre = new ComboBox();
            boxGrupo = new ComboBox();
            boxActSistemas = new ComboBox();
            boxProveedor = new ComboBox();
            boxNumFactura = new ComboBox();
            boxValorFactura = new ComboBox();
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
            panelBarra.Location = new Point(-1, 0);
            panelBarra.Name = "panelBarra";
            panelBarra.Size = new Size(878, 41);
            panelBarra.TabIndex = 32;
            panelBarra.Paint += panelBarra_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(448, 2);
            label1.Name = "label1";
            label1.Size = new Size(54, 30);
            label1.TabIndex = 47;
            label1.Text = "CPU";
            // 
            // buttonSalir
            // 
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.Image = (Image)resources.GetObject("buttonSalir.Image");
            buttonSalir.Location = new Point(847, 5);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(25, 27);
            buttonSalir.SizeMode = PictureBoxSizeMode.StretchImage;
            buttonSalir.TabIndex = 32;
            buttonSalir.TabStop = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(620, 465);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(76, 23);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(702, 465);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(76, 23);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(784, 465);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(76, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // Numero
            // 
            Numero.AutoSize = true;
            Numero.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Numero.Location = new Point(63, 64);
            Numero.Name = "Numero";
            Numero.Size = new Size(106, 30);
            Numero.TabIndex = 3;
            Numero.Text = "NUMERO";
            // 
            // txtFolio
            // 
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFolio.Location = new Point(175, 66);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(245, 23);
            txtFolio.TabIndex = 4;
            txtFolio.KeyPress += txtFolio_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 97);
            label2.Name = "label2";
            label2.Size = new Size(126, 21);
            label2.TabIndex = 5;
            label2.Text = "DEPARTAMENTO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(562, 93);
            label3.Name = "label3";
            label3.Size = new Size(48, 21);
            label3.TabIndex = 7;
            label3.Text = "AREA";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(562, 122);
            label4.Name = "label4";
            label4.Size = new Size(78, 21);
            label4.TabIndex = 9;
            label4.Text = "DIDECON";
            // 
            // txtDidecon
            // 
            txtDidecon.BorderStyle = BorderStyle.FixedSingle;
            txtDidecon.Font = new Font("Segoe UI", 9F);
            txtDidecon.Location = new Point(646, 122);
            txtDidecon.Name = "txtDidecon";
            txtDidecon.Size = new Size(215, 23);
            txtDidecon.TabIndex = 10;
            txtDidecon.KeyPress += txtDidecon_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(55, 126);
            label5.Name = "label5";
            label5.Size = new Size(114, 21);
            label5.TabIndex = 11;
            label5.Text = "RESPONSABLE";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(0, 0);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 38;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(585, 154);
            label7.Name = "label7";
            label7.Size = new Size(55, 21);
            label7.TabIndex = 16;
            label7.Text = "DIR. IP";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(105, 185);
            label8.Name = "label8";
            label8.Size = new Size(64, 21);
            label8.TabIndex = 17;
            label8.Text = "MARCA";
            // 
            // boxMarca
            // 
            boxMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            boxMarca.FlatStyle = FlatStyle.Popup;
            boxMarca.Font = new Font("Segoe UI", 9F);
            boxMarca.FormattingEnabled = true;
            boxMarca.Location = new Point(175, 183);
            boxMarca.Name = "boxMarca";
            boxMarca.Size = new Size(245, 23);
            boxMarca.TabIndex = 18;
            boxMarca.SelectedIndexChanged += boxMarca_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(76, 243);
            label9.Name = "label9";
            label9.Size = new Size(93, 21);
            label9.TabIndex = 19;
            label9.Text = "NUM. SERIE";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(95, 214);
            label10.Name = "label10";
            label10.Size = new Size(74, 21);
            label10.TabIndex = 21;
            label10.Text = "MODELO";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(529, 214);
            label11.Name = "label11";
            label11.Size = new Size(111, 21);
            label11.TabIndex = 23;
            label11.Text = "PROCESADOR";
            // 
            // txtProcesador
            // 
            txtProcesador.BorderStyle = BorderStyle.FixedSingle;
            txtProcesador.Font = new Font("Segoe UI", 9F);
            txtProcesador.Location = new Point(646, 210);
            txtProcesador.Name = "txtProcesador";
            txtProcesador.Size = new Size(214, 23);
            txtProcesador.TabIndex = 24;
            txtProcesador.TextChanged += txtProcesador_TextChanged;
            // 
            // boxModelo
            // 
            boxModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxModelo.FlatStyle = FlatStyle.Popup;
            boxModelo.Font = new Font("Segoe UI", 9F);
            boxModelo.FormattingEnabled = true;
            boxModelo.Location = new Point(175, 212);
            boxModelo.Name = "boxModelo";
            boxModelo.Size = new Size(245, 23);
            boxModelo.TabIndex = 25;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(558, 241);
            label12.Name = "label12";
            label12.Size = new Size(82, 21);
            label12.TabIndex = 26;
            label12.Text = "MEMORIA";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(536, 270);
            label13.Name = "label13";
            label13.Size = new Size(104, 21);
            label13.TabIndex = 28;
            label13.Text = "DISCO DURO";
            // 
            // boxDepartamento
            // 
            boxDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            boxDepartamento.FlatStyle = FlatStyle.Popup;
            boxDepartamento.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boxDepartamento.FormattingEnabled = true;
            boxDepartamento.Location = new Point(175, 95);
            boxDepartamento.Name = "boxDepartamento";
            boxDepartamento.Size = new Size(245, 23);
            boxDepartamento.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(19, 301);
            label6.Name = "label6";
            label6.Size = new Size(150, 21);
            label6.TabIndex = 33;
            label6.Text = "ACT. CONTRALORIA";
            // 
            // boxArea
            // 
            boxArea.DropDownStyle = ComboBoxStyle.DropDownList;
            boxArea.FlatStyle = FlatStyle.Popup;
            boxArea.Font = new Font("Segoe UI", 9F);
            boxArea.FormattingEnabled = true;
            boxArea.Location = new Point(616, 93);
            boxArea.Name = "boxArea";
            boxArea.Size = new Size(245, 23);
            boxArea.TabIndex = 35;
            // 
            // boxResponsable
            // 
            boxResponsable.DropDownStyle = ComboBoxStyle.DropDownList;
            boxResponsable.FlatStyle = FlatStyle.Popup;
            boxResponsable.Font = new Font("Segoe UI", 9F);
            boxResponsable.FormattingEnabled = true;
            boxResponsable.Location = new Point(175, 124);
            boxResponsable.Name = "boxResponsable";
            boxResponsable.Size = new Size(245, 23);
            boxResponsable.TabIndex = 36;
            // 
            // boxDireccion
            // 
            boxDireccion.DropDownStyle = ComboBoxStyle.DropDownList;
            boxDireccion.FlatStyle = FlatStyle.Popup;
            boxDireccion.Font = new Font("Segoe UI", 9F);
            boxDireccion.FormattingEnabled = true;
            boxDireccion.Location = new Point(646, 152);
            boxDireccion.Name = "boxDireccion";
            boxDireccion.Size = new Size(214, 23);
            boxDireccion.TabIndex = 37;
            // 
            // boxNumSerie
            // 
            boxNumSerie.DropDownStyle = ComboBoxStyle.DropDownList;
            boxNumSerie.FlatStyle = FlatStyle.Flat;
            boxNumSerie.Font = new Font("Segoe UI", 9F);
            boxNumSerie.FormattingEnabled = true;
            boxNumSerie.Location = new Point(175, 241);
            boxNumSerie.Name = "boxNumSerie";
            boxNumSerie.Size = new Size(245, 23);
            boxNumSerie.TabIndex = 39;
            boxNumSerie.TextChanged += boxNumSerie_TextChanged;
            boxNumSerie.KeyPress += boxNumSerie_KeyPress;
            // 
            // textDisco
            // 
            textDisco.BorderStyle = BorderStyle.FixedSingle;
            textDisco.Font = new Font("Segoe UI", 9F);
            textDisco.Location = new Point(646, 268);
            textDisco.Name = "textDisco";
            textDisco.Size = new Size(214, 23);
            textDisco.TabIndex = 40;
            textDisco.TextChanged += textDisco_TextChanged;
            // 
            // boxActivo
            // 
            boxActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxActivo.FlatStyle = FlatStyle.Popup;
            boxActivo.Font = new Font("Segoe UI", 9F);
            boxActivo.FormattingEnabled = true;
            boxActivo.Location = new Point(175, 299);
            boxActivo.Name = "boxActivo";
            boxActivo.Size = new Size(245, 23);
            boxActivo.TabIndex = 41;
            // 
            // txtMemoria
            // 
            txtMemoria.BorderStyle = BorderStyle.FixedSingle;
            txtMemoria.Font = new Font("Segoe UI", 9F);
            txtMemoria.Location = new Point(646, 239);
            txtMemoria.Name = "txtMemoria";
            txtMemoria.Size = new Size(214, 23);
            txtMemoria.TabIndex = 42;
            txtMemoria.TextChanged += txtMemoria_TextChanged;
            // 
            // btnNuevoMarca
            // 
            btnNuevoMarca.Cursor = Cursors.Hand;
            btnNuevoMarca.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoMarca.Location = new Point(427, 185);
            btnNuevoMarca.Name = "btnNuevoMarca";
            btnNuevoMarca.Size = new Size(88, 23);
            btnNuevoMarca.TabIndex = 44;
            btnNuevoMarca.Text = "GESTIONAR";
            btnNuevoMarca.UseVisualStyleBackColor = true;
            btnNuevoMarca.Click += btnNuevoMarca_Click;
            // 
            // btnNuevoModelo
            // 
            btnNuevoModelo.Cursor = Cursors.Hand;
            btnNuevoModelo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoModelo.Location = new Point(427, 214);
            btnNuevoModelo.Name = "btnNuevoModelo";
            btnNuevoModelo.Size = new Size(88, 23);
            btnNuevoModelo.TabIndex = 45;
            btnNuevoModelo.Text = "GESTIONAR";
            btnNuevoModelo.UseVisualStyleBackColor = true;
            btnNuevoModelo.Click += btnNuevoModelo_Click;
            // 
            // btnPerifericos
            // 
            btnPerifericos.Cursor = Cursors.Hand;
            btnPerifericos.FlatStyle = FlatStyle.System;
            btnPerifericos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPerifericos.Location = new Point(105, 466);
            btnPerifericos.Name = "btnPerifericos";
            btnPerifericos.Size = new Size(89, 21);
            btnPerifericos.TabIndex = 46;
            btnPerifericos.Text = "PERIFERICOS";
            btnPerifericos.UseVisualStyleBackColor = true;
            btnPerifericos.Click += btnPerifericos_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(58, 156);
            label14.Name = "label14";
            label14.Size = new Size(111, 21);
            label14.TabIndex = 47;
            label14.Text = "NOM. EQUIPO";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(53, 272);
            label15.Name = "label15";
            label15.Size = new Size(116, 21);
            label15.TabIndex = 50;
            label15.Text = "ACT. SISTEMAS";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.Location = new Point(49, 330);
            label16.Name = "label16";
            label16.Size = new Size(120, 21);
            label16.TabIndex = 52;
            label16.Text = "NUM. FACTURA";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.Location = new Point(41, 359);
            label17.Name = "label17";
            label17.Size = new Size(128, 21);
            label17.TabIndex = 54;
            label17.Text = "VALOR FACTURA";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.Location = new Point(69, 388);
            label18.Name = "label18";
            label18.Size = new Size(100, 21);
            label18.TabIndex = 56;
            label18.Text = "PROVEEDOR";
            // 
            // boxEstatus
            // 
            boxEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            boxEstatus.FlatStyle = FlatStyle.Popup;
            boxEstatus.Font = new Font("Segoe UI", 9F);
            boxEstatus.FormattingEnabled = true;
            boxEstatus.Location = new Point(175, 415);
            boxEstatus.Name = "boxEstatus";
            boxEstatus.Size = new Size(245, 23);
            boxEstatus.TabIndex = 57;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label19.Location = new Point(98, 417);
            label19.Name = "label19";
            label19.Size = new Size(71, 21);
            label19.TabIndex = 58;
            label19.Text = "ESTATUS";
            // 
            // boxTipo
            // 
            boxTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxTipo.FlatStyle = FlatStyle.Popup;
            boxTipo.Font = new Font("Segoe UI", 9F);
            boxTipo.FormattingEnabled = true;
            boxTipo.Location = new Point(616, 64);
            boxTipo.Name = "boxTipo";
            boxTipo.Size = new Size(245, 23);
            boxTipo.TabIndex = 59;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.Location = new Point(567, 66);
            label20.Name = "label20";
            label20.Size = new Size(43, 21);
            label20.TabIndex = 60;
            label20.Text = "TIPO";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label21.Location = new Point(577, 185);
            label21.Name = "label21";
            label21.Size = new Size(63, 21);
            label21.TabIndex = 62;
            label21.Text = "GRUPO";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(646, 297);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(85, 23);
            dateTimePicker1.TabIndex = 90;
            dateTimePicker1.Value = new DateTime(2025, 3, 14, 9, 28, 11, 0);
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label22.Location = new Point(583, 299);
            label22.Name = "label22";
            label22.Size = new Size(57, 21);
            label22.TabIndex = 89;
            label22.Text = "FECHA";
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.Location = new Point(516, 465);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(76, 23);
            btnBuscar.TabIndex = 91;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // boxNombre
            // 
            boxNombre.DropDownStyle = ComboBoxStyle.DropDownList;
            boxNombre.FlatStyle = FlatStyle.Popup;
            boxNombre.Font = new Font("Segoe UI", 9F);
            boxNombre.FormattingEnabled = true;
            boxNombre.Location = new Point(175, 152);
            boxNombre.Name = "boxNombre";
            boxNombre.Size = new Size(245, 23);
            boxNombre.TabIndex = 92;
            boxNombre.TextChanged += boxNombre_TextChanged;
            // 
            // boxGrupo
            // 
            boxGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxGrupo.FlatStyle = FlatStyle.Popup;
            boxGrupo.Font = new Font("Segoe UI", 9F);
            boxGrupo.FormattingEnabled = true;
            boxGrupo.Location = new Point(646, 181);
            boxGrupo.Name = "boxGrupo";
            boxGrupo.Size = new Size(214, 23);
            boxGrupo.TabIndex = 93;
            boxGrupo.TextChanged += boxGrupo_TextChanged;
            boxGrupo.KeyPress += boxGrupo_KeyPress;

            // 
            // boxActSistemas
            // 
            boxActSistemas.DropDownStyle = ComboBoxStyle.DropDownList;
            boxActSistemas.FlatStyle = FlatStyle.Popup;
            boxActSistemas.Font = new Font("Segoe UI", 9F);
            boxActSistemas.FormattingEnabled = true;
            boxActSistemas.Location = new Point(175, 270);
            boxActSistemas.Name = "boxActSistemas";
            boxActSistemas.Size = new Size(245, 23);
            boxActSistemas.TabIndex = 94;
            boxActSistemas.TextChanged += boxActSistemas_TextChanged;
            boxActSistemas.KeyPress += boxActSistemas_KeyPress;
            // 
            // boxProveedor
            // 
            boxProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            boxProveedor.FlatStyle = FlatStyle.Popup;
            boxProveedor.Font = new Font("Segoe UI", 9F);
            boxProveedor.FormattingEnabled = true;
            boxProveedor.Location = new Point(175, 386);
            boxProveedor.Name = "boxProveedor";
            boxProveedor.Size = new Size(245, 23);
            boxProveedor.TabIndex = 95;
            boxProveedor.TextChanged += boxProveedor_TextChanged;
            boxProveedor.KeyPress += boxProveedor_KeyPress;
            // 
            // boxNumFactura
            // 
            boxNumFactura.DropDownStyle = ComboBoxStyle.DropDownList;
            boxNumFactura.FlatStyle = FlatStyle.Popup;
            boxNumFactura.Font = new Font("Segoe UI", 9F);
            boxNumFactura.FormattingEnabled = true;
            boxNumFactura.Location = new Point(175, 328);
            boxNumFactura.Name = "boxNumFactura";
            boxNumFactura.Size = new Size(245, 23);
            boxNumFactura.TabIndex = 96;
            boxNumFactura.TextChanged += boxNumFactura_TextChanged;
            // 
            // boxValorFactura
            // 
            boxValorFactura.DropDownStyle = ComboBoxStyle.DropDownList;
            boxValorFactura.FlatStyle = FlatStyle.Popup;
            boxValorFactura.Font = new Font("Segoe UI", 9F);
            boxValorFactura.FormattingEnabled = true;
            boxValorFactura.Location = new Point(175, 357);
            boxValorFactura.Name = "boxValorFactura";
            boxValorFactura.Size = new Size(245, 23);
            boxValorFactura.TabIndex = 97;
            boxValorFactura.KeyPress += boxValorFactura_KeyPress;
            // 
            // Hardware
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(877, 514);
            Controls.Add(boxValorFactura);
            Controls.Add(boxNumFactura);
            Controls.Add(boxProveedor);
            Controls.Add(boxActSistemas);
            Controls.Add(boxGrupo);
            Controls.Add(boxNombre);
            Controls.Add(btnBuscar);
            Controls.Add(dateTimePicker1);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(boxTipo);
            Controls.Add(label19);
            Controls.Add(boxEstatus);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(btnPerifericos);
            Controls.Add(btnNuevoModelo);
            Controls.Add(btnNuevoMarca);
            Controls.Add(txtMemoria);
            Controls.Add(boxActivo);
            Controls.Add(textDisco);
            Controls.Add(boxNumSerie);
            Controls.Add(boxDireccion);
            Controls.Add(boxResponsable);
            Controls.Add(boxArea);
            Controls.Add(label6);
            Controls.Add(panelBarra);
            Controls.Add(boxDepartamento);
            Controls.Add(txtFolio);
            Controls.Add(btnNuevo);
            Controls.Add(label13);
            Controls.Add(btnAceptar);
            Controls.Add(label12);
            Controls.Add(btnCancelar);
            Controls.Add(boxModelo);
            Controls.Add(Numero);
            Controls.Add(txtProcesador);
            Controls.Add(label2);
            Controls.Add(label11);
            Controls.Add(label3);
            Controls.Add(label10);
            Controls.Add(label4);
            Controls.Add(label9);
            Controls.Add(txtDidecon);
            Controls.Add(boxMarca);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtDireccion);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Hardware";
            Text = "TIPO";
            Load += Hardware_Load_1;
            panelBarra.ResumeLayout(false);
            panelBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelBarra;
        private Button btnNuevo;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label Numero;
        private TextBox txtFolio;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtDidecon;
        private Label label5;
        private TextBox txtDireccion;
        private Label label7;
        private Label label8;
        private ComboBox boxMarca;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtProcesador;
        private ComboBox boxModelo;
        private Label label12;
        private Label label13;
        private ComboBox boxDepartamento;
        private PictureBox buttonSalir;
        private Label label6;
        private ComboBox boxArea;
        private ComboBox boxResponsable;
        private ComboBox boxDireccion;
        private ComboBox boxNumSerie;
        private TextBox textDisco;
        private ComboBox boxActivo;
        private TextBox txtMemoria;
        private Button btnNuevoMarca;
        private Button btnNuevoModelo;
        private Button btnPerifericos;
        private Label label1;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private ComboBox boxEstatus;
        private Label label19;
        private ComboBox boxTipo;
        private Label label20;
        private Label label21;
        private DateTimePicker dateTimePicker1;
        private Label label22;
        private Button btnBuscar;
        private ComboBox boxNombre;
        private ComboBox boxGrupo;
        private ComboBox boxActSistemas;
        private ComboBox boxProveedor;
        private ComboBox boxNumFactura;
        private ComboBox boxValorFactura;
    }
}