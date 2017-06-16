using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phyllotaxis
{
    public class Display
    {
        private Dot[] mDots;
        private int mClockwiseResolution = 0;
        private int mCounterclockwiseResolution = 0;
        private List<DisplayUpdateListener> mUpdateListeners = new List<DisplayUpdateListener>();

        public Display(int clockwiseResolution, int counterclockwiseResolution)
        {
            ClockwiseResolution = clockwiseResolution;
            CounterclockwiseResolution = counterclockwiseResolution;

            ResetDots();
        }

        public int ClockwiseResolution { get { return mClockwiseResolution; } set { mClockwiseResolution = value; ResetDots(); } }
        public int CounterclockwiseResolution { get { return mCounterclockwiseResolution; } set { mCounterclockwiseResolution = value; ResetDots(); } }
        public Dot[] Dots { get { return mDots; } set { mDots = value; Invalidate(); } }

        private void ResetDots()
        {
            int numDots = ClockwiseResolution * CounterclockwiseResolution;
            Dot[] dots = new Dot[numDots];
            for (int i = 0; i < numDots; i++)
            {
                dots[i] = new Dot(i);
            }

            PositionDots(dots);

            Dots = PositionDots(dots);
        }

        private Dot[] PositionDots(Dot[] dots)
        {
            // Code from http://krazydad.com/tutorials/circles/showexample.php?ex=phyllo_equal

            double internalWidth = 1;
            double internalHeight = 1;
            double minDimension = 1;

            double phi = (Math.Sqrt(5) + 1) / 2 - 1;            // golden ratio
            double golden_angle = phi * 2 * Math.PI;            // golden angle

            double lg_rad = Math.Min(internalWidth, internalHeight) * .45;
            double lg_area = Math.Pow(lg_rad, 2) * Math.PI;

            double sm_area = lg_area / dots.Length; // Area of our little circles, if they filled the space entirely
            double sm_rad = Math.Sqrt(sm_area / Math.PI); // This is related to the equation area = pi r squared
            double fudge = 1.5; //.87; // Fudge factor, since our circles don't actually fill up space entirely.

            double cx = internalWidth / 2;
            double cy = internalHeight / 2;

            double radius = sm_rad * fudge * minDimension;
            //float finalRadius = (float)(radius * finalMinDimension);

            for (int i = 0; i < dots.Length; ++i)
            {
                Dot dot = dots[i];
                int index = i + 1;

                double angle = index * golden_angle;
                double cum_area = index * sm_area;
                double spiral_rad = Math.Sqrt(cum_area / Math.PI);
                dot.X = cx + Math.Cos(angle) * spiral_rad;
                dot.Y = cy + Math.Sin(angle) * spiral_rad;
                dot.Radius = radius;
                //float x = (float)(internalX * finalMinDimension);
                //float y = (float)(internalY * finalMinDimension);
            }

            return dots;
        }

        public List<Dot> GetClockwiseSpiral(int clockwiseIndex)
        {
            List<Dot> spiral = new List<Dot>();
            //for (int i = GetClockwiseIndex(clockwiseIndex); i < Dots.Length; i += ClockwiseResolution)
            //{
            //    spiral.Add(Dots[i]);
            //}
            return spiral;
        }

        public int GetClockwiseIndex(int serialIndex)
        {
            int clockwiseIndex = (serialIndex * CounterclockwiseResolution) % ClockwiseResolution;
            return clockwiseIndex;
        }        
        public int GetCounterclockwiseIndex(int serialIndex)
        {
            int counterclockwiseIndex = (serialIndex * ClockwiseResolution) % CounterclockwiseResolution;
            return counterclockwiseIndex;
        }
        public int GetSerialIndex(int clockwiseIndex, int counterclockwiseIndex)
        {
            int numDots = ClockwiseResolution * CounterclockwiseResolution;
            int serial = ((numDots - (clockwiseIndex * CounterclockwiseResolution)) + (counterclockwiseIndex * ClockwiseResolution)) % numDots;
            return serial;
        }

        public void Invalidate()
        {
            foreach (DisplayUpdateListener listener in mUpdateListeners)
            {
                listener.DisplayUpdated(this);
            }
        }

        public void AddUpdateListener(DisplayUpdateListener listener)
        {
            mUpdateListeners.Add(listener);
        }

    }
}
