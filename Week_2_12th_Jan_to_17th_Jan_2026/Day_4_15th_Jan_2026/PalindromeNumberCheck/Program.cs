namespace PalindromeNumberCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number:");
            int input1 = int.Parse(Console.ReadLine());

            int output;

            if (input1 < 0)
            {
                output = -1;
            }
            else
            {
                // 123
                int original = input1;
                int reverse = 0;

                while (input1 > 0)
                {
                    reverse = reverse * 10 + (input1 % 10);
                    input1 /= 10;
                }

                if (original == reverse)
                {
                    output = 1;
                }
                else
                {
                    output = -2;
                }
            }

            Console.WriteLine("Output : " + output);
        }
    }
}
