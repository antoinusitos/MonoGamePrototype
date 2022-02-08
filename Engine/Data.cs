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
    }
}
