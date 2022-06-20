using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CauchyProblemSolver.Classes
{
    class RungeCutta : ICalculator
    {
        public double[] Calculate(double start, double end, double step, Func<double, double> diffEquation, double f0)
        {
            //Data prep
            int dotsAmount = Convert.ToInt32((end - start) / step) + 1;
            double[] resultDots = new double[dotsAmount];
            double[] k = new double[4];
            //Cauchy problem
            resultDots[0] = f0;
            //Calc
            for (int i = 1; i < dotsAmount; i++)
            {
                k[0] = diffEquation(start + step * (i - 1));
                k[1] = diffEquation(start + step * (i - 1) + step / 2);
                k[2] = diffEquation(start + step * (i - 1) + step / 2);
                k[3] = diffEquation(start + step * (i - 1) + step);
                resultDots[i] = resultDots[i - 1] + step * (k[0] + 2 * k[1] + 2 * k[2] + k[3]) / 6;
            }
            return resultDots;
        }
    }
}
