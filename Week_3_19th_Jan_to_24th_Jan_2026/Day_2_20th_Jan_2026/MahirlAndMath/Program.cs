namespace MahirlAndMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1;
            Console.Write("Enter number :: ");
            input1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(UserMainCode.MinOperations(input1));
        }
    }
}
