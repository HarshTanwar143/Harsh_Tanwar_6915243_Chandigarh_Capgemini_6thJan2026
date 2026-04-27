namespace LeapYearCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the year:");
            int input1 = int.Parse(Console.ReadLine());

            int output1;

            if (input1 < 0)
            {
                output1 = -1;
            }
            else
            {
                if ((input1 % 4 == 0 && input1 % 100 != 0) || (input1 % 400 == 0))
                {
                    output1 = 1;
                }
                else
                {
                    output1 = 0;
                }
            }

            Console.WriteLine("Output : " + output1);
        }
    }
}
