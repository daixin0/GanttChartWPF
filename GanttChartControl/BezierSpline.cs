using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GanttChartControl
{
    public static class BezierSpline
    {
        // Methods
        public static void GetCurveControlPoints(Point[] knots, out Point[] firstControlPoints, out Point[] secondControlPoints)
        {
            if (knots == null)
            {
                throw new ArgumentNullException("knots");
            }
            int index = knots.Length - 1;
            if (index < 1)
            {
                throw new ArgumentException("At least two knot points required", "knots");
            }
            if (index == 1)
            {
                firstControlPoints = new Point[1];
                firstControlPoints[0].X = ((2.0 * knots[0].X) + knots[1].X) / 3.0;
                firstControlPoints[0].Y = ((2.0 * knots[0].Y) + knots[1].Y) / 3.0;
                secondControlPoints = new Point[1];
                secondControlPoints[0].X = (2.0 * firstControlPoints[0].X) - knots[0].X;
                secondControlPoints[0].Y = (2.0 * firstControlPoints[0].Y) - knots[0].Y;
            }
            else
            {
                int num2;
                double[] rhs = new double[index];
                for (num2 = 1; num2 < (index - 1); num2++)
                {
                    rhs[num2] = (4.0 * knots[num2].X) + (2.0 * knots[num2 + 1].X);
                }
                rhs[0] = knots[0].X + (2.0 * knots[1].X);
                rhs[index - 1] = ((8.0 * knots[index - 1].X) + knots[index].X) / 2.0;
                double[] numArray2 = GetFirstControlPoints(rhs);
                for (num2 = 1; num2 < (index - 1); num2++)
                {
                    rhs[num2] = (4.0 * knots[num2].Y) + (2.0 * knots[num2 + 1].Y);
                }
                rhs[0] = knots[0].Y + (2.0 * knots[1].Y);
                rhs[index - 1] = ((8.0 * knots[index - 1].Y) + knots[index].Y) / 2.0;
                double[] numArray3 = GetFirstControlPoints(rhs);
                firstControlPoints = new Point[index];
                secondControlPoints = new Point[index];
                for (num2 = 0; num2 < index; num2++)
                {
                    firstControlPoints[num2] = new Point(numArray2[num2], numArray3[num2]);
                    if (num2 < (index - 1))
                    {
                        secondControlPoints[num2] = new Point((2.0 * knots[num2 + 1].X) - numArray2[num2 + 1], (2.0 * knots[num2 + 1].Y) - numArray3[num2 + 1]);
                    }
                    else
                    {
                        secondControlPoints[num2] = new Point((knots[index].X + numArray2[index - 1]) / 2.0, (knots[index].Y + numArray3[index - 1]) / 2.0);
                    }
                }
            }
        }

        private static double[] GetFirstControlPoints(double[] rhs)
        {
            int num3;
            int length = rhs.Length;
            double[] numArray = new double[length];
            double[] numArray2 = new double[length];
            double num2 = 2.0;
            numArray[0] = rhs[0] / num2;
            for (num3 = 1; num3 < length; num3++)
            {
                numArray2[num3] = 1.0 / num2;
                num2 = ((num3 < (length - 1)) ? 4.0 : 3.5) - numArray2[num3];
                numArray[num3] = (rhs[num3] - numArray[num3 - 1]) / num2;
            }
            for (num3 = 1; num3 < length; num3++)
            {
                numArray[(length - num3) - 1] -= numArray2[length - num3] * numArray[length - num3];
            }
            return numArray;
        }
    }
}
