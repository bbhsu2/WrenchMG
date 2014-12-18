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
    public class Node
    {
        protected ActionManager actionMgr = new ActionManager();

        public Vector2 Position = Vector2.Zero;
        public float Scale = 1.0f;
        public float Rotation = 0.0f;
		public Scene scene = null;
		public Color DrawColor = Color.White;

        public Node()
        {
            actionMgr.owner = this;
        }

        public Node(Vector2 position, float scale, float rotation)
        {
            Position = position;
            Scale = scale;
            Rotation = rotation;

            actionMgr.owner = this;
        }

        virtual public void Draw(SpriteBatch sb)
        {
            //
        }

        virtual public void Update(GameTime gameTime)
        {
            actionMgr.Update(gameTime);
        }

        virtual public Rectangle Bounds()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 0, 0);
        }

		virtual public OBB OrientedBounds()
		{
			Rectangle b = Bounds ();
			return new OBB (new Vector2 (b.Center.X, b.Center.Y), Rotation, new Vector2 (b.Width / 2.0f, b.Height / 2.0f));
		}

        virtual public void AddAction(Action a)
        {
            actionMgr.AddAction(a);
        }

        public virtual void RemoveAction(Action a)
        {
            actionMgr.RemoveAction(a);
        }

        public virtual void ClearActions()
        {
            actionMgr.ClearActions();
        }
    }
}
