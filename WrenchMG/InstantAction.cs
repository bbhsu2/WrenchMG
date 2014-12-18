using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
    public class InstantAction : Action
    {
        public InstantAction()
        {

        }

        public override void Update(GameTime gameTime)
        {
            Complete();
        }
    }
}
