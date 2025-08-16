using NAudio.Wave.SampleProviders;
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
        Queue<SortingAlgorithm.Frame> frames;
        SortingAlgorithm.Frame currentFrame;

        public SortingAlgorithmVisualiser(Queue<SortingAlgorithm.Frame> frames)
        {
            this.frames = frames;
            InitializeComponent();
        }

        public async void DisplayNextFrame()
        {
            while (frames.Any())
            {
                int frameDuration = 10; // ms
                currentFrame = frames.Dequeue();
                pnlRect.Invalidate();
                await Task.Delay(frameDuration);
            }
        }

        private void pnlRect_Paint(object sender, PaintEventArgs e)
        {
            if (!ValidateFrame())
            {
                return; // If the frame is not valid, do not draw anything
            }

            //TODO: POSSIBLE REFACTOR NEEDED HERE

            int rectWidth = pnlRect.Width / currentFrame.array.Length;

            for (int i = 0; i < currentFrame.array.Length; i++)
            {
                int height = (int)((double)currentFrame.array[i] / currentFrame.array.Max() * pnlRect.Height);
                Rectangle rect = new Rectangle(
                    i * rectWidth,
                    pnlRect.Height - height,
                    rectWidth - 1, // Subtracting 1 to create a gap between rectangles
                    height);

                using(Brush brush = DecideBrushColour(i))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayNextFrame();
            button1.Enabled = false; // Disable the button to prevent multiple clicks
        }

        private bool ValidateFrame()
        {
            if (currentFrame.array == null || currentFrame.array.Length == 0) return false;
            return true;
        }

        private SolidBrush DecideBrushColour(int arrayEntry)
        {
            if (currentFrame.redIndices != null && currentFrame.redIndices.Contains(arrayEntry))
            {
                return new SolidBrush(Color.Red);
            }
            else if (currentFrame.greenIndices != null && currentFrame.greenIndices.Contains(arrayEntry))
            {
                return new SolidBrush(Color.Green);
            }
            else if (currentFrame.blueIndices != null && currentFrame.blueIndices.Contains(arrayEntry))
            {
                return new SolidBrush(Color.Blue);
            }
            else
            {
                return new SolidBrush(Color.White);
            }
        }
    }
}
