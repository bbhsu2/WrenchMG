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
		#region Members
        protected ActionManager actionMgr = new ActionManager();
		protected Vector2 m_Position = Vector2.Zero;
		protected float m_Scale = 1.0f;
		protected float m_Rotation = 0.0f;
		protected Scene m_Scene = null;
		protected Color m_DrawColor = Color.White;
		#endregion

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

		#region Properties
		virtual public Rectangle Bounds
		{
			get { return new Rectangle ((int)Position.X, (int)Position.Y, 0, 0); }
		}

		virtual public OBB OrientedBounds
		{
			get {
				Rectangle b = Bounds;
				return new OBB (new Vector2 (b.Center.X, b.Center.Y), Rotation, new Vector2 (b.Width / 2.0f, b.Height / 2.0f));
			}
		}

		public Vector2 Position {
			get { return m_Position; }
			set { m_Position = value; }
		}

		public float Scale {
			get { return m_Scale; }
			set { m_Scale = value; }
		}

		public float Rotation {
			get { return m_Rotation; }
			set { m_Rotation = value; }
		}

		public Scene Scene {
			get { return this.m_Scene; }
			set { this.m_Scene = value; }
		}

		public Color DrawColor {
			get { return m_DrawColor; }
			set { m_DrawColor = value; }
		}
		#endregion
    }
}
