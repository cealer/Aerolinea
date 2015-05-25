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
    public partial class fAsiento : Form
    {
        public fAsiento()
        {
            InitializeComponent();
        }
        private static fAsiento m_FormDefInstance;
        public static fAsiento DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new fAsiento();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public static int can;
        private void Asiento_Load(object sender, EventArgs e)
        {
            
            //Creando Asientos
            int cantidad=Vuelo.avion.Capacidad;
            int X = 14;
            int Y = 16;
            int max = 1074;
            for (int i = 1; i <= cantidad; i++)
            {
                Asiento aux = new Asiento();
                
                aux.Name = "asiento"+(0+i).ToString();
                aux.TabIndex = i;
                aux.Numero = i;
                
                // 
                // avion
                // 

                avion1.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                avion1.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                avion1.Controls.Add(aux);
                avion1.Name = "avion";
                avion1.ResumeLayout(false);
                
                //
                //Creando asientos
                //
                if (X >=max)
                {           
                    aux.Location = new System.Drawing.Point(X, Y);
                    Y = Y + 50;
                    X = 14;
                }
                else
                {
                    aux.Location = new System.Drawing.Point(X, Y);       
                    X = X + 50;
                }
            }
        }

        private void avion1_Load(object sender, EventArgs e)
        {

        }
        }  
        }