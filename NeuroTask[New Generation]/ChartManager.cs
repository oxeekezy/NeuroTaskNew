using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace NeuronsTask
{
    internal class ChartManager
    {
        private Chart _chart { get; set; }
        public ChartManager(Chart chart) 
        {
            _chart = chart;
        }

        public void SetSeries(string seriesName, Color color, params Point[] points) 
        {
            if (_chart.Series.FindByName(seriesName) != null)
                _chart.Series.Remove(_chart.Series[seriesName]);

            _chart.Series.Add(seriesName);
            _chart.Series[seriesName].ChartType = SeriesChartType.Line;
            _chart.Series[seriesName].BorderWidth = 2;
            _chart.Series[seriesName].Color = color;

            foreach (var point in points) 
            {
                _chart.Series[seriesName].Points.AddXY(point.X, point.Y);
            }
        }

        public void SetPointSeries(string pointName, Color color, params Point[] points) 
        {
            if (_chart.Series.FindByName(pointName) != null)
                _chart.Series.Remove(_chart.Series[pointName]);

            _chart.Series.Add(pointName);
            _chart.Series[pointName].ChartType = SeriesChartType.Point;
            _chart.Series[pointName].BorderWidth = 2;
            _chart.Series[pointName].Color = color;

            foreach (var point in points)
            {
                _chart.Series[pointName].Points.AddXY(point.X, point.Y);
            }

        }
    }
}
