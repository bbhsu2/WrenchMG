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
    public class Sprite
    {
        Texture2D m_Texture;
        Rectangle m_Coords;
        Vector2 m_Origin;

		public Sprite(string filename)
		{
			this.Texture = Engine.ContentMgr.Load<Texture2D> (filename);

			Coordinates = new Rectangle(0, 0, Texture.Width, Texture.Height);
			Origin = new Vector2(Coordinates.Width / 2, Coordinates.Height / 2);
		}

        public Sprite(Texture2D nTexture, Rectangle? nCoords = null, Vector2? nOrigin = null)
        {
            Texture = nTexture;

            if(nCoords.HasValue)
				Coordinates = nCoords.Value;
            else
				Coordinates = new Rectangle(0, 0, Texture.Width, Texture.Height);

            if(nOrigin.HasValue)
                Origin = nOrigin.Value;
            else
				Origin = new Vector2(Coordinates.Width / 2, Coordinates.Height / 2);
        }

		public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, float scale, float rotation, Color c)
        {
			spriteBatch.Draw(Texture, position, Coordinates, c, rotation, Origin, scale, SpriteEffects.None, 0.0f);
        }

		#region Properties
        public virtual Rectangle Bounds
        {
			get { return new Rectangle (-(int)Origin.X, -(int)Origin.Y, Coordinates.Width, Coordinates.Height); }
        }

		public Texture2D Texture {
			get { return m_Texture; }
			set { m_Texture = value; }
		}

		public Rectangle Coordinates {
			get { return m_Coords; }
			set { m_Coords = value; }
		}

		public Vector2 Origin {
			get { return m_Origin; }
			set { m_Origin = value; }
		}

		#endregion
    }
}
