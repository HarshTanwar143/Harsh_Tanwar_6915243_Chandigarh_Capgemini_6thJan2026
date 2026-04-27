namespace Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalMarks;
            Console.Write("\nEnter total marks of student :: ");
            totalMarks = int.Parse(Console.ReadLine());

            Console.Write("Student's grade :: ");
            if (totalMarks >= 70 && totalMarks < 80)
            {
                Console.WriteLine("B+");
            }
            else if (totalMarks >= 80 && totalMarks < 90)
            {
                Console.WriteLine("A");
            }
            else if (totalMarks >= 90 && totalMarks <= 100)
            {
                Console.WriteLine("A+");
            }
            else
            {
                Console.WriteLine("Failed!!!");
            }

            Console.ReadLine();
        }
    }
}
