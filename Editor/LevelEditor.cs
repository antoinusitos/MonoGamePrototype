using MonoGamePrototype.Engine;
using Microsoft.Xna.Framework;

namespace MonoGamePrototype.Editor
{
    public class LevelEditor : Level
    {
        private LevelEditorMenuUI levelEditorMenuUI { get; set; } = null;

        public LevelEditor(string name = "Level Editor") : base(name)
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();

            levelEditorMenuUI = new LevelEditorMenuUI();
            levelEditorMenuUI.Initialize();
        }

        public override void Start()
        {
            base.Start();

            levelEditorMenuUI.Start();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            levelEditorMenuUI.Update(gameTime);
        }
    }
}
