using ModuleMatrixClustering.Experiments;
using ModuleMatrixClustering.Model;
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
            List2D<Item2D> cluster = new List2D<Item2D>();
            cluster.ReadFromTabbedText(Path.Combine(DATA_DIR, @"11-square.txt"));

            cluster.UpdateOddDistances();
            File.WriteAllText(Path.Combine(DATA_DIR, @"11-square-oddDistances.txt"), cluster.OddDistances.ToTabbedText());

            // var payload = new PathLengthsIn11Square(); payload.Run();
            var payload = new PathLengthsInHpTest3(); payload.Run();

            Console.ReadKey();
        }

    }

}
