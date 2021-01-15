using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace SistemaProduccion
{
    public partial class VerProduccionSlitter : Form
    {
        public VerProduccionSlitter()
        {
            InitializeComponent();
            cargarcbxcliente();
            crystalrpt("CrCliente");
        }

        public void cargarcbxcliente()
        {
            SqlConnection OpenCon = new SqlConnection(@"Data Source=WIN-SERVER\JAGUARIRA;Initial Catalog=SistemaProduccion;Persist Security Info=True;User ID=sa;Password=Jaguar1");

            try
            {
                OpenCon.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                string query = "select NombreCliente from ClientesProduccion order by NombreCliente";
                SqlDataAdapter da = new SqlDataAdapter(query, OpenCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "ClientesProduccion");
                cbxcliente.DisplayMember = "NombreCliente";
                cbxcliente.ValueMember = "NombreCliente";
                cbxcliente.DataSource = ds.Tables["ClientesProduccion"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            OpenCon.Close();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void crystalrpt(string parametro)
        {
            CRverproduccionslitter crystalreport = new CRverproduccionslitter();

            crystalreport.SetDatabaseLogon("sa", "Jaguar1", "WIN-SERVER\\JAGUARIRA", "SistemaProduccion");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            crParameterDiscreteValue.Value = cbxcliente.Text;
            crParameterFieldDefinitions = crystalreport.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions[parametro];

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = crystalreport;
            crystalReportViewer1.Refresh();

            crystalReportViewer1.RefreshReport();
        }

        private void cbxcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            crystalrpt("CrCliente");
        }
    }
}
