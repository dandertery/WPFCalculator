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
    internal class FunctionValueMap
    {

        private TreeNode AST;
        ObservablePoint[] functionMap;
        
        public FunctionValueMap(TreeNode abstractSyntaxTree, double xMin, double xMax, double yMin, double yMax)
        {
            AST = abstractSyntaxTree;


            double x = xMin;
            int resolution = 5000; //coordinates
            functionMap = new ObservablePoint[resolution];
            double pitch = (xMax - xMin) / resolution;

            for (int i = 0; i < resolution; i++)
            {
                ProcessAST process = new ProcessAST(AST, 0, x);
                double y = process.GetResult();
                if(yMin > y || yMax < y)
                {
                    
                }
                else
                {
                    functionMap[i] = new ObservablePoint(x, y);
                }
                x = x + pitch;
            }


        }

        public ObservablePoint[] GetObservablePointArray()
        {
            return functionMap;
        }
    }
}
