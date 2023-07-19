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
    
    public partial class Run_Solve : UserControl
    {
        private Variable ANS = new Variable();
        struct Variable
        {
            public string letter;
            public double value;
        }
        public Run_Solve()
        {
            InitializeComponent();
            ANS.letter = "A";
            ANS.value = 0;
            ansDisplay.Text = "ANS: " + ANS.value.ToString();
        }

        private void ClearableTextBox_RaiseUserInput(string inputParameter)
        {
            ProcessUserInput(inputParameter);
        }

        private void ProcessUserInput(string inputParameter)
        {
            
            string userInput = inputParameter;
            InputList.Items.Add(userInput);
            InputList.Items.Add("");
            OutputList.Items.Add("");
            try
            {
                Parsing InputParsed = new Parsing(userInput);
                TreeNode abstractSyntaxTree = FindRoot(InputParsed.GetTree());
                ProcessAST processAST = new ProcessAST(abstractSyntaxTree, ANS.value);

                double value = processAST.GetResult();
                ANS.value = value;
                ansDisplay.Text = "ANS: " + ANS.value.ToString();
                OutputList.Items.Add(ANS.value);
            }
            catch (Exception ex)
            {
                OutputList.Items.Add(ex.Message);
            }
        
            
        }
        private TreeNode FindRoot(TreeNode input) //Finding root of tree produced by Parser. Prevents a possible erroneous output from Parsing
        {
            TreeNode output = input;
            if (input.leftChild == null && input.rightChild == null)
            {
                if (input.token.tree != null)
                {
                    output = FindRoot(input.token.tree[0]);
                    return output;
                }
                else
                {
                    return output;
                }
            }
            else
            {

                return output;
            }
        }
       
        

    }
}
