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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace aerolinea.Formularios
{
    public partial class Boleto : Form
    {
        public static int asiento;
        public static double precio;
        public static int parametroAsiento;
        public static int parametroAvion;
        EBoleto aux = new EBoleto();
        EVuelo vuelo = new EVuelo();
        EPersona persona = new EPersona();
        EDestino destino = new EDestino();

        private readonly BoletoBOL _boletoBol = new BoletoBOL();
        private readonly PersonaBOL _personaBol = new PersonaBOL();
        private readonly VueloBOL _vueloBol = new VueloBOL();
        private readonly DestinoBOL _destinoBol = new DestinoBOL();

        private static Boleto m_FormDefInstance;

        public static Boleto DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new Boleto();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }

        public Boleto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            fAsiento aux = new fAsiento();
            aux.ShowDialog();
            lblAsiento.Text = asiento.ToString();
        }

        private void btnBuscarDestino_Click(object sender, EventArgs e)
        {
            Destino aux = new Destino();
            Destino.enviarDatos = true;
            aux.ShowDialog();
            try
            {
                lblDes.Text = Destino.aux.Destino;
                lblCosto.Text = precio.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSalidaVuelo_Click(object sender, EventArgs e)
        {
            Vuelo aux = new Vuelo();
            Vuelo.enviarDatos = true;
            try
            {
                aux.ShowDialog();
                lblSalida.Text = Vuelo.aux.Salida.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Boleto_Load(object sender, EventArgs e)
        {
            if (Usuario.Privilegios==false)
            {
                btnImprimir.Enabled = false;
                
            }
            LlenarDatagriew();
        }
        EPersona person = new EPersona();
        private void btnOperacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (aux.IdBoleto > 0)
                {
                    int idPersona = Convert.ToInt32(dgvBoleto.CurrentRow.Cells[5].Value);
                    aux.IdPersona = idPersona;
                    aux.IdVuelo = Vuelo.aux.IdVuelo;
                    aux.Asiento = asiento;
                    aux.Costo = precio;
                    _boletoBol.Modificar(aux);
                    MessageBox.Show("Modificado");
                }
                else
                {
                    aux.IdPersona = Persona.aux.IdPersona;
                    if (aux.IdPersona == 0)
                    {
                        int id = _personaBol.ObtenerIdPasajero();
                        person = _personaBol.ObtenerPorId(persona, id);
                        aux.IdPersona = person.IdPersona;
                    }
                    aux.IdVuelo = Vuelo.aux.IdVuelo;
                    aux.Asiento = asiento;
                    aux.Costo = precio;
                    _boletoBol.Registrar(aux);
                    Limpiar();
                    tabControl1.SelectedIndex = 1;
                    btnPasajero.Enabled = true;
                    MessageBox.Show("Agregado");
                }
                LlenarDatagriew();
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
            lblApellidos.Text = "";
            lblAsiento.Text = "";
            lblCosto.Text = "";
            lblDes.Text = "";
            lblDNI.Text = "";
            lblNombres.Text = "";
            lblSalida.Text = "";
            Persona.aux = new EPersona();
            Destino.aux = new EDestino();
            Vuelo.aux = new EVuelo();
        }

        private void btnPasajero_Click(object sender, EventArgs e)
        {
            Persona.opPasajero = true;
            Persona aux = new Persona();
            aux.ShowDialog();
            if (Persona.NuevoPasajaero == true)
            {
                int id = _personaBol.ObtenerIdPasajero();
                person = _personaBol.ObtenerPorId(persona, id);
                lblNombres.Text = person.Nombres;
                lblApellidos.Text = person.Apellidos;
                lblDNI.Text = person.Dni;
                Persona.NuevoPasajaero = false;
            }
            else
            {
                lblNombres.Text = Persona.aux.Nombres;
                lblApellidos.Text = Persona.aux.Apellidos;
                lblDNI.Text = Persona.aux.Dni;
            }


            Persona.opPasajero = false;

        }

        void LlenarDatagriew()
        {
            dgvBoleto.DataSource = _boletoBol.obtenerTodos(aux,dtpIni.Value,dtpFin.Value);
            dgvBoleto.Columns[0].Visible = false;
            dgvBoleto.Columns[1].Visible = false;
            dgvBoleto.Columns[4].Visible = false;

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aux = new EBoleto();
            int id = Convert.ToInt32(dgvBoleto.CurrentRow.Cells[0].Value.ToString());
            _boletoBol.Eliminar(aux, id);
            MessageBox.Show("Eliminado");
            LlenarDatagriew();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var ds = new FileStream("reporteBoleto.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
            var doc = new Document(PageSize.A4);
            var escribir = PdfWriter.GetInstance(doc, ds);
            doc.AddAuthor("Aerolínea");
            doc.AddTitle("Reporte de boletos");
            doc.AddCreator(Usuario.usuarioParametro);
            doc.Open();
            var Fila = new Paragraph("Reporte de Boletos");
            Fila.Alignment = Element.ALIGN_CENTER;
            doc.Add(Fila);
            var fi = dtpIni.Value.ToShortDateString();
            var ff = dtpFin.Value.ToShortDateString();
            Fila = new Paragraph("Desde: " + fi + " Hasta: " + ff);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Fila);
            //
            var table = new PdfPTable(7);
            table.SetWidthPercentage(new float[] { 20, 50, 110, 150, 70, 60, 170 }, PageSize.A4);
            var texto = new[] { "Nº","Costo", "Nombre", "Apellido", "DNI", "Destino", "SALIDA" };
            var celda = new PdfPCell();
            foreach (var item in texto)
            {
                celda = new PdfPCell(new Phrase(item));
                celda.BorderWidth = 0;
                celda.BorderWidthBottom = 0.5f;
                table.AddCell(celda);
            }
            //Crear las celdas de registros
            foreach (DataGridViewRow fila in dgvBoleto.Rows)
            {
                celda = new PdfPCell(new Phrase(fila.Cells[2].Value.ToString()));
                celda.BorderWidth = 0; celda.BorderWidthBottom = 0.5f; table.AddCell(celda);
                celda = new PdfPCell(new Phrase(fila.Cells[3].Value.ToString()));
                celda.BorderWidth = 0; celda.BorderWidthBottom = 0.5f; table.AddCell(celda);
                celda = new PdfPCell(new Phrase(fila.Cells[5].Value.ToString()));
                celda.BorderWidth = 0; celda.BorderWidthBottom = 0.5f; table.AddCell(celda);
                celda = new PdfPCell(new Phrase(fila.Cells[6].Value.ToString()));
                celda.BorderWidth = 0; celda.BorderWidthBottom = 0.5f; table.AddCell(celda);
                celda = new PdfPCell(new Phrase(fila.Cells[7].Value.ToString()));
                celda.BorderWidth = 0; celda.BorderWidthBottom = 0.5f; table.AddCell(celda);
                celda = new PdfPCell(new Phrase(fila.Cells[8].Value.ToString()));
                celda.BorderWidth = 0; celda.BorderWidthBottom = 0.5f; table.AddCell(celda);
                celda = new PdfPCell(new Phrase(fila.Cells[9].Value.ToString()));
                celda.BorderWidth = 0; celda.BorderWidthBottom = 0.5f; table.AddCell(celda);
            }
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(table);
            doc.Close();
            escribir.Close();
            var ruta = Path.Combine(Application.StartupPath, "reporteBoleto.pdf");
            Process.Start(ruta);
        }

        private void dgvBoleto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LlenarDatagriew();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}