using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day24
{
    class Hex
    {
        public int x;
        public int y;
        public int z;

        public Hex(int inputX, int inputY, int inputZ)
        {
            x = inputX;
            y = inputY;
            z = inputZ;
        }

        public bool AreTilesEqual(Hex Tile)
        {
            return (Tile.x == x && Tile.y == y && Tile.z == z);
        }

        public void PrintHex()
        {
            Console.WriteLine($"Tile at x: {x}, y: {y}, z: {z}");
        }
    }
}
