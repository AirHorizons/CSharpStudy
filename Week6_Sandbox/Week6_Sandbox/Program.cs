using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Sandbox
{
    class Program
    {
        public delegate int BinaryOperator(int a, int b);

        static void Main(string[] args)
        {
            /*
            BinaryOperator Add = (int a, int b) => a + b;
            BinaryOperator Subtract = (int a, int b) => a - b;
            BinaryOperator Multiply = (int a, int b) => a * b;

            Console.WriteLine(Calc(Add));
            Console.WriteLine(Calc(Subtract));
            Console.WriteLine(Calc(Multiply));
            Console.WriteLine();

            var Func_A = GetFunction('+');
            var Func_B = GetFunction('-');
            Console.WriteLine(Func_A(2, 3));
            Console.WriteLine(Func_B(10, 3));
            

            IEnumerable<int> numbers = Enumerable.Range(1, 100);
            List<int> Evens = numbers.Where(n => n % 2 == 0).ToList();
            Evens.ForEach(Console.WriteLine);
            int sum = Evens.Sum();
            Console.WriteLine("Sum: {0}", sum);
            

            var list = Enumerable.Range(1, 100).Select(i => Math.Pow(i, 2)).ToList();
            list.ForEach(Console.WriteLine);
            

            string[] array =
            {
                "I",
                "Love",
                "LINQ",
            };
            var result = array.SelectMany(element => element.ToCharArray());
            foreach (char letter in result)
                Console.WriteLine(letter);
            

            var array1 = new int[] { 1, 2, 3, 4, 5 };
            var array2 = new int[] { 6, 7, 8, 9, 10 };
            var zip = array1.Zip(array2, (int a, int b) => (a + b));
            foreach(int n in zip) { Console.WriteLine(n); }
            */

            int[] numbers = { 10, 15, 20, 25, 30, 35 };
            var result = numbers.GroupBy(n => (n % 10 == 0));
            Console.WriteLine("GroupBy has created two groups:");
            foreach (IGrouping<bool, int> group in result)
            {
                if (group.Key == true)
                    Console.WriteLine("Divisible by 10");
                else
                    Console.WriteLine("Not Divisible by 10");
                foreach (int number in group)
                    Console.WriteLine(number);
            }
        }
        /*
        public static int Calc(BinaryOperator func)
        {
            return func(10, 5); 
        }

        public static BinaryOperator GetFunction(char c)
        {
            switch (c)
            {
                case '+': return (int a, int b) => a + b;
                case '-': return (int a, int b) => a - b;
                case '*': return (int a, int b) => a * b;
                case '/': return (int a, int b) => a / b;
                default:
                    return (int a, int b) =>
                    {
                        throw new Exception("Cannot parse operator" + c.ToString());
                    };
            }
        }
        */
    }
}
