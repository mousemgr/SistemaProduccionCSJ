namespace SistemaProduccion
{
    partial class InventarioProduccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventarioProduccion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inventariolb = new System.Windows.Forms.Label();
            this.tbxsumapeso = new System.Windows.Forms.TextBox();
            this.totalpesolb = new System.Windows.Forms.Label();
            this.clientelb = new System.Windows.Forms.Label();
            this.cbxcliente = new System.Windows.Forms.ComboBox();
            this.btnsalir = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Chocolate;
            this.groupBox1.Controls.Add(this.inventariolb);
            this.groupBox1.Location = new System.Drawing.Point(-6, -9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1623, 101);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // inventariolb
            // 
            this.inventariolb.AutoSize = true;
            this.inventariolb.Font = new System.Drawing.Font("Arial Unicode MS", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventariolb.Location = new System.Drawing.Point(468, 18);
            this.inventariolb.Name = "inventariolb";
            this.inventariolb.Size = new System.Drawing.Size(495, 64);
            this.inventariolb.TabIndex = 0;
            this.inventariolb.Text = "Inventario Producción";
            // 
            // tbxsumapeso
            // 
            this.tbxsumapeso.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxsumapeso.Location = new System.Drawing.Point(823, 106);
            this.tbxsumapeso.MaxLength = 15;
            this.tbxsumapeso.Name = "tbxsumapeso";
            this.tbxsumapeso.ReadOnly = true;
            this.tbxsumapeso.Size = new System.Drawing.Size(160, 46);
            this.tbxsumapeso.TabIndex = 41;
            // 
            // totalpesolb
            // 
            this.totalpesolb.AutoSize = true;
            this.totalpesolb.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalpesolb.Location = new System.Drawing.Point(594, 109);
            this.totalpesolb.Name = "totalpesolb";
            this.totalpesolb.Size = new System.Drawing.Size(232, 39);
            this.totalpesolb.TabIndex = 40;
            this.totalpesolb.Text = "Total Peso Neto:";
            // 
            // clientelb
            // 
            this.clientelb.AutoSize = true;
            this.clientelb.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientelb.Location = new System.Drawing.Point(215, 109);
            this.clientelb.Name = "clientelb";
            this.clientelb.Size = new System.Drawing.Size(114, 39);
            this.clientelb.TabIndex = 39;
            this.clientelb.Text = "Cliente:";
            // 
            // cbxcliente
            // 
            this.cbxcliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxcliente.Font = new System.Drawing.Font("Arial Unicode MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxcliente.FormattingEnabled = true;
            this.cbxcliente.Location = new System.Drawing.Point(335, 108);
            this.cbxcliente.Name = "cbxcliente";
            this.cbxcliente.Size = new System.Drawing.Size(253, 44);
            this.cbxcliente.TabIndex = 38;
            this.cbxcliente.SelectedIndexChanged += new System.EventHandler(this.cbxcliente_SelectedIndexChanged);
            // 
            // btnsalir
            // 
            this.btnsalir.Font = new System.Drawing.Font("Arial Unicode MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.Location = new System.Drawing.Point(1010, 101);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(164, 54);
            this.btnsalir.TabIndex = 37;
            this.btnsalir.Text = "Salir";
            this.btnsalir.UseVisualStyleBackColor = true;
            this.btnsalir.Click += new System.EventHandler(this.salir_Click);
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
            this.crystalReportViewer1.TabIndex = 37;
            // 
            // InventarioProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.tbxsumapeso);
            this.Controls.Add(this.totalpesolb);
            this.Controls.Add(this.clientelb);
            this.Controls.Add(this.cbxcliente);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "InventarioProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventario Produccion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label inventariolb;
        private System.Windows.Forms.TextBox tbxsumapeso;
        private System.Windows.Forms.Label totalpesolb;
        private System.Windows.Forms.Label clientelb;
        private System.Windows.Forms.ComboBox cbxcliente;
        private System.Windows.Forms.Button btnsalir;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}