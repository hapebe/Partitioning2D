using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Model
{
    public class List2D<T> : List<T> where T : BaseObject2D, new()
    {
        Random random = new Random();
        public DistanceMatrix OddDistances { get; set; }

        public BaseObject2D Center()
        {
            BaseObject2D retval = new BaseObject2D();
            foreach (var item in this)
            {
                retval.Add(item);
            }
            retval.Scale(1d / this.Count);

            return retval;
        }

        public double OneDimensionErrorSum()
        {
            BaseObject2D c = Center();
            double errorSum = 0;
            foreach (var item in this) errorSum += Math.Abs(item.OneDimensionDistanceTo(c));
            return errorSum;
        }

        public void UpdateOddDistances()
        {
            OddDistances = new DistanceMatrix(this.Count);
            for (int i=0; i<this.Count; i++)
            {
                for (int j=i; j<this.Count; j++)
                {
                    OddDistances.Set(i, j, this[i].OneDimensionDistanceTo(this[j]));
                }
            }
        }

        public double RectangularArea()
        {
            return GetRange().Area;
        }

        public double EuclideanErrorSum()
        {
            BaseObject2D c = Center();
            double errorSum = 0;
            foreach (var item in this) errorSum += Math.Abs(item.EuclideanDistanceTo(c));
            return errorSum;
        }

        public double CircularArea()
        {
            double radius = 0d;
            var c = Center();
            foreach (T point in this)
            {
                double distanceToCenter = c.EuclideanDistanceTo(point);
                if (distanceToCenter > radius) radius = distanceToCenter;
            }
            return Math.PI * radius * radius;
        }

        public T GetRandom()
        {
            int idx = random.Next(this.Count);
            return this[idx];
        }

        public int[] GetShuffledIndexes()
        {
            int[] idxs = new int[this.Count];
            for (int i = 0; i < idxs.Length; i++)
                idxs[i] = i;

            // repeat N times:
            for (int i = 0; i < 10; i++)
            {
                // swap every item in the array with a random one:
                for (int j = 0; j < idxs.Length; j++)
                {
                    int otherIdx = random.Next(idxs.Length);
                    int temp = idxs[j];
                    idxs[j] = idxs[otherIdx];
                    idxs[otherIdx] = temp;
                }
            }

            return idxs;
        }

        public List2D<T> GetShuffled()
        {
            int[] idxs = GetShuffledIndexes();

            List2D<T> retval = new List2D<T>();
            foreach (var idx in idxs) retval.Add(this[idx]);
            return retval;
        }

        public Range2D GetRange()
        {
            BaseObject2D max = new BaseObject2D() { X = Double.MinValue, Y = Double.MinValue };
            BaseObject2D min = new BaseObject2D() { X = Double.MaxValue, Y = Double.MaxValue };

            foreach (var obj in this)
            {
                if (obj.X < min.X) min.X = obj.X;
                if (obj.Y < min.Y) min.Y = obj.Y;
                if (obj.X > max.X) max.X = obj.X;
                if (obj.Y > max.Y) max.Y = obj.Y;
            }

            return new Range2D()
            {
                Min = min,
                Max = max
            };
        }

        public void ReadFromTabbedText(string filename)
        {
            string s = File.ReadAllText(filename);
            string[] lines = s.Split('\n');

            this.Clear();

            // we assume there is a header line!
            for (int i=1; i<lines.Length; i++)
            {
                var line = lines[i];
                if (line.Trim().Length == 0) continue;

                T item = new T();
                item.FromTabbedText(line);
                this.Add(item);
            }
        }

        public void WriteToTabbedText(string filename)
        {
            StringBuilder sb = new StringBuilder();
            if (this.Count > 0)
            {
                sb.AppendLine(this[0].TabbedTextHeaders());
            }

            foreach (var item in this)
            {
                sb.AppendLine(item.ToTabbedText());
            }

            File.WriteAllText(filename, sb.ToString());
        }
    }
}
