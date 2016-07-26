using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{
    class Vector2i
    {
        private int x { get; set; }
        private int y { get; set; }

        public Vector2i() : this(0, 0) { }
        public Vector2i(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2i Add(Vector2i other)
        {
            return new Vector2i(x + other.x, y + other.y);
        }
    }
}
