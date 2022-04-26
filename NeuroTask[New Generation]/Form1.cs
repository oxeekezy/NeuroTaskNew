using NeuronsTask;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Colors = System.Drawing.Color;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NeuroTask_New_Generation_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        AprocReadyFunction func;
        ChartManager manager;
        Kohanen kohanen;
        List<Point> original;
        List<Tuple<string, ForAprocFunctions>> functions = new List<Tuple<string, ForAprocFunctions>>()
            {
                new Tuple<string,ForAprocFunctions>("Cos(X * X) * Sin(X)",ForAprocFunctions.cosXXsinX),
                new Tuple<string,ForAprocFunctions>("Tan(X)",ForAprocFunctions.tan),
                new Tuple<string,ForAprocFunctions>("Sin(X)",ForAprocFunctions.sin),
            };
        int hiddenNeurons = 25;


        private void RadialBasicsBtn_Click(object sender, EventArgs e)
        {
            Teacher teacherNet = new Teacher();
            LayeredNetwork radialNetwork = new LayeredNetwork(new int[] { 1, hiddenNeurons, 1 }, new NeuronActivateFunction[] 
            {
                NeuronActivateFunction.linear, 
                NeuronActivateFunction.radialBasics, 
                NeuronActivateFunction.linear 
            }, 
            new bool[]
            { 
                false, 
                false, 
                false, 
                false 
            });


            //teacherNet.Bazis(radialNetwork, func, 300000, 0.0000001,original);
            teacherNet.Bazis(radialNetwork, func, 10000, 0.0000001,original);
            radialNetwork.ChangeInpN(new List<double> {2});
            MessageBox.Show($"Result: {radialNetwork.GetOut().First()}");

            
            List<Point> approc = new List<Point>();


            for (double i = 0; i <= 20; i += 2) 
            {
                radialNetwork.ChangeInpN(new List<double> {i});
                approc.Add(new Point(i,radialNetwork.GetOut().First()));
            }

            
            manager.SetSeries("approc", System.Drawing.Color.Blue, approc.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            manager = new ChartManager(MainChart);
            hiddenNeuronsCount.Text = hiddenNeurons.ToString();

            foreach (var f in functions)
                function.Items.Add(f.Item1);

            function.SelectedIndex = 0;
        }

        private void function_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartCleaner(MainChart);
            foreach (var f in functions) 
            {
                if (f.Item1 == function.SelectedItem.ToString()) 
                {
                    func = new AprocReadyFunction(f.Item2);
                    break;
                }
            }

            original = func.GetPoints(0, 20, 1);
            manager.SetSeries("original", System.Drawing.Color.Red, original.ToArray());
        }

        private void hiddenNeuronsCount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void hiddenNeuronsCount_ValueChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(hiddenNeuronsCount.Value.ToString(), out int count))
                MessageBox.Show("Imposible count!");
            else hiddenNeurons = count;
        }

        private void KohanenBtn_Click(object sender, EventArgs e)
        {
            
            if (double.TryParse(xBox.Text, out double x) && double.TryParse(yBox.Text, out double y))
            {
                if(kohanen==null)
                    kohanen = new Kohanen
                    (
                        MainChart, 
                        1000, 
                        0.001, 
                        new Cluster("Red cluster", Colors.Red, new Point(3,8)),  
                        new Cluster("Blue cluster", Colors.Blue, new Point(5,-5)),  
                        new Cluster("Pink cluster", Colors.DeepPink, new Point(0,-4))  
                    );
                MessageBox.Show(kohanen.CheckPoint(new Point(x, y)));
            }
            else 
            {
                MessageBox.Show("Imposible!");
            }
        }

        private void ChartCleaner(Chart chart) 
        {
            if(chart.Series.Count > 0)
                chart.Series.Clear();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void spline_CheckedChanged(object sender, EventArgs e)
        {if(spline.Checked)
                foreach(var s in MainChart.Series)
                    s.ChartType = SeriesChartType.Spline;
            
        }

        private void fastline_CheckedChanged(object sender, EventArgs e)
        {
            if (fastline.Checked)
                foreach (var s in MainChart.Series)
                    s.ChartType = SeriesChartType.FastLine;
        }

        private void line_CheckedChanged(object sender, EventArgs e)
        {
            if (line.Checked)
                foreach (var s in MainChart.Series)
                    s.ChartType = SeriesChartType.Line;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChartCleaner(MainChart);
        }
    }
}
