namespace RemoveDuplicatesFromArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int input2 = int.Parse(Console.ReadLine());


            if (input2 < 0)
            {
                int[] output = { -2 };
                PrintArray(output);
                return;
            }

            int[] input1 = new int[input2];

            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < input2; i++)
            {
                input1[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < input2; i++)
            {
                if (input1[i] < 0)
                {
                    int[] output = { -1 };
                    PrintArray(output);
                    return;
                }
            }

            // Sorting the array
            Array.Sort(input1);

            // two pointers
            int[] outputArr = new int[input2];
            int j = 0;
            outputArr[j] = input1[0];

            for (int i = 1; i < input2; i++)
            {
                if (input1[i] != input1[i - 1])
                {
                    j++;
                    outputArr[j] = input1[i];
                }
            }

            PrintArray(outputArr);
            Console.ReadLine();
        }

        static void PrintArray(int[] arr)
        {
            Console.Write("Output = { ");
            for(int i = 0;i < arr.Length;i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("}");
        }
    }
}
