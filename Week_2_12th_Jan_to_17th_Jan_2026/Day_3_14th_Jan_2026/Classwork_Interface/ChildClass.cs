using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork_Interface
{
    internal class ChildClass : Inter1, Inter2
    {
        void Inter1.fun()
        {
            Console.WriteLine("function of interface1 invoked");
        }

        void Inter2.fun()
        {
            Console.WriteLine("function of interface2 invoked");
        }
    }
}
