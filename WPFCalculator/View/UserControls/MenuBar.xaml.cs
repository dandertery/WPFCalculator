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
    public partial class MenuBar : UserControl
    {
        private string showUserControl = null;
        public MenuBar()
        {
            InitializeComponent();
        }
    

        public event Action<string> RaiseUserControlShown;

        private void RunSolveButton_Click(object sender, RoutedEventArgs e)
        {
            showUserControl = "RunSolve";
            RaiseUserControlShown(showUserControl);
        }

        private void GraphingButton_Click(object sender, RoutedEventArgs e)
        {
            showUserControl = "Graphing";
            RaiseUserControlShown(showUserControl);
        }

        private void StatsButton_Click(object sender, RoutedEventArgs e)
        {
            showUserControl = "Stats";
            RaiseUserControlShown(showUserControl);
        }

        private void EquationButton_Click(object sender, RoutedEventArgs e)
        {
            showUserControl = "Equation";
            RaiseUserControlShown(showUserControl);
        }

        private void RecursionButton_Click(object sender, RoutedEventArgs e)
        {
            showUserControl = "Recursion";
            RaiseUserControlShown(showUserControl);
        }
        


        
    }
}
