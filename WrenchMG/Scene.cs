using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace WrenchMG
{
    public class Scene
    {
		#region Members
        public SpriteBatch spriteBatch;
        List<Node> nodes = new List<Node>();
		List<Node> nodesToAdd = new List<Node> ();
		List<Node> nodesToRemove = new List<Node> ();
		#endregion

        public Scene()
        {
            spriteBatch = new SpriteBatch(Engine.GFXDevice);
        }

        public virtual void Draw()
        {
			spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);

            foreach (Node n in nodes)
                n.Draw(spriteBatch);

            spriteBatch.End();
        }

        public virtual void Update(GameTime gameTime)
        {
			foreach (Node n in nodesToRemove) {
				nodes.Remove (n);
			}
			nodesToRemove.Clear ();

			foreach (Node n in nodesToAdd)
				nodes.Add (n);
			nodesToAdd.Clear ();

            foreach (Node n in nodes)
                n.Update(gameTime);
        }

        public virtual Node AddNode(Node n)
        {
            if (n != null)
            {
                n.Scene = this;
                nodesToAdd.Add(n);
            }
            return n;
        }

        public virtual void RemoveNode(Node n)
        {
			if (n != null) {
				n.Scene = null;
				nodesToRemove.Add (n);
			}
        }

		#region Properties
        public List<Node> Nodes
        {
			get { return nodes; }
        }
		#endregion
    }
}
