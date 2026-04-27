using System;

namespace SumAndAvgMultiplesOf5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int size = int.Parse(Console.ReadLine());

            if (size < 0)
            {
                Console.WriteLine("-2");
                return;
            }

            int[] arr = new int[size];
            Console.WriteLine("Enter array elements:");

            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if (arr[i] < 0)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            int sum = 0;
            int count = 0;

            foreach (int x in arr)
            {
                if (x % 5 == 0)
                {
                    sum += x;
                    count++;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Sum = 0");
                Console.WriteLine("Average = 0");
            }
            else
            {
                double avg = (double)sum / count;
                Console.WriteLine("Sum = " + sum);
                Console.WriteLine("Average = " + avg);
            }
        }
    }
}
