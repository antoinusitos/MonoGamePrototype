using Microsoft.Xna.Framework;

namespace MonoGamePrototype.Engine
{
    public class CameraManager : Manager
    {
        private Camera currentCamera { get; set; } = null;

        public void SetCamera(Camera camera)
        {
            currentCamera = camera;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            currentCamera.Update(gameTime);
        }
    }
}
