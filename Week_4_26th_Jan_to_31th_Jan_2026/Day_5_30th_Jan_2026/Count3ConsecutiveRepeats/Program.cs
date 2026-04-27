using System.Text.RegularExpressions;

namespace Count3ConsecutiveRepeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string:");
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, @"(.)\1\1+");
            Console.WriteLine("Output: " + matches.Count);
        }
    }
}
