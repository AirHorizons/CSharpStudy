using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            GameStateManager gsm = new GameStateManager();
            gsm.LoadMap("maps.txt");
            gsm.SelectMap();
        }
    }
}
