using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    public abstract class SortingAlgorithm
    {
        protected LinkedList<Frame> frames = new LinkedList<Frame>();
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

        public SortingAlgorithm(int[] array)
        {
            this.array = array;
        }

        public struct Frame
        {
            public int[] array;
            public int[] redIndices;
            public int[] greenIndices;
            public int[] blueIndices;

            public Frame(int[] array, int[] redIndices,  int[] greenIndices, int[] blueIndices)
            {
                this.array=array;
                this.redIndices=redIndices;
                this.greenIndices=greenIndices;
                this.blueIndices=blueIndices;
            }
        }

        public abstract LinkedList<Frame> Sort();


        public void CompletionAnimation()
        {
            frames.AddLast(new Frame((int[])array.Clone(), null, null, null));

            for (int i = 1; i <= array.Length; i++)
            {
                frames.AddLast(new Frame((int[])array.Clone(), null, null, Enumerable.Range(0, i).ToArray()));
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