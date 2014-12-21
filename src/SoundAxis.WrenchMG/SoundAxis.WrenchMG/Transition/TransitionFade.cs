using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoundAxis.WrenchMG.Transition
{
    public class TransitionFade : SceneTransition
    {
        float scale = 1.0f;

        public TransitionFade(Scene SourceScene, Scene destinationScene)
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

            SpriteBatch.Begin();

			SpriteBatch.Draw(_sourceTarget, new Vector2(CurrentGraphicsDevice.Viewport.Width/2, CurrentGraphicsDevice.Viewport.Height/2), null, new Color(1.0f, 1.0f, 1.0f, scale), 0.0f, new Vector2(CurrentGraphicsDevice.Viewport.Width/2, CurrentGraphicsDevice.Viewport.Height/2), 1.0f, SpriteEffects.None, 0);
			SpriteBatch.Draw(_targetTarget, new Vector2(CurrentGraphicsDevice.Viewport.Width/2, CurrentGraphicsDevice.Viewport.Height/2), null, new Color(1.0f, 1.0f, 1.0f, 1.0f - scale), 0.0f, new Vector2(CurrentGraphicsDevice.Viewport.Width/2, CurrentGraphicsDevice.Viewport.Height/2), 1.0f, SpriteEffects.None, 0);

            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            scale -= 0.05f;

            if (scale <= 0.0f)
            {
                Engine.PopScene();
                Engine.PushScene(destinationScene);
            }
        }
    }
}
