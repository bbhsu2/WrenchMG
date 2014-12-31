using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WrenchMG
{
    public class TextNode : Node
    {
		#region Members
		protected SpriteFont m_SpriteFont = null;
        protected string m_Text = "";
		#endregion

        public TextNode(Vector2 position)
            : base(position, 1.0f, 0.0f) { }

        public TextNode(SpriteFont nSpriteFont, string text, Color nColor, Vector2 position)
            : base(position, 1.0f, 0.0f)
        {
            Font = nSpriteFont;
            Text = text;
            DrawColor = nColor;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.DrawString(Font, Text, Position, DrawColor);
        }

		#region Properties
		public override Rectangle Bounds
		{
			get {
				Vector2 size = Font.MeasureString (Text);
				return new Rectangle ((int)Position.X, (int)Position.Y, (int)size.X, (int)size.Y);
			}
		}

		public SpriteFont Font {
			get { return m_SpriteFont; }
			set { m_SpriteFont = value; }
		}

		public string Text {
			get { return m_Text; }
			set { m_Text = value; }
		}
		#endregion
    }
}
