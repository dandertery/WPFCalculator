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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for DBExample.xaml
    /// </summary>
    public partial class DBExample : Window, INotifyPropertyChanged
    {
        public DBExample()
        {
            DataContext = this;
            InitializeComponent();
        }
        private string boundText;
        public event PropertyChangedEventHandler? PropertyChanged;
        public string BoundText
        {
            get { return boundText; }
            set
            {
                boundText = value;
                OnPropertyChanged("BoundText");

            }
        }
        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            BoundText = "set from code";
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
