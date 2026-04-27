namespace FindOutSalary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the salary :: ");
            int input1 = int.Parse(Console.ReadLine());
            Console.Write("Enter the days :: ");
            int input2 = int.Parse(Console.ReadLine());

            int output;

            if (input1 > 9000)
            {
                output = -1;
            }
            else if (input1 < 0)
            {
                output = -2;
            }
            else if (input2 < 0)
            {
                output = -4;
            }
            else
            {
                int food = input1 * 50 / 100;
                int travel = input1 * 20 / 100;
                int savings = input1 - (food + travel);

                if (input2 >= 31)
                {
                    int bonus = input2 / 31;
                    savings += (500 * bonus);
                }

                output = savings;
            }

            Console.WriteLine("Total savings :: " + output);
            Console.ReadLine();
        }
    }
}
