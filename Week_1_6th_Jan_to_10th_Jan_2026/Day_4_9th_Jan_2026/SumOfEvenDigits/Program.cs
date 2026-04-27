namespace SumOfEvenDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            int output = 0;


            if (number < 0)
            {
                output = -1;
                Console.WriteLine("Output = " + output);
                return;
            }


            if (number > 32767)
            {
                output = -2;
                Console.WriteLine("Output = " + output);
                return;
            }

            while (number > 0)
            {
                int digit = number % 10;

                if (digit % 2 == 0)
                {
                    output += digit;
                }

                number /= 10;
            }

            Console.WriteLine("Output = " + output);
        }
    }
}
