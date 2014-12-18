using System;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
	public class ScaleToAction : TimedAction
	{
		float startScale = 1.0f;
		float endScale = 1.0f;
		bool needsCalc = true;

		public ScaleToAction (float Scale, float Seconds)
			: base(Seconds)
		{
			endScale = Scale;
		}

		public override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			base.Update(gameTime);

			if(needsCalc)
			{
				if(Target != null)
				{
					startScale = Target.Scale;
					needsCalc = false;
				}
			}

			Target.Scale = MathHelper.Lerp (startScale, endScale, Elapsed / Duration);
		}
	}
}

