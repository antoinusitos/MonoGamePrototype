using Microsoft.Xna.Framework;
using MonoGamePrototype.Engine;

namespace MonoGamePrototype.Gameplay.Entities
{
    public class PlayerCamera : Camera
    {
        private Player playerTarget { get; set; } = null;

        public void SetPlayer(Player player)
        {
            playerTarget = player;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(playerTarget != null)
            {
                position = playerTarget.position;
                transform = Matrix.CreateTranslation(
                    -playerTarget.position.X,
                    -playerTarget.position.Y,
                    0) * Matrix.CreateTranslation(Data.Width / 2, Data.Height / 2, 0);
            }
        }
    }
}
