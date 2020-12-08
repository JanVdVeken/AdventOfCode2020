using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Day08
{
    
    class HandheldConsole
    {
        Dictionary<int, int> executedInstructions;
        List<string> instructions;
        List<string> originalInput;
        int acc;

        public HandheldConsole(List<string> input)
        {
            executedInstructions = new Dictionary<int, int>();
            instructions = input;
            originalInput = input;

            acc = 0;
        }

        public void ExecuteInstructions()
        {
            for(int i = 0;i < instructions.Count();i++)
            {
                //First => Check if we already did this instruction
                if (executedInstructions.ContainsKey(i))
                {
                    Console.WriteLine($"At the start of the inifinite loop, we got {acc} in the accumulater");
                    break;
                }
                else
                {
                    executedInstructions.Add(i, 1);
                }

                //Second => Do instructions
                
                var temp = instructions[i].Split(" ");
                var instruction = temp[0];
                var value = temp[1];

                switch(instruction)
                {
                    case "acc":
                        acc += int.Parse(value);
                        break;
                    case "nop":
                        break;

                    case "jmp":
                        i += int.Parse(value) -1;
                        break;
                }
                
            }
        }

        public void ExecuteInstructionsWithoutCorrupt()
        {
            //trail and error originalInput
            for(int j = 0; j < originalInput.Count(); j++)
            {
                executedInstructions = new Dictionary<int, int>();
                instructions = new List<string>(originalInput);
                acc = 0;
                if(instructions[j].Contains("nop"))
                {
                    //Console.WriteLine($"Changed instruction on location {j} from nop to jmp");
                    instructions[j] = instructions[j].Replace("nop", "jmp");
                }
                else if(instructions[j].Contains("jmp"))
                {
                    //Console.WriteLine($"Changed instruction on location {j} from jpm to nop");
                    instructions[j] = instructions[j].Replace("jmp", "nop");
                }

                //Check for each list if this will work
                int i = 0;
                for (i = 0; i < instructions.Count(); i++)
                {
                    //Console.WriteLine($"Instruction: {instructions[i]}");
                    //First => Check if we already did this instruction
                    if (executedInstructions.ContainsKey(i))
                    {
                        break;
                    }
                    else
                    {
                        executedInstructions.Add(i, 1);
                    }

                    //Second => Do instructions

                    var temp = instructions[i].Split(" ");
                    var instruction = temp[0];
                    var value = temp[1];

                    switch (instruction)
                    {
                        case "acc":
                            acc += int.Parse(value);
                            break;
                        case "nop":
                            break;

                        case "jmp":
                            i += int.Parse(value) - 1;
                            break;
                    }
                }
                
                if(i == instructions.Count())
                { 
                    Console.WriteLine($"We got {acc} in the accumulator"); 
                }
                
            }
        }
    }


}
