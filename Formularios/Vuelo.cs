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
    public partial class Vuelo : Form
    {
       private readonly AvionBOL _avionBol = new AvionBOL();
       private readonly VueloBOL _vueloBOL = new VueloBOL();
       
       public static EVuelo aux=new EVuelo();
       public static EAvion avion=new EAvion();
       public static EDestino destino= new EDestino();


       private static Vuelo m_FormDefInstance;
       public static Vuelo DefInstance
       {
           get
           {
               if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                   m_FormDefInstance = new Vuelo();
               return m_FormDefInstance;
           }
           set
           {
               m_FormDefInstance = value;
           }
       }

        public Vuelo()
        {
            InitializeComponent();
        }


        void LlenarDatagriew()
        {
            aux = new EVuelo();
            string buscar="Vuelo.IdVuelo,Avion.Modelo,Vuelo.Salida,Destino.Destino";
            dgvVuelo.DataSource = _vueloBOL.ObtenerTodos(aux,buscar);
            if (enviarDatos == true)
            {
                dgvVuelo.DataSource = _vueloBOL.ObtenerBuscar(aux, buscar,"Destino",Boleto.buscarDestino);
            }
        }

        void LlenarBuscar() {
            aux = new EVuelo();
            string buscar = "Vuelo.IdVuelo,Avion.Modelo,Vuelo.Salida,Destino.Destino";
            var lista = _vueloBOL.ObtenerTodos(aux, buscar);
        }

        void Limpiar()
        {
            lblAvion.Text="Modelo";
            lblDestino.Text="Destino";
            dtpSalida.Value = DateTime.Today;
            aux = new EVuelo();
            Destino.aux = null;
            Avion.aux = null;
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {

            try
            {
            aux.IdDestino = Destino.aux.IdDestino;
            aux.IdAvion = Avion.aux.IdAvion;
            aux.Salida =dtpSalida.Value;

            if (aux.IdVuelo > 0)
            {
                _vueloBOL.Modificar(aux);
                MessageBox.Show("Modificado");
            }
            else
            {
                _vueloBOL.Registrar(aux);
                MessageBox.Show("Agregado");
            }

            Limpiar();
            LlenarDatagriew();
            tabControl1.SelectedIndex = 1;
            }
            catch (CustomException ex)
            {
                MessageBox.Show(this, ex.Message, "No se pudo guardar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Verifique los datos");
            }
        }

        public static bool enviarDatos = false;

        void OpcionesBuscar() {
            tabControl1.TabPages.RemoveAt(0);
        }

        private void Vuelo_Load(object sender, EventArgs e)
        {

            if (enviarDatos==true)
            {
                LlenarBuscar();
                OpcionesBuscar();
                LlenarDatagriew();
            }
            else
            {
                LlenarDatagriew();
            }
        }

        private void btnBuscarAvion_Click(object sender, EventArgs e)
        {
            Avion aux = new Avion();
            Avion.enviarDatos = true;
            aux.ShowDialog();
            lblAvion.Text = Avion.aux.Modelo;
        }

        public static string DestinoBuscar = "";

        private void btnBuscarDestino_Click(object sender, EventArgs e)
        {
            Destino aux = new Destino();
            Destino.enviarDatos = true;
            aux.ShowDialog();
            lblDestino.Text = Destino.aux.Destino;
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public static int idVuelo;

        private void dgvVuelo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (enviarDatos == true)
            {
                enviarDatos = false;
                idVuelo = Convert.ToInt32(dgvVuelo.CurrentRow.Cells[0].Value.ToString());
                aux = _vueloBOL.ObtenerPorId(aux, idVuelo);
                avion = _avionBol.ObtenerPorId(avion, aux.IdAvion);
                this.Close();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aux = new EVuelo();
            int id = Convert.ToInt32(dgvVuelo.CurrentRow.Cells[0].Value.ToString());
            _vueloBOL.Eliminar(aux, id);
            MessageBox.Show("Eliminado");
            LlenarDatagriew();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}