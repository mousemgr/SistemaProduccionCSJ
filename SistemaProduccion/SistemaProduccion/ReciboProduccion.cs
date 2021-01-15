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
    public partial class ReciboProduccion : Form
    {
        public ReciboProduccion()
        {
            InitializeComponent();
            cargarcbxcliente();
            cargarnumparte();
            cargarcaracteristicas();

            //LOTE INTERNO DEPENDIENDO DEL CLIENTE
            tbxloteinterno.Text = formarloteinterno();

            //Inicializar combo box de Presentacion
            cbxpresentacion.SelectedIndex = 0;

            //Cantidad de piezas
            tbxpiezas.Text = "1";
        }

        private void cancelarbtn_Click(object sender, EventArgs e)
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

        public void cargarnumparte()
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
                string query = "select NumParte from NumeroParte where Cliente = '"+ cbxcliente.Text +"' order by NumParte";
                SqlDataAdapter da = new SqlDataAdapter(query, OpenCon);
                DataSet ds = new DataSet();
                da.Fill(ds, "NumeroParte");
                cbxnumparte.DisplayMember = "NumParte";
                cbxnumparte.ValueMember = "NumParte";
                cbxnumparte.DataSource = ds.Tables["NumeroParte"];
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

            //CONSULTAS DE LAS CARACTERISTICAS DEL NUMERO DE PARTE
            String ConsultaMaterial = "Select Material From NumeroParte Where NumParte = '" + cbxnumparte.Text + "'";
            String ConsultaEspesor = "Select Espesor From NumeroParte Where NumParte = '" + cbxnumparte.Text + "'";
            String ConsultaAncho = "Select AnchoRollo From NumeroParte Where NumParte = '" + cbxnumparte.Text + "'";

            try
            {
                //Convetir consulta material
                SqlCommand com = new SqlCommand(ConsultaMaterial, OpenCon);

                if (com.ExecuteScalar() != DBNull.Value)
                    tbxmaterial.Text = Convert.ToString(com.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL TIPO DE MATERIAL ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta espesor
                SqlCommand com2 = new SqlCommand(ConsultaEspesor, OpenCon);

                if (com2.ExecuteScalar() != DBNull.Value)
                    tbxespesor.Text = Convert.ToString(com2.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ESPESOR ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Convetir consulta ancho
                SqlCommand com3 = new SqlCommand(ConsultaAncho, OpenCon);

                if (com3.ExecuteScalar() != DBNull.Value)
                   tbxancho.Text = Convert.ToString(com3.ExecuteScalar());
                else
                {
                    MessageBox.Show("ERROR AL OBTENER EL ANCHO ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            OpenCon.Close();
        }

        public string formarloteinterno()
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
            String consultaconsecliente = "SELECT MAX(IdConseCliente) AS IdConseCliente FROM ReciboProduccion WHERE Cliente = '" + cbxcliente.SelectedValue + "'";

            //CONSULTA OBTENER CLAVE DEL CLIENTE SELECCIONADO
            String consultaclave = "select ClaveCliente from ClientesProduccion where NombreCliente ='" + cbxcliente.SelectedValue + "'";

            //Obtener ultimos dos numeros del año actual
            String sDate = DateTime.Now.ToString();
            DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));
            String yy = datevalue.Year.ToString();
            int startIndex = 2, length = 2;
            String substring = yy.Substring(startIndex, length);

            //--------------------------------------
            int MAXCONSE = 0;
            string clavecliente = "";


            try
            {
                //OBTENER CLAVE DEL CLIENTE
                SqlCommand com2 = new SqlCommand(consultaclave, OpenCon);

                if (com2.ExecuteScalar() != DBNull.Value)
                    clavecliente = Convert.ToString(com2.ExecuteScalar());
                else
                    MessageBox.Show("ERROR AL OBTENER LA CLAVE DEL CLIENTE");

                //CONVERTIR CONSULTA MAYOR CONSECUTIVO DEL CLIENTE A INT
                SqlCommand com3 = new SqlCommand(consultaconsecliente, OpenCon);

                if (com3.ExecuteScalar() != DBNull.Value)
                    MAXCONSE = Convert.ToInt32(com3.ExecuteScalar()) + 1;
                else
                    MAXCONSE = 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string LoteInterno = "";

            if (MAXCONSE < 10 && MAXCONSE >= 1)
                LoteInterno = "JAG" + substring + "-" + clavecliente + "000" + MAXCONSE.ToString();

            if (MAXCONSE < 100 && MAXCONSE >= 10)
                LoteInterno = "JAG" + substring + "-" + clavecliente + "00" + MAXCONSE.ToString();

            if (MAXCONSE < 1000 && MAXCONSE >= 100)
                LoteInterno = "JAG" + substring + "-" + clavecliente + "0" + MAXCONSE.ToString();

            if (MAXCONSE < 10000 && MAXCONSE >= 1000)
                LoteInterno = "JAG" + substring + "-" + clavecliente + "" + MAXCONSE.ToString();

            OpenCon.Close();

            return LoteInterno;
        }

        private void cbxcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LOTE INTERNO DEPENDIENDO DEL CLIENTE
            tbxloteinterno.Text = formarloteinterno();

            cargarnumparte();
            cargarcaracteristicas();
        }

        private void cbxnumparte_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarcaracteristicas();
        }

        private void cbxpresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxpresentacion.Text == "Blanks")
            {
                tbxpiezas.ReadOnly = false;
                tbxlargo.ReadOnly = false;
            }
            else
            {
                tbxpiezas.ReadOnly = true;
                tbxlargo.ReadOnly = true;

                tbxpiezas.Text = "1";
                tbxlargo.Text = "";
            }
        }

        private void bntverrecibo_Click(object sender, EventArgs e)
        {
            VerRecibo verrecibo = new VerRecibo();
            verrecibo.ShowDialog();
        }

        private void btnreporte_Click(object sender, EventArgs e)
        {
            ReporteProduccion reporteproduccion = new ReporteProduccion();
            reporteproduccion.ShowDialog();
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            #region validar datos
            int kgs = 0, pzs = 0, ancho = 0, largo = 0;
            float espesor = 0;

            if (tbxkgs.Text != "")
                kgs = int.Parse(tbxkgs.Text);

            if (tbxpiezas.Text != "")
                pzs = int.Parse(tbxpiezas.Text);

            if (tbxancho.Text != "")
                ancho = int.Parse(tbxancho.Text);

            if (tbxlargo.Text != "")
                largo = int.Parse(tbxlargo.Text);

            if (tbxespesor.Text != "")
                espesor = float.Parse(tbxespesor.Text);

            if (tbxloteinterno.Text == "")
            {
                MessageBox.Show("Favor de ingresar el lote interno ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxnumrollo.Text == "")
            {
                MessageBox.Show("Favor de ingresar el numero del rollo ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxlotecliente.Text == "")
            {
                MessageBox.Show("Favor de ingresar el lote del cliente ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxespecificacion.Text == "")
            {
                MessageBox.Show("Favor de ingresar la especificacion ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxespecificacion.Text == "")
            {
                MessageBox.Show("Favor de ingresar la especificacion ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbxkgs.Text == "")
            {
                MessageBox.Show("Favor de ingresar los kilogramos ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #endregion

            string nombrecaptu = login.VariableSecion;

            SqlConnection OpenCon = new SqlConnection(@"Data Source=WIN-SERVER\JAGUARIRA;Initial Catalog=SistemaProduccion;Persist Security Info=True;User ID=sa;Password=Jaguar1");

            try
            {
                OpenCon.Open();
            }

            catch (Exception ex)
            {
                MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //CONSULTAR MAYOR ID
            String ConsultaMaxId = "SELECT MAX(IdReciboProduccion) AS IdReciboProduccion FROM ReciboProduccion";

            //CONSULTAR MAYOR CONSECUTIVO DEPENDIENDO DEL CLIENTE
            String consultaconsecliente = "SELECT MAX(IdConseCliente) AS IdConseCliente FROM ReciboProduccion WHERE Cliente = '" + cbxcliente.SelectedValue + "'";

            //Consulta insertar datos recibo produccion
            String insertardatos = "insert into ReciboProduccion (IdReciboProduccion, Cliente, LoteInterno, NumeroRollo, LoteCliente, Presentacion, Especificacion, Kgs, Piezas, NumeroParte, Material, Espesor, Ancho, Largo, FechaRecibo, IdConseCliente, NombreCapturista, ProducidoBlanking, ProducidoSlitter) VALUES (@IdReciboProduccion, @Cliente, @LoteInterno, @NumeroRollo, @LoteCliente, @Presentacion, @Especificacion, @Kgs, @Piezas, @NumeroParte, @Material, @Espesor, @Ancho, @Largo, @FechaRecibo, @IdConseCliente, @NombreCapturista, @ProducidoBlanking, @ProducidoSlitter)";

            //Consulta insertar datos inventario produccion
            String insertdatosinventario = "insert into InventarioProduccion (IdReciboProduccion, Cliente, LoteInterno, NumeroRollo, LoteCliente, Presentacion, Especificacion, Kgs, Piezas, NumeroParte, Material, Espesor, Ancho, Largo, FechaRecibo, IdConseCliente, NombreCapturista, ProducidoBlanking, ProducidoSlitter) VALUES (@IdReciboProduccion, @Cliente, @LoteInterno, @NumeroRollo, @LoteCliente, @Presentacion, @Especificacion, @Kgs, @Piezas, @NumeroParte, @Material, @Espesor, @Ancho, @Largo, @FechaRecibo, @IdConseCliente, @NombreCapturista, @ProducidoBlanking, @ProducidoSlitter)";

            try
            {
                //CONVERTIR CONSULTA MAYOR ID A INT
                SqlCommand com = new SqlCommand(ConsultaMaxId, OpenCon);
                int MAXID = 0;

                if (com.ExecuteScalar() != DBNull.Value)
                    MAXID = Convert.ToInt32(com.ExecuteScalar()) + 1;
                else
                    MAXID = 1;

                //CONVERTIR CONSULTA MAYOR CONSECUTIVO DEL CLIENTE A INT
                SqlCommand com3 = new SqlCommand(consultaconsecliente, OpenCon);
                int MAXCONSE = 0;

                if (com3.ExecuteScalar() != DBNull.Value)
                    MAXCONSE = Convert.ToInt32(com3.ExecuteScalar()) + 1;
                else
                    MAXCONSE = 1;

                //Insertar datos de recibo de material
                SqlCommand consultainsertardatos = new SqlCommand(insertardatos, OpenCon);
                consultainsertardatos.Parameters.Add("@IdReciboProduccion", SqlDbType.Int).Value = MAXID;
                consultainsertardatos.Parameters.Add("@Cliente", SqlDbType.VarChar, 50).Value = cbxcliente.Text;
                consultainsertardatos.Parameters.Add("@LoteInterno", SqlDbType.VarChar, 50).Value = tbxloteinterno.Text;
                consultainsertardatos.Parameters.Add("@NumeroRollo", SqlDbType.VarChar, 50).Value = tbxnumrollo.Text;
                consultainsertardatos.Parameters.Add("@LoteCliente", SqlDbType.VarChar, 50).Value = tbxlotecliente.Text;
                consultainsertardatos.Parameters.Add("@Presentacion", SqlDbType.VarChar, 50).Value = cbxpresentacion.Text;
                consultainsertardatos.Parameters.Add("@Especificacion", SqlDbType.VarChar, 50).Value = tbxespecificacion.Text;
                consultainsertardatos.Parameters.Add("@Kgs", SqlDbType.Int).Value = kgs;
                consultainsertardatos.Parameters.Add("@Piezas", SqlDbType.Int).Value = pzs;
                consultainsertardatos.Parameters.Add("@NumeroParte", SqlDbType.VarChar, 50).Value = cbxnumparte.Text;
                consultainsertardatos.Parameters.Add("@Material", SqlDbType.VarChar, 50).Value = tbxmaterial.Text;
                consultainsertardatos.Parameters.Add("@Espesor", SqlDbType.Float).Value = espesor;
                consultainsertardatos.Parameters.Add("@Ancho", SqlDbType.Int).Value = ancho;
                consultainsertardatos.Parameters.Add("@Largo", SqlDbType.Int).Value = largo;
                consultainsertardatos.Parameters.Add("@FechaRecibo", SqlDbType.Date).Value = dateTimePicker1.Value;
                consultainsertardatos.Parameters.Add("@IdConseCliente", SqlDbType.Int).Value = MAXCONSE;
                consultainsertardatos.Parameters.Add("@NombreCapturista", SqlDbType.VarChar, 50).Value = nombrecaptu;
                consultainsertardatos.Parameters.Add("@ProducidoBlanking", SqlDbType.Bit).Value = false;
                consultainsertardatos.Parameters.Add("@ProducidoSlitter", SqlDbType.Bit).Value = false;
                consultainsertardatos.ExecuteNonQuery();

                //Insertar datos al inventario del almacen
                SqlCommand consultainsertardatosinventario = new SqlCommand(insertdatosinventario, OpenCon);
                consultainsertardatosinventario.Parameters.Add("@IdReciboProduccion", SqlDbType.Int).Value = MAXID;
                consultainsertardatosinventario.Parameters.Add("@Cliente", SqlDbType.VarChar, 50).Value = cbxcliente.Text;
                consultainsertardatosinventario.Parameters.Add("@LoteInterno", SqlDbType.VarChar, 50).Value = tbxloteinterno.Text;
                consultainsertardatosinventario.Parameters.Add("@NumeroRollo", SqlDbType.VarChar, 50).Value = tbxnumrollo.Text;
                consultainsertardatosinventario.Parameters.Add("@LoteCliente", SqlDbType.VarChar, 50).Value = tbxlotecliente.Text;
                consultainsertardatosinventario.Parameters.Add("@Presentacion", SqlDbType.VarChar, 50).Value = cbxpresentacion.Text;
                consultainsertardatosinventario.Parameters.Add("@Especificacion", SqlDbType.VarChar, 50).Value = tbxespecificacion.Text;
                consultainsertardatosinventario.Parameters.Add("@Kgs", SqlDbType.Int).Value = kgs;
                consultainsertardatosinventario.Parameters.Add("@Piezas", SqlDbType.Int).Value = pzs;
                consultainsertardatosinventario.Parameters.Add("@NumeroParte", SqlDbType.VarChar, 50).Value = cbxnumparte.Text;
                consultainsertardatosinventario.Parameters.Add("@Material", SqlDbType.VarChar, 50).Value = tbxmaterial.Text;
                consultainsertardatosinventario.Parameters.Add("@Espesor", SqlDbType.Float).Value = espesor;
                consultainsertardatosinventario.Parameters.Add("@Ancho", SqlDbType.Int).Value = ancho;
                consultainsertardatosinventario.Parameters.Add("@Largo", SqlDbType.Int).Value = largo;
                consultainsertardatosinventario.Parameters.Add("@FechaRecibo", SqlDbType.Date).Value = dateTimePicker1.Value;
                consultainsertardatosinventario.Parameters.Add("@IdConseCliente", SqlDbType.Int).Value = MAXCONSE;
                consultainsertardatosinventario.Parameters.Add("@NombreCapturista", SqlDbType.VarChar, 50).Value = nombrecaptu;
                consultainsertardatosinventario.Parameters.Add("@ProducidoBlanking", SqlDbType.Bit).Value = false;
                consultainsertardatosinventario.Parameters.Add("@ProducidoSlitter", SqlDbType.Bit).Value = false;
                consultainsertardatosinventario.ExecuteNonQuery();

                //LIMPIAR VALORES
                tbxnumrollo.Text = ""; tbxlotecliente.Text = ""; tbxespecificacion.Text = ""; tbxkgs.Text = "";

                //MENSAJE DE EXITO :D
                MessageBox.Show("Recibo capturado correctamente", "GAURDADO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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

            //LOTE INTERNO DEPENDIENDO DEL CLIENTE
            tbxloteinterno.Text = formarloteinterno();
        }

        private void tbxkgs_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
