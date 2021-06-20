using ModuleMatrixClustering.Model;
using ModuleMatrixClustering.Utils;
using ModuleMatrixClustering.Utils.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Experiments
{
    public class GenerateRandomItems : ConsolePayload
    {
        public int N { get; set; }

        public GenerateRandomItems(int n)
        {
            N = n;
        }

        public void Run()
        {
            var rnd = new Random();

            List2D<Item2D> items = new List2D<Item2D>();
            double rescale = Math.Sqrt(2d);
            for (int i=0; i<N; i++)
            {
                double xOrig = rnd.NextGaussian();
                double yOrig = rnd.NextGaussian();

                // now rotate the original point:
                double rad = rnd.NextDouble() * 2 * Math.PI;
                double x = xOrig * Math.Cos(rad) - yOrig * Math.Sin(rad);
                double y = xOrig * Math.Sin(rad) + yOrig * Math.Cos(rad);

                // ... or don't rotate:
                // double x = xOrig; double y = yOrig;

                var item = new Item2D(x,y);
                item.Label = $"p{i}";
                items.Add(item);
            }

            List2DManipulator.NormalizeCenter(items);

            List2DExporter exporter = new List2DExporter(items);
            exporter.SaveTo(Path.Combine(DATA_DIR, "randomItems.txt"));

        }
    }
}
