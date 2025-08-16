using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    public abstract class SortingAlgorithm
    {
        protected Queue<Frame> frames = new Queue<Frame>();
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

        public abstract Queue<Frame> Sort();


        public void CompletionAnimation()
        {
            frames.Enqueue(new Frame((int[])array.Clone(), null, null, null));

            for (int i = 1; i <= array.Length; i++)
            {
                frames.Enqueue(new Frame((int[])array.Clone(), new int[0], new int[0], Enumerable.Range(0, i).ToArray()));
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