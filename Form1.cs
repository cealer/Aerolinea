using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using aerolinea.Formularios;
namespace aerolinea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void avionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Avion.DefInstance.MdiParent = this;
            Avion.DefInstance.Show();
        }

        private void destinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Destino.DefInstance.MdiParent = this;
            Destino.DefInstance.Show();
        }

        private void vuelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vuelo.DefInstance.MdiParent = this;
            Vuelo.DefInstance.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void boletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boleto.DefInstance.MdiParent = this;
            Boleto.DefInstance.Show();
        }
    }
}