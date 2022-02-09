using Microsoft.Xna.Framework;
using System.IO;

namespace MonoGamePrototype.Engine
{
    public class Data
    {
        public static string DataPath = "Assets/PNG/";
        public static string LevelPath = Directory.GetCurrentDirectory() + "\\Content\\Assets\\Levels\\";
        public static int Width = 1920;
        public static int Height = 1080;
        public static bool FullScreen = false;
        public static int TileSize = 64;
        public static float ZOrderMax = 100;
        public static float UIZOrderStart = (ZOrderMax / 2) + 1;

        public static Vector2 ScreenToWorldSpace(in Vector2 point)
        {
            if(CameraManager.instance.currentCamera == null)
            {
                return Vector2.Zero;
            }

            Matrix invertedMatrix = Matrix.Invert(CameraManager.instance.currentCamera.transform);
            return Vector2.Transform(point, invertedMatrix);
        }
    }
}
