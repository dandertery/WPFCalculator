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
using System.Windows.Shapes;

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for KeyboardWindow.xaml
    /// </summary>
    public partial class KeyboardWindow : Window
    {
        private MainWindow parent;
        public KeyboardWindow(MainWindow inputParent)
        {
            parent = inputParent;
            InitializeComponent();
        }


        public void SendKey(string keyContent)
        {
            parent.ProcessKey(keyContent);
        }

        private void Key_RaisePress(string obj)
        {
            SendKey(obj);
        }
    }
}
