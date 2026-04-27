using System.Text.RegularExpressions;

namespace VoteEligibilityOfPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter age:");
            string input = Console.ReadLine();

            if (!Regex.IsMatch(input, @"^\d+$"))
            {
                Console.WriteLine("Output: -1");
                return;
            }

            int age = int.Parse(input);
            Console.WriteLine("Output: " + (age >= 18 ? 1 : -1));
        }
    }
}

// testcase : 18 ==> 1 , 17 ==> -1