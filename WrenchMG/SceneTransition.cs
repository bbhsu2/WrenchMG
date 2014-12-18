using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WrenchMG
{
    public class SceneTransition : Scene
    {
		public Scene targetScene;
        public Scene sourceScene;

        protected RenderTarget2D sourceTarget;
        protected RenderTarget2D targetTarget;

        protected SpriteBatch sb;
        protected Engine g;

        public SceneTransition(Scene SourceScene, Scene TargetScene)
        {
            sourceScene = SourceScene;
            targetScene = TargetScene;

			g = Engine.Instance;

            sourceTarget = new RenderTarget2D(g.GraphicsDevice, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);
            targetTarget = new RenderTarget2D(g.GraphicsDevice, g.GraphicsDevice.Viewport.Width, g.GraphicsDevice.Viewport.Height);

            sb = new SpriteBatch(g.GraphicsDevice);
        }

        public override void Draw()
        {
        }

        public override void Update(GameTime gameTime)
        {
            Engine.PopScene();
            Engine.PushScene(targetScene);
        }
    }
}
