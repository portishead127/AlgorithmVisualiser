using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualisationTool
{
    internal abstract class SortingAlgorithm
    {
        public readonly List<SortingAlgorithmState> States = new List<SortingAlgorithmState>();    
        public void AddAlgorithmState(int currentIndex, int comparedIndex, int[] array, int passNumber) => States.Add(new SortingAlgorithmState(currentIndex, comparedIndex, (int[])array.Clone(), passNumber));

        //public abstract void OutputCurrentState(int[] array, int pass);
        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public abstract int[] Sort(int[] array);

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
