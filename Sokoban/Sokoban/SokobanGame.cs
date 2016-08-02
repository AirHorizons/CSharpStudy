using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class SokobanGame
    {
        public Tile[,] Map; // Wall: X, player: P, box: B, slot: o, Filled Slot: O
        public Player player;
        public List<Block> BlockList = new List<Block>();
        public int Row { get; private set; }
        public int Col { get; private set; }
        public int Turn { get; private set; }
        public int Level { get; private set; }

        public SokobanGame(int row, int col, string[] MapData, int level)
        {
            ScanMap(row, col, MapData);
            Level = level;
        }


        public void Run()
        {
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
            int px = player.pos.x;
            int py = player.pos.y;
            if (dir == 'u')
            {
                Tile UpTile = getTileByInt(player.pos.x - 1, player.pos.y);
                Tile UpUpTile = getTileByInt(player.pos.x - 2, player.pos.y);
                if (UpTile == null) return;
                else
                {
                    if (!(UpTile is Wall)&& !FindBlock(px-1, py))
                    {                       
                        player.pos.x -= 1;
                        Turn += 1;
                    }
                    else if (!(UpTile is Wall) && FindBlock(px - 1, py))
                    {
                        if (UpUpTile != null && !(UpUpTile is Wall) && !FindBlock(px-2, py))
                        {
                            MoveBlock(px - 1, py, 'u');
                            player.pos.x -= 1;
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
                    if (!(DownTile is Wall) && !FindBlock(px + 1, py))
                    {
                        player.pos.x += 1;
                        Turn += 1;
                    }
                    else if (!(DownTile is Wall) && FindBlock(px + 1, py))
                    {
                        if (DownDownTile != null && !(DownDownTile is Wall) && !FindBlock(px+2, py))
                        {
                            MoveBlock(px + 1, py, 'd');
                            player.pos.x += 1;
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
                    if (!(LeftTile is Wall) && !FindBlock(px, py - 1))
                    {
                        player.pos.y -= 1;
                        Turn += 1;
                    }
                    else if (!(LeftTile is Wall) && FindBlock(px, py - 1))
                    {
                        if (LeftLeftTile != null && !(LeftLeftTile is Wall) && !FindBlock(px, py-2))
                        {
                            MoveBlock(px, py-1, 'l');
                            player.pos.y -= 1;
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
                    if (!(RightTile is Wall) && !FindBlock(px, py + 1))
                    {
                        player.pos.y += 1;
                        Turn += 1;
                    }
                    else if (!(RightTile is Wall) && FindBlock(px, py + 1))
                    {
                        if (RightRightTile != null && !(RightRightTile is Wall) && !FindBlock(px, py+2))
                        {
                            MoveBlock(px, py + 1, 'r');
                            player.pos.y += 1;
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
                    if (Map[i,j] is Slot && !FindBlock(i, j))
                        return false;
                }
            }
            return true;
        }

        public Tile getTileByInt(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Row || y >= Col) return null;
            return Map[x,y];
        }

        public Tile getTileByVector(Vector2i v)
        {
            if (v.x < 0 || v.y < 0 || v.x >= Row || v.y >= Col) return null;
            return Map[v.x,v.y];
        }

        public void ScanMap(int row, int col, string[] mapdata)
        {
            this.Row = row;
            this.Col = col;
            Map = new Tile[row,col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < mapdata[i].Length; j++)
                {
                    char tile = mapdata[i][j];
                    if (tile == '#') Map[i, j] = new Wall();
                    else if (tile == ' ') Map[i, j] = new Floor();
                    else if (tile == '@')
                    {
                        Map[i, j] = new Floor();
                        player = new Player(i, j);
                    }
                    else if (tile == '$')
                    {
                        Map[i, j] = new Floor();
                        BlockList.Add(new Block(i, j));
                    }
                    else if (tile == '.') Map[i, j] = new Slot();
                    else if (tile == '*')
                    {
                        Map[i, j] = new Slot();
                        BlockList.Add(new Block(i, j));
                    }
                    else if (tile == 'p') {
                        Map[i, j] = new Slot();
                        player = new Player(i, j);
                    }
                }
            }

        }

        public bool FindBlock(int x, int y)
        {
            foreach (Block b in BlockList)
            {
                if (b.pos.x == x && b.pos.y == y) return true;
            }
            return false;
        }

        public void MoveBlock(int x, int y, char dir, int amount = 1)
        {
            foreach(Block b in BlockList)
            {
                if (b.pos.x==x && b.pos.y == y)
                {
                    if (dir == 'u')
                    {
                        b.pos.x -= amount;
                    }
                    else if (dir == 'd')
                    {
                        b.pos.x += amount;
                    }
                    else if (dir == 'l')
                    {
                        b.pos.y -= amount;
                    }
                    else if (dir == 'r')
                    {
                        b.pos.y += amount;
                    }
                }
            }
        }

        private bool FindPlayer(int x, int y) { return (player.pos.x == x && player.pos.y == y); }

        public void PrintMap()
        {
            Console.Clear();
            Console.WriteLine("SokobanGame! Level: {0}", Level);
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    if (Map[i,j] is Wall) Console.Write("#");
                    else if (Map[i,j] is Floor)
                    {
                        if (FindPlayer(i, j)) Console.Write("@");
                        else if (FindBlock(i, j)) Console.Write("$");
                        else Console.Write(" ");
                    }
                    else if (Map[i,j] is Slot)
                    {
                        if (FindPlayer(i, j)) Console.Write("@");
                        else if (FindBlock(i, j)) Console.Write("*");
                        else Console.Write(".");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("Turn Number: {0}", Turn);
        }

    }

   
}
