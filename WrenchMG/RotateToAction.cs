using System;

namespace WrenchMG
{
	public class RotateToAction : TimedAction
	{
		float Rotation = 0.0f;
		float RadianPerMilli = 0.0f;
		bool needsCalc = true;

		public RotateToAction (float Radian, float Seconds)
			: base(Seconds)
		{
			Rotation = Radian;
		}

		public override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			if (needsCalc) {
				if (Target != null) {
					RadianPerMilli = (Target.Rotation - Rotation) / (Duration * 1000.0f);
					needsCalc = false;
				}
			}

			Target.Rotation += RadianPerMilli * (float)AdjustMilliseconds(gameTime);
			base.Update(gameTime);
		}

		public override void Complete ()
		{
			Target.Rotation = Rotation;
			base.Complete ();
		}
	}
}

