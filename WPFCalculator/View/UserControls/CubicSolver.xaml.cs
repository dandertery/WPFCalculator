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

    public partial class CubicSolver : UserControl
    {
        string prefix = "Root: ";
        public CubicSolver()
        {
            InitializeComponent();
        }
        private void genButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal a = decimal.Parse(aInputBox.Text);
                decimal b = decimal.Parse(bInputBox.Text);
                decimal c = decimal.Parse(cInputBox.Text);
                decimal d = decimal.Parse(cInputBox.Text);
                decimal[] coefficients = { a, b, c, d };    
                PolySolver polySolver = new PolySolver(coefficients); //REEEUSEEEE
                decimal[] roots = polySolver.GetRoots();
                string[] rootStrings = new string[roots.Length];
                for (int i = 0; i < roots.Length; i++)
                {
                    if (roots[i] == decimal.MaxValue)
                    {
                        rootStrings[i] = prefix + "error";
                    }
                    else
                    {
                        rootStrings[i] = prefix + roots[i];
                    }
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
