namespace RemoveReapeatedElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array:: ");
            int size = int.Parse(Console.ReadLine());

            if (size <= 0)
            {
                Console.WriteLine("-2");
                return;
            }

            int[] input = new int[size];
            Console.WriteLine("Enter the elements:: ");

            for (int i = 0; i < size; i++)
            {
                input[i] = int.Parse(Console.ReadLine());
            }

            foreach (int ele in input)
            {
                if (ele < 0)
                {
                    int[] output = new int[1];
                    output[0] = -1;
                    Console.WriteLine(output[0]);
                    return;
                }
            }


            // 1112223345667
            Array.Sort(input);

            int[] outputArray = new int[size];
            int index = 0;

            outputArray[index++] = input[0];

            for (int i = 1; i < size; i++)
            {
                if (input[i] != input[i - 1])
                {
                    outputArray[index++] = input[i];
                }
            }

            Console.WriteLine("Array after removing repeated elements :: ");
            for (int i = 0; i < index; i++)
            {
                Console.Write(outputArray[i] + " ");
            }

            Console.ReadLine();
        }
    }
}
