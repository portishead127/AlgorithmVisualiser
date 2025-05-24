using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualisationTool
{
    internal class InsertionSort : SortingAlgorithm
    {
        int currentIndex = -1;
        int comparedIndex = -1;
        int pass = 0;
        public override int[] Sort(int[] array)
        {
            pass = 0;
            AddAlgorithmState(currentIndex, comparedIndex, array, pass);
            for(int i = 1; i < array.Length; i++)
            {
                pass++;
                currentIndex = -1;
                comparedIndex = -1;
                AddAlgorithmState(currentIndex, comparedIndex, array, pass);
                currentIndex = i;
                comparedIndex = i - 1;
                while(comparedIndex >= 0 && array[currentIndex] < array[comparedIndex])
                {
                    AddAlgorithmState(currentIndex, comparedIndex, array, pass);
                    Swap(array, currentIndex, comparedIndex);
                    AddAlgorithmState(currentIndex, comparedIndex, array, pass);
                    currentIndex = comparedIndex;
                    comparedIndex--;
                }
            }
            return array;
        }
    }
}
