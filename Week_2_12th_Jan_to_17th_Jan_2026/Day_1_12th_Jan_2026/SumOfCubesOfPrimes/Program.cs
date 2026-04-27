namespace SumOfCubesOfPrimes
{
    internal class Program
    {
        static bool isPrime(int num)
        {
            for(int i = 2; i*i <= num; i++)
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
            Console.WriteLine("Enter a number:: ");
            int input = int.Parse(Console.ReadLine());


            long output = 0;
            if(input < 0)
            {
                output = -1;
            }
            else if(input > 32676)
            {
                output = -2;
            }
            else
            {
                int count = 0;
                int num = 2;
                while(count < input)
                {
                    if (isPrime(num))
                    {
                        output += (long)(num * num * num);
                        ++count;
                    }
                    ++num;
                }
            }

            Console.WriteLine("sum of cubes of prime for n natural numbers :: " + output);
            Console.ReadLine();
        }
    }
}

/*
23.     find sum of cubes of prime for n natural numbers
Business Rule:
Store -1 into the output variable if input value is negative number
Store -2 into the output variable if input value is exceeds 32676
*/