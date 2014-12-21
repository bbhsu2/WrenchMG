using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoundAxis.WrenchMG.Action;
using SoundAxis.WrenchMG.Action.Timed;

namespace SoundAxis.WrenchMG.Tests
{
    [TestClass]
    public class LineBatchTests
    {
        [TestMethod]
        public void GetEmptyTextureUninitialized_ShouldBeNull()
        {
            Texture2D expected = null;
            Texture2D actual;

            actual = LineBatch.EmptyTexture;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetEmptyTextureAfterInitialize_ShouldNotBeNull()
        {
            Texture2D actual;

            LineBatch.Initialize(_defaultGraphicsDevice);
            actual = LineBatch.EmptyTexture;

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void InitializeWithValidArgument_ShouldNotError()
        {
            LineBatch.Initialize(_defaultGraphicsDevice);

            // Should not fail.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InitializeWithNullArgument_ShouldThrowException()
        {
            LineBatch.Initialize(null);

            Assert.Fail("Should have thrown ArgumentNullException.");
        }

        [TestMethod]
        public void DrawLineWithValidOverloadArguments_ShouldNotError()
        {
            SpriteBatch batch = new SpriteBatch(_defaultGraphicsDevice);
            batch.Begin();
            Color color = Color.Red;
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(10, 10);
            LineBatch.DrawLine(batch, color, point1, point2);

            // Should not fail.
        }

        [TestMethod]
        public void DrawLineWithValidArguments_ShouldNotError()
        {
            SpriteBatch batch = new SpriteBatch(_defaultGraphicsDevice);
            batch.Begin();
            Color color = Color.Red;
            Vector2 point1 = new Vector2(0,0);
            Vector2 point2 = new Vector2(10,10); 
            Single layer = 0;
            LineBatch.DrawLine(batch, color, point1, point2, layer);

            // Should not fail.
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DrawLineWithNullBatch_ShouldThrowException()
        {
            SpriteBatch batch = null;
            Color color = Color.Red;
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(10, 10);
            Single layer = 0;
            LineBatch.DrawLine(batch, color, point1, point2, layer);

            Assert.Fail("Should have thrown ArgumentNullException.");
        }


        private GraphicsDevice _defaultGraphicsDevice = new GraphicsDevice(GraphicsAdapter.Adapters[0],
            GraphicsProfile.HiDef, new PresentationParameters());
    }
}
