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
            //Cauchy problem
            resultDots[0] = f0;
            //Calc
            


            return resultDots;
        }
    }
}
