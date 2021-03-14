using ModuleMatrixClustering.Model;
using ModuleMatrixClusteringTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleMatrixClusteringTests
{
    public class List2DCalculationTests
    {
        [Test]
        public void TestFourSquare()
        {
            var fourSquare = TestObjectFactory.FourSquare();

            var center = fourSquare.Center();
            Assert.AreEqual(0.5, center.X);
            Assert.AreEqual(0.5, center.Y);

            Console.WriteLine(fourSquare.OneDimensionErrorSum());
        }

        [Test]
        public void TestHolyCross()
        {
            var holyCross = TestObjectFactory.HolyCross();

            var center = holyCross.Center();
            Console.WriteLine(center);
            Assert.AreEqual(0, center.X);
            Assert.AreEqual(1d/3, center.Y);

            Console.WriteLine(holyCross.OneDimensionErrorSum());
        }
    }
}
