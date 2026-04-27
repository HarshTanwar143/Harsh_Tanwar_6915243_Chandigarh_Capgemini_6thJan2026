namespace NumberOfDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:: ");
            int input3 = int.Parse(Console.ReadLine());
            int output3;

            if (input3 < 0)
            {
                output3 = -1;
            }
            else
            {
                int count = 0;
                int temp = input3;
                while (temp > 0)
                {
                    count++;
                    temp /= 10;
                }
                output3 = count;
            }
            Console.WriteLine("Number of digits:: " + output3);
        }
    }
}
