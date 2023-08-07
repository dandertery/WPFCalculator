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
    /// Interaction logic for SampleAnalysis.xaml
    /// </summary>
    public partial class SampleAnalysis : UserControl
    {
        public SampleAnalysis()
        {
            InitializeComponent();
        }

        struct NumFreq
        {
            private decimal num;
            private int freq;

            public decimal Num
            {
                get { return num; }
                set { num = value; }
            }
            public int Freq
            {
                get { return freq; }
                set { freq = value; }
            }
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            decimal num = decimal.Parse(valueInput.Text);
            int freq = int.Parse(freqInput.Text);
            NumFreq numFreq = new NumFreq();
            numFreq.Freq = freq;
            numFreq.Num = num;
        }
    }
}
