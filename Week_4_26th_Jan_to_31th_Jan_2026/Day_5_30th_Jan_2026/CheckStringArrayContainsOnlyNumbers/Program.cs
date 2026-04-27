using System.Text.RegularExpressions;

namespace CheckStringArrayContainsOnlyNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter values separated by comma:");
            string input = Console.ReadLine();

            string[] arr = input.Split(',');
            foreach (string s in arr)
            {
                if (!Regex.IsMatch(s.Trim(), @"^\d+(\.\d+)?$"))
                {
                    Console.WriteLine("Output: -1");
                    return;
                }
            }
            Console.WriteLine("Output: 1");
        }
    }
}

// testcase : 33,43,55 ==> 1 , 3,d ==> -1