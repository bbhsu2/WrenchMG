using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace WrenchMG
{
	public delegate void ActionDelegate(Node caller);

	public class CallbackAction : InstantAction
	{
		public ActionDelegate OnComplete = null;

		public CallbackAction (ActionDelegate onComplete)
		{
			OnComplete = onComplete;
		}

		public override void Complete ()
		{
			if (OnComplete != null)
				OnComplete (Target);
			base.Complete ();
		}
	}
}

