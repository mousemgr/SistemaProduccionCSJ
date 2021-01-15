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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        public static string VariableSecion = "";

        private void cacelarbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void entrar_Click(object sender, EventArgs e)
        {
            if (usuariotxbx.Text == "")
            {
                MessageBox.Show("ERROR: USUARIO O CONTRASEÑA INCORRECTA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (contraseñatxtbx.Text == "")
            {
                MessageBox.Show("ERROR: USUARIO O CONTRASEÑA INCORRECTA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=WIN-SERVER\JAGUARIRA;Initial Catalog=SistemaProduccion;Persist Security Info=True;User ID=sa;Password=Jaguar1");

                try
                {
                    con.Open();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("ERROR FAVOR DE INFORMAR AL DEPARTAMENTO DE SISTEMAS " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                String consultacontraseña = "Select Contraseña From LOGIN where NobreUsuario = '" + usuariotxbx.Text + "'";

                try
                {
                    SqlCommand com = new SqlCommand(consultacontraseña, con);

                    if (com.ExecuteScalar() != DBNull.Value)
                    {
                        if (contraseñatxtbx.Text == Convert.ToString(com.ExecuteScalar()))
                        {
                            VariableSecion = usuariotxbx.Text;

                            this.Hide();
                            Main ss = new Main();
                            ss.Show();
                        }

                        else
                        {
                            contraseñatxtbx.Text = ""; usuariotxbx.Text = "";
                            MessageBox.Show("ERROR: USUARIO O CONTRASEÑA INCORRECTA ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else
                    {
                        MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                con.Close();
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

        private void contraseñatxtbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
                entrar.PerformClick();
        }

    }
}
