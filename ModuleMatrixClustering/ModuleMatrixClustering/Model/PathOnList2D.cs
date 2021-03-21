using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Model
{
    public class PathOnList2D<T> where T : BaseObject2D, new()
    {
        public List2D<T> List { get; }
        public int[] SequenceOfIndexes { get; }

        public PathOnList2D(List2D<T> list, int[] sequenceOfIndexes)
        {
            List = list;
            SequenceOfIndexes = sequenceOfIndexes;
        }

        /// <summary>
        /// uses Euclidean distances
        /// </summary>
        /// <returns></returns>
        public double GetCircularLength()
        {
            double retval = 0d;
            for (int i=0; i<SequenceOfIndexes.Length; i++)
            {
                int listIdxA = SequenceOfIndexes[i];
                int listIdxB = SequenceOfIndexes[(i + 1) % SequenceOfIndexes.Length]; // i.e. #0 for the last element in the sequence

                retval += List[listIdxA].EuclideanDistanceTo(List[listIdxB]);
            }

            return retval;
        }
    }
}
