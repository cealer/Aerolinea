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
using Aerolinea_LogicaNegocio;
namespace aerolinea.Formularios
{
    public partial class Boleto : Form
    {
        public static int asiento;
        public static double precio;

        EBoleto aux = new EBoleto();

        private readonly BoletoBOL _boletoBol = new BoletoBOL();

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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Boleto_Load(object sender, EventArgs e)
        {

        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            try
            {   
                if (aux.IdBoleto > 0)
                {
                    //_boletoBol.Modificar(aux);
                    MessageBox.Show("Modificado");
                }
                else
                {
                    aux.IdAeropuerto = 1;
                    aux.IdPersona = Pasajero.aux.IdPersona;
                    aux.IdVuelo = Vuelo.aux.IdVuelo;
                    aux.Asiento = asiento;
                    aux.Costo = precio;
                    _boletoBol.Registrar(aux);
                    Limpiar();
                    MessageBox.Show("Agregado");          
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        void Limpiar() {
            lblApellidos.Text = "";
            lblAsiento.Text = "";
            lblCosto.Text = "";
            lblDes.Text = "";
            lblDNI.Text = "";
            lblNombres.Text = "";
            lblSalida.Text = "";
            Pasajero.aux = null;
            Destino.aux = null;
            Vuelo.aux = null;
        }

        private void btnPasajero_Click(object sender, EventArgs e)
        {
            Pasajero.opPasajero = true;
            Pasajero aux = new Pasajero();
            aux.ShowDialog();
            Pasajero.opPasajero = false;
            lblNombres.Text = Pasajero.aux.Nombres;
            lblApellidos.Text = Pasajero.aux.Apellidos;
            lblDNI.Text = Pasajero.aux.Dni;
        }
    }
}