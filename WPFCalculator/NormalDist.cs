using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator
{
    internal class NormalDist : DistributionTemplate
    {
        public NormalDist(decimal lower, decimal higher, decimal var1, decimal var2) : base(lower, higher, var1, var2)
        {
        }
        protected override decimal CalculateCumulative(decimal inputOne, decimal inputTwo, decimal inputThree)
        {
            decimal value = inputOne;
            decimal m = inputTwo;
            decimal s = inputThree; //standard deviation
            Dictionary<string, decimal> ms = new Dictionary<string, decimal>();
            ms.Add("M", m);
            ms.Add("S", s);
            if (value == decimal.MaxValue)
            {
                return 1;
            }
            else if (value == decimal.MinValue)
            {
                return 0;
            }
            else
            {
                string function = "(1/(S*π*2))*(e^(-0.5*((x-M)^2)/S^2))";
                IntegralSolver gaussianIntegral = new IntegralSolver(function, decimal.MinValue.ToString(), value.ToString(), variables: ms);
                return gaussianIntegral.GetSolution();
            }
        }

        protected override decimal CalculateProbability(decimal xInput, decimal meanInput, decimal sd)
        {
            decimal mean = meanInput;
            decimal standardDeviation = sd;
            //decimal variance = (decimal)Math.Pow((double)sd, 2);
            decimal x = xInput;
            return (1 / (standardDeviation * (decimal)(Math.Sqrt(2 * Math.PI)))) * (decimal)Math.Pow(Math.E, ((-0.5) * Math.Pow((double)((x-mean)/standardDeviation), 2)));
        }

        protected override void CalculateDefaultRange()
        {
            
        }
        protected override decimal CalculateRangeProbability(decimal lower, decimal higher, decimal mean, decimal sd)
        {
            return CalculateCumulative(higher, mean, sd) - CalculateCumulative(lower, mean, sd);
        }


    }
}
