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
using System.Collections.ObjectModel;
using LiveChartsCore.Defaults;
using SkiaSharp.Views;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Runtime;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;
using Microsoft.Win32;

namespace WPFCalculator.View.UserControls
{

    public partial class Graphing : UserControl, INotifyPropertyChanged 
    {
        ObservablePoint[] functionsConcatenated;
        double xMin; double xMax;
        string preface = "y = ";
        double yMin; double yMax;
        List<Function> functionList = new List<Function>();

        struct Function
        {
            string function;
            TreeNode abstractSyntaxTree;
            ObservablePoint[] points;


            public void GenerateFunction(string input)
            {
                function = input;
                Parsing functionParse = new Parsing(function);
                abstractSyntaxTree = functionParse.GetTree();

                FunctionValueMap coordinateMap = new FunctionValueMap(abstractSyntaxTree);
                points = coordinateMap.GetObservablePointArray();
                
            }
            
            
        }
        public Graphing()
        {



            DataContext = this;
            functions = new ObservableCollection<string>();

            InitializeComponent();
            double rangeDefault = 100; //edit this
            xMin = rangeDefault * -1; yMin = rangeDefault * -1;
            xMax = rangeDefault; yMax = rangeDefault;
            xLowerTbx.Text = xMin.ToString();
            xUpperTbx.Text = xMax.ToString();
            yLowerTbx.Text = yMin.ToString();
            yUpperTbx.Text = yMax.ToString();

            cartChart.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.CompareAllTakeClosest;
            cartChart.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Bottom;
            cartChart.EasingFunction = null;

            GenerateGraph();


        }

        private void CompileFunctions()
        {

        }


        private void GenerateGraph()
        {
            vals = new ISeries[] //initialise
            {
                new LineSeries<ObservablePoint> // range
                {
                    Values = functionsConcatenated,
                    Fill = null,
                    GeometrySize = 0,
                    Stroke = null


                },
                new LineSeries<ObservablePoint> // range
                {
                    Values = new ObservablePoint[2] {new ObservablePoint(xMin,yMin), new ObservablePoint(xMax,yMax)},
                    Fill = null,
                    GeometrySize = 0,
                    Stroke = null


                },

                new LineSeries<ObservablePoint> // x Axis
                {
                    Values = new ObservablePoint[2] {new ObservablePoint(xMin,0), new ObservablePoint(xMax,0)},
                    Stroke = new SolidColorPaint(SKColors.Black) { StrokeThickness = 3 },
                    Fill = null,
                    GeometrySize = 0,



                },
                new LineSeries<ObservablePoint> // y Axis
                {
                    Values = new ObservablePoint[2] {new ObservablePoint(0,yMin), new ObservablePoint(0,yMax)},
                    Stroke = new SolidColorPaint(SKColors.Black) { StrokeThickness = 3 },
                    Fill = null,
                    GeometrySize = 0,




                },


}           ;
            OnPropertyChanged("Vals");
        }
        private ISeries[] vals { get; set; } = new ISeries[]
        {

                new LineSeries<ObservablePoint> //GET RID OF THESE?
                {
                    Values = new ObservablePoint[0],
                    Fill = null,
                    GeometrySize = 0,
                    //TooltipLabelFormatter = (chartPoint) => $"({RoundTo(chartPoint.SecondaryValue, 4)}, {RoundTo(chartPoint.PrimaryValue, 4)})"

                },
                new LineSeries<ObservablePoint> // define range
                {
                    Values = new ObservablePoint[0],
                    Fill = null,
                    GeometrySize = 0,
                    //TooltipLabelFormatter = (chartPoint) => $"({RoundTo(chartPoint.SecondaryValue, 4)}, {RoundTo(chartPoint.PrimaryValue, 4)})"

                },

        };


        private void AddFunctionToList(string input)
        {
            string functionExpression = input;
            Function functionToAdd = new Function();
            
        }
        private void RemoveFunctionFromList()
        {

        }
        private void ClearFunctionList()
        {
            functionList.Clear();
        }

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
            functions.Add(preface + input);
            AddFunctionToList(input);
            


        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Functions.Clear();
            ClearFunctionList();
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = (string)functionListView.SelectedItem;
            functions.Remove(selectedItem);
        }

        private ObservableCollection<string> functions;

        public ObservableCollection<string> Functions
        {
            get { return functions; }
            set { functions = value; }
        }

        private void xLowerTbx_TextChanged(object sender, TextChangedEventArgs e) //issue with xmax small xmax big?
        {
            try
            {
                
                double temp = double.Parse(xLowerTbx.Text);
                if(temp < xMax)
                {
                    xMin = temp;
                }
            }
            catch (Exception)
            {

                
            }
        }

        private void xUpperTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                double temp = double.Parse(xUpperTbx.Text);
                if (temp > xMin)
                {
                    xMax = temp;
                }
            }
            catch (Exception)
            {


            }
        }

        private void yLowerTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                double temp = double.Parse(yLowerTbx.Text);
                if (temp < yMax)
                {
                    yMin = temp;
                }
            }
            catch (Exception)
            {


            }
        }

        private void yUpperTbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                double temp = double.Parse(yUpperTbx.Text);
                if (temp > yMin)
                {
                    yMax = temp;
                }
            }
            catch (Exception)
            {


            }

        }
    }
}
