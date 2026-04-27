namespace ProductOfMaxAndMin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the array :: ");
            int size = int.Parse(Console.ReadLine());

            long output = 0;
            if(size < 0)
            {
                output = -2;
                Console.WriteLine("Ouput :: " + output);
                return;
            }

            Console.WriteLine("Enter the elements of the array :: ");
            int[] arr = new int[size];
            for(int i = 0;i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if (arr[i] < 0)
                {
                    output = -1;
                    Console.WriteLine("Output :: " + output);
                    return;
                }
            }

            int min = arr[0], max = arr[0];
            for(int i = 0;i < size; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            output = min * max;
            Console.WriteLine("Product of the min and max elements :: " + output);
            Console.ReadLine();
        }
    }
}
