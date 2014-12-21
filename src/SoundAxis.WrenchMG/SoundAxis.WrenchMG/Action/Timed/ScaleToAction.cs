using System;
using Microsoft.Xna.Framework;

namespace SoundAxis.WrenchMG.Action.Timed
{
    public class ScaleToAction : TimedAction
    {
        float startScale = 1.0f;
        float endScale = 1.0f;
        bool needsCalc = true;

        public ScaleToAction(Single Scale, TimeSpan duration, ActionManager actionManager, SequenceAction sequence)
            : base(duration, actionManager, sequence)
        {
            endScale = Scale;
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Update(gameTime);

            if (needsCalc)
            {
                if (Target != null)
                {
                    startScale = Target.Scale;
                    needsCalc = false;
                }
            }

            Target.Scale = MathHelper.Lerp(startScale, endScale, (Single)((Single)Elapsed.TotalMilliseconds / (Single)Duration.TotalMilliseconds));
        }
    }
}

