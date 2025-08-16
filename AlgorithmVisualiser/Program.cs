using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualiser
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var sine20Seconds = new SignalGenerator()
            {
                Gain = 0.2,
                Frequency = 500,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromSeconds(2));
            using (var wo = new WaveOutEvent())
            {
                wo.Init(sine20Seconds);
                wo.Play();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SortingAlgorithmVisualiser(new BubbleSort(GenerateRandomArray(20)).Sort()));
        }

        public static int[] GenerateRandomArray(int size)
        {
            return Enumerable.Range(1, size)
                             .OrderBy(x => Guid.NewGuid()) // Randomise the order
                             .ToArray();
        }
    }
}
