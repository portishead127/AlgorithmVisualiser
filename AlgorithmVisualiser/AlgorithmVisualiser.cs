using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualisationTool
{
    public partial class SortingAlgorithmVisualiser : Form
    {
        SortingAlgorithm algorithm;
        int currentStep;
        public SortingAlgorithmVisualiser()
        {
            InitializeComponent();
            algorithm = new InsertionSort();
            currentStep = 0;
            algorithm.Sort(new int[] { 5, 4, 3, 2, 1 });
            UpdateUI(algorithm.States[currentStep]);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            currentStep++;
            try
            {
                UpdateUI(algorithm.States[currentStep]);
            }catch(ArgumentOutOfRangeException)
            { 
                cbxAuto.Checked = false;
                MessageBox.Show("End of algorithm steps.");
            }
        }

        private void UpdateUI(SortingAlgorithmState currentState)
        {
            lblItem0.Text = currentState.Array[0].ToString();
            lblItem1.Text = currentState.Array[1].ToString();
            lblItem2.Text = currentState.Array[2].ToString();
            lblItem3.Text = currentState.Array[3].ToString();
            lblItem4.Text = currentState.Array[4].ToString();
            lblPassNum.Text = "Pass " + currentState.PassNumber.ToString() + ":";

            for (int i = 0; i < currentState.Array.Length; i++)
            {
                // Find the panel by name
                Panel panel = this.Controls.Find($"pnlIndex{i}", true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    // Find the TextBox inside the panel
                    Label label = panel.Controls.OfType<Label>().FirstOrDefault();
                    if (label != null)
                    {
                        label.Text = currentState.Array[i].ToString();
                    }

                    // Set panel background color
                    if (i == currentState.CurrentIndex)
                    {
                        label.BackColor = Color.Red;
                    }
                    else if (i == currentState.ComparedIndex)
                    {
                        label.BackColor = Color.Green;
                    }
                    else
                    {
                        label.BackColor = SystemColors.ControlDark;
                    }
                }
            }
        }

        private void tmrAuto_Tick(object sender, EventArgs e) => btnNext_Click(sender, e);

        private void cbxAuto_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxAuto.Checked)
            {
                tmrAuto.Start();
            }
            else
            {
                tmrAuto.Stop();
            }
        }

        private void trkSpeed_ValueChanged(object sender, EventArgs e)
        {
            try 
            { 
                tmrAuto.Interval = trkSpeed.Value * 100;
            }
            catch(ArgumentOutOfRangeException)
            {
                tmrAuto.Interval = 50;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            algorithm = new InsertionSort();
            currentStep = 0;
            algorithm.Sort(new int[] { 5, 4, 3, 2, 1 });
            UpdateUI(algorithm.States[currentStep]);
        }
    }
}
