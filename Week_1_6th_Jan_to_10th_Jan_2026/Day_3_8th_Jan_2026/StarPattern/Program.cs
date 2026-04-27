namespace StarPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of rows :: ");
            int row = int.Parse(Console.ReadLine());

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row - i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
