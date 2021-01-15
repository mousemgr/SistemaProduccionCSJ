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
    public partial class BlankingProduccion : Form
    {
        public BlankingProduccion()
        {
            InitializeComponent();
            cargarcbxcliente();
            cargarcbxloteinterno();
            cargarcaracteristicas();
        }

        public bool bandera = false;

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if(bandera == false)
                this.Close();
            else
                MessageBox.Show("FAVOR DE FINALIZAR LA PRODUCCION ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void cargarcbxloteinterno()
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

            ////combo box lote interno
            try
            {
                string query = "select LoteInterno from InventarioProduccion where Cliente = '" + cbxcliente.SelectedValue + "' and ProducidoBlanking = 0 order by LoteInterno";
                SqlDataAdapter da = new SqlDataAdapter(query, OpenCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "InventarioProduccion");
                cbxloteinterno.DisplayMember = "LoteInterno";
                cbxloteinterno.ValueMember = "LoteInterno";
                cbxloteinterno.DataSource = ds.Tables["InventarioProduccion"];
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
            cargarcbxloteinterno();
            cargarcaracteristicas();
        }

        private void tbxnumtarima_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxkgstarima_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxpzstarima_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void cargarcaracteristicas()
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

            //CONSULTAS DE LAS CARACTERISTICAS DEL ROLLO
            String ConsultaNumRollo = "Select NumeroRollo From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";
            String ConsultaLoteCliente = "Select LoteCliente From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";
            String ConsultaEspecificacion = "Select Especificacion From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";
            String ConsultaMaterial = "Select Material From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";
            String ConsultaKgs = "Select Kgs From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";
            String ConsultaEspesor = "Select Espesor From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";
            String ConsultaAnchoRollo = "Select Ancho From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";
            String ConsultaNumParte = "Select NumeroParte From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";  

            try
            {
                //Convetir consulta num rollo
                SqlCommand com4 = new SqlCommand(ConsultaNumRollo, OpenCon);

                if (com4.ExecuteScalar() != DBNull.Value)
                    tbxnumrollo.Text = Convert.ToString(com4.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL NUMERO DEL ROLLO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta lote del cliente
                SqlCommand com5 = new SqlCommand(ConsultaLoteCliente, OpenCon);

                if (com5.ExecuteScalar() != DBNull.Value)
                    tbxlotecliente.Text = Convert.ToString(com5.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL LOTE DEL CLIENTE ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta especificacion
                SqlCommand com6 = new SqlCommand(ConsultaEspecificacion, OpenCon);

                if (com6.ExecuteScalar() != DBNull.Value)
                    tbxespecificacion.Text = Convert.ToString(com6.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER LA ESPECIFICACION DEL ROLLO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta material
                SqlCommand com = new SqlCommand(ConsultaMaterial, OpenCon);

                if (com.ExecuteScalar() != DBNull.Value)
                    tbxmaterial.Text = Convert.ToString(com.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL TIPO DE MATERIAL ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta kgs
                SqlCommand com7 = new SqlCommand(ConsultaKgs, OpenCon);

                if (com7.ExecuteScalar() != DBNull.Value)
                    tbxkgs.Text = Convert.ToString(com7.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER LOS KGS DEL ROLLO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta espesor
                SqlCommand com2 = new SqlCommand(ConsultaEspesor, OpenCon);

                if (com2.ExecuteScalar() != DBNull.Value)
                    tbxespesor.Text = Convert.ToString(com2.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ESPESOR ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta ancho rollo
                SqlCommand com3 = new SqlCommand(ConsultaAnchoRollo, OpenCon);

                if (com3.ExecuteScalar() != DBNull.Value)
                    tbxancho.Text = Convert.ToString(com3.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DEL ROLLO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta ancho
                SqlCommand com8 = new SqlCommand(ConsultaNumParte, OpenCon);

                if (com8.ExecuteScalar() != DBNull.Value)
                    tbxnumparte.Text = Convert.ToString(com8.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL NUMERO DE PARTE ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            //CONSULTAS DE LAS CARACTERISTICAS DEL NUMERO DE PARTE
            String ConsultaAnchoBlank = "Select AnchoBlank From NumeroParte Where NumParte = '" + tbxnumparte.Text + "'";
            String ConsultaLargoBlank = "Select Largo From NumeroParte Where NumParte = '" + tbxnumparte.Text + "'";

            //LOTE INTERNO JAG
            string loteinternojag = cbxloteinterno.Text;

            //CONSULTAR MAYOR ID
            String ConsultaMaxId = "SELECT MAX(NumeroTarima) AS NumeroTarima FROM InventarioProduccion where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";

            try
            {
                //Convetir consulta ancho blank
                SqlCommand com9 = new SqlCommand(ConsultaAnchoBlank, OpenCon);

                if (com9.ExecuteScalar() != DBNull.Value)
                    tbxanchoblank.Text = Convert.ToString(com9.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO DEL BLANK ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta largo blank
                SqlCommand com10 = new SqlCommand(ConsultaLargoBlank, OpenCon);

                if (com10.ExecuteScalar() != DBNull.Value)
                    tbxlargoblank.Text = Convert.ToString(com10.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL LARGO DEL BLANK ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //CONVERTIR CONSULTA MAYOR ID A INT
                SqlCommand com = new SqlCommand(ConsultaMaxId, OpenCon);
                int MAXID = 0;

                if (com.ExecuteScalar() != DBNull.Value)
                    MAXID = Convert.ToInt32(com.ExecuteScalar()) + 1;
                else
                    MAXID = 1;

                //Formar label lote interno jaguar
                lbjagtarima.Text = loteinternojag + " " + Convert.ToString(MAXID) + ":";

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

        private void cbxloteinterno_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarcaracteristicas();
        }

        private void btnverproduccion_Click(object sender, EventArgs e)
        {
            VerProduccionBlanking verproduccionblankin = new VerProduccionBlanking();
            verproduccionblankin.ShowDialog();
        }

        private void tbncargartarima_Click(object sender, EventArgs e)
        {
            #region validar datos
            int numerodetarimas = 0, kgstarima = 0, pzstarima = 0, idreciboprod = 0, idconsecliente = 0;
            string nombrecaptu = login.VariableSecion; 

            if (tbxnumtarima.Text != "")
                numerodetarimas = int.Parse(tbxnumtarima.Text);

            if (tbxkgstarima.Text != "")
                kgstarima = int.Parse(tbxkgstarima.Text);

            if (tbxpzstarima.Text != "")
                pzstarima = int.Parse(tbxpzstarima.Text);

            if (tbxnumtarima.Text == "")
            {
                MessageBox.Show("Favor de ingresar el numero de tarimas generadas de este rollo ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxkgstarima.Text == "")
            {
                MessageBox.Show("Favor de ingresar los kgs de la tarima ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxpzstarima.Text == "")
            {
                MessageBox.Show("Favor de ingresar las piezas de la tarima ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbxloteinterno.Text == "")
            {
                MessageBox.Show("Favor de seleccionar un jag ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Deshabilitar controles
            cbxcliente.Enabled = false;
            cbxloteinterno.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            tbxnumtarima.ReadOnly = true;

            #endregion

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

            //CONSULTA ID CONSECUTIVO CLIENTE
            String ConsultaIdConseCliente = "Select IdConseCliente From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";

            //CONSULTA fecha de recibo
            String ConsultaFechaRecibo = "Select FechaRecibo From InventarioProduccion Where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";

            //Consulta insertar datos inventario produccion
            String insertdatosinventario = "insert into InventarioProduccion(IdReciboProduccion, Cliente, LoteInterno, NumeroRollo, LoteCliente, Presentacion, Especificacion, Kgs, Piezas, NumeroParte, Material, Espesor, Ancho, Largo, FechaRecibo, IdConseCliente, NombreCapturista, NumeroTarima, ProducidoBlanking) VALUES (@IdReciboProduccion, @Cliente, @LoteInterno, @NumeroRollo, @LoteCliente, @Presentacion, @Especificacion, @Kgs, @Piezas, @NumeroParte, @Material, @Espesor, @Ancho, @Largo, @FechaRecibo, @IdConseCliente, @NombreCapturista, @NumeroTarima, @ProducidoBlanking)";

            //Consulta insertar datos produccion blanking
            String insertardatosblanking = "insert into ProduccionBlanking(IdProduccionBlanking, Cliente, LoteInterno, FechaProduccion, HoraInicio, HoraFin, NumeroRollo, LoteCliente, Especificacion, Material, KgRollo, Espesor, AnchoRollo, NumeroParte, NumeroTarima, KgTarima, PzsTarima, AnchoBlank, LargoBlank, Observaciones, NombreCapturista, Operador) values (@IdProduccionBlanking, @Cliente, @LoteInterno, @FechaProduccion, @HoraInicio, @HoraFin, @NumeroRollo, @LoteCliente, @Especificacion, @Material, @KgRollo, @Espesor, @AnchoRollo, @NumeroParte, @NumeroTarima, @KgTarima, @PzsTarima, @AnchoBlank, @LargoBlank, @Observaciones, @NombreCapturista, @Operador)";

            //CONSULTA ID RECIBO 
            String ConsultaIdRecibo = "Select IdReciboProduccion From InventarioProduccion where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";

            try
            {
                //Convetir consulta id recibo prod
                SqlCommand com = new SqlCommand(ConsultaIdRecibo, OpenCon);

                if (com.ExecuteScalar() != DBNull.Value)
                    idreciboprod = Convert.ToInt32(com.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ID DE RECIBO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //CONSULTAR MAYOR NUMERO DE TARIMA
            String ConsultaMaxId = "SELECT MAX(NumeroTarima) AS NumeroTarima FROM InventarioProduccion where LoteInterno = '" + cbxloteinterno.SelectedValue + "' and Cliente = '" + cbxcliente.SelectedValue + "'";

            //CONSULTA fecha de recibo
            String ConsultaMatOk = "Select MaterialOK From ReciboProduccion Where IdReciboProduccion = '" + idreciboprod.ToString() + "'";

            //consulta kgs rollo master
            String ConsultaKgsRolloMaster = "Select Kgs From ReciboProduccion Where IdReciboProduccion = '" + idreciboprod.ToString() + "'";

            //Convetir consulta kgs
            SqlCommand com81 = new SqlCommand(ConsultaKgsRolloMaster, OpenCon);

            int KgsRolloMaster = 0;

            if (com81.ExecuteScalar() != DBNull.Value)
                KgsRolloMaster = Convert.ToInt32(com81.ExecuteScalar());
            else
            {
                MessageBox.Show("ERROR AL OBTENER LOS KGS DEL ROLLO MASTER ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Convetir consulta material ok
            SqlCommand com9 = new SqlCommand(ConsultaMatOk, OpenCon);

            int materialok = 0;

            if (com9.ExecuteScalar() != DBNull.Value)
                materialok = Convert.ToInt32(com9.ExecuteScalar());

            int newmaterialok = 0, scrap = 0;

            newmaterialok = Convert.ToInt32(tbxkgstarima.Text) + materialok;

            scrap = KgsRolloMaster - newmaterialok;

            //validar que el scrap no sea negartivo
            if (scrap < 0)
            {
                MessageBox.Show(" ERROR: el scrap no puede ser negativo ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Consulta actualizar scrap
            String actualizarscrap = "Update ReciboProduccion Set ProducidoBlanking = 1, MaterialOK = " + newmaterialok + ", Scrap = " + scrap + " where IdReciboProduccion = '" + idreciboprod.ToString() + "'";

            try
            {
                //CONVERTIR CONSULTA MAYOR ID A INT
                SqlCommand com3 = new SqlCommand(ConsultaMaxId, OpenCon);
                int MAXID = 0;

                if (com3.ExecuteScalar() != DBNull.Value)
                    MAXID = Convert.ToInt32(com3.ExecuteScalar()) + 1;
                else
                    MAXID = 1;

                if (MAXID > Convert.ToInt32(tbxnumtarima.Text))
                {
                    MessageBox.Show(" ERROR: No es posible capturar mas tarimas de las producidas ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Actualizar scrap
                SqlCommand queryactualizarscrap = new SqlCommand(actualizarscrap, OpenCon);
                queryactualizarscrap.ExecuteNonQuery();

                //Mostrar material ok y scrap
                tbxmaterialok.Text = Convert.ToString(newmaterialok);
                tbxscrap.Text = Convert.ToString(scrap);

                //Convetir consulta id consecutivo cliente
                SqlCommand com2 = new SqlCommand(ConsultaIdConseCliente, OpenCon);

                if (com2.ExecuteScalar() != DBNull.Value)
                    idconsecliente = Convert.ToInt32(com2.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL CONSECUTIVO DEL CLIENTE ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta fecha recibo
                SqlCommand com4 = new SqlCommand(ConsultaFechaRecibo, OpenCon);
                var fechaderecibo = DateTime.Now;

                if (com4.ExecuteScalar() != DBNull.Value)
                    fechaderecibo = Convert.ToDateTime(com4.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL CONSECUTIVO DEL CLIENTE ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Insertar datos al inventario de produccion
                SqlCommand consultainsertardatosinventario = new SqlCommand(insertdatosinventario, OpenCon);
                consultainsertardatosinventario.Parameters.Add("@IdReciboProduccion", SqlDbType.Int).Value = idreciboprod;
                consultainsertardatosinventario.Parameters.Add("@Cliente", SqlDbType.VarChar, 50).Value = cbxcliente.Text;
                consultainsertardatosinventario.Parameters.Add("@LoteInterno", SqlDbType.VarChar, 50).Value = cbxloteinterno.Text;
                consultainsertardatosinventario.Parameters.Add("@NumeroRollo", SqlDbType.VarChar, 50).Value = tbxnumrollo.Text;
                consultainsertardatosinventario.Parameters.Add("@LoteCliente", SqlDbType.VarChar, 50).Value = tbxlotecliente.Text;
                consultainsertardatosinventario.Parameters.Add("@Presentacion", SqlDbType.VarChar, 50).Value = "Paquete";
                consultainsertardatosinventario.Parameters.Add("@Especificacion", SqlDbType.VarChar, 50).Value = tbxespecificacion.Text;
                consultainsertardatosinventario.Parameters.Add("@Kgs", SqlDbType.Int).Value = kgstarima;
                consultainsertardatosinventario.Parameters.Add("@Piezas", SqlDbType.Int).Value = pzstarima;
                consultainsertardatosinventario.Parameters.Add("@NumeroParte", SqlDbType.VarChar, 50).Value = tbxnumparte.Text;
                consultainsertardatosinventario.Parameters.Add("@Material", SqlDbType.VarChar, 50).Value = tbxmaterial.Text;
                consultainsertardatosinventario.Parameters.Add("@Espesor", SqlDbType.Float).Value = float.Parse(tbxespesor.Text);
                consultainsertardatosinventario.Parameters.Add("@Ancho", SqlDbType.Int).Value = Convert.ToInt32(tbxanchoblank.Text);
                consultainsertardatosinventario.Parameters.Add("@Largo", SqlDbType.Int).Value = Convert.ToInt32(tbxlargoblank.Text);
                consultainsertardatosinventario.Parameters.Add("@FechaRecibo", SqlDbType.Date).Value = fechaderecibo;
                consultainsertardatosinventario.Parameters.Add("@IdConseCliente", SqlDbType.Int).Value = idconsecliente;
                consultainsertardatosinventario.Parameters.Add("@NombreCapturista", SqlDbType.VarChar, 50).Value = nombrecaptu;
                consultainsertardatosinventario.Parameters.Add("@NumeroTarima", SqlDbType.Int).Value = MAXID;
                consultainsertardatosinventario.Parameters.Add("@ProducidoBlanking", SqlDbType.Bit).Value = true;
                consultainsertardatosinventario.ExecuteNonQuery();

                //Insertar datos a la produccion de blanking
                SqlCommand consultainsertardatosblanking = new SqlCommand(insertardatosblanking, OpenCon);
                consultainsertardatosblanking.Parameters.Add("@IdProduccionBlanking", SqlDbType.Int).Value = idreciboprod;
                consultainsertardatosblanking.Parameters.Add("@Cliente", SqlDbType.VarChar, 50).Value = cbxcliente.Text;
                consultainsertardatosblanking.Parameters.Add("@LoteInterno", SqlDbType.VarChar, 50).Value = cbxloteinterno.Text;
                consultainsertardatosblanking.Parameters.Add("@FechaProduccion", SqlDbType.Date).Value = dateTimePicker1.Value;
                consultainsertardatosblanking.Parameters.Add("@HoraInicio", SqlDbType.DateTime).Value = dateTimePicker2.Value;
                consultainsertardatosblanking.Parameters.Add("@HoraFin", SqlDbType.DateTime).Value = dateTimePicker3.Value;
                consultainsertardatosblanking.Parameters.Add("@NumeroRollo", SqlDbType.VarChar, 50).Value = tbxnumrollo.Text;
                consultainsertardatosblanking.Parameters.Add("@LoteCliente", SqlDbType.VarChar, 50).Value = tbxlotecliente.Text;
                consultainsertardatosblanking.Parameters.Add("@Especificacion", SqlDbType.VarChar, 50).Value = tbxespecificacion.Text;
                consultainsertardatosblanking.Parameters.Add("@Material", SqlDbType.VarChar, 50).Value = tbxmaterial.Text;
                consultainsertardatosblanking.Parameters.Add("@KgRollo", SqlDbType.Int).Value = Convert.ToInt32(tbxkgs.Text);
                consultainsertardatosblanking.Parameters.Add("@Espesor", SqlDbType.Float).Value = float.Parse(tbxespesor.Text);
                consultainsertardatosblanking.Parameters.Add("@AnchoRollo", SqlDbType.Int).Value = Convert.ToInt32(tbxancho.Text);
                consultainsertardatosblanking.Parameters.Add("@NumeroParte", SqlDbType.VarChar, 50).Value = tbxnumparte.Text;
                consultainsertardatosblanking.Parameters.Add("@NumeroTarima", SqlDbType.Int).Value = MAXID;
                consultainsertardatosblanking.Parameters.Add("@KgTarima", SqlDbType.Int).Value = Convert.ToInt32(tbxkgstarima.Text);
                consultainsertardatosblanking.Parameters.Add("@PzsTarima", SqlDbType.Int).Value = Convert.ToInt32(tbxpzstarima.Text);
                consultainsertardatosblanking.Parameters.Add("@AnchoBlank", SqlDbType.Float).Value = float.Parse(tbxanchoblank.Text);
                consultainsertardatosblanking.Parameters.Add("@LargoBlank", SqlDbType.Float).Value = float.Parse(tbxlargoblank.Text);
                consultainsertardatosblanking.Parameters.Add("@Observaciones", SqlDbType.VarChar, 50).Value = tbxobservaciones.Text;
                consultainsertardatosblanking.Parameters.Add("@NombreCapturista", SqlDbType.VarChar, 50).Value = nombrecaptu;
                consultainsertardatosblanking.Parameters.Add("@Operador", SqlDbType.VarChar, 50).Value = tbxoperador.Text;
                consultainsertardatosblanking.ExecuteNonQuery();

                //Formar label lote interno jaguar
                lbjagtarima.Text = cbxloteinterno.Text + " " + Convert.ToString(MAXID+1) + ":";

                //Limpiar valores
                tbxkgstarima.Text = ""; tbxpzstarima.Text = ""; tbxobservaciones.Text = "";

                //Activar bandera 
                bandera = true;

                //MENSAJE DE EXITO :D
                MessageBox.Show("Tarima capturada correctamente", "GAURDADO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            if (tbxnumtarima.Text == "")
                return;

            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar la produccion del rollo?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
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

                //Consulta borrar datos del inventario almacen
                String borrardatosinventario = "Delete From InventarioProduccion where LoteInterno = '" + cbxloteinterno.Text + "' and NumeroTarima is NULL";

                try
                {
                    //Borrar datos del inventario de produccion
                    SqlCommand consultaborrardatosinventario = new SqlCommand(borrardatosinventario, OpenCon);
                    consultaborrardatosinventario.ExecuteNonQuery();

                    //MENSAJE DE EXITO :D
                    MessageBox.Show("Produccion finalizada correctamente ", "FINALIZADO ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Habilitar controles
                cbxcliente.Enabled = true;
                cbxloteinterno.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
                tbxnumtarima.ReadOnly = false;

                //deshabilitar bandera
                bandera = false;

                //Limpiar valores
                tbxkgstarima.Text = ""; tbxpzstarima.Text = ""; tbxobservaciones.Text = ""; tbxoperador.Text = ""; tbxscrap.Text = ""; tbxmaterialok.Text = ""; tbxnumtarima.Text = "";

                OpenCon.Close();

                //cargar cbx lote interno y las caracteristicas 
                cargarcbxloteinterno();
                cargarcaracteristicas(); 
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btnscrap_Click(object sender, EventArgs e)
        {
            VerScrap verscrap = new VerScrap();
            verscrap.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbxnumtarima.Text == "")
                return;

            DialogResult dialogResult = MessageBox.Show("¿Desea cancelar la produccion del rollo?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
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

                //Inicializar variable idrecibo
                int idreciboprod = 0;

                //Consulta borrar datos del inventario almacen
                String borrardatosinventario = "Delete From InventarioProduccion where LoteInterno = '" + cbxloteinterno.Text + "' and NumeroTarima is NOT NULL";

                //Consulta borrar datos de probuccion blanking
                String borrardatosprodblanking = "Delete From ProduccionBlanking where LoteInterno = '" + cbxloteinterno.Text + "'";

                //CONSULTA ID RECIBO 
                String ConsultaIdRecibo = "Select IdReciboProduccion From InventarioProduccion where LoteInterno = '" + cbxloteinterno.SelectedValue + "'";


                //Convetir consulta id recibo prod
                SqlCommand com = new SqlCommand(ConsultaIdRecibo, OpenCon);

                if (com.ExecuteScalar() != DBNull.Value)
                    idreciboprod = Convert.ToInt32(com.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ID DE RECIBO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Consulta actualizar scrap
                String actualizarscrap = "Update ReciboProduccion Set ProducidoBlanking = 0, MaterialOK = 0, Scrap = 0 where IdReciboProduccion = '" + idreciboprod.ToString() + "'";

                try
                {
                    //Actualizar scrap
                    SqlCommand queryactualizarscrap = new SqlCommand(actualizarscrap, OpenCon);
                    queryactualizarscrap.ExecuteNonQuery();

                    //Borrar datos del inventario de produccion
                    SqlCommand consultaborrardatosinventario = new SqlCommand(borrardatosinventario, OpenCon);
                    consultaborrardatosinventario.ExecuteNonQuery();

                    //Borrar datos de produccion blanking
                    SqlCommand consultaborrardatosprodblanking = new SqlCommand(borrardatosprodblanking, OpenCon);
                    consultaborrardatosprodblanking.ExecuteNonQuery();

                    //MENSAJE DE EXITO :D
                    MessageBox.Show("Produccion cancelada correctamente ", "FINALIZADO ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Habilitar controles
                cbxcliente.Enabled = true;
                cbxloteinterno.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
                tbxnumtarima.ReadOnly = false;

                //deshabilitar bandera
                bandera = false;

                //Limpiar valores
                tbxkgstarima.Text = ""; tbxpzstarima.Text = ""; tbxobservaciones.Text = ""; tbxoperador.Text = ""; tbxscrap.Text = ""; tbxmaterialok.Text = ""; tbxnumtarima.Text = "";

                OpenCon.Close();

                //cargar cbx lote interno y las caracteristicas 
                cargarcbxloteinterno();
                cargarcaracteristicas();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
