using ModuleMatrixClustering.Experiments;
using ModuleMatrixClustering.Model;
using ModuleMatrixClustering.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering
{
    class Program : ConsolePayload
    {
        static void Main(string[] args)
        {
            // List2D<Item2D> cluster = new List2D<Item2D>();
            // cluster.ReadFromTabbedText(Path.Combine(DATA_DIR, @"11-square.txt"));

            string baseName = "15-square";
            var cluster = SquareSetFactory.GetSquareSet(15);

            // var payload = new PathLengthsInHpTest3("HP-Test3"); payload.Run();
            var payload = new ExploreList2D(cluster, baseName);
            payload.Run();

            // Console.ReadKey();
        }

    }

}
