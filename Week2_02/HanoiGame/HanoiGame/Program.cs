using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(@"하노이 탑 게임입니다.
엔터 키로 원판을 고르거나 내려놓고, 좌우 방향키로 원판을 옮깁니다.
");
                while (true)
                {                   
                    Console.Write("원판의 개수를 입력하세요(0이면 종료): ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n == 0) return;
                    Hanoi hanoi = new Hanoi(n);
                    hanoi.Run();
                    //Console.Clear();
                }
            }
            catch (WrongInputException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
