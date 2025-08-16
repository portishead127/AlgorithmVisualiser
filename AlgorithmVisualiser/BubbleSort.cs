using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    internal class BubbleSort : SortingAlgorithm
    {
        public BubbleSort(int[] array) : base(array ) { }

        public override LinkedList<Frame> Sort()
        {
            int n = array.Length;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Highlight the current pair being compared
                    frames.AddLast(new Frame((int[])array.Clone(), new int[] {j}, new int[] {j+1}, null));
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
                    CompletionAnimation();
                    return frames;
                }

                // Update the visualiser with the current state of the array
                frames.AddLast(new Frame((int[])array.Clone(), null, null, null));
            }
            CompletionAnimation();
            return frames;
        }
    }
}
