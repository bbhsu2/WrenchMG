using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace WrenchMG
{
    public static class RectangleExtensions
    {
        public static Rectangle[] GetQuadrants(this Rectangle r)
        {
            Rectangle[] quadrants = new Rectangle[4];

            int nWidth = r.Width / 2;
            int nHeight = r.Height / 2;

            quadrants[0] = new Rectangle(nWidth,    0,      nWidth, nHeight);
            quadrants[1] = new Rectangle(0,         0,      nWidth, nHeight);
            quadrants[2] = new Rectangle(0,         nHeight,nWidth, nHeight);
            quadrants[3] = new Rectangle(nWidth,    nHeight,nWidth, nHeight);

            return quadrants;
        }
    }
}
