using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    internal class InsertionSort : SortingAlgorithm
    {
        SortingAlgorithmVisualiser visualiser;

        public InsertionSort(SortingAlgorithmVisualiser visualiser)
        {
            this.visualiser = visualiser;
        }

        public async void Sort(int[] array)
        {
            for (int i = 1; i <= array.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && j != array.Length - 1)
                {
                    if (array[j] > array[j+1])
                    {
                        await visualiser.Next(array, new int[] { j }, new int[] { i }, Array.Empty<int>());
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

        public async void CompletionAnimation(int[] array)
        {
            await visualiser.Next(array, null, null, null);

            for (int i = 1; i <= array.Length; i++)
            {
                await visualiser.Next(array, new int[0], new int[0], Enumerable.Range(0, i).ToArray());
            }
        }
    }
}
