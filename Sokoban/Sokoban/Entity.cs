using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Entity
    {
        public Vector2i pos;
        public Entity(int x, int y) { this.pos.x = x; this.pos.y = y; }
    }

    struct Vector2i
    {
        public int x;
        public int y;
    }

    class Player : Entity
    {
        public Player(int x, int y) : base(x, y) { }
    }

    class Block : Entity
    {
        public Block(int x, int y) : base(x, y) { }
    }
}
