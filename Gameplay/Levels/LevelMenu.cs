using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Engine;

namespace MonoGamePrototype.Gameplay.Levels
{
    public class LevelMenu : Level
    {
        private int menuIndex { get; set; } = 0;

        private EntityText[] entityTexts { get; set; } = null;

        public override void Initialize()
        {
            entityTexts = new EntityText[3];

            EntityText newGameText = new EntityText("New Game");
            newGameText.position = new Vector2(100, 100);
            newGameText.textAlign = TextAlign.CENTER;
            entities.Add(newGameText);
            entityTexts[0] = newGameText;

            EntityText optionText = new EntityText("Options");
            optionText.position = new Vector2(100, 150);
            optionText.textAlign = TextAlign.CENTER;
            entities.Add(optionText);
            entityTexts[1] = optionText;

            EntityText exitText = new EntityText("Exit");
            exitText.position = new Vector2(100, 200);
            exitText.textAlign = TextAlign.CENTER;
            entities.Add(exitText);
            entityTexts[2] = exitText;

            entityTexts[menuIndex].color = Color.Red;

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            bool needUpdate = false;
            int increment = 0;
            if (InputManager.instance.GetKeyboardPressed(Keys.Z) && menuIndex > 0)
            {
                increment--;
                needUpdate = true;
            }
            else if(InputManager.instance.GetKeyboardPressed(Keys.S) && menuIndex < 2)
            {
                increment++; 
                needUpdate = true;
            }

            if(needUpdate)
            {
                entityTexts[menuIndex].color = Color.White;
                menuIndex += increment;
                entityTexts[menuIndex].color = Color.Red;
            }

            if(InputManager.instance.GetKeyboardPressed(Keys.Enter))
            {
                //TODO : handle the menu reaction
            }
        }
    }
}
