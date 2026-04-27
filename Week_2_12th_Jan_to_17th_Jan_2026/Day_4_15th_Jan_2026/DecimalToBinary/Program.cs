namespace DecimalToBinary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a decimal number :: ");
            int input1 = int.Parse(Console.ReadLine());

            if (input1 < 0)
            {
                int[] output = {-1};
                Console.WriteLine(output[0]);
                return;
            }

            int[] binary = new int[32];
            int index = 0;

            while (input1 > 0)
            {
                binary[index++] = input1 % 2;
                input1 /= 2;
            }

            int[] outputArray = new int[index];
            int j = 0;

            for (int i = index - 1; i >= 0; i--)
            {
                outputArray[j++] = binary[i];
            }

            Console.Write("Corresponding binary form of this decimal :: ");
            for (int i = 0; i < outputArray.Length; i++)
            {
                Console.Write(outputArray[i] + " ");
            }
        }
    }
}
