using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;
using MonoGamePrototype.Gameplay.Levels;

namespace MonoGamePrototype.Editor
{
    public class LevelEditorPauseMenu : UIMenu
    {
        public override void Initialize()
        {
            entityTexts = new EntityText[3];

            float offset = 150.0f;

            entityTexts[0] = new EntityText("Resume")
            {
                positionX = Data.Width / 2.0f,
                positionY = Data.Height * 0.5f,
                textAlign = TextAlign.CENTER,
                isActive = false,
                textType = TextType.TITLE
            };

            entityTexts[1] = new EntityText("Save")
            {
                positionX = Data.Width / 2.0f,
                positionY = Data.Height * 0.5f + offset,
                textAlign = TextAlign.CENTER,
                isActive = false,
                textType = TextType.TITLE
            };

            entityTexts[2] = new EntityText("Main Menu")
            {
                positionX = Data.Width / 2.0f,
                positionY = Data.Height * 0.5f + offset * 2,
                textAlign = TextAlign.CENTER,
                isActive = false,
                textType = TextType.TITLE
            };

            entityTexts[menuIndex].color = Color.Red;

            base.Initialize();
        }

        public override void Start()
        {
            base.Start();

            for (int i = 0; i < entityTexts.Length; i++)
            {
                UIManager.instance.AddEntity(entityTexts[i]);
            }
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
                    GameManager.instance.SetGameState(GameManager.GameState.LEVELEDITOR);
                }
                else if (menuIndex == 1)
                {
                    LevelEditor levelEditor = (LevelEditor)(SceneManager.instance.GetCurrentLevel());
                    levelEditor.SaveLevel();
                    SetActive(false);
                    GameManager.instance.SetGameState(GameManager.GameState.LEVELEDITOR);
                }
                else if (menuIndex == 2)
                {
                    UIManager.instance.ClearEntities();
                    GameManager.instance.SetGameState(GameManager.GameState.MENU);
                    SceneManager.instance.SetLevel(new LevelMenu("Main menu"));
                }
            }
        }
    }
}
