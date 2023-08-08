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
        }
        private TextBoxGrid tbGrid;
        private int n;
        private int m;
        private void genButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                n = int.Parse(nInput.Text);
                m = int.Parse(mInput.Text);
                if (n < 27 && m < 27)
                {
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
            decimal[,] inputArray = tbGrid.getInputArray();
            decimal[,] outputArray = CalculateExpected(inputArray);
        }

        private decimal[,] CalculateExpected(decimal[,] input)
        {
            
        }
    }
}
