using Microsoft.Xna.Framework;
using SoundAxis.WrenchMG.Action.Timed;

namespace SoundAxis.WrenchMG.Action.Instant
{
    public class InstantAction : Action
    {
        public InstantAction(ActionManager actionManager, SequenceAction sequence)
            : base(actionManager, sequence)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Complete();
        }
    }
}
