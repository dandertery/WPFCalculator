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
    /// Interaction logic for OutputGrid.xaml
    /// </summary>
    public partial class OutputGrid : UserControl
    {
        private int n;
        private int m;
        private List<TextBlock>? textBlocks;
        private List<TextBlock> headerBlocks;
        public OutputGrid(int nInput, int mInput, decimal[,] valueInput)
        {
            n = nInput;
            m = mInput;
            int headedN = n + 2;
            int headedM = m + 2;
            InitializeComponent();
            for (int i = 0; i < headedN; i++)
            {
                gridXAML2.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < headedM; i++)
            {
                gridXAML2.RowDefinitions.Add(new RowDefinition());
            }
            textBlocks = new List<TextBlock>();
            headerBlocks = new List<TextBlock>();
            int f = 0;
            for (int i = 1; i < headedN-1; i++)
            {
                TextBlock hb = new TextBlock();
                hb.Text = ((char)(64 + i)).ToString();
                hb.FontSize = 20;
                hb.HorizontalAlignment = HorizontalAlignment.Center;
                hb.VerticalAlignment = VerticalAlignment.Center;
                headerBlocks.Add(hb);
                gridXAML2.Children.Add(headerBlocks[f]);
                Grid.SetColumn(headerBlocks[f], i);
                Grid.SetRow(headerBlocks[f], 0);
                f++;
                
                
            }
            TextBlock ttb = new TextBlock();
            ttb.Text = "Total";
            ttb.FontSize = 20;
            ttb.HorizontalAlignment = HorizontalAlignment.Center;
            ttb.VerticalAlignment = VerticalAlignment.Center;
            
            headerBlocks.Add(ttb);
            gridXAML2.Children.Add(headerBlocks[f]);
            Grid.SetColumn(headerBlocks[f], headedN-1);
            Grid.SetRow(headerBlocks[f], 0);

            f++;

            for (int i = 1; i < headedM - 1; i++)
            {
                TextBlock hb = new TextBlock();
                hb.Text = (i).ToString();
                hb.FontSize = 20;
                hb.HorizontalAlignment = HorizontalAlignment.Center;
                hb.VerticalAlignment = VerticalAlignment.Center;
                headerBlocks.Add(hb);
                gridXAML2.Children.Add(headerBlocks[f]);
                Grid.SetColumn(headerBlocks[f], 0);
                Grid.SetRow(headerBlocks[f], i);
                f++;


            }
            TextBlock ttb2 = new TextBlock();
            ttb2.Text = "Total";
            ttb2.FontSize = 20;
            ttb2.HorizontalAlignment = HorizontalAlignment.Center;
            ttb2.VerticalAlignment = VerticalAlignment.Center;
            headerBlocks.Add(ttb2);
            gridXAML2.Children.Add(headerBlocks[f]);
            Grid.SetColumn(headerBlocks[f], 0);
            Grid.SetRow(headerBlocks[f], headedM -1);
            //f++;

            f = 0;
            for (int i = 1; i < headedN; i++)
            {
                for (int z = 1; z < headedM; z++)
                {
                    TextBlock tb = new TextBlock();
                    tb.Text = valueInput[i - 1, z - 1].ToString();
                    tb.FontSize = 20;
                    tb.HorizontalAlignment = HorizontalAlignment.Center;
                    tb.VerticalAlignment = VerticalAlignment.Center;
                    tb.TextWrapping = TextWrapping.Wrap;
                    textBlocks.Add(tb);
                    gridXAML2.Children.Add(textBlocks[f]);
                    Grid.SetColumn(textBlocks[f], i);
                    Grid.SetRow(textBlocks[f], z);
                    f++;
                }
            }

        }
    }
}
