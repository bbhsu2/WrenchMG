using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

using WrenchMG;

namespace Demo_iOS
{
	[Register ("AppDelegate")]
	class Program : UIApplicationDelegate 
	{
		public override void FinishedLaunching (UIApplication app)
		{
			// Fun begins..
			Engine.Instance.onLoad = delegate() {
				Engine.DocumentDirectory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments);
				Engine.Instance.IsMouseVisible = true;


				//Add your custom scene here
				Engine.PushScene (new Scene ());
			};

			Engine.Instance.Run ();
		}

		static void Main (string [] args)
		{
			UIApplication.Main (args,null,"AppDelegate");
		}
	}
}
