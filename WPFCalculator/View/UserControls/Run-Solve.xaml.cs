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
        private double ans = 0;


        private Variable E = new Variable();
        private Variable PI = new Variable();
        //private Variable ANS = new Variable();
        private string[] functionArray = { "cos", "sin", "log", "ln", "abs" }; //to determine nature of parsed function tokens
        private string[] operationArray = { "^", "*", "/", "-", "+" }; // to determine nature of parsed operation tokens
        struct Variable
        {
            public string letter;
            public double value;
        }
        public Run_Solve()
        {
            InitializeComponent();
        }
        private void InitialiseVariables() //Initialising variables for use in function/matrix definition
        {
            E.letter = "e";
            E.value = Math.E;
            PI.letter = "π";
            PI.value = Math.PI;
            
        }
        private void ClearableTextBox_RaiseUserInput(string inputParameter)
        {
            ProcessUserInput(inputParameter);
        }

        private void ProcessUserInput(string inputParameter)
        {
            
            string userInput = inputParameter;
            InputList.Items.Add(userInput);
            OutputList.Items.Add("");
            try
            {

                List<Variable> variableArray = new List<Variable>();
                variableArray.Add(E);
                variableArray.Add(PI);
                Parsing InputParsed = new Parsing(userInput);
                TreeNode abstractSyntaxTree = FindRoot(InputParsed.GetTree());
                double value = ProcessTree(abstractSyntaxTree, variableArray);
                ans = value;
                OutputList.Items.Add(ans);
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
        private double ProcessTree(TreeNode inputTree, List<Variable> varinputs) //recursive, top down
        {

            double value;

            if (inputTree.leftChild == null && inputTree.rightChild == null) //indicating double value / variable
            {

                if (Double.TryParse(inputTree.token.contents, out value))
                {
                    return (double)value;
                }
                else
                {
                    for (int i = 0; i < varinputs.Count; i++)
                    {
                        if (inputTree.token.contents == varinputs[i].letter)
                        {
                            return varinputs[i].value;
                        }
                    }
                }
            }
            else if (inputTree.leftChild == null) //indicating function
            {
                double rightValue = ProcessTree(inputTree.rightChild, varinputs);
                int index = -1;
                for (int i = 0; i < functionArray.Length; i++)
                {
                    if (inputTree.token.contents == functionArray[i])
                    {
                        index = i;
                    }
                }
                if (index == -1)
                {
                    throw new Exception("function not found in list");
                }
                switch (index)
                {
                    case 0:
                        return Math.Cos(rightValue);

                    case 1:
                        return Math.Sin(rightValue);

                    case 2:
                        return Math.Log10(rightValue);

                    case 3:
                        return Math.Log(rightValue);
                    case 4:
                        return Math.Abs(rightValue);

                }
            }
            else //indicating operation
            {
                double leftValue = ProcessTree(inputTree.leftChild, varinputs);
                double rightValue = ProcessTree(inputTree.rightChild, varinputs);
                int index = -1;
                for (int i = 0; i < operationArray.Length; i++)
                {
                    if (inputTree.token.contents == operationArray[i])
                    {
                        index = i;
                    }
                }

                switch (index)
                {
                    case 0:
                        return Math.Pow(leftValue, rightValue);

                    case 1:
                        return leftValue * rightValue;

                    case 2:
                        return leftValue / rightValue;

                    case 3:
                        return leftValue - rightValue;

                    case 4:
                        return leftValue + rightValue;

                }
            }
            return -1;

        }

    }
}
