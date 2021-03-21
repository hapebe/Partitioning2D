using ModuleMatrixClustering.Model;
using ModuleMatrixClustering.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Experiments
{
    public class ExploreList2D : ConsolePayload
    {
        public string BaseName { get; set; }
        public List2D<Item2D> List { get; set; }

        public ExploreList2D(List2D<Item2D> list, string baseName)
        {
            List = list;
            BaseName = baseName;
        }

        public void Run()
        {
            w($"center: {List.Center()}");
            var pointCount = List.Count; 

            var oddErrSum = List.OneDimensionErrorSum(); w($"ODD error sum: {oddErrSum}");
            var rectArea = List.RectangularArea(); w($"Rectangular area: {rectArea} U²");
            var rectDensity = List.Count / List.RectangularArea();  w($"Density: {rectDensity} points per U²");

            var eucErrSum = List.EuclideanErrorSum(); w($"EUC error sum: {eucErrSum}");
            var circArea = List.CircularArea(); w($"Circular area: {circArea} U²");
            var circDensity = List.Count / List.CircularArea(); w($"Density: {circDensity} points per U²");

            var size = List.GetRange().Size; w($"size / range: {size}");

            w($"random element: {List.GetRandom()}");

            File.AppendAllText(
                Path.Combine(DATA_DIR, $"ExploreList2D-results.txt"),
                $"{BaseName}\t{pointCount}\t{oddErrSum}\t{rectArea}\t{rectDensity}\t{eucErrSum}\t{circArea}\t{circDensity}\t{size}\r\n"
            );

            // List2D<Item2D> shuffled = List.GetShuffled();
            // shuffled.WriteToTabbedText(Path.Combine(DATA_DIR, $"{BaseName}-shuffled.txt"));

            List.UpdateOddDistances();
            File.WriteAllText(Path.Combine(DATA_DIR, $"{BaseName}-oddDistances.txt"), List.OddDistances.ToTabbedText());

            List.UpdateEuclideanDistances();
            File.WriteAllText(Path.Combine(DATA_DIR, $"{BaseName}-eucDistances.txt"), List.EuclideanDistances.ToTabbedText());

            List<string> pathLengths = new List<string>() { "path_length" };
            for (int i = 0; i < 1000000; i++)
            {
                PathOnList2D<Item2D> path = new PathOnList2D<Item2D>(List, List.GetShuffledIndexes());
                double l = path.GetCircularLength();
                if (i % 1000 == 0) w($"Path {i} length: {l}");
                pathLengths.Add(l.ToString("G6", CultureInfo.InvariantCulture));
            }
            File.WriteAllLines(Path.Combine(DATA_DIR, $"{BaseName}-pathLengths.xl.txt"), pathLengths);

        }
    }
}
