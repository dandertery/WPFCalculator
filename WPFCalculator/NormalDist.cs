using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator
{
    internal class NormalDist : DistributionTemplate
    {
        public override decimal CalculateCumulative(decimal inputOne, decimal inputTwo, decimal inputThree)
        {
            return 1; // implement
        }
        public override decimal CalculateProbability(decimal xInput, decimal meanInput, decimal sd)
        {
            decimal mean = meanInput;
            decimal standardDeviation = sd;
            //decimal variance = (decimal)Math.Pow((double)sd, 2);
            decimal x = xInput;
            return (1 / (standardDeviation * (decimal)(Math.Sqrt(2 * Math.PI)))) * (decimal)Math.Pow(Math.E, ((-0.5) * Math.Pow((double)((x-mean)/standardDeviation), 2)));
        }
    }
}
