using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualisationTool
{
    internal class SearchingAlgorithmState : AlgorithmState
    {
        public int CurrentIndex { get; set; }
        public int ComparedIndex { get; set; }
        public int Target { get; set; }
        public SearchingAlgorithmState(int currentIndex, int target, int[] array, int passNumber) : base(array, passNumber)
        {
            CurrentIndex = currentIndex;
            Target = target;
            ComparedIndex = -1;
        }
        public SearchingAlgorithmState(int currentIndex, int comparedIndex, int target, int[] array, int passNumber) : base(array, passNumber)
        {
            CurrentIndex = currentIndex;
            ComparedIndex = comparedIndex;
            Target = target;
        }
    }
}
