namespace SalarySavedStory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter salary:");
            int input1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of working days:");
            int input2 = int.Parse(Console.ReadLine());

            int output;

            if (input1 > 9000)
            {
                output = -1;
            }
            else if (input1 < 0)
            {
                output = -3;
            }
            else if (input2 < 0)
            {
                output = -4;
            }
            else
            {
                int totalSalary = input1;

                if (input2 >= 31)
                {
                    int bonus = input2 / 31;
                    totalSalary += (500 * bonus);
                }

                int foodExpense = (totalSalary * 50) / 100;
                int travelExpense = (totalSalary * 20) / 100;

                output = totalSalary - (foodExpense + travelExpense);
            }

            Console.WriteLine("Total saved amount : " + output);
        }
    }
}
