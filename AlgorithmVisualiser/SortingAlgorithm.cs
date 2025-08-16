using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    public abstract class SortingAlgorithm
    {
        SortingAlgorithmVisualiser visualiser;
        public int[] array;
        private int[] redIndices;
        private int[] greenIndices;
        private int[] blueIndices;

        public int[] Array {
            get
            {
                return array;
            }
            set
            {
                if(Array != null)
                {
                    array = value;
                }
            }
        }

        public abstract int[] Sort(int[] array);
    }
}