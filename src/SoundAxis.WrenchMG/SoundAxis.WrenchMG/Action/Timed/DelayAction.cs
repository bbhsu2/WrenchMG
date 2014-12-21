using System;

namespace SoundAxis.WrenchMG.Action.Timed
{
	public class DelayAction : TimedAction
	{
		public DelayAction (TimeSpan duration, ActionManager actionManager, SequenceAction sequence)
            : base(duration, actionManager, sequence)
		{
		}
	}
}

