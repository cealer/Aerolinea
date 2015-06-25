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

namespace aerolinea.Formularios
{
    public partial class UsuarioMantenimiento : Form
    {
        private readonly UsuarioBOL _usuarioBol = new UsuarioBOL();
        private readonly PersonaBOL _personaBol = new PersonaBOL();
        public static EPersona persona = new EPersona();
        public static EUsuario aux=new EUsuario();

        //Evita que se pueda abrir el mismo formulario 2 veces
        private static UsuarioMantenimiento m_FormDefInstance;

        public static UsuarioMantenimiento DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new UsuarioMantenimiento();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public UsuarioMantenimiento()
        {
            InitializeComponent();
        }

        void Limpiar() {
            tbxPass.Clear();
            tbxUsuario.Clear();
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            try
            {
                string pass=tbxPass.Text;
                string hash = _usuarioBol.GenerarHash(pass);
                aux.Usuario = tbxUsuario.Text;
                aux.Pass = hash;
                aux.Privilegios = rdnSi.Checked;
                _usuarioBol.Registrar(aux);
                Limpiar();
                MessageBox.Show("Usuario Registrado");
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
        private void rdnPrivilegios_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnSi.Checked==true)
            {
                rdnNo.Checked = false;    
            }
            
        }
        private void rdnNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnNo.Checked==true)
            {
            rdnSi.Checked = false;
            }
        }

        private void UsuarioMantenimiento_Load(object sender, EventArgs e)
        {
            #region Timer para el cambio de imagen
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
            #endregion
        }
        bool op = true;
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (op == true)
            {
                pictureBox1.Image = aerolinea.Properties.Resources.hombre_usuario_icono;
                op = false;
            }
            else
            {
                pictureBox1.Image = aerolinea.Properties.Resources.preview;
                op = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {

                this.Close();
            }
        }
    }
}
