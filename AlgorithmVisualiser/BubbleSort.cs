using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    internal class BubbleSort : SortingAlgorithm
    {
        SortingAlgorithmVisualiser visualiser;

        public BubbleSort(SortingAlgorithmVisualiser visualiser)
        {
            this.visualiser = visualiser;
        }

        public async void Sort(int[] array)
        {
            int n = array.Length;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Highlight the current pair being compared
                    await visualiser.Next(array, new int[] { j }, new int[] {j+1}, null);
                    if (array[j] > array[j + 1])
                    {
                        // Swap if the element found is greater than the next element
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                // If no two elements were swapped by inner loop, then break
                if (!swapped)
                {
                    CompletionAnimation(array);
                    return;
                }

                // Update the visualiser with the current state of the array
                await visualiser.Next(array, new int[0], new int[0], null);
            }
            CompletionAnimation(array);
        }

        public async void CompletionAnimation(int[] array)
        {
            await visualiser.Next(array, null, null, null);

            for(int i = 1; i <= array.Length; i++)
            {
                await visualiser.Next(array, new int[0], new int[0], Enumerable.Range(0, i).ToArray());
            }
        }
    }
}
