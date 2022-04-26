using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronsTask
{
    internal class AprocReadyFunction
    {
        ForAprocFunctions _type { get; set; }
        private List<Point> _points;
        public AprocReadyFunction(ForAprocFunctions type) 
        {
            _type = type;
        }



        public List<Point> GetPoints(double start=0, double end=200, double step=1) 
        {
            _points = new List<Point>();

            for (double i = start; i <= end; i += step) 
            {
                _points.Add(new Point(i, CalculateFunction(i)));
            }

            return _points;
        }

        private double CalculateFunction(double x)
        {
            switch (_type)
            {
                case ForAprocFunctions.cosXXsinX:
                    return Math.Cos(x * x) * Math.Sin(x);
                case ForAprocFunctions.tan:
                    return Math.Tan(x);
                case ForAprocFunctions.sin:
                    return Math.Sin(x);
                default:
                    return x;
            }
        }       
    }

    public enum ForAprocFunctions 
    {
        sin,
        cos,
        tan,
        tanH,
        cosXXsinX
    }
}
