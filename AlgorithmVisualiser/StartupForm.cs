using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AlgorithmVisualiser
{
    public partial class StartupForm : Form
    {
        Dictionary<int, Func<int[], SortingAlgorithm>> sortingAlgorithmDictionary =
            new Dictionary<int, Func<int[], SortingAlgorithm>>
            {
                {0, array => new BogoSort(array) },
                {1, array => new BubbleSort(array) },
                {2, array => new InsertionSort(array) }
            };

        struct VisualiserParams
        {
            public SortingAlgorithm sortingAlgorithm;

            public VisualiserParams(SortingAlgorithm sortingAlgorithm)
            {
                this.sortingAlgorithm = sortingAlgorithm;
            }
        };

        public StartupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CreateNewVisualiser(GetAlgorithm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private SortingAlgorithm GetAlgorithm()
        {
            int[] array;

            if (checkBox1.Checked)
            {
                int arrayLength = int.Parse(textBox2.Text);
                array = Program.GenerateRandomArray(arrayLength);
            }
            else
            {
                array = textBox1.Text
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            SortingAlgorithm sortingAlgorithm =
                sortingAlgorithmDictionary[comboBox1.SelectedIndex](array);

            return sortingAlgorithm;
        }

        private void CreateNewVisualiser(SortingAlgorithm sortingAlgorithm)
        {
            (new SortingAlgorithmVisualiser(sortingAlgorithm.Sort())).Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool checkBoxState = checkBox1.Checked;

            label3.Visible = !checkBoxState;
            textBox1.Visible = !checkBoxState;

            label4.Visible = checkBoxState;
            textBox2.Visible = checkBoxState;
        }
    }
}
