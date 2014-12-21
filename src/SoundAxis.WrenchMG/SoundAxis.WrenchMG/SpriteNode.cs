using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoundAxis.WrenchMG
{
    public class SpriteNode : Node
    {
        public Sprite sprite = null;

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
            sprite = s;
			DrawColor = Color.White;
        }

        public override void Draw(SpriteBatch sb)
        {
            if (sprite != null)
				sprite.Draw(sb, Position, Scale, Rotation, DrawColor);
        }

        public override Rectangle Bounds()
        {
            Rectangle r = sprite.Bounds();

            r.X = (int)(Scale * r.X);
            r.Y = (int)(Scale * r.Y);
            r.Width = (int)(Scale * r.Width);
            r.Height= (int)(Scale * r.Height);

            return new Rectangle(r.X + (int)Position.X, r.Y + (int)Position.Y, r.Width, r.Height);
        }
    }
}
