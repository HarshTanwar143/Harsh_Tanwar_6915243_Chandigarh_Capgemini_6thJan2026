namespace MostRepeatedElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter size of array: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Enter elements:");
            for (int i = 0; i < n; i++)
                arr[i] = int.Parse(Console.ReadLine());

            int maxCount = 0;

            // finding maximum frequency
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (arr[i] == arr[j])
                        count++;
                }
                if (count > maxCount)
                    maxCount = count;
            }

            Console.Write("Output: ");
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (arr[i] == arr[j])
                        count++;
                }

                // Check, is it already taken or not...
                bool printed = false;
                for (int k = 0; k < i; k++)
                {
                    if (arr[i] == arr[k])
                        printed = true;
                }

                if (count == maxCount && !printed)
                    Console.Write(arr[i] + " ");
            }
        }
    }
}
