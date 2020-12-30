using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5_10
{
    class Rotator
    {
        public static void RotateX(Vertex v, double angle, Vertex center)
        {
            ShiftBack(v, center);
            RotateX(v, angle);
            ShiftForward(v, center);
        }
        public static void RotateY(Vertex v, double angle, Vertex center)
        {
            ShiftBack(v, center);
            RotateY(v, angle); ShiftForward(v, center);
        }
        public static void RotateZ(Vertex v, double angle, Vertex center)
        {
            ShiftBack(v, center);
            RotateZ(v, angle);
            ShiftForward(v, center);
        }


        public static void ShiftForward(Vertex v, Vertex shift)
        {
            v.xyz = Multiply(v, ShiftForward(shift));
        }
        public static void ShiftBack(Vertex v, Vertex shift)
        {
            v.xyz = Multiply(v, ShiftBack(shift));
        }

        public static void RotateX(Vertex v, double angle)
        {
            double[][] temp = new double[][]{
                new double[]{1,0,0,0},
                new double[]{0,Math.Cos(angle),-Math.Sin(angle),0},
                new double[]{0,Math.Sin(angle),Math.Cos(angle),0},
                new double[]{0,0,0,1}
            };
            v.xyz = Multiply(v, temp);
        }

        public static void RotateY(Vertex v, double angle)
        {
            double[][] temp = new double[][]{
                new double[]{Math.Cos(angle),0, Math.Sin(angle),0},
                new double[]{0,1,0,0},
                new double[]{-Math.Sin(angle),0, Math.Cos(angle),0},
                new double[]{0,0,0,1}
        };
            v.xyz = Multiply(v, temp);
        }

        public static void RotateZ(Vertex v, double angle)
        {
            double[][] temp = new double[][]{
                new double[]{Math.Cos(angle),-Math.Sin(angle),0,0},
                new double[]{Math.Sin(angle),Math.Cos(angle),0,0},
                new double[]{0,0,1,0},
                new double[]{0,0,0,1}
        };
            v.xyz = Multiply(v, temp);
        }
        public static void Scale(Vertex v, double scale)
        {
            double[][] temp = new double[][]{
                new double[]{scale,0,0,0},
                new double[]{0,scale,0,0},
                new double[]{0,0,scale,0},
                new double[]{0,0,0,1}
        };
            v.xyz = Multiply(v, temp);
        }

        private static double[][] ShiftForward(Vertex shift)
        {
            double[][] temp = new double[][]{
                new double[]{1,0,0,0},
                new double[]{0,1,0,0},
                new double[]{0,0,1,0},
                new double[]{shift.xyz[0],shift.xyz[1],shift.xyz[2],1}
        };
            return temp;
        }

        private static double[][] ShiftBack(Vertex shift)
        {
            double[][] temp = new double[][]{
                new double[]{1,0,0,0},
                new double[]{0,1,0,0},
                new double[]{0,0,1,0},
                new double[]{-shift.xyz[0],-shift.xyz[1],-shift.xyz[2],1}
        };
            return temp;
        }

        private static double[] Multiply(Vertex mp, double[][] arr)
        {
            double[] temp = { 0, 0, 0, 0 };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp[j] += mp.xyz[i] * arr[i][j];
                }
            }
            return temp;
        }
    }
}
