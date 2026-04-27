namespace PalindromeCheck
{
    internal class Program
    {
        static bool check(string st)
        {
            int s = 0, e = st.Length - 1;

            while(s < e)
            {
                if (st[s] != st[e])
                {
                    return false;
                }
                s++;
                e--;
            }

            return true;
        }


        static void Main(string[] args)
        {
            Console.Write("Enter the string :: ");
            string input = Console.ReadLine();

            if (check(input))
            {
                Console.WriteLine("It's Palindrome");
            }
            else
            {
                Console.WriteLine("Not Palindrome");
            }

            Console.ReadLine();
        }
    }
}
