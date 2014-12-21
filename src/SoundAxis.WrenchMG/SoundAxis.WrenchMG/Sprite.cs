using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoundAxis.WrenchMG
{
    public class Sprite
    {
        public Texture2D texture;
        Rectangle coords;
        Vector2 origin;

		public Sprite(string filename)
		{
			texture = Engine.ContentMgr.Load<Texture2D> (filename);

			coords = new Rectangle(0, 0, texture.Width, texture.Height);
			origin = new Vector2(coords.Width / 2, coords.Height / 2);
		}

        public Sprite(Texture2D nTexture, Rectangle? nCoords = null, Vector2? nOrigin = null)
        {
            texture = nTexture;

            if(nCoords.HasValue)
                coords = nCoords.Value;
            else
                coords = new Rectangle(0, 0, texture.Width, texture.Height);

            if(nOrigin.HasValue)
                origin = nOrigin.Value;
            else
                origin = new Vector2(coords.Width / 2, coords.Height / 2);
        }

		public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, float scale, float rotation, Color c)
        {
            spriteBatch.Draw(texture, position, coords, c, rotation, origin, scale, SpriteEffects.None, 0.0f);
        }

        public virtual Rectangle Bounds()
        {
            return new Rectangle(-(int)origin.X, -(int)origin.Y, coords.Width, coords.Height);
        }
    }
}
