using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MonoGamePrototype.Engine;
using System;

namespace MonoGamePrototype.Editor
{
    public class LevelEditorMenuUI : UIMenu
    {
        private EntityText levelNameText { get; set; } = null;

        private TileSelectionPanel tilePanel { get; set; } = null;

        public override void Initialize()
        {
            base.Initialize();

            levelNameText = new EntityText("Level Name : NOT SAVED")
            {
                positionX = Data.Width / 2.0f,
                positionY = 0,
                textAlign = TextAlign.CENTER
            };

            tilePanel = new TileSelectionPanel()
            {
                positionX = 50,
                positionY = 50,
                color = Color.Black
            };
        }

        public override void Start()
        {
            base.Start();

            UIManager.instance.AddEntity(levelNameText);
            UIManager.instance.AddEntity(tilePanel);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
