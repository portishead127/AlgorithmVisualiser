using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                    width - 1, // Subtracting 5 to create a gap between rectangles
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
    }
}
