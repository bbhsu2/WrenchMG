using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using WrenchMG;

namespace WrenchMG
{
	public class LineNode : Node
	{
		List<Vector2> pointsToDraw = null;

		public LineNode (List<Vector2> pList)
		{
			pointsToDraw = pList;
		}

		public override void Draw (SpriteBatch sb)
		{
			for (int a = 0; a < pointsToDraw.Count - 1; a++) {
				LineBatch.DrawLine (sb, Color.White, pointsToDraw [a], pointsToDraw [a + 1]);
			}
		}
	}
}

