using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day20
{
    class Extensions
    {
        public static List<string> monster = new List<string>() { "..................#.", "#....##....##....###", ".#..#..#..#..#..#..." };
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static int CountSeaMonsters(List<string> input)
        {
            var ans = 0;
            for (int c = 0; c < input[0].Count() - monster[0].Count(); c++)
                for (int r = 0; r < input.Count() - monster.Count(); r++)
                    if (HasMonster(input, r, c))
                    {
                        ans++;
                    }
            //Console.WriteLine(ans);
            return ans;
        }
        private static bool HasMonster(List<string> input, int r, int c)
        {
            //monster.ForEach(x => Console.WriteLine(x));
            for(int x = 0; x < monster[0].Count(); x++)
            {
                for (int y = 0; y < monster.Count(); y++)
                {
                    //Console.WriteLine(monster[y][x] +" "+ input[y + r][x + c]);
                    if(monster[y][x] == '#' && input[y+r][x+c] != '#')
                    {
                        //Console.WriteLine("Wrong");
                        return false;
                    }
                }
            }
            return true;

        }
    }
}
