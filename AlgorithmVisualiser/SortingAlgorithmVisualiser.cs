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
        bool playing = false;

        Queue<SortingAlgorithm.Frame> frames;
        SortingAlgorithm.Frame currentFrame;

        public SortingAlgorithmVisualiser(Queue<SortingAlgorithm.Frame> frames)
        {
            this.frames = frames;
            InitializeComponent();
        }

        public async void DisplayNextFrameLoop()
        {
            while (frames.Any() && playing)
            {
                int frameDuration = GetFrameDuration(); // ms
                currentFrame = frames.Dequeue();
                pnlRect.Invalidate();
                await Task.Delay(frameDuration);
            }
        }

        public async void DisplayNextFrame()
        {
            int framesDuration = GetFrameDuration();
            currentFrame = frames.Dequeue();
            pnlRect.Invalidate();
            await Task.Delay(framesDuration);
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
            UpdatePlayStatus();

            if (playing)
            {
                DisplayNextFrameLoop();
            }
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
                return new SolidBrush(Color.Gray);
            }
        }

        private int GetFrameDuration()
        {
            return trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBar1.Value = trackBar1.Minimum;
        }

        private void UpdatePlayStatus()
        {
            playing = !playing;

            if (playing)
            {
                button1.Text = "PAUSE";
            }
            else
            {
                button1.Text = "PLAY";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayNextFrame();
        }
    }
}
