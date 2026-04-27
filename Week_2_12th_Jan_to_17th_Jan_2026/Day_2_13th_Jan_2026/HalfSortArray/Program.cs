using System;

namespace HalfSortArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int size = int.Parse(Console.ReadLine());

            if (size < 0)
            {
                int[] output = new int[1];
                output[0] = -1;
                Console.WriteLine(output[0]);
                return;
            }

            int[] arr = new int[size];
            Console.WriteLine("Enter elements:");

            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(arr);

            int mid = size / 2;
            int start = mid, end = size - 1;

            while(start < end)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end--;
            }

            Console.WriteLine("Output:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
