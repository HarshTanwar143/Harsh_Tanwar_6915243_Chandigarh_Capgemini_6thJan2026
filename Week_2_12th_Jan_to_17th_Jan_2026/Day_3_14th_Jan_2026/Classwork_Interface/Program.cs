using System;

namespace Classwork_Interface
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ChildClass obj = new ChildClass();

            Inter1 obj1 = (Inter1)obj;
            Inter2 obj2 = (Inter2)obj;

            obj1.fun();
            obj2.fun();
            Console.ReadLine();
        }
    }
}
