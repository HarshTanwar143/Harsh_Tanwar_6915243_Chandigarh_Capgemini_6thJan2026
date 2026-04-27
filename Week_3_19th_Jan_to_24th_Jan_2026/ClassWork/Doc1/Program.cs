using System.Text;

namespace Doc1
{
    internal class Person
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Person Name: {Name}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ObjectBaseClassDemo();
            EqualsVsOperatorDemo();
            StringVsStringBuilderDemo();
            StringManipulationDemo();
            StringMethodsDemo();
            DefaultParameterDemo();
            NamedParameterDemo();
        }

        static void ObjectBaseClassDemo()
        {
            object obj1 = 42;
            Console.WriteLine(obj1.ToString());

            object obj2 = "Hello";
            Console.WriteLine(obj2.GetType());

            object obj3 = new Person { Name = "John" };
            Console.WriteLine(obj3.Equals(new Person { Name = "John" }));
        }

        static void EqualsVsOperatorDemo()
        {
            string s1 = "hello";
            string s2 = "hello";
            Console.WriteLine(s1.Equals(s2));
            Console.WriteLine(s1 == s2);

            object o1 = new object();
            object o2 = new object();
            Console.WriteLine(o1.Equals(o2));
            Console.WriteLine(o1 == o2);

            int a = 5;
            int b = 5;
            Console.WriteLine(a.Equals(b));
            Console.WriteLine(a == b);
        }

        static void StringVsStringBuilderDemo()
        {
            string str = "Hello";
            str += " World";
            Console.WriteLine(str);

            StringBuilder sb = new StringBuilder("Hello");
            sb.Append(" World");
            Console.WriteLine(sb.ToString());

            string concat = "";
            for (int i = 0; i < 5; i++)
                concat += i;
            Console.WriteLine(concat);

            StringBuilder sb2 = new StringBuilder();
            for (int i = 0; i < 5; i++)
                sb2.Append(i);
            Console.WriteLine(sb2.ToString());
        }

        static void StringManipulationDemo()
        {
            string text = "  Welcome to .NET  ";
            Console.WriteLine(text.Trim());

            string name = "John Doe";
            Console.WriteLine(name.Substring(0, 4));

            string sentence = "apple,banana,orange";
            string[] fruits = sentence.Split(',');
            Console.WriteLine(fruits[1]);
        }

        static void StringMethodsDemo()
        {
            string s = "Programming in C#";

            Console.WriteLine(s.Contains("C#"));
            Console.WriteLine(s.StartsWith("Pro"));
            Console.WriteLine(s.EndsWith("C#"));
            Console.WriteLine(s.IndexOf("in"));
            Console.WriteLine(s.ToUpper());
            Console.WriteLine(s.ToLower());
        }

        static void DefaultParameterDemo()
        {
            PrintMessage();
            PrintMessage("Custom Msg");

            Add(5);
            Add(5, 20);
        }

        static void NamedParameterDemo()
        {
            Display("John", "Doe", 30);
            Display(lastName: "Smith", firstName: "Jane", age: 25);
            Display(age: 40, firstName: "Mark", lastName: "Lee");
        }

        static void PrintMessage(string msg = "Hello World")
        {
            Console.WriteLine(msg);
        }

        static void Add(int a, int b = 10)
        {
            Console.WriteLine(a + b);
        }

        static void Display(string firstName, string lastName, int age)
        {
            Console.WriteLine($"{firstName} {lastName}, Age: {age}");
        }
    }
}
