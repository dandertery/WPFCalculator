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
    
    public partial class ClearableTextBox : UserControl
    {
        private string userInput;
        public ClearableTextBox()
        {
            InitializeComponent();
        }




        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            userInput = txtInput.Text;
            txtInput.Clear();
            txtInput.Focus();
            RaiseUserInput(userInput);
        }
        public event Action<string> RaiseUserInput;
        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtInput.Text))
            {
                tbPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                tbPlaceHolder.Visibility = Visibility.Hidden;
            }
        }
    }
}
