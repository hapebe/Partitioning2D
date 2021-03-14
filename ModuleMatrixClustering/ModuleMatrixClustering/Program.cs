using ModuleMatrixClustering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering
{
    class Program
    {
        static void Main(string[] args)
        {
            Set2D set = new Set2D();
            set.Add(new Item2D(0, 0));
            set.Add(new Item2D(0, 1));
            set.Add(new Item2D(1, 0));
            set.Add(new Item2D(1, 1));

            w($"center: {set.Center()}");
            w($"error sum: {set.OneDimensionErrorSum()}");

            Console.ReadKey();
        }

        public static void w(string s)
        {
            Console.WriteLine(s);
        }
    }

}
