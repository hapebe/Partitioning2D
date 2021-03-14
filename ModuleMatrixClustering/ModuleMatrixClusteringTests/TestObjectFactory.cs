using ModuleMatrixClustering.Model;

namespace ModuleMatrixClusteringTests
{
    public class TestObjectFactory
    {
        public static List2D FourSquare()
        {
            Item2D a = new Item2D(0, 0);
            Item2D b = new Item2D(1, 0);
            Item2D c = new Item2D(0, 1);
            Item2D d = new Item2D(1, 1);

            List2D retval = new List2D() { a, b, c, d };
            return retval;
        }

        public static List2D HolyCross()
        {
            Item2D l = new Item2D(-1, 0);
            Item2D c = new Item2D(0, 0);
            Item2D r = new Item2D(1, 0);

            Item2D t = new Item2D(0, -1);
            Item2D b1 = new Item2D(0, 1);
            Item2D b2 = new Item2D(0, 2);

            List2D retval = new List2D() { l, c, r, t, b1, b2 };
            return retval;
        }

    }
}
