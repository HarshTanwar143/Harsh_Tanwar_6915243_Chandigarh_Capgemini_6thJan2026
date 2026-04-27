namespace BiggestNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3;
            Console.Write("Enter three different numbers : ");
            num1 = int.Parse(Console.ReadLine());
            num2 = int.Parse(Console.ReadLine());
            num3 = int.Parse(Console.ReadLine());

            Console.Write("Greatest value :: ");
            if (num1 > num2 && num1 > num3)
            {
                Console.Write(num1);
            }
            else if (num2 > num1 && num2 > num3)
            {
                Console.Write(num2);
            }
            else
            {
                Console.Write(num3);
            }

            Console.ReadLine();

        }
    }
}
