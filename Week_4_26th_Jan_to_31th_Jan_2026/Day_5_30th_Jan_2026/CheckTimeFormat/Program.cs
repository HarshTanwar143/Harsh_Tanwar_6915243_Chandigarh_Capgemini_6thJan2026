using System.Text.RegularExpressions;

namespace CheckTimeFormat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter time (hh:mm am/pm):");
            string input = Console.ReadLine();

            string pattern = @"^(0[1-9]|1[0-2]):[0-5][0-9]\s(am|pm)$";
            Console.WriteLine("Output: " + (Regex.IsMatch(input, pattern) ? 1 : -1));
        }
    }
}


// testcase: 09:30 am ==> 1 , 10:61 am ==> -1