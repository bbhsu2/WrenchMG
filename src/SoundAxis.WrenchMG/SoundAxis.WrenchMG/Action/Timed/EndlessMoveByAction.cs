using System;
using Microsoft.Xna.Framework;

namespace SoundAxis.WrenchMG.Action.Timed
{
	public class EndlessMoveByAction : MoveByAction
	{
		Vector2 movePerMilli;

		public EndlessMoveByAction (Vector2 movePerMillisecond, ActionManager actionManager, SequenceAction sequence)
			: base (Vector2.Zero, new TimeSpan(), actionManager, sequence)
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

