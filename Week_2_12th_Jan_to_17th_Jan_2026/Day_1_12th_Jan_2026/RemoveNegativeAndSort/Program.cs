namespace RemoveNegativeAndSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array size:");
            int size = int.Parse(Console.ReadLine());

            if (size < 0)
            {
                Console.WriteLine("-1");
                return;
            }

            int[] input = new int[size];
            Console.WriteLine("Enter array elements:");

            int count = 0;
            for (int i = 0; i < size; i++)
            {
                input[i] = int.Parse(Console.ReadLine());
                if (input[i] >= 0)
                {
                    count++;
                }
            }

            int[] output = new int[count];
            int index = 0;

            for (int i = 0; i < size; i++)
            {
                if (input[i] >= 0)
                {
                    output[index++] = input[i];
                }
            }

            Array.Sort(output);

            Console.WriteLine("Output array:");
            for (int i = 0; i < output.Length; i++)
            {
                Console.Write(output[i] + " ");
            }

            Console.ReadLine();
        }
    }
}
