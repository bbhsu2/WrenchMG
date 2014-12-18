using System;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
	public class MoveByAction : TimedAction
	{
		Vector2 amount = Vector2.Zero;
		Vector2 startPosition = Vector2.Zero;
		Vector2 endPosition = Vector2.Zero;
		bool needsCalc = true;

		public MoveByAction (Vector2 MoveAmount, float Seconds)
			: base(Seconds)
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

			Target.Position = Vector2.Lerp(startPosition, endPosition, Elapsed / Duration);
		}
	}
}

