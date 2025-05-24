using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualisationTool
{
    internal class AlgorithmState
    {
        public int PassNumber { get; set; }
        public int[] Array { get; set; }
        public AlgorithmState(int[] array, int passNumber)
        {
            PassNumber = passNumber;
            Array = array;
        }
    }
}
