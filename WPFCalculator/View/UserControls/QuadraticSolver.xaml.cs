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
    /// Interaction logic for QuadraticSolver.xaml
    /// </summary>
    public partial class QuadraticSolver : UserControl
    {
        string prefix = "Root: ";
        public QuadraticSolver()
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

                decimal root1 = SolveQuad(a, b, c, 1);
                decimal root2 = SolveQuad(a, b, c, -1);
                if(root1 == decimal.MaxValue)
                {
                    rtTxt1.Text = prefix + "error";
                }
                else
                {
                    rtTxt1.Text = prefix + root1;
                }
                if(root2 == decimal.MaxValue)
                {
                    rtTxt2.Text = prefix + "error";
                }
                else
                {
                    rtTxt2.Text = prefix + root2;
                }
            }
            catch (Exception)
            {
                rtTxt1.Text = "error";
                rtTxt2.Text = "error";
                
            }
        }
        
        private decimal SolveQuad(decimal a, decimal b, decimal c, decimal coefficient)
        {
            decimal discriminant = (decimal)Math.Pow((double)b, 2) - (4 * a * c);
            if(discriminant >= 0)
            {
                decimal rooted = (decimal)Math.Sqrt((double)discriminant);
                decimal numerator = -b + (coefficient * rooted);
                return numerator / (2 * a);
            }
            return decimal.MaxValue;
            
        }
    }
}
