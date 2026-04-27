namespace AvgOfMulOf5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number :: ");
            int input1 = int.Parse(Console.ReadLine());

            double output = 0;
            if (input1 < 0)
            {
                output = -1;
            }
            else if (input1 > 500)
            {
                output = -2;
            }
            else
            {
                int sum = 0;
                int i = 1;
                while (i * 5 <= input1)
                {
                    sum += (i * 5);
                    ++i;
                }
                output = (double)sum / (i - 1);
            }

            Console.WriteLine("Average of multiples of 5 :: " + output);
            Console.ReadLine();
        }
    }
}


/*
 * 3.    Find the average of multiples of five up to N natural number. Consider input1 is the N value.

Eg:
	Input1= 15
	Output1=10

Business Rules:
i)	If the input1 is negative store -1 in to the output variable.
ii)	If input1 is greater than 500 store -2 in to the output variable
*/
