using ModuleMatrixClustering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Utils
{
    public static class List2DManipulator
    {
        public static void NormalizeCenter(List2D<Item2D> list)
        {
            BaseObject2D offset = new BaseObject2D();
            offset.Add(list.Center());
            offset.Scale(-1d);

            foreach (var point in list)
            {
                point.Add(offset);
            }
        }
    }
}
