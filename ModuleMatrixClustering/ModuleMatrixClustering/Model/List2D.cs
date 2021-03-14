using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Model
{
    public class List2D : List<BaseObject2D>
    {
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

            foreach (var item in this)
            {
                errorSum += Math.Abs(item.OneDimensionDistanceTo(c));
            }

            return errorSum;
        }

        public void ReadFromTabbedText<T>(string filename) where T : BaseObject2D, new()
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
