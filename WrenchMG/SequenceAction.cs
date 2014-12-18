using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WrenchMG
{
    public class SequenceAction : Action
    {
        List<Action> actions = new List<Action>();

        public SequenceAction()
        {

        }

        public virtual Action AddAction(Action a)
        {
            actions.Add(a);

            a.Target = Target;
            a.sequence = this;

            return a;
        }

        public virtual void RemoveAction(Action a)
        {
            actions.Remove(a);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
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

                foreach (Action a in actions)
                    a.Target = Target;
            }
        }
    }
}
