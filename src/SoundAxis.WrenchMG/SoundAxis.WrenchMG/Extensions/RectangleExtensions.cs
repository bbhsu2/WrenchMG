using System;
using Microsoft.Xna.Framework;

namespace SoundAxis.WrenchMG.Extensions
{
    /// <summary>
    /// Language extension class for <see cref="Rectangle"/>.
    /// </summary>
    public static class RectangleExtensions
    {
        /// <summary>
        /// Gets the quadrants for the specified <paramref name="rectangle"/>.
        /// </summary>
        /// <param name="rectangle">The rectangle from which to derive the quadrants.</param>
        public static Rectangle[] GetQuadrants(this Rectangle rectangle)
        {
            Rectangle[] quadrants = new Rectangle[4];

            Int32 halfWidth = rectangle.Width / 2;
            Int32 halfHeight = rectangle.Height / 2;

            quadrants[0] = new Rectangle(halfWidth, 0, halfWidth, halfHeight);
            quadrants[1] = new Rectangle(0, 0, halfWidth, halfHeight);
            quadrants[2] = new Rectangle(0, halfHeight, halfWidth, halfHeight);
            quadrants[3] = new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight);

            return quadrants;
        }
    }
}
