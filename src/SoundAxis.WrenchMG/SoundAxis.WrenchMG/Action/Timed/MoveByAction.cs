using System;
using Microsoft.Xna.Framework;

namespace SoundAxis.WrenchMG.Action.Timed
{
	public class MoveByAction : TimedAction
	{
		Vector2 amount = Vector2.Zero;
		Vector2 startPosition = Vector2.Zero;
		Vector2 endPosition = Vector2.Zero;
		bool needsCalc = true;

		public MoveByAction (Vector2 MoveAmount, TimeSpan duration, ActionManager actionManager, SequenceAction sequence)
            : base(duration, actionManager, sequence)
		{
			amount = MoveAmount;
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);

			if(needsCalc)
			{
				if(Target != null)
				{
					startPosition = Target.Position;
					endPosition = Target.Position + amount;

					needsCalc = false;
				}
			}

            Target.Position = Vector2.Lerp(startPosition, endPosition, (Single)((Single)Elapsed.TotalMilliseconds / (Single)Duration.TotalMilliseconds));
		}
	}
}

