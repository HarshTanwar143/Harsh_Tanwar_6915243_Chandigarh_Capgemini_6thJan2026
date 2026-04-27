namespace LuckyDrawNumbers
{
    internal class Program
    {
        static int SumOfDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }

        static bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter two numbers :: ");
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int count = 0;

            for (int x = m; x <= n; x++)
            {
                if (!IsPrime(x))   
                {
                    int s = SumOfDigits(x);
                    int sSquare = SumOfDigits(x * x);

                    if (sSquare == s * s)
                        count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
