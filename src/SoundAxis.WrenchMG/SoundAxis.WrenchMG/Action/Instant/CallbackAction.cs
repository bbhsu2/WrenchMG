using System;
using SoundAxis.WrenchMG.Action.Timed;

namespace SoundAxis.WrenchMG.Action.Instant
{
    /// <summary>
    /// InstantAction class which executes code upon a callback.
    /// </summary>
    public class CallbackAction : InstantAction
    {
        /// <summary>
        /// Creates a new instance of this type.
        /// </summary>
        /// <param name="onComplete">The code to execute when this action is complete.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="onComplete"/> is null.</exception>
        public CallbackAction(Action<Node> onComplete, ActionManager actionManager, SequenceAction sequence)
            : base(actionManager, sequence)
        {
            if (onComplete == null)
                throw new ArgumentNullException("onComplete");

            OnComplete = onComplete;
        }

        /// <summary>
        /// Gets the current delegate which will be executed when this action is complete.
        /// </summary>
        public Action<Node> OnComplete { get; protected set; }


        public override void Complete()
        {
            if (OnComplete != null)
                OnComplete(Target);
            base.Complete();
        }
    }
}

