using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroTask_New_Generation_
{
    internal class Neuron
    {
        double[] _weights;
        double _output = 0;
        Neuron[] _inputN;
        NeuronActivateFunction _type;
        double? _bias = null;
        bool _first;

        public Neuron(NeuronActivateFunction funcType, double[] weight, double value, double? bias = null)
        {
            _type = funcType;
            _weights = weight;
            _output = value;
            _bias = bias;
        }
        public Neuron(double value, bool itisfirst)
        {
            _output = value;
            _first = itisfirst;
        }

        internal double GetOutputResult(double x = 1)
        {
            if (_first)
                return _output;
            double newX = 0;
            for (int i = 0; i < _inputN.Length; i++)
                newX += _inputN[i].GetOutputResult(x) * _weights[i];
            newX += _bias.HasValue ? _bias.Value : 0;
            _output = NeuronActivateFunction.radialBasics == _type ? GetRadialBasisResult(x) : GetFunctionResult(newX);
            return _output;
        }

        private double GetRadialBasisResult(double x)
        {
            double outF = 0;
            for (int i = 0; i < _inputN.Length; i++)
                outF += Math.Pow((_inputN[i]._output - _weights[i]), 2);
            return Math.Pow(Math.E, -(Math.Pow((Math.Sqrt(outF) / (x / 0.8326)), 2)));

        }

        internal int GetWeightsCount()
        {
            return _first ? 0 : _inputN.Count();
        }

        internal void ChengeWeights(double delta, int index, double eta)
        {
            _weights[index] += eta * delta * _inputN[index]._output;
        }

        internal void ChangeInputs(List<double> inputs)
        {
            foreach (var n in _inputN)
            {
                n._output = inputs.First();
                inputs.RemoveAt(0);
            }
        }

        internal double[,] GetWidth()
        {
            double[,] v = new double[1, _weights.Length];
            for (int i = 0; i < _weights.Length; i++)
            {
                v[0, i] = _weights[i];
            }
            return v;

        }

        internal double GetWeightByIndex(int j)
        {
            return _weights[j];
        }
        internal void ChangeWeightByIndex(int i, double w)
        {
            _weights[i] = w;
        }

        internal void ChangeLayerWeights(double obh, double _delta, double[,] maswidth)
        {
            if (!_first)
                for (int i = 0; i < _weights.Length; i++)
                {
                    _weights[i] += obh * _delta * (maswidth.GetLength(1) != 1 ? maswidth[0, i] : 1) * _inputN[i]._output;
                    if (_bias.HasValue)
                        _bias += obh * _delta * (maswidth.GetLength(1) != 1 ? maswidth[0, i] : 1);
                }
        }
        internal void ChangeOutput(double something)
        {
            _output = something;
        }

        public double GetOutVal()
        {
            return _output;
        }

        public NeuronActivateFunction GetTypeF()
        {
            return _type;
        }

        public void AddInputN(Neuron[] input)
        {
            _inputN = input;
        }

        public double GetFunctionResult(double x)
        {
            switch (_type)
            {
                case NeuronActivateFunction.sigmoid:
                    return 1 / (1 + Math.Pow(Math.E, -x));
                case NeuronActivateFunction.linear:
                    return x;
                case NeuronActivateFunction.gaus:
                    return Math.Pow(Math.E, -Math.Pow(x, 2));
                default: return 0;
            }
        }
    }
}
