namespace Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.Write("Enter the value of a : ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Enter the value of b : ");
            b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                Console.WriteLine("a is greater");
            }
            else if (b > a)
            {
                Console.WriteLine("b is greater");
            }
            else
            {
                Console.WriteLine("Both are equal");
            }
            Console.ReadLine();
        }
    }
}
