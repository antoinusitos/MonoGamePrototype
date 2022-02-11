using MonoGamePrototype.Engine;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoGamePrototype.Editor
{
    public class LevelEditor : Level
    {
        private LevelEditorMenuUI levelEditorMenuUI { get; set; } = null;

        private List<Tile> generatedTiles { get; set; } = null;

        private List<Tile> AddedTiles { get; set; } = null;

        private int levelSizeX { get; set; } = 20;
        private int levelSizeY { get; set; } = 20;

        private ContentManager contentManager { get; set; } = null;

        private int currentLayer = 0;

        private LevelEditorPauseMenu pauseMenuUI { get; set; } = null;

        private Vector2 mousePosClick { get; set; } = Vector2.Zero;

        private Vector2 mouseDelta { get; set; } = Vector2.Zero;

        private LevelEditorCamera levelEditorCamera { get; set; } = null;

        public LevelEditor(string name = "Level Editor") : base(name)
        {
            generatedTiles = new List<Tile>();
            AddedTiles = new List<Tile>();
        }

        public override void Initialize()
        {
            base.Initialize();

            levelEditorMenuUI = new LevelEditorMenuUI();
            levelEditorMenuUI.Initialize();

            pauseMenuUI = new LevelEditorPauseMenu();
            pauseMenuUI.Initialize();

            for (int i = 0; i < levelSizeX * levelSizeY; i++)
            {
                generatedTiles.Add(new Tile("Tiles/Grid")
                {
                    zOrder = currentLayer
                }) ;
            }

            levelEditorCamera = new LevelEditorCamera();
            CameraManager.instance.SetCamera(levelEditorCamera);
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            contentManager = content;

            pauseMenuUI.LoadContent(content);
        }

        public override void Start()
        {
            base.Start();

            levelEditorMenuUI.Start();

            pauseMenuUI.Start();
            pauseMenuUI.SetActive(false);

            int posX = 0;
            int posY = 0;
            for (int i = 0; i < generatedTiles.Count; i++)
            {
                generatedTiles[i].positionX = (Data.TileSize / 2) + posX * Data.TileSize;
                generatedTiles[i].positionY = (Data.TileSize / 2) + posY * Data.TileSize;
                posX++;
                if (posX >= levelSizeX)
                {
                    posX = 0;
                    posY++;
                }
                AddEntity(generatedTiles[i]);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            levelEditorMenuUI.Update(gameTime);

            HandlePauseMenu(gameTime);

            if (!levelEditorMenuUI.GetIsOnPanel())
            {
                if (InputManager.instance.GetMouseButtonPressed(0))
                {
                    HandleTilePlacement();
                }
                else if (InputManager.instance.GetMouseButtonPressed(1))
                {
                    mousePosClick = InputManager.instance.GetMousePosition();
                }
                else if (InputManager.instance.GetMouseButtonDown(1))
                {
                    mouseDelta = mousePosClick - InputManager.instance.GetMousePosition();
                    levelEditorCamera.Move(mouseDelta);
                }
                else if (InputManager.instance.GetMouseButtonReleased(1))
                {
                    levelEditorCamera.positionX += mouseDelta.X;
                    levelEditorCamera.positionY += mouseDelta.Y;
                }
            }

            HandleSave();

            HandleLayer();

            Vector2 mousePos = InputManager.instance.GetMousePosition();
            mousePos = Data.ScreenToWorldSpace(mousePos);
            Console.WriteLine("diffX:" + (levelEditorCamera.positionX - mousePos.X));
            Console.WriteLine("diffY:" + (levelEditorCamera.positionX - mousePos.Y));
        }

        private void HandlePauseMenu(GameTime gameTime)
        {
            pauseMenuUI.Update(gameTime);

            if (InputManager.instance.GetKeyboardPressed(Keys.Escape))
            {
                if (GameManager.instance.currentGameState != GameManager.GameState.PAUSE)
                {
                    GameManager.instance.SetGameState(GameManager.GameState.PAUSE);
                    pauseMenuUI.SetActive(true);
                }
                else
                {
                    GameManager.instance.SetGameState(GameManager.GameState.LEVELEDITOR);
                    pauseMenuUI.SetActive(false);
                }
            }
        }

        private void HandleLayer()
        {
            if (InputManager.instance.GetKeyboardPressed(Keys.P))
            {
                currentLayer++;
                levelEditorMenuUI.UpdateLayerText(currentLayer);
                ShowCurrentLayerTiles();
            }
            else if (InputManager.instance.GetKeyboardPressed(Keys.O))
            {
                currentLayer--;
                levelEditorMenuUI.UpdateLayerText(currentLayer);
                ShowCurrentLayerTiles();
            }
        }

        private void HandleSave()
        {
            if (InputManager.instance.GetKeyboardDown(Keys.LeftControl) && InputManager.instance.GetKeyboardPressed(Keys.S))
            {
                SaveLevel();
            }
        }

        private void HandleTilePlacement()
        {
            Vector2 pos = InputManager.instance.GetMousePosition();


            int x = (int)(levelEditorCamera.positionX - (Data.Width / 2) + pos.X);
            int y = (int)(levelEditorCamera.positionX - (Data.Width / 2) + pos.Y);
            //int x = (int)(pos.X - (levelEditorCamera.positionX + (Data.Width / 2)));
            //int y = (int)(pos.Y - (levelEditorCamera.positionY + (Data.Height / 2)));

            x /= Data.TileSize;
            y /= Data.TileSize;

            if (currentLayer == 0)
            {
                int tileCurrentIndex = (y * levelSizeX + x);
                if(tileCurrentIndex >= 0 && tileCurrentIndex < generatedTiles.Count)
                    generatedTiles[tileCurrentIndex].UpdateTexture(levelEditorMenuUI.GetSelectedTile(), contentManager);
            }
            else
            {
                Tile tile = new Tile(levelEditorMenuUI.GetSelectedTile())
                {
                    zOrder = currentLayer,
                    positionX = (Data.TileSize / 2) + x * Data.TileSize,
                    positionY = (Data.TileSize / 2) + y * Data.TileSize
                };
                AddedTiles.Add(tile);
                AddEntity(tile);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        private void ShowCurrentLayerTiles()
        {
            for(int i = 0; i < entities.Count; i++)
            {
                if(entities[i].zOrder == currentLayer)
                {
                    entities[i].color = Color.White;
                }
                else
                {
                    entities[i].color = new Color(100, 100, 100, 0.5f);
                }
            }
        }

        public void SaveLevel()
        {
            //Save the map
            LevelLoadingManager.instance.SaveLevel("testMap", generatedTiles);
            levelEditorMenuUI.UpdateMapName("testMap");
        }
    }
}
