namespace AlgorithmVisualiser
{
    partial class SortingAlgorithmVisualiser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlRectangleBox = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlRectangleBox
            // 
            this.pnlRectangleBox.Location = new System.Drawing.Point(13, 13);
            this.pnlRectangleBox.Name = "pnlRectangleBox";
            this.pnlRectangleBox.Size = new System.Drawing.Size(775, 425);
            this.pnlRectangleBox.TabIndex = 0;
            // 
            // SortingAlgorithmVisualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlRectangleBox);
            this.Name = "SortingAlgorithmVisualiser";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRectangleBox;
    }
}

