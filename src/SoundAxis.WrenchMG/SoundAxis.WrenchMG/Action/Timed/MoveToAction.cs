using System;
using Microsoft.Xna.Framework;

namespace SoundAxis.WrenchMG.Action.Timed
{
    public class MoveToAction : TimedAction
    {
        Vector2 startPosition = Vector2.Zero;
        Vector2 endPosition = Vector2.Zero;
        bool needsCalc = true;

        public MoveToAction(Vector2 Position, TimeSpan duration, ActionManager actionManager, SequenceAction sequence)
            : base(duration, actionManager, sequence)
        {
            endPosition = Position;
        }

        public override void Update(GameTime gameTime)
        {
            
            if(needsCalc)
            {
                if(Target != null)
                {
                    startPosition = Target.Position;

                    needsCalc = false;
                }
            }

            Target.Position = Vector2.Lerp(startPosition, endPosition, (Single)((Single)Elapsed.TotalMilliseconds / (Single)Duration.TotalMilliseconds));

			base.Update(gameTime);
        }

		public override void Complete ()
		{
			Target.Position = endPosition;
			base.Complete ();
		}
    }
}
