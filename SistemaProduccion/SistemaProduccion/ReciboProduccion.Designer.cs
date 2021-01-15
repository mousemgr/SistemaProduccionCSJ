namespace SistemaProduccion
{
    partial class ReciboProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReciboProduccion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reciboalmacenlb = new System.Windows.Forms.Label();
            this.presentacionlb = new System.Windows.Forms.Label();
            this.cbxcliente = new System.Windows.Forms.ComboBox();
            this.clientelb = new System.Windows.Forms.Label();
            this.bntverrecibo = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btncargar = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.fecharecibolb = new System.Windows.Forms.Label();
            this.lbespecificacion = new System.Windows.Forms.Label();
            this.tbxespecificacion = new System.Windows.Forms.TextBox();
            this.tbxancho = new System.Windows.Forms.TextBox();
            this.ancholb = new System.Windows.Forms.Label();
            this.tbxespesor = new System.Windows.Forms.TextBox();
            this.espesorlb = new System.Windows.Forms.Label();
            this.tbxpiezas = new System.Windows.Forms.TextBox();
            this.piezaslb = new System.Windows.Forms.Label();
            this.lbnumparte = new System.Windows.Forms.Label();
            this.loteclientelb = new System.Windows.Forms.Label();
            this.loteinternolb = new System.Windows.Forms.Label();
            this.tbxlotecliente = new System.Windows.Forms.TextBox();
            this.tbxnumrollo = new System.Windows.Forms.TextBox();
            this.tbxloteinterno = new System.Windows.Forms.TextBox();
            this.lbnumrollo = new System.Windows.Forms.Label();
            this.cbxnumparte = new System.Windows.Forms.ComboBox();
            this.tbxkgs = new System.Windows.Forms.TextBox();
            this.lbkg = new System.Windows.Forms.Label();
            this.tbxmaterial = new System.Windows.Forms.TextBox();
            this.lbmaterial = new System.Windows.Forms.Label();
            this.cbxpresentacion = new System.Windows.Forms.ComboBox();
            this.tbxlargo = new System.Windows.Forms.TextBox();
            this.lblargo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Chocolate;
            this.groupBox1.Controls.Add(this.reciboalmacenlb);
            this.groupBox1.Location = new System.Drawing.Point(-5, -7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1265, 99);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // reciboalmacenlb
            // 
            this.reciboalmacenlb.AutoSize = true;
            this.reciboalmacenlb.Font = new System.Drawing.Font("Arial Unicode MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reciboalmacenlb.Location = new System.Drawing.Point(461, 26);
            this.reciboalmacenlb.Name = "reciboalmacenlb";
            this.reciboalmacenlb.Size = new System.Drawing.Size(337, 50);
            this.reciboalmacenlb.TabIndex = 1;
            this.reciboalmacenlb.Text = "Recibo Producción";
            // 
            // presentacionlb
            // 
            this.presentacionlb.AutoSize = true;
            this.presentacionlb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presentacionlb.Location = new System.Drawing.Point(12, 204);
            this.presentacionlb.Name = "presentacionlb";
            this.presentacionlb.Size = new System.Drawing.Size(143, 28);
            this.presentacionlb.TabIndex = 70;
            this.presentacionlb.Text = "Presentacion:";
            // 
            // cbxcliente
            // 
            this.cbxcliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxcliente.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxcliente.FormattingEnabled = true;
            this.cbxcliente.Location = new System.Drawing.Point(101, 129);
            this.cbxcliente.Name = "cbxcliente";
            this.cbxcliente.Size = new System.Drawing.Size(179, 33);
            this.cbxcliente.TabIndex = 55;
            this.cbxcliente.SelectedIndexChanged += new System.EventHandler(this.cbxcliente_SelectedIndexChanged);
            // 
            // clientelb
            // 
            this.clientelb.AutoSize = true;
            this.clientelb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientelb.Location = new System.Drawing.Point(12, 130);
            this.clientelb.Name = "clientelb";
            this.clientelb.Size = new System.Drawing.Size(83, 28);
            this.clientelb.TabIndex = 67;
            this.clientelb.Text = "Cliente:";
            // 
            // bntverrecibo
            // 
            this.bntverrecibo.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntverrecibo.Location = new System.Drawing.Point(497, 448);
            this.bntverrecibo.Name = "bntverrecibo";
            this.bntverrecibo.Size = new System.Drawing.Size(262, 55);
            this.bntverrecibo.TabIndex = 58;
            this.bntverrecibo.Text = "Ver recibo";
            this.bntverrecibo.UseVisualStyleBackColor = true;
            this.bntverrecibo.Click += new System.EventHandler(this.bntverrecibo_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.Location = new System.Drawing.Point(212, 448);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(262, 55);
            this.btnsalir.TabIndex = 59;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.cancelarbtn_Click);
            // 
            // btncargar
            // 
            this.btncargar.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncargar.Location = new System.Drawing.Point(781, 448);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(262, 55);
            this.btncargar.TabIndex = 4;
            this.btncargar.Text = "Cargar";
            this.btncargar.UseVisualStyleBackColor = true;
            this.btncargar.Click += new System.EventHandler(this.btncargar_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(712, 361);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(187, 36);
            this.dateTimePicker1.TabIndex = 65;
            // 
            // fecharecibolb
            // 
            this.fecharecibolb.AutoSize = true;
            this.fecharecibolb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecharecibolb.Location = new System.Drawing.Point(534, 367);
            this.fecharecibolb.Name = "fecharecibolb";
            this.fecharecibolb.Size = new System.Drawing.Size(172, 28);
            this.fecharecibolb.TabIndex = 64;
            this.fecharecibolb.Text = "Fecha de recibo:";
            // 
            // lbespecificacion
            // 
            this.lbespecificacion.AutoSize = true;
            this.lbespecificacion.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbespecificacion.Location = new System.Drawing.Point(354, 204);
            this.lbespecificacion.Name = "lbespecificacion";
            this.lbespecificacion.Size = new System.Drawing.Size(154, 28);
            this.lbespecificacion.TabIndex = 63;
            this.lbespecificacion.Text = "Especificacion:";
            // 
            // tbxespecificacion
            // 
            this.tbxespecificacion.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxespecificacion.Location = new System.Drawing.Point(513, 201);
            this.tbxespecificacion.MaxLength = 30;
            this.tbxespecificacion.Name = "tbxespecificacion";
            this.tbxespecificacion.Size = new System.Drawing.Size(301, 36);
            this.tbxespecificacion.TabIndex = 2;
            // 
            // tbxancho
            // 
            this.tbxancho.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxancho.Location = new System.Drawing.Point(1058, 283);
            this.tbxancho.MaxLength = 7;
            this.tbxancho.Name = "tbxancho";
            this.tbxancho.ReadOnly = true;
            this.tbxancho.Size = new System.Drawing.Size(111, 36);
            this.tbxancho.TabIndex = 49;
            // 
            // ancholb
            // 
            this.ancholb.AutoSize = true;
            this.ancholb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ancholb.Location = new System.Drawing.Point(973, 286);
            this.ancholb.Name = "ancholb";
            this.ancholb.Size = new System.Drawing.Size(79, 28);
            this.ancholb.TabIndex = 62;
            this.ancholb.Text = "Ancho:";
            // 
            // tbxespesor
            // 
            this.tbxespesor.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxespesor.Location = new System.Drawing.Point(849, 283);
            this.tbxespesor.MaxLength = 7;
            this.tbxespesor.Name = "tbxespesor";
            this.tbxespesor.ReadOnly = true;
            this.tbxespesor.Size = new System.Drawing.Size(111, 36);
            this.tbxespesor.TabIndex = 48;
            // 
            // espesorlb
            // 
            this.espesorlb.AutoSize = true;
            this.espesorlb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.espesorlb.Location = new System.Drawing.Point(746, 286);
            this.espesorlb.Name = "espesorlb";
            this.espesorlb.Size = new System.Drawing.Size(97, 28);
            this.espesorlb.TabIndex = 60;
            this.espesorlb.Text = "Espesor:";
            // 
            // tbxpiezas
            // 
            this.tbxpiezas.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxpiezas.Location = new System.Drawing.Point(1126, 201);
            this.tbxpiezas.MaxLength = 7;
            this.tbxpiezas.Name = "tbxpiezas";
            this.tbxpiezas.ReadOnly = true;
            this.tbxpiezas.Size = new System.Drawing.Size(85, 36);
            this.tbxpiezas.TabIndex = 46;
            // 
            // piezaslb
            // 
            this.piezaslb.AutoSize = true;
            this.piezaslb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piezaslb.Location = new System.Drawing.Point(1066, 204);
            this.piezaslb.Name = "piezaslb";
            this.piezaslb.Size = new System.Drawing.Size(54, 28);
            this.piezaslb.TabIndex = 57;
            this.piezaslb.Text = "Pzs:";
            // 
            // lbnumparte
            // 
            this.lbnumparte.AutoSize = true;
            this.lbnumparte.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnumparte.Location = new System.Drawing.Point(52, 286);
            this.lbnumparte.Name = "lbnumparte";
            this.lbnumparte.Size = new System.Drawing.Size(154, 28);
            this.lbnumparte.TabIndex = 50;
            this.lbnumparte.Text = "Num. de parte:";
            // 
            // loteclientelb
            // 
            this.loteclientelb.AutoSize = true;
            this.loteclientelb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loteclientelb.Location = new System.Drawing.Point(939, 130);
            this.loteclientelb.Name = "loteclientelb";
            this.loteclientelb.Size = new System.Drawing.Size(127, 28);
            this.loteclientelb.TabIndex = 44;
            this.loteclientelb.Text = "Lote cliente:";
            // 
            // loteinternolb
            // 
            this.loteinternolb.AutoSize = true;
            this.loteinternolb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loteinternolb.Location = new System.Drawing.Point(286, 130);
            this.loteinternolb.Name = "loteinternolb";
            this.loteinternolb.Size = new System.Drawing.Size(131, 28);
            this.loteinternolb.TabIndex = 42;
            this.loteinternolb.Text = "Lote interno:";
            // 
            // tbxlotecliente
            // 
            this.tbxlotecliente.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxlotecliente.Location = new System.Drawing.Point(1072, 127);
            this.tbxlotecliente.MaxLength = 20;
            this.tbxlotecliente.Name = "tbxlotecliente";
            this.tbxlotecliente.Size = new System.Drawing.Size(167, 36);
            this.tbxlotecliente.TabIndex = 1;
            // 
            // tbxnumrollo
            // 
            this.tbxnumrollo.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxnumrollo.Location = new System.Drawing.Point(730, 127);
            this.tbxnumrollo.MaxLength = 20;
            this.tbxnumrollo.Name = "tbxnumrollo";
            this.tbxnumrollo.Size = new System.Drawing.Size(200, 36);
            this.tbxnumrollo.TabIndex = 0;
            // 
            // tbxloteinterno
            // 
            this.tbxloteinterno.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxloteinterno.Location = new System.Drawing.Point(418, 127);
            this.tbxloteinterno.MaxLength = 20;
            this.tbxloteinterno.Name = "tbxloteinterno";
            this.tbxloteinterno.ReadOnly = true;
            this.tbxloteinterno.Size = new System.Drawing.Size(184, 36);
            this.tbxloteinterno.TabIndex = 61;
            // 
            // lbnumrollo
            // 
            this.lbnumrollo.AutoSize = true;
            this.lbnumrollo.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnumrollo.Location = new System.Drawing.Point(614, 130);
            this.lbnumrollo.Name = "lbnumrollo";
            this.lbnumrollo.Size = new System.Drawing.Size(114, 28);
            this.lbnumrollo.TabIndex = 74;
            this.lbnumrollo.Text = "Num. rollo:";
            // 
            // cbxnumparte
            // 
            this.cbxnumparte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxnumparte.DropDownWidth = 20;
            this.cbxnumparte.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxnumparte.FormattingEnabled = true;
            this.cbxnumparte.IntegralHeight = false;
            this.cbxnumparte.ItemHeight = 28;
            this.cbxnumparte.Location = new System.Drawing.Point(211, 283);
            this.cbxnumparte.Name = "cbxnumparte";
            this.cbxnumparte.Size = new System.Drawing.Size(273, 36);
            this.cbxnumparte.TabIndex = 75;
            this.cbxnumparte.SelectedIndexChanged += new System.EventHandler(this.cbxnumparte_SelectedIndexChanged);
            // 
            // tbxkgs
            // 
            this.tbxkgs.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxkgs.Location = new System.Drawing.Point(888, 201);
            this.tbxkgs.MaxLength = 9;
            this.tbxkgs.Name = "tbxkgs";
            this.tbxkgs.Size = new System.Drawing.Size(144, 36);
            this.tbxkgs.TabIndex = 3;
            this.tbxkgs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxkgs_KeyPress);
            // 
            // lbkg
            // 
            this.lbkg.AutoSize = true;
            this.lbkg.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbkg.Location = new System.Drawing.Point(830, 204);
            this.lbkg.Name = "lbkg";
            this.lbkg.Size = new System.Drawing.Size(55, 28);
            this.lbkg.TabIndex = 77;
            this.lbkg.Text = "Kgs:";
            // 
            // tbxmaterial
            // 
            this.tbxmaterial.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxmaterial.Location = new System.Drawing.Point(589, 283);
            this.tbxmaterial.MaxLength = 20;
            this.tbxmaterial.Name = "tbxmaterial";
            this.tbxmaterial.ReadOnly = true;
            this.tbxmaterial.Size = new System.Drawing.Size(151, 36);
            this.tbxmaterial.TabIndex = 78;
            // 
            // lbmaterial
            // 
            this.lbmaterial.AutoSize = true;
            this.lbmaterial.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmaterial.Location = new System.Drawing.Point(490, 286);
            this.lbmaterial.Name = "lbmaterial";
            this.lbmaterial.Size = new System.Drawing.Size(93, 28);
            this.lbmaterial.TabIndex = 79;
            this.lbmaterial.Text = "Material:";
            // 
            // cbxpresentacion
            // 
            this.cbxpresentacion.DisplayMember = "Rollo Master";
            this.cbxpresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxpresentacion.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxpresentacion.FormattingEnabled = true;
            this.cbxpresentacion.IntegralHeight = false;
            this.cbxpresentacion.Items.AddRange(new object[] {
            "Rollo Master",
            "Cinta",
            "Blanks"});
            this.cbxpresentacion.Location = new System.Drawing.Point(161, 201);
            this.cbxpresentacion.Name = "cbxpresentacion";
            this.cbxpresentacion.Size = new System.Drawing.Size(187, 36);
            this.cbxpresentacion.TabIndex = 81;
            this.cbxpresentacion.SelectedIndexChanged += new System.EventHandler(this.cbxpresentacion_SelectedIndexChanged);
            // 
            // tbxlargo
            // 
            this.tbxlargo.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxlargo.Location = new System.Drawing.Point(412, 364);
            this.tbxlargo.MaxLength = 7;
            this.tbxlargo.Name = "tbxlargo";
            this.tbxlargo.ReadOnly = true;
            this.tbxlargo.Size = new System.Drawing.Size(111, 36);
            this.tbxlargo.TabIndex = 82;
            // 
            // lblargo
            // 
            this.lblargo.AutoSize = true;
            this.lblargo.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblargo.Location = new System.Drawing.Point(333, 367);
            this.lblargo.Name = "lblargo";
            this.lblargo.Size = new System.Drawing.Size(73, 28);
            this.lblargo.TabIndex = 83;
            this.lblargo.Text = "Largo:";
            // 
            // ReciboProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1255, 532);
            this.Controls.Add(this.tbxlargo);
            this.Controls.Add(this.lblargo);
            this.Controls.Add(this.cbxpresentacion);
            this.Controls.Add(this.tbxmaterial);
            this.Controls.Add(this.lbmaterial);
            this.Controls.Add(this.tbxkgs);
            this.Controls.Add(this.lbkg);
            this.Controls.Add(this.cbxnumparte);
            this.Controls.Add(this.lbnumrollo);
            this.Controls.Add(this.presentacionlb);
            this.Controls.Add(this.cbxcliente);
            this.Controls.Add(this.clientelb);
            this.Controls.Add(this.bntverrecibo);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.btncargar);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.fecharecibolb);
            this.Controls.Add(this.lbespecificacion);
            this.Controls.Add(this.tbxespecificacion);
            this.Controls.Add(this.tbxancho);
            this.Controls.Add(this.ancholb);
            this.Controls.Add(this.tbxespesor);
            this.Controls.Add(this.espesorlb);
            this.Controls.Add(this.tbxpiezas);
            this.Controls.Add(this.piezaslb);
            this.Controls.Add(this.lbnumparte);
            this.Controls.Add(this.loteclientelb);
            this.Controls.Add(this.loteinternolb);
            this.Controls.Add(this.tbxlotecliente);
            this.Controls.Add(this.tbxnumrollo);
            this.Controls.Add(this.tbxloteinterno);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1271, 571);
            this.MinimumSize = new System.Drawing.Size(1271, 571);
            this.Name = "ReciboProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibo Produccion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label reciboalmacenlb;
        private System.Windows.Forms.Label presentacionlb;
        private System.Windows.Forms.ComboBox cbxcliente;
        private System.Windows.Forms.Label clientelb;
        private System.Windows.Forms.Button bntverrecibo;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btncargar;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label fecharecibolb;
        private System.Windows.Forms.Label lbespecificacion;
        private System.Windows.Forms.TextBox tbxespecificacion;
        private System.Windows.Forms.TextBox tbxancho;
        private System.Windows.Forms.Label ancholb;
        private System.Windows.Forms.TextBox tbxespesor;
        private System.Windows.Forms.Label espesorlb;
        private System.Windows.Forms.TextBox tbxpiezas;
        private System.Windows.Forms.Label piezaslb;
        private System.Windows.Forms.Label lbnumparte;
        private System.Windows.Forms.Label loteclientelb;
        private System.Windows.Forms.Label loteinternolb;
        private System.Windows.Forms.TextBox tbxlotecliente;
        private System.Windows.Forms.TextBox tbxnumrollo;
        private System.Windows.Forms.TextBox tbxloteinterno;
        private System.Windows.Forms.Label lbnumrollo;
        private System.Windows.Forms.ComboBox cbxnumparte;
        private System.Windows.Forms.TextBox tbxkgs;
        private System.Windows.Forms.Label lbkg;
        private System.Windows.Forms.TextBox tbxmaterial;
        private System.Windows.Forms.Label lbmaterial;
        private System.Windows.Forms.ComboBox cbxpresentacion;
        private System.Windows.Forms.TextBox tbxlargo;
        private System.Windows.Forms.Label lblargo;
    }
}