using System.Windows;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
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
namespace WPFCalculator
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            KeyboardWindow keyboardWindow = new KeyboardWindow(this);
            keyboardWindow.Show();
            
                //DBExample example = new DBExample();
            //example.Show();
            RunSolveContent.Visibility = Visibility.Hidden;
            RecursionContent.Visibility = Visibility.Hidden;
            GraphingContent.Visibility = Visibility.Hidden;
            StatsContent.Visibility = Visibility.Hidden;
            EquationContent.Visibility = Visibility.Hidden;
            //menuBar.RunSolvePressed += RunSolvePress(sender, e);





        }
        private void RunSolvePress(object sender, System.EventArgs e)
        {

        }

        public void ProcessKey(string keyContent)
        {
            try
            {
                TextBox selectedBox = (TextBox)FocusManager.GetFocusedElement(this);
                try
                {
                    int digit = Convert.ToInt32(keyContent);
                    selectedBox.Text = selectedBox.Text + digit;
                    // work on number
                }
                catch (System.Exception)
                {

                    switch (keyContent)
                    {
                        case "∫":
                            IntegrationWindow integrationWindow = new IntegrationWindow();
                            integrationWindow.Show();
                            break;
                        case ".":
                            break;
                        case "ANS":
                            break;
                        case "(":
                            break;
                        case ")":
                            break;
                        case "DEL":
                            break;
                        case "OPTN":
                            break;
                        case "MAT":
                            break;
                        case "RESTART":
                            break;
                        case "DEG/RADIAN":
                            break;
                        case "i":
                            break;
                        case "sin":
                            break;
                        case "cos":
                            break;
                        case "ln":
                            break;
                        case "log(a,b)":
                            break;
                        case "e":
                            break;
                        case "π":
                            break;
                        case "^":
                            break;
                        case "*":
                            break;
                        case "+":
                            break;
                        case "/":
                            break;
                        case "-":
                            break;
                        case "TRIG/HYPERB":
                            break;

                        case "EXIT":
                            break;
                        case "S/D":
                            break;
                    }
                }
            }
            catch (Exception)
            {

                
            }
            

        }

        private void menuBar_RaiseUserControlShown(string toBeShown)
        {
            ShowThisHideOthers(toBeShown);
        }

        private void ShowThisHideOthers(string userControl)
        {
            RunSolveContent.Visibility = Visibility.Hidden;
            RecursionContent.Visibility = Visibility.Hidden;
            GraphingContent.Visibility = Visibility.Hidden;
            StatsContent.Visibility = Visibility.Hidden;
            EquationContent.Visibility = Visibility.Hidden;
            if (userControl != null)
            {

                if(userControl == "RunSolve")
                {
                    RunSolveContent.Visibility=Visibility.Visible;
                }
                else if(userControl == "Graphing")
                {
                    GraphingContent.Visibility = Visibility.Visible;
                }
                else if (userControl == "Stats")
                {
                    StatsContent.Visibility = Visibility.Visible;

                }
                else if (userControl == "Recursion")
                {
                    RecursionContent.Visibility = Visibility.Visible;
                }
                else if (userControl == "Equation")
                {
                    EquationContent.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
