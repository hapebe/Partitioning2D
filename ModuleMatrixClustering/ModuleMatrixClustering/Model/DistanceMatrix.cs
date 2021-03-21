using ModuleMatrixClustering.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Model
{
    public class DistanceMatrix : ITabbedTextable
    {
        /// <summary>
        /// only values with (index0) less of equal (index1) are valid - use Get() and Set() to avoid problems
        /// </summary>
        public double[,] Distances { get; }

        public DistanceMatrix(int n)
        {
            Distances = new double[n, n];
        }

        public void Set(int i, int j, double d)
        {
            if (i > j)
            {
                Distances[j, i] = d;
            } 
            else
            {
                Distances[i, j] = d;
            }
        }

        public double Get(int i, int j)
        {
            if (i > j)
            {
                return Distances[j, i];
            } 
            else
            {
                return Distances[i, j];
            }
        }

        public string TabbedTextHeaders()
        {
            return "point_idx_a\tpoint_idx_b\tdistance";
        }

        public string ToTabbedText()
        {
            return ToTabbedText(includeDistancesToSelf: false);
        }

        public string ToTabbedText(bool includeDistancesToSelf)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(TabbedTextHeaders());
            for (int i=0; i<Distances.GetLength(0); i++)
            {
                for (int j=i; j<Distances.GetLength(1); j++)
                {
                    if (j == i && (!includeDistancesToSelf))
                        continue;

                    sb.AppendLine($"{i}\t{j}\t{Distances[i, j]}");
                }
            }
            return sb.ToString();
        }

        public void FromTabbedText(string s)
        {
            throw new NotImplementedException();
        }
    }
}
