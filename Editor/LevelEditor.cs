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

        private int levelSizeX { get; set; } = 20;
        private int levelSizeY { get; set; } = 20;

        private ContentManager contentManager { get; set; } = null;

        public LevelEditor(string name = "Level Editor") : base(name)
        {
            generatedTiles = new List<Tile>();
        }

        public override void Initialize()
        {
            base.Initialize();

            levelEditorMenuUI = new LevelEditorMenuUI();
            levelEditorMenuUI.Initialize();

            for (int i = 0; i < levelSizeX * levelSizeY; i++)
            {
                generatedTiles.Add(new Tile("Tiles/Grid"));

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

                int tileCurrentIndex = (y * levelSizeX + x);
                generatedTiles[tileCurrentIndex].UpdateTexture(levelEditorMenuUI.GetSelectedTile(), contentManager);
            }

            if(InputManager.instance.GetKeyboardDown(Keys.LeftControl) && InputManager.instance.GetKeyboardPressed(Keys.S))
            {
                //Save the map
                LevelLoadingManager.instance.SaveLevel("testMap", generatedTiles);
                levelEditorMenuUI.UpdateMapName("testMap");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
