using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AddHundredDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigNumber number1, number2, numberResult;
            Write("Insert 1 to start the program, or something else to finish it: ");
            string input = Console.ReadLine();
            while(input == "1")
            {
                WriteLine("FIRST NUMBER");
                number1 = new BigNumber();
                WriteLine("SECOND NUMBER");
                number2 = new BigNumber();
                numberResult = new BigNumber(number1.AdditionWith(number2));

                WriteLine("ANSWER OF THE ADDITION: \n" + numberResult);

                number1 = null;
                number2 = null;
                numberResult = null;
                Write("Insert 1 to start the program, or something else to finish it: ");
                input = Console.ReadLine();
            }

            WriteLine("/////////////////////\nPROGRAM FINISHED");
            ReadKey();
        }
    }
}
