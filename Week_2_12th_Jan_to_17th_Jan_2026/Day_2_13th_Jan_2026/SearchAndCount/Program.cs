namespace SearchAndCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array :: ");
            int input2 = int.Parse(Console.ReadLine());

            if(input2 < 0)
            {
                Console.WriteLine("-2");
                return;
            }

            int[] input1 = new int[input2];
            Console.WriteLine("Enter elements :: ");
            for(int i = 0;i < input1.Length; i++)
            {
                input1[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the element want to count :: ");
            int input3 = int.Parse(Console.ReadLine());
            if(input3 < 0)
            {
                Console.WriteLine("-3");
                return;
            }

            foreach(int ele in input1)
            {
                if(ele < 0)
                {
                    Console.WriteLine("-1");
                    return;
                }
            }

            int count = 0;
            foreach(int ele in input1)
            {
                if(input3 == ele)
                {
                    ++count;
                }
            }
            Console.WriteLine("total count :: " + count);
        }
    }
}
