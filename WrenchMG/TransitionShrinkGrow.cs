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
    public class TransitionShrinkGrow : SceneTransition
    {
        float scale = 1.0f;

        public TransitionShrinkGrow(Scene SourceScene, Scene TargetScene)
            : base(SourceScene, TargetScene)
        {
        }

        public override void Draw()
        {
            g.GraphicsDevice.SetRenderTarget(sourceTarget);
            g.GraphicsDevice.Clear(Color.Black);
            sourceScene.Draw();

            g.GraphicsDevice.SetRenderTarget(targetTarget);
            g.GraphicsDevice.Clear(Color.Black);
            targetScene.Draw();

            g.GraphicsDevice.SetRenderTarget(null);
            g.GraphicsDevice.Clear(Color.Black);

            sb.Begin();

			sb.Draw(sourceTarget, new Vector2(g.GraphicsDevice.Viewport.Width/2, g.GraphicsDevice.Viewport.Height/2), null, Color.White, 0.0f, new Vector2(g.GraphicsDevice.Viewport.Width/2, g.GraphicsDevice.Viewport.Height/2), scale, SpriteEffects.None, 0);
			sb.Draw(targetTarget, new Vector2(g.GraphicsDevice.Viewport.Width/2, g.GraphicsDevice.Viewport.Height/2), null, Color.White, 0.0f, new Vector2(g.GraphicsDevice.Viewport.Width/2, g.GraphicsDevice.Viewport.Height/2), 1.0f - scale, SpriteEffects.None, 0);

            sb.End();
        }

        public override void Update(GameTime gameTime)
        {
            scale -= 0.05f;

            if (scale <= 0.0f)
            {
                Engine.PopScene();
                Engine.PushScene(targetScene);
            }
        }
    }
}
