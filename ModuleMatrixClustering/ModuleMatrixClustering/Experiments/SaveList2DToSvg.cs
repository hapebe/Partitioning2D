using ModuleMatrixClustering.Model;
using ModuleMatrixClustering.Utils.Svg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Experiments
{
    public class SaveList2DToSvg : ConsolePayload
    {
        List2D<Item2D> cluster;
        string basename;

        public SaveList2DToSvg(List2D<Item2D> cluster, string basename)
        {
            this.cluster = cluster;
            this.basename = basename;
        }

        public void Run()
        {
            var exporter = new List2DExporter();
            var bounds = exporter.Draw(cluster);
            exporter.SaveTo(Path.Combine(DATA_DIR, basename + ".svg"));

            w($"Bounds: {bounds}");
        }
    }
}
