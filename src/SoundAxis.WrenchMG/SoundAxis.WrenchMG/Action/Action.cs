using System;
using Microsoft.Xna.Framework;
using SoundAxis.WrenchMG.Action.Timed;

namespace SoundAxis.WrenchMG.Action
{
    /// <summary>
    /// Abstract base class for all actions.
    /// </summary>
    public abstract class Action
    {
        /// <summary>
        /// In a concrete class, creates a new instance of this type.
        /// </summary>
        /// <param name="actionManager">The <see cref="ActionManager"/>, or owner 
        /// of this action.</param>
        /// <param name="sequence">The <see cref="SequenceAction"/> to which this 
        /// action belongs.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="actionManager"/> 
        /// or <paramref name="sequence"/> are null.</exception>
protected Action(ActionManager actionManager, SequenceAction sequence)
{
    if (actionManager == null)
        throw new ArgumentNullException("actionManager");
    if (sequence == null)
        throw new ArgumentNullException("sequence");

    ActionManager = actionManager;
    Sequence = sequence;
}

        /// <summary>
        /// Gets the current action manager, or owner of this action.
        /// </summary>
        public ActionManager ActionManager { get;  set; }

        /// <summary>
        /// Gets the current sequence to which this action belongs.
        /// </summary>
        public SequenceAction Sequence { get;  set; }

        /// <summary>
        /// Begins the action.
        /// </summary>
        /// <param name="gameTime">The <see cref="GameTime"/> to be used for 
        /// this action.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="gameTime"/> 
        /// is null.</exception>
        public virtual void Begin(GameTime gameTime)
        {
            if (gameTime == null)
                throw new ArgumentNullException("gameTime");
        }

        /// <summary>
        /// Updates the action.
        /// </summary>
        /// <param name="gameTime">The <see cref="GameTime"/> to be used for 
        /// this action.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="gameTime"/> 
        /// is null.</exception>
        public virtual void Update(GameTime gameTime)
        {
            if (gameTime == null)
                throw new ArgumentNullException("gameTime");
        }

        public virtual void Complete()
        {
            if (ActionManager != null) 
                ActionManager.RemoveAction(this);

            if (Sequence != null) 
                Sequence.RemoveAction(this);
        }

        /// <summary>
        /// Gets or sets the target node.
        /// </summary>
        public virtual Node Target { get; set; }
    }
}