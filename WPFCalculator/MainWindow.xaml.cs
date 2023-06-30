using System.Windows;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
namespace WPFCalculator
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            KeyboardWindow keyboardWindow = new KeyboardWindow();
            keyboardWindow.Show();
            DBExample example = new DBExample();
            example.Show();
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
