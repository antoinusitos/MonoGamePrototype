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
    }
}
