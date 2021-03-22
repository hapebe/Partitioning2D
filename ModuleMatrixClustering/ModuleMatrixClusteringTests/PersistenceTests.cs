using ModuleMatrixClustering.Model;
using ModuleMatrixClusteringTests;
using NUnit.Framework;
using System;
using System.IO;

namespace ModuleMatrixClusteringTests
{
    public class PersistenceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestItem2DTabbedTextable()
        {
            Item2D original = new Item2D(1, -3)
            {
                Id = "c1"
            };
            // Label is implicitly set

            Item2D copy = new Item2D(0,0);
            copy.FromTabbedText(original.ToTabbedText());

            Assert.AreEqual(original.Id, copy.Id);
            Assert.AreEqual(original.Label, copy.Label);
            Assert.AreEqual(original.X, copy.X);
            Assert.AreEqual(original.Y, copy.Y);
        }

        [Test]
        public void TestList2DAndTabbedText()
        {
            string tempFilename = Path.GetTempFileName();

            var original = TestObjectFactory.FourSquare();
            original.WriteToTabbedText(tempFilename);

            // Console.WriteLine(File.ReadAllText(tempFilename));

            var copy = new List2D<Item2D>();
            copy.ReadFromTabbedText(tempFilename);

            Assert.AreEqual(original.Count, copy.Count);
            Assert.AreEqual(((Item2D)original[3]).Id, ((Item2D)copy[3]).Id);
            Assert.AreEqual(((Item2D)original[3]).Label, ((Item2D)copy[3]).Label);
            Assert.AreEqual(original[3].X, copy[3].X);
            Assert.AreEqual(original[3].Y, copy[3].Y);

            File.Delete(tempFilename);
        }
    }
}