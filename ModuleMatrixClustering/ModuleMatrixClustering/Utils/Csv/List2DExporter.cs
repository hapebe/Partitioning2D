using ModuleMatrixClustering.Model;
using Svg;
using Svg.Transforms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ModuleMatrixClustering.Utils.Csv
{
    public class List2DExporter
    {
        private List2D<Item2D> list;

        public List2DExporter(List2D<Item2D> list)
        {
            this.list = list;
        }

        public void SaveTo(string filename)
        {
            List<string> lines = new List<string>();
            lines.Add("ID\tlabel\tx\ty");
            foreach (Item2D item in list)
            {
                lines.Add($"{item.Id}\t{item.Label}\t{item.X}\t{item.Y}");
            }
            File.WriteAllLines(filename, lines);
        }
    }
}
