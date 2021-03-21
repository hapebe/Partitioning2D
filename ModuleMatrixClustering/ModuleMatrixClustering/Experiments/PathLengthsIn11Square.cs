using ModuleMatrixClustering.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Experiments
{
    public class PathLengthsIn11Square : ConsolePayload
    {
        public void Run()
        {
            List2D<Item2D> cluster = new List2D<Item2D>();
            cluster.ReadFromTabbedText(Path.Combine(DATA_DIR, "11-square.txt"));

            // List2D<Item2D> shuffled = cluster.GetShuffled();
            // shuffled.WriteToTabbedText(Path.Combine(DATA_DIR, @"11-square-shuffled.txt"));

            List<string> pathLengths = new List<string>() { "path_length" };
            for (int i = 0; i < 1000000; i++)
            {
                PathOnList2D<Item2D> path = new PathOnList2D<Item2D>(cluster, cluster.GetShuffledIndexes());
                double l = path.GetCircularLength();
                if (i % 1000 == 0) w($"Path {i} length: {l}");
                pathLengths.Add(l.ToString(CultureInfo.InvariantCulture));
            }
            File.WriteAllLines(Path.Combine(DATA_DIR, @"11-square-pathLengths.txt"), pathLengths);

        }
    }
}
