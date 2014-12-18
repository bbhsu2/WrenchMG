using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
    public class Action
    {
        protected Node target = null;
        
		public ActionManager owner = null;
		public SequenceAction sequence = null;

        public virtual void Begin(GameTime gameTime)
        {
            //
        }

        public virtual void Update(GameTime gameTime)
        {
            //
        }

        public virtual void Complete()
        {
            if(owner != null) owner.RemoveAction(this);
            if (sequence != null) sequence.RemoveAction(this);
        }

        public virtual Node Target
        {
            get
            {
                return target;
            }

            set
            {
                target = value;
            }
        }
    }
}
