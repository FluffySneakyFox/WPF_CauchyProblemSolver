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
                case 1:
                    calc = new EulerMod();
                    break;
                default:
                    _ = MessageBox.Show("Not implemented method!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
            return calc;
        }

        private void DrawGraph(double start, double step, double[] dots)
        {
            //Oxyplot preparation
            PlotModel plotModel = new PlotModel() { Title = "Cauchy ptoblem solution" };
            LineSeries Series = new LineSeries();
            //Adding calculated dots to series
            for (int i = 0; i < dots.Length; i++)
            {
                Series.Points.Add(new DataPoint(start + step * i, dots[i]));
            }
            //Attaching data and drawing
            plotModel.Series.Add(Series);
            oxyPlotCanvas.Model = plotModel;
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            //Get data from form
            double start = Convert.ToDouble(StartTB.Text);
            double end = Convert.ToDouble(EndTB.Text);
            double step = Convert.ToDouble(StepTB.Text);
            double f0 = Convert.ToDouble(CauchyTB.Text);
            //Get calculator with choosed method
            ICalculator Calculator = GetCalculator();
            //1-param diff equation written as delegate
            Func<double, double> testFunc = x => 3 * Math.Pow(x, 2) + 6 * x - 4 * Math.Pow(x, 3);
            //Solve problem (calculate dots coordinates)
            double[] diffEqDots = Calculator.Calculate(start, end, step, testFunc, f0);
            //Draw graph
            DrawGraph(start, step, diffEqDots);
        }
    }
}
