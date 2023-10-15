using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using LiveChartsCore.Defaults;
using SkiaSharp.Views;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Runtime;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;
using Microsoft.Win32;

namespace WPFCalculator
{
    internal class IntegralSolver
    {
        private TreeNode abstractSyntaxTree;
        private string expression;
        decimal solution;
        public IntegralSolver(string inputExpression, string lowerLimit, string upperLimit, Dictionary<string, decimal> variables = null)
        {
            int resolution = 500000;
            resolution = resolution * 2; // must be even 

            expression = inputExpression;
            decimal a = decimal.Parse(lowerLimit);
            decimal b = decimal.Parse(upperLimit);
            if(a == decimal.MinValue)
            {
                a = -10000; // this is a jank testing limit, use some formulation with SD later
            }
            if(b == decimal.MaxValue)
            {
                b = 10000; //^
            }
            Parsing parser = new Parsing(expression);
            abstractSyntaxTree = parser.GetTree();
            solution = Integrate(abstractSyntaxTree, resolution, a, b);
        }


        private decimal Integrate(TreeNode AST, int n, decimal lower, decimal upper, Dictionary<string, decimal> variables = null) // Simpson's rule
        {
            decimal h = (upper - lower) / n;
            decimal x = lower;
            decimal[] yPoints = new decimal[n];
            for (int i = 0; i < n; i++)
            {
                ProcessAST processAST = new ProcessAST(AST, 0, x);
                decimal yTemp = processAST.GetResult();
                yPoints[i] = yTemp;
                x = x + h;
            }

            decimal firstAndLast = yPoints[0] + yPoints[yPoints.Length-1];
            decimal odd = 0;
            decimal even = 0;

            for (int z = 1; z < yPoints.Length-1; z++)
            {
                if((z % 2) == 1)
                {
                    odd = odd + yPoints[z];
                }
                else
                {
                    even = even + yPoints[z];
                }
            }

            return (h / 3) * (firstAndLast + (4 * odd) + (2 * even));
        }
        public decimal GetSolution()
        {
            return solution;
        }
    }
}
