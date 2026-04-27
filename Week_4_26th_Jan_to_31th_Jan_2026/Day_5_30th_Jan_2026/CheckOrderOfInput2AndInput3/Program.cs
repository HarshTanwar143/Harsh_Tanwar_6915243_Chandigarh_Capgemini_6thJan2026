using System.Text.RegularExpressions;

namespace CheckOrderOfInput2AndInput3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter main string:");
            string input1 = Console.ReadLine();

            Console.WriteLine("Enter first word:");
            string input2 = Console.ReadLine();

            Console.WriteLine("Enter second word:");
            string input3 = Console.ReadLine();

            string pattern = input2 + ".*" + input3;
            Console.WriteLine("Output: " + Regex.IsMatch(input1, pattern));
        }
    }
}


// testcase :: todayisc#exam  is  exam  ==> true