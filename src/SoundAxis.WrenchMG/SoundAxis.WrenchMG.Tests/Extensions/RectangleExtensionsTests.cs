using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using SoundAxis.WrenchMG.Extensions;

namespace SoundAxis.WrenchMG.Tests.Extensions
{
    [TestClass]
    public class RectangleExtensionsTests
    {
        [TestMethod]
        public void GetQuadrantsWithEmptyRectangle_ReturnsExpected()
        {
            Rectangle rectangle = Rectangle.Empty;
            Rectangle[] expectedRectangle = new Rectangle[4] {Rectangle.Empty, Rectangle.Empty, Rectangle.Empty, Rectangle.Empty};

            Rectangle[] actualRectangle = RectangleExtensions.GetQuadrants(rectangle);

            Int32  expected = 0;
            Int32 actual = 0;

            for (Int32 index = 0; index < 4; index++)
            {
                actual += actualRectangle[index].X;
                actual += actualRectangle[index].Y;
                actual += actualRectangle[index].Height;
                actual += actualRectangle[index].Width;
            }

            Assert.AreEqual(expected, actual);
        }
    }
}
