using System;
using System.IO;
using System.Text.Json;

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

        public string[] LoadLevelText(string levelName, bool debug = false)
        {
            string path = Data.LevelPath + levelName;
            string[] lines = File.ReadAllLines(path);

            if(!debug)
                return lines;

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of level = \n");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine(line);
            }

            return lines;
        }

        public Tile[] LoadLevel(string levelName)
        {
            string fileName = Data.LevelPath + levelName;
            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Tile[]>(jsonString);
        }
    }
}
