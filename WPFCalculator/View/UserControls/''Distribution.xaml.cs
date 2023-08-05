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

namespace WPFCalculator.View.UserControls
{
    /// <summary>
    /// Interaction logic for __Distribution.xaml
    /// </summary>
    public partial class __Distribution : UserControl
    {
        string dist;
        public __Distribution()
        {
            InitializeComponent();
        }
        private void Show2()
        {
            var2Label.Visibility = Visibility.Visible;
            var2Input.Visibility = Visibility.Visible;
        }
        public void setDistribution(string distInput)
        {
            dist = distInput;
            switch (dist)
            {
                case ("normal"):
                    Show2();
                    var1Label.Text = "Mean:";
                    var2Label.Text = "SD:";
                    break;
                case ("bin"):
                    Show2();
                    var1Label.Text = "n:";
                    var2Label.Text = "p";
                    break;
                case ("poisson"):
                    var1Label.Text = "mew:";
                    var2Label.Visibility = Visibility.Hidden;
                    var2Input.Visibility = Visibility.Hidden;
                    break;
                case ("t"):
                    var1Label.Text = "df:";
                    var2Label.Visibility = Visibility.Hidden;
                    var2Input.Visibility = Visibility.Hidden;
                    break;
                case ("mtth"):
                    Show2();
                    var1Label.Text = "MTTH: ";
                    var2Label.Text = "Unit(Optional):";
                    break;

            }
        }

        private void enterProbButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void probModeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lowerTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void upperTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void probTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void genBtn_Click(object sender, RoutedEventArgs e)
        {
            decimal var1 = decimal.Parse(var1Input.Text);
            decimal var2 = decimal.Parse(var2Input.Text);
        }

    }
}
