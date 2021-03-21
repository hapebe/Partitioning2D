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
    public class PathLengthsInHpTest3 : ConsolePayload
    {
        public string FileBaseName { get; set; }

        public PathLengthsInHpTest3(string fileBaseName)
        {
            FileBaseName = fileBaseName;
        }

        public void Run()
        {
            List2D<Item2D> cluster = new List2D<Item2D>();
            cluster.ReadFromTabbedText(Path.Combine(DATA_DIR, $"{FileBaseName}-coords.txt"));

            w($"center: {cluster.Center()}");
            List2DManipulator.NormalizeCenter(cluster);
            w($"center after normalization: {cluster.Center()}");

            w($"ODD error sum: {cluster.OneDimensionErrorSum()}");
            w($"Rectangular area: {cluster.RectangularArea()} U²");
            w($"Density: {cluster.Count / cluster.RectangularArea()} points per U²");

            w($"EUC error sum: {cluster.EuclideanErrorSum()}");
            w($"Circular area: {cluster.CircularArea()} U²");
            w($"Density: {cluster.Count / cluster.CircularArea()} points per U²");

            w($"size / range: {cluster.GetRange().Size}");

            w($"random element: {cluster.GetRandom()}");



            // List2D<Item2D> shuffled = cluster.GetShuffled();
            // shuffled.WriteToTabbedText(Path.Combine(DATA_DIR, @"11-square-shuffled.txt"));

            //cluster.UpdateOddDistances();
            //File.WriteAllText(Path.Combine(DATA_DIR, $"{FileBaseName}-oddDistances.txt"), cluster.OddDistances.ToTabbedText());

            //cluster.UpdateEuclideanDistances();
            //File.WriteAllText(Path.Combine(DATA_DIR, $"{FileBaseName}-eucDistances.txt"), cluster.EuclideanDistances.ToTabbedText());

            //List<string> pathLengths = new List<string>() { "path_length" };
            //for (int i = 0; i < 1000000; i++)
            //{
            //    PathOnList2D<Item2D> path = new PathOnList2D<Item2D>(cluster, cluster.GetShuffledIndexes());
            //    double l = path.GetCircularLength();
            //    if (i % 1000 == 0) w($"Path {i} length: {l}");
            //    pathLengths.Add(l.ToString(CultureInfo.InvariantCulture));
            //}
            //File.WriteAllLines(Path.Combine(DATA_DIR, $"{FILE_BASENAME}-pathLengths.xl.txt"), pathLengths);

        }
    }
}
