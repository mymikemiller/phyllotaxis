namespace Phyllotaxis
{
    partial class PhylloForm
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
            this.components = new System.ComponentModel.Container();
            this.btnIteration = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mPhylloView = new Phyllotaxis.PylloView();
            this.btnAuto = new System.Windows.Forms.Button();
            this.txtSpiralOffset = new System.Windows.Forms.TextBox();
            this.btnIncrement = new System.Windows.Forms.Button();
            this.btnDecrement = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtSecondSpiral = new System.Windows.Forms.TextBox();
            this.txtFirstSpiral = new System.Windows.Forms.TextBox();
            this.mTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIteration
            // 
            this.btnIteration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIteration.Location = new System.Drawing.Point(12, 6);
            this.btnIteration.Name = "btnIteration";
            this.btnIteration.Size = new System.Drawing.Size(123, 23);
            this.btnIteration.TabIndex = 1;
            this.btnIteration.Text = "Iteration: 1";
            this.btnIteration.UseVisualStyleBackColor = true;
            this.btnIteration.Click += new System.EventHandler(this.btnIteration_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mPhylloView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnAuto);
            this.splitContainer1.Panel2.Controls.Add(this.txtSpiralOffset);
            this.splitContainer1.Panel2.Controls.Add(this.btnIncrement);
            this.splitContainer1.Panel2.Controls.Add(this.btnDecrement);
            this.splitContainer1.Panel2.Controls.Add(this.btnGo);
            this.splitContainer1.Panel2.Controls.Add(this.txtSecondSpiral);
            this.splitContainer1.Panel2.Controls.Add(this.txtFirstSpiral);
            this.splitContainer1.Panel2.Controls.Add(this.btnIteration);
            this.splitContainer1.Size = new System.Drawing.Size(585, 385);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 2;
            // 
            // phylloView
            // 
            this.mPhylloView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPhylloView.HighlightedClockwiseSpiral = 0;
            this.mPhylloView.Iteration = 1;
            this.mPhylloView.Location = new System.Drawing.Point(0, 0);
            this.mPhylloView.Name = "phylloView";
            this.mPhylloView.HighlightedCounterclockwiseSpiral = 0;
            this.mPhylloView.Size = new System.Drawing.Size(585, 340);
            this.mPhylloView.TabIndex = 1;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(142, 4);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(42, 23);
            this.btnAuto.TabIndex = 9;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // txtSpiralOffset
            // 
            this.txtSpiralOffset.Location = new System.Drawing.Point(475, 9);
            this.txtSpiralOffset.Name = "txtSpiralOffset";
            this.txtSpiralOffset.Size = new System.Drawing.Size(25, 20);
            this.txtSpiralOffset.TabIndex = 8;
            this.txtSpiralOffset.Text = "0";
            // 
            // btnIncrement
            // 
            this.btnIncrement.Location = new System.Drawing.Point(506, 6);
            this.btnIncrement.Name = "btnIncrement";
            this.btnIncrement.Size = new System.Drawing.Size(42, 23);
            this.btnIncrement.TabIndex = 6;
            this.btnIncrement.Text = ">>";
            this.btnIncrement.UseVisualStyleBackColor = true;
            this.btnIncrement.Click += new System.EventHandler(this.btnIncrement_Click);
            // 
            // btnDecrement
            // 
            this.btnDecrement.Location = new System.Drawing.Point(431, 6);
            this.btnDecrement.Name = "btnDecrement";
            this.btnDecrement.Size = new System.Drawing.Size(37, 23);
            this.btnDecrement.TabIndex = 5;
            this.btnDecrement.Text = "<<";
            this.btnDecrement.UseVisualStyleBackColor = true;
            this.btnDecrement.Click += new System.EventHandler(this.btnDecrement_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(315, 6);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(72, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtSecondSpiral
            // 
            this.txtSecondSpiral.Location = new System.Drawing.Point(249, 9);
            this.txtSecondSpiral.Name = "txtSecondSpiral";
            this.txtSecondSpiral.Size = new System.Drawing.Size(59, 20);
            this.txtSecondSpiral.TabIndex = 3;
            this.txtSecondSpiral.Text = "21";
            // 
            // txtFirstSpiral
            // 
            this.txtFirstSpiral.Location = new System.Drawing.Point(190, 8);
            this.txtFirstSpiral.Name = "txtFirstSpiral";
            this.txtFirstSpiral.Size = new System.Drawing.Size(53, 20);
            this.txtFirstSpiral.TabIndex = 2;
            this.txtFirstSpiral.Text = "13";
            // 
            // mTimer
            // 
            this.mTimer.Interval = 50;
            this.mTimer.Tick += new System.EventHandler(this.mTimer_Tick);
            // 
            // PhylloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 385);
            this.Controls.Add(this.splitContainer1);
            this.Name = "PhylloForm";
            this.Text = "Phyllotaxis";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIteration;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private PylloView mPhylloView;
        private System.Windows.Forms.TextBox txtSecondSpiral;
        private System.Windows.Forms.TextBox txtFirstSpiral;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtSpiralOffset;
        private System.Windows.Forms.Button btnIncrement;
        private System.Windows.Forms.Button btnDecrement;
        private System.Windows.Forms.Timer mTimer;
        private System.Windows.Forms.Button btnAuto;
    }
}

