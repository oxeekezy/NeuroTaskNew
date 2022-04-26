using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace NeuronsTask
{
    internal class Kohanen
    {
        ChartManager manager { get; set; }
        Random rand { get; set; }
        string result { get; set; }

        int _clusterCount;
        int _epoch;

        double _learningRate;
        double[,] weightsMatrix;

        Dictionary<int, int> numeration;

        public Kohanen(Chart chart, int epoch, double lRate, params Cluster[] clusters)
        {
            _clusterCount = clusters.Length;
            _epoch = epoch;
            _learningRate = lRate;
            manager = new ChartManager(chart);
            rand = new Random(1);
            weightsMatrix = new double[_clusterCount, 2];

            for (int i = 0; i < weightsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < weightsMatrix.GetLength(1); j++)
                {
                    weightsMatrix[i, j] = rand.NextDouble();
                }
            }

            

            List<Point> points = new List<Point>();
            List<Point> trustedPoints = new List<Point>();
            List<Cluster> allClusters = new List<Cluster>();

            foreach (var tp in clusters)
            {
                Cluster cluster = new Cluster(tp.name, tp.color, tp.startPoint);
                cluster.points = GenClasterbyOrigin(cluster.startPoint, 35);
                points.AddRange(cluster.points);
                trustedPoints.Add(cluster.startPoint);
                allClusters.Add(cluster);
            }

            numeration = RepairNumeration(trustedPoints.ToList());

            int ii = 0;
            foreach(var c in allClusters)
            {
                manager.SetPointSeries(c.name, c.color, c.points.ToArray());
                ii++;
            }

            Learn(points);
        }

        private Dictionary<int, int> RepairNumeration(List<Point> trs_pts) 
        {
            Dictionary<int,int> newNumeration = new Dictionary<int,int>();

            for (int i = 0; i < trs_pts.Count; i++)
            {
                List<double> result = new List<double>();
                Point testPoint = trs_pts[i];

                for (int j = 0; j < weightsMatrix.GetLength(0); j++) 
                {
                    var weight  = new Vector(weightsMatrix[j, 0], weightsMatrix[j, 1]);
                    result.Add(weight * new Vector(testPoint.X, testPoint.Y));
                }

                var max = result.Max();
                var index = result.IndexOf(max);

                newNumeration.Add(i,index);

                Debug.Write($"{i} -- {index}\n");
            }

            return newNumeration;
        }

        private void Learn(List<Point> points)
        {
            for (int ep = 0; ep < _epoch; ep++)
            {
                for (int k = 0; k < points.Count; k++)
                {
                    List<double> result = new List<double>();
                    Vector x = new Vector(points[k].X, points[k].Y);
                    for (int i = 0; i < weightsMatrix.GetLength(0); i++)
                    {

                        Vector weight = new Vector(weightsMatrix[i, 0], weightsMatrix[i, 1]);

                        double res = weight * x;
                        result.Add(res);
                    }

                    double min = result.Min();
                    int index = result.IndexOf(min);

                    Vector oldvector = new Vector(weightsMatrix[index, 0], weightsMatrix[index, 1]);
                    Vector newWeight = oldvector + (_learningRate ^ (x - oldvector));

                    weightsMatrix[index, 0] = newWeight.X;
                    weightsMatrix[index, 1] = newWeight.Y;
                }
            }
        }

        public string CheckPoint(Point point) 
        {
            manager.SetPointSeries("test point", Color.Aqua, point);

            List<double> result2 = new List<double>();
            for (int i = 0; i < weightsMatrix.GetLength(0); i++)
            {
                Vector weight = new Vector(weightsMatrix[i, 0], weightsMatrix[i, 1]);

                double res = weight * new Vector(point.X, point.Y);
                result2.Add(res);
            }

            double max = result2.Max();
            int index2 = result2.IndexOf(max);
            
            return "Кластер № "+numeration.First(x=>x.Value==index2).Key.ToString();
        }

        List<Point> GenClasterbyOrigin(Point point, int count)
        {
            List<Point> result = new List<Point>();

            result.Add(point);

            for (int i = 0; i < count; i++)
            {
                result.Add(new Point(point.X + rand.NextDouble(), point.Y + rand.NextDouble()));
            }

            return result;
        }

        public override string ToString()
        {
            return result.ToString();
        }
    }
}
