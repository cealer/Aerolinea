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

        }
    }
}
