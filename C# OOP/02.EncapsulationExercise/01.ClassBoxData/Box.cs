using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length,double width,double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return length; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }
                length = value; 
            }
        }


        public double Width
        {
            get { return width; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                }
                width = value; 
            }
        }


        public double Height
        {
            get { return height; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative."); 
                }
                height = value; 
            }
        }

        public double Volume()
        {
            return Length * Width * Height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double SurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height + 2*Length*Width;
        }
    }
}
