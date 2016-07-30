using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class SokobanGame
    {
        public Tile[][] Map; // Wall: X, player: P, box: B, slot: o, Filled Slot: O
        public Player player;
        public List<Block> BlockList;
        public int Row { get; private set; }
        public int Col { get; private set; }
        public Vector2i PlayerPos;
        public int Turn { get; private set; }

        public SokobanGame()
        {
            string[] testmap = { "XXXXXXX", "X    oX", "XPBB  X", "X    oX", "XXXXXXX" };
            ScanMap(5, 7, testmap);
        }


        public void Run()
        {
            Console.WriteLine("SokobanGame!");
            PrintMap();
            while (!isClear())
            {                
                ExecuteTurn();
                PrintMap();
            }
        }

        public void ExecuteTurn()
        {
            
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.UpArrow) Move('u');
            else if (key.Key == ConsoleKey.DownArrow) Move('d');
            else if (key.Key == ConsoleKey.LeftArrow) Move('l');
            else if (key.Key == ConsoleKey.RightArrow) Move('r');
        }

        public void Move(char dir)
        {
            Console.Clear();
            if (dir == 'u')
            {
                Tile UpTile = getTileByInt(player.pos.x - 1, player.pos.y);
                Tile UpUpTile = getTileByInt(player.pos.x - 2, player.pos.y);
                if (UpTile == null) return;
                else
                {
                    if (!(UpTile is Wall)&& !UpTile.onBox)
                    {
                        Map[player.pos.x][player.pos.y].onPlayer = false;
                        player.pos.x -= 1;
                        Map[player.pos.x][player.pos.y].onPlayer = true;
                        Turn += 1;
                    }
                    else if (!(UpTile is Wall) && UpTile.onBox)
                    {
                        if (UpUpTile != null && !(UpUpTile is Wall) && !UpUpTile.onBox )
                        {
                            Map[player.pos.x-1][player.pos.y].onBox = false;
                            Map[player.pos.x - 2][player.pos.y].onBox = true;
                            Map[player.pos.x][player.pos.y].onPlayer = false;
                            player.pos.x -= 1;
                            Map[player.pos.x][player.pos.y].onPlayer = true;
                            Turn += 1;
                        }
                    }
                }
            }
            else if (dir == 'd')
            {
                Tile DownTile = getTileByInt(player.pos.x + 1, player.pos.y);
                Tile DownDownTile = getTileByInt(player.pos.x + 2, player.pos.y);
                if (DownTile == null) return;
                else
                {
                    if (!(DownTile is Wall) && !DownTile.onBox)
                    {
                        Map[player.pos.x][player.pos.y].onPlayer = false;
                        player.pos.x += 1;
                        Map[player.pos.x][player.pos.y].onPlayer = true;
                        Turn += 1;
                    }
                    else if (!(DownTile is Wall) && DownTile.onBox)
                    {
                        if (DownDownTile != null && !(DownDownTile is Wall) && !DownDownTile.onBox)
                        {
                            Map[player.pos.x + 1][player.pos.y].onBox = false;
                            Map[player.pos.x + 2][player.pos.y].onBox = true;
                            Map[player.pos.x][player.pos.y].onPlayer = false;
                            player.pos.x += 1;
                            Map[player.pos.x][player.pos.y].onPlayer = true;
                            Turn += 1;
                        }
                    }
                }
            }
            else if (dir == 'l')
            {
                Tile LeftTile = getTileByInt(player.pos.x, player.pos.y-1);
                Tile LeftLeftTile = getTileByInt(player.pos.x , player.pos.y-2);
                if (LeftTile == null) return;
                else
                {
                    if (!(LeftTile is Wall) && !LeftTile.onBox)
                    {
                        Map[player.pos.x][player.pos.y].onPlayer = false;
                        player.pos.y -= 1;
                        Map[player.pos.x][player.pos.y].onPlayer = true;
                        Turn += 1;
                    }
                    else if (!(LeftTile is Wall) && LeftTile.onBox)
                    {
                        if (LeftLeftTile != null && !(LeftLeftTile is Wall) && !LeftLeftTile.onBox)
                        {
                            Map[player.pos.x][player.pos.y - 1].onBox = false;
                            Map[player.pos.x][player.pos.y - 2].onBox = true;
                            Map[player.pos.x][player.pos.y].onPlayer = false;
                            player.pos.y -= 1;
                            Map[player.pos.x][player.pos.y].onPlayer = true;
                            Turn += 1;
                        }
                    }
                }
            }
            else if (dir == 'r')
            {
                Tile RightTile = getTileByInt(player.pos.x, player.pos.y + 1);
                Tile RightRightTile = getTileByInt(player.pos.x, player.pos.y + 2);
                if (RightTile == null) return;
                else
                {
                    if (!(RightTile is Wall) && !RightTile.onBox)
                    {
                        Map[player.pos.x][player.pos.y].onPlayer = false;
                        player.pos.y += 1;
                        Map[player.pos.x][player.pos.y].onPlayer = true;
                        Turn += 1;
                    }
                    else if (!(RightTile is Wall) && RightTile.onBox)
                    {
                        if (RightRightTile != null && !(RightRightTile is Wall) && !RightRightTile.onBox)
                        {
                            Map[player.pos.x][player.pos.y + 1].onBox = false;
                            Map[player.pos.x][player.pos.y + 2].onBox = true;
                            Map[player.pos.x][player.pos.y].onPlayer = false;
                            player.pos.y += 1;
                            Map[player.pos.x][player.pos.y].onPlayer = true;
                            Turn += 1;
                        }
                    }
                }
            }
        }

        public bool isClear()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0 ; j < Col ; j++)
                {
                    if (Map[i][j] is Slot && !(Map[i][j] as Slot).onBox)
                        return false;
                }
            }
            return true;
        }

        public Tile getTileByInt(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Row || y >= Col) return null;
            return Map[x][y];
        }

        public Tile getTileByVector(Vector2i v)
        {
            if (v.x < 0 || v.y < 0 || v.x >= Row || v.y >= Col) return null;
            return Map[v.x][v.y];
        }

        public void ScanMap(int row, int col, String[] mapdata)
        {
            this.Row = row;
            this.Col = col;
            Map = new Tile[row][];
            for (int i = 0; i < row; i++) Map[i] = new Tile[col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    char tile = mapdata[i][j];
                    if (tile == 'X') Map[i][j] = new Wall();
                    else if (tile == ' ') Map[i][j] = new Floor();
                    else if (tile == 'P')
                    {
                        Map[i][j] = new Floor(false, true);
                        player = new Player(i, j);
                        player.pos.x = i; player.pos.y = j;
                    }
                    else if (tile == 'B') Map[i][j] = new Floor(true, false);
                    else if (tile == 'o') Map[i][j] = new Slot();
                    else if (tile == 'O') Map[i][j] = new Slot(true, false);
                    else if (tile == 'p') Map[i][j] = new Slot(false, true);
                }
            }

        }

        public void PrintMap()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (Map[i][j] is Wall) Console.Write("X");
                    else if (Map[i][j] is Floor)
                    {
                        if ((Map[i][j] as Floor).onPlayer) Console.Write("P");
                        else if ((Map[i][j] as Floor).onBox) Console.Write("B");
                        else Console.Write(" ");
                    }
                    else if (Map[i][j] is Slot)
                    {
                        if ((Map[i][j] as Slot).onPlayer) Console.Write("p");
                        else if ((Map[i][j] as Slot).onBox) Console.Write("O");
                        else Console.Write("o");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("Turn Number: {0}", Turn);
        }
    }
}
