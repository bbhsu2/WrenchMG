using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoundAxis.WrenchMG
{
    /// <summary>
    /// Static utility class for the line batch.
    /// </summary>
    public static class LineBatch
    {
        /// <summary>
        /// Gets the current empty texture which was initialized with 
        /// the graphics device.
        /// </summary>
        public static Texture2D EmptyTexture { get; private set; }

        /// <summary>
        /// Initializes the line batch with the specified 
        /// <paramref name="device"/>.
        /// </summary>
        /// <param name="device">The graphics device to which to 
        /// initialize.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="device"/> 
        /// is null.</exception>
        public static void Initialize(GraphicsDevice device)
        {
            if (device == null)
                throw new ArgumentNullException("device");

            EmptyTexture = new Texture2D(device, 1, 1);
            EmptyTexture.SetData<Color>(new Color[] { Color.White }, 0, 1);
        }


        public static void DrawLine(SpriteBatch batch, Color color,
                Vector2 point1, Vector2 point2)
        {
            DrawLine(batch, color, point1, point2, 0);
        }

        /// <summary>
        /// Draw a line into a SpriteBatch.
        /// </summary>
        /// <param name="batch">SpriteBatch to draw line.</param>
        /// <param name="color">The line color.</param>
        /// <param name="point1">Start point.</param>
        /// <param name="point2">End point.</param>
        /// <param name="layer">Layer or Z position.</param>
        /// <exception cref="ArgumentNullException">When 
        /// <paramref name="batch"/> is null.</exception>
        public static void DrawLine(SpriteBatch batch, Color color,
            Vector2 point1, Vector2 point2, Single layer)
        {
            if (batch == null)
                throw new ArgumentNullException("batch");
            // Other arguments are structs.


            //Check if data has been set for texture
            //Do this only once otherwise
            if (!_initialized)
            {
                EmptyTexture.SetData(new[] { Color.White });
                _initialized = true;
            }


            Single angle = (Single)Math.Atan2(point2.Y - point1.Y,
                point2.X - point1.X);
            Single length = (point2 - point1).Length();

            batch.Draw(EmptyTexture, point1, null, color,
                angle, Vector2.Zero, new Vector2(length, 1),
                SpriteEffects.None, layer);
        }

        /// <summary>
        /// Gets or sets whether the <see cref="EmptyTexture"/> has 
        /// been initialized.
        /// </summary>
        private static Boolean _initialized = false;
    }
}

