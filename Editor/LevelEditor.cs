using Microsoft.Xna.Framework.Content;
using MonoGamePrototype.Engine;

namespace MonoGamePrototype.Editor
{
    public class LevelEditor : Level
    {
        EntityText levelNameText { get; set; } = null;

        public LevelEditor(string name = "Level Editor") : base(name)
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();

            levelNameText = new EntityText("Level Name : NOT SAVED")
            {
                positionX = Data.Width / 2.0f,
                positionY = 0,
                textAlign = TextAlign.CENTER
            };
        }

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);
        }

        public override void Start()
        {
            base.Start();

            UIManager.instance.AddEntity(levelNameText);
        }
    }
}
