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
            buttonSalir = new PictureBox();
            btnNuevo = new Button();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
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
            boxMemoria = new ComboBox();
            boxDepartamento = new ComboBox();
            label6 = new Label();
            boxArea = new ComboBox();
            boxResponsable = new ComboBox();
            boxDireccion = new ComboBox();
            boxNumSerie = new ComboBox();
            textDisco = new TextBox();
            boxActivo = new ComboBox();
            panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSalir).BeginInit();
            SuspendLayout();
            // 
            // panelBarra
            // 
            panelBarra.BackColor = Color.DodgerBlue;
            panelBarra.BorderStyle = BorderStyle.FixedSingle;
            panelBarra.Controls.Add(buttonSalir);
            panelBarra.Location = new Point(-1, 0);
            panelBarra.Name = "panelBarra";
            panelBarra.Size = new Size(696, 35);
            panelBarra.TabIndex = 32;
            // 
            // buttonSalir
            // 
            buttonSalir.Cursor = Cursors.Hand;
            buttonSalir.Image = (Image)resources.GetObject("buttonSalir.Image");
            buttonSalir.Location = new Point(665, 3);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(24, 27);
            buttonSalir.SizeMode = PictureBoxSizeMode.StretchImage;
            buttonSalir.TabIndex = 32;
            buttonSalir.TabStop = false;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(393, 545);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(89, 23);
            btnNuevo.TabIndex = 0;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAceptar.Location = new Point(488, 545);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(89, 23);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(583, 545);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(89, 23);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(73, 68);
            label1.Name = "label1";
            label1.Size = new Size(54, 30);
            label1.TabIndex = 3;
            label1.Text = "CPU";
            // 
            // txtFolio
            // 
            txtFolio.BorderStyle = BorderStyle.FixedSingle;
            txtFolio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtFolio.Location = new Point(139, 68);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(245, 23);
            txtFolio.TabIndex = 4;
            //txtFolio.TextChanged += txtFolio_TextChanged;
            txtFolio.KeyPress += txtFolio_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 112);
            label2.Name = "label2";
            label2.Size = new Size(110, 21);
            label2.TabIndex = 5;
            label2.Text = "Departamento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(396, 112);
            label3.Name = "label3";
            label3.Size = new Size(42, 21);
            label3.TabIndex = 7;
            label3.Text = "Area";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(59, 152);
            label4.Name = "label4";
            label4.Size = new Size(67, 21);
            label4.TabIndex = 9;
            label4.Text = "Didecon";
            // 
            // txtDidecon
            // 
            txtDidecon.BorderStyle = BorderStyle.FixedSingle;
            txtDidecon.Font = new Font("Segoe UI", 9F);
            txtDidecon.Location = new Point(139, 150);
            txtDidecon.Name = "txtDidecon";
            txtDidecon.Size = new Size(245, 23);
            txtDidecon.TabIndex = 10;
            txtDidecon.KeyPress += txtDidecon_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(29, 195);
            label5.Name = "label5";
            label5.Size = new Size(98, 21);
            label5.TabIndex = 11;
            label5.Text = "Responsable";
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
            label7.Location = new Point(35, 237);
            label7.Name = "label7";
            label7.Size = new Size(92, 21);
            label7.TabIndex = 16;
            label7.Text = "Direccion IP";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(73, 280);
            label8.Name = "label8";
            label8.Size = new Size(53, 21);
            label8.TabIndex = 17;
            label8.Text = "Marca";
            // 
            // boxMarca
            // 
            boxMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            boxMarca.Font = new Font("Segoe UI", 9F);
            boxMarca.FormattingEnabled = true;
            boxMarca.Location = new Point(139, 278);
            boxMarca.Name = "boxMarca";
            boxMarca.Size = new Size(245, 23);
            boxMarca.TabIndex = 18;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(39, 322);
            label9.Name = "label9";
            label9.Size = new Size(87, 21);
            label9.TabIndex = 19;
            label9.Text = "Num. Serie";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(64, 363);
            label10.Name = "label10";
            label10.Size = new Size(63, 21);
            label10.TabIndex = 21;
            label10.Text = "Modelo";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(39, 406);
            label11.Name = "label11";
            label11.Size = new Size(88, 21);
            label11.TabIndex = 23;
            label11.Text = "Procesador";
            // 
            // txtProcesador
            // 
            txtProcesador.BorderStyle = BorderStyle.FixedSingle;
            txtProcesador.Font = new Font("Segoe UI", 9F);
            txtProcesador.Location = new Point(139, 404);
            txtProcesador.Name = "txtProcesador";
            txtProcesador.Size = new Size(245, 23);
            txtProcesador.TabIndex = 24;
            txtProcesador.TextChanged += txtProcesador_TextChanged;
            // 
            // boxModelo
            // 
            boxModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxModelo.Font = new Font("Segoe UI", 9F);
            boxModelo.FormattingEnabled = true;
            boxModelo.Location = new Point(139, 361);
            boxModelo.Name = "boxModelo";
            boxModelo.Size = new Size(245, 23);
            boxModelo.TabIndex = 25;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(54, 450);
            label12.Name = "label12";
            label12.Size = new Size(73, 21);
            label12.TabIndex = 26;
            label12.Text = "Memoria";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(40, 490);
            label13.Name = "label13";
            label13.Size = new Size(87, 21);
            label13.TabIndex = 28;
            label13.Text = "Disco Duro";
            // 
            // boxMemoria
            // 
            boxMemoria.DropDownStyle = ComboBoxStyle.DropDownList;
            boxMemoria.Font = new Font("Segoe UI", 9F);
            boxMemoria.FormattingEnabled = true;
            boxMemoria.Location = new Point(139, 448);
            boxMemoria.Name = "boxMemoria";
            boxMemoria.Size = new Size(245, 23);
            boxMemoria.TabIndex = 30;
            // 
            // boxDepartamento
            // 
            boxDepartamento.DropDownStyle = ComboBoxStyle.DropDownList;
            boxDepartamento.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            boxDepartamento.FormattingEnabled = true;
            boxDepartamento.Location = new Point(139, 110);
            boxDepartamento.Name = "boxDepartamento";
            boxDepartamento.Size = new Size(245, 23);
            boxDepartamento.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(396, 152);
            label6.Name = "label6";
            label6.Size = new Size(117, 21);
            label6.TabIndex = 33;
            label6.Text = "Act. Contraloria";
            // 
            // boxArea
            // 
            boxArea.DropDownStyle = ComboBoxStyle.DropDownList;
            boxArea.Font = new Font("Segoe UI", 9F);
            boxArea.FormattingEnabled = true;
            boxArea.Location = new Point(444, 110);
            boxArea.Name = "boxArea";
            boxArea.Size = new Size(228, 23);
            boxArea.TabIndex = 35;
            // 
            // boxResponsable
            // 
            boxResponsable.DropDownStyle = ComboBoxStyle.DropDownList;
            boxResponsable.Font = new Font("Segoe UI", 9F);
            boxResponsable.FormattingEnabled = true;
            boxResponsable.Location = new Point(139, 197);
            boxResponsable.Name = "boxResponsable";
            boxResponsable.Size = new Size(245, 23);
            boxResponsable.TabIndex = 36;
            // 
            // boxDireccion
            // 
            boxDireccion.DropDownStyle = ComboBoxStyle.DropDownList;
            boxDireccion.Font = new Font("Segoe UI", 9F);
            boxDireccion.FormattingEnabled = true;
            boxDireccion.Location = new Point(139, 237);
            boxDireccion.Name = "boxDireccion";
            boxDireccion.Size = new Size(245, 23);
            boxDireccion.TabIndex = 37;
            // 
            // boxNumSerie
            // 
            boxNumSerie.DropDownStyle = ComboBoxStyle.DropDownList;
            boxNumSerie.Font = new Font("Segoe UI", 9F);
            boxNumSerie.FormattingEnabled = true;
            boxNumSerie.Location = new Point(139, 320);
            boxNumSerie.Name = "boxNumSerie";
            boxNumSerie.Size = new Size(245, 23);
            boxNumSerie.TabIndex = 39;
            // 
            // textDisco
            // 
            textDisco.BorderStyle = BorderStyle.FixedSingle;
            textDisco.Font = new Font("Segoe UI", 9F);
            textDisco.Location = new Point(139, 488);
            textDisco.Name = "textDisco";
            textDisco.Size = new Size(245, 23);
            textDisco.TabIndex = 40;
            textDisco.TextChanged += textDisco_TextChanged;
            // 
            // boxActivo
            // 
            boxActivo.DropDownStyle = ComboBoxStyle.DropDownList;
            boxActivo.Font = new Font("Segoe UI", 9F);
            boxActivo.FormattingEnabled = true;
            boxActivo.Location = new Point(519, 149);
            boxActivo.Name = "boxActivo";
            boxActivo.Size = new Size(153, 23);
            boxActivo.TabIndex = 41;
            // 
            // Hardware
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(694, 580);
            Controls.Add(boxActivo);
            Controls.Add(textDisco);
            Controls.Add(boxNumSerie);
            Controls.Add(boxDireccion);
            Controls.Add(boxResponsable);
            Controls.Add(boxArea);
            Controls.Add(label6);
            Controls.Add(panelBarra);
            Controls.Add(boxDepartamento);
            Controls.Add(boxMemoria);
            Controls.Add(txtFolio);
            Controls.Add(btnNuevo);
            Controls.Add(label13);
            Controls.Add(btnAceptar);
            Controls.Add(label12);
            Controls.Add(btnCancelar);
            Controls.Add(boxModelo);
            Controls.Add(label1);
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
            Text = "Perifericos";
            Load += Perifericos_Load_1;
            panelBarra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)buttonSalir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelBarra;
        private Button btnNuevo;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label1;
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
        private ComboBox boxMemoria;
        private ComboBox boxDepartamento;
        private PictureBox buttonSalir;
        private Label label6;
        private ComboBox boxArea;
        private ComboBox boxResponsable;
        private ComboBox boxDireccion;
        private ComboBox boxNumSerie;
        private TextBox textDisco;
        private ComboBox boxActivo;
    }
}