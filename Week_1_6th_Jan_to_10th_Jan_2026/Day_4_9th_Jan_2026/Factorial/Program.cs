namespace Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the number :: ");
            int input1 = int.Parse(Console.ReadLine());
            int output1;

            if (input1 < 0)
            {
                output1 = -1;
            }
            else
            {
                if (input1 > 7)
                {
                    output1 = -2;
                }
                else
                {
                    int temp = input1;
                    int fact = 1;
                    while (temp > 0)
                    {
                        fact *= temp;
                        temp--;
                    }
                    output1 = fact;
                }
            }

            Console.WriteLine("factorial is " + output1);


        }
    }
}
