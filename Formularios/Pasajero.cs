using Aerolinea_Entidades;
using Aerolinea_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aerolinea.Formularios
{
    public partial class Pasajero : Form
    {
        public static bool opPasajero = false;
        public static int idTipoPersona = 1;

        public static EPersona aux = new EPersona();
        ETipoPersona tipo = new ETipoPersona();

        private readonly PersonaBOL _personaBol = new PersonaBOL();
        private readonly TipoPersonaBOL _tipopersonaBol = new TipoPersonaBOL();
        
        public Pasajero()
        {
            InitializeComponent();
        }

        private static Pasajero m_FormDefInstance;
        public static Pasajero DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Pasajero();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void Pasajero_Load(object sender, EventArgs e)
        {
            if (opPasajero==false)
            {
                LlenarPasajeros();    
            }
            else
            {
                tbxPasajero.Text = "1";
                btnBuscar.PerformClick();
            }
            LlenarCombo();
            LlenarComboBuscar();
        }

        void LlenarComboBuscar() {
            var lista = _personaBol.LlenarCombo(aux);
            if (opPasajero == true)
            {
             cboPersonaBuscar.Items.Add(lista[6].ToString());
             cboPersonaBuscar.SelectedIndex = 0;
            }
            else
            {
                foreach (var item in lista)
                {
                    cboPersonaBuscar.Items.Add(item.ToString());
                }
            }
           
        }

        string getNombres() {
            return tbxNom1.Text + " " + tbxNom2.Text;
        }
        string getApellidos() {
            return tbxApePat.Text + " " + tbxApeMat.Text;
        }

        void LlenarPasajeros() { 
        dgvLista.DataSource=_personaBol.ObtenerTodos(aux);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                aux.Nombres = getNombres();
                aux.Apellidos = getApellidos();
                aux.Dni = mtbDNI.Text;
                aux.FecNac =dtpNacimiento.Value.Date;
                aux.Celular = mtbCelular.Text;
                aux.Email = tbxEmail.Text;
                aux.IdTipoPersona=idTipoPersona;
                if (aux.IdPersona > 0)
                {
                   // _avionBol.Modificar(aux);
                    MessageBox.Show("Modificado");
                }
                else
                {
                    _personaBol.Registrar(aux);
                    MessageBox.Show("Agregado");
                    if (opPasajero==true)
                    {
                        aux.IdPersona = _personaBol.ObtenerIdPasajero();
                        this.Close();
                    }
                }

                Limpiar();
                LlenarPasajeros();
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Limpiar() {
        
        }

        void LlenarCombo() {
            var lista = _tipopersonaBol.ObtenerTodos(tipo);
            if (opPasajero==true)
            {
                for (int i = 0; i < lista.Rows.Count; i++)
                {
                    if (lista.Rows[i].ItemArray[1].ToString().Contains("Pasajero") || lista.Rows[i].ItemArray[1].ToString().Contains("Pasajeros") || lista.Rows[i].ItemArray[1].ToString().Contains("pasajero") || lista.Rows[i].ItemArray[1].ToString().Contains("pasajeros"))
                    {
                        cboTipo.Enabled = false;
                        cboTipo.Items.Add(lista.Rows[i].ItemArray[1].ToString());
                    }
                }
            }
            else
            {
                for (int i = 0; i < lista.Rows.Count; i++)
                {
                    cboTipo.Items.Add(lista.Rows[i].ItemArray[1].ToString());
                }
            }
            cboTipo.SelectedIndex = 0;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnTipoPersona_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!cboPersonaBuscar.SelectedIndex.Equals(-1))
            {
                string busqueda = tbxPasajero.Text;
                dgvLista.DataSource = _personaBol.ObtenerCondicion(aux, cboPersonaBuscar.SelectedItem.ToString(), busqueda);
                dgvLista.Columns[0].Visible = false;
                Limpiar();
            }
            else
            {
                MessageBox.Show("Escoja un campo a buscar");
            }
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lista = _tipopersonaBol.ObtenerTodos(tipo);
            if (cboPersonaBuscar.Items.Count>0)
            {
               
                for (int i = 0; i < lista.Rows.Count; i++)
                {
                   if (lista.Rows[i].ItemArray[1].ToString().Contains(cboTipo.SelectedItem.ToString()))
                    {
                        idTipoPersona = Convert.ToInt32(lista.Rows[i].ItemArray[0].ToString());
                    }
                }
            }
        }
    }
}
