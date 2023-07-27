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
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : UserControl
    {
        public Stats()
        {
            InitializeComponent();
            Hide();
        }
        private void Hide()
        {
            distributionUC.Visibility = Visibility.Hidden;
            piecewiseUC.Visibility = Visibility.Hidden;
            chiTestUC.Visibility = Visibility.Hidden;
            sampleAnalysisUC.Visibility = Visibility.Hidden;

        }
        private void normalDistButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            distributionUC.Visibility = Visibility.Visible;
        }

        private void binDistButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            distributionUC.Visibility = Visibility.Visible;
        }

        private void poissonDistButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            distributionUC.Visibility = Visibility.Visible;
        }

        private void tDistButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            distributionUC.Visibility = Visibility.Visible;
        }

        private void mtthDistButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            distributionUC.Visibility = Visibility.Visible;
        }

        private void piecewiseButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            piecewiseUC.Visibility = Visibility.Visible;
        }

        private void chiTestButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            chiTestUC.Visibility = Visibility.Visible;
        }

        private void sampleAnalysisButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            sampleAnalysisUC.Visibility = Visibility.Visible;
        }
    }
}
