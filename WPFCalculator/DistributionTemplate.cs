using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp.Views;
using LiveChartsCore.Defaults;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;

namespace WPFCalculator
{
    internal abstract class DistributionTemplate
    {
        protected decimal[] range = new decimal[2];
        protected ObservablePoint[] pdfSet = new ObservablePoint[0]; //?
        protected ObservablePoint[] cumSet = new ObservablePoint[0];

        public DistributionTemplate(decimal lower, decimal higher, decimal var1, decimal var2)
        {
            int resolution = 5000;
            pdfSet = new ObservablePoint[resolution];
            decimal pitch = (higher - lower) / resolution;
            decimal x = lower;
            for (int i = 0; i < resolution; i++)
            {
                pdfSet[i] = new ObservablePoint((double)x, (double)CalculateProbability(x, var1, var2));
                x = x + pitch;
            }
            
        }
        public ObservablePoint[] GetPDFSet()
        {
            return pdfSet;
        }
        public ObservablePoint[] GetCumSet()
        {
            return cumSet;
        }
        public decimal[] GetDefaultRange()
        {
            return range;
        }



        protected abstract void CalculateDefaultRange();
        
        protected abstract decimal CalculateProbability(decimal inputOne, decimal inputTwo, decimal input3);
        protected abstract decimal CalculateCumulative(decimal inputOne, decimal inputTwo, decimal input3);

    }
}
