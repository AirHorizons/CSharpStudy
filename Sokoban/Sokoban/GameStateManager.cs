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
                SingleMap = new string[MAXHEIGHT];
            }
        }
    }
}
