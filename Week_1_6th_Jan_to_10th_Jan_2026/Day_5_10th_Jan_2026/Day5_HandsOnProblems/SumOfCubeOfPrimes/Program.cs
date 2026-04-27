namespace SumOfCubeOfPrimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter n value: ");
            int n = int.Parse(Console.ReadLine());

            int output;

            if (n < 0 || n > 7)
            {
                output = -1;
            }
            else
            {
                int sum = 0;

                for (int i = 2; i <= n; i++)
                {
                    bool isPrime = true;

                    for (int j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                        sum += i * i * i;
                }

                output = sum;
            }

            Console.WriteLine("Output = " + output);
        }
    }
}
