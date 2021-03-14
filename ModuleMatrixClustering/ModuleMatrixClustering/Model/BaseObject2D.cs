using ModuleMatrixClustering.Persistence;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Model
{
    public class BaseObject2D : ITabbedTextable
    {
        public double X { get; set; }
        public double Y { get; set; }

        public BaseObject2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public BaseObject2D() : this(0, 0) { }

        public void Add(BaseObject2D other)
        {
            X += other.X;
            Y += other.Y;
        }

        public void Scale(double factor)
        {
            X *= factor;
            Y *= factor;
        }

        public double EuclideanDistanceTo(BaseObject2D other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public double OneDimensionDistanceTo(BaseObject2D other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            return Math.Max(Math.Abs(dx), Math.Abs(dy));
        }

        public override bool Equals(object obj)
        {
            var d = obj as BaseObject2D;
            return d != null &&
                   X == d.X &&
                   Y == d.Y;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }

        public virtual string TabbedTextHeaders()
        {
            return "X\tY";
        }

        public virtual string ToTabbedText()
        {
            return $"{X}\t{Y}";
        }

        public virtual void FromTabbedText(string s)
        {
            string[] parts = s.Split('\t');
            if (parts.Length != 2)
            {
                throw new InvalidOperationException($"Cannot parse tabbed text: {s}");
            }

            X = Double.Parse(parts[0], CultureInfo.InvariantCulture);
            Y = Double.Parse(parts[1], CultureInfo.InvariantCulture);
        }

        //public static BaseObject2D operator+ (BaseObject2D a, BaseObject2D b)
        //{
        //    return new BaseObject2D(a.X + b.X, a.Y + b.Y);
        //}


    }
}
