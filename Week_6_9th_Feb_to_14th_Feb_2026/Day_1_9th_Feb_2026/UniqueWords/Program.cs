namespace UniqueWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("size of the list :: ");
            int n = Convert.ToInt32(Console.ReadLine());

            List<string> list = new List<string>(n);
            Console.WriteLine("Enter the strings :: ");
            for(int i = 0;i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach(string s in list)
            {
                string asc = new string(s.OrderBy(x => x).ToArray());
                if (!map.ContainsKey(asc))
                {
                    map[asc] = new List<string>();
                }
                map[asc].Add(s);
            }

            Console.WriteLine("\nUnique Words :: ");
            foreach(var val in map)
            {
                if(val.Value.Count == 1)
                {
                    Console.WriteLine(val.Value[0]);
                }
            }
            Console.WriteLine();
        }
    }
}
