using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;
using System;

namespace MonoGamePrototype.Gameplay.Menu
{
    public class OptionMenuUI : UIMenu
    {
        public override void Initialize()
        {
            entityTexts = new EntityText[3];

            float offset = 150.0f;

            entityTexts[0] = new EntityText("Option 1")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f),
                textAlign = TextAlign.CENTER
            };
            UIManager.instance.AddEntity(entityTexts[0]);

            entityTexts[1] = new EntityText("Option 2")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f + offset),
                textAlign = TextAlign.CENTER
            };
            UIManager.instance.AddEntity(entityTexts[1]);

            entityTexts[2] = new EntityText("Back")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f + offset * 2),
                textAlign = TextAlign.CENTER
            };
            UIManager.instance.AddEntity(entityTexts[2]);

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
                    Console.WriteLine("Option 1");
                }
                else if (menuIndex == 1)
                {
                    Console.WriteLine("Option 2");
                }
                else if (menuIndex == 2)
                {
                    currentLevel.BackToPreviousMenu();
                }
            }
        }
    }
}
