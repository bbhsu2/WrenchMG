using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
    public class MoveToAction : TimedAction
    {
        Vector2 startPosition = Vector2.Zero;
        Vector2 endPosition = Vector2.Zero;
        bool needsCalc = true;

        public MoveToAction(Vector2 Position, float Seconds)
        : base(Seconds)
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

            Target.Position = Vector2.Lerp(startPosition, endPosition, Elapsed / Duration);

			base.Update(gameTime);
        }

		public override void Complete ()
		{
			Target.Position = endPosition;
			base.Complete ();
		}
    }
}
