using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiGame
{
    class Hanoi
    {
        private HanoiTower[] towers;
        public int NumOfDisks { get; private set; }
        public int Turns { get; private set; }
        public int TowerSelected { get; private set; }
        public Hanoi(int n)
        {
            this.NumOfDisks = n;
            if (NumOfDisks < 0) throw new WrongInputException("0 보다 작은 숫자는 입력할 수 없습니다.");
            towers = new HanoiTower[3];

            for (int i = 0; i < towers.Length; i++)
                towers[i] = new HanoiTower(NumOfDisks);
            towers[0].InsertAllDisks();
            towers[TowerSelected].Selected = true;
        }

        public void Run()
        {
            while(!(towers[0].Empty && towers[1].Empty))
            {
                SelectTower(); 
                MoveDisk();
                Turns += 1;
            }
            Console.Clear();
            Draw(false);
            Console.WriteLine("축하합니다! {0}회만에 원판을 모두 옮겼습니다!", Turns);
            if (Turns == Math.Pow(2, NumOfDisks) - 1) Console.WriteLine("최저 횟수로 옮기는 데 성공하였습니다!");
        }
        private void SelectTower()
        {
            ConsoleKeyInfo key;
            while (true)
            {
                Console.Clear();
                Draw(false);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow) { MoveCursorLeft(); }
                else if (key.Key == ConsoleKey.RightArrow) { MoveCursorRight(); }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (!towers[TowerSelected].Empty)
                        return;
                    else continue;
                }
            }            
        }
        private void MoveDisk()
        {
            ConsoleKeyInfo key;
            while (true)
            {
                Console.Clear();
                Draw(true);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (Moveable(false))
                        MoveDiskLeft();
                    else if (Moveable(true))
                        MoveDiskRight();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {   if (Moveable(true))
                        MoveDiskRight();
                    else if (Moveable(false))
                        MoveDiskLeft();
                }
                else if (key.Key == ConsoleKey.Enter) return;
            }
        }
        private bool Moveable(bool dir) // dir is false when moving disk left, true when right
        {
            int source = TowerSelected, dest;
            if (!dir)
            {
                dest = TowerSelected - 1;
                if (dest < 0) dest += 3;
            }
            else
            {
                dest = TowerSelected + 1;
                if (dest > 2) dest -= 3;
            }
            if (towers[dest].Empty) return true;
            else return towers[dest].PeekDisk() > towers[source].PeekDisk();
        }
        private void MoveCursorRight()
        {
            towers[TowerSelected].Selected = false;
            TowerSelected += 1;
            if (TowerSelected >= 3) TowerSelected -= 3;
            towers[TowerSelected].Selected = true;
        }
        private void MoveCursorLeft()
        {
            towers[TowerSelected].Selected = false;
            TowerSelected -= 1;
            if (TowerSelected < 0) TowerSelected += 3;
            towers[TowerSelected].Selected = true;
        }
        private void MoveDiskRight()
        {
            towers[TowerSelected].Selected = false;
            int disk = towers[TowerSelected].RemoveDisk();
            TowerSelected += 1;
            if (TowerSelected >= 3) TowerSelected -= 3;
            towers[TowerSelected].Selected = true;
            towers[TowerSelected].InsertDisk(disk);
        }
        private void MoveDiskLeft()
        {
            towers[TowerSelected].Selected = false;
            int disk = towers[TowerSelected].RemoveDisk();
            TowerSelected -= 1;
            if (TowerSelected < 0) TowerSelected += 3;
            towers[TowerSelected].Selected = true;
            towers[TowerSelected].InsertDisk(disk);
        }
        private void ExecuteTurn(int n, HanoiTower source, HanoiTower via, HanoiTower dest)
        {
            if (n == 1)
            {
                dest.InsertDisk(source.RemoveDisk());
                Draw(false);
                Turns += 1;
            }
            else
            {
                ExecuteTurn(n - 1, source, dest, via);
                dest.InsertDisk(source.RemoveDisk());
                Draw(false);
                Turns += 1;
                ExecuteTurn(n - 1, via, source, dest);
            }
        }
        public void Draw(bool mode) // mode is false when mode is select, true when move
        {
            string firstline = "";
            for (int j = 0; j < towers.Length; j++)
            {
                for (int i = 0; i < 2 * NumOfDisks + 1; i++) { 
                    if (i == NumOfDisks)
                    {
                        if (towers[j].Selected) {
                            if (!mode) firstline += "^";
                            else firstline += "v";                       
                        }
                        else firstline += " ";
                    }
                    else firstline += " ";
                }
                firstline += '\t';
            }
            Console.WriteLine(firstline);
            for (int i = NumOfDisks - 1; i >= 0; i--)
            {
                for (int j = 0; j < towers.Length; j++)
                {
                    Console.Write(DrawDisk(NumOfDisks, towers[j].Disks[i], mode, towers[j].Selected, i == towers[j].getheight()-1));
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
        private string DrawDisk(int n, int diskSize, bool mode, bool selected, bool top)
        {
            string str = "";
            for (int i = 0; i < 2 * n + 1; i++)
            {
                if (i == n) str += "|";
                else if (i < n - diskSize || i > n + diskSize) str += " ";
                else
                {
                    if (mode && selected && top) str += "o";
                    else str += "*";
                }
            }
            str += "\t";
            return str;
        }
    }
}
