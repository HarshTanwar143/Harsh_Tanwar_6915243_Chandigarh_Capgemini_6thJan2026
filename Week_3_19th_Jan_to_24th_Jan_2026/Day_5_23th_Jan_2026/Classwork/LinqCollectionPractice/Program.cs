using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace LinqCollectionPractice
{

    internal class Program
    {
        static void Main()
        {
            LinqFilterProjectDemo();
            LinqSortDistinctTakeDemo();
            LinqGroupAggregateDemo();
            XElementCreateSaveDemo();
            XElementReadQueryDemo();
            XElementModifyDemo();
            XDocumentCrudDemo();
        }

        static void LinqFilterProjectDemo()
        {
            List<string> products = new List<string>
            {
                "Pen", "Pencil", "Notebook", "Marker", "Paper"
            };

            var result = products
                .Where(p => p.StartsWith("P"))
                .Select(p => p.ToUpper());

            foreach (var item in result)
                Console.WriteLine(item);

            Console.WriteLine();
        }

        static void LinqSortDistinctTakeDemo()
        {
            List<int> scores = new List<int>
            {
                78, 92, 85, 92, 67, 88, 95
            };

            var top3 = scores
                .OrderByDescending(s => s)
                .Distinct()
                .Take(3)
                .ToList();

            top3.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        record Sale(string Region, decimal Amount);

        static void LinqGroupAggregateDemo()
        {
            List<Sale> sales = new List<Sale>
            {
                new("North", 1200m),
                new("South", 800m),
                new("North", 500m),
                new("East", 900m),
                new("South", 700m)
            };

            var result = sales
                .GroupBy(s => s.Region)
                .Select(g => new
                {
                    Region = g.Key,
                    Total = g.Sum(x => x.Amount),
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Total);

            foreach (var r in result)
                Console.WriteLine($"{r.Region} - Total: {r.Total}, Count: {r.Count}");

            Console.WriteLine();
        }

        static void XElementCreateSaveDemo()
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
            Console.WriteLine(students);
            Console.WriteLine();
        }

        static void XElementReadQueryDemo()
        {
            XElement students = XElement.Load("students.xml");

            var names = from s in students.Elements("Student")
                        where (int)s.Element("Age") > 20
                        select s.Element("Name").Value;

            foreach (var name in names)
                Console.WriteLine(name);

            Console.WriteLine();
        }

        static void XElementModifyDemo()
        {
            XElement students = XElement.Load("students.xml");

            var student = students.Elements("Student")
                .FirstOrDefault(s => (int)s.Attribute("Id") == 1);

            if (student != null)
                student.Element("Age").Value = "21";

            students.Add(
                new XElement("Student",
                    new XAttribute("Id", 3),
                    new XElement("Name", "Charlie"),
                    new XElement("Age", 23)
                )
            );

            students.Save("students.xml");
            Console.WriteLine(students);
            Console.WriteLine();
        }

        static void XDocumentCrudDemo()
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

            var query = loaded.Descendants("Student")
                .Where(s => (int)s.Element("Age") > 20)
                .Select(s => s.Element("Name").Value);

            foreach (var name in query)
                Console.WriteLine(name);

            var updateStudent = loaded.Descendants("Student")
                .FirstOrDefault(s => (int)s.Attribute("Id") == 1);

            if (updateStudent != null)
                updateStudent.Element("Age").Value = "21";

            var deleteStudent = loaded.Descendants("Student")
                .FirstOrDefault(s => (int)s.Attribute("Id") == 2);

            deleteStudent?.Remove();

            loaded.Save("studentsDoc.xml");
        }
    }


}




