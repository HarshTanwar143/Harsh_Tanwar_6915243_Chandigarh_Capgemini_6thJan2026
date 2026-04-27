namespace SearchElement
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

            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());


                if (arr[i] < 0)
                {
                    output = -1;
                    Console.WriteLine("Output = " + output);
                    return;
                }
            }

            Console.Write("Enter element to search: ");
            int key = int.Parse(Console.ReadLine());

            output = 1; 

            for (int i = 0; i < size; i++)
            {
                if (arr[i] == key)
                {
                    output = i;
                    break;
                }
            }

            Console.WriteLine("Output = " + output);
        }
    }
}
