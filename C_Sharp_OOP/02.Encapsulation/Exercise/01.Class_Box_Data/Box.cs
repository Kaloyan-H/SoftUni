using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Class_Box_Data
{
    public class Box
    {
		private double length;
		private double width;
		private double height;

		public Box(double length, double width, double height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;
		}

		public double Length
		{
			get { return length; }
			private set
			{
				if (value > 0) this.length = value;
				else throw new ArgumentException("Length cannot be zero or negative.");
			}
		}
		public double Width
		{
			get { return width; }
			private set
            {
                if (value > 0) this.width = value;
                else throw new ArgumentException("Width cannot be zero or negative.");
            }
        }
		public double Height
		{
			get { return height; }
			private set
            {
                if (value > 0) this.height = value;
                else throw new ArgumentException("Height cannot be zero or negative.");
            }
        }

		public double SurfaceArea() => 2 * ((length * width) + (length * height) + (width * height));
		public double LateralSurfaceArea() => 2 * ((length * height) + (width * height));
		public double Volume() => length * width * height;

	}
}
