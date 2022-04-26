using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroTask_New_Generation_
{
    internal class Layer
    {
        Random rnd = new Random();
        public Neuron[] _neurons;
        public NeuronActivateFunction _type;

        public Layer(int neuronsCount, NeuronActivateFunction type, Layer previousLayer, bool first = false, bool b = false)
        {
            _neurons = new Neuron[neuronsCount];
            _type = type;
            for (int i = 0; i < neuronsCount; i++)
            {
                _neurons[i] = (first ? new Neuron(0, first) : new Neuron(type, GenWeight(previousLayer._neurons.Length), 0, GetRandomB(b)));
                if (!first)
                {
                    _neurons[i].AddInputN(previousLayer._neurons);
                    _neurons[i].GetOutputResult();
                }
            }
        }

        private double? GetRandomB(bool b)
        {
            if (b)
                return rnd.NextDouble();
            else
                return null;
        }

        private double[] GenWeight(int countPrevious)
        {
            double[] w = new double[countPrevious];
            for (int i = 0; i < countPrevious; i++)
            {
                w[i] = rnd.NextDouble();
            }
            return w;
        }

        internal List<double> GetOut(double S)
        {
            List<double> outt = new List<double>();
            foreach (var n in _neurons)
            {
                outt.Add(n.GetOutputResult(S));
            }
            return outt;
        }

        internal double[,] GetWidthLast()
        {
            return _neurons.Last().GetWidth();
        }

        internal double[,] GetWidth()
        {
            double[,] v = new double[_neurons.Length, _neurons[0].GetWeightsCount()];
            for (int i = 0; i < _neurons.Length; i++)
            {
                for (int j = 0; j < _neurons[0].GetWeightsCount(); j++)
                {
                    v[i, j] = _neurons[i].GetWeightByIndex(j);
                }
            }
            return v;
        }
        internal void ChangeWidth(List<double> newWidth)
        {
            for (int n = 0; n < _neurons[0].GetWeightsCount(); n++)
            {
                List<double> ww = new List<double>(newWidth);
                foreach (var N in _neurons)
                {
                    int newI = rnd.Next(ww.Count - 1);
                    N.ChangeWeightByIndex(n, ww[newI]);
                    //ww.RemoveAt(newI);
                }
            }
        }

        internal void Changeinpn(List<double> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                _neurons[i].ChangeOutput(list[i]);
            }
        }
    }
}
