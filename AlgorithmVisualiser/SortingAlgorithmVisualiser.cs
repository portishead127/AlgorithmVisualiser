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
        int[] array;

        public SortingAlgorithmVisualiser(int[] array)
        {
            InitializeComponent();
            this.array = array;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GenerateRectangles();
        }

        private void GenerateRectangles() 
        { 
            int width = pnlRectangleBox.Width / array.Length;
            foreach (int item in array)
            {
                int height = (int)((double)item / array.Max() * pnlRectangleBox.Height);
                Rectangle rect = new Rectangle(
                    array.ToList().IndexOf(item) * width,
                    pnlRectangleBox.Height - height,
                    width - 1,
                    height);
                using (Brush brush = new SolidBrush(Color.White))
                {
                    using (Graphics g = CreateGraphics())
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
            }
        }
    }
}
