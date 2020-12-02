using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Days.Day02
{
    class Password
    {
        int MinOccur;
        int MaxOccur;
        char Character;
        string StringToCheck;

        public Password(int min, int max, char checkCharacter, string inputSting)
        {
            MinOccur = min;
            MaxOccur = max;
            Character = checkCharacter;
            StringToCheck = inputSting;
        }

        public bool CheckPasswordRegex()
        {

            int counter = StringToCheck.Count(x => x == Character);
            return counter <= MaxOccur && counter >= MinOccur;
            //string Pattern = Character + "{" + MinOccur + "," + MaxOccur +"}";
            //Regex reg = new Regex(Pattern);
            //bool Output =  reg.IsMatch(StringToCheck)? true: false;
            //return Output;
        }
        public bool CheckPassWordNewPolicy()
        {
            bool FirstLocation = Character == StringToCheck[MinOccur-1];
            bool LastLocation = Character == StringToCheck[MaxOccur-1];
            return FirstLocation ^ LastLocation;
        }

    }
}
