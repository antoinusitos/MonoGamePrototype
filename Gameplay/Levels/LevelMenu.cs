using Microsoft.Xna.Framework;
using MonoGamePrototype.Engine;
using MonoGamePrototype.Gameplay.Entities;

namespace MonoGamePrototype.Gameplay.Levels
{
    public class LevelMenu : Level
    {
        public override void Initialize()
        {
            EntityText newGameText = new EntityText("New Game");
            newGameText.position = new Vector2(100, 100);
            newGameText.textAlign = TextAlign.CENTER;
            entities.Add(newGameText);

            EntityText ExitText = new EntityText("Exit");
            ExitText.position = new Vector2(100, 150);
            ExitText.textAlign = TextAlign.CENTER;
            entities.Add(ExitText);

            base.Initialize();
        }
    }
}
