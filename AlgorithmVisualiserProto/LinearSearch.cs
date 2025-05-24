using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualisationTool
{
    internal class LinearSearch : SearchingAlgorithm
    {
        public override int Search(int[] array, int target)
        {
            int currentIndex = -1;
            int pass = 0;
            AddAlgorithmState(currentIndex, target, array, pass);
            pass++;
            for (currentIndex = 0; currentIndex < array.Length; currentIndex++)
            {
                AddAlgorithmState(currentIndex, target, array, pass);
                if (array[currentIndex] == target)
                {
                    return currentIndex; // Target found
                }
            }
            return -1; // Target not found
        }
    }
}
