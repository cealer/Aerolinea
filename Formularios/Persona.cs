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
using System.Timers;
using System.Windows.Forms;
using System.IO;
namespace aerolinea.Formularios
{
    public partial class Persona : Form
    {
        public static bool opPasajero = false;
        public static int idTipoPersona = 1;

        public static EPersona aux = new EPersona();
        ETipoPersona tipo = new ETipoPersona();

        private readonly PersonaBOL _personaBol = new PersonaBOL();
        private readonly TipoPersonaBOL _tipopersonaBol = new TipoPersonaBOL();

        public static bool NuevoPasajaero = false;

        public Persona()
        {
            InitializeComponent();
        }

        private static Persona m_FormDefInstance;
        public static Persona DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Persona();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        private void Pasajero_Load(object sender, EventArgs e)
        {
            if (Usuario.Privilegios == false)
            {
                rdnNo.Enabled = false;
                rdnSi.Enabled = false;
                label4.Visible = false;
                rdnNo.Visible = false;
                rdnSi.Visible = false;
            }
            if (opPasajero == false)
            {
                LlenarPersonas();
            }

            else
            {
                string buscar = "Persona.IdPersona,Persona.IdPersona,TipoPersona.Tipo,Persona.Nombres,Persona.Apellidos,Persona.DNI,Persona.FecNac,Persona.Celular,Persona.Email";
                dgvLista.DataSource = _personaBol.ObtenerCondicion(aux, buscar, "Tipo", "Pasajero");
            }

            LlenarCombo();
            LlenarComboBuscar();
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[1].Visible = false;

            #region Timer para el cambio de imagen
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            #endregion
           
        }
        //Variable que nos ayudara para cambiar de imagen
        bool op = true;
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (op==true)
            {
                pictureBox1.Image = aerolinea.Properties.Resources.retrato_femenino_del_icono_del_perfil_de_la_empresaria_plano_47075260;
                op = false;
            }
            else
            {
                pictureBox1.Image = aerolinea.Properties.Resources.empleado_1186693;
                op = true;
            }
          
        }

        void LlenarComboBuscar()
        {
            var lista = _personaBol.LlenarCombo(aux);
            if (opPasajero == true)
            {
                foreach (var item in lista)
                {
                    cboPersonaBuscar.Items.Add(item.ToString());
                }
                cboPersonaBuscar.SelectedIndex = 0;
                cboPersonaBuscar.Items.Remove("IdTipoPersona");
                cboPersonaBuscar.Items.Remove("Estado");
            }
            else
            {
                foreach (var item in lista)
                {
                    cboPersonaBuscar.Items.Add(item.ToString());
                }
                cboPersonaBuscar.Items.Remove("IdTipoPersona");
                cboPersonaBuscar.Items.Add("Tipo");
            }

        }

        string getNombres()
        {
            return tbxNom1.Text;

        }
        string getApellidos()
        {
            return tbxApe.Text;
        }

        void LlenarPersonas()
        {
            string BuscarPersona = tbxPersonaBuscar.Text;
            string buscar = "Persona.IdPersona,Persona.IdPersona,TipoPersona.Tipo,Persona.Nombres,Persona.Apellidos,Persona.DNI,Persona.FecNac,Persona.Celular,Persona.Email,Persona.Estado";
            dgvLista.DataSource = _personaBol.ObtenerTodos(aux, buscar);
            dgvLista.Columns[0].Visible = false;
            dgvLista.Columns[1].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                aux.Nombres = getNombres();
                aux.Apellidos = getApellidos();
                aux.Dni = mtbDNI.Text;
                aux.FecNac = dtpNacimiento.Value.Date;
                aux.Celular = mtbCelular.Text;
                aux.Email = tbxEmail.Text;
                aux.IdTipoPersona = idTipoPersona;
                aux.Estado = rdnSi.Checked;
                if (aux.IdPersona > 0)
                {
                    _personaBol.Modificar(aux);
                    MessageBox.Show("Modificado");
                }
                else
                {
                    _personaBol.Registrar(aux);
                    MessageBox.Show("Agregado");
                    if (opPasajero == true)
                    {
                        aux = new EPersona();
                        NuevoPasajaero = true;
                        this.Close();
                    }
                }

                Limpiar();
                LlenarPersonas();
                tabControl1.SelectedIndex = 1;
            }
            catch (CustomException ex)
            {
                MessageBox.Show(this, ex.Message, "No se pudo guardar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Limpiar()
        {
            tbxApe.Clear();
            tbxEmail.Clear();
            tbxNom1.Clear();
            tbxPersonaBuscar.Clear();
            aux = new EPersona();
            mtbDNI.Clear();
            mtbCelular.Clear();
            dtpNacimiento.ResetText();
            tbxNom1.Focus();
        }

        void LlenarCombo()
        {
            var lista = _tipopersonaBol.ObtenerTodos(tipo);
            if (opPasajero == true)
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!cboPersonaBuscar.SelectedIndex.Equals(-1))
            {
                string buscar = "Persona.IdPersona,Persona.IdPersona,TipoPersona.Tipo,Persona.Nombres,Persona.Apellidos,Persona.DNI,Persona.FecNac,Persona.Celular,Persona.Email,Persona.Estado";
                string busqueda = tbxPersonaBuscar.Text;
                string campo = cboPersonaBuscar.SelectedItem.ToString();
                dgvLista.DataSource = _personaBol.ObtenerCondicion(aux, buscar, campo, busqueda);
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
            if (cboPersonaBuscar.Items.Count > 0)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvLista_DoubleClick(object sender, EventArgs e)
        {
            if (dgvLista.Rows.Count > 0)
            {
                NuevoPasajaero = false;
                int id = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
                aux = _personaBol.ObtenerPorId(aux, id);
                this.Close();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aux = new EPersona();
            int id = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value.ToString());
            _personaBol.Eliminar(aux, id);
            MessageBox.Show("Eliminado");
            LlenarPersonas();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Verificar esto
            int idPersona = Convert.ToInt32(dgvLista.CurrentRow.Cells[0].Value);
            aux = _personaBol.ObtenerPorId(aux, idPersona);
            tbxApe.Text = aux.Apellidos;
            tbxNom1.Text = aux.Nombres;
            tbxEmail.Text = aux.Email;
            mtbCelular.Text = aux.Celular;
            mtbDNI.Text = aux.Dni;
            cboTipo.Text = dgvLista.CurrentRow.Cells[2].Value.ToString();
            dtpNacimiento.Value = DateTime.Parse(dgvLista.CurrentRow.Cells[6].Value.ToString());
            tabControl1.SelectedIndex = 0;
        }

        private void rdnSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnSi.Checked == true)
            {
                rdnNo.Checked = false;
            }
        }

        private void rdnNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnNo.Checked == true)
            {
                rdnSi.Checked = false;
            }
        }

        private void dtpNacimiento_ValueChanged(object sender, EventArgs e)
        {
            dtpNacimiento.CustomFormat = "dd/MM/yyyy";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 2)
            {

                this.Close();
            }
        }
    }
}
