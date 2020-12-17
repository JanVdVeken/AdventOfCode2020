using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day17
{
    class Cube
    {
        public int x;
        public int y;
        public int z;
        public int w;
        public char value;

        public Cube(int inputX, int inputY, int inputZ, char inputValue)
        {
            x = inputX;
            y = inputY;
            z = inputZ;
            value = inputValue;
        }
        public Cube(int inputX, int inputY, int inputZ, int inputW, char inputValue)
        {
            x = inputX;
            y = inputY;
            z = inputZ;
            w = inputW;
            value = inputValue;
        }

        public bool checkIfPointsAreTheSame(int inputX, int inputY, int inputZ)
        {
            return (x == inputX && y == inputY && z == inputZ);
        }
        public bool checkIfPointsAreTheSame(int inputX, int inputY, int inputZ, int inputW)
        {
            return (x == inputX && y == inputY && z == inputZ && w == inputW);
        }

        public void printCubeProps()
        {
            Console.WriteLine($"X= {x}, Y= {y}, Z= {z}, W= {w},Value= {value} ");
        }
    }
}
