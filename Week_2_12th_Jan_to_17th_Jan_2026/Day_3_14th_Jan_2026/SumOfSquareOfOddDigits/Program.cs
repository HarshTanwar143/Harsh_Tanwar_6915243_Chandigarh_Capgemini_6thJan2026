namespace SumOfSquareOfOddDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number :: ");
            int input1 = int.Parse(Console.ReadLine());

            long output = 0;
            if(input1 < 0)
            {
                output = -1;
            }
            else
            {
                int temp = input1;
                while(temp > 0)
                {
                    int digit = temp % 10;
                    if(digit % 2 != 0)
                    {
                        output += (long)(digit * digit);
                    }
                    temp /= 10;
                }
            }

            Console.Write("Sum of squares of odd digits in this number :: " + output);
            Console.ReadLine();
        }
    }
}

/*
 * 2.sum of squres of odd digits in a number. 
Business Rule:if input1< 0, store -1 into the output variable
eg = 345 gives 34 as output
*/