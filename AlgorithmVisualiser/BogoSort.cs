using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    internal class BogoSort : SortingAlgorithm
    {
        public BogoSort(int[] array) : base(array) { }

        public override LinkedList<Frame> Sort()
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

                frames.AddLast(new Frame((int[])array.Clone(), new int[] {index1}, new int[] { index2 }, null));
            }
            CompletionAnimation();
            return frames;
        }
    }
}
