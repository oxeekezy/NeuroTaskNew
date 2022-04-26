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

        public Kohanen(Chart chart, int cluster, int epoch, double lRate) 
        {
            _clusterCount = cluster;
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
            List<Point> cluster1 = GenClasterbyOrigin(4, 4, 20);
            List<Point> cluster2 = GenClasterbyOrigin(4, -4, 20);
            List<Point> cluster3 = GenClasterbyOrigin(-5, 4, 20);
            List<List<Point>> clusters = new List<List<Point>>() {cluster1,cluster2,cluster3};

            manager.SetPointSeries("cluster1", Color.Red, cluster1.ToArray());
            manager.SetPointSeries("cluster2", Color.Blue, cluster2.ToArray());
            manager.SetPointSeries("cluster3", Color.DeepPink, cluster3.ToArray());
            

            points.AddRange(cluster1);
            points.AddRange(cluster2);
            points.AddRange(cluster3);

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

            
            Dictionary<int, int> resultsD = new Dictionary<int, int>();

            for (int c = 0; c < clusters.Count; c++) 
            {
                foreach (var p in clusters[c]) 
                {
                    List<double> result2 = new List<double>();
                    for (int i = 0; i < weightsMatrix.GetLength(0); i++)
                    {
                        Vector weight = new Vector(weightsMatrix[i, 0], weightsMatrix[i, 1]);

                        double res = weight * new Vector(p.X, p.Y);
                        result2.Add(res);
                    }
                    double max = result2.Max();
                    int index2 = result2.IndexOf(max);

                    //resultsD.Add(c,index2);
                    Debug.Write($"Original: {c}\tNeuronus: {index2}\n");
                }
                Debug.Write($"\n\n");
            }

            

            //result = "Кластер № "/* +(index2 + 1).ToString()*/;
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

            return "Кластер № "+(index2 + 1).ToString();
        }

        List<Point> GenClasterbyOrigin(double x, double y, int count)
        {
            List<Point> result = new List<Point>();

            result.Add(new Point(x, y));

            for (int i = 0; i < count; i++)
            {
                result.Add(new Point(x + rand.NextDouble(), y + rand.NextDouble()));
            }

            return result;
        }

        public override string ToString()
        {
            return result.ToString();
        }
    }
}
