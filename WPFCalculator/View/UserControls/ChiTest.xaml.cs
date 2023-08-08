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
using WPFCalculator.View.UserControls;

namespace WPFCalculator.View.UserControls
{
    /// <summary>
    /// Interaction logic for ChiTest.xaml
    /// </summary>
    public partial class ChiTest : UserControl
    {
        public ChiTest()
        {
            InitializeComponent();
        }

        private void genButton_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(nInput.Text);
            int m = int.Parse(mInput.Text);

            TextBoxGrid tbGrid = new TextBoxGrid();
            tbGrid.N = n;
            tbGrid.M = m;
            gridContainer.Children.Add(tbGrid);
        }
    }
}
