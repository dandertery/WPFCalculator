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
        private ObservablePoint[] pdfSet = new ObservablePoint[0]; //?
        private ObservablePoint[] cumSet = new ObservablePoint[0];


        public ObservablePoint[] GetPDFSet()
        {
            return pdfSet;
        }
        public ObservablePoint[] GetCumSet()
        {
            return cumSet;
        }
    }
}
