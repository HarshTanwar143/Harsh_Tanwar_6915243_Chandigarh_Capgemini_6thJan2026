namespace CountVowels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the string :: ");
            string input = Console.ReadLine();
            int count = 0;

            for(int i = 0;i < input.Length; i++)
            {
                char ch = char.ToLower(input[i]);
                if(ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                {
                    ++count;
                }
            }

            Console.WriteLine("Total count of vowels :: " + count);
            Console.ReadLine();
        }
    }
}
