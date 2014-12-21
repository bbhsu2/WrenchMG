using System;

namespace SoundAxis.WrenchMG.Action.Timed
{
	public class RotateToAction : TimedAction
	{
		float Rotation = 0.0f;
		float RadianPerMilli = 0.0f;
		bool needsCalc = true;

		public RotateToAction (float Radian, TimeSpan duration, ActionManager actionManager, SequenceAction sequence)
            : base(duration, actionManager, sequence)
		{
			Rotation = Radian;
		}

		public override void Update (Microsoft.Xna.Framework.GameTime gameTime)
		{
			if (needsCalc) {
				if (Target != null)
				{
				    RadianPerMilli = (Target.Rotation - Rotation)/(float) Duration.TotalMilliseconds; //(Duration * 1000.0f);
					needsCalc = false;
				}
			}

			Target.Rotation += RadianPerMilli * (float)AdjustMilliseconds(gameTime).TotalMilliseconds;
			base.Update(gameTime);
		}

		public override void Complete ()
		{
			Target.Rotation = Rotation;
			base.Complete ();
		}
	}
}

