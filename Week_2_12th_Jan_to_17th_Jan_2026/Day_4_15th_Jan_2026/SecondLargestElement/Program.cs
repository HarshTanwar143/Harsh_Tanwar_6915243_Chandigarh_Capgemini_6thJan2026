namespace SecondLargestElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the array:: ");
            int input3 = int.Parse(Console.ReadLine());

            if(input3 < 0)
            {
                int[] output = new int[1];
                output[0] = -2;
                Console.WriteLine("Output :: " + output[0]);
                return;
            }

            int[] input1 = new int[input3];
            Console.WriteLine("Enter the elements of array:: ");
            for(int i = 0;i < input3; i++)
            {
                input1[i] = int.Parse(Console.ReadLine());
                if(input1[i] < 0)
                {
                    int[] output = new int[1];
                    output[0] = -1;
                    Console.WriteLine("Output :: " + output[0]);
                    return;
                }
            }

            // eg: 1 3 2 4 7 7 8 6 9 9
            int first = input1[0];
            int second = -1;
            for(int i = 0;i < input3; i++)
            {
                if(first < input1[i])
                {
                    second = first;
                    first = input1[i];
                }
                else
                {
                    if(second < input1[i] && input1[i] != first)
                    {
                        second = input1[i];
                    }
                }
            }

            Console.WriteLine("Second Largest number :: " + second);
            Console.ReadLine();
        }
    }
}

/**
 * 2. Given  input array is input1[] and size of array is input3
Identify the second largest element and store it to output1
input1[]={2,3,4,1,9}
output1=4
Business Rule1: If  the size of input array is negative ,then store -2 to output array
Business Rule2: If any element in  input array is negative ,then store -1 to output array 

 */