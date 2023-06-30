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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WPFCalculator.View.UserControls
{
    /// <summary>
    /// Interaction logic for Graphing.xaml
    /// </summary>
    public partial class Graphing : UserControl, INotifyPropertyChanged
    {
        
        public Graphing()
        {
            DataContext = this;
            InitializeComponent();
            cartChart.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.CompareAllTakeClosest;
            cartChart.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Bottom;
            cartChart.EasingFunction = null;
        }
        private ISeries[] vals { get; set; } = new ISeries[]
        {

    
                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null,  
                    GeometrySize = 0,
                    //TooltipLabelFormatter = (chartPoint) => $"({RoundTo(chartPoint.SecondaryValue, 4)}, {RoundTo(chartPoint.PrimaryValue, 4)})"

                },

                new LineSeries<double>
                {
                    Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null,
                    GeometrySize = 0,
                    //TooltipLabelFormatter = (chartPoint) => $"({RoundTo(chartPoint.SecondaryValue, 4)}, {RoundTo(chartPoint.PrimaryValue, 4)})"

                }
        };


        public event PropertyChangedEventHandler? PropertyChanged;
        public ISeries[] Vals
        {
            get { return vals; }
            set
            {
                vals = value;
                OnPropertyChanged("Vals");

            }
        }
        private double RoundTo(double input, int sf)
        {
            return Math.Round(input, sf);
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ClearableTextBox_RaiseUserInput(string input)
        {
            functionListView.Items.Add("y = " + input);
        }
    }
}
