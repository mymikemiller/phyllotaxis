using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phyllotaxis
{
    public partial class PhylloForm : Form
    {
        Display mDisplay = new Display(0, 0);

        public PhylloForm()
        {
            InitializeComponent();
            Go();
        }

        private void Go()
        {
            int firstSpiral = int.Parse(txtFirstSpiral.Text);
            int secondSpiral = int.Parse(txtSecondSpiral.Text);

            mPhylloView.Display.ClockwiseResolution = firstSpiral;
            mPhylloView.Display.CounterclockwiseResolution = secondSpiral;

            //phylloView.FirstSpiral = firstSpiral;
            //phylloView.SecondSpiral = secondSpiral;

            
            for (int i = 0; i < 273; i++)
            {
                int clockwiseIndex = mPhylloView.Display.GetClockwiseIndex(i);
                int counterclockwiseIndex = mPhylloView.Display.GetCounterclockwiseIndex(i);
                int serial = mPhylloView.Display.GetSerialIndex(clockwiseIndex, counterclockwiseIndex);
                if (i != serial)
                {
                    Console.WriteLine("Wrong... " + i + " != " + serial);
                }
                //if (counterclockwiseIndex == 1)
                //{
                //    Console.WriteLine(clockwiseIndex + ", " + counterclockwiseIndex + " = " + i);
                //}
            }

        }

        private void btnIteration_Click(object sender, EventArgs e)
        {
            mPhylloView.Iteration += 1;
            btnIteration.Text = "Iteration: " + mPhylloView.Iteration;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Go();
        }

        private void btnDecrement_Click(object sender, EventArgs e)
        {
            mPhylloView.HighlightedClockwiseSpiral++;
            mPhylloView.HighlightedCounterclockwiseSpiral--;
            txtSpiralOffset.Text = mPhylloView.HighlightedClockwiseSpiral.ToString();
        }

        private void btnIncrement_Click(object sender, EventArgs e)
        {
            mPhylloView.HighlightedClockwiseSpiral--;
            mPhylloView.HighlightedCounterclockwiseSpiral++;
            txtSpiralOffset.Text = mPhylloView.HighlightedClockwiseSpiral.ToString();
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            mTimer.Start();
        }

        private void mTimer_Tick(object sender, EventArgs e)
        {
            mPhylloView.HighlightedClockwiseSpiral--;
            mPhylloView.HighlightedCounterclockwiseSpiral++;
            txtSpiralOffset.Text = mPhylloView.HighlightedClockwiseSpiral.ToString();
        }
    }
}
