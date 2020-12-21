using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day20
{
    class Tile
    {
        private List<String> tileLines;
        public Tile()
        {
            tileLines = new List<string>();
        }

        public void FlipLR()
        {
            List<String> tileLinesNew = new List<string>();
            tileLines.ForEach(x => tileLinesNew.Add(Extensions.Reverse(x)));
            tileLines = tileLinesNew;
        }
        public void FlipUD()
        {
           tileLines.Reverse();
        }

        public void RotateR(int times)
        {
            for(int i = 0; i < times; i++)
            {
                List<String> tileLinesNew = new List<string>();
                foreach (string line in tileLines)
                {
                    for(int j = 0; j < line.Length; j++)
                    {
                        if (tileLinesNew.Count <= j)
                        {
                            tileLinesNew.Add(line[j].ToString());
                        }
                        else
                        {
                            tileLinesNew[j] = line[j] + tileLinesNew[j];
                        }
                        
                    }
                }
                tileLines = tileLinesNew;
            }
        }
        public void AddToList(string line)
        {
            tileLines.Add(line);
        }

        public void PrintTile()
        {
            tileLines.ForEach(x => Console.WriteLine(x));
        }
    }
}
