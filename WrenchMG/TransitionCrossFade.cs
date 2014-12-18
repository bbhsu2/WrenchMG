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
    public class TransitionCrossFade : SceneTransition
    {
        float progress = 0.0f;

        public TransitionCrossFade(Scene SourceScene, Scene TargetScene)
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

            int sliceHeight = g.GraphicsDevice.Viewport.Height / 8;
            float screenW = (float)g.GraphicsDevice.Viewport.Width;

            sb.Begin();

            sb.Draw(sourceTarget, Vector2.Zero, Color.White);

            for (int y = 0; y < 8; y++)
            {
                Texture2D tex = targetTarget;
                float x = 0.0f;

                if (y % 2 == 0)
                    x = -screenW + screenW * progress;
                else
                    x = screenW - screenW * progress;
                
                sb.Draw(tex, new Vector2(x, y * sliceHeight), new Rectangle(0, y * sliceHeight, tex.Width, sliceHeight), Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            }

            sb.End();
        }

        public override void Update(GameTime gameTime)
        {
            progress += 0.02f;

            if (progress >= 1.0f)
            {
                Engine.PopScene();
                Engine.PushScene(targetScene);
            }
        }
    }
}
