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
    public class SpriteNode : Node
    {
		#region Members
        protected Sprite m_Sprite = null;
		#endregion

		public SpriteNode()
			: base()
		{
			DrawColor = Color.White;
		}

        public SpriteNode(Vector2 position, float scale, float rotation)
            : base(position, scale, rotation)
		{
			DrawColor = Color.White;
		}

        public SpriteNode(Sprite s, Vector2 position, float scale, float rotation)
            : base(position, scale, rotation)
        {
            this.Sprite = s;
			DrawColor = Color.White;
        }

        public override void Draw(SpriteBatch sb)
        {
			if (this.Sprite != null)
				this.Sprite.Draw(sb, Position, Scale, Rotation, DrawColor);
        }

        public override Rectangle Bounds()
        {
			Rectangle r = this.Sprite.Bounds();

            r.X = (int)(Scale * r.X);
            r.Y = (int)(Scale * r.Y);
            r.Width = (int)(Scale * r.Width);
            r.Height= (int)(Scale * r.Height);

            return new Rectangle(r.X + (int)Position.X, r.Y + (int)Position.Y, r.Width, r.Height);
        }

		#region Properties
		public Sprite Sprite {
			get { return m_Sprite; }
			set { m_Sprite = value; }
		}
		#endregion
    }
}
