using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aerolinea_Entidades;
namespace aerolinea.Formularios
{
    public partial class Boleto : Form
    {
        public static int asiento;
        public static double precio;

        private static Boleto m_FormDefInstance;
        public static Boleto DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Boleto();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        public Boleto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fAsiento aux = new fAsiento();
            aux.ShowDialog();
            lblAsiento.Text = asiento.ToString();
        }

        private void btnBuscarDestino_Click(object sender, EventArgs e)
        {
            Destino aux = new Destino();
            Destino.enviarDatos = true;
            aux.ShowDialog();
            try
            {
            lblDes.Text = Destino.aux.Destino;
            lblCosto.Text = precio.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSalidaVuelo_Click(object sender, EventArgs e)
        {
            Vuelo aux = new Vuelo();
            Vuelo.enviarDatos = true;
            try
            {
                aux.ShowDialog();
                lblSalida.Text = Vuelo.aux.Salida.ToString();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void Boleto_Load(object sender, EventArgs e)
        {

        }
    }
}