using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true) { 
                    Console.Write("원판의 개수를 입력하세요(0이면 종료): ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n == 0) return;
                    Hanoi hanoi = new Hanoi(n);
                    hanoi.Run();
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
