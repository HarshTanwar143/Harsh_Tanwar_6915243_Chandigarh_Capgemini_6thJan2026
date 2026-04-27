namespace LuckyString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1;
            string input2;

            Console.Write("Enter number :: ");
            input1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter string :: ");
            input2 = Console.ReadLine();

            Console.WriteLine(UserMainCode.IsLuckyString(input1, input2));
        }
    }
}
