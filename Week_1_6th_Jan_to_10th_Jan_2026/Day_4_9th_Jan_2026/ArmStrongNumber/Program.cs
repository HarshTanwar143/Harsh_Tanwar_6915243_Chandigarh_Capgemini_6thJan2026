namespace ArmStrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int input;
            Console.Write("Enter the number for armstrong :: ");
            input = int.Parse(Console.ReadLine());
            int output1;

            if (input < 0)
            {
                output1 = -1;
            }
            else
            {
                if (input / 1000 > 0)     // If input has more than 3 digits it will store -2
                {
                    output1 = -2;
                }
                else
                {
                    int num = input;
                    int sum = 0;
                    while (num > 0)
                    {
                        int digit = num % 10;
                        sum += (digit * digit * digit);
                        num /= 10;
                    }

                    if (sum == input)
                    {
                        output1 = 1;
                    }
                    else
                    {
                        output1 = 0;
                    }
                }
            }
            Console.WriteLine("Output is " + output1);

        }
    }
}
