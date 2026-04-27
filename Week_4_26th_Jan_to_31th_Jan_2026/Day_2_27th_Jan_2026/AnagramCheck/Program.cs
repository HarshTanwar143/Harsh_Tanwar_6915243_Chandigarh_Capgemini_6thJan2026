namespace AnagramCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first string :: ");
            string s1 = Console.ReadLine();
            Console.Write("Enter second string :: ");
            string s2 = Console.ReadLine();

            if (s1.Length != s2.Length)
            {
                Console.WriteLine("Not Anagram");
                return;
            }

            Dictionary<char, int> freq = new Dictionary<char, int>();

            foreach (char c in s1)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }

            foreach (char c in s2)
            {
                if (!freq.ContainsKey(c))
                {
                    Console.WriteLine("Not Anagram");
                    return;
                }

                freq[c]--;
            }

            foreach (var val in freq.Values)
            {
                if (val != 0)
                {
                    Console.WriteLine("Not Anagram");
                    return;
                }
            }

            Console.WriteLine("Anagram");
        }
    }
}
