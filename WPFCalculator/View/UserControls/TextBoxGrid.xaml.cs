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
    /// Interaction logic for TextBoxGrid.xaml
    /// </summary>
    public partial class TextBoxGrid : UserControl
    {
        private int n;
        private int m;
        private List<TextBox> textBoxes;
        private List<TextBlock>? totalBlocks;
        public TextBoxGrid(int nInput, int mInput)
        {
            n = nInput;
            m = mInput;
            int headedN = n + 2;
            int headedM = m + 2;
            InitializeComponent();
            for (int i = 0; i < headedN; i++)
            {
                gridXAML.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < headedM; i++)
            {
                gridXAML.RowDefinitions.Add(new RowDefinition());
            }
            textBoxes = new List<TextBox>();
            totalBlocks = new List<TextBlock>();
            int f = 0;
            for (int i = 1; i < headedN-1; i++)
            {
                for (int z = 1; z < headedM-1; z++)
                {
                    textBoxes.Add(new TextBox());
                    textBoxes[textBoxes.Count - 1].FontSize = 20;
                    textBoxes[textBoxes.Count - 1].HorizontalContentAlignment = HorizontalAlignment.Center;
                    textBoxes[textBoxes.Count - 1].VerticalContentAlignment = VerticalAlignment.Center;

                    gridXAML.Children.Add(textBoxes[f]);
                    Grid.SetColumn(textBoxes[f], i);
                    Grid.SetRow(textBoxes[f], z);     
                    f++;
                }
            }
            for (int i = 1; i < headedN-1; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = ((char)(64 + i)).ToString();
                tb.FontSize = 20;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                gridXAML.Children.Add((TextBlock)tb);
                Grid.SetRow(tb, 0);
                Grid.SetColumn(tb, i);
            }
            for (int i = 1; i < headedM-1; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = i.ToString();
                tb.FontSize = 20;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                gridXAML.Children.Add((TextBlock)tb);
                Grid.SetRow(tb, i);
                Grid.SetColumn(tb, 0);
            }
            TextBlock ttb = new TextBlock();
            ttb.Text = "Total";
            ttb.FontSize = 20;
            ttb.VerticalAlignment = VerticalAlignment.Center;
            ttb.HorizontalAlignment = HorizontalAlignment.Center;
            gridXAML.Children.Add((TextBlock)ttb);
            Grid.SetRow(ttb, headedN);
            Grid.SetColumn(ttb, 0);

            TextBlock ttb2 = new TextBlock();
            ttb2.Text = "Total";
            ttb2.FontSize = 20;
            ttb2.VerticalAlignment = VerticalAlignment.Center;
            ttb2.HorizontalAlignment = HorizontalAlignment.Center;
            gridXAML.Children.Add((TextBlock)ttb2);
            Grid.SetRow(ttb2, 0);
            Grid.SetColumn(ttb2, headedM);
            for (int i = 1; i < headedM-1; i++)
            {
                TextBlock tbl = new TextBlock();
                tbl.FontSize = 20;
                tbl.VerticalAlignment = VerticalAlignment.Center;
                tbl.HorizontalAlignment = HorizontalAlignment.Center;
                totalBlocks.Add(tbl);
                gridXAML.Children.Add(tbl);
                Grid.SetRow(tbl, i);
                Grid.SetColumn(tbl, headedN);
            }
            for (int i = 1; i < headedN; i++)
            {
                TextBlock tbl = new TextBlock();
                tbl.FontSize = 20;
                tbl.VerticalAlignment = VerticalAlignment.Center;
                tbl.HorizontalAlignment = HorizontalAlignment.Center;
                totalBlocks.Add(tbl);
                gridXAML.Children.Add(tbl);
                Grid.SetRow(tbl, headedM);
                Grid.SetColumn(tbl, i);
            }
        }

        public decimal[,] getInputArray()
        {
            return ConvertInput();
        }

        private decimal[,] ConvertInput()
        {
            
            decimal[,] inputArray = new decimal[n, m];
            int f = 0;
            for (int i = 0; i < n; i++)
            {
                for (int z = 0; z < m; z++)
                {
                    inputArray[i, z] = decimal.Parse(textBoxes[f].Text);
                    f++;
                }
            }
            int y = 0;
            for (int i = 0; i < m; i++)
            {
                decimal sum = 0;
                for (int z = 0; z < n; z++)
                {
                    sum = sum + inputArray[z, i];
                }
                totalBlocks[y].Text = sum.ToString();
                y++;

            }
            decimal overall = 0;
            for (int i = 0; i < n; i++)
            {
                decimal sum = 0;
                for (int z = 0; z < m; z++)
                {
                    sum = sum + inputArray[i, z];
                }
                totalBlocks[y].Text = sum.ToString();
                overall = overall + sum;
                y++;

            }
            totalBlocks[totalBlocks.Count-1].Text = overall.ToString(); 
            return inputArray;
        }



    }
}
