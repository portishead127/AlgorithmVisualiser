using AlgorithmVisualiser.Properties;
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
        //true - forwards, false - backwards, null - none
        bool? playing = null;

        LinkedList<SortingAlgorithm.Frame> frames;
        SortingAlgorithm.Frame currentFrame;
        LinkedListNode<SortingAlgorithm.Frame> currentNode;

        public SortingAlgorithmVisualiser(LinkedList<SortingAlgorithm.Frame> frames)
        {
            this.frames = frames;
            currentNode = frames.First;
            currentFrame = currentNode.Value;
            InitializeComponent();
        }

        public async void DisplayNextFrameLoop()
        {
            while (playing == true)
            {
                await DisplayNextFrame();
            }
        }

        public async Task DisplayNextFrame()
        {
            if (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                currentFrame = currentNode.Value;
                int framesDuration = GetFrameDuration();
                pnlRect.Invalidate();
                await Task.Delay(framesDuration);
            }
            else
            {
                UpdatePlayStatus(null);
            }
        }

        public async void DisplayPrevFrameLoop()
        {
            while (playing == false)
            {
                await DisplayPrevFrame();
            }
        }

        public async Task DisplayPrevFrame()
        {
            if (currentNode.Previous != null)
            {
                currentNode = currentNode.Previous;
                currentFrame = currentNode.Value;
                int framesDuration = GetFrameDuration();
                pnlRect.Invalidate();
                await Task.Delay(framesDuration);
            }
            else
            {
                UpdatePlayStatus(null);
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
            UpdatePlayStatus(true);

            DisplayNextFrameLoop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdatePlayStatus(false);
            DisplayPrevFrameLoop();
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

        private void FFButton_Click(object sender, EventArgs e)
        {
            trackBar1.Value = trackBar1.Minimum;
            UpdatePlayStatus(true);
            DisplayNextFrameLoop();
        }

        private void UpdatePlayStatus(bool? state)
        {
            if (playing == state)
            {
                // If already in that state, pause
                playing = null;
            }
            else
            {
                // Otherwise, switch to the requested state
                playing = state;
            }
            UpdatePlayIcons();
        }


        private void UpdatePlayIcons()
        {
            if (playing == true)
            {
                PLAY.Image = Resources.pause;
                PLAYPREV.Image = Resources.play_prev;
            }
            else if(playing == false)
            {
                PLAY.Image = Resources.play;
                PLAYPREV.Image = Resources.pause;
            }
            else
            {
                PLAY.Image = Resources.play;
                PLAYPREV.Image = Resources.play_prev;
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await DisplayNextFrame();
            UpdatePlayStatus(null);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await DisplayPrevFrame();
            UpdatePlayStatus(null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            trackBar1.Value = trackBar1.Minimum;
            UpdatePlayStatus(false);
            DisplayPrevFrameLoop();
        }
    }
}
