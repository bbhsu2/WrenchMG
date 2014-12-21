using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SoundAxis.WrenchMG.Transition
{
    /// <summary>
    /// Base class for a scene.
    /// </summary>
    public class Scene
    {
        /// <summary>
        /// Creates a new instance of this type, using the default sprite batch.
        /// </summary>
        public Scene()
            : this(new SpriteBatch(Engine.GFXDevice))
        {
        }

        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to use for this instance.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Scene(SpriteBatch spriteBatch)
        {
            if (spriteBatch == null)
                throw new ArgumentNullException("spriteBatch");

            SpriteBatch = spriteBatch;
            CurrentGraphicsDevice = spriteBatch.GraphicsDevice;
        }

        /// <summary>
        /// Gets the sprite batch being used by this instance.
        /// </summary>
        public SpriteBatch SpriteBatch { get; protected set; }

        /// <summary>
        /// Gets the current graphics device.
        /// </summary>
        public GraphicsDevice CurrentGraphicsDevice { get; protected set; }

        /// <summary>
        /// Executes a draw.
        /// </summary>
        public virtual void Draw()
        {
            SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);

            foreach (Node n in _nodes)
                n.Draw(SpriteBatch);

            SpriteBatch.End();
        }

        /// <summary>
        /// Executes an update.
        /// </summary>
        /// <param name="gameTime">The game time to use for this update.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void Update(GameTime gameTime)
        {
            if (gameTime == null)
                throw new ArgumentNullException("gameTime");

            foreach (Node n in _nodesToRemove)
                _nodes.Remove(n);
            _nodesToRemove.Clear();

            foreach (Node n in _nodesToAdd)
                _nodes.Add(n);
            _nodesToAdd.Clear();

            foreach (Node n in _nodes)
                n.Update(gameTime);
        }

        /// <summary>
        /// Adds a node to the scene.
        /// </summary>
        /// <param name="node">Thee node to add.</param>
        /// <returns></returns>
        public virtual void AddNode(Node node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            node.scene = this;
            _nodesToAdd.Add(node);
        }

        /// <summary>
        /// Removes a node from the scene.
        /// </summary>
        /// <param name="node"></param>
        public virtual void RemoveNode(Node node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            if (_nodes.Contains(node))
            {
                _nodesToRemove.Add(node);
            }
            else
            {
                throw new InvalidOperationException("Node does not exist in the collection.");
            }
        }

        /// <summary>
        /// Gets a collection of all of the nodes.
        /// </summary>
        public IEnumerable<Node> Nodes()
        {
            return _nodes;
        }

        protected List<Node> _nodes = new List<Node>();
        protected List<Node> _nodesToAdd = new List<Node>();
        protected List<Node> _nodesToRemove = new List<Node>();

    }
}
