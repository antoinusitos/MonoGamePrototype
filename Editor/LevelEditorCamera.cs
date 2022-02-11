using Microsoft.Xna.Framework;
using MonoGamePrototype.Engine;

namespace MonoGamePrototype.Editor
{
    public class LevelEditorCamera : Camera
    {
        private float cameraSpeed { get; set; } = 0.1f;

        public void Move(Vector2 movement)
        {
            Vector2 newMovement = movement * cameraSpeed;

            positionX += newMovement.X;
            positionY += newMovement.Y;
            transform = Matrix.CreateTranslation(
                    positionX - newMovement.X,
                    positionY - newMovement.Y,
                    0) * Matrix.CreateTranslation(Data.Width / 2, Data.Height / 2, 0);
        }
    }
}
