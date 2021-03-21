using ModuleMatrixClustering.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Utils
{
    public class SquareSetFactory
    {
        public static List2D<Item2D> GetSquareSet(int n)
        {
            var list = new List2D<Item2D>();

            int cnt = 0;
            for (int x=0; x<n; x++)
            {
                for (int y=0; y<n; y++)
                {
                    Item2D item = new Item2D(x, y);
                    item.Id = $"p{cnt + 1}";

                    if (x == 0 && y == 0) item.Label = "top-left";
                    if (x == 0 && y == n-1) item.Label = "bottom-left";
                    if (x == n-1 && y == 0) item.Label = "top-right";
                    if (x == n-1 && y == n-1) item.Label = "bottom-right";

                    list.Add(item);

                    cnt++;
                }
            }

            List2DManipulator.NormalizeCenter(list);

            return list;
        }
    }
}
