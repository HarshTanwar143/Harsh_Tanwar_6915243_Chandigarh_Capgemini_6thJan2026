namespace SearchAndRemoveSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of array :: ");
            int input2 = int.Parse(Console.ReadLine());

            if (input2 < 0)
            {
                Console.WriteLine("-2");
                return;
            }

            Console.WriteLine("Enter the elements of the array:: ");
            int[] input1 = new int[input2];
            for (int i = 0; i < input2; i++)
            {
                input1[i] = int.Parse(Console.ReadLine());
                if (input1[i] < 0)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            Console.Write("Enter the element you want to search and remove :: "); 
            int input3 = int.Parse(Console.ReadLine());

            int index = -1;
            for (int i = 0; i < input2; i++)
            {
                if (input1[i] == input3)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("-3");
                return;
            }

            int[] output = new int[input2 - 1];
            int k = 0;

            for (int i = 0; i < input2; i++)
            {
                if (i != index)
                {
                    output[k++] = input1[i];
                }
            }

            for (int i = 0; i < output.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < output.Length; j++)
                {
                    if (output[j] < output[min])
                        min = j;
                }

                int temp = output[i];
                output[i] = output[min];
                output[min] = temp;
            }

            Console.Write("Final output array :: ");
            for (int i = 0; i < output.Length; i++)
            {
                Console.Write(output[i] + " ");
            }
            Console.ReadLine();
        }
    }
}
