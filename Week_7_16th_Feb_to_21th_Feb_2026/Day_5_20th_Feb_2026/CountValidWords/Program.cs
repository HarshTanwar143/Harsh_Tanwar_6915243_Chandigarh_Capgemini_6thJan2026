namespace CountValidWords
{
    internal class Program
    {
        static int CountValidWords(string input)
        {
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = 0;

            foreach (string word in words)
                if (IsValid(word)) count++;

            return count;
        }

        static bool IsValid(string word)
        {
            if (word.Length <= 2) return false;

            bool hasVowel = false, hasConsonant = false;

            foreach (char c in word)
            {
                if (!char.IsLetterOrDigit(c)) return false;

                if (char.IsLetter(c))
                {
                    char lower = char.ToLower(c);
                    if ("aeiou".Contains(lower)) hasVowel = true;
                    else hasConsonant = true;
                }
            }

            return hasVowel && hasConsonant;
        }

        static void Main()
        {
            string input = "cat dog a1b2 xy z apple bcd123";
            Console.WriteLine(CountValidWords(input));
        }
    }
}
