namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the string :: ");
            string input = Console.ReadLine();

            int e = input.Length - 1;
            string rev = "";
             while(e >= 0)
            {
                rev += input[e];
                e--;
            }

            Console.WriteLine("After reversing the string :: " + rev);
            Console.ReadLine();

        }
    }
}
