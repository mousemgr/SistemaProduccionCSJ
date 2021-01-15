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
    public partial class InventarioProduccion : Form
    {
        public InventarioProduccion()
        {
            InitializeComponent();
            cargarcbxcliente();
            crystalrpt("CrCliente");
            sumartotalpesoneto();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public void crystalrpt(string parametro)
        {
            CRverinventario crystalreport = new CRverinventario();

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

        public void sumartotalpesoneto()
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

            //CONSULTAR MAYOR CONSECUTIVO DEPENDIENDO DEL CLIENTE
            String QuerySumPesoNeto = "SELECT SUM(Kgs) AS Expr1 FROM InventarioProduccion WHERE Cliente = '" + cbxcliente.SelectedValue + "'";

            try
            {
                //CONVERTIR CONSULTA MAYOR CONSECUTIVO DEL CLIENTE A INT
                SqlCommand SumPesoNeto = new SqlCommand(QuerySumPesoNeto, OpenCon);



                if (SumPesoNeto.ExecuteScalar() != DBNull.Value)
                    tbxsumapeso.Text = Convert.ToString(SumPesoNeto.ExecuteScalar());
                else
                    tbxsumapeso.Text = "0";
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

        private void cbxcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            crystalrpt("CrCliente");
            sumartotalpesoneto();
        }
    }
}
