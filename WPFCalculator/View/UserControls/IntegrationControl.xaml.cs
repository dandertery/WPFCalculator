﻿using System;
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

namespace WPFCalculator.View.UserControls
{
    /// <summary>
    /// Interaction logic for IntegrationControl.xaml
    /// </summary>
    /// 
    public partial class IntegrationControl : UserControl
    {
        public IntegrationControl()
        {
            InitializeComponent();

            
        }

        private void generateBtn_Click(object sender, RoutedEventArgs e)
        {
            string upperLimit = upperLimitTB.Text;
            string lowerLimit = lowerLimitTB.Text;
            string expression = functionTB.Text;
            IntegralSolver integralSolver = new IntegralSolver(expression, lowerLimit, upperLimit);
            double result = integralSolver.GetSolution();
            resultTB.Text = result.ToString();
        }
    }
}
