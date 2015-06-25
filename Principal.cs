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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
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

            toolStripStatusLabel1.Text = "Usuario: " + Usuario.usuarioParametro+" Hora Ingreso: "+DateTime.Today;
            if (Usuario.Privilegios==false)
            {
                avionToolStripMenuItem.Enabled = false;
                destinoToolStripMenuItem.Enabled = false;
                vuelosToolStripMenuItem.Enabled = false;
                tipoToolStripMenuItem.Enabled = false;
                mantenimientoToolStripMenuItem.Enabled = false;
                usuariosToolStripMenuItem.Enabled = false;   
            }
        }

        private void boletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Boleto.DefInstance.MdiParent = this;
            Boleto.DefInstance.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void tipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoPersona.DefInstance.MdiParent = this;
            TipoPersona.DefInstance.Show();
        }

        private void mantenimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Persona.DefInstance.MdiParent = this;
            Persona.DefInstance.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           UsuarioMantenimiento.DefInstance.MdiParent = this;
           UsuarioMantenimiento.DefInstance.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Usuario aux = new Usuario();
            aux.Show();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text += DateTime.Now.ToString(" HH:mm:ss");

        }

        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void empleadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            avionToolStripMenuItem.PerformClick();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            destinoToolStripMenuItem.PerformClick();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            boletoToolStripMenuItem.PerformClick();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}