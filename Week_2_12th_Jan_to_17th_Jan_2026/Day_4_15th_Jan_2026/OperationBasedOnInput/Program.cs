namespace OperationBasedOnInput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter input1 :: ");
            int input1 = int.Parse(Console.ReadLine());
            Console.Write("Enter input2 :: ");
            int input2 = int.Parse(Console.ReadLine());
            Console.Write("Enter input3 :: ");
            int input3 = int.Parse(Console.ReadLine());

            int output;

            if (input1 < 0 && input2 < 0)
            {
                output = -1;
            }
            else
            {
                if (input3 == 1)
                    output = input1 + input2;
                else if (input3 == 2)
                    output = input1 - input2;
                else if (input3 == 3)
                    output = input1 * input2;
                else if (input3 == 4)
                    output = input1 / input2;
                else
                    output = 0;
            }

            Console.WriteLine("Final output :: " + output);
            Console.ReadLine();
        }
    }
}
