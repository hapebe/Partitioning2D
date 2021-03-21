using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Model
{
    public class Range2D
    {
        public BaseObject2D Min { get; set; }
        public BaseObject2D Max { get; set; }

        public BaseObject2D Size => new BaseObject2D()
        {
            X = Max.X - Min.X,
            Y = Max.Y - Min.Y
        };

        public BaseObject2D Center => new BaseObject2D()
        {
            X = (Min.X + Max.X) / 2d,
            Y = (Min.Y + Max.Y) / 2d
        };

        public double Area => Size.X * Size.Y;
    }
}
