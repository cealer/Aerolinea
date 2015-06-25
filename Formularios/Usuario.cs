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
    public partial class Usuario : Form
    {
        public static string usuarioParametro = "";
        private readonly UsuarioBOL _usuarioBol = new UsuarioBOL();

        public static bool Privilegios = false;

        public Usuario()
        {
            InitializeComponent();
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            try
            {
                string Password = tbxPass.Text;
                string usuario = tbxUsuario.Text;
                var lista = _usuarioBol.Buscar(usuario);
                string hash = _usuarioBol.GenerarHash(Password);

                for (int i = 0; i < lista.Rows.Count; i++)
                {
                    if (_usuarioBol.validarUsuario(Password, lista.Rows[i].ItemArray[2].ToString()) == true)
                    {
                        if (lista.Rows[i].ItemArray[3].Equals(true))
                        {
                            Privilegios = true;
                            
                        }
                        usuarioParametro = tbxUsuario.Text;
                        Limpiar();
                        Principal aux = new Principal();
                        MessageBox.Show("Bienvenido " + lista.Rows[i].ItemArray[1].ToString());
                        aux.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta");
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error inesperado");
            }
        }



        void Limpiar()
        {
            tbxPass.Clear();
            tbxUsuario.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            Privilegios = false;
            tbxUsuario.Focus();
        }
    }
}
