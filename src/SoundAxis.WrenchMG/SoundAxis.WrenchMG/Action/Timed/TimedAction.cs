using System;
using Microsoft.Xna.Framework;

namespace SoundAxis.WrenchMG.Action.Timed
{
    public class TimedAction : Action
    {
        public TimedAction(TimeSpan duration, ActionManager actionManager, SequenceAction sequence)
            : base(actionManager, sequence)
        {
            Duration = duration;
        }

        public TimeSpan Duration { get; protected set; }
        public TimeSpan Elapsed { get; protected set; }


        public override void Update(GameTime gameTime)
        {
            Elapsed += gameTime.ElapsedGameTime;

            if(Elapsed >= Duration)
                Complete();
        }

		public TimeSpan AdjustMilliseconds(GameTime gameTime)
		{
			if (gameTime.ElapsedGameTime > (Duration - Elapsed))
				return (Duration - Elapsed);

			return gameTime.ElapsedGameTime;
		}
    }
}
