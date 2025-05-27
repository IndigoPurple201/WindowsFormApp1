namespace WinFormsApp1
{
    partial class Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Compras));
            this.panelBarra = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSalir = new System.Windows.Forms.PictureBox();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.Numero = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFolioOrden = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.boxProveedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boxDepartamento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEntrega = new System.Windows.Forms.TextBox();
            this.txtRecibe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFolioDetalle = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boxCompra = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnEliminar2 = new System.Windows.Forms.Button();
            this.btnActualizar2 = new System.Windows.Forms.Button();
            this.btnAceptar2 = new System.Windows.Forms.Button();
            this.btnNuevo2 = new System.Windows.Forms.Button();
            this.btnBuscar2 = new System.Windows.Forms.Button();
            this.btnCancelar2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRegistros = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panelBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
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
            this.panelBarra.Size = new System.Drawing.Size(645, 36);
            this.panelBarra.TabIndex = 33;
            this.panelBarra.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBarra_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(279, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "COMPRAS";
            // 
            // buttonSalir
            // 
            this.buttonSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(145)))), ((int)(((byte)(145)))));
            this.buttonSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSalir.Image = ((System.Drawing.Image)(resources.GetObject("buttonSalir.Image")));
            this.buttonSalir.Location = new System.Drawing.Point(615, 5);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(21, 23);
            this.buttonSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonSalir.TabIndex = 32;
            this.buttonSalir.TabStop = false;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // txtOrden
            // 
            this.txtOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrden.Location = new System.Drawing.Point(227, 10);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(210, 23);
            this.txtOrden.TabIndex = 35;
            // 
            // Numero
            // 
            this.Numero.AutoSize = true;
            this.Numero.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numero.Location = new System.Drawing.Point(6, 3);
            this.Numero.Name = "Numero";
            this.Numero.Size = new System.Drawing.Size(215, 30);
            this.Numero.TabIndex = 34;
            this.Numero.Text = "ORDEN DE COMPRA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 36;
            this.label4.Text = "FOLIO";
            // 
            // txtFolioOrden
            // 
            this.txtFolioOrden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolioOrden.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFolioOrden.Location = new System.Drawing.Point(228, 38);
            this.txtFolioOrden.Name = "txtFolioOrden";
            this.txtFolioOrden.Size = new System.Drawing.Size(210, 23);
            this.txtFolioOrden.TabIndex = 37;
            this.txtFolioOrden.TextChanged += new System.EventHandler(this.txtFolioOrden_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(443, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 24);
            this.btnBuscar.TabIndex = 100;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(228, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(210, 20);
            this.dateTimePicker1.TabIndex = 102;
            this.dateTimePicker1.Value = new System.DateTime(2025, 3, 14, 9, 28, 11, 0);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(158, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 21);
            this.label22.TabIndex = 101;
            this.label22.Text = "FECHA";
            // 
            // boxProveedor
            // 
            this.boxProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boxProveedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.boxProveedor.FormattingEnabled = true;
            this.boxProveedor.Location = new System.Drawing.Point(228, 93);
            this.boxProveedor.Name = "boxProveedor";
            this.boxProveedor.Size = new System.Drawing.Size(211, 23);
            this.boxProveedor.TabIndex = 104;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(115, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.label5.TabIndex = 103;
            this.label5.Text = "PROVEEDOR";
            // 
            // boxDepartamento
            // 
            this.boxDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boxDepartamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxDepartamento.FormattingEnabled = true;
            this.boxDepartamento.Location = new System.Drawing.Point(228, 122);
            this.boxDepartamento.Name = "boxDepartamento";
            this.boxDepartamento.Size = new System.Drawing.Size(211, 23);
            this.boxDepartamento.TabIndex = 106;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 21);
            this.label2.TabIndex = 105;
            this.label2.Text = "DEPARTAMENTO";
            // 
            // txtEntrega
            // 
            this.txtEntrega.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEntrega.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEntrega.Location = new System.Drawing.Point(227, 151);
            this.txtEntrega.Name = "txtEntrega";
            this.txtEntrega.Size = new System.Drawing.Size(210, 23);
            this.txtEntrega.TabIndex = 108;
            this.txtEntrega.TextChanged += new System.EventHandler(this.txtEntrega_TextChanged);
            // 
            // txtRecibe
            // 
            this.txtRecibe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecibe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRecibe.Location = new System.Drawing.Point(227, 180);
            this.txtRecibe.Name = "txtRecibe";
            this.txtRecibe.Size = new System.Drawing.Size(210, 23);
            this.txtRecibe.TabIndex = 109;
            this.txtRecibe.TextChanged += new System.EventHandler(this.txtRecibe_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(138, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 21);
            this.label3.TabIndex = 107;
            this.label3.Text = "ENTREGA";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(156, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 21);
            this.label6.TabIndex = 110;
            this.label6.Text = "RECIBE";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(18, 225);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(87, 28);
            this.btnNuevo.TabIndex = 111;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(351, 225);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 28);
            this.btnAceptar.TabIndex = 112;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(444, 225);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 113;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(520, 202);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(93, 28);
            this.btnImprimir.TabIndex = 114;
            this.btnImprimir.Text = "IMPIRMIR";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(193, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 30);
            this.label7.TabIndex = 115;
            this.label7.Text = "DETALLES DE LA ORDEN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(35, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 21);
            this.label8.TabIndex = 116;
            this.label8.Text = "FOLIO";
            // 
            // txtFolioDetalle
            // 
            this.txtFolioDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolioDetalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFolioDetalle.Location = new System.Drawing.Point(95, 72);
            this.txtFolioDetalle.Name = "txtFolioDetalle";
            this.txtFolioDetalle.Size = new System.Drawing.Size(120, 23);
            this.txtFolioDetalle.TabIndex = 117;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(38, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 21);
            this.label16.TabIndex = 118;
            this.label16.Text = "DESC.";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(95, 101);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(518, 63);
            this.txtDescripcion.TabIndex = 119;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 21);
            this.label9.TabIndex = 120;
            this.label9.Text = "CANTIDAD";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCantidad.Location = new System.Drawing.Point(95, 175);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(89, 23);
            this.txtCantidad.TabIndex = 121;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtMedida
            // 
            this.txtMedida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMedida.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMedida.Location = new System.Drawing.Point(302, 173);
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.Size = new System.Drawing.Size(311, 23);
            this.txtMedida.TabIndex = 123;
            this.txtMedida.TextChanged += new System.EventHandler(this.txtMedida_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(228, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 21);
            this.label10.TabIndex = 122;
            this.label10.Text = "MEDIDA";
            // 
            // txtPrecio
            // 
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrecio.Location = new System.Drawing.Point(95, 204);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(89, 23);
            this.txtPrecio.TabIndex = 125;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(26, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 21);
            this.label11.TabIndex = 124;
            this.label11.Text = "PRECIO";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotal.Location = new System.Drawing.Point(95, 230);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(89, 23);
            this.txtTotal.TabIndex = 127;
            this.txtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotal_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 21);
            this.label12.TabIndex = 126;
            this.label12.Text = "TOTAL";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.boxCompra);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnEliminar2);
            this.panel1.Controls.Add(this.btnActualizar2);
            this.panel1.Controls.Add(this.btnAceptar2);
            this.panel1.Controls.Add(this.btnNuevo2);
            this.panel1.Controls.Add(this.btnBuscar2);
            this.panel1.Controls.Add(this.btnCancelar2);
            this.panel1.Controls.Add(this.btnImprimir);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtMedida);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtPrecio);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtFolioDetalle);
            this.panel1.Location = new System.Drawing.Point(8, 326);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(628, 277);
            this.panel1.TabIndex = 129;
            // 
            // boxCompra
            // 
            this.boxCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxCompra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.boxCompra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCompra.FormattingEnabled = true;
            this.boxCompra.Location = new System.Drawing.Point(95, 46);
            this.boxCompra.Name = "boxCompra";
            this.boxCompra.Size = new System.Drawing.Size(120, 23);
            this.boxCompra.TabIndex = 117;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 21);
            this.label13.TabIndex = 132;
            this.label13.Text = "COMPRA";
            // 
            // btnEliminar2
            // 
            this.btnEliminar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar2.Location = new System.Drawing.Point(526, 67);
            this.btnEliminar2.Name = "btnEliminar2";
            this.btnEliminar2.Size = new System.Drawing.Size(87, 28);
            this.btnEliminar2.TabIndex = 119;
            this.btnEliminar2.Text = "ELIMINAR";
            this.btnEliminar2.UseVisualStyleBackColor = true;
            // 
            // btnActualizar2
            // 
            this.btnActualizar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar2.Location = new System.Drawing.Point(413, 67);
            this.btnActualizar2.Name = "btnActualizar2";
            this.btnActualizar2.Size = new System.Drawing.Size(107, 28);
            this.btnActualizar2.TabIndex = 118;
            this.btnActualizar2.Text = "ACTUALIZAR";
            this.btnActualizar2.UseVisualStyleBackColor = true;
            // 
            // btnAceptar2
            // 
            this.btnAceptar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAceptar2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar2.Location = new System.Drawing.Point(334, 204);
            this.btnAceptar2.Name = "btnAceptar2";
            this.btnAceptar2.Size = new System.Drawing.Size(87, 28);
            this.btnAceptar2.TabIndex = 117;
            this.btnAceptar2.Text = "ACEPTAR";
            this.btnAceptar2.UseVisualStyleBackColor = true;
            this.btnAceptar2.Click += new System.EventHandler(this.btnAceptar2_Click);
            // 
            // btnNuevo2
            // 
            this.btnNuevo2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo2.Location = new System.Drawing.Point(320, 67);
            this.btnNuevo2.Name = "btnNuevo2";
            this.btnNuevo2.Size = new System.Drawing.Size(87, 28);
            this.btnNuevo2.TabIndex = 117;
            this.btnNuevo2.Text = "NUEVO";
            this.btnNuevo2.UseVisualStyleBackColor = true;
            this.btnNuevo2.Click += new System.EventHandler(this.btnNuevo2_Click);
            // 
            // btnBuscar2
            // 
            this.btnBuscar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar2.Location = new System.Drawing.Point(221, 67);
            this.btnBuscar2.Name = "btnBuscar2";
            this.btnBuscar2.Size = new System.Drawing.Size(92, 28);
            this.btnBuscar2.TabIndex = 131;
            this.btnBuscar2.Text = "BUSCAR";
            this.btnBuscar2.UseVisualStyleBackColor = true;
            this.btnBuscar2.Click += new System.EventHandler(this.btnBuscar2_Click);
            // 
            // btnCancelar2
            // 
            this.btnCancelar2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar2.Location = new System.Drawing.Point(427, 204);
            this.btnCancelar2.Name = "btnCancelar2";
            this.btnCancelar2.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar2.TabIndex = 118;
            this.btnCancelar2.Text = "CANCELAR";
            this.btnCancelar2.UseVisualStyleBackColor = true;
            this.btnCancelar2.Click += new System.EventHandler(this.btnCancelar2_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnRegistros);
            this.panel2.Controls.Add(this.txtFolioOrden);
            this.panel2.Controls.Add(this.txtRecibe);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.Numero);
            this.panel2.Controls.Add(this.btnEliminar);
            this.panel2.Controls.Add(this.txtEntrega);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnActualizar);
            this.panel2.Controls.Add(this.btnNuevo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.boxDepartamento);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.boxProveedor);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnBuscar);
            this.panel2.Controls.Add(this.txtOrden);
            this.panel2.Location = new System.Drawing.Point(8, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(628, 275);
            this.panel2.TabIndex = 130;
            // 
            // btnRegistros
            // 
            this.btnRegistros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistros.Location = new System.Drawing.Point(444, 38);
            this.btnRegistros.Name = "btnRegistros";
            this.btnRegistros.Size = new System.Drawing.Size(108, 24);
            this.btnRegistros.TabIndex = 117;
            this.btnRegistros.Text = "VER REGISTROS";
            this.btnRegistros.UseVisualStyleBackColor = true;
            this.btnRegistros.Click += new System.EventHandler(this.btnRegistros_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(224, 225);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(87, 28);
            this.btnEliminar.TabIndex = 116;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Location = new System.Drawing.Point(111, 225);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(107, 28);
            this.btnActualizar.TabIndex = 115;
            this.btnActualizar.Text = "ACTUALIZAR";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(8, 641);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.Size = new System.Drawing.Size(628, 101);
            this.dgvDetalles.TabIndex = 131;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 613);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(183, 21);
            this.label14.TabIndex = 133;
            this.label14.Text = "REGISTROS DE ORDEN:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(184, 613);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 21);
            this.label15.TabIndex = 134;
            // 
            // Compras
            // 
            this.AcceptButton = this.btnRegistros;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 753);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBarra);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Compras";
            this.Text = "DETALLES DE LA ORDEN";
            this.Load += new System.EventHandler(this.Compras_Load);
            this.panelBarra.ResumeLayout(false);
            this.panelBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSalir)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelBarra;
        private Label label1;
        private PictureBox buttonSalir;
        private TextBox txtOrden;
        private Label Numero;
        private Label label4;
        private TextBox txtFolioOrden;
        private Button btnBuscar;
        private DateTimePicker dateTimePicker1;
        private Label label22;
        private ComboBox boxProveedor;
        private Label label5;
        private ComboBox boxDepartamento;
        private Label label2;
        private TextBox txtEntrega;
        private TextBox txtRecibe;
        private Label label3;
        private Label label6;
        private Button btnNuevo;
        private Button btnAceptar;
        private Button btnCancelar;
        private Button btnImprimir;
        private Label label7;
        private Label label8;
        private TextBox txtFolioDetalle;
        private Label label16;
        private TextBox txtDescripcion;
        private Label label9;
        private TextBox txtCantidad;
        private TextBox txtMedida;
        private Label label10;
        private TextBox txtPrecio;
        private Label label11;
        private TextBox txtTotal;
        private Label label12;
        private Panel panel1;
        private Panel panel2;
        private Button btnEliminar;
        private Button btnActualizar;
        private Button btnBuscar2;
        private Button btnEliminar2;
        private Button btnActualizar2;
        private Button btnAceptar2;
        private Button btnNuevo2;
        private Button btnCancelar2;
        private ComboBox boxCompra;
        private Label label13;
        private DataGridView dgvDetalles;
        private Label label14;
        private Label label15;
        private Button btnRegistros;
    }
}