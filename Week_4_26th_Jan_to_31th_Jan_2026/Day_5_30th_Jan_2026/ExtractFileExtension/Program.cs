using System.Text.RegularExpressions;

namespace ExtractFileExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file name:");
            string input = Console.ReadLine();

            Match m = Regex.Match(input, @"\.([a-zA-Z0-9]+)$");
            Console.WriteLine("Output: " + (m.Success ? m.Groups[1].Value : "-1"));
        }
    }
}


// testcase : image.png ==> png , myfile ==> -1