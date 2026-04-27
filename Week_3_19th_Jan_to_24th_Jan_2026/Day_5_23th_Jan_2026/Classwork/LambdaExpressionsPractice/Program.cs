using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LambdaExpressionsPractice
{
    internal class Program
    {
        static void Main()
        {
            LinqCollectionsDemo();
            LambdaExpressionsDemo();
            XElementDemo();
            XDocumentDemo();
        }

        static void LinqCollectionsDemo()
        {
            List<string> products = new List<string> { "Pen", "Pencil", "Notebook", "Marker", "Paper" };

            var filtered = products.Where(p => p.StartsWith("P")).Select(p => p.ToUpper());
            foreach (var p in filtered) Console.WriteLine(p);

            List<int> scores = new List<int> { 78, 92, 85, 92, 67, 88, 95 };

            var top3 = scores.OrderByDescending(x => x).Distinct().Take(3);
            foreach (var s in top3) Console.WriteLine(s);

            List<Sale> sales = new List<Sale>
            {
                new Sale("North",1200),
                new Sale("South",800),
                new Sale("North",500),
                new Sale("East",900),
                new Sale("South",700)
            };

            var grouped = sales
                .GroupBy(s => s.Region)
                .Select(g => new { Region = g.Key, Total = g.Sum(x => x.Amount), Count = g.Count() });

            foreach (var g in grouped)
                Console.WriteLine($"{g.Region} {g.Total} {g.Count}");
        }

        static void LambdaExpressionsDemo()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            var even = numbers.FindAll(x => x % 2 == 0);
            foreach (var n in even) Console.WriteLine(n);

            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(5, 3));

            Func<int, bool> isEven = x => x % 2 == 0;
            Console.WriteLine(isEven(4));

            List<Dog> dogs = new List<Dog>
            {
                new Dog { Name = "Rex", Age = 4 },
                new Dog { Name = "Sean", Age = 0 },
                new Dog { Name = "Stacy", Age = 3 }
            };

            var names = dogs.Select(x => x.Name);
            foreach (var name in names) Console.WriteLine(name);

            var anonymous = dogs.Select(x => new { x.Age, FirstLetter = x.Name[0] });
            foreach (var a in anonymous) Console.WriteLine(a);

            var sortedDogs = dogs.OrderByDescending(x => x.Age);
            foreach (var d in sortedDogs) Console.WriteLine($"{d.Name} {d.Age}");

            List<string> words = new List<string> { "apple", "ball", "cat", "dog" };
            Console.WriteLine(words.Count(w => w.Contains('a')));
        }

        static void XElementDemo()
        {
            XElement students =
                new XElement("Students",
                    new XElement("Student",
                        new XAttribute("Id", 1),
                        new XElement("Name", "Alice"),
                        new XElement("Age", 20)
                    ),
                    new XElement("Student",
                        new XAttribute("Id", 2),
                        new XElement("Name", "Bob"),
                        new XElement("Age", 22)
                    )
                );

            students.Save("students.xml");

            XElement loaded = XElement.Load("students.xml");

            var query = from s in loaded.Elements("Student")
                        where (int)s.Element("Age") > 20
                        select s.Element("Name").Value;

            foreach (var q in query) Console.WriteLine(q);

            var student = loaded.Elements("Student")
                .FirstOrDefault(s => (int)s.Attribute("Id") == 1);

            if (student != null) student.Element("Age").Value = "21";

            loaded.Add(
                new XElement("Student",
                    new XAttribute("Id", 3),
                    new XElement("Name", "Charlie"),
                    new XElement("Age", 23)
                )
            );

            loaded.Save("students.xml");
        }

        static void XDocumentDemo()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Students",
                    new XElement("Student",
                        new XAttribute("Id", 1),
                        new XElement("Name", "Alice"),
                        new XElement("Age", 20)
                    ),
                    new XElement("Student",
                        new XAttribute("Id", 2),
                        new XElement("Name", "Bob"),
                        new XElement("Age", 22)
                    )
                )
            );

            doc.Save("studentsDoc.xml");

            XDocument loaded = XDocument.Load("studentsDoc.xml");

            var result = loaded.Descendants("Student")
                .Where(s => (int)s.Element("Age") > 20)
                .Select(s => new { Name = s.Element("Name").Value, Age = s.Element("Age").Value });

            foreach (var r in result) Console.WriteLine($"{r.Name} {r.Age}");

            var update = loaded.Descendants("Student")
                .FirstOrDefault(s => (int)s.Attribute("Id") == 1);

            if (update != null) update.Element("Age").Value = "21";

            var delete = loaded.Descendants("Student")
                .FirstOrDefault(s => (int)s.Attribute("Id") == 2);

            delete?.Remove();

            loaded.Save("studentsDoc.xml");
        }
    }

    record Sale(string Region, decimal Amount);

    class Dog
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}




