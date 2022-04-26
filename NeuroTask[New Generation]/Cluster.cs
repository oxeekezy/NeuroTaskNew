using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronsTask
{
    internal class Cluster
    {
        public int clusterId { get; set; }
        public string name { get; set; }
        public Color color { get; set; }
        public Point startPoint { get; set; }
        public List<Point> points { get; set; }

        public Cluster(string name, Color color, Point point) 
        {
            this.name = name;
            this.color = color;
            startPoint = point;
        }

    }
}
