using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    public abstract class SortingAlgorithm
    {
        protected SortingAlgorithmVisualiser visualiser;
        public int[] array;

        public int[] Array {
            get
            {
                return array;
            }
            set
            {
                if(array != null)
                {
                    array = value;
                }
            }
        }

        public SortingAlgorithm(int[] array, SortingAlgorithmVisualiser visualiser)
        {
            this.array = array;
            this.visualiser = visualiser;
        }

        public struct SortingFrame
        {
            public int[] array;
            public int[] redIndices;
            public int[] greenIndices;
            public int[] blueIndices;

            public SortingFrame(int[] array, int[] redIndices,  int[] greenIndices, int[] blueIndices)
            {
                this.array=array;
                this.redIndices=redIndices;
                this.greenIndices=greenIndices;
                this.blueIndices=blueIndices;
            }
        }

        public abstract void Sort();


        public void CompletionAnimation(int[] array)
        {
            visualiser.DisplayNextFrame(new SortingFrame(array, null, null, null));

            for (int i = 1; i <= array.Length; i++)
            {
                visualiser.DisplayNextFrame(new SortingFrame(array, new int[0], new int[0], Enumerable.Range(0, i).ToArray()));
            }
        }

        public static bool IsSorted(int[] array)
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
    }
}