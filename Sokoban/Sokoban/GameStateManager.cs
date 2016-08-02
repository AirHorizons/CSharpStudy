using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class GameStateManager
    {
        private const int MAXHEIGHT = 30;
        public List<SokobanGame> Games = new List<SokobanGame>();
        string[] RawMapData;
        string[] SingleMap;

        public void LoadMap(string filename)
        {
            int level = 1;
            RawMapData = System.IO.File.ReadAllLines(filename);
            for (int line = 0; line < RawMapData.Length; line++)
            {
                if (RawMapData[line].Length == 0) continue;
                else
                {
                    int row = 0;
                    int col = 0;
                    SingleMap = new string[MAXHEIGHT];
                    while (!(RawMapData[line][0] == ';'))
                    {                   
                        if (RawMapData[line].Length > col) col = RawMapData[line].Length;
                        SingleMap[row] = RawMapData[line];
                        row += 1;
                        line += 1;
                    }
                    line += 1;
                    Games.Add(new SokobanGame(row, col, SingleMap, level));
                    level += 1;
                }
            }
        }

        public int SelectMap(int start = 0)
        {
            if (start != 0)
            {
                Games.ElementAt(start).Run();
                return start + 1;
            }
            else
            {
                Console.Write("Choose Level: ");
                try
                {                   
                    int level = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    if (level == 0) return 0;
                    Games.ElementAt(level - 1).Run();
                    return level;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
           
        }
    }
}
