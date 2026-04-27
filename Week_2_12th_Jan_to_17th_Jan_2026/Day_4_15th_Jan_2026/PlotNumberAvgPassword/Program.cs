namespace PlotNumberAvgPassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of plot :: ");
            int size = int.Parse(Console.ReadLine());

            if (size < 0)
            {
                Console.WriteLine(-2);
                return;
            }

            int[] input = new int[size];
            int sumOdd = 0;
            int sumEven = 0;

            for (int i = 0; i < size; i++)
            {
                input[i] = int.Parse(Console.ReadLine());

                if (input[i] < 0)
                {
                    Console.WriteLine(-1);
                    return;
                }

                if (input[i] % 2 == 0)
                {
                    sumEven += input[i];
                }
                else
                {
                    sumOdd += input[i];
                }
            }

            int output1 = (sumOdd + sumEven) / 2;
            Console.WriteLine("Password as average of odd and even plot sum :: " + output1);
        }
    }
}
