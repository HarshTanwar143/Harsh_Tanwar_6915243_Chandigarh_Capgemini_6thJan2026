using System;

namespace CompareArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of arrays: ");
            int size = int.Parse(Console.ReadLine());

            int[] output = new int[size];


            if (size < 0)
            {
                output[0] = -2;
                Console.WriteLine("Output: " + output[0]);
                return;
            }

            int[] arr1 = new int[size];
            int[] arr2 = new int[size];

            Console.WriteLine("Enter elements of first array:");
            for (int i = 0; i < size; i++)
            {
                arr1[i] = int.Parse(Console.ReadLine());
                if (arr1[i] < 0)
                {
                    output[0] = -1;
                    Console.WriteLine("Output: " + output[0]);
                    return;
                }
            }

            Console.WriteLine("Enter elements of second array:");
            for (int i = 0; i < size; i++)
            {
                arr2[i] = int.Parse(Console.ReadLine());
                if (arr2[i] < 0)
                {
                    output[0] = -1;
                    Console.WriteLine("Output: " + output[0]);
                    return;
                }
            }


            for (int i = 0; i < size; i++)
            {
                output[i] = (arr1[i] > arr2[i]) ? arr1[i] : arr2[i];
            }

            Console.WriteLine("Output Array:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(output[i] + " ");
            }
        }
    }
}
