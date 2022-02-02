using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Gameplay.Levels;

namespace MonoGamePrototype.Engine
{
    public class MainGame : Game
    {
        private GraphicsDeviceManager graphics { get; set; } = null;
        private SpriteBatch spriteBatch { get; set; } = null;

        private InputManager inputManager { get; set; } = null;

        private Level currentLevel { get; set; } = null;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = Data.Width;
            graphics.PreferredBackBufferHeight = Data.Height;
            graphics.ApplyChanges();

            inputManager = new InputManager();
            currentLevel = new LevelMenu();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            inputManager.Initialize();

            currentLevel.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            currentLevel.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (InputManager.instance.GetGamepadButtonDown(GamePad.GetState(PlayerIndex.One).Buttons.Back) || InputManager.instance.GetKeyboardDown(Keys.Escape))
                Exit();

            InputManager.instance.Update();

            currentLevel.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentLevel.Draw(spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
