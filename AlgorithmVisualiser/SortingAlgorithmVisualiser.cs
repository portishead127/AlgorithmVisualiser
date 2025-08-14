using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualiser
{
    public partial class SortingAlgorithmVisualiser : Form
    {
        SortingAlgorithm sortingAlgorithm;
        int[] currentArray;
        readonly int[] originalArray;
        int[] redHighlightIndices;
        int[] greenHighlightIndices;
        int[] blueHighlightIndices;

        public SortingAlgorithmVisualiser(int[] array)
        {
            sortingAlgorithm = new BubbleSort(this); // You can change this to any sorting algorithm you implement
            InitializeComponent();
            currentArray = array;
            originalArray = (int[])array.Clone(); // Store the original array for reference
            pnlRect.Paint += pnlRect_Paint;
        }

        public async Task Next(int[] newArray, int[] redIndices, int[] greenIndices, int[] blueIndices)
        {
            SetArray(newArray);
            HighlightIndices(redIndices, greenIndices, blueIndices);
            await Task.Delay(10); // Delay to visualize the changes
            pnlRect.Invalidate(); // This will trigger the Paint event
        }

        private void SetArray(int[] newArray)
        {
            currentArray = newArray;
        }

        private void HighlightIndices(int[] redIndices, int[] greenIndices, int[] blueIndices)
        {
            redHighlightIndices = redIndices;
            greenHighlightIndices = greenIndices;
            blueHighlightIndices = blueIndices;
        }

        private void pnlRect_Paint(object sender, PaintEventArgs e)
        {
            if (currentArray == null || currentArray.Length == 0)
                return;

            int width = pnlRect.Width / currentArray.Length;
            for (int i = 0; i < currentArray.Length; i++)
            {
                int height = (int)((double)currentArray[i] / currentArray.Max() * pnlRect.Height);
                Rectangle rect = new Rectangle(
                    i * width,
                    pnlRect.Height - height,
                    width - 1, // Subtracting 1 to create a gap between rectangles
                    height);

                Brush brush;

                using( brush = new SolidBrush(Color.White))
                {
                    if (redHighlightIndices != null && redHighlightIndices.Contains(i))
                    {
                        brush = new SolidBrush(Color.Red);
                    }
                    else if (greenHighlightIndices != null && greenHighlightIndices.Contains(i))
                    {
                        brush = new SolidBrush(Color.Green);
                    }
                    else if (blueHighlightIndices != null && blueHighlightIndices.Contains(i))
                    {
                        brush = new SolidBrush(Color.Blue);
                    }
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sortingAlgorithm.Sort(currentArray);
            button1.Enabled = false; // Disable the button to prevent multiple clicks
        }

        public static void PlayBeep(UInt16 frequency, int msDuration = 100, UInt16 volume = 16383)
        {
            var mStrm = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(mStrm);

            const double TAU = 2 * Math.PI;
            int formatChunkSize = 16;
            int headerSize = 8;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int samples = (int)((decimal)samplesPerSecond * msDuration / 1000);
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            // var encoding = new System.Text.UTF8Encoding();
            writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
            writer.Write(fileSize);
            writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
            writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(0x61746164); // = encoding.GetBytes("data")
            writer.Write(dataChunkSize);
            {
                double theta = frequency * TAU / (double)samplesPerSecond;
                // 'volume' is UInt16 with range 0 thru Uint16.MaxValue ( = 65 535)
                // we need 'amp' to have the range of 0 thru Int16.MaxValue ( = 32 767)
                double amp = volume >> 2; // so we simply set amp = volume / 2
                for (int step = 0; step < samples; step++)
                {
                    short s = (short)(amp * Math.Sin(theta * (double)step));
                    writer.Write(s);
                }
            }

            mStrm.Seek(0, SeekOrigin.Begin);
            new System.Media.SoundPlayer(mStrm).PlaySync();
            writer.Close();
            mStrm.Close();
        }
    }
}
