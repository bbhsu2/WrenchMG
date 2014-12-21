using System;
using Microsoft.Xna.Framework;

namespace SoundAxis.WrenchMG.Action.Timed
{
	public class ChangeColorToAction : TimedAction
	{
		bool needsCalc = true;
		Color targetColor = Color.White;
		Color startColor = Color.White;

		float r,g,b,a;

		public ChangeColorToAction (Color tColor, TimeSpan duration, ActionManager actionManager, SequenceAction sequence)
            : base(duration, actionManager, sequence)
		{
			targetColor = tColor;
		}

		public override void Update (GameTime gameTime)
		{
			if (needsCalc) {
				if (Target != null) {
					startColor = Target.DrawColor;

					r = (targetColor.R - startColor.R) / ((Single)Duration.TotalMilliseconds);
					g = (targetColor.G - startColor.G) / ((Single)Duration.TotalMilliseconds);
					b = (targetColor.B - startColor.B) / ((Single)Duration.TotalMilliseconds);
					a = (targetColor.A - startColor.A) / ((Single)Duration.TotalMilliseconds);

					needsCalc = false;
				}
			}

			Target.DrawColor = new Color (
                startColor.R + (int)(r * Elapsed.TotalMilliseconds), 
                startColor.G + (int)(g * Elapsed.TotalMilliseconds), 
                startColor.B + (int)(b * Elapsed.TotalMilliseconds), 
                startColor.A + (int)(a * Elapsed.TotalMilliseconds));

			base.Update (gameTime);
		}

		public override void Complete ()
		{
			Target.DrawColor = targetColor;
			base.Complete ();
		}
	}
}

