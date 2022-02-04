using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGamePrototype.Gameplay.Levels;

namespace MonoGamePrototype.Engine
{
    public class UIMenu : BaseBehaviour
    {
        public bool isActive { get; set; } = true;
        public LevelMenu currentLevel { get; set; } = null;

        protected int menuIndex { get; set; } = 0;

        protected EntityText[] entityTexts { get; set; } = null;


        public override void Update(GameTime gameTime)
        {
            bool needUpdate = false;
            int increment = 0;
            if (InputManager.instance.GetKeyboardPressed(Keys.Z) && menuIndex > 0)
            {
                increment--;
                needUpdate = true;
            }
            else if (InputManager.instance.GetKeyboardPressed(Keys.S) && menuIndex < entityTexts.Length - 1)
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
        }

        public virtual void SetActive(bool aState)
        {
            isActive = aState;

            for (int i = 0; i < entityTexts.Length; i++)
            {
                entityTexts[i].isActive = aState;
            }
        }
    }
}
