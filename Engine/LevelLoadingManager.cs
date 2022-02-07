using System;
using System.IO;

namespace MonoGamePrototype.Engine
{
    public class LevelLoadingManager : Manager
    {
        public static LevelLoadingManager instance { get; set; } = null;

        public override void Initialize()
        {
            base.Initialize();

            instance = this;
        }

        public string[] LoadLevel(string levelName)
        {
            string path = Directory.GetCurrentDirectory() + "\\Content\\Assets\\Levels\\" + levelName;
            string[] lines = System.IO.File.ReadAllLines(path);

            return lines;

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of level = \n");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine(line);
            }
        }
    }
}
