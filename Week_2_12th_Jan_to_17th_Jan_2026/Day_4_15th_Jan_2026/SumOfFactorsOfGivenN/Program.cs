using System;

namespace SumOfFactorsOfGivenN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of which factors you sum :: ");
            int input1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the limit :: ");
            int input2 = int.Parse(Console.ReadLine());

            int output;

            if (input1 < 0)
            {
                output = -1;
            }
            else if (input2 > 32627)
            {
                output = -2;
            }
            else
            {
                output = 0;
                for (int i = input1; i <= input2; i += input1)
                {
                    output += i;
                }
            }

            Console.WriteLine("sum of factors from a given number upto N :: " + output);
        }
    }
}
