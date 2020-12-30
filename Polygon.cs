using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace task5_10
{
    class Polygon
    {
        private double z;
        private Vertex[] VIS;

        public Polygon(Vertex v1, Vertex v2, Vertex v3)
        {
            VIS = new Vertex[] { v1, v2, v3 };
        }

        public void ZBuffering()
        {
            z = VIS[0].xyz[2] + VIS[1].xyz[2] + VIS[2].xyz[2];
        }
        public double GetZ()
        {
            return z;
        }
        
        public void Draw(Graphics g)
        {
            //освещение
            int tmp = Calc();
            {
                /*if (true)  //отрисовка интами
                {
                    g.FillPolygon(new SolidBrush(Color.FromArgb(255, tmp / 2, tmp / 2, tmp)), new Point[]{
                    VIS[0].xy,
                    VIS[1].xy,
                    VIS[2].xy });
                }
                else     // отрисовка флотами
                {
                    g.FillPolygon(new SolidBrush(Color.FromArgb(255, tmp / 2, tmp / 2, tmp)), new PointF[]{
                    new PointF ((float)VIS[0].xyz[0],(float)VIS[0].xyz[1]),
                    new PointF ((float)VIS[1].xyz[0],(float)VIS[1].xyz[1]),
                    new PointF ((float)VIS[2].xyz[0],(float)VIS[2].xyz[1]) });
                }*/

                if (false)  //отрисовка интами
                {
                    g.FillPolygon(new SolidBrush(Color.FromArgb(255, tmp / 2, tmp / 2, tmp)), new Point[]{
                    new Point ((int)VIS[0].xyz[0],(int)VIS[0].xyz[1]),
                    new Point ((int)VIS[1].xyz[0],(int)VIS[1].xyz[1]),
                    new Point ((int)VIS[2].xyz[0],(int)VIS[2].xyz[1]) });
                }
                else     // отрисовка флотами
                {
                    g.FillPolygon(new SolidBrush(Color.FromArgb(255, tmp / 2, tmp / 2, tmp)), new PointF[]{
                    new PointF ((float)VIS[0].xyz[0],(float)VIS[0].xyz[1]),
                    new PointF ((float)VIS[1].xyz[0],(float)VIS[1].xyz[1]),
                    new PointF ((float)VIS[2].xyz[0],(float)VIS[2].xyz[1]) });
                }
            }
        }
        private int Calc()
        {
            double Vx, Vy, Vz, Ux, Uy, Uz;
            Vx = VIS[0].xyz[0] - VIS[1].xyz[0];
            Vy = VIS[0].xyz[1] - VIS[1].xyz[1];
            Vz = VIS[0].xyz[2] - VIS[1].xyz[2];
            Ux = VIS[0].xyz[0] - VIS[2].xyz[0];
            Uy = VIS[0].xyz[1] - VIS[2].xyz[1];
            Uz = VIS[0].xyz[2] - VIS[2].xyz[2];
            double x = Vy * Uz - Vz * Uy;
            double y = Vz * Ux - Vx * Uz;
            double z = Vx * Uy - Vy * Ux;
            return (int)(255 * Math.Abs(z / (Math.Sqrt(x * x + y * y + z * z))));
        }
    }
}
