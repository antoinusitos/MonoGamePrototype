using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Gameplay.Levels;
using System;

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

        private CameraManager cameraManager { get; set; } = null;

        private LevelLoadingManager levelLoadingManager { get; set; } = null;

        private Level currentLevel { get; set; } = null;

        private bool started { get; set; } = false;

        private System.Diagnostics.Stopwatch startTime { get; set; } = null;

        public MainGame()
        {
            instance = this;

            startTime = new System.Diagnostics.Stopwatch();
            startTime.Start();

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            inputManager = new InputManager();
            uiManager = new UIManager();
            sceneManager = new SceneManager();
            gameManager = new GameManager();
            cameraManager = new CameraManager();
            levelLoadingManager = new LevelLoadingManager();

            currentLevel = new LevelMenu("Main Menu");
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
            cameraManager.Initialize();
            levelLoadingManager.Initialize();

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
            cameraManager.LoadContent(Content);

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

                cameraManager.Start();

                started = true;

                startTime.Stop();
                Console.WriteLine($"GAME start Time: {startTime.ElapsedMilliseconds} ms");
                return;
            }

            gameManager.Update(gameTime);

            inputManager.Update(gameTime);

            sceneManager.Update(gameTime);

            cameraManager.Update(gameTime);

            uiManager.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (CameraManager.instance.currentCamera != null)
            {
                spriteBatch.Begin(transformMatrix: CameraManager.instance.currentCamera.transform);
                sceneManager.Draw(spriteBatch);
                spriteBatch.End();
            }
            else
            {
                sceneManager.Draw(spriteBatch);
            }

            uiManager.Draw(spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
