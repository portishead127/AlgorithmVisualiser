using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiserProto
{
    internal class BubbleSort : SortingAlgorithm
    {
        public override int[] Sort(int[] array)
        {
            int currentIndex = -1;
            int comparedIndex = -1;
            int pass = 0;
            AddAlgorithmState(currentIndex, comparedIndex, array, pass);
            for (int i = 0; i < array.Length-1; i++)
            {
                pass++;
                currentIndex = -1;
                comparedIndex = -1;
                AddAlgorithmState(currentIndex, comparedIndex, array, pass);
                bool swapped = false;
                for (currentIndex = 0; currentIndex < array.Length - 1 - i; currentIndex++)
                {
                    comparedIndex = currentIndex + 1;

                    if (array[currentIndex] > array[comparedIndex])
                    {
                        swapped = true;
                        AddAlgorithmState(currentIndex, comparedIndex, array, pass);
                        Swap(array, currentIndex, comparedIndex);
                    }
                    AddAlgorithmState(currentIndex, comparedIndex, array, pass);
                }
                if (!swapped)
                {
                    break; // Array is sorted
                }
            }
            return array;
        }
    }
}
