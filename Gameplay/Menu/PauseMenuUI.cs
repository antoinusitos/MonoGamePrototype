using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;
using MonoGamePrototype.Gameplay.Levels;

namespace MonoGamePrototype.Gameplay.Menu
{
    public class PauseMenuUI : UIMenu
    {
        public override void Initialize()
        {
            entityTexts = new EntityText[3];

            float offset = 150.0f;

            entityTexts[0] = new EntityText("Resume")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f),
                textAlign = TextAlign.CENTER
            };

            entityTexts[1] = new EntityText("Options")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f + offset),
                textAlign = TextAlign.CENTER
            };

            entityTexts[2] = new EntityText("Main Menu")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f + offset * 2),
                textAlign = TextAlign.CENTER
            };

            entityTexts[menuIndex].color = Color.Red;

            base.Initialize();
        }

        public override void Start()
        {
            base.Start();

            UIManager.instance.AddEntity(entityTexts[0]);
            UIManager.instance.AddEntity(entityTexts[1]);
            UIManager.instance.AddEntity(entityTexts[2]);
        }

        public override void Update(GameTime gameTime)
        {
            if (!isActive)
                return;

            if (GameManager.instance.currentGameState != GameManager.GameState.PAUSE)
                return;

            base.Update(gameTime);

            if (InputManager.instance.GetKeyboardPressed(Keys.Enter))
            {
                if (menuIndex == 0)
                {
                    SetActive(false);
                    GameManager.instance.SetGameState(GameManager.GameState.GAME);
                }
                else if (menuIndex == 1)
                {
                }
                else if (menuIndex == 2)
                {
                    UIManager.instance.ClearEntities();
                    GameManager.instance.SetGameState(GameManager.GameState.MENU);
                    SceneManager.instance.SetLevel(new LevelMenu());
                }
            }
        }
    }
}
