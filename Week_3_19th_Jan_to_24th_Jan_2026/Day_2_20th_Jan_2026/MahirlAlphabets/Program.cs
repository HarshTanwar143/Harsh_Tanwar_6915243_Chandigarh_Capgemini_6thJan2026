namespace MahirlAlphabets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input1, input2;

            Console.Write("Enter string 1 :: ");
            input1 = Console.ReadLine();
            Console.Write("Enter string 2 :: ");
            input2 = Console.ReadLine();

            Console.WriteLine(UserMainCode.ProcessString(input1, input2));
        }
    }
}
