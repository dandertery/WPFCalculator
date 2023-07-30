using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator
{
    internal class ProcessAST
    {
        private Variable E = new Variable();
        private Variable PI = new Variable();
        private Variable ANS = new Variable();
        private Variable X = new Variable();
        private TreeNode AST;
        private string[] functionArray = { "cos", "sin", "log", "ln", "abs" }; //to determine nature of parsed function tokens
        private string[] operationArray = { "^", "*", "/", "-", "+" }; // to determine nature of parsed operation tokens
        struct Variable
        {
            public string letter;
            public decimal value;
        }
        private void InitialiseVariables() //Initialising variables for use in function/matrix definition
        {
            E.letter = "e";
            E.value = (decimal)Math.E;
            PI.letter = "π";
            PI.value = (decimal)Math.PI;
            ANS.letter = "A";
            ANS.value = 0;
            X.letter = "x";
            X.value = 0;

        }

        private decimal result = -1;
        public  ProcessAST(TreeNode abstractSyntaxTree, decimal ansValue, decimal xValue)
        {
            AST = abstractSyntaxTree;
            InitialiseVariables();
            ANS.value = ansValue;
            X.value = xValue;
            result = Process();
        }
        public decimal GetResult()
        {
            return result;

        }
        private decimal Process()
        {
            try
            {
                List<Variable> variableArray = new List<Variable>();
                variableArray.Add(E);
                variableArray.Add(PI);
                variableArray.Add(ANS);
                variableArray.Add(X);
                return ProcessTree(AST, variableArray);
            }
            catch (Exception)
            {

                return 18401840184018401840;
            }
        }
        private decimal ProcessTree(TreeNode inputTree, List<Variable> varinputs) //recursive, top down
        {

            decimal value;

            if (inputTree.leftChild == null && inputTree.rightChild == null) //indicating double value / variable
            {

                if (decimal.TryParse(inputTree.token.contents, out value))
                {
                    return (decimal)value;
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
                decimal rightValue = ProcessTree(inputTree.rightChild, varinputs);
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
                        return (decimal)Math.Cos((double)rightValue);

                    case 1:
                        return (decimal)Math.Sin((double)rightValue);

                    case 2:
                        return (decimal)Math.Log10((double)rightValue);

                    case 3:
                        return (decimal)Math.Log((double)rightValue);
                    case 4:
                        return (decimal)Math.Abs(rightValue);

                }
            }
            else //indicating operation
            {
                decimal leftValue = ProcessTree(inputTree.leftChild, varinputs);
                decimal rightValue = ProcessTree(inputTree.rightChild, varinputs);
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
                        return (decimal)Math.Pow((double)leftValue, (double)rightValue);

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
