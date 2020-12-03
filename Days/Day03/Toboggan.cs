using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day03
{
    class Toboggan
    {
        public int xPos;
        public int yPos;
        public int xIncrement;
        public int yIncrement;
        

        public Toboggan(int x, int y, int incX, int incY)
        {
            xPos = x;
            yPos = y;
            xIncrement = incX;
            yIncrement = incY;

        }
        public int Travel(string[] map)
        {
            int treeHits = 0;
            int width = map[0].Length; //Lengte van de eerste rij
            int lenght = map.Length; //Lengte van de eerste kolom
            while(yPos < lenght)
            {
                if(map[yPos][xPos] == '#')
                {
                    treeHits += 1;
                    //Console.WriteLine($"Hit on xPos = {xPos}, yPos = {yPos}");
                }

                yPos += yIncrement;
                xPos += xIncrement;
                
                if(xPos > width -1)
                {
                    xPos = xPos - width;
                }
                //Console.WriteLine($"xPos = {xPos}, yPos = {yPos}");
            }
            return treeHits;
        }
    }
}
