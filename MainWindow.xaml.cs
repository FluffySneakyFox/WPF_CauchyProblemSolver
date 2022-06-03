using System;
using System.Windows;
using WPF_CauchyProblemSolver.Classes;
using OxyPlot;
using OxyPlot.Series;

namespace WPF_CauchyProblemSolver
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private ICalculator GetCalculator()
        {
            ICalculator calc = new Euler();
            switch (Convert.ToInt32(MethodCB.SelectedIndex))
            {
                case 0:
                    calc = new Euler();
                    break;
                default:
                    _ = MessageBox.Show("Not implemented method!", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
                    break;
            }
            return calc;
        }

        private void DrawGraph(double start, double step, double[] dots)
        {
            //Clear old dots
           /* if(oxyPlotCanvas.Model.Series != null)
            {
                oxyPlotCanvas.Model.Series.Clear();
            }*/

            PlotModel plotModel = new PlotModel(){Title = "Graph"};
            LineSeries Series = new LineSeries();
            for (int i = 0; i < dots.Length; i++)
            {
                Series.Points.Add(new DataPoint(start+step*i, dots[i]));
            }
            plotModel.Series.Add(Series);
            oxyPlotCanvas.Model = plotModel;
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            //Get data from form
            double
                start = Convert.ToDouble(StartTB.Text),
                end = Convert.ToDouble(EndTB.Text),
                step = Convert.ToDouble(StepTB.Text),
                f0 = Convert.ToDouble(CauchyTB.Text);
            ICalculator calc = GetCalculator();

            
            Func<double, double> testFunc = x => 1/(2*Math.Sqrt(x));
            //https://github.com/Firestorm01X2/MathDotNetTest/blob/main/MathDotNetTest/Program.cs

            //Solve problem
            double[] diffEqDots = calc.Calculate(start, end, step, testFunc, f0);

            //Draw graph
            DrawGraph(start,step,diffEqDots);
        }
    }
}
