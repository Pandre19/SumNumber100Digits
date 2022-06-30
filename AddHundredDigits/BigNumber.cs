using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AddHundredDigits
{
    internal class BigNumber
    {
        private string bigNumber;
        private char[] bigNumberArray;
        private int bigNumberLength;

        public BigNumber()
        {
            //Aqui poner GetNumber
            this.bigNumber = GetNumber();
            this.bigNumberArray = bigNumber.ToCharArray();
            this.bigNumberLength = this.bigNumber.Length;
        }

        public BigNumber(char[] bigNumberArray)
        {
            this.bigNumberArray = bigNumberArray;
            this.bigNumber = new string(bigNumberArray).TrimStart('0');
            this.bigNumberLength = this.bigNumber.Length;
        }

        private string GetNumber()
        {
            string input;
            Write("Insert a number between 1 and 100 digits: ");
            input = ReadLine().TrimStart(' ').TrimEnd(' ');
            //WriteLine(input.Length);
            while(input.Length < 1 | input.Length > 100)
            {
                Write("REMEMBER it must be a number between 1 and 100 digits: ");
                input = ReadLine().TrimStart(' ').TrimEnd(' ');
                WriteLine(input.Length);
            }
            return input;
        }

        private char[] GetAnswerAddition(char[] longerArray, char[] shorterArray)
        {
            char[] respond;

            int respondLength = longerArray.Length + 1;
            //WriteLine("respondLength: "+ respondLength);
            int minLength = shorterArray.Length;
            int currentIndexAnswer, valueOne, valueTwo, valueCurrent, valueAnswer;
            char lastOperationValue;
            respond = new char[respondLength];
            respond[respond.Length - 1] = '0';
            for (int i = 0; i < respondLength-1; i++)
            {
                currentIndexAnswer = (respondLength - 1) - i;
                //WriteLine("current index: " + currentIndexAnswer);
                //respond[currentIndexAnswer] = '0';
                lastOperationValue = '0';
                if (i >= minLength)
                {
                    //WriteLine("FIRST SECTION");
                    valueOne = int.Parse(new string(longerArray[longerArray.Length - 1 -i], 1));
                    valueCurrent = int.Parse(new string(respond[currentIndexAnswer], 1));
                    valueAnswer = valueOne + valueCurrent;
                    if (valueAnswer >= 10)
                    {
                        valueAnswer = valueAnswer - 10;
                        lastOperationValue = '1';
                    }
                    respond[currentIndexAnswer] = char.Parse(valueAnswer.ToString());
                }
                else
                {
                    //WriteLine("SECOND SECTION");
                    valueOne = int.Parse(new string(longerArray[longerArray.Length - 1 - i], 1));
                    //WriteLine("VALUE ONE: " + valueOne);
                    valueTwo = int.Parse(new string(shorterArray[shorterArray.Length -1 - i], 1));
                    //WriteLine("VALUE TWO: " + valueTwo);
                    valueCurrent = int.Parse(new string(respond[currentIndexAnswer], 1));
                    //WriteLine("VALUE CURRENT: " + valueCurrent);
                    valueAnswer = valueOne + valueTwo + valueCurrent;
                    //WriteLine("VALUE Answer: " + valueAnswer);
                    if (valueAnswer >= 10)
                    {
                        valueAnswer = valueAnswer - 10;
                        lastOperationValue = '1';
                    }
                    respond[currentIndexAnswer] = char.Parse(valueAnswer.ToString());
                    //WriteLine("VALUE RESPOND: " + (char)valueAnswer);
                }
                if ((currentIndexAnswer - 1) >= 0)
                {
                    //WriteLine("TUKI");
                    respond[currentIndexAnswer - 1] = lastOperationValue;
                }
                //riteLine("Cifra: " + respond[currentIndexAnswer]);
            }
            return respond;
        }

        public char[] AdditionWith(BigNumber secondNumber)
        {
            char[] answer;
            
            if(this.BigNumberLength >= secondNumber.BigNumberLength)
            {
                //WriteLine("Mayor");
                answer = GetAnswerAddition(this.BigNumberArray, secondNumber.BigNumberArray);
            } else
            {
                answer = GetAnswerAddition(secondNumber.BigNumberArray, this.BigNumberArray);
            }
           
            return answer;
        }

        public override string ToString()
        {
            return "The value of the number is: "+ this.bigNumber;
        }

        public int BigNumberLength
        {
            get { return bigNumberLength; }
        }

        public char[] BigNumberArray
        {
            get { return bigNumberArray; }
        }
    }
}
