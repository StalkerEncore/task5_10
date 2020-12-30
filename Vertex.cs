using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace task5_10
{
    class Vertex
    {
        public double[] xyz;
        /*public Point xy;
        public void CalcPoint()
        {
            xy = new Point((int)xyz[0],(int)xyz[1]);
        }*/
        public Vertex(double[] xyz)
        {
            this.xyz = xyz;
        }
    }
}
