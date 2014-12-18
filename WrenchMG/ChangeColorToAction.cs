using System;

using Microsoft.Xna.Framework;

namespace WrenchMG
{
	public class ChangeColorToAction : TimedAction
	{
		bool needsCalc = true;
		Color targetColor = Color.White;
		Color startColor = Color.White;

		float r,g,b,a;

		public ChangeColorToAction (Color tColor, float seconds)
			: base(seconds)
		{
			targetColor = tColor;
		}

		public override void Update (GameTime gameTime)
		{
			if (needsCalc) {
				if (Target != null) {
					startColor = Target.DrawColor;

					r = (targetColor.R - startColor.R) / (Duration);
					g = (targetColor.G - startColor.G) / (Duration);
					b = (targetColor.B - startColor.B) / (Duration);
					a = (targetColor.A - startColor.A) / (Duration);

					needsCalc = false;
				}
			}

			Target.DrawColor = new Color (startColor.R + (int)(r * Elapsed), startColor.G + (int)(g * Elapsed), startColor.B + (int)(b * Elapsed), startColor.A + (int)(a * Elapsed));

			base.Update (gameTime);
		}

		public override void Complete ()
		{
			Target.DrawColor = targetColor;
			base.Complete ();
		}
	}
}

