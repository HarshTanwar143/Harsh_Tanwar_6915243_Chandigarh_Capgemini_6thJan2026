namespace SumOfCubeOfPrimesUptoLimit
{
    internal class Program
    {
        static bool isPrime(int num)
        {
            for(int i = 2;i <= Math.Sqrt(num); i++)
            {
                if(num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter limit: ");
            int n = int.Parse(Console.ReadLine());

            if (n < 0)
            {
                Console.WriteLine(-1);
                return;
            }

            if (n > 32767)
            {
                Console.WriteLine(-2);
                return;
            }

            long sum = 0;

            for (int i = 2; i <= n; i++)
            {
                if (isPrime(i))
                {
                    sum += (long)i * i * i;
                }
            }

            Console.WriteLine("sum of cubes of number present upto limit :: " + sum);
        }
    }
}
