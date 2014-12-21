using System;

namespace SoundAxis.WrenchMG.Action.Timed
{
    class RotateByAction : TimedAction
    {
        float Rotation = 0.0f;
        float RadianPerMilli = 0.0f;

        public RotateByAction(float Radian, TimeSpan duration, ActionManager actionManager, SequenceAction sequence)
            : base(duration, actionManager, sequence)
        {
            Rotation = Radian;
            RadianPerMilli = Rotation/(Single)duration.TotalMilliseconds;  // * 1000.0f);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
			Target.Rotation += RadianPerMilli * (float)AdjustMilliseconds(gameTime).TotalMilliseconds;
            base.Update(gameTime);
        }
    }
}
