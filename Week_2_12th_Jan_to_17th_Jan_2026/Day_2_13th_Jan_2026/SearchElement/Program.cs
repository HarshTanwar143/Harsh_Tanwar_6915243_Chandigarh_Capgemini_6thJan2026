using System;

namespace SearchElementBR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int size = int.Parse(Console.ReadLine());

            if (size < 0)
            {
                Console.WriteLine(-2);
                return;
            }

            int[] arr = new int[size];
            Console.WriteLine("Enter elements:");

            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                
            }

            foreach(int ele in arr)
            {
                if(ele < 0)
                {
                    Console.WriteLine("you entered a negative number "+ -1);
                    return;
                }
            }

            Console.Write("Enter element to search: ");
            int key = int.Parse(Console.ReadLine());

            for (int i = 0; i < size; i++)
            {
                if (arr[i] == key)
                {
                    Console.WriteLine(1);
                    return;
                }
            }

            Console.WriteLine(-3);
        }
    }
}
