namespace SistemaProduccion
{
    partial class VerRecibo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerRecibo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbvernumparte = new System.Windows.Forms.Label();
            this.clientelb = new System.Windows.Forms.Label();
            this.cbxcliente = new System.Windows.Forms.ComboBox();
            this.salir = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnreporte = new System.Windows.Forms.Button();
            this.lbjag = new System.Windows.Forms.Label();
            this.tbxloteinterno = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Chocolate;
            this.groupBox1.Controls.Add(this.lbvernumparte);
            this.groupBox1.Location = new System.Drawing.Point(-5, -13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1623, 116);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lbvernumparte
            // 
            this.lbvernumparte.AutoSize = true;
            this.lbvernumparte.Font = new System.Drawing.Font("Arial Unicode MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbvernumparte.Location = new System.Drawing.Point(470, 32);
            this.lbvernumparte.Name = "lbvernumparte";
            this.lbvernumparte.Size = new System.Drawing.Size(498, 64);
            this.lbvernumparte.TabIndex = 0;
            this.lbvernumparte.Text = "Ver recibo producción";
            // 
            // clientelb
            // 
            this.clientelb.AutoSize = true;
            this.clientelb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientelb.Location = new System.Drawing.Point(36, 124);
            this.clientelb.Name = "clientelb";
            this.clientelb.Size = new System.Drawing.Size(62, 20);
            this.clientelb.TabIndex = 10;
            this.clientelb.Text = "Cliente:";
            // 
            // cbxcliente
            // 
            this.cbxcliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxcliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxcliente.FormattingEnabled = true;
            this.cbxcliente.Location = new System.Drawing.Point(104, 121);
            this.cbxcliente.Name = "cbxcliente";
            this.cbxcliente.Size = new System.Drawing.Size(234, 28);
            this.cbxcliente.TabIndex = 9;
            this.cbxcliente.SelectedIndexChanged += new System.EventHandler(this.cbxcliente_SelectedIndexChanged);
            // 
            // salir
            // 
            this.salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir.Location = new System.Drawing.Point(1147, 113);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(164, 42);
            this.salir.TabIndex = 8;
            this.salir.Text = "Salir";
            this.salir.UseVisualStyleBackColor = true;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 170);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReuseParameterValuesOnRefresh = true;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1326, 547);
            this.crystalReportViewer1.TabIndex = 11;
            // 
            // btnreporte
            // 
            this.btnreporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreporte.Location = new System.Drawing.Point(776, 113);
            this.btnreporte.Name = "btnreporte";
            this.btnreporte.Size = new System.Drawing.Size(154, 42);
            this.btnreporte.TabIndex = 12;
            this.btnreporte.Text = "Reporte Blanking";
            this.btnreporte.UseVisualStyleBackColor = true;
            this.btnreporte.Click += new System.EventHandler(this.btnreporte_Click);
            // 
            // lbjag
            // 
            this.lbjag.AutoSize = true;
            this.lbjag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbjag.Location = new System.Drawing.Point(380, 124);
            this.lbjag.Name = "lbjag";
            this.lbjag.Size = new System.Drawing.Size(100, 20);
            this.lbjag.TabIndex = 13;
            this.lbjag.Text = "Lote Interno:";
            // 
            // tbxloteinterno
            // 
            this.tbxloteinterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxloteinterno.Location = new System.Drawing.Point(495, 121);
            this.tbxloteinterno.MaxLength = 20;
            this.tbxloteinterno.Name = "tbxloteinterno";
            this.tbxloteinterno.Size = new System.Drawing.Size(252, 26);
            this.tbxloteinterno.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(964, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 42);
            this.button1.TabIndex = 15;
            this.button1.Text = "Reporte Slitter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VerRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxloteinterno);
            this.Controls.Add(this.lbjag);
            this.Controls.Add(this.btnreporte);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.clientelb);
            this.Controls.Add(this.cbxcliente);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "VerRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver Recibo Produccion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbvernumparte;
        private System.Windows.Forms.Label clientelb;
        private System.Windows.Forms.ComboBox cbxcliente;
        private System.Windows.Forms.Button salir;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnreporte;
        private System.Windows.Forms.Label lbjag;
        private System.Windows.Forms.TextBox tbxloteinterno;
        private System.Windows.Forms.Button button1;
    }
}