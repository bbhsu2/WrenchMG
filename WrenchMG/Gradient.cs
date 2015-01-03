using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace WrenchMG
{
	public enum GradientDirection
	{
		HORIZONTAL	=	0,
		VERTICAL	=	1,
	}

	public class Gradient
	{
		List<Tuple<Color, float>> colors = new List<Tuple<Color, float>>();

		public Gradient ()
		{
		}

		public Gradient(GradientDirection d)
		{
			Direction = d;
		}

		public GradientDirection Direction { get; set; }

		public void AddColor(Color c, float position)
		{
			if(position >= 0.0f && position <= 1.0f)
				colors.Add(Tuple.Create<Color,float>(c,position));
		}

		protected void SortColors()
		{
			for (int a = 0; a < colors.Count - 1; a++) {
				for (int b = a + 1; b < colors.Count; b++) {
					if (colors [b].Item2 < colors [a].Item2) {
						Tuple<Color, float> temp = colors [b];
						colors [b] = colors [a];
						colors [a] = temp;
					}
				}
			}
		}

		protected void AddEdges()
		{
			if (colors [0].Item2 > 0.0)
				colors.Insert (0, Tuple.Create<Color,float> (Color.Transparent, 0.0f));

			if(colors[colors.Count-1].Item2 < 1.0)
				colors.Add(Tuple.Create<Color,float> (Color.Transparent, 1.0f));
		}

		public Texture2D CreateTexture(int width, int height)
		{
			SortColors ();
			AddEdges ();

			Texture2D tex = new Texture2D (Engine.GFXDevice, width, height);
			Color[] c = new Color[width * height];

			for(int y = 0; y < height; y++) {
				for(int x = 0; x < width; x++) {

					float currentPos = (float)x / (float)width;

					if(Direction == GradientDirection.VERTICAL)
						currentPos = (float)y / (float)height;

					for (int a = 0; a < colors.Count - 1; a++) {
						if (currentPos >= colors [a].Item2 && colors[a+1].Item2 >= currentPos) {

							float lerpValue = (currentPos - colors [a].Item2) / (colors [a + 1].Item2 - colors [a].Item2);

							c [y * width + x] = Color.Lerp (colors [a].Item1, colors [a + 1].Item1, lerpValue);

							break;
						}
					}
				}
			}

			tex.SetData<Color> (c, 0, width * height);
			return tex;
		}
	}
}

