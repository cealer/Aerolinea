using Aerolinea_LogicaNegocio;
using Aerolinea_Entidades;
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
    public partial class Destino : Form
    {
       private readonly DestinoBOL _destinoBol = new DestinoBOL();
        int idDestino;
       public static EDestino aux;
       private static Destino m_FormDefInstance;
       public static Destino DefInstance
       {
           get
           {
               if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                   m_FormDefInstance = new Destino();
               return m_FormDefInstance;
           }
           set
           {
               m_FormDefInstance = value;
           }
       }
        public Destino()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                aux.Destino = tbxDestino.Text;
                aux.Costo1 = double.Parse(tbxCosto1.Text);
                aux.Costo2 = double.Parse(tbxCosto2.Text);
                if (aux.IdDestino > 0)
                {
                    _destinoBol.Modificar(aux);
                    MessageBox.Show("Modificado");
                }
                else
                {
                    _destinoBol.Registrar(aux);
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
            aux = new EDestino();
               if (!cboDestino.SelectedIndex.Equals(-1))
            {
            string busqueda = tbxBuscar.Text;
            dgvDestino.DataSource = _destinoBol.ObtenerCondicion(aux, cboDestino.SelectedItem.ToString(), busqueda);
            dgvDestino.Columns[0].Visible = false;
            Limpiar();
            }
               else
               {
                   MessageBox.Show("Escoja un campo a buscar");
               }
        }

        void Limpiar() {
            tbxBuscar.Clear();
            tbxDestino.Clear();
            tbxCosto1.Clear();
            tbxCosto2.Clear();
            aux = new EDestino();
        }

        void LlenarDatagriew()
        {
            aux = new EDestino();
            dgvDestino.DataSource = _destinoBol.ObtenerTodos(aux);
            dgvDestino.Columns[0].Visible = false;
        }

        public static bool enviarDatos=false;

        private void Destino_Load(object sender, EventArgs e)
        {
            if (enviarDatos==true)
            {
                OpcionesVistaBuscar();
            }
            LlenarDatagriew();
            //Obtener Todos los campos de la tabla X
            var lista = _destinoBol.LlenarCombo(aux);
            //Agregando items al combobox
            foreach (var item in lista)
            {
                cboDestino.Items.Add(item);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aux = new EDestino();
            int id = Convert.ToInt32(dgvDestino.CurrentRow.Cells[0].Value.ToString());
            _destinoBol.Eliminar(aux, id);
            MessageBox.Show("Eliminado");
            LlenarDatagriew();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idDestino = Convert.ToInt32(dgvDestino.CurrentRow.Cells[0].Value);
            aux = _destinoBol.ObtenerPorId(aux, idDestino);
            tbxDestino.Text = aux.Destino;
            tbxCosto1.Text = aux.Costo1.ToString();
            tbxCosto2.Text = aux.Costo2.ToString();
            tabControl1.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        void OpcionesVistaBuscar() {
            tabControl1.TabPages.RemoveAt(0);
            contextMenuStrip1.Enabled = false;
            contextMenuStrip1.Dispose();
        }

        private void dgvDestino_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (enviarDatos==true)
            {
                enviarDatos = false;
                int id = Convert.ToInt32(dgvDestino.CurrentRow.Cells[0].Value.ToString());
                
                aux = _destinoBol.ObtenerPorId(aux, id);
                try
                {
            Formularios.Boleto.precio=Convert.ToDouble(dgvDestino.CurrentCell.Value.ToString());
            this.Close();   
                }
                catch (Exception)
                {
                    this.Close();
                }
            }
        }
    }
}