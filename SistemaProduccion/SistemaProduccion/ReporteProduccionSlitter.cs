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
    public partial class ReporteProduccionSlitter : Form
    {
        public ReporteProduccionSlitter()
        {
            InitializeComponent();

            string LoteInternoJAG = VerRecibo.LoteInterno;
            string Clinete = "";
            string NumeroDeParte = "";
            string TipoMaterial = "";
            string NumeroDeRollo = "";
            string LoteDelCliente = "";
            int PesoRollo = 0;
            float EspesorRollo = 0, EsMas = 0, EsMenos = 0;
            int AnchoRollo = 0, IdRecibo = 0;
            int diametrointerno = 0, pesomaxcin = 0, pesomincin = 0, espesorbobinamax = 0;
            float rebabamax = 0;

            //cintas
            int numcin1 = 0, numcin2 = 0, numcin3 = 0, numcin4 = 0, numcin5 = 0;
            float anchocin1 = 0, anchocin2 = 0, anchocin3 = 0, anchocin4 = 0, anchocin5 = 0;
            float numcin1amas = 0, numcin1amenos = 0, numcin2amas = 0, numcin2amenos = 0, numcin3amas = 0, numcin3amenos = 0, numcin4amas = 0, numcin4amenos = 0, numcin5amas = 0, numcin5amenos = 0;
            string empaque = "", tarima = "";

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

            String ConsultaEsMas = "Select EspesorMas From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaEsMenos = "Select EspesorMenos From NumeroParte Where NumParte = '" + NumeroDeParte + "'";

            /////--------------------
            String ConsultaDiametroInterno = "Select DiametroInterno From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaPesoMaximoCin = "Select PesoMaxCin From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaPesoMinimoCin = "Select PesoMinCin From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaEsBobinaMax = "Select RebabaMax From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaRebabaMax = "Select EspesorBobinaMax From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaEmpaque = "Select Empaque From NumeroParte Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaTarima = "Select Tarima From NumeroParte Where NumParte = '" + NumeroDeParte + "'";

            //Consultas cintas
            String ConsultaNumCintas1 = "Select A1NumCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaNumCintas2 = "Select A2NumCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaNumCintas3 = "Select A3NumCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaNumCintas4 = "Select A4NumCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaNumCintas5 = "Select A5NumCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";

            String ConsultaAnchoCin1 = "Select A1AnchoCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin2 = "Select A2AnchoCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin3 = "Select A3AnchoCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin4 = "Select A4AnchoCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin5 = "Select A5AnchoCin From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";

            String ConsultaAnchoCin1Mas = "Select A1AnchoCinMas From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin2Mas = "Select A2AnchoCinMas From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin3Mas = "Select A3AnchoCinMas From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin4Mas = "Select A4AnchoCinMas From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin5Mas = "Select A5AnchoCinMas From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";

            String ConsultaAnchoCin1Menos = "Select A1AnchoCinMenos From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin2Menos = "Select A2AnchoCinMenos From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin3Menos = "Select A3AnchoCinMenos From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin4Menos = "Select A4AnchoCinMenos From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";
            String ConsultaAnchoCin5Menos = "Select A5AnchoCinMenos From AnchosCintasSlitter Where NumParte = '" + NumeroDeParte + "'";

            try
            {
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

                //Convertir consulta numero de cintas 1
                SqlCommand com1 = new SqlCommand(ConsultaNumCintas1, OpenCon);

                if (com1.ExecuteScalar() != DBNull.Value)
                    numcin1 = Convert.ToInt32(com1.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL NUMERO DE CINTAS 1 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta numero de cintas 2
                SqlCommand com4 = new SqlCommand(ConsultaNumCintas2, OpenCon);

                if (com4.ExecuteScalar() != DBNull.Value)
                    numcin2 = Convert.ToInt32(com4.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL NUMERO DE CINTAS 2 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta numero de cintas 3
                SqlCommand com5 = new SqlCommand(ConsultaNumCintas3, OpenCon);

                if (com5.ExecuteScalar() != DBNull.Value)
                    numcin3 = Convert.ToInt32(com5.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL NUMERO DE CINTAS 3 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta numero de cintas 4
                SqlCommand com6 = new SqlCommand(ConsultaNumCintas4, OpenCon);

                if (com6.ExecuteScalar() != DBNull.Value)
                    numcin4 = Convert.ToInt32(com6.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL NUMERO DE CINTAS 4 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta numero de cintas 5
                SqlCommand com7 = new SqlCommand(ConsultaNumCintas5, OpenCon);

                if (com7.ExecuteScalar() != DBNull.Value)
                    numcin5 = Convert.ToInt32(com7.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL NUMERO DE CINTAS 5 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta 1
                SqlCommand com8 = new SqlCommand(ConsultaAnchoCin1, OpenCon);

                if (com8.ExecuteScalar() != DBNull.Value)
                    anchocin1 = Convert.ToSingle(com8.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 1 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta 2
                SqlCommand com9 = new SqlCommand(ConsultaAnchoCin2, OpenCon);

                if (com9.ExecuteScalar() != DBNull.Value)
                    anchocin2 = Convert.ToSingle(com9.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 2 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta 3
                SqlCommand com10 = new SqlCommand(ConsultaAnchoCin3, OpenCon);

                if (com10.ExecuteScalar() != DBNull.Value)
                    anchocin3 = Convert.ToSingle(com10.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 3 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta 4
                SqlCommand com11 = new SqlCommand(ConsultaAnchoCin4, OpenCon);

                if (com11.ExecuteScalar() != DBNull.Value)
                    anchocin4 = Convert.ToSingle(com11.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 4 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta 5
                SqlCommand com12 = new SqlCommand(ConsultaAnchoCin5, OpenCon);

                if (com12.ExecuteScalar() != DBNull.Value)
                    anchocin5 = Convert.ToSingle(com12.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 5 ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta mas 1
                SqlCommand com13 = new SqlCommand(ConsultaAnchoCin1Mas, OpenCon);

                if (com13.ExecuteScalar() != DBNull.Value)
                    numcin1amas = Convert.ToSingle(com13.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 1 MAS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta mas 2
                SqlCommand com14 = new SqlCommand(ConsultaAnchoCin2Mas, OpenCon);

                if (com14.ExecuteScalar() != DBNull.Value)
                    numcin2amas = Convert.ToSingle(com14.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 2 MAS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta mas 3
                SqlCommand com15 = new SqlCommand(ConsultaAnchoCin3Mas, OpenCon);

                if (com15.ExecuteScalar() != DBNull.Value)
                    numcin3amas = Convert.ToSingle(com15.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 3 MAS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta mas 4
                SqlCommand com16 = new SqlCommand(ConsultaAnchoCin4Mas, OpenCon);

                if (com16.ExecuteScalar() != DBNull.Value)
                    numcin4amas = Convert.ToSingle(com16.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 4 MAS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta mas 5
                SqlCommand com17 = new SqlCommand(ConsultaAnchoCin5Mas, OpenCon);

                if (com17.ExecuteScalar() != DBNull.Value)
                    numcin5amas = Convert.ToSingle(com17.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 5 MAS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta menos 1
                SqlCommand com18 = new SqlCommand(ConsultaAnchoCin1Menos, OpenCon);

                if (com18.ExecuteScalar() != DBNull.Value)
                    numcin1amenos = Convert.ToSingle(com18.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 1 MENOS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta menos 2
                SqlCommand com19 = new SqlCommand(ConsultaAnchoCin2Menos, OpenCon);

                if (com19.ExecuteScalar() != DBNull.Value)
                    numcin2amenos = Convert.ToSingle(com19.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 2 MENOS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta menos 3
                SqlCommand com20 = new SqlCommand(ConsultaAnchoCin3Menos, OpenCon);

                if (com20.ExecuteScalar() != DBNull.Value)
                    numcin3amenos = Convert.ToSingle(com20.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 3 MENOS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta menos 4
                SqlCommand com21 = new SqlCommand(ConsultaAnchoCin4Menos, OpenCon);

                if (com21.ExecuteScalar() != DBNull.Value)
                    numcin4amenos = Convert.ToSingle(com21.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 4 MENOS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta ancho cinta menos 5
                SqlCommand com22 = new SqlCommand(ConsultaAnchoCin5Menos, OpenCon);

                if (com22.ExecuteScalar() != DBNull.Value)
                    numcin5amenos = Convert.ToSingle(com22.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DE LA CINTA 5 MENOS ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta diametro interno 
                SqlCommand com23 = new SqlCommand(ConsultaDiametroInterno, OpenCon);

                if (com23.ExecuteScalar() != DBNull.Value)
                    diametrointerno = Convert.ToInt32(com23.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL DIAMETRO INTERNO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta peso maximo cinta 
                SqlCommand com24 = new SqlCommand(ConsultaPesoMaximoCin, OpenCon);

                if (com24.ExecuteScalar() != DBNull.Value)
                    pesomaxcin = Convert.ToInt32(com24.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL PESO MAXIMO DE LA CINTA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta peso minimo cinta 
                SqlCommand com25 = new SqlCommand(ConsultaPesoMinimoCin, OpenCon);

                if (com25.ExecuteScalar() != DBNull.Value)
                    pesomincin = Convert.ToInt32(com25.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL PESO MINIMO DE LA CINTA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta espesor maximo de la bobina
                SqlCommand com26 = new SqlCommand(ConsultaEsBobinaMax, OpenCon);

                if (com26.ExecuteScalar() != DBNull.Value)
                    espesorbobinamax = Convert.ToInt32(com26.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ESPESOR MAXIMO DE LA BOBINA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta rebaba max
                SqlCommand com27 = new SqlCommand(ConsultaRebabaMax, OpenCon);

                if (com27.ExecuteScalar() != DBNull.Value)
                    rebabamax = Convert.ToSingle(com27.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER LA REBABA MAXIMA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta empaque
                SqlCommand com28 = new SqlCommand(ConsultaEmpaque, OpenCon);

                if (com28.ExecuteScalar() != DBNull.Value)
                    empaque = Convert.ToString(com28.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER LAS CONDICIONES DEL EMPAQUE ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convertir consulta tarima
                SqlCommand com29 = new SqlCommand(ConsultaTarima, OpenCon);

                if (com29.ExecuteScalar() != DBNull.Value)
                    tarima = Convert.ToString(com29.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER LAS CONDICIONES DE LA TARIMA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            CRreporteslitter crystalreport = new CRreporteslitter();
            crystalreport.SetDatabaseLogon("sa", "Jaguar1", "WIN-SERVER\\JAGUARIRA", "SistemaProduccion");

            ////------------

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

            TextObject text26 = (TextObject)crystalreport.ReportDefinition.Sections["Section1"].ReportObjects["Text230"];
            text26.Text = IdRecibo.ToString();

            TextObject text27 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text231"];
            text27.Text = login.VariableSecion.ToString();

            TextObject text28 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text93"];
            text28.Text = LoteInternoJAG;

            TextObject text29 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text94"];
            text29.Text = LoteInternoJAG;

            TextObject text30 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text97"];
            text30.Text = LoteInternoJAG;

            TextObject text31 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text107"];
            text31.Text = LoteInternoJAG;

            TextObject text32 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text108"];
            text32.Text = LoteInternoJAG;

            TextObject text33 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text109"];
            text33.Text = LoteInternoJAG;

            TextObject text34 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text110"];
            text34.Text = LoteInternoJAG;

            TextObject text35 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text111"];
            text35.Text = LoteInternoJAG;

            TextObject text36 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text112"];
            text36.Text = LoteInternoJAG;

            TextObject text37 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text113"];
            text37.Text = LoteInternoJAG;

            TextObject text38 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text114"];
            text38.Text = LoteInternoJAG;

            TextObject text39 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text131"];
            text39.Text = LoteInternoJAG;

            TextObject text40 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text132"];
            text40.Text = LoteInternoJAG;

            TextObject text41 = (TextObject)crystalreport.ReportDefinition.Sections["Section3"].ReportObjects["Text133"];
            text41.Text = LoteInternoJAG;

            ////------------------

            EsMas = EspesorRollo + EsMas;
            EsMenos = EspesorRollo - EsMenos;
            numcin1amas = anchocin1 + numcin1amas;
            numcin2amas = anchocin2 + numcin2amas;
            numcin3amas = anchocin3 + numcin3amas;
            numcin4amas = anchocin4 + numcin4amas;
            numcin5amas = anchocin5 + numcin5amas;
            numcin1amenos = anchocin1 - numcin1amenos;
            numcin2amenos = anchocin2 - numcin2amenos;
            numcin3amenos = anchocin3 - numcin3amenos;
            numcin4amenos = anchocin4 - numcin4amenos;
            numcin5amenos = anchocin5 - numcin5amenos;

            ////------------------


            TextObject text10 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text214"];
            text10.Text = EspesorRollo.ToString();

            TextObject text14 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text218"];
            text14.Text = EsMas.ToString();

            TextObject text15 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text219"];
            text15.Text = EsMenos.ToString();

            TextObject text16 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text215"];
            text16.Text = numcin1.ToString();

            TextObject text17 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text75"];
            text17.Text = numcin2.ToString();

            TextObject text18 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text103"];
            text18.Text = numcin3.ToString();

            TextObject text19 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text119"];
            text19.Text = numcin4.ToString();

            TextObject text20 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text127"];
            text20.Text = numcin5.ToString();

            TextObject text21 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text19"];
            text21.Text = anchocin1.ToString();

            TextObject text22 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text80"];
            text22.Text = anchocin2.ToString();

            TextObject text23 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text106"];
            text23.Text = anchocin3.ToString();

            TextObject text24 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text122"];
            text24.Text = anchocin4.ToString();

            TextObject text25 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text130"];
            text25.Text = anchocin5.ToString();

            TextObject text42 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text221"];
            text42.Text = numcin1amenos.ToString();

            TextObject text43 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text36"];
            text43.Text = numcin2amenos.ToString();

            TextObject text44 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text99"];
            text44.Text = numcin3amenos.ToString();

            TextObject text45 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text115"];
            text45.Text = numcin4amenos.ToString();

            TextObject text46 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text123"];
            text46.Text = numcin5amenos.ToString();

            TextObject text47 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text220"];
            text47.Text = numcin1amas.ToString();

            TextObject text48 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text78"];
            text48.Text = numcin2amas.ToString();

            TextObject text49 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text104"];
            text49.Text = numcin3amas.ToString();

            TextObject text50 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text120"];
            text50.Text = numcin4amas.ToString();

            TextObject text51 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text128"];
            text51.Text = numcin5amas.ToString();

            TextObject text52 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text154"];
            text52.Text = diametrointerno.ToString();

            TextObject text53 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text158"];
            text53.Text = pesomaxcin.ToString();

            TextObject text54 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text152"];
            text54.Text = rebabamax.ToString();

            TextObject text55 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text156"];
            text55.Text = espesorbobinamax.ToString();

            TextObject text56 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text161"];
            text56.Text = pesomincin.ToString();

            TextObject text57 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text228"];
            text57.Text = empaque;

            TextObject text58 = (TextObject)crystalreport.ReportDefinition.Sections["Section2"].ReportObjects["Text201"];
            text58.Text = tarima;

            crystalReportViewer1.ReportSource = crystalreport;
            crystalReportViewer1.Refresh();

            crystalReportViewer1.RefreshReport();
        }
    }
}
