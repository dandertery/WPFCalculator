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
            
        }

    }
}
