using Microsoft.Xna.Framework;
using MonoGamePrototype.Engine;
using MonoGamePrototype.Gameplay.Menu;

namespace MonoGamePrototype.Gameplay.Levels
{
    public class LevelMenu : Level
    {
        private MainMenuUI mainMenuUI { get; set; } = null;

        public LevelMenu()
        {
            mainMenuUI = new MainMenuUI();
        }

        public override void Initialize()
        {
            base.Initialize();

            mainMenuUI.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            mainMenuUI.Update(gameTime);
        }
    }
}
