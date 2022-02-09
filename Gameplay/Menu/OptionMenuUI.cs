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
                positionX = Data.Width / 2.0f,
                positionY = Data.Height * 0.5f,
                textAlign = TextAlign.CENTER,
                textType = TextType.TITLE
            };

            entityTexts[1] = new EntityText("Option 2")
            {
                positionX = Data.Width / 2.0f,
                positionY = Data.Height * 0.5f + offset,
                textAlign = TextAlign.CENTER,
                textType = TextType.TITLE
            };

            entityTexts[2] = new EntityText("Back")
            {
                positionX = Data.Width / 2.0f,
                positionY = Data.Height * 0.5f + offset * 2,
                textAlign = TextAlign.CENTER,
                textType = TextType.TITLE
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
