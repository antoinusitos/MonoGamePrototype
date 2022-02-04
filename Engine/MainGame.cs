using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Gameplay.Levels;

namespace MonoGamePrototype.Engine
{
    public class MainGame : Game
    {
        public static MainGame instance { get; set; } = null;

        private GraphicsDeviceManager graphics { get; set; } = null;
        private SpriteBatch spriteBatch { get; set; } = null;

        private InputManager inputManager { get; set; } = null;

        private UIManager uiManager { get; set; } = null;

        private SceneManager sceneManager { get; set; } = null;

        private GameManager gameManager { get; set; } = null;

        private Level currentLevel { get; set; } = null;

        private bool started { get; set; } = false;

        public MainGame()
        {
            instance = this;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            inputManager = new InputManager();
            uiManager = new UIManager();
            sceneManager = new SceneManager();
            gameManager = new GameManager();

            currentLevel = new LevelMenu();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            graphics.PreferredBackBufferWidth = Data.Width;
            graphics.PreferredBackBufferHeight = Data.Height;
            graphics.IsFullScreen = Data.FullScreen;
            graphics.ApplyChanges();

            inputManager.Initialize();
            uiManager.Initialize();
            sceneManager.Initialize();
            gameManager.Initialize();

            currentLevel.Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            inputManager.LoadContent(Content);
            uiManager.LoadContent(Content);
            sceneManager.LoadContent(Content);
            gameManager.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if(!started)
            {
                gameManager.Start();

                inputManager.Start();

                sceneManager.Start();

                uiManager.Start();

                sceneManager.SetLevel(currentLevel);

                started = true;
                return;
            }

            gameManager.Update(gameTime);

            inputManager.Update(gameTime);

            sceneManager.Update(gameTime);

            uiManager.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            sceneManager.Draw(spriteBatch);

            uiManager.Draw(spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
