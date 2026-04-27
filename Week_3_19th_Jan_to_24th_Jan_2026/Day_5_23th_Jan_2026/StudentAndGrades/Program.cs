namespace StudentAndGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentGradeManager manager = new StudentGradeManager();

            manager.AddOrUpdateStudent(101, 85);
            manager.AddOrUpdateStudent(102, 45);
            manager.AddOrUpdateStudent(103, 60);
            manager.AddOrUpdateStudent(104, 30);

            Func<IEnumerable<double>, double> averageFunc = g => g.Average();
            Predicate<double> riskPredicate = g => g < 50;

            Console.WriteLine("average :: " + manager.GetAverage(averageFunc));

            var atRisk = manager.GetAtRiskStudents(riskPredicate);
            Console.WriteLine("Students at risk :: ");
            foreach (var roll in atRisk)
                Console.WriteLine(roll);

            manager.AddOrUpdateStudent(102, 75);

            atRisk = manager.GetAtRiskStudents(riskPredicate);
            Console.WriteLine("Students at risk :: ");
            foreach (var roll in atRisk)
                Console.WriteLine(roll);
        }
    }
}
