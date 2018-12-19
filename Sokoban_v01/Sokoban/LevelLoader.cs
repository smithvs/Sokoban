using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sokoban
{


    class LevelsLoader
    {
        string directory;
        List<Level> levels;

        public LevelsLoader(string dir)
        {
            directory = dir;
        }

        public List<Level> Load()
        {
            levels = new List<Level>();
            foreach (var testFile in Directory.GetFiles(directory, "*.txt"))
            {
                Level newLevel = new Level();
                int currentLine = 0;
                List<String> mapTemplate = new List<string>();
                List<Position> boxPosition = new List<Position>();
                var lines = File.ReadAllLines(testFile);
                var countRowMap = int.Parse(lines[currentLine++]);
                for (; currentLine <= countRowMap; currentLine++)
                    mapTemplate.Add(lines[currentLine]);

                var countBox = int.Parse(lines[currentLine++]);
                for (int i = 0; i < countBox; i++, currentLine++)
                {
                    string[] pos = lines[currentLine].Split(' ');
                    boxPosition.Add(new Position(int.Parse(pos[0]), int.Parse(pos[1])));
                }
                string[] startPos = lines[currentLine].Split(' ');
                var startPosition = new Position(int.Parse(startPos[0]), int.Parse(startPos[1]));

                newLevel.Initialize(mapTemplate, boxPosition, startPosition);
                levels.Add(newLevel);


            }

            return levels;
        }
    }
}

