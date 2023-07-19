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
    
    public partial class Key : UserControl
    {
        private string keyString;

        private KeyboardWindow keyboardParent;
        public Key()
        {
            
            keyboardParent = (KeyboardWindow)Window.GetWindow(this);
            InitializeComponent();
            
            
        }
        private string placeholder;

        public string Placeholder
        {   
            get { return placeholder; }
            set 
            {
                placeholder = value;
                buttonLocal.Content = placeholder;
                keyString = placeholder;
            }

        }


        private void buttonLocal_Click(object sender, RoutedEventArgs e)
        {
            keyboardParent.SendKey(keyString);
        }
    }
}
