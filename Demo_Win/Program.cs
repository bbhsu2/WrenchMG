#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using WrenchMG;
#endregion

namespace Demo_Win
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Fun begins..
            Engine.Instance.onLoad = delegate()
            {
                Engine.DocumentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Engine.Instance.IsMouseVisible = true;


                //Add your custom scene here
                Engine.PushScene(new Scene());
            };

            Engine.Instance.Run();
        }
    }
#endif
}
