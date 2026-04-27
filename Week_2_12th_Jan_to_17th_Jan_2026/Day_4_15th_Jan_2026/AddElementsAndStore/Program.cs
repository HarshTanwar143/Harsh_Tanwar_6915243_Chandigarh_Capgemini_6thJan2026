namespace AddElementsAndStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the array :: ");
            int input3 = int.Parse(Console.ReadLine());

            if(input3 < 0)
            {
                Console.WriteLine("Output :: -2");
                return;
            }

            int[] input1 = new int[input3];
            int[] input2 = new int[input3];

            Console.WriteLine("Enter the elements of array1 :: ");
            for(int i = 0;i < input3; i++)
            {
                input1[i] = int.Parse(Console.ReadLine());
                if (input1[i] < 0)
                {
                    Console.WriteLine("Output :: -1");
                    return;
                }
            }

            Console.WriteLine("Enter the elements of array2 :: ");
            for (int i = 0; i < input3; i++)
            {
                input2[i] = int.Parse(Console.ReadLine());
                if (input2[i] < 0)
                {
                    Console.WriteLine("Output :: -1");
                    return;
                }
            }

            int[] output = new int[input3];
            for(int i = 0;i < input3; i++)
            {
                output[i] = input1[i] + input2[input3 - i - 1];
            }
            Console.Write("Output :: ");
            foreach(int ele in output)
            {
                Console.Write(ele + " ");
            }
            Console.ReadLine();
        }
    }
}
