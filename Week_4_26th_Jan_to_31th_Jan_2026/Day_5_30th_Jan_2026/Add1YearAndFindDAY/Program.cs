using System.Text.RegularExpressions;

namespace Add1YearAndFindDAY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter date (dd/MM/yyyy):");
            string input = Console.ReadLine();

            string pattern = @"^\d{2}/\d{2}/\d{4}$";

            if (!Regex.IsMatch(input, pattern))
            {
                Console.WriteLine("Output: -1");
                return;
            }

            DateTime dt = DateTime.ParseExact(input, "dd/MM/yyyy", null);
            Console.WriteLine("Output: " + dt.AddYears(1).DayOfWeek);
        }
    }
}

// testcase :: 01/01/2020 ==> Friday
