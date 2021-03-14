using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleMatrixClustering.Model
{
    public class Set2D : HashSet<BaseObject2D>
    {
        public BaseObject2D Center()
        {
            BaseObject2D retval = new BaseObject2D();
            foreach (var item in this)
            {
                retval.Add(item);
            }
            retval.Scale(1d / this.Count);

            return retval;
        }

        public double OneDimensionErrorSum()
        {
            BaseObject2D c = Center();
            double errorSum = 0;

            foreach (var item in this)
            {
                errorSum += Math.Abs(item.OneDimensionDistanceTo(c));
            }

            return errorSum;
        }
    }
}
