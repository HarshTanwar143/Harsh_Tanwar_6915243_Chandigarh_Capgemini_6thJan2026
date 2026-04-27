using System.Text.RegularExpressions;

namespace AddingYearsToDate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter date (dd/MM/yyyy):");
            string input1 = Console.ReadLine();

            Console.WriteLine("Enter number of years:");
            int years = int.Parse(Console.ReadLine());

            string pattern = @"^\d{2}/\d{2}/\d{4}$";

            if (!Regex.IsMatch(input1, pattern))
            {
                Console.WriteLine("Output: -1");
                return;
            }

            if (years < 0)
            {
                Console.WriteLine("Output: -2");
                return;
            }

            DateTime dt = DateTime.ParseExact(input1, "dd/MM/yyyy", null);
            Console.WriteLine("Output: " + dt.AddYears(years).ToString("dd/MM/yyyy"));
        }
    }
}

// testcase : 20/03/2020 , 4 ==> 20/03/2024