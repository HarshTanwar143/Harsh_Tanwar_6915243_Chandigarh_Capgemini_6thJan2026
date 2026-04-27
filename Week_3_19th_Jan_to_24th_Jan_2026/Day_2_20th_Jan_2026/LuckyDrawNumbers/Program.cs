namespace LuckyDrawNumbers
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers :: ");
            int input1 = int.Parse(Console.ReadLine());
            int input2 = int.Parse(Console.ReadLine());

            int count = 0;

            for (int x = input1; x <= input2; x++)
            {
                if (!LuckyNumberFunctionality.IsPrime(x))
                {
                    int s = LuckyNumberFunctionality.SumOfDigits(x);
                    int sSquare = LuckyNumberFunctionality.SumOfDigits(x * x);

                    if (sSquare == s * s)
                        count++;
                }
            }

            Console.WriteLine("count :: " + count);
        }
    }
}
