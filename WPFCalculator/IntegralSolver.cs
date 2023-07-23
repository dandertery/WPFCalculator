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
        double solution;
        public IntegralSolver(string inputExpression, string lowerLimit, string upperLimit)
        {
            int resolution = 50000;
            resolution = resolution * 2; // must be even 

            expression = inputExpression;
            double a = double.Parse(lowerLimit);
            double b = double.Parse(upperLimit);

            Parsing parser = new Parsing(expression);
            abstractSyntaxTree = parser.GetTree();
            solution = Integrate(abstractSyntaxTree, resolution, a, b);
        }


        private double Integrate(TreeNode AST, int n, double lower, double upper) // Simpson's rule
        {
            double h = (upper - lower) / n;
            double x = lower;
            double[] yPoints = new double[n];
            for (int i = 0; i < n; i++)
            {
                ProcessAST processAST = new ProcessAST(AST, 0, x);
                double yTemp = processAST.GetResult();
                yPoints[i] = yTemp;
                x = x + h;
            }

            double firstAndLast = yPoints[0] + yPoints[yPoints.Length-1];
            double odd = 0;
            double even = 0;

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
        public double GetSolution()
        {
            return solution;
        }
    }
}
