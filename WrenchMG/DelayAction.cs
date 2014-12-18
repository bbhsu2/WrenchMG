using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
	public class DelayAction : TimedAction
	{
		public DelayAction (float seconds)
			: base(seconds)
		{
		}
	}
}

