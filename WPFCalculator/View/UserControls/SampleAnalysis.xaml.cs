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
using System.Collections.ObjectModel;
namespace WPFCalculator.View.UserControls
{
    /// <summary>
    /// Interaction logic for SampleAnalysis.xaml
    /// </summary>
    public partial class SampleAnalysis : UserControl
    {
        public SampleAnalysis()
        {
            DataContext = this;
            entries = new ObservableCollection<string>();
            output = new ObservableCollection<string>();
            numberfrequencies = new List<NumFreq>();
            InitializeComponent();
            
        }
        private ObservableCollection<string> entries;
        private List<NumFreq> numberfrequencies;
        public ObservableCollection<string> Entries
        {
            get { return entries; }
            set { entries = value; }
        }

        private ObservableCollection<string> output;

        public ObservableCollection<string> Output
        {
            get { return output; }
            set { output = value; }
        }


        public struct NumFreq
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

            Entries.Add("Value: " + num + " Frequency: " + freq);
            numberfrequencies.Add(numFreq);


            valueInput.Text = "";
            freqInput.Text = "1";
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = lvEntries.SelectedIndex;
            string selectedItem = (string)lvEntries.SelectedItem;
            Entries.Remove(selectedItem);
            numberfrequencies.RemoveAt(index);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            Entries.Clear();
            numberfrequencies.Clear();
        }

        private void genButton_Click(object sender, RoutedEventArgs e)
        {
            if(entries.Count > 0)
            {
                Output.Clear();
                List<decimal> valueList = new List<decimal>();
                for (int i = 0; i < numberfrequencies.Count; i++)
                {
                    for (int z = 0; z < numberfrequencies[i].Freq; z++)
                    {
                        valueList.Add(numberfrequencies[i].Num);
                    }
                }
                int length = valueList.Count;
                // sum / mean
                decimal sum = 0;
                for (int i = 0; i < length; i++)
                {
                    sum = sum + valueList[i];
                }
                decimal mean = sum / length;
                Output.Add("Sum = " + sum);
                Output.Add("Mean = " + mean);
                // mode
                decimal modalNumberIndex = valueList[0];
                decimal numAtIndex;
                int maxFreq = 0;
                for (int i = 0; i < length; i++)
                {
                    numAtIndex = valueList[i];
                    int freq = 0;
                    for (int z = 0; z < length; z++)
                    {
                        if (valueList[z] == numAtIndex)
                        {
                            freq++;
                        }
                    }
                    if (freq > maxFreq)
                    {
                        maxFreq = freq;
                        modalNumberIndex = numAtIndex;
                    }

                }
                Output.Add("Mode = " + modalNumberIndex);
                // sigma
                // s
                // n
                // range
                decimal min = valueList.Min();
                decimal max = valueList.Max();
                decimal range = max - min;
                Output.Add("Range: " + range);
                // Q1
                // MED
                // Q3
            }




        }
    }
}
