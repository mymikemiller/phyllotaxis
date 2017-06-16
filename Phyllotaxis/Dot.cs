using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phyllotaxis
{
    public class Dot
    {
        public int SerialIndex { get; private set; }

        public Dot(int serialIndex)
        {
            SerialIndex = serialIndex;
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }

        public PointF GetCanvasLocation(double canvasWidth, double canvasHeight)
        {
            double minDimension = Math.Min(canvasWidth, canvasHeight);
            PointF center = new PointF((float)(canvasWidth / 2.0), (float)(canvasHeight / 2.0));
            double dotXCenteredAt0 = X - .5;
            double dotYCenteredAt0 = Y - .5;
            float x = (float)(dotXCenteredAt0 * minDimension) + center.X;
            float y = (float)(dotYCenteredAt0 * minDimension) + center.Y;
            return new PointF(x, y);
        }

        public float GetCanvasRadius(double canvasWidth, double canvasHeight)
        {
            double minDimension = Math.Min(canvasWidth, canvasHeight);
            return (float)(Radius * minDimension);
        }


        public int GetClockwiseIndex(Display display)
        {
            return display.GetClockwiseIndex(SerialIndex);
        }

        public int GetCounterclockwiseIndex(Display display)
        {
            return display.GetCounterclockwiseIndex(SerialIndex);
        }
    }
}
