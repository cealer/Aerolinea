using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aerolinea_LogicaNegocio;
using Aerolinea_Entidades;
using System.Reflection;
namespace aerolinea.Formularios
{
    public partial class Avion : Form
    {
       public static EAvion aux;
        //
        private readonly AvionBOL  _avionBol = new AvionBOL();

        //Evita que se pueda abrir el mismo formulario 2 veces
        private static Avion m_FormDefInstance;
        public static Avion DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Avion();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public Avion()
        {
            InitializeComponent();
        }

        void LlenarDatagriew() {
            dgvAvion.DataSource = _avionBol.ObtenerTodos(aux);
            dgvAvion.Columns[0].Visible = false;
        }

        void Limpiar() {
            tbxBusqueda.Clear();
            tbxCap.Clear();
            tbxEnve.Clear();
            tbxLon.Clear();
            tbxModel.Clear();
            tbxNomAero.Clear();
            tbxPesoMax.Clear();
            tbxSalida.Clear();
            tbxSani.Clear();
            tbxNomAero.Focus();
            tbxBusqueda.Clear();
            aux = new EAvion();
        }

        public static bool enviarDatos = false;
       
        void OpcionesVistaBuscar()
        {
            tabControl1.TabPages.RemoveAt(0);
            cmsOperaciones.Enabled = false;
            cmsOperaciones.Dispose();
        }
        
        private void Avion_Load(object sender, EventArgs e)
        {

            if (enviarDatos==true)
            {
                OpcionesVistaBuscar();
            }

            aux = new EAvion();
            //Obtener Todos los campos de la tabla X
            var lista = _avionBol.LlenarCombo(aux);
            //Agregando items al combobox
            foreach (var item in lista)
            {
            cboBusqueda.Items.Add(item);
            }
            //Llenando el datagridview
            LlenarDatagriew();
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            try
            {
                    aux.Aerolinea = tbxNomAero.Text;
                    aux.Capacidad = int.Parse(tbxCap.Text);
                    aux.Despliegue = float.Parse(tbxPesoMax.Text);
                    aux.Envergadura = float.Parse(tbxEnve.Text);
                    aux.Longitud = float.Parse(tbxLon.Text);
                    aux.Modelo = tbxModel.Text;
                    aux.Salida = int.Parse(tbxSalida.Text);
                    aux.Sanitarios = int.Parse(tbxSani.Text);

                    if (aux.IdAvion > 0)
                    {
                        _avionBol.Modificar(aux);
                        MessageBox.Show("Modificado");
                    }
                    else
                    {
                        _avionBol.Registrar(aux);
                        MessageBox.Show("Agregado");
                    }

                    Limpiar();
                    LlenarDatagriew();
                    tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!cboBusqueda.SelectedIndex.Equals(-1))
            {
                string busqueda = tbxBusqueda.Text;
                EAvion aux = new EAvion();
                dgvAvion.DataSource = _avionBol.ObtenerCondicion(aux, cboBusqueda.SelectedItem.ToString(), busqueda);
                dgvAvion.Columns[0].Visible = false;
                Limpiar();    
            }
            else
            {
                MessageBox.Show("Escoja un campo a buscar");
            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aux = new EAvion();
            int id=Convert.ToInt32(dgvAvion.CurrentRow.Cells[0].Value.ToString());
            _avionBol.Eliminar(aux,id);
            MessageBox.Show("Eliminado");
            LlenarDatagriew();
        }
    
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idAvion =Convert.ToInt32(dgvAvion.CurrentRow.Cells[0].Value);
            aux = _avionBol.ObtenerPorId(aux,idAvion);
            tbxNomAero.Text = aux.Aerolinea;
            tbxModel.Text = aux.Modelo;
            tbxCap.Text = aux.Capacidad.ToString();
            tbxLon.Text = aux.Longitud.ToString();
            tbxEnve.Text = aux.Envergadura.ToString();
            tbxPesoMax.Text = aux.Despliegue.ToString();
            tbxSalida.Text = aux.Salida.ToString();
            tbxSani.Text = aux.Sanitarios.ToString();      
            tabControl1.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvAvion_DoubleClick(object sender, EventArgs e)
        {
            if (enviarDatos==true)
            {
            enviarDatos = false;
            int id = Convert.ToInt32(dgvAvion.CurrentRow.Cells[0].Value.ToString());
            aux = _avionBol.ObtenerPorId(aux, id);
            this.Close();   
            }
        }
        }
    }