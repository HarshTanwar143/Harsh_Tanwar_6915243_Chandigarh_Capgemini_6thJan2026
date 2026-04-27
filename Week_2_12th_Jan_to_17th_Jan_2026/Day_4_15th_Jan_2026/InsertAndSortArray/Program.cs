namespace InsertAndSortArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size :: ");
            int size = int.Parse(Console.ReadLine());

            if (size < 0)
            {
                Console.WriteLine("-2");
                return;
            }

            int[] arr = new int[size];

            Console.WriteLine("Enter the elements :: ");
            for (int i = 0; i < size; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if (arr[i] < 0)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            Console.Write("Enter the elements that you want to place :: ");
            int element = int.Parse(Console.ReadLine());

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            int[] output = new int[size + 1];
            int k = 0;
            bool inserted = false;

            for (int i = 0; i < size; i++)
            {
                if (!inserted && element < arr[i])
                {
                    output[k++] = element;
                    inserted = true;
                }
                output[k++] = arr[i];
            }

            if (!inserted)
            {
                output[k] = element;
            }

            Console.Write("Output :: ");
            for (int i = 0; i < output.Length; i++)
            {
                Console.Write(output[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
