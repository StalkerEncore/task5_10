using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace task5_10
{
    class Function
    {
        private static Vertex center = new Vertex(new double[] { 400, 500, 0, 1 });
        private float radius;
        private int dist = 100;
        private Dictionary<int, Vertex> vertices;
        private List<Polygon> polys;

        public Function()
        {
            float scale = 64;
            vertices = new Dictionary<int, Vertex>();
            polys = new List<Polygon>();
            dist = (int)Math.Ceiling(scale);
            this.radius = scale;
            Vertex temp;
            for (int i = -dist; i <= dist; i++)
            {
                for (int j = -dist; j <= dist; j++)
                {
                    temp = Calculator.Paraboloid(i * 8 / scale, j * 8 / scale);
                    vertices.Add((i + dist) * (dist * 3) + j, temp);
                    Rotator.Scale(temp, 32);
                    Rotator.ShiftForward(temp, center);
                }
            }
            Vertex v1, v2, v3, v4;
            for (int i = -dist; i < dist; i++)
            {
                for (int j = -dist; j < dist; j++)
                {
                    vertices.TryGetValue((i + dist) * (dist * 3) + j, out v1);
                    vertices.TryGetValue((i + dist + 1) * (dist * 3) + j, out v2);
                    vertices.TryGetValue((i + dist) * (dist * 3) + j + 1, out v3);
                    vertices.TryGetValue((i + dist + 1) * (dist * 3) + j + 1, out v4);
                    polys.Add(new Polygon(v1, v2, v4));
                    polys.Add(new Polygon(v1, v3, v4));
                }
            }
        }

        public void Draw(Graphics g)
        {
            //foreach (Vertex v in vertices.Values) v.CalcPoint();
            foreach (Polygon p in polys)
            {
                p.ZBuffering();
            }
            polys.Sort(new Comparison<Polygon>((p1, p2) => p1.GetZ().CompareTo(p2.GetZ())));

            foreach (Polygon p in polys)
            {
                p.Draw(g);
            }
        }

        public void Rotate(double angle, int axis)
        {
            foreach (Vertex temp in vertices.Values)
            {
                switch (axis)
                {
                    case 0: Rotator.RotateX(temp, angle, center); break;
                    case 1: Rotator.RotateY(temp, angle, center); break;
                    case 2: Rotator.RotateZ(temp, angle, center); break;
                }
            }
        }
    }
}
