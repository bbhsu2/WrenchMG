using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WrenchMG
{
    class RotateByAction : TimedAction
    {
        float Rotation = 0.0f;
        float RadianPerMilli = 0.0f;

        public RotateByAction(float Radian, float Seconds)
            : base(Seconds)
        {
            Rotation = Radian;
            RadianPerMilli = Rotation / (Seconds * 1000.0f);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
			Target.Rotation += RadianPerMilli * (float)AdjustMilliseconds(gameTime);
            base.Update(gameTime);
        }
    }
}
