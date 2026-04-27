namespace FindRupeeCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rupees :: ");
            int input = int.Parse(Console.ReadLine());

            int output = 0;
            int[] rupees = new int[] { 500, 100, 50, 10, 1 };
            int[] count = new int[rupees.Length];

            if (input < 0)
            {
                output = -1;
                Console.WriteLine("Final Count :: " + output);
                return;
            }

            for (int i = 0; i < rupees.Length; i++)
            {
                // 1400 -> 900 -->400 --> 300->200->100->0
                while (input >= rupees[i])
                {
                    count[i]++;
                    output++;
                    input -= rupees[i];
                }
            }

            for (int i = 0; i < rupees.Length; i++)
            {
                Console.WriteLine(rupees[i] + " - " + count[i]);
            }

            Console.WriteLine("Final Count :: " + output);
        }
    }
}
