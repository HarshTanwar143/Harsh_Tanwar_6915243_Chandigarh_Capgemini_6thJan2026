using System.Text.RegularExpressions;

namespace RemoveRepeatedCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string:");
            string input = Console.ReadLine();

            string result = Regex.Replace(input, @"(.)(?=.*\1)", "");
            Console.WriteLine("Output: " + result);
        }
    }
}

// testcase : programming ==> poraming