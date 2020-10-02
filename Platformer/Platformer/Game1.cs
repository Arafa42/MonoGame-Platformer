using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Platformer.User_Interface;

namespace Platformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Input inp;
        const int SCREENWIDTH = 1024, SCREENHEIGHT = 768;
        const bool FULLSCREEN = false;
        PresentationParameters pp;
        static public int screenW, screenH;
        static public Vector2 screen_center;
        Rectangle screenRect, desktopRect;
        RenderTarget2D MainTarget;
        Texture2D far_background, mid_background, tiles_image;
        static public Vector2 background_pos;
        static public string LEVEL_NAME = @"Content\\lev1.txt";
        static public string BACKUP_NAME = @"Content\\backup.txt";
        enum GameState {edit, play, game_over, menu, load_level}
        GameState gameState = GameState.edit;



        public Game1()
        {
            int initial_screen_width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 10;
            int initial_screen_height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 10;
            _graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = initial_screen_width,
                PreferredBackBufferHeight = initial_screen_height,
                IsFullScreen = false,
                PreferredDepthStencilFormat = DepthFormat.Depth16
            };
            Window.IsBorderless = true;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            inp = new Input();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MainTarget = new RenderTarget2D(GraphicsDevice, SCREENWIDTH, SCREENHEIGHT);
            pp = GraphicsDevice.PresentationParameters;
            SurfaceFormat format = pp.BackBufferFormat;
            screenW = MainTarget.Width;
            screenH = MainTarget.Height;
            desktopRect = new Rectangle(0, 0, pp.BackBufferWidth, pp.BackBufferHeight);
            screenRect = new Rectangle(0, 0, screenW,screenH);
            screen_center = new Vector2(screenW / 2.0f, screenH / 2.0f) - new Vector2(32f, 32f); 
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            far_background = Content.Load<Texture2D>("Images/background_stars");
            mid_background = Content.Load<Texture2D>("Images/mid_background");
            tiles_image = Content.Load<Texture2D>("Images/tiles1");

        }

        protected override void Update(GameTime gameTime)
        {
            //EXIT
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here
            
            //EXIT
            inp.Update();
            if (inp.Keypress(Keys.Escape)) { Exit(); }

            //TEST INPUT PARALLAX
            //if (inp.Keydown(Keys.Left)) { background_pos.X++; }
            //if (inp.Keydown(Keys.Right)) { background_pos.X--; }
            //if (inp.Keydown(Keys.Up)) { background_pos.Y++; }
            //if (inp.Keydown(Keys.Down)) { background_pos.Y--; }




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            GraphicsDevice.SetRenderTarget(MainTarget);

            //GELAAGDE BACKGROUND
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap);
            _spriteBatch.Draw(far_background, screenRect, new Rectangle((int)(-background_pos.X * 0.5f), 0, far_background.Width, far_background.Height), Color.White);
            _spriteBatch.End();

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, SamplerState.LinearWrap);
            _spriteBatch.Draw(mid_background, screenRect, new Rectangle((int)(-background_pos.X), (int)-background_pos.Y, mid_background.Width, mid_background.Height),Color.White);
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Opaque, SamplerState.LinearWrap,DepthStencilState.None,RasterizerState.CullNone);
            _spriteBatch.Draw(MainTarget, desktopRect, Color.White);
            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
