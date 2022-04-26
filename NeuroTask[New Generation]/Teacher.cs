using NeuroTask_New_Generation_;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronsTask
{
    internal class Teacher
    {
        ChengeW chengeW = new ChengeW();
        int epoch = 0;
        double reduce = 1;
        internal void OneNeiron(Neuron neiron, StreamReader data)
        {
            List<int> inpz = new List<int>();
            List<int> outz = new List<int>();
            while (!data.EndOfStream)
            {
                int[] b = data.ReadLine().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
                inpz.Add(b[0]);
                outz.Add(b[1]);
            }
            while (epoch <= 10000 && reduce >= 0.00000001)
            {
                reduce = 0;
                epoch++;
                for (int i = 0; i < inpz.Count; i++)
                {
                    neiron.ChangeInputs(new List<double>() { inpz[i] });
                    reduce += 0.5 * Math.Pow(neiron.GetOutputResult() - outz[i], 2);
                    chengeW.GetChange(neiron, outz[i], 0.001);
                }
            }

        }
        internal void OneLayerNet(LayeredNetwork lay, StreamReader data)
        {
            List<double> inpz = new List<double>();
            List<double> outz = new List<double>();
            while (!data.EndOfStream)
            {
                double[] b = data.ReadLine().Split(' ').Select(a => Convert.ToDouble(a)).ToArray();
                inpz.Add(b[0]);
                outz.Add(b[1]);
            }
            if (epoch != 0)
                epoch = 0;
            while (epoch <= 5000 && reduce >= 0.00000001)
            {
                reduce = 0;
                epoch++;
                for (int i = 0; i < inpz.Count; i++)
                {
                    foreach (double n in lay.GetOut().ToArray())
                    {
                        lay.ChangeInpN(new List<double>() { inpz[i] });
                        reduce += 0.5 * Math.Pow(n - outz[i], 2);
                        chengeW.GetChangeLayNet(lay, outz[i]);
                        Debug.WriteLine(lay.layers.Last()._neurons.Last().GetWidth()[0, 0]);
                    }
                }
            }

        }


        internal void Bazis(LayeredNetwork lay, AprocReadyFunction func, int epoches, double learningRate, List<Point> oroginalPoints)
        {
            List<double> inpz = new List<double>();
            List<double> outz = new List<double>();

            foreach (Point p in oroginalPoints) 
            {
                inpz.Add(p.X);
                outz.Add(p.Y);
            }

            if (epoch != 0)
                epoch = 0;
            else
                lay.ChangeWtwoLay(inpz);

            while (epoch <= epoches && reduce >= learningRate)
            {
                reduce = 0;
                epoch++;
                for (int i = 0; i < inpz.Count; i++)
                {
                    lay.ChangeInpN(new List<double>() { inpz[i] });
                    reduce += 0.5 * Math.Pow(lay.GetOut().First() - outz[i], 2);
                    chengeW.GetChange(lay.GetLastNeiron(), outz[i], 0.01, lay.S);
                }
            }

        }
    }

    class ChengeW
    {
        double _delta = 1;
        double[,] maswidth;
        double[,] oldwidth;
        internal void GetChange(Neuron N, double norm, double eta, double S = 1)
        {
            double o = N.GetOutputResult(S);
            _delta = (norm - o) * GetProizF(N.GetTypeF(), o);
            for (int i = 0; i < N.GetWeightsCount(); i++)
            {
                N.ChengeWeights (_delta, i, eta);
            }

        }

        private double GetProizF(NeuronActivateFunction type, double o)
        {
            if (type == NeuronActivateFunction.linear) //eta 1/100 
                return 1;
            if (type == NeuronActivateFunction.sigmoid) //eta 0.25
                return o * (1 - o);
            return 0;
        }

        internal void GetChangeLayNet(LayeredNetwork laynet, double norm)
        {
            maswidth = new double[,] { { 1 } };
            double rez = laynet.GetOut().Last();
            double eta = GetEta(laynet.layers.Last()._type);
            for (int i = laynet.layers.Length - 1; i > 0; i--)
            {
                GetChangeLay(laynet.layers[i], norm, eta, rez);
            }

        }

        private double GetEta(NeuronActivateFunction type)
        {
            if (type == NeuronActivateFunction.linear) //eta 1/100 
                return 0.0001;
            if (type == NeuronActivateFunction.sigmoid) //eta 0.25
                return 0.25;
            return 0;
        }

        internal void GetChangeLay(Layer lay, double norm, double eta, double rez)
        {
            double obh = eta * (norm - rez);
            oldwidth = lay.GetWidth();
            double[,] delti = new double[1, lay._neurons.Length];
            for (int i = 0; i < lay._neurons.Length; i++)
            {
                delti[0, i] = GetProizF(lay._type, lay._neurons[i].GetOutVal());
                lay._neurons[i].ChangeLayerWeights(obh, delti[0, i], maswidth);
            }
            maswidth = multiMatrix(delti, maswidth);
            maswidth = multiMatrix(oldwidth, maswidth);

        }

        private double[,] multiMatrix(double[,] a, double[,] b)
        {
            double[,] r = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < b.GetLength(1); j++)
                    for (int k = 0; k < b.GetLength(0); k++)
                        r[i, j] += a[i, j] * b[k, j];
            return r;
        }

    }
}
