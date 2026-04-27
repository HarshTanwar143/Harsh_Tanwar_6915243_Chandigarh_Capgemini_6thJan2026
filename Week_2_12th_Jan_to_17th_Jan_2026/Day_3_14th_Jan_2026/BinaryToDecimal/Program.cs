using System;

namespace BinaryToDecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the binary input :: ");
            string input1 = Console.ReadLine();
            int output;

            if (input1.Length > 5)
            {
                Console.WriteLine("-2");
                return;
            }

            for (int i = 0; i < input1.Length; i++)
            {
                if (input1[i] != '0' && input1[i] != '1')
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            int decimalValue = 0;
            int power = 1;

            for (int i = input1.Length - 1; i >= 0; i--)
            {
                if (input1[i] == '1')
                {
                    decimalValue += power;
                }

                power *= 2;
            }

            output = decimalValue;
            Console.Write("Corresponding decimal number :: ");
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
