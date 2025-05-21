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
            this.radioEquipo = new System.Windows.Forms.RadioButton();
            this.radioUno = new System.Windows.Forms.RadioButton();
            this.radioTodos = new System.Windows.Forms.RadioButton();
            this.boxDepartamentos = new System.Windows.Forms.ComboBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
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
            this.btnCerrar.Location = new System.Drawing.Point(475, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(21, 23);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 35;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioEquipo);
            this.panel1.Controls.Add(this.radioUno);
            this.panel1.Controls.Add(this.radioTodos);
            this.panel1.Location = new System.Drawing.Point(14, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 148);
            this.panel1.TabIndex = 36;
            // 
            // radioEquipo
            // 
            this.radioEquipo.AutoSize = true;
            this.radioEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioEquipo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioEquipo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEquipo.Location = new System.Drawing.Point(13, 99);
            this.radioEquipo.Name = "radioEquipo";
            this.radioEquipo.Size = new System.Drawing.Size(167, 22);
            this.radioEquipo.TabIndex = 2;
            this.radioEquipo.TabStop = true;
            this.radioEquipo.Text = "IMPRIMIR UN EQUIPO";
            this.radioEquipo.UseVisualStyleBackColor = true;
            this.radioEquipo.CheckedChanged += new System.EventHandler(this.radioEquipo_CheckedChanged);
            // 
            // radioUno
            // 
            this.radioUno.AutoSize = true;
            this.radioUno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioUno.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioUno.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioUno.Location = new System.Drawing.Point(13, 62);
            this.radioUno.Name = "radioUno";
            this.radioUno.Size = new System.Drawing.Size(256, 22);
            this.radioUno.TabIndex = 1;
            this.radioUno.TabStop = true;
            this.radioUno.Text = "IMPRIMIR SOLO UN DEPARTAMENTO";
            this.radioUno.UseVisualStyleBackColor = true;
            this.radioUno.CheckedChanged += new System.EventHandler(this.radioUno_CheckedChanged);
            // 
            // radioTodos
            // 
            this.radioTodos.AutoSize = true;
            this.radioTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioTodos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioTodos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTodos.Location = new System.Drawing.Point(13, 23);
            this.radioTodos.Name = "radioTodos";
            this.radioTodos.Size = new System.Drawing.Size(276, 22);
            this.radioTodos.TabIndex = 0;
            this.radioTodos.TabStop = true;
            this.radioTodos.Text = "IMPRIMIR TODOS LOS DEPARTAMENTOS";
            this.radioTodos.UseVisualStyleBackColor = true;
            this.radioTodos.CheckedChanged += new System.EventHandler(this.radioTodos_CheckedChanged);
            // 
            // boxDepartamentos
            // 
            this.boxDepartamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxDepartamentos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boxDepartamentos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxDepartamentos.FormattingEnabled = true;
            this.boxDepartamentos.Location = new System.Drawing.Point(14, 222);
            this.boxDepartamentos.Name = "boxDepartamentos";
            this.boxDepartamentos.Size = new System.Drawing.Size(482, 23);
            this.boxDepartamentos.TabIndex = 37;
            // 
            // txtFolio
            // 
            this.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolio.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.Location = new System.Drawing.Point(65, 221);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(135, 23);
            this.txtFolio.TabIndex = 38;
            this.txtFolio.Visible = false;
            this.txtFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarFolio_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "FOLIO:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(331, 255);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(78, 20);
            this.btnAceptar.TabIndex = 40;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(415, 255);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(78, 20);
            this.btnCancelar.TabIndex = 41;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Inventario
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 292);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.boxDepartamentos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
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
        private TextBox txtFolio;
        private Label label1;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}