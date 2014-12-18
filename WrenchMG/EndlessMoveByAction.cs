using System;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
	public class EndlessMoveByAction : MoveByAction
	{
		Vector2 movePerMilli;

		public EndlessMoveByAction (Vector2 movePerMillisecond)
			: base (Vector2.Zero, 0.0f)
		{
			movePerMilli = movePerMillisecond;
		}

		public override void Update (GameTime gameTime)
		{
			Target.Position += (movePerMilli * (float)gameTime.ElapsedGameTime.Milliseconds);
		}

		public override void Complete ()
		{
			//does not complete
		}
	}
}

