namespace ShipStoryWithTwoArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the arrays:");
            int size = int.Parse(Console.ReadLine());

            if (size < 0)
            {
                int[] output1 = { -2 };
                Console.WriteLine("Output : " + output1[0]);
                return;
            }

            int[] input1 = new int[size];
            int[] input2 = new int[size];

            Console.WriteLine("Enter elements of first array:");
            for (int i = 0; i < size; i++)
            {
                input1[i] = int.Parse(Console.ReadLine());
                if (input1[i] < 0)
                {
                    int[] output1 = { -1 };
                    Console.WriteLine("Output:");
                    Console.WriteLine(output1[0]);
                    return;
                }
            }

            Console.WriteLine("Enter elements of second array:");
            for (int i = 0; i < size; i++)
            {
                input2[i] = int.Parse(Console.ReadLine());
                if (input2[i] < 0)
                {
                    int[] output1 = { -1 };
                    Console.WriteLine("Output:");
                    Console.WriteLine(output1[0]);
                    return;
                }
            }

            int[] output = new int[size];

            for (int i = 0; i < size; i++)
            {
                output[i] = input1[i] + input2[size - 1 - i];
            }

            Console.WriteLine("Output array:");
            for (int i = 0; i < size; i++)
            {
                Console.Write(output[i] + " ");
            }
        }
    }
}
