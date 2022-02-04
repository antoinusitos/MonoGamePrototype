using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
            entityTexts = new EntityText[3];

            float offset = 150.0f;

            entityTexts[0] = new EntityText("New Game")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f),
                textAlign = TextAlign.CENTER
            };
            UIManager.instance.AddEntity(entityTexts[0], false);

            entityTexts[1] = new EntityText("Options")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f + offset),
                textAlign = TextAlign.CENTER
            };
            UIManager.instance.AddEntity(entityTexts[1], false);

            entityTexts[2] = new EntityText("Exit")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f + offset * 2),
                textAlign = TextAlign.CENTER
            };
            UIManager.instance.AddEntity(entityTexts[2], false);

            entityTexts[menuIndex].color = Color.Red;

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (InputManager.instance.GetKeyboardPressed(Keys.Enter))
            {
                if (menuIndex == 0)
                {
                    UIManager.instance.ClearEntities();
                    SceneManager.instance.SetLevel(new FirstLevel());
                }
                else if (menuIndex == 1)
                {
                    if (optionMenuUI == null)
                    {
                        optionMenuUI = new OptionMenuUI();
                        optionMenuUI.Initialize();
                        optionMenuUI.currentLevel = currentLevel;
                    }
                    currentLevel.SetCurrentMenu(optionMenuUI);
                }
                else if (menuIndex == 2)
                {
                    MainGame.instance.Exit();
                }
            }
        }
    }
}
