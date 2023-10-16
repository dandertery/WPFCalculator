using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator
{
    internal class PolySolver
    {
        decimal[] roots;
        private int degree;
        private decimal[] coefficients;
        public PolySolver(decimal[] coeff)
        {
            coefficients = coeff;
            int degree = coeff.Length;
            roots = FindRoots();

        }
        private decimal Differential(TreeNode AST, decimal x)
        {
            decimal h = 0.0001M;
            decimal xplush = x + h;
            ProcessAST processX = new ProcessAST(AST, decimal.MinValue, x);
            ProcessAST processXPlusH = new ProcessAST(AST, decimal.MinValue, xplush);
            return (processXPlusH.GetResult() - processX.GetResult()) / h;
        }
        private decimal[] FindRoots() //no check for degree of polynomial yet
        {
            decimal[] output = new decimal[degree];
            decimal[] coeffReversed = (decimal[])coefficients.Reverse();
            string function = coeffReversed[1] + "x" + coeffReversed[0].ToString();

            for (int i = 2; i < degree; i++)
            {
                function = coeffReversed[i] + "x^" + i + " + " + function;
            }
            Parsing polyParse = new Parsing(function);
            TreeNode abstractSyntaxTree = polyParse.GetTree();

            decimal start = 0;
            decimal iteration = 0;
            decimal iterationStore = 0;
            decimal differenceStore = 0;
            for (int i = 0; i < degree; i++)
            {
                ////

                // once a suitable starting point has been found
                iteration = start; iterationStore = start;
                int n = 1000;
                for (int z  = 1; z < n; z++) // n is a placeholder
                {
                    ProcessAST processAST = new ProcessAST(abstractSyntaxTree, decimal.MinValue, iteration);
                    iteration = iteration - (processAST.GetResult()) / Differential(abstractSyntaxTree, iteration);
                    bool converging = false;
                    if(n - z < (n / 10)) // checking in the last few iterations
                    {
                        decimal difference = iteration - iterationStore;
                        if (Math.Abs(difference) < Math.Abs(differenceStore))
                        {
                            // ITS CONVERGING
                        }
                        differenceStore = difference;
                    }
                    //
                    ProcessAST startCheck = new ProcessAST(abstractSyntaxTree, decimal.MinValue, start);
                    ProcessAST iterationCheck = new ProcessAST(abstractSyntaxTree, decimal.MinValue, iteration);
                    if(startCheck.GetResult() - iterationCheck.GetResult() < 0)
                    {
                        // ITS NOT BLOODY FINDING IT IS IT
                    }
                    //
                    iterationStore = iteration;

                }


                //

            }





            
            return null;
        }
        public decimal[] GetRoots()
        {
            return roots;
        }
    }
}
