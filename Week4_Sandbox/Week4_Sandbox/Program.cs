using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> SketchBook = new List<Shape>();
            SketchBook.Add(new Circle(0, 0, 20));
            SketchBook.Add(new Rectangle(5, 5, 10, 15));
            SketchBook.Add(new Triangle(0, 0, 30, 30, 15));
            foreach(Shape s in SketchBook) { s.Draw(); }
            

        }

        public class Shape
        {
            public int X { get; private set; }
            public int Y { get; private set; }
            public int Height { get; private set; }
            public int Width { get; private set; }

            public Shape(int x, int y, int h, int w)
            {
                this.X = x;
                this.Y = y;
                this.Height = h;
                this.Width = w;
            }

            public virtual void Draw()
            {
                Console.WriteLine("\n그렸따리그렸따\n");
            }
        }

        public class Circle : Shape
        {
            public int Radius { get; private set; }
            public Circle(int x, int y, int r) : base(x, y, 2*r, 2*r) { this.Radius = r; }
            public override void Draw()
            {
                for (int i=0; i<Y; i++) { Console.WriteLine(); }
                for (int i=0; i<Height; i++)
                {
                    for (int j=0; j<X; j++) { Console.Write(" "); }
                    for (int j=0;j<Width; j++)
                    {
                        int a = Math.Abs(i - Radius);
                        int b = Math.Abs(j - Radius);
                        if (a * a + b * b <= Radius * Radius) Console.Write("*");
                        else Console.Write(" ");
                    }
                    Console.Write("\n");
                }
                base.Draw();
            }
        }

        public class Rectangle : Shape
        {
            public Rectangle(int x, int y, int h, int w) : base(x, y, h, w) { }
            public override void Draw()
            {
                for (int i = 0; i < Y; i++) { Console.WriteLine(); }
                for (int i = Height; i >= 1; i--)
                {
                    for (int j = 0; j < X; j++) { Console.Write(" "); }
                    for (int j = 0; j < Width; j++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("\n");
                }
                base.Draw();
            }
        }

        public class Triangle : Shape
        {
            public int A { get; private set; }
            public Triangle(int x, int y, int h, int w, int a) : base(x, y, h, w) { this.A = a; }
            public override void Draw()
            {
                for (int i = 0; i < Y; i++) { Console.WriteLine(); }
                for (int i = Height; i >= 1; i--)
                {
                    for (int j = 0; j < X; j++) { Console.Write(" "); }
                    for (int j = 0; j < Width; j++)
                    {
                        if (j >= (A * i) / Height && (j <= (i * (A - Width) / Height + Width)))
                            Console.Write("*");
                        else Console.Write(" ");
                    }
                    Console.Write("\n");
                }
                base.Draw();
            }
        }
    }
}
