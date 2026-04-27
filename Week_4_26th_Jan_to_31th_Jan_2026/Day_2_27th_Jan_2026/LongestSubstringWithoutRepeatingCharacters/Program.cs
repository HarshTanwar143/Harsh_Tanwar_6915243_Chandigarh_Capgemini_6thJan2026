namespace LongestSubstringWithoutRepeatingCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ente the string :: ");
            string s = Console.ReadLine();
            Dictionary<char, int> map = new Dictionary<char, int>();

            int left = 0, maxLen = 0;

            for (int right = 0; right < s.Length; right++)
            {
                if (map.ContainsKey(s[right]) && map[s[right]] >= left)
                {
                    left = map[s[right]] + 1;
                }

                map[s[right]] = right;
                maxLen = Math.Max(maxLen, right - left + 1);
            }


            Console.WriteLine("Length of Longest substring without repeating chars :: " + maxLen);
            Console.ReadLine();
        }
    }
}



