using Microsoft.Xna.Framework;
using MonoGamePrototype.Engine;
using MonoGamePrototype.Gameplay.Menu;

namespace MonoGamePrototype.Gameplay.Levels
{
    public class LevelMenu : Level
    {
        private MainMenuUI mainMenuUI { get; set; } = null;

        private UIMenu currentMenu { get; set; } = null;
        private UIMenu previousMenu { get; set; } = null;

        public LevelMenu()
        {
            mainMenuUI = new MainMenuUI();

            currentMenu = mainMenuUI;
            previousMenu = mainMenuUI;
        }

        public override void Initialize()
        {
            base.Initialize();

            mainMenuUI.Initialize();
            mainMenuUI.currentLevel = this;
        }

        public override void Start()
        {
            base.Start();
            mainMenuUI.Start();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            currentMenu.Update(gameTime);
        }

        public void SetCurrentMenu(UIMenu uIMenu)
        {
            currentMenu.SetActive(false);
            previousMenu = currentMenu;
            currentMenu = uIMenu;
            currentMenu.SetActive(true);
        }

        public void BackToPreviousMenu()
        {
            currentMenu.SetActive(false);
            currentMenu = previousMenu;
            currentMenu.SetActive(true);
        }
    }
}
