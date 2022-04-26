using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroTask_New_Generation_
{
    internal class LayeredNetwork
    {
        public Layer[] layers;
        public double S = 1;
        public LayeredNetwork(int[] networkParam, NeuronActivateFunction[] activateFunctions, bool[] b)
        {
            layers = new Layer[networkParam.Length];
            for (int i = 0; i < networkParam.Length; i++)
            {
                AddNewLayer(networkParam[i], activateFunctions[i], i == 0 ? null : layers[i - 1], i, b[i]); ;
            }
        }

        private void AddNewLayer(int countNeiron, NeuronActivateFunction type, Layer prev, int i, bool b)
        {
            if (i == 0)
                layers[i] = (new Layer(countNeiron, type, prev, true));
            else
                layers[i] = (new Layer(countNeiron, type, prev, false, b));
        }

        internal List<double> GetOut()
        {
            return layers.Last().GetOut(S);
        }

        internal double[,] GetLastWidth()
        {
            return layers.Last().GetWidthLast();
        }

        internal void ChangeInpN(List<double> list)
        {
            layers[0].Changeinpn(list);
        }

        internal void ChangeWtwoLay(List<double> inpz)
        {
            S = (inpz.Sum() / inpz.Count) / 2;
            S = S / 4;
            layers[1].ChangeWidth(inpz);
        }

        internal Neuron GetLastNeiron()
        {
            return layers.Last()._neurons[0];
        }
    }
}
