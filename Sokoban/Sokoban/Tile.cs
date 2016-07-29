using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Tile
    {
        public bool onBox { get; set; }
        public bool onPlayer { get; set; }
        public Tile(bool b, bool p)
        {
            onBox = b;
            onPlayer = p;
        }
    }

    class Wall : Tile
    {
        public Wall(bool b, bool p) : base(b,p) { }
        public Wall() : base(false, false) { }
    }

    class Floor : Tile
    {
        public Floor(bool b, bool p) : base(b,p) { }
        public Floor() : base(false, false) { }
    }

    class Slot : Tile
    {
        public Slot(bool b, bool p): base(b, p) {  }
        public Slot() : base(false, false) { }
    }
}
