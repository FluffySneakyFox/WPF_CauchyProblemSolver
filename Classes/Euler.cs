using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CauchyProblemSolver.Classes
{
    class Euler : ICalculator
    {
        public double[] Calculate(double start, double end, double step, Func<double, double> diffEquation, double f0)
        {
            int dotsAmount = Convert.ToInt32((end - start) / step) + 1;
            double[] resultDots = new double[dotsAmount];

            resultDots[0] = f0;
            for (int i = 1; i < dotsAmount; i++)
            {
                //y[i] = y[i-1] + (x[i]-x[i-1])*f'(x)
                resultDots[i] = resultDots[i - 1] + step * diffEquation(start + step * i);
            }
            //resultDots[dotsAmount-1] = resultDots[dotsAmount - 2] + step * diffEquation(end);

            return resultDots;
        }
    }
}
