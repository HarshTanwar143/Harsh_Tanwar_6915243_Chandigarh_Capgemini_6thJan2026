namespace ReplaceString
{
    internal class Program
    {
        static string replaceString(string input1, int input2, char input3)
        {
            foreach (char c in input1)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return "-1";
            }

            if (input2 <= 0)
                return "-2";

            if (char.IsLetterOrDigit(input3))
                return "-3";

            string[] words = input1.Split(' ');

            words[input2 - 1] = new string(input3, words[input2 - 1].Length);

            return string.Join(" ", words).ToLower();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the string: ");
            string str = Console.ReadLine();

            Console.Write("Enter word number: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter special character: ");
            char ch = Console.ReadLine()[0];

            string result = replaceString(str, n, ch);

            Console.WriteLine("Output:");

            if (result == "-1")
                Console.WriteLine("Invalid String");
            else if (result == "-2")
                Console.WriteLine("Number not positive");
            else if (result == "-3")
                Console.WriteLine("Character not a special character");
            else
                Console.WriteLine(result);
        }
    }
}
