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
            boxBuscarTipo = new ComboBox();
            label3 = new Label();
            txtBuscarDidecon = new TextBox();
            label4 = new Label();
            boxBuscarMarca = new ComboBox();
            label7 = new Label();
            txtBuscarNumSerie = new TextBox();
            label11 = new Label();
            button1 = new Button();
            button2 = new Button();
            label12 = new Label();
            btnHardware = new Button();
            panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPerifericos).BeginInit();
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
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.Image = (Image)resources.GetObject("buttonSalir.Image");
            buttonSalir.Location = new Point(745, 4);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(25, 27);
            buttonSalir.SizeMode = PictureBoxSizeMode.StretchImage;
            buttonSalir.TabIndex = 32;
            buttonSalir.TabStop = false;
            // 
            // txtFolio
            // 
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFolio.Location = new Point(128, 66);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(216, 23);
            txtFolio.TabIndex = 35;
            // 
            // Numero
            // 
            Numero.AutoSize = true;
            Numero.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Numero.Location = new Point(16, 59);
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
            boxDidecon.Location = new Point(128, 101);
            boxDidecon.Name = "boxDidecon";
            boxDidecon.Size = new Size(216, 23);
            boxDidecon.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(44, 103);
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
            boxTipo.Location = new Point(128, 139);
            boxTipo.Name = "boxTipo";
            boxTipo.Size = new Size(216, 23);
            boxTipo.TabIndex = 39;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(79, 141);
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
            // 
            // boxModelo
            // 
            boxModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxModelo.Font = new Font("Segoe UI", 9F);
            boxModelo.FormattingEnabled = true;
            boxModelo.Location = new Point(528, 70);
            boxModelo.Name = "boxModelo";
            boxModelo.Size = new Size(233, 23);
            boxModelo.TabIndex = 49;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(448, 72);
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
            boxMarca.Location = new Point(528, 104);
            boxMarca.Name = "boxMarca";
            boxMarca.Size = new Size(233, 23);
            boxMarca.TabIndex = 47;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(458, 106);
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
            boxActivo.Location = new Point(528, 139);
            boxActivo.Name = "boxActivo";
            boxActivo.Size = new Size(233, 23);
            boxActivo.TabIndex = 55;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(372, 145);
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
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(319, 217);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 58;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
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
            // boxBuscarTipo
            // 
            boxBuscarTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxBuscarTipo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boxBuscarTipo.FormattingEnabled = true;
            boxBuscarTipo.Location = new Point(324, 319);
            boxBuscarTipo.Name = "boxBuscarTipo";
            boxBuscarTipo.Size = new Size(135, 23);
            boxBuscarTipo.TabIndex = 66;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(274, 321);
            label3.Name = "label3";
            label3.Size = new Size(43, 21);
            label3.TabIndex = 65;
            label3.Text = "TIPO";
            // 
            // txtBuscarDidecon
            // 
            txtBuscarDidecon.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarDidecon.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBuscarDidecon.Location = new Point(125, 317);
            txtBuscarDidecon.Name = "txtBuscarDidecon";
            txtBuscarDidecon.Size = new Size(135, 23);
            txtBuscarDidecon.TabIndex = 64;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(35, 319);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(78, 21);
            label4.TabIndex = 63;
            label4.Text = "DIDECON";
            // 
            // boxBuscarMarca
            // 
            boxBuscarMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            boxBuscarMarca.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boxBuscarMarca.FormattingEnabled = true;
            boxBuscarMarca.Location = new Point(549, 323);
            boxBuscarMarca.Name = "boxBuscarMarca";
            boxBuscarMarca.Size = new Size(135, 23);
            boxBuscarMarca.TabIndex = 68;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(479, 325);
            label7.Name = "label7";
            label7.Size = new Size(64, 21);
            label7.TabIndex = 67;
            label7.Text = "MARCA";
            // 
            // txtBuscarNumSerie
            // 
            txtBuscarNumSerie.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarNumSerie.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBuscarNumSerie.Location = new Point(125, 362);
            txtBuscarNumSerie.Name = "txtBuscarNumSerie";
            txtBuscarNumSerie.Size = new Size(135, 23);
            txtBuscarNumSerie.TabIndex = 70;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(20, 364);
            label11.Name = "label11";
            label11.RightToLeft = RightToLeft.No;
            label11.Size = new Size(93, 21);
            label11.TabIndex = 69;
            label11.Text = "NUM. SERIE";
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(506, 362);
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
            button2.Location = new Point(587, 362);
            button2.Name = "button2";
            button2.Size = new Size(97, 23);
            button2.TabIndex = 72;
            button2.Text = "REESTABLECER";
            button2.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(35, 291);
            label12.Name = "label12";
            label12.RightToLeft = RightToLeft.No;
            label12.Size = new Size(252, 15);
            label12.TabIndex = 73;
            label12.Text = "RELLENE UNO O MAS CAMPOS PARA FILTRAR";
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
            // Perifericos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 597);
            Controls.Add(btnHardware);
            Controls.Add(label12);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(txtBuscarNumSerie);
            Controls.Add(label11);
            Controls.Add(boxBuscarMarca);
            Controls.Add(label7);
            Controls.Add(boxBuscarTipo);
            Controls.Add(label3);
            Controls.Add(txtBuscarDidecon);
            Controls.Add(label4);
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
            Text = "Perifericos";
            panelBarra.ResumeLayout(false);
            panelBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPerifericos).EndInit();
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
        private ComboBox boxBuscarTipo;
        private Label label3;
        private TextBox txtBuscarDidecon;
        private Label label4;
        private ComboBox boxBuscarMarca;
        private Label label7;
        private TextBox txtBuscarNumSerie;
        private Label label11;
        private Button button1;
        private Button button2;
        private Label label12;
        private Button btnHardware;
    }
}