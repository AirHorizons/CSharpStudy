using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid<int> g = new Grid<int>(7, 7, 1);
            g.SetItemsInRect(1, 1, 5, 5, 3);
            g.Print();
        }
    }
    
}
