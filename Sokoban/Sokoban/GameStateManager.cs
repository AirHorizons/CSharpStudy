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
                    Games.Add(new SokobanGame(row, col, SingleMap));
                }
            }
        }

        public void SelectMap()
        {
            Console.Write("Choose Level: ");
            try
            {
                int level = Int32.Parse(Console.ReadLine());
                Games.ElementAt(level - 1).Run();
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
