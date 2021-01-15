using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaProduccion
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nUMERODEPARTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumeroParte numeroparte = new NumeroParte();
            numeroparte.ShowDialog();
        }

        private void rECIBOALMACENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReciboProduccion reciboproduccion = new ReciboProduccion();
            reciboproduccion.ShowDialog();
        }

        private void iNVENTARIOALMACENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventarioProduccion inventarioprod = new InventarioProduccion();
            inventarioprod.ShowDialog();
        }

        private void eMBARQUEALMACENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmbarqueProduccion embarqueproduccion = new EmbarqueProduccion();
            embarqueproduccion.ShowDialog();
        }

        private void bLANKINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BlankingProduccion blankingproduccion = new BlankingProduccion();
            blankingproduccion.ShowDialog();
        }

        private void sLITTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SlitterProduccion slitterproduccion = new SlitterProduccion();
            slitterproduccion.ShowDialog();
        }
    }
}
