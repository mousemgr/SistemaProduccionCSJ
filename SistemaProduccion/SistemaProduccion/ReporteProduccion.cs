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
using CrystalDecisions.Windows.Forms;

namespace SistemaProduccion
{
    public partial class ReporteProduccion : Form
    {
        public ReporteProduccion()
        {
            InitializeComponent();

            string LoteInternoJAG = VerRecibo.LoteInterno;
            string Clinete = "";
            string NumeroDeParte = "";
            string TipoMaterial = "";
            string NumeroDeRollo = "";
            string LoteDelCliente = "";
            int PesoRollo = 0;
            float EspesorRollo = 0, DescuadreBlank = 0, EsMas = 0, EsMenos = 0, AnMas = 0, AnMenos = 0, LaMas = 0, LaMenos = 0, DeMas = 0, DeMenos = 0, PesoTeorico = 0;
            int AnchoRollo = 0, AnchoBlank = 0, LargoBlank = 0, Ondulacion = 0, PiezasTarima = 0, IdRecibo = 0;
            string TarimaCon = "";

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

            //Consultas
            String ConsultaCliente = "Select Cliente From ReciboProduccion Where LoteInterno = '" + LoteInternoJAG + "'";
            String ConsultaNumeroParte = "Select NumeroParte From ReciboProduccion Where LoteInterno = '" + LoteInternoJAG + "'";
            String ConsultaMaterial = "Select Material From ReciboProduccion Where LoteInterno = '" + LoteInternoJAG + "'";
            String ConsultaNumRollo = "Select NumeroRollo From ReciboProduccion Where LoteInterno = '" + LoteInternoJAG + "'";
            String ConsultaLoteCliente = "Select LoteCliente From ReciboProduccion Where LoteInterno = '" + LoteInternoJAG + "'";
            String ConsultaKilogramos = "Select Kgs From ReciboProduccion Where LoteInterno = '" + LoteInternoJAG + "'";
            String ConsultaEspesor = "Select Espesor From ReciboProduccion Where LoteInterno = '" + LoteInternoJAG + "'";
            String ConsultaAnchoRollo = "Select Ancho From ReciboProduccion Where LoteInterno = '" + LoteInternoJAG + "'";
            String ConsultaIdRecibo = "Select IdReciboProduccion From ReciboProduccion Where LoteInterno = '" + LoteInternoJAG + "'";

            try
            {
                //Convetir consulta cliente
                SqlCommand com = new SqlCommand(ConsultaCliente, OpenCon);

                if (com.ExecuteScalar() != DBNull.Value)
                    Clinete = Convert.ToString(com.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL CLIENTE ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta numero de parte
                SqlCommand com2 = new SqlCommand(ConsultaNumeroParte, OpenCon);

                if (com2.ExecuteScalar() != DBNull.Value)
                    NumeroDeParte = Convert.ToString(com2.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL NUMERO DE PARTE ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta material
                SqlCommand com3 = new SqlCommand(ConsultaMaterial, OpenCon);

                if (com3.ExecuteScalar() != DBNull.Value)
                    TipoMaterial = Convert.ToString(com3.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL MATERIAL ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta numero de rollo
                SqlCommand com4 = new SqlCommand(ConsultaNumRollo, OpenCon);

                if (com4.ExecuteScalar() != DBNull.Value)
                    NumeroDeRollo = Convert.ToString(com4.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL NUMERO DE ROLLO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta lote del cliente
                SqlCommand com5 = new SqlCommand(ConsultaLoteCliente, OpenCon);

                if (com5.ExecuteScalar() != DBNull.Value)
                    LoteDelCliente = Convert.ToString(com5.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL LOTE DEL CLIENTE ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta peso del rollo
                SqlCommand com6 = new SqlCommand(ConsultaKilogramos, OpenCon);

                if (com6.ExecuteScalar() != DBNull.Value)
                    PesoRollo = Convert.ToInt32(com6.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL PESO DEL ROLLO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta espesor del rollo
                SqlCommand com7 = new SqlCommand(ConsultaEspesor, OpenCon);

                if (com7.ExecuteScalar() != DBNull.Value)
                    EspesorRollo = Convert.ToSingle(com7.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ESPESOR ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta ancho rollo
                SqlCommand com8 = new SqlCommand(ConsultaAnchoRollo, OpenCon);

                if (com8.ExecuteScalar() != DBNull.Value)
                    AnchoRollo = Convert.ToInt32(com8.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DEL ROLLO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta id recibo produccion
                SqlCommand com9 = new SqlCommand(ConsultaIdRecibo, OpenCon);

                if (com9.ExecuteScalar() != DBNull.Value)
                    IdRecibo = Convert.ToInt32(com9.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ID DE RECIBO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            String ConsultaAnchoBlank = "Select AnchoBlank From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaLargoBlank = "Select Largo From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaDescuadre = "Select Descuadre From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaEsMas = "Select EspesorMas From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaEsMenos = "Select EspesorMenos From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnMas = "Select AnchoMas From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnMenos = "Select AnchoMenos From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaLaMas = "Select LargoMas From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaLaMenos = "Select LargoMenos From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaDeMas = "Select DescuadreMas From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaDeMenos = "Select DescuadreMenos From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaOndulacion = "Select Ondulacion From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaPesoPieza = "Select PesoPieza From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaPiezasTarima = "Select PiezasTarima From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaTarimaCon = "Select Tarima From NumeroParte Where NumParte = '" + NumeroDeParte + "'";

            try
            {
                //Convetir consulta ancho del blank
                SqlCommand com8 = new SqlCommand(ConsultaAnchoBlank, OpenCon);

                if (com8.ExecuteScalar() != DBNull.Value)
                    AnchoBlank = Convert.ToInt32(com8.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DEL BLANK ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta largo del blank
                SqlCommand com = new SqlCommand(ConsultaLargoBlank, OpenCon);

                if (com.ExecuteScalar() != DBNull.Value)
                    LargoBlank = Convert.ToInt32(com.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL LARGO DEL BLANK ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta descuadre del blank
                SqlCommand com1 = new SqlCommand(ConsultaDescuadre, OpenCon);

                if (com1.ExecuteScalar() != DBNull.Value)
                    DescuadreBlank = Convert.ToSingle(com1.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL DESCUADRE DEL BLANK ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta espesor mas
                SqlCommand com2 = new SqlCommand(ConsultaEsMas, OpenCon);

                if (com2.ExecuteScalar() != DBNull.Value)
                    EsMas = Convert.ToSingle(com2.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ESPESOR MAS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta espesor menos
                SqlCommand com3 = new SqlCommand(ConsultaEsMenos, OpenCon);

                if (com3.ExecuteScalar() != DBNull.Value)
                    EsMenos = Convert.ToSingle(com3.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ESPESOR MENOS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta ancho mas
                SqlCommand com4 = new SqlCommand(ConsultaAnMas, OpenCon);

                if (com4.ExecuteScalar() != DBNull.Value)
                    AnMas = Convert.ToSingle(com4.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO MAS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta ancho menos
                SqlCommand com5 = new SqlCommand(ConsultaAnMenos, OpenCon);

                if (com5.ExecuteScalar() != DBNull.Value)
                    AnMenos = Convert.ToSingle(com5.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO MENOS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta largo mas
                SqlCommand com6 = new SqlCommand(ConsultaLaMas, OpenCon);

                if (com6.ExecuteScalar() != DBNull.Value)
                    LaMas = Convert.ToSingle(com6.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL LARGO MAS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta largo menos
                SqlCommand com7 = new SqlCommand(ConsultaLaMenos, OpenCon);

                if (com7.ExecuteScalar() != DBNull.Value)
                    LaMenos = Convert.ToSingle(com7.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL LARGO MENOS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta descuadre mas
                SqlCommand com9 = new SqlCommand(ConsultaDeMas, OpenCon);

                if (com9.ExecuteScalar() != DBNull.Value)
                    DeMas = Convert.ToSingle(com9.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL DESCUADRE MAS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta descuadre menos
                SqlCommand com10 = new SqlCommand(ConsultaDeMenos, OpenCon);

                if (com10.ExecuteScalar() != DBNull.Value)
                    DeMenos = Convert.ToSingle(com10.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL DESCUADRE MENOS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta ondulacion
                SqlCommand com11 = new SqlCommand(ConsultaOndulacion, OpenCon);

                if (com11.ExecuteScalar() != DBNull.Value)
                    Ondulacion = Convert.ToInt32(com11.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER LA ONDULACION ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta peso teorico
                SqlCommand com12 = new SqlCommand(ConsultaPesoPieza, OpenCon);

                if (com12.ExecuteScalar() != DBNull.Value)
                    PesoTeorico = Convert.ToSingle(com12.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL PESO TEORICO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta piezas tarima
                SqlCommand com13 = new SqlCommand(ConsultaPiezasTarima, OpenCon);

                if (com13.ExecuteScalar() != DBNull.Value)
                    PiezasTarima = Convert.ToInt32(com13.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER LAS PIEZAS POR TARIMA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta caracteristicas de la tarima
                SqlCommand com14 = new SqlCommand(ConsultaTarimaCon, OpenCon);

                if (com14.ExecuteScalar() != DBNull.Value)
                    TarimaCon = Convert.ToString(com14.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER LAS CARACTERISTICAS DE LA TARIMA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CRreporteproduccion crystalreport = new CRreporteproduccion();
            crystalreport.SetDatabaseLogon("sa", "Jaguar1", "WIN-SERVER\\JAGUARIRA", "SistemaProduccion");

            //TEXTOS
            TextObject text = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text159"];
            text.Text = LoteInternoJAG;

            TextObject text2 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text202"];
            text2.Text = Clinete;

            TextObject text3 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text203"];
            text3.Text = NumeroDeParte;

            TextObject text4 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text208"];
            text4.Text = TipoMaterial;

            TextObject text5 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text209"];
            text5.Text = NumeroDeRollo;

            TextObject text6 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text210"];
            text6.Text = LoteDelCliente;

            TextObject text7 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text211"];
            text7.Text = PesoRollo.ToString();

            TextObject text8 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text212"];
            text8.Text = EspesorRollo.ToString();

            TextObject text9 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text213"];
            text9.Text = AnchoRollo.ToString();

            TextObject text10 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text214"];
            text10.Text = EspesorRollo.ToString();

            TextObject text11 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text215"];
            text11.Text = AnchoBlank.ToString();

            TextObject text12 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text216"];
            text12.Text = LargoBlank.ToString();

            TextObject text13 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text217"];
            text13.Text = DescuadreBlank.ToString();

            //

            EsMas = EspesorRollo + EsMas;
            EsMenos = EspesorRollo - EsMenos;
            AnMas = AnchoBlank + AnMas;
            AnMenos = AnchoBlank - AnMenos;
            LaMas = LargoBlank + LaMas;
            LaMenos = LargoBlank - LaMenos;
            DeMas = DescuadreBlank + DeMas;
            DeMenos = DescuadreBlank - DeMenos;

            //

            TextObject text14 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text218"];
            text14.Text = EsMas.ToString();

            TextObject text15 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text219"];
            text15.Text = EsMenos.ToString();

            TextObject text16 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text220"];
            text16.Text = AnMas.ToString();

            TextObject text17 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text221"];
            text17.Text = AnMenos.ToString();

            TextObject text18 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text222"];
            text18.Text = LaMas.ToString();

            TextObject text19 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text223"];
            text19.Text = LaMenos.ToString();

            TextObject text20 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text224"];
            text20.Text = DeMas.ToString();

            TextObject text21 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text225"];
            text21.Text = DeMenos.ToString();

            TextObject text22 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text226"];
            text22.Text = Ondulacion.ToString();

            TextObject text23 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text227"];
            text23.Text = PesoTeorico.ToString();

            TextObject text24 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text228"];
            text24.Text = TarimaCon.ToString();

            TextObject text25 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text229"];
            text25.Text = PiezasTarima.ToString();

            TextObject text26 = (TextObject)crystalreport.ReportDefinition.Sections["Section1"].ReportObjects["Text230"];
            text26.Text = IdRecibo.ToString();

            TextObject text27 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text231"];
            text27.Text = login.VariableSecion.ToString();

            //

            crystalReportViewer1.ReportSource = crystalreport;
            crystalReportViewer1.Refresh();

            crystalReportViewer1.RefreshReport();

            OpenCon.Close();
        }
    }
}
