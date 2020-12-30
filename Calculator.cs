using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_10
{
    class Calculator
    {

        public static Vertex Paraboloid(double x, double y)
        {
            return new Vertex(new double[] { x, y, (Math.Sin(x)*Math.Cos(y)) /2, 1 });
        }
    }
}
