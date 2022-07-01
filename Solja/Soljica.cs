using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solja
{
    internal class Soljica
    {
        Point o;
        int x, Dx;
        Color boja;

        public Point O
        {
            get { return o; }
        }
        public int A
        {
            get { return x; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("x<0");
                }
                else x = value;
            }
        }

        public Soljica(Point o, int x, Color color)
        {
            this.o = o;
            A = x;
            this.boja = color;
        }

        public void Crtaj(Graphics g)
        {
            SolidBrush brush = new SolidBrush(boja);
            Pen pen = new Pen(boja, x / 4);
            g.FillRectangle(brush, o.X - x / 2, o.Y - x, x, 2 * x);
            g.DrawLine(pen, o.X - x, o.Y + x, o.X + x, o.Y + x);
            g.DrawEllipse(pen, o.X, o.Y - x / 2, x, x);
        }

        public void Start(int dx)
        {
            this.Dx = dx;
        }

        public void Pomeranje()
        {
            o.X += Dx;
        }

        public bool End(int limit)
        {
            return o.X - x > limit;
        }

        public void Stop()
        {
            Dx = 0;
        }
    }
}
