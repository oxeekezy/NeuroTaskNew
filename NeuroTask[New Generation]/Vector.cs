using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronsTask
{
    internal class Vector
    {
        public double X = 0;
        public double Y = 0;

        public Vector(Point end, Point origin)
        {
            X = end.X - origin.X;
            Y = end.Y - origin.Y;
        }

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static double operator *(Vector first, Vector second)
        {
            return first.X * second.X + first.Y * second.Y;
        }

        public static Vector operator -(Vector first, Vector second)
        {
            return new Vector(first.X - second.X, first.Y - second.Y);
        }

        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector(first.X + second.X, first.Y + second.Y);
        }

        public static Vector operator ^(double mult, Vector second)
        {
            return new Vector(mult * second.X, mult * second.Y);
        }
    }
}
