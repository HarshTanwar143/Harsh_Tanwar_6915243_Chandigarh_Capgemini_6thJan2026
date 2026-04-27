using System;

namespace MultiplyPositiveNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of array: ");
            int size = int.Parse(Console.ReadLine());

            int output;


            if (size < 0)
            {
                output = -2;
                Console.WriteLine("Output = " + output);
                return;
            }

            int[] arr = new int[size];
            output = 1;
            bool foundPositive = false;

            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

                if (arr[i] > 0)
                {
                    output *= arr[i];
                    foundPositive = true;
                }
            }

            // If no positive number exists
            if (!foundPositive)
            {
                output = 0;
            }

            Console.WriteLine("Output = " + output);
        }
    }
}
