using Microsoft.Xna.Framework;
using MonoGamePrototype.Engine;

namespace MonoGamePrototype.Editor
{
    public class LevelEditorMenuUI : UIMenu
    {
        private EntityText levelNameText { get; set; } = null;

        private TileSelectionPanel tilePanel { get; set; } = null;

        private EntityText tilePanelPageText { get; set; } = null;

        private EntityText layerText { get; set; } = null;

        public override void Initialize()
        {
            base.Initialize();

            levelNameText = new EntityText("Level Name : NOT SAVED")
            {
                positionX = Data.Width / 2.0f,
                positionY = 0,
                textAlign = TextAlign.CENTER,
                textType = TextType.BOLD
            };

            tilePanel = new TileSelectionPanel()
            {
                positionX = 50,
                positionY = 50,
                color = Color.Black
            };

            tilePanelPageText = new EntityText("Page : 0 / 0")
            {
                positionX = 50,
                positionY = tilePanel.size.Y + 50,
                textAlign = TextAlign.LEFT
            };

            layerText = new EntityText("Layer : 0")
            {
                positionX = 50,
                positionY = tilePanel.size.Y + 100,
                textAlign = TextAlign.LEFT
            };
        }

        public override void Start()
        {
            base.Start();

            UIManager.instance.AddEntity(levelNameText);
            UIManager.instance.AddEntity(tilePanel);
            UIManager.instance.AddEntity(tilePanelPageText);
            UIManager.instance.AddEntity(layerText);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            tilePanelPageText.text = "Page : " + (tilePanel.GetPage() + 1) + " / " + tilePanel.GetMaxPage();
        }

        public string GetSelectedTile()
        {
            return tilePanel.GetSelectedTile();
        }

        public bool GetIsOnPanel()
        {
            return tilePanel.IsInside();
        }

        public void UpdateMapName(string aName)
        {
            levelNameText.text = "Level Name : " + aName;
        }

        public void UpdateLayerText(int layer)
        {
            layerText.text = "Layer : " + layer;
        }
    }
}
