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
using LiveChartsCore.Drawing;
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
using System.Drawing;

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


            public void GenerateFunction(string input, double xMinLocal, double xMaxLocal, double yMinLocal, double yMaxLocal)
            {
                function = input;
                Parsing functionParse = new Parsing(function);
                abstractSyntaxTree = functionParse.GetTree();

                FunctionValueMap coordinateMap = new FunctionValueMap(abstractSyntaxTree, xMinLocal, xMaxLocal, yMinLocal, yMaxLocal);
                points = coordinateMap.GetObservablePointArray();
                
            }

            public ObservablePoint[] GetPoints()
            {

                return points;
            }
            public string GetFunctionName()
            {
                return function;
            }
            
            
        }
        public Graphing()
        {



            DataContext = this;
            functions = new ObservableCollection<string>();

            InitializeComponent();
            double rangeDefault = 10; //edit this
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
            functionsConcatenated = new ObservablePoint[0];   
            if(functionList.Count > 0)
            {
                List<ObservablePoint> pointsList = new List<ObservablePoint>();

                for (int i = 0; i < functionList.Count; i++)
                {
                    for (int z = 0; z < functionList[i].GetPoints().Length; z++)
                    {
                        pointsList.Add(functionList[i].GetPoints()[z]);
                    }
                    pointsList.Add(null);
                    
                }
                functionsConcatenated = new ObservablePoint[pointsList.Count];
                for (int i = 0; i < pointsList.Count; i++)
                {
                    functionsConcatenated[i] = pointsList[i];
                }
            }

        }


        private void GenerateGraph()
        {
            CompileFunctions();
            vals = new ISeries[] //initialise
            {
                new LineSeries<ObservablePoint> // range
                {
                    LineSmoothness = 0,
                    DataPadding = new LvcPoint(0,0),
                    Values = functionsConcatenated,
                    Fill = null,
                    GeometrySize = 0,
                    Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
                    //TooltipLabelFormatter = (chartPoint) => $"({RoundTo(chartPoint.SecondaryValue, 4)}, {RoundTo(chartPoint.PrimaryValue, 4)})"

                },
                new LineSeries<ObservablePoint> // range
                {
                    DataPadding = new LvcPoint(0,0),
                    Values = new ObservablePoint[2] {new ObservablePoint(xMin,yMin), new ObservablePoint(xMax,yMax)},
                    Fill = null,
                    GeometrySize = 0,
                    Stroke = null


                },

                new LineSeries<ObservablePoint> // x Axis
                {
                    DataPadding = new LvcPoint(0,0),
                    Values = new ObservablePoint[2] {new ObservablePoint(xMin,0), new ObservablePoint(xMax,0)},
                    Stroke = new SolidColorPaint(SKColors.Black) { StrokeThickness = 3 },
                    Fill = null,
                    GeometrySize = 0,



                },
                new LineSeries<ObservablePoint> // y Axis
                {
                    DataPadding = new LvcPoint(0,0),
                    Values = new ObservablePoint[2] {new ObservablePoint(0,yMin), new ObservablePoint(0,yMax)},
                    Stroke = new SolidColorPaint(SKColors.Black) { StrokeThickness = 3 },
                    Fill = null,
                    GeometrySize = 0,

                    //TooltipLabelFormatter = (chartPoint) => $"({RoundTo(chartPoint.SecondaryValue, 4)}, {RoundTo(chartPoint.PrimaryValue, 4)})"


                },


}           ;
            OnPropertyChanged("Vals");
        }
        private ISeries[] vals { get; set; } = new ISeries[]
        {


        };


        private void AddFunctionToList(string input)
        {
            string functionExpression = input;
            Function functionToAdd = new Function();
            functionToAdd.GenerateFunction(functionExpression, xMin, xMax, yMin, yMax);
            functionList.Add(functionToAdd);
            GenerateGraph();
        }
        private void RemoveFunctionFromList(string selectedItem)
        {
            for (int i = 0; i < functionList.Count; i++)
            {
                if((preface + functionList[i].GetFunctionName()) == selectedItem)
                {
                    functionList.RemoveAt(i);
                }
            }
            GenerateGraph();
        }
        private void ClearFunctionList()
        {
            functionList.Clear();
            GenerateGraph();
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
            RemoveFunctionFromList(selectedItem);
            functions.Remove(selectedItem);
        }

        private ObservableCollection<string> functions;

        public ObservableCollection<string> Functions
        {
            get { return functions; }
            set { functions = value; }
        }

        private void OnRangeChange()
        {
            for (int i = 0; i < functionList.Count; i++)
            {
                Function tempFunction = new Function();
                tempFunction.GenerateFunction(functionList[i].GetFunctionName(), xMin, xMax, yMin, yMax);
                functionList[i] = tempFunction;
            }
            GenerateGraph();
        }

        private void xLowerTbx_TextChanged(object sender, TextChangedEventArgs e) //issue with xmax small xmax big?
        {
            try
            {
                
                double temp = double.Parse(xLowerTbx.Text);
                if(temp < xMax)
                {
                    xMin = temp;
                    OnRangeChange();
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
                    OnRangeChange();
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
                    OnRangeChange();
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
                    OnRangeChange();
                }
            }
            catch (Exception)
            {


            }

        }
    }
}
