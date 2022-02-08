using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Editor;
using MonoGamePrototype.Engine;
using MonoGamePrototype.Gameplay.Levels;
using System;

namespace MonoGamePrototype.Gameplay.Menu
{
    public class MainMenuUI : UIMenu
    {
        private OptionMenuUI optionMenuUI { get; set; } = null;

        public override void Initialize()
        {
            entityTexts = new EntityText[4];

            float offset = 150.0f;

            float centerX = Data.Width / 2.0f;

            entityTexts[0] = new EntityText("New Game")
            {
                positionX = centerX,
                positionY = Data.Height * 0.5f,
                textAlign = TextAlign.CENTER
            };

            entityTexts[1] = new EntityText("Options")
            {
                positionX = centerX,
                positionY = Data.Height * 0.5f + offset,
                textAlign = TextAlign.CENTER
            };

            entityTexts[2] = new EntityText("Exit")
            {
                positionX = centerX,
                positionY = Data.Height * 0.5f + offset * 2,
                textAlign = TextAlign.CENTER
            };

            entityTexts[3] = new EntityText("Level Editor")
            {
                positionX = centerX,
                positionY = Data.Height * 0.5f + offset * 3,
                textAlign = TextAlign.CENTER
            };

            entityTexts[menuIndex].color = Color.Red;

            base.Initialize();
        }

        public override void Start()
        {
            base.Start();

            for(int i = 0; i < entityTexts.Length; i++)
            {
                UIManager.instance.AddEntity(entityTexts[i]);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (InputManager.instance.GetKeyboardPressed(Keys.Enter))
            {
                if (menuIndex == 0)
                {
                    UIManager.instance.ClearEntities();
                    GameManager.instance.SetGameState(GameManager.GameState.GAME);
                    FirstLevel firstLevel = new FirstLevel("First Level");
                    SceneManager.instance.SetLevel(firstLevel);
                }
                else if (menuIndex == 1)
                {
                    if (optionMenuUI == null)
                    {
                        optionMenuUI = new OptionMenuUI();
                        optionMenuUI.Initialize();
                        optionMenuUI.Start();
                        optionMenuUI.currentLevel = currentLevel;
                    }
                    currentLevel.SetCurrentMenu(optionMenuUI);
                }
                else if (menuIndex == 2)
                {
                    MainGame.instance.Exit();
                }
                else if (menuIndex == 3)
                {
                    UIManager.instance.ClearEntities();
                    GameManager.instance.SetGameState(GameManager.GameState.GAME);
                    LevelEditor levelEditor = new LevelEditor();
                    SceneManager.instance.SetLevel(levelEditor);
                }
            }
        }
    }
}
