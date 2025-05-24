using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualiserProto
{
    internal class BogoSort : SortingAlgorithm
    {
        Random random = new Random();

        public override int[] Sort(int[] array)
        {
            int currentIndex = -1;
            int comparedIndex = -1;
            int pass = 0;
            AddAlgorithmState(currentIndex, comparedIndex, array, pass);
            while (!IsSorted(array))
            {
                currentIndex = -1;
                comparedIndex = -1;
                pass++;
                AddAlgorithmState(currentIndex, comparedIndex, array, pass);

                currentIndex = random.Next(0, array.Length);
                comparedIndex = random.Next(0, array.Length);

                AddAlgorithmState(currentIndex, comparedIndex, array, pass);
                Swap(array, currentIndex, comparedIndex);
                AddAlgorithmState(currentIndex, comparedIndex, array, pass);
            }
            return array;
        }
    }
}
