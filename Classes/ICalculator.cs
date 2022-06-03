using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_CauchyProblemSolver.Classes
{
    interface ICalculator
    {
        public double[] Calculate(double start, double end, double step, Func<double,double> func, double f0);
    }
}
