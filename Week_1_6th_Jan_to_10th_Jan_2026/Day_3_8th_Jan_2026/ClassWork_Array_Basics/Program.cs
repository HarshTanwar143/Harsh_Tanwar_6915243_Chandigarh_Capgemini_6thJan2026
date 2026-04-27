namespace ClassWork_Array_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            int[] nums = new int[5];
            // int[] nums = new int[] {2,3,4,5,4,3};
            // int[] nums = new int[6]{2,3,4,5,4,3};
            nums[0] = 43;
            nums[1] = 10;
            nums[2] = 20;
            nums[3] = 30;
            nums[4] = 50;

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();

            foreach (int var in nums)
            {
                Console.Write(var + " ");
            }
            Console.WriteLine();
        }
    }
}
