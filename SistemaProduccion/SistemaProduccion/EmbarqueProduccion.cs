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
    public partial class EmbarqueProduccion : Form
    {
        public EmbarqueProduccion()
        {
            InitializeComponent();
            cargarcbxcliente();
            llenardatagridinven();
            llenardatagridembar();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            //validar que se alla generado remision antes de finalizar el embarque
            if (bandera2 == true)
            {
                MessageBox.Show("No se puede salir sin finalizar el embarque ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                this.Close();
            }
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

        private void btnverembarques_Click(object sender, EventArgs e)
        {
            VerEmbarques verembarques = new VerEmbarques();
            verembarques.ShowDialog();
        }

        private void btnremision_Click(object sender, EventArgs e)
        {
            RemisionProduccion remisionproduccion = new RemisionProduccion();
            remisionproduccion.ShowDialog();

            //Inicializar vandera a true

            bandera = true;
        }

        public void llenardatagridinven()
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

            if (lotedelclientetbx.Text == "")
            {
                try
                {
                    var select = "SELECT LoteInterno, NumeroTarima, NumeroRollo, NumeroParte, Piezas, Kgs FROM InventarioProduccion where Cliente = '" + cbxcliente.SelectedValue + "' ORDER BY LoteInterno";
                    var dataAdapter = new SqlDataAdapter(select, OpenCon);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];

                    //alternar color de las filas
                    dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PeachPuff;

                    #region IndiceColums

                    //indice de las columnas
                    dataGridView1.Columns[0].HeaderCell.Value = "Lote Interno";
                    dataGridView1.Columns[1].HeaderCell.Value = "Tarima";
                    dataGridView1.Columns[2].HeaderCell.Value = "Numero de Rollo";
                    dataGridView1.Columns[3].HeaderCell.Value = "Numero de Parte";
                    dataGridView1.Columns[4].HeaderCell.Value = "Piezas";
                    dataGridView1.Columns[5].HeaderCell.Value = "Kilogramos";

                    #endregion

                    //Extender y adaptar datagridview
                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    var select = "SELECT LoteInterno, NumeroTarima, NumeroRollo, NumeroParte, Piezas, Kgs FROM InventarioProduccion where Cliente ='" + cbxcliente.SelectedValue + "' and NumeroRollo = '" + lotedelclientetbx.Text + "' or LoteInterno = '" + lotedelclientetbx.Text + "' ORDER BY LoteInterno";
                    var dataAdapter = new SqlDataAdapter(select, OpenCon);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];

                    //alternar color de las filas
                    dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PeachPuff;

                    #region IndiceColums

                    dataGridView1.Columns[0].HeaderCell.Value = "Lote Interno";
                    dataGridView1.Columns[1].HeaderCell.Value = "Tarima";
                    dataGridView1.Columns[2].HeaderCell.Value = "Numero de Rollo";
                    dataGridView1.Columns[3].HeaderCell.Value = "Numero de Parte";
                    dataGridView1.Columns[4].HeaderCell.Value = "Piezas";
                    dataGridView1.Columns[5].HeaderCell.Value = "Kilogramos";

                    #endregion

                    //Extender y adaptar datagridview
                    //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Limpiar textbox lote jag 
            lotejagtbx.Text = "";

            OpenCon.Close();
        }

        public void llenardatagridembar()
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
                var select = "SELECT LoteInterno, NumeroTarima, NumeroRollo, LoteCliente, NumeroParte, Espesor, Ancho, Largo, Piezas, Kgs FROM EmbarqueProduccion where Cliente = '" + cbxcliente.SelectedValue + "' and Remision = 'JAG-R" + numremisiontbx.Text + "' ORDER BY LoteInterno";
                var dataAdapter = new SqlDataAdapter(select, OpenCon);

                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView2.ReadOnly = true;
                dataGridView2.DataSource = ds.Tables[0];

                //alternar color de las filas
                dataGridView2.RowsDefaultCellStyle.BackColor = Color.White;
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.PeachPuff;

                #region IndiceColums

                //indice de las columnas
                dataGridView2.Columns[0].HeaderCell.Value = "Lote Interno";
                dataGridView2.Columns[1].HeaderCell.Value = "Tarima";
                dataGridView2.Columns[2].HeaderCell.Value = "Numero de Rollo";
                dataGridView2.Columns[3].HeaderCell.Value = "Lote del Cliente";
                dataGridView2.Columns[4].HeaderCell.Value = "Numero de Parte";
                dataGridView2.Columns[5].HeaderCell.Value = "Espesor";
                dataGridView2.Columns[6].HeaderCell.Value = "Ancho";
                dataGridView2.Columns[7].HeaderCell.Value = "Largo";
                dataGridView2.Columns[8].HeaderCell.Value = "Piezas";
                dataGridView2.Columns[9].HeaderCell.Value = "Kgs";

                #endregion

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
            llenardatagridinven();
            llenardatagridembar();
        }

        private void lotedelclientetbx_KeyUp(object sender, KeyEventArgs e)
        {
            llenardatagridinven();
        }

        private void numremisiontbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que el textbox solo permita numeros enteros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public bool bandera = false, bandera2 = false;

        public static string NumRemision = "";

        public static string NombreTransportista = "";

        public static string Destino = "";

        public static string ClienteRem = "";

        public static string FechaRem = "";

        public static string NoEconom = "";

        public static string LineaTrans = "";

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = 0;
                i = dataGridView1.CurrentRow.Index;
                lotejagtbx.Text = dataGridView1[0, i].Value.ToString();
                tbxtarimainven.Text = dataGridView1[1, i].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el rollo, favor de seleccionar un rollo " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //LIMPIAR TEXTBOX
                lotejagtbx.Text = "";
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = 0;
                i = dataGridView2.CurrentRow.Index;
                lotejagregresotbx.Text = dataGridView2[0, i].Value.ToString();
                tbxtarimaembar.Text = dataGridView2[1, i].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el rollo, favor de seleccionar un rollo " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //LIMPIAR TEXTBOX
                lotejagregresotbx.Text = "";
            }
        }

        private void btnfinalizar_Click(object sender, EventArgs e)
        {
            //validar que se alla generado remision antes de finalizar el embarque
            if (bandera == false)
            {
                MessageBox.Show("No se puede finalizar el embarque sin haber generado antes la remision  ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Bandera 2
            bandera2 = false;

            DialogResult dialogResult = MessageBox.Show("¿Desea finalizar el embarque?", "SALIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                //Abilitar textbox numremision, combobox cliente y datetimepicker
                numremisiontbx.ReadOnly = false;
                cbxcliente.Enabled = true;
                dateTimePicker1.Enabled = true;
                TbxDestino.ReadOnly = false;
                TxbTrannsportista.ReadOnly = false;
                tbxnoeconom.ReadOnly = false;
                tbxlineatrans.ReadOnly = false;

                //Limpiar valor del combobox cliente
                ClienteRem = "";

                //Limpiar valor del datetime
                FechaRem = "";

                //Limpiar textbox numremision
                numremisiontbx.Text = "";
                NumRemision = "";

                //Limpiar textbox destino
                TbxDestino.Text = "";
                Destino = "";

                //Limpiar textbox transportita
                TxbTrannsportista.Text = "";
                tbxlineatrans.Text = "";
                tbxnoeconom.Text = "";
                NombreTransportista = "";

                //limpiar datagrid de embarque
                llenardatagridembar();

                //volver a inicializar la bandera
                bandera = false;
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void cargarrollobtn_Click(object sender, EventArgs e)
        {
            #region validardatos

            if (numremisiontbx.Text == "")
            {
                MessageBox.Show("Favor de ingresar el numero de la remision ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lotejagtbx.Text == "")
            {
                MessageBox.Show("Favor de seleccionar una tarima para embarcar ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TxbTrannsportista.Text == "")
            {
                MessageBox.Show("Favor de ingresar los datos del transportista ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TbxDestino.Text == "")
            {
                MessageBox.Show("Favor de ingresar el destino del embarque ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            numremisiontbx.ReadOnly = true;
            cbxcliente.Enabled = false;
            dateTimePicker1.Enabled = false;
            TbxDestino.ReadOnly = true;
            TxbTrannsportista.ReadOnly = true;
            tbxlineatrans.ReadOnly = true;
            tbxnoeconom.ReadOnly = true;

            //////////////////

            Destino = TbxDestino.Text;
            NumRemision = numremisiontbx.Text;
            NombreTransportista = tbxlineatrans.Text;
            ClienteRem = cbxcliente.Text;
            FechaRem = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            LineaTrans = TxbTrannsportista.Text;
            NoEconom = tbxnoeconom.Text;

            //////////////////

            string nombrecaptu = login.VariableSecion;

            //bandera 2
            bandera2 = true;

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

            try
            {
                if (tbxtarimainven.Text != "")
                {
                    //Consulta insertar datos recibo almacen
                    String insertardatosembarque = "insert into EmbarqueProduccion(IdReciboProduccion, NumeroRollo, LoteCliente, Especificacion, Material, LoteInterno, NumeroTarima, Kgs, Piezas, Espesor, Ancho, Largo, NumeroParte, Cliente, FechaRecibo, IdConseCliente, Presentacion, ProducidoBlanking) Select IdReciboProduccion, NumeroRollo, LoteCliente, Especificacion, Material, LoteInterno, NumeroTarima, Kgs, Piezas, Espesor, Ancho, Largo, NumeroParte, Cliente, FechaRecibo, IdConseCliente, Presentacion, ProducidoBlanking From InventarioProduccion where LoteInterno = '" + lotejagtbx.Text + "' and NumeroTarima = " + Convert.ToInt32(tbxtarimainven.Text);
                    
                    //Insertar datos de recibo de material
                    SqlCommand consultainsertdatosembarque = new SqlCommand(insertardatosembarque, OpenCon);
                    consultainsertdatosembarque.ExecuteNonQuery();
                }
                else
                {
                    //Consulta insertar datos recibo almacen
                    String insertardatosembarque = "insert into EmbarqueProduccion(IdReciboProduccion, NumeroRollo, LoteCliente, Especificacion, Material, LoteInterno, NumeroTarima, Kgs, Piezas, Espesor, Ancho, Largo, NumeroParte, Cliente, FechaRecibo, IdConseCliente, Presentacion, ProducidoBlanking) Select IdReciboProduccion, NumeroRollo, LoteCliente, Especificacion, Material, LoteInterno, NumeroTarima, Kgs, Piezas, Espesor, Ancho, Largo, NumeroParte, Cliente, FechaRecibo, IdConseCliente, Presentacion, ProducidoBlanking From InventarioProduccion where LoteInterno = '" + lotejagtbx.Text + "' and NumeroTarima is NULL";
                    
                    //Insertar datos de recibo de material
                    SqlCommand consultainsertdatosembarque = new SqlCommand(insertardatosembarque, OpenCon);
                    consultainsertdatosembarque.ExecuteNonQuery();
                }

                if(tbxtarimainven.Text != "")
                {
                    //Consulta borrar datos del inventario almacen
                    String borrardatosinventario = "Delete From InventarioProduccion where LoteInterno = '" + lotejagtbx.Text + "' and NumeroTarima = " + Convert.ToInt32(tbxtarimainven.Text);

                    //Borrar datos del inventario del almacen
                    SqlCommand consultaborrardatosinventario = new SqlCommand(borrardatosinventario, OpenCon);
                    consultaborrardatosinventario.ExecuteNonQuery();
                }
                else
                {
                    //Consulta borrar datos del inventario almacen
                    String borrardatosinventario = "Delete From InventarioProduccion where LoteInterno = '" + lotejagtbx.Text + "' and NumeroTarima is NULL";

                    //Borrar datos del inventario del almacen
                    SqlCommand consultaborrardatosinventario = new SqlCommand(borrardatosinventario, OpenCon);
                    consultaborrardatosinventario.ExecuteNonQuery();
                }

                //Consulta actualizar embarque con el num de remision y fecha de embarque
                if (tbxtarimainven.Text != "")
                {
                    String actualizarembarque = "Update EmbarqueProduccion Set Origen = '" + origentbx.Text + "', Remision = 'JAG-R" + NumRemision + "', Transportista = '" + TxbTrannsportista.Text + "', Capturista = '" + nombrecaptu + "', Destino = '" + TbxDestino.Text + "', FechaEmbarque = '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' where LoteInterno = '" + lotejagtbx.Text + "' and NumeroTarima = " + Convert.ToInt32(tbxtarimainven.Text);
                    
                    //Actualizar datos del inventario
                    SqlCommand consultaactualizarinventario = new SqlCommand(actualizarembarque, OpenCon);
                    consultaactualizarinventario.ExecuteNonQuery();
                }
                else
                {
                    String actualizarembarque = "Update EmbarqueProduccion Set Origen = '" + origentbx.Text + "', Remision = 'JAG-R" + NumRemision + "', Transportista = '" + TxbTrannsportista.Text + "', Capturista = '" + nombrecaptu + "', Destino = '" + TbxDestino.Text + "', FechaEmbarque = '" + dateTimePicker1.Value.ToString("dd/MM/yyyy") + "' where LoteInterno = '" + lotejagtbx.Text + "' and NumeroTarima is NULL";
                    //Actualizar datos del inventario
                    SqlCommand consultaactualizarinventario = new SqlCommand(actualizarembarque, OpenCon);
                    consultaactualizarinventario.ExecuteNonQuery();
                }

                //Llenar datagrids
                llenardatagridembar();
                llenardatagridinven();

                //Limpiar textbox lotejagtbx

                lotejagtbx.Text = "";
                tbxtarimainven.Text = "";

                //MENSAJE DE EXITO :D
                MessageBox.Show("Rollo movido a embarque correctamente", "Movido con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void regresarrollobtn_Click(object sender, EventArgs e)
        {
            #region validardatos

            if (numremisiontbx.Text == "")
            {
                MessageBox.Show("Favor de ingresar el numero de la remision ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lotejagregresotbx.Text == "")
            {
                MessageBox.Show("Favor de seleccionar una tarima para regresar al inventario ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            numremisiontbx.ReadOnly = true;
            cbxcliente.Enabled = false;
            dateTimePicker1.Enabled = false;

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

            try
            {
                if(tbxtarimaembar.Text != "")
                {
                    //Consulta insertar datos recibo almacen
                    String insertardatosinventario = "insert into InventarioProduccion (IdReciboProduccion, NumeroRollo, LoteCliente, Especificacion, Material, LoteInterno, NumeroTarima, Kgs, Piezas, Espesor, Ancho, Largo, NumeroParte, Cliente, FechaRecibo, IdConseCliente, Presentacion, ProducidoBlanking) Select IdReciboProduccion, NumeroRollo, LoteCliente, Especificacion, Material, LoteInterno, NumeroTarima, Kgs, Piezas, Espesor, Ancho, Largo, NumeroParte, Cliente, FechaRecibo, IdConseCliente, Presentacion, ProducidoBlanking From EmbarqueProduccion where LoteInterno = '" + lotejagregresotbx.Text + "' and NumeroTarima = " + Convert.ToInt32(tbxtarimaembar.Text);

                    //Insertar datos de recibo de material
                    SqlCommand consultainsertdatosembarque = new SqlCommand(insertardatosinventario, OpenCon);
                    consultainsertdatosembarque.ExecuteNonQuery();
                }
                else
                {
                    //Consulta insertar datos recibo almacen
                    String insertardatosinventario = "insert into InventarioProduccion (IdReciboProduccion, NumeroRollo, LoteCliente, Especificacion, Material, LoteInterno, NumeroTarima, Kgs, Piezas, Espesor, Ancho, Largo, NumeroParte, Cliente, FechaRecibo, IdConseCliente, Presentacion, ProducidoBlanking) Select IdReciboProduccion, NumeroRollo, LoteCliente, Especificacion, Material, LoteInterno, NumeroTarima, Kgs, Piezas, Espesor, Ancho, Largo, NumeroParte, Cliente, FechaRecibo, IdConseCliente, Presentacion, ProducidoBlanking From EmbarqueProduccion where LoteInterno = '" + lotejagregresotbx.Text + "' and NumeroTarima is NULL";

                    //Insertar datos de recibo de material
                    SqlCommand consultainsertdatosembarque = new SqlCommand(insertardatosinventario, OpenCon);
                    consultainsertdatosembarque.ExecuteNonQuery();
                }

                if(tbxtarimaembar.Text != "")
                {
                    //Consulta borrar datos del inventario almacen
                    String borrardatosembarque = "Delete From EmbarqueProduccion where LoteInterno = '" + lotejagregresotbx.Text + "' and NumeroTarima = " + Convert.ToInt32(tbxtarimaembar.Text);

                    //Borrar datos del inventario del almacen
                    SqlCommand consultaborrardatosinventario = new SqlCommand(borrardatosembarque, OpenCon);
                    consultaborrardatosinventario.ExecuteNonQuery();
                }
                else
                {
                    //Consulta borrar datos del inventario almacen
                    String borrardatosembarque = "Delete From EmbarqueProduccion where LoteInterno = '" + lotejagregresotbx.Text + "' and NumeroTarima is NULL";

                    //Borrar datos del inventario del almacen
                    SqlCommand consultaborrardatosinventario = new SqlCommand(borrardatosembarque, OpenCon);
                    consultaborrardatosinventario.ExecuteNonQuery();
                }

                //Llenar datagrids
                llenardatagridembar();
                llenardatagridinven();

                //Limpiar textbox lotejagregresotbx
                lotejagregresotbx.Text = "";
                tbxtarimaembar.Text = "";

                //MENSAJE DE EXITO :D
                MessageBox.Show("Tarima regresada a inventario correctamente", "Movido con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
    }
}
