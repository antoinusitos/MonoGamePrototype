using Microsoft.Xna.Framework;

namespace MonoGamePrototype.Engine
{
    public class CameraManager : Manager
    {
        public static CameraManager instance { get; private set; } = null;

        public Camera currentCamera { get; set; } = null;

        public void SetCamera(Camera camera)
        {
            currentCamera = camera;
        }

        public override void Initialize()
        {
            base.Initialize();

            instance = this;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(currentCamera != null)
                currentCamera.Update(gameTime);
        }
    }
}
