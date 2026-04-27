using System.ComponentModel;

namespace AvgDivBy5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number :: ");
            int input1 = int.Parse(Console.ReadLine());

            double output = 0;
            if(input1 < 0)
            {
                output = -1;
            }
            else
            {
                int count = 0;
                int sum = 0;
                for(int i = 1;i <= input1; i++)
                {
                    if(i % 5 == 0)
                    {
                        ++count;
                        sum += i;
                    }
                }
                output = (double)sum / count;
            }

            Console.WriteLine("Average of the numbers divisible by 5 upto limit :: " + output);
        }
    }
}

/*
 * 1.average of the numbers divisible by 5 upto a limit.
Business Rule:if input1< 0, store -1 into the output variable
 * */