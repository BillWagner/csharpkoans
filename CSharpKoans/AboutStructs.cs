using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    public class AboutStructs : KoanContainer
    {
        public struct Point
        {
            public double X;
            public double Y;
        }

        private const double FILL_ME_IN = -1;

        [Koan]
        public void UnderstandDefaultValuesForStructcs()
        {
            var pt = new Point();

            Assert.AreEqual(FILL_ME_IN, pt.X);
            Assert.AreEqual(FILL_ME_IN, pt.Y);
        }

        [Koan]
        public void UnderstandStructCopySemantics()
        {
            var pt1 = new Point
            {
                X = 3,
                Y = 4
            };

            var pt2 = pt1;

            pt2.X *= 2;
            pt2.Y *= 2;

            Assert.AreEqual(FILL_ME_IN, pt1.X);
            Assert.AreEqual(FILL_ME_IN, pt1.Y);
            Assert.AreEqual(FILL_ME_IN, pt2.X);
            Assert.AreEqual(FILL_ME_IN, pt2.Y);
        }

        [Koan]
        public void UndestandStructConversionsToObject()
        {
            var pt1 = new Point
            {
                X = 3,
                Y = 4
            };

            object pt2 = pt1;

            pt1.X = 12;

            Assert.AreEqual(FILL_ME_IN, ((Point)pt2).X);
        }

        [Koan]
        public void UnderstandHowToCreateMethodsInStructs()
        {
            var pt1 = new Point
            {
                X = 3,
                Y = 4
            };

            double distance = -1;

            // Uncomment this line and implement the distance property:
            // Hint: The System.Math class has a Sqrt() method that calculates Square ruuts.
            // distance = pt1.Distance();

            Assert.AreEqual(5, distance);
        }
    }
}