namespace DigitSumInStringArray
{
    internal class Program
    {
        static int sumOfDigits(string[] input1)
        {
            int sum = 0;

            foreach (string str in input1)
            {
                foreach (char ch in str)
                {
                    if (char.IsDigit(ch))
                    {
                        sum += ch - '0';
                    }
                    else if (!char.IsLetter(ch) && ch != ' ')
                    {
                        return -1;
                    }
                }
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number of strings: ");
            int n = int.Parse(Console.ReadLine());

            string[] arr = new string[n];

            Console.WriteLine("Enter the strings:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Console.ReadLine();
            }

            int result = sumOfDigits(arr);

            Console.WriteLine("Output:"); 
            Console.WriteLine(result);
        }
    }
}
