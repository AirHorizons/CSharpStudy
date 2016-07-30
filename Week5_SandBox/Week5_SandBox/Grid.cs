using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_SandBox
{
    class Grid<T>
    {
        private T[,] data;
        public int Width { get; set; }
        public int Height { get; set; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            data = new T[width, height];
        }

        public Grid(int width, int height, T value) : this(width, height)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    data[i, j] = value;
                }
            }
        }

        public T GetValue(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                return data[x, y];
            else
            {
                Console.WriteLine("Index out of boundary!");
                return default(T);
            }                
        }
        public void SetValue(int x, int y, T value)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
                data[x, y] = value;
            else
            {
                Console.WriteLine("Index out of boundary!");
            }
        }
        public void SetItemsInRect(int xs, int ys, int xf, int yf, T value)
        {
            if (xs>=0 && xf<Width && ys>=0 && yf<Height)
            {
                for (int i = xs; i <= xf; i++)
                {
                    for (int j = ys; j <= yf; j++)
                    {
                        SetValue(i, j, value);
                    }
                }
            }
            else
            {
                Console.WriteLine("Index out of boundary!");
            }
        }
        public void Print()
        {
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    Console.Write(data[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
