using System;
using System.Collections.Generic;
using System.Text;

namespace BoxData
{
   public class Box
   {
        private const string ExceptionMessege = "{0} cannot be zero or negative.";
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
            get
            {
                return this.length;
            }
            private set
            {
                ValidateSide(value, nameof(Length));
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                ValidateSide(value, nameof(Width));
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                ValidateSide(value, nameof(Height));
                this.height = value;
            }
        }

        private void ValidateSide(double side, string name)
        {
            if (side <= 0)
            {
                throw new ArgumentException(String.Format(ExceptionMessege,name));
            }
        }

        public double CalculateLateralSurfaceArea =>
            (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double CalculateSurfaceArea =>
            (2 * this.Length * this.Width) + CalculateLateralSurfaceArea;

        public double CalculateVolume => this.Length * this.Width * this.Height;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {CalculateSurfaceArea:f2}");
            sb.AppendLine($"Lateral Surface Area - {CalculateLateralSurfaceArea:f2}");
            sb.AppendLine($"Volume - {CalculateVolume:f2}");

            return sb.ToString().Trim();
        }
    }
}
