using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;
using System;

namespace MonoGamePrototype.Gameplay.Menu
{
    public class MainMenuUI : UIMenu
    {

        private int menuIndex { get; set; } = 0;

        private EntityText[] entityTexts { get; set; } = null;


        public override void Initialize()
        {
            entityTexts = new EntityText[3];

            float offset = 150.0f;

            entityTexts[0] = new EntityText("New Game")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f),
                textAlign = TextAlign.CENTER
            };
            UIManager.instance.AddEntity(entityTexts[0]);

            entityTexts[1] = new EntityText("Options")
            {
                position = new Vector2(Data.Width / 2.0f, Data.Height * 0.5f + offset),
                textAlign = TextAlign.CENTER
            };
            UIManager.instance.AddEntity(entityTexts[1]);

            entityTexts[2] = new EntityText("Exit")
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
            bool needUpdate = false;
            int increment = 0;
            if (InputManager.instance.GetKeyboardPressed(Keys.Z) && menuIndex > 0)
            {
                increment--;
                needUpdate = true;
            }
            else if (InputManager.instance.GetKeyboardPressed(Keys.S) && menuIndex < 2)
            {
                increment++;
                needUpdate = true;
            }

            if (needUpdate)
            {
                entityTexts[menuIndex].color = Color.White;
                menuIndex += increment;
                entityTexts[menuIndex].color = Color.Red;
            }

            if (InputManager.instance.GetKeyboardPressed(Keys.Enter))
            {
                if (menuIndex == 0)
                {
                    Console.WriteLine("New Game");
                }
                else if (menuIndex == 1)
                {
                    Console.WriteLine("Options");
                }
                else if (menuIndex == 2)
                {
                    MainGame.instance.Exit();
                }
            }
        }
    }
}
