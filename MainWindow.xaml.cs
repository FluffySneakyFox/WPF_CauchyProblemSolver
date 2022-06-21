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
                case 2:
                    calc = new RungeCutta();
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
            PlotModel plotModel = new PlotModel() { Title = EquationTB.Text };
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
            Func<double, double> testFunc = x => 0.5 / Math.Sqrt(x);
            //Solve problem (calculate dots coordinates)
            double[] diffEqDots = Calculator.Calculate(start, end, step, testFunc, f0);
            //_ = MessageBox.Show(diffEqDots[diffEqDots.Length - 1].ToString());
            //Draw graph
            DrawGraph(start, step, diffEqDots);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //patch
            _ = MessageBox.Show("Not implemented yet.", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
        }
    }
}
