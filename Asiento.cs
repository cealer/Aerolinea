using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace aerolinea
{
    public class Asiento : Control
    {
        private Size _DefaultSize = new Size(40, 40);
        private int _Numero;
        private EstadoAsiento _Estado;

        public Asiento()
        {
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        public Asiento(int Numero)
            : base()
        {

        }

        [DefaultValue(0)]
        public int Numero
        {
            get { return _Numero; }
            set
            {
                _Numero = value;
                if (IsHandleCreated)
                    Invalidate();
            }
        }
        [DefaultValue(typeof(EstadoAsiento), "Disponible")]
        public EstadoAsiento Estado
        {
            get { return _Estado; }
            set
            {
                _Estado = value;
                if (IsHandleCreated)
                    Invalidate();
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Size Size
        {
            get { return base.Size; }
            set { base.Size = _DefaultSize; }
        }

        protected override System.Drawing.Size DefaultSize
        {
            get
            {
                return _DefaultSize;
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Hand;
            if (IsHandleCreated)
                Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
            if (IsHandleCreated)
                Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (Estado == EstadoAsiento.Disponible || Estado == EstadoAsiento.Reservado)
                {
                   var r= MessageBox.Show("Confirmar asiento","Asiento",MessageBoxButtons.YesNo);
                    if (r==DialogResult.Yes)
                    {
                        Estado = EstadoAsiento.Ocupado;
                        Formularios.Boleto.asiento = Numero;
                        Form.ActiveForm.Close();     
                    }
                }
                else
                    Estado = EstadoAsiento.Disponible;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (Estado == EstadoAsiento.Disponible)
                    Estado = EstadoAsiento.Reservado;
                else if (Estado == EstadoAsiento.Reservado)
                    Estado = EstadoAsiento.Disponible;

            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.Green);
            Color foreColor = Color.White;

            if (Estado == EstadoAsiento.Ocupado)
                brush = new SolidBrush(Color.Red);
            if (Estado == EstadoAsiento.Reservado)
            {
                brush = new SolidBrush(Color.Yellow);
                foreColor = Color.Black;
            }

            int penWidth = Cursor.Equals(Cursors.Default) ? 1 : 2;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(brush, new Rectangle(1, 1, Size.Width - 1 - penWidth, Size.Height - 1 - penWidth));
            e.Graphics.DrawEllipse(new Pen(Brushes.Black, penWidth), new Rectangle(1, 1, Size.Width - 1 - penWidth, Size.Height - 1 - penWidth));
            e.Graphics.DrawString(Numero.ToString(), Font, new SolidBrush(foreColor), new RectangleF(1, 1, Size.Width - 1 - penWidth, Size.Height - 1 - penWidth), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }
    }

    public enum EstadoAsiento
    {
        Disponible,
        Reservado,
        Ocupado
    }
}
