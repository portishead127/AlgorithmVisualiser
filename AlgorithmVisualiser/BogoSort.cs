using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    internal class BogoSort : SortingAlgorithm
    {
        SortingAlgorithmVisualiser visualiser;

        public BogoSort(SortingAlgorithmVisualiser visualiser)
        {
            this.visualiser = visualiser;
        }

        public async void Sort(int[] array)
        {
            Random rng = new Random();

            int index1, index2, temp;

            while (!IsSorted(array))
            {
                index1 = rng.Next(array.Length);
                index2 = rng.Next(array.Length);

                temp = array[index1];
                array[index1] = array[index2];
                array[index2] = temp;

                await visualiser.Next(array, new int[] {index1}, new int[] { index2 }, null);
            }
            CompletionAnimation(array);
        }

        public  bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
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
