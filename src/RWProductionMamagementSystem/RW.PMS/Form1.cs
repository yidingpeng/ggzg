using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ChartValues<double> chs = new ChartValues<double>();
        ChartValues<double> chs1 = new ChartValues<double>();

        private void Form1_Load(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title="扭矩",
                    Values = chs,
                    PointGeometrySize = 8,
                    StrokeThickness = 2,
                    ScalesYAt=0
                },
                new LineSeries
                {
                    Title="角度",
                    Values = chs1,
                    PointGeometrySize = 8,
                    StrokeThickness = 2,
                    ScalesYAt=1
                }
            };

            //cartesianChart1.AxisX.Add(new Axis
            //{
            //    DisableAnimations = true,
            //   // LabelFormatter = value => new DateTime((long)value).ToString("mm:ss"),
            //    //Separator = new Separator
            //    //{
            //    //    Step = TimeSpan.FromSeconds(1).Ticks
            //    //}
            //});

            cartesianChart1.AxisY.Add(new Axis
            {
                Foreground = System.Windows.Media.Brushes.DodgerBlue,
                Title = "扭矩 Nm"
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                Foreground = System.Windows.Media.Brushes.IndianRed,
                Title = "角度 °",
                Position = AxisPosition.RightTop
            });

            List<double> list = new List<double>() {  9, 6, 5, 7, 8, 9, 7, 6, 7, 5 };
            chs.AddRange(list);
            cartesianChart1.Series.Add(new StepLineSeries
            {
                Values = chs
            });
        }
    }
}
