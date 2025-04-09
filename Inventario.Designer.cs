namespace WinFormsApp1
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioTodos = new System.Windows.Forms.RadioButton();
            this.radioUno = new System.Windows.Forms.RadioButton();
            this.radioEquipo = new System.Windows.Forms.RadioButton();
            this.boxDepartamentos = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(473, 10);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(21, 23);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 35;
            this.btnCerrar.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioEquipo);
            this.panel1.Controls.Add(this.radioUno);
            this.panel1.Controls.Add(this.radioTodos);
            this.panel1.Location = new System.Drawing.Point(11, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 148);
            this.panel1.TabIndex = 36;
            // 
            // radioTodos
            // 
            this.radioTodos.AutoSize = true;
            this.radioTodos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTodos.Location = new System.Drawing.Point(13, 23);
            this.radioTodos.Name = "radioTodos";
            this.radioTodos.Size = new System.Drawing.Size(329, 21);
            this.radioTodos.TabIndex = 0;
            this.radioTodos.TabStop = true;
            this.radioTodos.Text = "IMPRIMIR TODOS LOS DEPARTAMENTOS";
            this.radioTodos.UseVisualStyleBackColor = true;
            // 
            // radioUno
            // 
            this.radioUno.AutoSize = true;
            this.radioUno.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioUno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioUno.Location = new System.Drawing.Point(13, 62);
            this.radioUno.Name = "radioUno";
            this.radioUno.Size = new System.Drawing.Size(299, 21);
            this.radioUno.TabIndex = 1;
            this.radioUno.TabStop = true;
            this.radioUno.Text = "IMPRIMIR SOLO UN DEPARTAMENTO";
            this.radioUno.UseVisualStyleBackColor = true;
            // 
            // radioEquipo
            // 
            this.radioEquipo.AutoSize = true;
            this.radioEquipo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEquipo.Location = new System.Drawing.Point(13, 99);
            this.radioEquipo.Name = "radioEquipo";
            this.radioEquipo.Size = new System.Drawing.Size(186, 21);
            this.radioEquipo.TabIndex = 2;
            this.radioEquipo.TabStop = true;
            this.radioEquipo.Text = "IMPRIMIR UN EQUIPO";
            this.radioEquipo.UseVisualStyleBackColor = true;
            // 
            // boxDepartamentos
            // 
            this.boxDepartamentos.FormattingEnabled = true;
            this.boxDepartamentos.Location = new System.Drawing.Point(11, 219);
            this.boxDepartamentos.Name = "boxDepartamentos";
            this.boxDepartamentos.Size = new System.Drawing.Size(482, 21);
            this.boxDepartamentos.TabIndex = 37;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 219);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 20);
            this.textBox1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "FOLIO:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(331, 246);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(78, 20);
            this.btnAceptar.TabIndex = 40;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(415, 246);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 20);
            this.btnCancelar.TabIndex = 41;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 292);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.boxDepartamentos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventario";
            this.Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox btnCerrar;
        private Panel panel1;
        private RadioButton radioEquipo;
        private RadioButton radioUno;
        private RadioButton radioTodos;
        private ComboBox boxDepartamentos;
        private TextBox textBox1;
        private Label label1;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}