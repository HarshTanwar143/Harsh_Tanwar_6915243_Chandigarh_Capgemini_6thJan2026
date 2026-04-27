namespace ArrayEvenOddAvg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int output1;

            Console.Write("Enter size of array: ");
            int size = int.Parse(Console.ReadLine());

            // if array size is negative
            if (size < 0)
            {
                output1 = -2;
                Console.WriteLine("Output1 = " + output1);
                return;
            }

            int[] arr = new int[size];
            int evenSum = 0, oddSum = 0;

            Console.WriteLine("Enter array elements:");
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

                // For negative element
                if (arr[i] < 0)
                {
                    output1 = -1;
                    Console.WriteLine("Output1 = " + output1);
                    return;
                }

                if (arr[i] % 2 == 0)
                    evenSum += arr[i];
                else
                    oddSum += arr[i];
            }

            output1 = (evenSum + oddSum) / 2;
            Console.WriteLine("Output1 = " + output1);
        }
    }
}
