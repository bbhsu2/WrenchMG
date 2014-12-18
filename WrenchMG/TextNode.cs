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
        public SpriteFont spriteFont = null;
        public Color color = Color.Black;
        public string text = "";

        public TextNode(Vector2 position)
            : base(position, 1.0f, 0.0f) { }

        public TextNode(SpriteFont nSpriteFont, string Text, Color nColor, Vector2 position)
            : base(position, 1.0f, 0.0f)
        {
            spriteFont = nSpriteFont;
            text = Text;
            color = nColor;
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.DrawString(spriteFont, text, Position, color);
        }

        public override Rectangle Bounds()
        {
            Vector2 size = spriteFont.MeasureString(text);
            return new Rectangle((int)Position.X, (int)Position.Y, (int)size.X, (int)size.Y);
        }
    }
}
