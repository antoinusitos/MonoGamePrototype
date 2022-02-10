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

            for (int i = 0; i < levelSizeX * levelSizeY; i++)
            {
                generatedTiles.Add(new Tile("Tiles/Grid")
                {
                    zOrder = currentLayer
                }) ;
            }
        }

        public override void Start()
        {
            base.Start();

            levelEditorMenuUI.Start();

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

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            contentManager = content;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            levelEditorMenuUI.Update(gameTime);

            if (!levelEditorMenuUI.GetIsOnPanel() && InputManager.instance.GetMouseButtonPressed(0))
            {
                Vector2 pos = InputManager.instance.GetMousePosition();

                int x = (int)(pos.X / Data.TileSize);
                int y = (int)(pos.Y / Data.TileSize);

                if (currentLayer == 0)
                {
                    int tileCurrentIndex = (y * levelSizeX + x);
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

            if(InputManager.instance.GetKeyboardDown(Keys.LeftControl) && InputManager.instance.GetKeyboardPressed(Keys.S))
            {
                //Save the map
                LevelLoadingManager.instance.SaveLevel("testMap", generatedTiles);
                levelEditorMenuUI.UpdateMapName("testMap");
            }

            if(InputManager.instance.GetKeyboardPressed(Keys.P))
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
    }
}
