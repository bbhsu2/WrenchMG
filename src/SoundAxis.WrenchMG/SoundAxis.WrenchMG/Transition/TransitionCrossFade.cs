using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoundAxis.WrenchMG.Transition
{
    public class TransitionCrossFade : SceneTransition
    {
        float progress = 0.0f;

        public TransitionCrossFade(Scene SourceScene, Scene destinationScene)
            : base(SourceScene, destinationScene)
        {
        }

        public override void Draw()
        {
            CurrentGraphicsDevice.SetRenderTarget(_sourceTarget);
            CurrentGraphicsDevice.Clear(Color.Black);
            SourceScene.Draw();

            CurrentGraphicsDevice.SetRenderTarget(_targetTarget);
            CurrentGraphicsDevice.Clear(Color.Black);
            destinationScene.Draw();

            CurrentGraphicsDevice.SetRenderTarget(null);
            CurrentGraphicsDevice.Clear(Color.Black);

            int sliceHeight = CurrentGraphicsDevice.Viewport.Height / 8;
            float screenW = (float)CurrentGraphicsDevice.Viewport.Width;

            SpriteBatch.Begin();

            SpriteBatch.Draw(_sourceTarget, Vector2.Zero, Color.White);

            for (int y = 0; y < 8; y++)
            {
                Texture2D tex = _targetTarget;
                float x = 0.0f;

                if (y % 2 == 0)
                    x = -screenW + screenW * progress;
                else
                    x = screenW - screenW * progress;
                
                SpriteBatch.Draw(tex, new Vector2(x, y * sliceHeight), new Rectangle(0, y * sliceHeight, tex.Width, sliceHeight), Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
            }

            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            progress += 0.02f;

            if (progress >= 1.0f)
            {
                Engine.PopScene();
                Engine.PushScene(destinationScene);
            }
        }
    }
}
