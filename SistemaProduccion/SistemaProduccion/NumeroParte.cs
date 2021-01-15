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

namespace SistemaProduccion
{
    public partial class NumeroParte : Form
    {
        public NumeroParte()
        {
            InitializeComponent();
            cargarcbxcliente();
            cargarcbxmaterial();
            pesomaterialprod();
        }

        private void btnsalir_Click(object sender, EventArgs e)
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

        public void cargarcbxmaterial()
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
                string query = "select TipoMaterial from MaterialProduccion";
                SqlDataAdapter da = new SqlDataAdapter(query, OpenCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "MaterialProduccion");
                cbxmaterial.DisplayMember = "TipoMaterial";
                cbxmaterial.ValueMember = "TipoMaterial";
                cbxmaterial.DataSource = ds.Tables["MaterialProduccion"];
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

        public void pesomaterialprod()
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

            //CONSULTA DENSIDAD MATERIAL 
            String ConsultaDensidad = "Select DensidadMaterial From MaterialProduccion Where TipoMaterial = '" + cbxmaterial.Text + "'";

            decimal densidadmate = 0;

            try
            {
                //Convetir consulta densidad
                SqlCommand com2 = new SqlCommand(ConsultaDensidad, OpenCon);

                if (com2.ExecuteScalar() != DBNull.Value)
                    densidadmate = Convert.ToDecimal(com2.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER LA DENSIDAD DEL MATERIAL ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //Calcular Peso de la pieza
            decimal PesoPieza = 0, espesor = 0, ancho = 0, largo = 0;

            if(tbxespesor.Text != "")
                espesor = decimal.Parse(tbxespesor.Text);
            
            if(tbxanchoblank.Text != "")
                ancho = decimal.Parse(tbxanchoblank.Text);
            
            if(tbxlargoblanck.Text != "")
                largo = decimal.Parse(tbxlargoblanck.Text);

            PesoPieza = densidadmate * espesor * ancho * largo;

            tbxpesopieza.Text = PesoPieza.ToString();

            //CALCULAR DESCUADRE
            double descuadre = 0;
            double x = 0;
            x = (Convert.ToDouble(largo) * Convert.ToDouble(largo)) + (Convert.ToDouble(ancho) * Convert.ToDouble(ancho));
            
            descuadre = Math.Pow(x,0.5);

            //Mostrar descuadre
            tbxdescuadre.Text = descuadre.ToString();

            OpenCon.Close();
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            #region validar datos
            float espesor = 0, espesormas = 0, espesormenos = 0, anchoblank = 0, anchomas = 0, anchomenos = 0;
            float largomas = 0, largomenos = 0, descuadre = 0, descuadremas = 0, descuadremenos = 0, pesopieza = 0, RebabaMax = 0;
            int anchorollo = 0, largo = 0, ondulacion = 0, piezastarima = 0, diametrointerno = 0, pesomaxcinta = 0, pesomincinta = 0, espesorbobinamax = 0;

            //Anchos de cintas
            int A1NumCin = 0, A2NumCin = 0, A3NumCin = 0, A4NumCin = 0, A5NumCin = 0;
            float A1AnchoCin = 0, A1AnchoCinMas = 0, A1AnchoCinMenos = 0, A2AnchoCin = 0, A2AnchoCinMas = 0, A2AnchoCinMenos = 0, A3AnchoCin = 0, A3AnchoCinMas = 0, A3AnchoCinMenos = 0;
            float A4AnchoCin = 0, A4AnchoCinMas = 0, A4AnchoCinMenos = 0, A5AnchoCin = 0, A5AnchoCinMas = 0, A5AnchoCinMenos = 0;

            if (tbxespesor.Text != "")
                espesor = float.Parse(tbxespesor.Text);

            if (tbxespesormas.Text != "")
                espesormas = float.Parse(tbxespesormas.Text);

            if (tbxespesormenos.Text != "")
                espesormenos = float.Parse(tbxespesormenos.Text);

            if (tbxanchoblank.Text != "")
                anchoblank = float.Parse(tbxanchoblank.Text);

            if (tbxanchomas.Text != "")
                anchomas = float.Parse(tbxanchomas.Text);

            if (tbxanchomenos.Text != "")
                anchomenos = float.Parse(tbxanchomenos.Text);

            if (tbxlargomas.Text != "")
                largomas = float.Parse(tbxlargomas.Text);

            if (tbxlargomenos.Text != "")
                largomenos = float.Parse(tbxlargomenos.Text);

            if (tbxdescuadre.Text != "")
                descuadre = float.Parse(tbxdescuadre.Text);

            if (tbxdescuadremas.Text != "")
                descuadremas = float.Parse(tbxdescuadremas.Text);

            if (tbxdescuadremenos.Text != "")
                descuadremenos = float.Parse(tbxdescuadremenos.Text);

            if (tbxanchorollo.Text != "")
                anchorollo = int.Parse(tbxanchorollo.Text);

            if (tbxlargoblanck.Text != "")
                largo = int.Parse(tbxlargoblanck.Text);

            if (tbxondulacion.Text != "")
                ondulacion = int.Parse(tbxondulacion.Text);

            if (tbxpiezastarima.Text != "")
                piezastarima = int.Parse(tbxpiezastarima.Text);

            if (TbxRebabaMax.Text != "")
                RebabaMax = float.Parse(TbxRebabaMax.Text);

            if (TbxDiametroInterno.Text != "")
                diametrointerno = int.Parse(TbxDiametroInterno.Text);

            if (TbxPesoMaxCin.Text != "")
                pesomaxcinta = int.Parse(TbxPesoMaxCin.Text);

            if (TbxPesoMinCinta.Text != "")
                pesomincinta = int.Parse(TbxPesoMinCinta.Text);

            if (TbxEspesorBobinaMax.Text != "")
                espesorbobinamax = int.Parse(TbxEspesorBobinaMax.Text);

            if (tbxa1numcintas.Text != "")
                A1NumCin = int.Parse(tbxa1numcintas.Text);

            if (tbxa2numcintas.Text != "")
                A2NumCin = int.Parse(tbxa2numcintas.Text);

            if (tbxa3numcintas.Text != "")
                A3NumCin = int.Parse(tbxa3numcintas.Text);

            if (tbxa4numcintas.Text != "")
                A4NumCin = int.Parse(tbxa4numcintas.Text);

            if (tbxa5numcintas.Text != "")
                A5NumCin = int.Parse(tbxa5numcintas.Text);

            if (tbxa1anchocin.Text != "")
                A1AnchoCin = float.Parse(tbxa1anchocin.Text);

            if (tbxa2anchocin.Text != "")
                A2AnchoCin = float.Parse(tbxa2anchocin.Text);

            if (tbxa3anchocin.Text != "")
                A3AnchoCin = float.Parse(tbxa3anchocin.Text);

            if (tbxa4anchocin.Text != "")
                A4AnchoCin = float.Parse(tbxa4anchocin.Text);

            if (tbxa5anchocin.Text != "")
                A5AnchoCin = float.Parse(tbxa5anchocin.Text);

            if (tbxa1anchocintamas.Text != "")
                A1AnchoCinMas = float.Parse(tbxa1anchocintamas.Text);

            if (tbxa2anchocinmas.Text != "")
                A2AnchoCinMas = float.Parse(tbxa2anchocinmas.Text);

            if (tbxa3anchocinmas.Text != "")
                A3AnchoCinMas = float.Parse(tbxa3anchocinmas.Text);

            if (tbxa4anchocinmas.Text != "")
                A4AnchoCinMas = float.Parse(tbxa4anchocinmas.Text);

            if (tbxa5anchocinmas.Text != "")
                A5AnchoCinMas = float.Parse(tbxa5anchocinmas.Text);

            if (tbxa1anchocinmenos.Text != "")
                A1AnchoCinMenos = float.Parse(tbxa1anchocinmenos.Text);

            if (tbxa2anchocinmenos.Text != "")
                A2AnchoCinMenos = float.Parse(tbxa2anchocinmenos.Text);

            if (tbxa3anchocinmenos.Text != "")
                A3AnchoCinMenos = float.Parse(tbxa3anchocinmenos.Text);

            if (tbxa4anchocinmenos.Text != "")
                A4AnchoCinMenos = float.Parse(tbxa4anchocinmenos.Text);

            if (tbxa5anchocinmenos.Text != "")
                A5AnchoCinMenos = float.Parse(tbxa5anchocinmenos.Text);

            if (tbxnumparte.Text == "")
            {
                MessageBox.Show("Favor de ingresar el numero de parte ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxempaque.Text == "")
            {
                MessageBox.Show("Favor de ingresar las condiciones del empaque ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxtarima.Text == "")
            {
                MessageBox.Show("Favor de ingresar las caracteristicas de la tarima ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxespesor.Text == "")
            {
                MessageBox.Show("Favor de ingresar el espesor ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxanchorollo.Text == "")
            {
                MessageBox.Show("Favor de ingresar el ancho del rollo ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxanchoblank.Text == "")
            {
                MessageBox.Show("Favor de ingresar el ancho del blank ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxlargoblanck.Text == "")
            {
                MessageBox.Show("Favor de ingresar el largo del blank ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxdescuadre.Text == "")
            {
                MessageBox.Show("Favor de ingresar el descuadre ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxondulacion.Text == "")
            {
                MessageBox.Show("Favor de ingresar la tolerancia de ondulacion ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #endregion

            SqlConnection OpenCon = new SqlConnection(@"Data Source=WIN-SERVER\JAGUARIRA;Initial Catalog=SistemaProduccion;Persist Security Info=True;User ID=sa;Password=Jaguar1");

            try
            {
                OpenCon.Open();
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //covetir el peso de la pieza a float
            pesopieza = float.Parse(tbxpesopieza.Text);

            //CONSULTAR MAYOR ID
            String ConsultaMaxId = "SELECT MAX(IdNumParte) AS IdNumParte FROM NumeroParte";

            //Consulta insertar datos recibo almacen
            String insertardatos = "insert into NumeroParte (IdNumParte, Cliente, NumParte, Material, Espesor, EspesorMas, EspesorMenos, AnchoRollo, AnchoBlank, AnchoMas, AnchoMenos, Largo, LargoMas, LargoMenos, Descuadre, DescuadreMas, DescuadreMenos, PesoPieza, Ondulacion, Empaque, Tarima, PiezasTarima, FechaAlta, DiametroInterno, PesoMaxCin, PesoMinCin, RebabaMax, EspesorBobinaMax) VALUES (@IdNumParte, @Cliente, @NumParte, @Material, @Espesor, @EspesorMas, @EspesorMenos, @AnchoRollo, @AnchoBlank, @AnchoMas, @AnchoMenos, @Largo, @LargoMas, @LargoMenos, @Descuadre, @DescuadreMas, @DescuadreMenos, @PesoPieza, @Ondulacion, @Empaque, @Tarima, @PiezasTarima, @FechaAlta, @DiametroInterno, @PesoMaxCin, @PesoMinCin, @RebabaMax, @EspesorBobinaMax)";

            //Consulta insertar datos cintas slitter
            String insertardatoscintas = "insert into AnchosCintasSlitter(A1NumCin, A2NumCin, A3NumCin, A4NumCin, A5NumCin, A1AnchoCin, A2AnchoCin, A3AnchoCin, A4AnchoCin, A5AnchoCin, A1AnchoCinMas, A2AnchoCinMas, A3AnchoCinMas, A4AnchoCinMas, A5AnchoCinMas, A1AnchoCinMenos, A2AnchoCinMenos, A3AnchoCinMenos, A4AnchoCinMenos, A5AnchoCinMenos, Cliente, NumParte) values (@A1NumCin, @A2NumCin, @A3NumCin, @A4NumCin, @A5NumCin, @A1AnchoCin, @A2AnchoCin, @A3AnchoCin, @A4AnchoCin, @A5AnchoCin, @A1AnchoCinMas, @A2AnchoCinMas, @A3AnchoCinMas, @A4AnchoCinMas, @A5AnchoCinMas, @A1AnchoCinMenos, @A2AnchoCinMenos, @A3AnchoCinMenos, @A4AnchoCinMenos, @A5AnchoCinMenos, @Cliente, @NumParte)";

            try
            {
                //CONVERTIR CONSULTA MAYOR ID A INT
                SqlCommand com = new SqlCommand(ConsultaMaxId, OpenCon);
                int MAXID = 0;

                if (com.ExecuteScalar() != DBNull.Value)
                    MAXID = Convert.ToInt32(com.ExecuteScalar()) + 1;
                else
                    MAXID = 1;

                //Insertar datos de recibo de material
                SqlCommand consultainsertardatos = new SqlCommand(insertardatos, OpenCon);
                consultainsertardatos.Parameters.Add("@IdNumParte", SqlDbType.Int).Value = MAXID;
                consultainsertardatos.Parameters.Add("@Cliente", SqlDbType.VarChar, 50).Value = cbxcliente.Text;
                consultainsertardatos.Parameters.Add("@NumParte", SqlDbType.VarChar, 50).Value = tbxnumparte.Text;
                consultainsertardatos.Parameters.Add("@Material", SqlDbType.VarChar, 50).Value = cbxmaterial.Text;
                consultainsertardatos.Parameters.Add("@Espesor", SqlDbType.Float).Value = espesor;
                consultainsertardatos.Parameters.Add("@EspesorMas", SqlDbType.Float).Value = espesormas;
                consultainsertardatos.Parameters.Add("@EspesorMenos", SqlDbType.Float).Value = espesormenos;
                consultainsertardatos.Parameters.Add("@AnchoRollo", SqlDbType.Int).Value = anchorollo;
                consultainsertardatos.Parameters.Add("@AnchoBlank", SqlDbType.Float).Value = anchoblank;
                consultainsertardatos.Parameters.Add("@AnchoMas", SqlDbType.Float).Value = anchomas;
                consultainsertardatos.Parameters.Add("@AnchoMenos", SqlDbType.Float).Value = anchomenos;
                consultainsertardatos.Parameters.Add("@Largo", SqlDbType.Int).Value = largo;
                consultainsertardatos.Parameters.Add("@LargoMas", SqlDbType.Float).Value = largomas;
                consultainsertardatos.Parameters.Add("@LargoMenos", SqlDbType.Float).Value = largomenos;
                consultainsertardatos.Parameters.Add("@Descuadre", SqlDbType.Float).Value = descuadre;
                consultainsertardatos.Parameters.Add("@DescuadreMas", SqlDbType.Float).Value = descuadremas;
                consultainsertardatos.Parameters.Add("@DescuadreMenos", SqlDbType.Float).Value = descuadremenos;
                consultainsertardatos.Parameters.Add("@PesoPieza", SqlDbType.Float).Value = pesopieza;
                consultainsertardatos.Parameters.Add("@Ondulacion", SqlDbType.Int).Value = ondulacion;
                consultainsertardatos.Parameters.Add("@Empaque", SqlDbType.VarChar, 50).Value = tbxempaque.Text;
                consultainsertardatos.Parameters.Add("@Tarima", SqlDbType.VarChar, 50).Value = tbxtarima.Text;
                consultainsertardatos.Parameters.Add("@PiezasTarima", SqlDbType.Int).Value = piezastarima;
                consultainsertardatos.Parameters.Add("@FechaAlta", SqlDbType.Date).Value = dateTimePicker1.Value;
                consultainsertardatos.Parameters.Add("@DiametroInterno", SqlDbType.Int).Value = diametrointerno;
                consultainsertardatos.Parameters.Add("@PesoMaxCin", SqlDbType.Int).Value = pesomaxcinta;
                consultainsertardatos.Parameters.Add("@PesoMinCin", SqlDbType.Int).Value = pesomincinta;
                consultainsertardatos.Parameters.Add("@RebabaMax", SqlDbType.Float).Value = RebabaMax;
                consultainsertardatos.Parameters.Add("@EspesorBobinaMax", SqlDbType.Int).Value = espesorbobinamax;
                consultainsertardatos.ExecuteNonQuery();

                //Insertar datos de Cintas Slitter   
                SqlCommand consultainsertardatoscintas = new SqlCommand(insertardatoscintas, OpenCon);
                consultainsertardatoscintas.Parameters.Add("@A1NumCin", SqlDbType.Int).Value = A1NumCin;
                consultainsertardatoscintas.Parameters.Add("@A2NumCin", SqlDbType.Int).Value = A2NumCin;
                consultainsertardatoscintas.Parameters.Add("@A3NumCin", SqlDbType.Int).Value = A3NumCin;
                consultainsertardatoscintas.Parameters.Add("@A4NumCin", SqlDbType.Int).Value = A4NumCin;
                consultainsertardatoscintas.Parameters.Add("@A5NumCin", SqlDbType.Int).Value = A5NumCin;
                consultainsertardatoscintas.Parameters.Add("@A1AnchoCin", SqlDbType.Int).Value = A1AnchoCin;
                consultainsertardatoscintas.Parameters.Add("@A2AnchoCin", SqlDbType.Int).Value = A2AnchoCin;
                consultainsertardatoscintas.Parameters.Add("@A3AnchoCin", SqlDbType.Int).Value = A3AnchoCin;
                consultainsertardatoscintas.Parameters.Add("@A4AnchoCin", SqlDbType.Int).Value = A4AnchoCin;
                consultainsertardatoscintas.Parameters.Add("@A5AnchoCin", SqlDbType.Int).Value = A5AnchoCin;
                consultainsertardatoscintas.Parameters.Add("@A1AnchoCinMas", SqlDbType.Int).Value = A1AnchoCinMas;
                consultainsertardatoscintas.Parameters.Add("@A2AnchoCinMas", SqlDbType.Int).Value = A2AnchoCinMas;
                consultainsertardatoscintas.Parameters.Add("@A3AnchoCinMas", SqlDbType.Int).Value = A3AnchoCinMas;
                consultainsertardatoscintas.Parameters.Add("@A4AnchoCinMas", SqlDbType.Int).Value = A4AnchoCinMas;
                consultainsertardatoscintas.Parameters.Add("@A5AnchoCinMas", SqlDbType.Int).Value = A5AnchoCinMas;
                consultainsertardatoscintas.Parameters.Add("@A1AnchoCinMenos", SqlDbType.Int).Value = A1AnchoCinMenos;
                consultainsertardatoscintas.Parameters.Add("@A2AnchoCinMenos", SqlDbType.Int).Value = A2AnchoCinMenos;
                consultainsertardatoscintas.Parameters.Add("@A3AnchoCinMenos", SqlDbType.Int).Value = A3AnchoCinMenos;
                consultainsertardatoscintas.Parameters.Add("@A4AnchoCinMenos", SqlDbType.Int).Value = A4AnchoCinMenos;
                consultainsertardatoscintas.Parameters.Add("@A5AnchoCinMenos", SqlDbType.Int).Value = A5AnchoCinMenos;
                consultainsertardatoscintas.Parameters.Add("@Cliente", SqlDbType.VarChar, 50).Value = cbxcliente.Text;
                consultainsertardatoscintas.Parameters.Add("@NumParte", SqlDbType.VarChar, 50).Value = tbxnumparte.Text;
                consultainsertardatoscintas.ExecuteNonQuery();

                //LIMPIAR VALORES 
                tbxnumparte.Text = ""; tbxespesor.Text = ""; tbxespesormas.Text = ""; tbxespesormenos.Text = ""; tbxanchorollo.Text = ""; tbxanchoblank.Text = "";
                tbxanchomas.Text = ""; tbxanchomenos.Text = ""; tbxlargoblanck.Text = ""; tbxlargomas.Text = ""; tbxlargomenos.Text = ""; tbxdescuadre.Text = "";
                tbxdescuadremas.Text = ""; tbxdescuadremenos.Text = ""; tbxondulacion.Text = ""; tbxempaque.Text = ""; tbxtarima.Text = ""; tbxpiezastarima.Text = "";
                tbxpesopieza.Text = ""; TbxDiametroInterno.Text = ""; TbxPesoMaxCin.Text = ""; TbxPesoMinCinta.Text = ""; TbxRebabaMax.Text = ""; TbxEspesorBobinaMax.Text = "";

                //LIMPIAR VALORES DE LAS CINTAS
                tbxa1anchocin.Text = ""; tbxa2anchocin.Text = ""; tbxa3anchocin.Text = ""; tbxa4anchocin.Text = ""; tbxa5anchocin.Text = ""; tbxa1numcintas.Text = ""; tbxa2numcintas.Text = "";
                tbxa3numcintas.Text = ""; tbxa4numcintas.Text = ""; tbxa5numcintas.Text = ""; tbxa1anchocintamas.Text = ""; tbxa2anchocinmas.Text = ""; tbxa3anchocinmas.Text = "";
                tbxa4anchocinmas.Text = ""; tbxa5anchocinmas.Text = ""; tbxa1anchocinmenos.Text = ""; tbxa2anchocinmenos.Text = ""; tbxa3anchocinmenos.Text = ""; tbxa4anchocinmenos.Text = ""; tbxa5anchocinmenos.Text = "";
                tbx21.Text = ""; tbx22.Text = ""; tbx23.Text = ""; tbx24.Text = "";

                //MENSAJE DE EXITO :D
                MessageBox.Show("Numero de parte capturado correctamente", "GAURDADO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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

        private void tbxanchorollo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxlargoblanck_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxespesor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxespesormas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxespesormenos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxanchoblank_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxanchomas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxanchomenos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxlargomas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxlargomenos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxdescuadre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxdescuadremas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxdescuadremenos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxondulacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxpiezastarima_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbxmaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            pesomaterialprod();
        }

        private void tbxespesor_KeyUp(object sender, KeyEventArgs e)
        {
            pesomaterialprod();
        }

        private void tbxanchoblank_KeyUp(object sender, KeyEventArgs e)
        {
            pesomaterialprod();
        }

        private void tbxlargoblanck_KeyUp(object sender, KeyEventArgs e)
        {
            pesomaterialprod();
        }

        private void btnnumparte_Click(object sender, EventArgs e)
        {
            VerNumParte vernumparte = new VerNumParte();
            vernumparte.ShowDialog();
        }

        private void TbxDiametroInterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TbxPesoMaxCin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TbxPesoMinCinta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TbxRebabaMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TbxEspesorBobinaMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxa1numcintas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxa2numcintas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxa3numcintas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxa4numcintas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxa5numcintas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbx24_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxa1anchocin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa1anchocintamas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa1anchocinmenos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa2anchocin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa2anchocinmas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa2anchocinmenos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa3anchocin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa3anchocinmas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa3anchocinmenos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa4anchocin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa4anchocinmas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa4anchocinmenos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa5anchocin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa5anchocinmas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbxa5anchocinmenos_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbx21_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbx23_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbx22_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void numparteslitter_Click(object sender, EventArgs e)
        {
            NumParteSlitter numparteslitter = new NumParteSlitter();
            numparteslitter.ShowDialog();
        }
    }
}
