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
    internal class BinomialDist
    {
        protected ObservablePoint[] pdfSet = new ObservablePoint[0]; //?
        protected ObservablePoint[] cumSet = new ObservablePoint[0];

        public BinomialDist(int lower, int higher, int n, decimal p)
        {
            int setLength = higher - lower + 1; //+1?
            pdfSet = new ObservablePoint[setLength];
            
            int x = lower;
            for (int i = 0; i < setLength; i++)
            {
                pdfSet[i] = new ObservablePoint((double)x, (double)CalculateProbability(x, n, p));
                x = x + 1;
            }
            cumSet = new ObservablePoint[setLength];
            for (int i = 0; i < setLength; i++)
            {
                cumSet[i] = new ObservablePoint(pdfSet[i].X, CalculateCumulative(i, pdfSet));
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

        private int Factorial(int r)
        {
            if(r < 2)
            {
                return 1;
            }
            else
            {
                return r * Factorial(r - 1);
            }
        }

        private decimal CalculateProbability(int x, int n, decimal p)
        {
            int combinations = Factorial(n) / (Factorial(x) * Factorial(n - x));
            decimal q = 1 - p;
            decimal prob = (decimal)(combinations * Math.Pow((double)p,x) * Math.Pow((double)q, n-x));
            return prob;
        }
        private double CalculateCumulative(int index, ObservablePoint[] inputCum)
        {
            double sum = 0;
            for (int i = 0; i < index+1; i++)
            {
                sum = sum + (double)inputCum[i].Y;
            }
            return sum;
        }
    }
}
