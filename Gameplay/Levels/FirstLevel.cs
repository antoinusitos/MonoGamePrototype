using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;
using MonoGamePrototype.Gameplay.Entities;
using MonoGamePrototype.Gameplay.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MonoGamePrototype.Gameplay.Levels
{
    public class FirstLevel : Level
    {
        private Player player { get; set; } = null;

        private PauseMenuUI pauseMenuUI { get; set; } = null;

        private List<Tile> tiles { get; set; } = null;

        public FirstLevel(string name) : base(name)
        {

        }

        public override void Initialize()
        {
            player = new Player();

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

            LoadLevel();
        }

        public override void Start()
        {
            base.Start();

            pauseMenuUI.Start();
            pauseMenuUI.SetActive(false);

            AddEntity(player);
            for (int i = 0; i < tiles.Count; i++)
            {
                AddEntity(tiles[i]);
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

        private void LoadLevel()
        {
            tiles = new List<Tile>();
            Tile[] loadedTiles = LevelLoadingManager.instance.LoadLevel("Level1.json");
            for (int i = 0; i < loadedTiles.Length; i++)
            {
                tiles.Add(loadedTiles[i]);
            }

            return;

            //DEBUG LOAD 
            string[] levelTiles = LevelLoadingManager.instance.LoadLevelText("Level1.txt");
            tiles = new List<Tile>();

            Random random = new Random();
            for (int i = 0; i < levelTiles.Length; i++)
            {
                string[] tempTiles = levelTiles[i].Split(',');
                for (int t = 0; t < tempTiles.Length; t++)
                {
                    string tileName = tempTiles[t];
                    if (tileName == "0")
                        continue;

                    if (tileName == "1")
                        tileName = "0" + random.Next(1, 7);

                    Tile tile = new Tile("Tiles/tile_" + tileName)
                    {
                        positionX = t * Data.TileSize,
                        positionY = i * Data.TileSize
                    };
                    tiles.Add(tile);
                }
            }

            levelTiles = LevelLoadingManager.instance.LoadLevelText("Level1_1.txt");

            for (int i = 0; i < levelTiles.Length; i++)
            {
                string[] tempTiles = levelTiles[i].Split(',');
                for (int t = 0; t < tempTiles.Length; t++)
                {
                    string tileName = tempTiles[t];
                    if (tileName == "0")
                        continue;

                    if (tileName == "1")
                        tileName = "0" + random.Next(1, 7);

                    Tile tile = new Tile("Tiles/tile_" + tileName)
                    {
                        positionX = t * Data.TileSize,
                        positionY = i * Data.TileSize,
                        zOrder = 1
                    };
                    tiles.Add(tile);
                }
            }

            string fileName = Data.LevelPath + "Level1.json";
            string jsonString = JsonSerializer.Serialize(tiles);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
