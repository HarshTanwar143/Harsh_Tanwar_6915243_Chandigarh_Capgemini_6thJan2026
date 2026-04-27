namespace FirstNonRepeatingElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the string :: ");
            string input = Console.ReadLine();

            Dictionary<char, int> freq = new Dictionary<char, int>();
            for(int i = 0;i < input.Length; i++)
            {
                if (freq.ContainsKey(input[i]))
                {
                    freq[input[i]]++;
                }
                else
                {
                    freq[input[i]] = 1;
                }
            }

            bool present = false;
            foreach(char ch in input)
            {
                if (freq[ch] == 1)
                {
                    Console.WriteLine("first non-repeating char :: " + ch);
                    present = true;
                    break;
                }
            }
            if(present == false)
            {
                Console.WriteLine("There is no non-repeating char");
            }

            Console.ReadLine();
        }
    }
}
