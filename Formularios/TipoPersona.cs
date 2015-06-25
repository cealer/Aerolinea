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
    public partial class TipoPersona : Form
    {
        ETipoPersona aux =  new ETipoPersona();
        
        private readonly TipoPersonaBOL _TipoPersonaBOL = new TipoPersonaBOL();

        private static TipoPersona m_FormDefInstance;
        public static TipoPersona DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new TipoPersona();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public TipoPersona()
        {
            InitializeComponent();
        }

        private void TipoPersona_Load(object sender, EventArgs e)
        {
            LlenarDatagriew();
        }

        void LlenarDatagriew() {
        dgvTipoPersona.DataSource=_TipoPersonaBOL.ObtenerTodos(aux);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                aux.Tipo = tbxTipo.Text;

                if (aux.IdTipoPersona > 0)
                {
                    _TipoPersonaBOL.Modificar(aux);
                    MessageBox.Show("Modificado");
                }
                else
                {
                    _TipoPersonaBOL.Registrar(aux);
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
            catch (Exception ex){
                MessageBox.Show(ex.Message,"Error inesperado");
            }
        }

        void Limpiar() {
            tbxTipo.Clear();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aux = new ETipoPersona();
            int id = Convert.ToInt32(dgvTipoPersona.CurrentRow.Cells[0].Value.ToString());
            _TipoPersonaBOL.Eliminar(aux, id);
            MessageBox.Show("Eliminado");
            LlenarDatagriew();
        }

        int idTipo;

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idTipo = Convert.ToInt32(dgvTipoPersona.CurrentRow.Cells[0].Value);
            aux = _TipoPersonaBOL.ObtenerPorId(aux, idTipo);
            tbxTipo.Text = aux.Tipo;
            tabControl1.SelectedIndex = 0;
        }

    }
}
