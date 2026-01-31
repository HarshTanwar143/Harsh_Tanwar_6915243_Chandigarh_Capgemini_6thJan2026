namespace FormString
{
    internal class Program
    {
        static string formString(string[] input1, int input2)
        {
            foreach (string s in input1)
            {
                foreach (char c in s)
                {
                    if (!char.IsLetter(c))
                        return "-1";
                }
            }

            string result = "";

            foreach (string s in input1)
            {
                if (s.Length >= input2)
                    result += s[input2 - 1];
                else
                    result += "$";
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number of strings: ");
            int k = int.Parse(Console.ReadLine());

            string[] arr = new string[k];

            Console.WriteLine("Enter strings:");
            for (int i = 0; i < k; i++)
            {
                arr[i] = Console.ReadLine();
            }

            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());

            string output = formString(arr, n);

            Console.WriteLine("Output:");
            Console.WriteLine(output);
        }
    }
}
