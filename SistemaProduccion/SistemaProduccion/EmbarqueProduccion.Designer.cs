namespace SistemaProduccion
{
    partial class EmbarqueProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmbarqueProduccion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.embarquealmacenlb = new System.Windows.Forms.Label();
            this.btnverembarques = new System.Windows.Forms.Button();
            this.btnfinalizar = new System.Windows.Forms.Button();
            this.btnsalir = new System.Windows.Forms.Button();
            this.btnremision = new System.Windows.Forms.Button();
            this.TbxDestino = new System.Windows.Forms.TextBox();
            this.LbDestino = new System.Windows.Forms.Label();
            this.TxbTrannsportista = new System.Windows.Forms.TextBox();
            this.LBTransportista = new System.Windows.Forms.Label();
            this.lotedelclientetbx = new System.Windows.Forms.TextBox();
            this.lotedelclientelb = new System.Windows.Forms.Label();
            this.buscarrollolb = new System.Windows.Forms.Label();
            this.lotejagregresotbx = new System.Windows.Forms.TextBox();
            this.lotejagtbx = new System.Windows.Forms.TextBox();
            this.numremisiontbx = new System.Windows.Forms.TextBox();
            this.embarquelb = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.regresarrollobtn = new System.Windows.Forms.Button();
            this.regresarrollolb = new System.Windows.Forms.Label();
            this.cargarrollobtn = new System.Windows.Forms.Button();
            this.cargarrollolb = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.fechaembarquelb = new System.Windows.Forms.Label();
            this.remisionlb = new System.Windows.Forms.Label();
            this.origentbx = new System.Windows.Forms.TextBox();
            this.origenlb = new System.Windows.Forms.Label();
            this.clientelb = new System.Windows.Forms.Label();
            this.cbxcliente = new System.Windows.Forms.ComboBox();
            this.inventariolb = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbxtarimainven = new System.Windows.Forms.TextBox();
            this.tbxtarimaembar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxlineatrans = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxnoeconom = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Chocolate;
            this.groupBox1.Controls.Add(this.embarquealmacenlb);
            this.groupBox1.Location = new System.Drawing.Point(-3, -10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1603, 100);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // embarquealmacenlb
            // 
            this.embarquealmacenlb.AutoSize = true;
            this.embarquealmacenlb.Font = new System.Drawing.Font("Arial Unicode MS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.embarquealmacenlb.Location = new System.Drawing.Point(490, 28);
            this.embarquealmacenlb.Name = "embarquealmacenlb";
            this.embarquealmacenlb.Size = new System.Drawing.Size(393, 50);
            this.embarquealmacenlb.TabIndex = 2;
            this.embarquealmacenlb.Text = "Embarque Producción";
            // 
            // btnverembarques
            // 
            this.btnverembarques.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnverembarques.Location = new System.Drawing.Point(678, 659);
            this.btnverembarques.Name = "btnverembarques";
            this.btnverembarques.Size = new System.Drawing.Size(262, 55);
            this.btnverembarques.TabIndex = 51;
            this.btnverembarques.Text = "Ver Embarques";
            this.btnverembarques.UseVisualStyleBackColor = true;
            this.btnverembarques.Click += new System.EventHandler(this.btnverembarques_Click);
            // 
            // btnfinalizar
            // 
            this.btnfinalizar.Font = new System.Drawing.Font("Arial Unicode MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfinalizar.Location = new System.Drawing.Point(390, 659);
            this.btnfinalizar.Name = "btnfinalizar";
            this.btnfinalizar.Size = new System.Drawing.Size(262, 55);
            this.btnfinalizar.TabIndex = 50;
            this.btnfinalizar.Text = "Finalizar Embarque";
            this.btnfinalizar.UseVisualStyleBackColor = true;
            this.btnfinalizar.Click += new System.EventHandler(this.btnfinalizar_Click);
            // 
            // btnsalir
            // 
            this.btnsalir.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.Location = new System.Drawing.Point(95, 659);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(262, 55);
            this.btnsalir.TabIndex = 48;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click);
            // 
            // btnremision
            // 
            this.btnremision.Font = new System.Drawing.Font("Arial Unicode MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnremision.Location = new System.Drawing.Point(989, 660);
            this.btnremision.Name = "btnremision";
            this.btnremision.Size = new System.Drawing.Size(262, 55);
            this.btnremision.TabIndex = 49;
            this.btnremision.Text = "Generar Remision";
            this.btnremision.UseVisualStyleBackColor = true;
            this.btnremision.Click += new System.EventHandler(this.btnremision_Click);
            // 
            // TbxDestino
            // 
            this.TbxDestino.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxDestino.Location = new System.Drawing.Point(486, 299);
            this.TbxDestino.MaxLength = 15;
            this.TbxDestino.Name = "TbxDestino";
            this.TbxDestino.Size = new System.Drawing.Size(138, 36);
            this.TbxDestino.TabIndex = 81;
            // 
            // LbDestino
            // 
            this.LbDestino.AutoSize = true;
            this.LbDestino.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbDestino.Location = new System.Drawing.Point(397, 302);
            this.LbDestino.Name = "LbDestino";
            this.LbDestino.Size = new System.Drawing.Size(90, 28);
            this.LbDestino.TabIndex = 80;
            this.LbDestino.Text = "Destino:";
            // 
            // TxbTrannsportista
            // 
            this.TxbTrannsportista.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxbTrannsportista.Location = new System.Drawing.Point(485, 363);
            this.TxbTrannsportista.MaxLength = 30;
            this.TxbTrannsportista.Name = "TxbTrannsportista";
            this.TxbTrannsportista.Size = new System.Drawing.Size(185, 36);
            this.TxbTrannsportista.TabIndex = 79;
            // 
            // LBTransportista
            // 
            this.LBTransportista.AutoSize = true;
            this.LBTransportista.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBTransportista.Location = new System.Drawing.Point(634, 307);
            this.LBTransportista.Name = "LBTransportista";
            this.LBTransportista.Size = new System.Drawing.Size(143, 28);
            this.LBTransportista.TabIndex = 78;
            this.LBTransportista.Text = "Transportista:";
            // 
            // lotedelclientetbx
            // 
            this.lotedelclientetbx.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lotedelclientetbx.Location = new System.Drawing.Point(238, 196);
            this.lotedelclientetbx.MaxLength = 15;
            this.lotedelclientetbx.Name = "lotedelclientetbx";
            this.lotedelclientetbx.Size = new System.Drawing.Size(145, 36);
            this.lotedelclientetbx.TabIndex = 77;
            this.lotedelclientetbx.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lotedelclientetbx_KeyUp);
            // 
            // lotedelclientelb
            // 
            this.lotedelclientelb.AutoSize = true;
            this.lotedelclientelb.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lotedelclientelb.Location = new System.Drawing.Point(12, 201);
            this.lotedelclientelb.Name = "lotedelclientelb";
            this.lotedelclientelb.Size = new System.Drawing.Size(224, 25);
            this.lotedelclientelb.TabIndex = 76;
            this.lotedelclientelb.Text = "Lote interno o del cliente:";
            // 
            // buscarrollolb
            // 
            this.buscarrollolb.AutoSize = true;
            this.buscarrollolb.Font = new System.Drawing.Font("Arial Unicode MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarrollolb.Location = new System.Drawing.Point(112, 144);
            this.buscarrollolb.Name = "buscarrollolb";
            this.buscarrollolb.Size = new System.Drawing.Size(173, 36);
            this.buscarrollolb.TabIndex = 75;
            this.buscarrollolb.Text = "Buscar rollos";
            // 
            // lotejagregresotbx
            // 
            this.lotejagregresotbx.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lotejagregresotbx.Location = new System.Drawing.Point(688, 612);
            this.lotejagregresotbx.MaxLength = 15;
            this.lotejagregresotbx.Name = "lotejagregresotbx";
            this.lotejagregresotbx.Size = new System.Drawing.Size(37, 29);
            this.lotejagregresotbx.TabIndex = 74;
            this.lotejagregresotbx.Visible = false;
            // 
            // lotejagtbx
            // 
            this.lotejagtbx.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lotejagtbx.Location = new System.Drawing.Point(644, 612);
            this.lotejagtbx.MaxLength = 15;
            this.lotejagtbx.Name = "lotejagtbx";
            this.lotejagtbx.Size = new System.Drawing.Size(37, 29);
            this.lotejagtbx.TabIndex = 73;
            this.lotejagtbx.Visible = false;
            // 
            // numremisiontbx
            // 
            this.numremisiontbx.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numremisiontbx.Location = new System.Drawing.Point(726, 162);
            this.numremisiontbx.MaxLength = 10;
            this.numremisiontbx.Name = "numremisiontbx";
            this.numremisiontbx.Size = new System.Drawing.Size(145, 36);
            this.numremisiontbx.TabIndex = 72;
            this.numremisiontbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numremisiontbx_KeyPress);
            // 
            // embarquelb
            // 
            this.embarquelb.AutoSize = true;
            this.embarquelb.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.embarquelb.Location = new System.Drawing.Point(1079, 94);
            this.embarquelb.Name = "embarquelb";
            this.embarquelb.Size = new System.Drawing.Size(150, 39);
            this.embarquelb.TabIndex = 71;
            this.embarquelb.Text = "Embarque";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(967, 144);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(371, 497);
            this.dataGridView2.TabIndex = 70;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // regresarrollobtn
            // 
            this.regresarrollobtn.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regresarrollobtn.Location = new System.Drawing.Point(639, 546);
            this.regresarrollobtn.Name = "regresarrollobtn";
            this.regresarrollobtn.Size = new System.Drawing.Size(86, 51);
            this.regresarrollobtn.TabIndex = 69;
            this.regresarrollobtn.Text = "<";
            this.regresarrollobtn.UseVisualStyleBackColor = true;
            this.regresarrollobtn.Click += new System.EventHandler(this.regresarrollobtn_Click);
            // 
            // regresarrollolb
            // 
            this.regresarrollolb.AutoSize = true;
            this.regresarrollolb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regresarrollolb.Location = new System.Drawing.Point(543, 515);
            this.regresarrollolb.Name = "regresarrollolb";
            this.regresarrollolb.Size = new System.Drawing.Size(275, 28);
            this.regresarrollolb.TabIndex = 68;
            this.regresarrollolb.Text = "Regresar Rollo al Inventario";
            // 
            // cargarrollobtn
            // 
            this.cargarrollobtn.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargarrollobtn.Location = new System.Drawing.Point(639, 456);
            this.cargarrollobtn.Name = "cargarrollobtn";
            this.cargarrollobtn.Size = new System.Drawing.Size(86, 51);
            this.cargarrollobtn.TabIndex = 67;
            this.cargarrollobtn.Text = ">";
            this.cargarrollobtn.UseVisualStyleBackColor = true;
            this.cargarrollobtn.Click += new System.EventHandler(this.cargarrollobtn_Click);
            // 
            // cargarrollolb
            // 
            this.cargarrollolb.AutoSize = true;
            this.cargarrollolb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargarrollolb.Location = new System.Drawing.Point(549, 427);
            this.cargarrollolb.Name = "cargarrollolb";
            this.cargarrollolb.Size = new System.Drawing.Size(257, 28);
            this.cargarrollolb.TabIndex = 66;
            this.cargarrollolb.Text = "Cargar Rollo al Embarque";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(678, 226);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(204, 36);
            this.dateTimePicker1.TabIndex = 65;
            // 
            // fechaembarquelb
            // 
            this.fechaembarquelb.AutoSize = true;
            this.fechaembarquelb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaembarquelb.Location = new System.Drawing.Point(463, 232);
            this.fechaembarquelb.Name = "fechaembarquelb";
            this.fechaembarquelb.Size = new System.Drawing.Size(211, 28);
            this.fechaembarquelb.TabIndex = 64;
            this.fechaembarquelb.Text = "Fecha de embarque:";
            // 
            // remisionlb
            // 
            this.remisionlb.AutoSize = true;
            this.remisionlb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remisionlb.Location = new System.Drawing.Point(488, 165);
            this.remisionlb.Name = "remisionlb";
            this.remisionlb.Size = new System.Drawing.Size(232, 28);
            this.remisionlb.TabIndex = 63;
            this.remisionlb.Text = "Num. Remision: JAG-R";
            // 
            // origentbx
            // 
            this.origentbx.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origentbx.Location = new System.Drawing.Point(766, 100);
            this.origentbx.MaxLength = 20;
            this.origentbx.Name = "origentbx";
            this.origentbx.ReadOnly = true;
            this.origentbx.Size = new System.Drawing.Size(164, 36);
            this.origentbx.TabIndex = 61;
            this.origentbx.Text = "Jaguar Irapuato";
            // 
            // origenlb
            // 
            this.origenlb.AutoSize = true;
            this.origenlb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origenlb.Location = new System.Drawing.Point(679, 103);
            this.origenlb.Name = "origenlb";
            this.origenlb.Size = new System.Drawing.Size(81, 28);
            this.origenlb.TabIndex = 62;
            this.origenlb.Text = "Origen:";
            // 
            // clientelb
            // 
            this.clientelb.AutoSize = true;
            this.clientelb.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientelb.Location = new System.Drawing.Point(397, 103);
            this.clientelb.Name = "clientelb";
            this.clientelb.Size = new System.Drawing.Size(83, 28);
            this.clientelb.TabIndex = 60;
            this.clientelb.Text = "Cliente:";
            // 
            // cbxcliente
            // 
            this.cbxcliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxcliente.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxcliente.FormattingEnabled = true;
            this.cbxcliente.Location = new System.Drawing.Point(486, 100);
            this.cbxcliente.Name = "cbxcliente";
            this.cbxcliente.Size = new System.Drawing.Size(185, 36);
            this.cbxcliente.TabIndex = 59;
            this.cbxcliente.SelectedIndexChanged += new System.EventHandler(this.cbxcliente_SelectedIndexChanged);
            // 
            // inventariolb
            // 
            this.inventariolb.AutoSize = true;
            this.inventariolb.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventariolb.Location = new System.Drawing.Point(131, 94);
            this.inventariolb.Name = "inventariolb";
            this.inventariolb.Size = new System.Drawing.Size(144, 39);
            this.inventariolb.TabIndex = 58;
            this.inventariolb.Text = "Inventario";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 253);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(371, 388);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // tbxtarimainven
            // 
            this.tbxtarimainven.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxtarimainven.Location = new System.Drawing.Point(601, 612);
            this.tbxtarimainven.MaxLength = 15;
            this.tbxtarimainven.Name = "tbxtarimainven";
            this.tbxtarimainven.Size = new System.Drawing.Size(37, 29);
            this.tbxtarimainven.TabIndex = 82;
            this.tbxtarimainven.Visible = false;
            // 
            // tbxtarimaembar
            // 
            this.tbxtarimaembar.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxtarimaembar.Location = new System.Drawing.Point(731, 612);
            this.tbxtarimaembar.MaxLength = 15;
            this.tbxtarimaembar.Name = "tbxtarimaembar";
            this.tbxtarimaembar.Size = new System.Drawing.Size(37, 29);
            this.tbxtarimaembar.TabIndex = 83;
            this.tbxtarimaembar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 28);
            this.label1.TabIndex = 84;
            this.label1.Text = "Chofer:";
            // 
            // tbxlineatrans
            // 
            this.tbxlineatrans.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxlineatrans.Location = new System.Drawing.Point(783, 304);
            this.tbxlineatrans.MaxLength = 15;
            this.tbxlineatrans.Name = "tbxlineatrans";
            this.tbxlineatrans.Size = new System.Drawing.Size(171, 36);
            this.tbxlineatrans.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(679, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 28);
            this.label2.TabIndex = 86;
            this.label2.Text = "No. Econom:";
            // 
            // tbxnoeconom
            // 
            this.tbxnoeconom.Font = new System.Drawing.Font("Arial Unicode MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxnoeconom.Location = new System.Drawing.Point(821, 363);
            this.tbxnoeconom.MaxLength = 10;
            this.tbxnoeconom.Name = "tbxnoeconom";
            this.tbxnoeconom.Size = new System.Drawing.Size(128, 36);
            this.tbxnoeconom.TabIndex = 87;
            // 
            // EmbarqueProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.tbxnoeconom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxlineatrans);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxtarimaembar);
            this.Controls.Add(this.tbxtarimainven);
            this.Controls.Add(this.TbxDestino);
            this.Controls.Add(this.LbDestino);
            this.Controls.Add(this.TxbTrannsportista);
            this.Controls.Add(this.LBTransportista);
            this.Controls.Add(this.lotedelclientetbx);
            this.Controls.Add(this.lotedelclientelb);
            this.Controls.Add(this.buscarrollolb);
            this.Controls.Add(this.lotejagregresotbx);
            this.Controls.Add(this.lotejagtbx);
            this.Controls.Add(this.numremisiontbx);
            this.Controls.Add(this.embarquelb);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.regresarrollobtn);
            this.Controls.Add(this.regresarrollolb);
            this.Controls.Add(this.cargarrollobtn);
            this.Controls.Add(this.cargarrollolb);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.fechaembarquelb);
            this.Controls.Add(this.remisionlb);
            this.Controls.Add(this.origentbx);
            this.Controls.Add(this.origenlb);
            this.Controls.Add(this.clientelb);
            this.Controls.Add(this.cbxcliente);
            this.Controls.Add(this.inventariolb);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnverembarques);
            this.Controls.Add(this.btnfinalizar);
            this.Controls.Add(this.btnremision);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "EmbarqueProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Embarque Produccion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label embarquealmacenlb;
        private System.Windows.Forms.Button btnverembarques;
        private System.Windows.Forms.Button btnfinalizar;
        private System.Windows.Forms.Button btnsalir;
        private System.Windows.Forms.Button btnremision;
        private System.Windows.Forms.TextBox TbxDestino;
        private System.Windows.Forms.Label LbDestino;
        private System.Windows.Forms.TextBox TxbTrannsportista;
        private System.Windows.Forms.Label LBTransportista;
        private System.Windows.Forms.TextBox lotedelclientetbx;
        private System.Windows.Forms.Label lotedelclientelb;
        private System.Windows.Forms.Label buscarrollolb;
        private System.Windows.Forms.TextBox lotejagregresotbx;
        private System.Windows.Forms.TextBox lotejagtbx;
        private System.Windows.Forms.TextBox numremisiontbx;
        private System.Windows.Forms.Label embarquelb;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button regresarrollobtn;
        private System.Windows.Forms.Label regresarrollolb;
        private System.Windows.Forms.Button cargarrollobtn;
        private System.Windows.Forms.Label cargarrollolb;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label fechaembarquelb;
        private System.Windows.Forms.Label remisionlb;
        private System.Windows.Forms.TextBox origentbx;
        private System.Windows.Forms.Label origenlb;
        private System.Windows.Forms.Label clientelb;
        private System.Windows.Forms.ComboBox cbxcliente;
        private System.Windows.Forms.Label inventariolb;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbxtarimainven;
        private System.Windows.Forms.TextBox tbxtarimaembar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxlineatrans;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxnoeconom;
    }
}