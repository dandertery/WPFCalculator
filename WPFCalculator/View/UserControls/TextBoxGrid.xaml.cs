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
        public TextBoxGrid()
        {
            
            InitializeComponent();
            for (int i = 0; i < n; i++)
            {
                gridXAML.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < m; i++)
            {
                gridXAML.RowDefinitions.Add(new RowDefinition());
            }
            List<TextBox> textBoxes = new List<TextBox>();
            int f = 0;
            for (int i = 0; i < n; i++)
            {
                for (int z = 0; z < m; z++)
                {
                    textBoxes.Add(new TextBox());
                    gridXAML.Children.Add(textBoxes[f]);
                    f++;
                }
            }
        }
        private int n;

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        private int m;

        public int M
        {
            get { return m; }
            set { m = value; }
        }


    }
}
