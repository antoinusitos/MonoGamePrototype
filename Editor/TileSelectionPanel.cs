using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;
using System.Collections.Generic;

namespace MonoGamePrototype.Editor
{
    public class TileSelectionPanel : UIPanel
    {
        private int tileShownIndex { get; set; } = 0;

        private int tileCurrentIndex { get; set; } = -1;

        private int tileNumberColumn { get; set; } = 4;
        private int tileNumberRow { get; set; } = 6;

        private int page { get; set; } = 0; //min = 1
        private int pageMax { get; set; } = 0;

        private List<Tile> tiles { get; set; } = null;

        private ContentManager contentManager { get; set; } = null;

        public TileSelectionPanel() : base()
        {
            size = new Vector2(Data.TileSize * tileNumberColumn, Data.TileSize * tileNumberRow);

            tiles = new List<Tile>();
        }

        public override void Initialize()
        {
            base.Initialize();

            for (int i = 1; i < 539; i++)
            {
                string name = (i < 10 ? "0" : "") + i;
                tiles.Add(new Tile("Tiles/tile_" + name));
            }
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            contentManager = content;
        }

        public override void Start()
        {
            base.Start();

            int posX = 0;
            int posY = 0;
            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].Initialize();
                tiles[i].LoadContent(contentManager);
                tiles[i].scaleX = 0.9f;
                tiles[i].scaleY = 0.9f;
                tiles[i].positionX = positionX + (Data.TileSize / 2) + posX * Data.TileSize;
                tiles[i].positionY = positionY + (Data.TileSize / 2) + posY * Data.TileSize;
                tiles[i].zOrder = 1;
                tiles[i].isActive = false;
                posX++;
                if(posX >= tileNumberColumn)
                {
                    posX = 0;
                    posY++;
                    if(posY >= tileNumberRow)
                    {
                        posY = 0;
                        pageMax++;
                    }
                }
            }

            int end = tileShownIndex + (tileNumberColumn * tileNumberRow);

            for (int i = tileShownIndex; i < end; i++)
            {
                tiles[i].isActive = true;
            }

            SelectTile(0);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].isActive)
                    tiles[i].Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsInside())
            {
                if (InputManager.instance.GetMouseButtonPressed(0))
                {
                    Vector2 pos = InputManager.instance.GetMousePosition();
                    pos.X -= positionX;
                    pos.Y -= positionY;

                    int x = (int)(pos.X / Data.TileSize);
                    int y = (int)(pos.Y / Data.TileSize);

                    SelectTile((y * tileNumberColumn + x) + (page * tileNumberColumn * tileNumberRow));
                }
            }

            if(InputManager.instance.GetKeyboardPressed(Keys.E))
            {
                ChangePage(1);
            }
            else if (InputManager.instance.GetKeyboardPressed(Keys.A))
            {
                ChangePage(-1);
            }
        }

        private void SelectTile(int index)
        {
            if (tileCurrentIndex != -1)
            {
                tiles[tileCurrentIndex].color = Color.White;
            }

            tileCurrentIndex = index;

            if (index == -1)
                return;

            tiles[tileCurrentIndex].color = Color.Red;
        }

        private void ChangePage(int increment)
        {
            int newShownIndex = tileShownIndex;
            if(increment < 0)
            {
                if (page == 0)
                    return;
                page--;
                newShownIndex -= tileNumberColumn * tileNumberRow;
            }
            else
            {
                if (page + 1 == pageMax)
                    return;
                page++;
                newShownIndex += tileNumberColumn * tileNumberRow;
            }

            SelectTile(-1);

            tileCurrentIndex = 0;

            int end = tileShownIndex + (tileNumberColumn * tileNumberRow);

            for (int i = tileShownIndex; i < end; i++)
            {
                tiles[i].isActive = false;
            }

            tileShownIndex = newShownIndex;

            end = newShownIndex + (tileNumberColumn * tileNumberRow);

            for (int i = newShownIndex; i < end; i++)
            {
                tiles[i].isActive = true;
            }

            SelectTile(page * tileNumberColumn * tileNumberRow);
        }

        public int GetPage()
        {
            return page;
        }

        public int GetMaxPage()
        {
            return pageMax;
        }

        public string GetSelectedTile()
        {
            if (tileCurrentIndex == -1)
                return "";

            return tiles[tileCurrentIndex].texturePath;
        }
    }
}
