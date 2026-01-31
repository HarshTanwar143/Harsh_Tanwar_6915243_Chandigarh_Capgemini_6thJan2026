namespace EmployeeDesignation
{
    internal class Program
    {
        static string[] getEmployee(string[] input1, string input2)
        {
            foreach (string s in input1)
            {
                foreach (char c in s)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        return new string[] { "Invalid Input" };
                    }
                }
            }

            foreach (char c in input2)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return new string[] { "Invalid Input" };
                }
            }

            List<string> result = new List<string>();
            int totalEmployees = input1.Length / 2;

            for (int i = 1; i < input1.Length; i += 2)
            {
                if (input1[i].Equals(input2, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(input1[i - 1]);
                }
            }

            if (result.Count == 0)
            {
                return new string[] { "No employee for " + input2 + " designation" };
            }

            if (result.Count == totalEmployees)
            {
                return new string[] { "All employees belong to same " + input2 + " designation" };
            }

            return result.ToArray();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number of elements: ");
            int n = int.Parse(Console.ReadLine());

            string[] arr = new string[n];

            Console.WriteLine("Enter elements:");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Console.ReadLine();
            }

            Console.Write("Enter designation: ");
            string desig = Console.ReadLine();

            string[] output = getEmployee(arr, desig);

            Console.WriteLine("Output:");
            foreach (string s in output)
            {
                Console.Write(s + " ");
            }
            Console.ReadLine();
        }
    }
}
