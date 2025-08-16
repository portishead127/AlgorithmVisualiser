using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    internal class InsertionSort : SortingAlgorithm
    {
        public InsertionSort(int[] array) : base(array) { }

        public override LinkedList<Frame> Sort()
        {
            for (int i = 1; i <= array.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && j != array.Length - 1)
                {
                    if (array[j] > array[j+1])
                    {
                        frames.AddLast(new Frame((int[])array.Clone(), new int[] { j }, new int[] { i }, null));
                        // Swap elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                    j--;
                }
            }
            CompletionAnimation();
            return frames;
        }
    }
}
