using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoundAxis.WrenchMG.Transition
{

    /// <summary>
    /// Scene transition.
    /// </summary>
    public class SceneTransition : Scene
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="sourceScene">The source scene.</param>
        /// <param name="destinationScene">The target scene.</param>
        /// <exception cref="ArgumentNullException">When any argument is null.</exception>
        public SceneTransition(Scene sourceScene, Scene destinationScene)
        {
            if (sourceScene == null)
                throw new ArgumentNullException("sourceScene");
            if (destinationScene == null)
                throw new ArgumentNullException("destinationScene");

            SourceScene = sourceScene;
            this.destinationScene = destinationScene;

            GraphicsDevice graphicsDevice = SpriteBatch.GraphicsDevice;

            _sourceTarget = new RenderTarget2D(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
            _targetTarget = new RenderTarget2D(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
        }

        /// <summary>
        /// Gets the current target scene.
        /// </summary>
        public Scene destinationScene { get; protected set; }

        /// <summary>
        /// Gets the current source scene.
        /// </summary>
        public Scene SourceScene { get; protected set; }


        /// <summary>
        /// Executes an update.
        /// </summary>
        /// <param name="gameTime">The game time to use for this update.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public override void Update(GameTime gameTime)
        {
            Engine.PopScene();
            Engine.PushScene(destinationScene);
        }

        /// <summary>
        /// The source target.
        /// </summary>
        protected RenderTarget2D _sourceTarget;

        /// <summary>
        /// The destination target.
        /// </summary>
        protected RenderTarget2D _targetTarget;
    }
}
