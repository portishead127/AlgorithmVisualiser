using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiserProto
{
    internal abstract class SearchingAlgorithm
    {
        public readonly List<SearchingAlgorithmState> States = new List<SearchingAlgorithmState>();

        public void AddAlgorithmState(int currentIndex, int target, int[] array, int passNumber) => States.Add(new SearchingAlgorithmState(currentIndex, target, (int[])array.Clone(), passNumber));

        public abstract int Search(int[] array, int target);
    }
}
