namespace Delegate
{
    public delegate void Operations(int x, int y);

    internal class Program
    {
        public void add(int x, int y)
        {
            Console.WriteLine("add : " + (x + y));
        }

        public void sub(int x, int y)
        {
            Console.WriteLine("sub : " + (x - y));
        }

        public void mul(int x, int y)
        {
            Console.WriteLine("mul : " + (x * y));
        }

        public void div(int x, int y)
        {
            Console.WriteLine("div : " + (x / y));
        }

        public void mod(int x, int y)
        {
            Console.WriteLine("mod : " + (x % y));
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            Operations op = new Operations(obj.add);

            op += obj.sub;
            op += obj.mul;
            op += obj.div;
            op += obj.mod;

            op(2, 3);
            Console.ReadLine();
        }
    }
}
