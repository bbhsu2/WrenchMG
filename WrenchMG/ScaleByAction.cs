using System;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
	public class ScaleByAction : TimedAction
	{
		float startScale = 1.0f;
		float endScale = 1.0f;
		float amount = 0.0f;
		bool needsCalc = true;

		public ScaleByAction (float Scale, float Seconds)
			: base(Seconds)
		{
			amount = Scale;
		}

		public override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			base.Update(gameTime);

			if(needsCalc)
			{
				if(Target != null)
				{
					startScale = Target.Scale;
					endScale = Target.Scale + amount;

					needsCalc = false;
				}
			}

			Target.Scale = MathHelper.Lerp(startScale, endScale, Elapsed / Duration);
		}
	}
}

