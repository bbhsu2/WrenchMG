using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoundAxis.WrenchMG.Transition;

namespace SoundAxis.WrenchMG.Tests.Transition
{
    [TestClass]
    public class SceneTests
    {
        [TestMethod]
        public void ConstructorWithNoArguments_ReturnsInstance()
        {
            Scene instance = new Scene();
            // TODO: I don't think this test can run because it needs a game?

            Assert.IsNotNull(instance);
        }
        
        [TestMethod]
        public void ConstructorWithValidArgument_ReturnsInstance()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            Assert.IsNotNull(instance);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullArgument_ThrowsException()
        {
            Scene instance = new Scene(null);

            Assert.Fail("Should have thrown an ArgumentNullException.");

        }


        [TestMethod]
        public void DrawWithNoArguments_ShouldNotError()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            instance.Draw();
        }
        
        [TestMethod]
        public void DrawWithNodesLoaded_ShouldNotError()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            Node node1 = new Node();
            Node node2 = new Node();

            instance.AddNode(node1);
            instance.AddNode(node2);
            instance.Update(new GameTime()); // Commit the adds.

            instance.Draw();
        }


        [TestMethod]
        public void UpdateWithNoArguments_ShouldNotError()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            instance.Update(new GameTime());
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateWithNullArguments_ThrowException()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            instance.Update(null);

            Assert.Fail("Should have thrown an ArgumentNullException.");
        }
        
        [TestMethod]
        public void UpdateWithValidArguments_ShouldBeInCollection()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            Node expected = new Node() { Position = new Vector2(10, 20) };
            Node actual = null;

            instance.AddNode(expected);
            instance.Update(new GameTime()); // Commit the add.

            actual = instance.Nodes().First();

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddWithNullArguments_ThrowsException()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            instance.AddNode(null);

            Assert.Fail("Should have thrown an ArgumentNullException.");
        }
        
        [TestMethod]
        public void AddWithValidArguments_ShouldBeInCollection()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            Node expected = new Node() { Position = new Vector2(10, 20) };
            Node actual = null;

            instance.AddNode(expected);
            instance.Update(new GameTime()); // Commit the add.

            actual = instance.Nodes().First();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveWithValidArguments_ShouldBeGoneFromCollection()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            Node node = new Node() { Position = new Vector2(10, 20) };
            Int32 expected = 0;
            Int32 actual = -1;

            instance.AddNode(node);
            instance.Update(new GameTime()); // Commit the add.
            instance.RemoveNode(node);
            instance.Update(new GameTime()); // Commit the remove.

            actual = instance.Nodes().Count();

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveWithNullArguments_ThrowsException()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            instance.RemoveNode(null);

            Assert.Fail("Should have thrown an ArgumentNullException.");
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveWithInvalidArguments_ThrowsException()
        {
            SpriteBatch spriteBatch = new SpriteBatch(_defaultGraphicsDevice);
            Scene instance = new Scene(spriteBatch);

            Node nodeThatIsntThere = new Node();
            instance.RemoveNode(nodeThatIsntThere);

            Assert.Fail("Should have thrown an InvalidOperationException.");
        }


        private GraphicsDevice _defaultGraphicsDevice = new GraphicsDevice(GraphicsAdapter.Adapters[0],
            GraphicsProfile.HiDef, new PresentationParameters());
    }
}
