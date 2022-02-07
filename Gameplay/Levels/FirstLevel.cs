using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;
using MonoGamePrototype.Gameplay.Entities;
using MonoGamePrototype.Gameplay.Menu;
using System;

namespace MonoGamePrototype.Gameplay.Levels
{
    public class FirstLevel : Level
    {
        private Player player { get; set; } = null;

        private PauseMenuUI pauseMenuUI { get; set; } = null;

        private Tile tile { get; set; } = null;

        //DEBUG
        private Tile[] testTiles { get; set; } = new Tile[10000];
        //DEBUG


        public FirstLevel(string name) : base(name)
        {

        }

        public override void Initialize()
        {
            player = new Player();

            tile = new Tile("Tiles/tile_01");

            for(int i = 0; i < testTiles.Length; i++)
            {
                testTiles[i] = new Tile("Tiles/tile_01");
            }

            pauseMenuUI = new PauseMenuUI();
            pauseMenuUI.Initialize();

            CameraManager.instance.SetCamera(new PlayerCamera());
            ((PlayerCamera)CameraManager.instance.currentCamera).SetPlayer(player);

            base.Initialize();
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
            pauseMenuUI.LoadContent(content);
        }

        public override void Start()
        {
            base.Start();

            pauseMenuUI.Start();
            pauseMenuUI.SetActive(false);

            AddEntity(player);
            AddEntity(tile);
            for (int i = 0; i < testTiles.Length; i++)
            {
                AddEntity(testTiles[i]);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            pauseMenuUI.Update(gameTime);

            if (InputManager.instance.GetKeyboardPressed(Keys.Escape))
            {
                if(GameManager.instance.currentGameState != GameManager.GameState.PAUSE)
                {
                    GameManager.instance.SetGameState(GameManager.GameState.PAUSE);
                    pauseMenuUI.SetActive(true);
                }
                else
                {
                    GameManager.instance.SetGameState(GameManager.GameState.GAME);
                    pauseMenuUI.SetActive(false);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
