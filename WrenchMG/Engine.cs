#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace WrenchMG
{
	public delegate void OnLoadContent();
	public delegate void OnSuspend();
	public delegate void OnResume();

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Engine : Game
    {
		public OnSuspend onSuspend;
		public OnResume onResume;
		bool firstInit = true;

        static Engine instance = null;
        Stack<Scene> sceneStack = new Stack<Scene>();
        GraphicsDeviceManager graphics;

		public OnLoadContent onLoad = null;

		public static string DocumentDirectory = "";
		static bool firstFrame = true;

        protected Engine()
            : base()
        {
			graphics = new GraphicsDeviceManager (this);

			graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;

            Content.RootDirectory = "Content";
			instance = this;
        }

		protected Engine(GraphicsDeviceManager gdm)
			: base()
		{
			graphics = gdm;
			Content.RootDirectory = "Content";
			instance = this;
		}

        protected override void Initialize()
        {
            base.Initialize();

			LineBatch.Init (this.GraphicsDevice);
        }

        protected override void LoadContent()
        {

        }

        protected override void UnloadContent()
        {
            
        }

		public static Engine Instance
		{
			get {
				if (instance == null)
					instance = new Engine ();
				return instance;
			}
		}

        protected override void Update(GameTime gameTime)
        {
			if (onLoad != null && firstFrame) {
				firstFrame = false;
				onLoad ();
			}

            if (sceneStack.Count > 0)
                sceneStack.Peek().Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            if (sceneStack.Count > 0)
                sceneStack.Peek().Draw();

            base.Draw(gameTime);
        }

        public static Scene PushScene(Scene s)
        {
            if (s != null)
                Instance.sceneStack.Push(s);
            return s;
        }

        public static void PopScene()
        {
            Instance.sceneStack.Pop();
        }

        public static Scene ActiveScene
        {
			get { return Instance.sceneStack.Peek (); }
        }

        public static ContentManager ContentMgr
        {
			get { return Instance.Content; }
        }

        public static GraphicsDeviceManager GFXDeviceMgr
        {
			get { return Instance.graphics; }
        }

        public static GraphicsDevice GFXDevice
        {
			get { return Instance.GraphicsDevice; }
        }

		protected override void OnDeactivated (object sender, EventArgs args)
		{
			if (onSuspend != null)
				onSuspend ();
			base.OnDeactivated (sender, args);
		}

		protected override void OnActivated (object sender, EventArgs args)
		{
			if (onResume != null && !firstInit)
				onResume ();

			firstInit = false;

			base.OnActivated (sender, args);
		}

		public static Viewport Viewport
		{
			get { return GFXDevice.Viewport; }
		}

		public static Texture2D CreateTexture(int width, int height, Color color)
		{
			Texture2D tex = new Texture2D (Engine.GFXDevice, width, height);

			Color[] c = new Color[width * height];

			for (int a = 0; a < width * height; a++)
				c [a] = color;

			tex.SetData<Color> (c, 0, width * height);

			return tex;
		}

		public static Texture2D CreateTextureWithBorder(int width, int height, Color backgroundColor, int borderWidth, Color borderColor)
		{
			Texture2D tex = new Texture2D (Engine.GFXDevice, width, height);

			Color[] c = new Color[width * height];

			for(int y = 0; y < height; y++) {
				for(int x = 0; x < width; x++) {
					c [y * width + x] = backgroundColor;

					if (y < borderWidth || y >= height - borderWidth || x < borderWidth || x >= width - borderWidth)
						c [y * width + x] = borderColor;
				}
			}

			tex.SetData<Color> (c, 0, width * height);

			return tex;
		}
    }
}
