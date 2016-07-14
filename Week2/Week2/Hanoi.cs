using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Hanoi
    {
        private HanoiTower[] towers;
        public int NumOfDisks { get; private set; }
        public int Turns { get; private set; }
        public Hanoi()
        {
            Console.Write("원판의 개수를 입력하세요: ");
            this.NumOfDisks = Convert.ToInt32(Console.ReadLine());
            if (NumOfDisks <= 0) throw new WrongInputException("0 이하의 숫자는 입력할 수 없습니다.");
            towers = new HanoiTower[3];

            for (int i=0; i<towers.Length; i++)
                towers[i] = new HanoiTower(NumOfDisks);
            towers[0].InsertAllDisks();
        }

        public void Run()
        {
            Draw();
            ExecuteTurn(NumOfDisks, towers[0], towers[1], towers[2]);
            Console.WriteLine("총 {0}회의 이동으로 옮겼습니다.", Turns);
        }
        private void ExecuteTurn(int n, HanoiTower source, HanoiTower via, HanoiTower dest)
        {
            if (n==1)
            {
                dest.InsertDisk(source.RemoveDisk());
                Draw();
                Turns += 1;
            }
            else
            {
                ExecuteTurn(n - 1, source, dest, via);
                dest.InsertDisk(source.RemoveDisk());
                Draw();
                Turns += 1;
                ExecuteTurn(n - 1, via, source, dest);
            }
        }
        public void Draw()
        {
            for (int i = NumOfDisks-1; i >= 0; i--)
            {
                for (int j = 0; j < towers.Length; j++)
                {
                    Console.Write(DrawDisk(NumOfDisks, towers[j].Disks[i]));
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
        private string DrawDisk(int n, int diskSize)
        {
            string str = "";
            for (int i=0; i<2*n+1; i++)
            {
                if (i == n) str += "|";
                else if (i < n - diskSize || i > n + diskSize) str += " ";
                else str += "*"; 
            }
            str += "\t";
            return str;
        }
    }
}
