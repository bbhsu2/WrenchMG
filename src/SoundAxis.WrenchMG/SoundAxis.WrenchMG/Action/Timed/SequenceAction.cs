using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SoundAxis.WrenchMG.Action.Timed
{
    public class SequenceAction : Action
    {
        List<Action> actions = new List<Action>();


        public SequenceAction(ActionManager actionManager, SequenceAction sequence)
            : base(actionManager, sequence)
        {
        }

        public virtual Action AddAction(Action a)
        {
            actions.Add(a);

            a.Target = Target;
            a.Sequence = this;

            return a;
        }

        public virtual void RemoveAction(Action a)
        {
            actions.Remove(a);
        }

        public override void Update(GameTime gameTime)
        {
            if (actions.Count > 0)
            {
                actions[0].Update(gameTime);
            }
            else
                Complete();
        }

        public override Node Target
        {
            get
            {
                return base.Target;
            }
            set
            {
                base.Target = value;

                foreach (global::SoundAxis.WrenchMG.Action.Action a in actions)
                    a.Target = Target;
            }
        }
    }
}
