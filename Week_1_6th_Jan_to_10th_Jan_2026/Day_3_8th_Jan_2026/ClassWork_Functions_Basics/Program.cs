namespace ClassWork_Functions_Basics
{
    internal class Program
    {
        void fun1()
        {
            Console.WriteLine("inside no parameters, no output");
        }

        void fun2(int x, int y)
        {
            int add = x + y;
            Console.WriteLine("add : " + add);
        }

        int fun3()
        {
            int x = 100;
            int y = 30;
            int sub = x - y;
            return sub;
        }

        int fun4(int x, int y)
        {
            int dot = x * y;
            return dot;
        }

        void fun5(int x, int y, ref int a, ref int b)
        {
            a = x + y;
            b = x - y;
        }

        void fun6(int x, int y, out int a, out int b)
        {
            a = x * y;
            b = x / y;
        }

        static void Main(String[] args)
        {
            Program obj = new Program();
            obj.fun1();
            obj.fun2(50, 5);

            int res1 = obj.fun3();
            Console.WriteLine("res1 : " + res1);


            int res2 = obj.fun4(100, 10);
            Console.WriteLine("res2 : " + res2);

            // for ref keyword
            int r1 = 0, r2 = 0;
            obj.fun5(50, 5, ref r1, ref r2);
            Console.WriteLine("printing ref variables : " + r1 + " " + r2);

            // for out keyword
            int t1, t2;
            obj.fun6(50, 5, out t1, out t2);
            Console.WriteLine("printing out variables  : " + t1 + " " + t2);

        }
    }
}

