using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    internal class InsertionSort : SortingAlgorithm
    {
        public InsertionSort(int[] array, SortingAlgorithmVisualiser visualiser) : base(array, visualiser) { }

        public override void Sort()
        {
            for (int i = 1; i <= array.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && j != array.Length - 1)
                {
                    if (array[j] > array[j+1])
                    {
                        visualiser.DisplayNextFrame(new SortingFrame(array, new int[] { j }, new int[] { i }, null));
                        // Swap elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        // Highlight the swapped indices
                    }
                    j--;
                }
            }
            CompletionAnimation(array);
        }
    }
}
