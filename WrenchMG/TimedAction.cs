using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
    public class TimedAction : Action
    {
        public float Duration = 0.0f;
        public float Elapsed = 0.0f;

        public TimedAction(float seconds)
        {
            Duration = seconds;
        }

        public override void Update(GameTime gameTime)
        {
            Elapsed += 0.001f * (float)gameTime.ElapsedGameTime.Milliseconds;

            if(Elapsed >= Duration)
                Complete();
        }

		public int AdjustMilliseconds(GameTime gameTime)
		{
			if ((0.001f * (float)gameTime.ElapsedGameTime.Milliseconds) > (Duration - Elapsed))
				return (int)((Duration - Elapsed) * 1000.0f);
			return gameTime.ElapsedGameTime.Milliseconds;
		}
    }
}
