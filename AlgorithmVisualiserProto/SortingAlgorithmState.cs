using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiserProto
{
    internal class SortingAlgorithmState : AlgorithmState
    {
        public int CurrentIndex { get; set; }
        public int ComparedIndex { get; set; }

        public SortingAlgorithmState(int currentIndex, int comparedIndex, int[] array, int passNumber) : base(array, passNumber)
        {
            CurrentIndex = currentIndex;
            ComparedIndex = comparedIndex;
        }
    }
}
