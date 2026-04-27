namespace SumOfPrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = { 1, 2, 3, 4, 5 };
            int input2 = 5;
            int output1;


            if (input2 < 0)
            {
                output1 = -2;
            }
            else
            {
                int sum = 0;
                bool hasPrime = false;

                for (int i = 0; i < input2; i++)
                {
                    if (input1[i] < 0)
                    {
                        output1 = -1;
                        Console.WriteLine("Output = " + output1);
                        return;
                    }

                    if (IsPrime(input1[i]))
                    {
                        sum += input1[i];
                        hasPrime = true;
                    }
                }

                if (!hasPrime)
                    output1 = -3;
                else
                    output1 = sum;
            }

            Console.WriteLine("Output = " + output1);
        }

        static bool IsPrime(int num)
        {
            if (num <= 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }
    }
}
