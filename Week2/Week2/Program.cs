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
                Hanoi hanoi = new Hanoi();
                hanoi.Run();
            }
            catch (WrongInputException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
