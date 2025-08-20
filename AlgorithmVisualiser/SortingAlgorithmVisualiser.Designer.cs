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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pnlRect = new AlgorithmVisualiser.DoubleBufferedPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FF = new System.Windows.Forms.PictureBox();
            this.PP = new System.Windows.Forms.PictureBox();
            this.PREV = new System.Windows.Forms.PictureBox();
            this.PLAYPREV = new System.Windows.Forms.PictureBox();
            this.PLAY = new System.Windows.Forms.PictureBox();
            this.NEXT = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PREV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLAYPREV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLAY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NEXT)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 100;
            this.trackBar1.Location = new System.Drawing.Point(687, 388);
            this.trackBar1.Maximum = 5000;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBar1.Size = new System.Drawing.Size(101, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 1000;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 10;
            // 
            // pnlRect
            // 
            this.pnlRect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRect.BackColor = System.Drawing.Color.Transparent;
            this.pnlRect.Location = new System.Drawing.Point(13, 12);
            this.pnlRect.Name = "pnlRect";
            this.pnlRect.Size = new System.Drawing.Size(775, 368);
            this.pnlRect.TabIndex = 0;
            this.pnlRect.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRect_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NEXT);
            this.panel1.Controls.Add(this.PLAY);
            this.panel1.Controls.Add(this.PLAYPREV);
            this.panel1.Controls.Add(this.PREV);
            this.panel1.Controls.Add(this.PP);
            this.panel1.Controls.Add(this.FF);
            this.panel1.Location = new System.Drawing.Point(236, 388);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 50);
            this.panel1.TabIndex = 8;
            // 
            // FF
            // 
            this.FF.Image = global::AlgorithmVisualiser.Properties.Resources.fast_forward;
            this.FF.Location = new System.Drawing.Point(278, 0);
            this.FF.Name = "FF";
            this.FF.Size = new System.Drawing.Size(50, 50);
            this.FF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FF.TabIndex = 0;
            this.FF.TabStop = false;
            this.FF.Click += new System.EventHandler(this.FFButton_Click);
            // 
            // PP
            // 
            this.PP.Image = global::AlgorithmVisualiser.Properties.Resources.past_previous;
            this.PP.Location = new System.Drawing.Point(0, 0);
            this.PP.Name = "PP";
            this.PP.Size = new System.Drawing.Size(50, 50);
            this.PP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PP.TabIndex = 1;
            this.PP.TabStop = false;
            this.PP.Click += new System.EventHandler(this.button5_Click);
            // 
            // PREV
            // 
            this.PREV.Image = global::AlgorithmVisualiser.Properties.Resources.back;
            this.PREV.Location = new System.Drawing.Point(56, 0);
            this.PREV.Name = "PREV";
            this.PREV.Size = new System.Drawing.Size(50, 50);
            this.PREV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PREV.TabIndex = 2;
            this.PREV.TabStop = false;
            this.PREV.Click += new System.EventHandler(this.button4_Click);
            // 
            // PLAYPREV
            // 
            this.PLAYPREV.Image = global::AlgorithmVisualiser.Properties.Resources.play_prev;
            this.PLAYPREV.Location = new System.Drawing.Point(112, 0);
            this.PLAYPREV.Name = "PLAYPREV";
            this.PLAYPREV.Size = new System.Drawing.Size(50, 50);
            this.PLAYPREV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PLAYPREV.TabIndex = 3;
            this.PLAYPREV.TabStop = false;
            this.PLAYPREV.Click += new System.EventHandler(this.button6_Click);
            // 
            // PLAY
            // 
            this.PLAY.Image = global::AlgorithmVisualiser.Properties.Resources.play;
            this.PLAY.Location = new System.Drawing.Point(168, 0);
            this.PLAY.Name = "PLAY";
            this.PLAY.Size = new System.Drawing.Size(50, 50);
            this.PLAY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PLAY.TabIndex = 4;
            this.PLAY.TabStop = false;
            this.PLAY.Click += new System.EventHandler(this.button1_Click);
            // 
            // NEXT
            // 
            this.NEXT.Image = global::AlgorithmVisualiser.Properties.Resources.next;
            this.NEXT.Location = new System.Drawing.Point(224, 0);
            this.NEXT.Name = "NEXT";
            this.NEXT.Size = new System.Drawing.Size(50, 50);
            this.NEXT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NEXT.TabIndex = 5;
            this.NEXT.TabStop = false;
            this.NEXT.Click += new System.EventHandler(this.button3_Click);
            // 
            // SortingAlgorithmVisualiser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pnlRect);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SortingAlgorithmVisualiser";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PREV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLAYPREV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLAY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NEXT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AlgorithmVisualiser.DoubleBufferedPanel pnlRect;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox NEXT;
        private System.Windows.Forms.PictureBox PLAY;
        private System.Windows.Forms.PictureBox PLAYPREV;
        private System.Windows.Forms.PictureBox PREV;
        private System.Windows.Forms.PictureBox PP;
        private System.Windows.Forms.PictureBox FF;
    }
}

