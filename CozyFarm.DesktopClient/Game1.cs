using CozyFarm.DesktopClient.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace CozyFarm.DesktopClient
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameStateManager _gsm;
        private InputManager _inputManager;
        public OrthographicCamera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = System.TimeSpan.FromSeconds(1d / 60d);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = Global.SCREEN_WIDTH;
            _graphics.PreferredBackBufferHeight = Global.SCREEN_HEIGHT;
            _graphics.ApplyChanges();

            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, Global.SCREEN_WIDTH, Global.SCREEN_HEIGHT);
            camera = new OrthographicCamera(viewportAdapter);
            //camera.Zoom = 2;
            _inputManager = new InputManager(this);
            _gsm = new GameStateManager(this, _inputManager);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            CozyConsole.LoadContent(this.Content);
            _gsm.LoadContent(this.Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            CozyConsole.Update(gameTime);
            _gsm.UpdateState(gameTime);
            _inputManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _gsm.DrawState(_spriteBatch);
            _spriteBatch.Begin();
            CozyConsole.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
