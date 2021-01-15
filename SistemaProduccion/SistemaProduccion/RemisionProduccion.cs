using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace SistemaProduccion
{
    public partial class RemisionProduccion : Form
    {
        public RemisionProduccion()
        {
            InitializeComponent();
            crystalrpt();
        }

        public void crystalrpt()
        {
            string NumeroDeRemision = "JAG-R" + EmbarqueProduccion.NumRemision;
            string NomTrans = EmbarqueProduccion.NombreTransportista;
            string EmbarcadoA = EmbarqueProduccion.Destino;
            string ClienteEmbarque = EmbarqueProduccion.ClienteRem;
            string FechaRemision = EmbarqueProduccion.FechaRem;
            string LineaTransportista = EmbarqueProduccion.LineaTrans;
            string NumeroEconomico = EmbarqueProduccion.NoEconom;

            CRremision crystalreport = new CRremision();
            crystalreport.SetDatabaseLogon("sa", "Jaguar1");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

            TextObject text = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text31"];
            text.Text = NomTrans;

            TextObject text2 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text30"];
            text2.Text = EmbarcadoA;

            TextObject text3 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text32"];
            text3.Text = ClienteEmbarque;

            TextObject text4 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text33"];
            text4.Text = FechaRemision;

            TextObject text5 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text12"];
            text5.Text = NumeroEconomico;

            TextObject text6 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text11"];
            text6.Text = LineaTransportista;

            crParameterDiscreteValue.Value = NumeroDeRemision;
            crParameterFieldDefinitions = crystalreport.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["NumeroRem"];

            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer1.ReportSource = crystalreport;
            crystalReportViewer1.Refresh();

            crystalReportViewer1.RefreshReport();
        }
    }
}
