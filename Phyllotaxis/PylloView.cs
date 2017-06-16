using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phyllotaxis
{
    enum DotHighlightType { NotHighlighted, HighlightedInClockwiseSpiral, HighlightedInCounterclockwiseSpiral, HighlightedInBothSpirals }

    public partial class PylloView : UserControl, DisplayUpdateListener
    {
        private static int mDrawIteration = 1;
        private static int mHighlightedClockwiseSpiral = 0;
        private static int mHighlightedCounterclockwiseSpiral = 0;

        private static Bitmap mBufferBitmap;
        private static Graphics mBufferGraphics;

        public Display Display { get; private set; }

        public PylloView()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Display = new Display(0, 0);
        }

        public int Iteration
        {
            get
            {
                return mDrawIteration;
            }
            set
            {
                mDrawIteration = value;
                Invalidate();
            }
        }
        public int HighlightedClockwiseSpiral
        {
            get
            {
                return mHighlightedClockwiseSpiral;
            }
            set
            {
                mHighlightedClockwiseSpiral = (value + Display.ClockwiseResolution) % Math.Max(Display.ClockwiseResolution, 1);
                Invalidate();
            }
        }
        public int HighlightedCounterclockwiseSpiral
        {
            get
            {
                return mHighlightedCounterclockwiseSpiral;
            }
            set
            {
                mHighlightedCounterclockwiseSpiral = (value + Display.CounterclockwiseResolution) % Math.Max(Display.CounterclockwiseResolution, 1);
                Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            mBufferBitmap = new Bitmap(Width, Height);
            mBufferGraphics = Graphics.FromImage(mBufferBitmap);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Refresh(mBufferGraphics, Width, Height);

            e.Graphics.DrawImageUnscaled(mBufferBitmap, new Point(0, 0));
        }

        private bool IsHighlightedClockwiseSpiral(Dot dot)
        {
            return dot.GetClockwiseIndex(Display) == mHighlightedClockwiseSpiral;
        }
        private bool IsHighlightedCounterclockwisepiral(Dot dot)
        {
            return dot.GetCounterclockwiseIndex(Display) == mHighlightedCounterclockwiseSpiral;
        }

        private DotHighlightType GetHighlightType(Dot dot) {
            if (IsHighlightedClockwiseSpiral(dot))
            {
                if (IsHighlightedCounterclockwisepiral(dot))
                {
                    return DotHighlightType.HighlightedInBothSpirals;
                }

                    
                return DotHighlightType.HighlightedInClockwiseSpiral;
            }

            if (IsHighlightedCounterclockwisepiral(dot)) {
                return DotHighlightType.HighlightedInCounterclockwiseSpiral;
            }

            return DotHighlightType.NotHighlighted;
                  
        }

        private void Refresh(Graphics g, double width, double height)
        {
            g.Clear(Color.Black);
            
            Brush brush;
            Color dark = Color.FromArgb(15, 15, 15);
            Pen darkPen = new Pen(dark);

            foreach (Dot dot in Display.Dots)
            {

                DotHighlightType highlightType = GetHighlightType(dot);

                switch (highlightType) {
                    case DotHighlightType.HighlightedInClockwiseSpiral:
                        brush = Brushes.Red;
                        break;
                    case DotHighlightType.HighlightedInCounterclockwiseSpiral:
                        brush = Brushes.Blue;
                        break;
                    case DotHighlightType.HighlightedInBothSpirals:
                        brush = Brushes.Lime;
                        break;
                    default:
                        brush = Brushes.Transparent;
                        break;
                }
                
                float radius = dot.GetCanvasRadius(width, height);
                PointF center = dot.GetCanvasLocation(width, height);
                PointF topLeft = new PointF(center.X - radius / 2f, center.Y - radius / 2f);

                if (highlightType != DotHighlightType.NotHighlighted) {
                    g.FillEllipse(brush, topLeft.X, topLeft.Y, radius, radius);
                }

                // Outline every dot
                g.DrawEllipse(darkPen, topLeft.X, topLeft.Y, radius, radius);

                g.DrawString(dot.GetCounterclockwiseIndex(Display).ToString(), SystemFonts.DefaultFont, Brushes.White, topLeft);

            }

            Dot lastDot = null;
            foreach(Dot dot in Display.GetClockwiseSpiral(HighlightedClockwiseSpiral)) {
                if (lastDot != null)
                {
                    ConnectDots(g, dot, lastDot);
                }
                lastDot = dot;
            }
        }

        private void ConnectDots(Graphics g, Dot first, Dot second)
        {
            g.DrawLine(Pens.LimeGreen, first.GetCanvasLocation(Width, Height), second.GetCanvasLocation(Width, Height));
        }

        public void DisplayUpdated(Display display)
        {
            if (display == Display)
            {
                Invalidate();
            }
        }
    }
}
