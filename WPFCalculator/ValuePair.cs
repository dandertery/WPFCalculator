using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator
{
    
    struct fractionPair
    {
        private double value;
        private int index;
        private string representation;
    }
    internal class ValuePair
    {
        private double[] valueArray;
        private bool canAccessList = false;
        

        public ValuePair(bool defineList)
        {
            if(defineList)
            {
                defineValueList();
                canAccessList = true;
            }
            
        }
        public double getAtIndex(int index)
        {
            try
            {
                return valueArray[index];
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private void defineValueList()
        {
            List<double> valueList = new List<double>();
            double[] valueInputs = new double[3];
            valueInputs[0] = 1;
            valueInputs[1] = Math.PI;
            valueInputs[2] = Math.E;
            for (int v = 0; v < valueInputs.Length; v++)
            {
                for (int n = 0; n < 1001; n++)
                {
                    for (int d = 0; d < 1001; d++)
                    {
                        valueList.Add((v*n) / d);
                    }
                }
            }

            double[] valueArray = listToArray(valueList);
            valueArray = mergeSort(valueArray);



            
        }

        double[] listToArray(List<double> input)
        {
            double[] result = new double[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                result[i] = input[i];
            }
            return result;
        }

        double[] mergeSort(double[] list)
        {
            if (list.Length == 2)
            {
                if (list[0] > list[1])
                {
                    double temp = list[1]; list[1] = list[0]; list[0] = temp;
                }
            }
            else if (list.Length > 2)
            {
                int middle = ((list.Length + 1) / 2);
                double[] leftlist = new double[middle];
                double[] rightlist = new double[list.Length - middle];
                for (int i = 0; i < middle; i++)
                {
                    leftlist[i] = list[i];
                }
                for (int i = 0; i < list.Length - middle; i++)
                {
                    rightlist[i] = list[i + middle];
                }
                leftlist = mergeSort(leftlist); rightlist = mergeSort(rightlist); list = new double[leftlist.Length + rightlist.Length];
                int x = 0; int y = 0; int z = 0; // left list, right list, combined list indexes
                while (z < list.Length)
                {
                    if (x < leftlist.Length && y < rightlist.Length)
                    {
                        if (leftlist[x] < rightlist[y])
                        {
                            list[z] = leftlist[x];
                            x++;
                        }
                        else
                        {
                            list[z] = rightlist[y];
                            y++;
                        }
                    }
                    else if (x < leftlist.Length)
                    {
                        list[z] = leftlist[x];
                        x++;
                    }
                    else //if(y < rightlist.Length)
                    {
                        list[z] = rightlist[y];
                        y++;
                    }
                    z++;
                }
            }
            return list;
        }
    }


}
