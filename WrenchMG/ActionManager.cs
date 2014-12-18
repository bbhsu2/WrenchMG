using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
    public class ActionManager
    {
		public Node owner = null;

        List<Action> toBegin = new List<Action>();
        List<Action> toRemove = new List<Action>();
        List<Action> activeActions = new List<Action>();

        public ActionManager()
        {
            //
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach(Action action in toBegin) {
                action.Begin(gameTime);
                activeActions.Add(action);
            }

            foreach (Action action in activeActions)
                action.Update(gameTime);

            foreach (Action action in toRemove)
            {
                activeActions.Remove(action);
            }

            toBegin.Clear();
            toRemove.Clear();
        }

        public virtual void AddAction(Action a)
        {
            a.owner = this;
            a.Target = owner;

            toBegin.Add(a);
        }

        public virtual void RemoveAction(Action a)
        {
            toRemove.Add(a);
        }

        public virtual void ClearActions()
        {
            toBegin.Clear();
            toRemove.Clear();
            activeActions.Clear();
        }

		public virtual void RemoveAction(Type ofType)
		{
			for (int a = 0; a < activeActions.Count; a++) {
				if (activeActions [a].GetType().IsSubclassOf(ofType) || activeActions [a].GetType() == ofType) {
					activeActions.RemoveAt (a);
					a--;
				}
			}

			for (int a = 0; a < toBegin.Count; a++) {
				if (toBegin [a].GetType ().IsSubclassOf(ofType) || toBegin[a].GetType() == ofType) {
					toBegin.RemoveAt (a);
					a--;
				}
			}

		}

		public virtual bool ContainsActionOfType(Type ofType)
		{
			for (int a = 0; a < activeActions.Count; a++) {
				if (activeActions [a].GetType().IsSubclassOf(ofType) || activeActions [a].GetType() == ofType) {
					return true;
				}
			}

			for (int a = 0; a < toBegin.Count; a++) {
				if (toBegin [a].GetType ().IsSubclassOf(ofType) || toBegin[a].GetType() == ofType) {
					return true;
				}
			}

			return false;
		}
    }
}
