using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StudentAndGrades
{
    internal class StudentGradeManager
    {
        private Dictionary<int, double> grades = new Dictionary<int, double>();

        public void AddOrUpdateStudent(int rollNo, double grade)
        {
            grades[rollNo] = grade;
        }

        public double GetAverage(Func<IEnumerable<double>, double> averageCalculator)
        {
            return averageCalculator(grades.Values);
        }

        public List<int> GetAtRiskStudents(Predicate<double> riskCheck)
        {
            return grades
                .Where(s => riskCheck(s.Value))
                .Select(s => s.Key)
                .ToList();
        }
    }
}
