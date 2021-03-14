using ModuleMatrixClustering.Persistence;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Model
{
    public class Item2D : BaseObject2D, ITabbedTextable
    {
        public string Id { get; set; }
        public string Label { get; set; }

        public Item2D(double x, double y) : base(x, y)
        {
            Label = $"({X};{Y})";
        }

        public Item2D() : this(0, 0) { }

        public override string ToString()
        {
            return $"{Id} {Label}";
        }

        public override string ToTabbedText()
        {
            return $"{Id}\t{Label}\t{X}\t{Y}";
        }

        public override void FromTabbedText(string s)
        {
            string[] parts = s.Split('\t');
            if (parts.Length != 4)
            {
                throw new InvalidOperationException($"Cannot parse tabbed text: {s}");
            }

            string potentialId = parts[0].Trim();
            Id = string.IsNullOrEmpty(potentialId) ? null : potentialId;
            Label = parts[1];
            X = Double.Parse(parts[2], CultureInfo.InvariantCulture);
            Y = Double.Parse(parts[3].Trim(), CultureInfo.InvariantCulture);
        }

        public override string TabbedTextHeaders()
        {
            return "Id\tLabel\tX\tY";
        }
    }
}
