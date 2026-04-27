using System.Text.RegularExpressions;

namespace ValidatePassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter password:");
            string input = Console.ReadLine();

            string pattern = @"^(?=[A-Za-z])(?=.*[@#_])(?=.*[A-Za-z])(?=.*\d)[A-Za-z0-9@#_]{7,}[A-Za-z0-9]$";
            Console.WriteLine("Output: " + (Regex.IsMatch(input, pattern) ? 1 : -1));
        }
    }
}


/*
First char must be letter
Last char not special
Must contain @ or # or _
Must contain letter
Must contain digit
Length ≥ 8

testcase : ashok_23 ==> 1 , ashok@ ==> -1
 */