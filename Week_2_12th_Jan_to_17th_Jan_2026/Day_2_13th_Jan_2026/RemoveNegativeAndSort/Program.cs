namespace RemoveNegativeAndSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int size = int.Parse(Console.ReadLine());

            if (size < 0)
            {
                int[] output = new int[1];
                output[0] = -1;
                Console.WriteLine(output[0]);
                return;
            }

            int[] input = new int[size];
            Console.WriteLine("Enter elements:");

            for (int i = 0; i < size; i++)
            {
                input[i] = int.Parse(Console.ReadLine());
            }

            int count = 0;
            for (int i = 0; i < size; i++)
            {
                if (input[i] >= 0)
                    count++;
            }

            int[] outputArr = new int[count];
            int index = 0;

            for (int i = 0; i < size; i++)
            {
                if (input[i] >= 0)
                {
                    outputArr[index] = input[i];
                    index++;
                }
            }

            for (int i = 0; i < outputArr.Length - 1; i++)
            {
                for (int j = i + 1; j < outputArr.Length; j++)
                {
                    if (outputArr[i] > outputArr[j])
                    {
                        int temp = outputArr[i];
                        outputArr[i] = outputArr[j];
                        outputArr[j] = temp;
                    }
                }
            }

            Console.WriteLine("Output:");
            for (int i = 0; i < outputArr.Length; i++)
            {
                Console.Write(outputArr[i] + " ");
            }
        }
    }
}
