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
            exeButton.IsEnabled = false;
            yatesCheckBox.Visibility = Visibility.Hidden;
            yatesLabel.Visibility = Visibility.Hidden;
        }
        private TextBoxGrid tbGrid;
        private OutputGrid outputGrid;
        private int n;
        private int m;
        private bool yates = false;
        private string chiPrefix = "chi statistic = ";
        private decimal[,] inputArray;
        private decimal[,] outputArray;
        private void genButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                n = int.Parse(nInput.Text);
                m = int.Parse(mInput.Text);
                if (n < 27 && m < 27 && m > 1 && n > 1)
                {
                    if(n == 2 && m == 2)
                    {
                        yatesCheckBox.Visibility=Visibility.Visible;
                        yatesLabel.Visibility=Visibility.Visible;
                    }
                    else
                    {
                        yatesCheckBox.Visibility = Visibility.Hidden;
                        yatesLabel.Visibility = Visibility.Hidden;
                        yates = false;
                        yatesCheckBox.IsChecked=false;
                    }
                    gridContainer.Children.Clear();
                    outputGridContainer.Children.Clear();
                    tbGrid = new TextBoxGrid(n, m);
                    gridContainer.Children.Add(tbGrid);
                    exeButton.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {

            }


        }

        private void exeButton_Click(object sender, RoutedEventArgs e)
        {
            outputGridContainer.Children.Clear();
            inputArray = tbGrid.getInputArray();
            outputArray = CalculateExpected(inputArray);
            outputGrid = new OutputGrid(n, m, outputArray);
            outputGridContainer.Children.Add(outputGrid);
        }

        private decimal[,] CalculateExpected(decimal[,] input)
        {
            decimal[,] inputWithTotal = new decimal[n+1,m+1];
            for (int i = 0; i < n; i++)
            {
                for (int z = 0; z < m; z++)
                {
                    inputWithTotal[i, z] = input[i, z];
                }
            }
            for (int i = 0; i < m; i++)
            {
                decimal sum = 0;
                for (int z  = 0; z < n; z++)
                {
                    sum = sum + inputWithTotal[z, i];
                }
                inputWithTotal[n, i] = sum;
            }
            for (int i = 0; i < n+1; i++)
            {
                decimal sum = 0;
                for (int z = 0; z < m; z++)
                {   
                    sum = sum + inputWithTotal[i, z];
                }
                inputWithTotal[i, m] = sum;
            }
            decimal totFreq = inputWithTotal[n, m];
            decimal[,] outputWithTotal = new decimal[n+1,m+1];
            for (int i = 0; i < n+1; i++)
            {
                for (int z = 0; z < m+1; z++)
                {
                    outputWithTotal[i, z] = inputWithTotal[i, z];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int z = 0; z < m; z++)
                {
                    decimal ev = (inputWithTotal[n, z] * inputWithTotal[i, m]) / totFreq;
                    outputWithTotal[i,z] = ev;
                }
            }
            return outputWithTotal;



        }

        private void calcChiButton_Click(object sender, RoutedEventArgs e)
        {
            if(yates)
            {

            }
            else
            {
                decimal chiSum = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int z = 0; z < m; z++)
                    {
                        decimal observed = inputArray[i, z];
                        decimal expected = outputArray[i, z];
                        chiSum = chiSum + ((decimal)Math.Pow((double)(observed - expected), 2) / outputArray[i, z]);
                    }
                }
                chiOutput.Text = chiPrefix + chiSum;

            }
        }

        private void yatesCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            yates = !yates;
            
        }

        private void yatesCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            yates = !yates;
        }
    }
}
