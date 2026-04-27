namespace QuestionPaper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the marks of 1st and 2nd type of questions :: ");
            int input1 = int.Parse(Console.ReadLine());
            int input2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of questions of 1st and 2nd type :: ");
            int input3 = int.Parse(Console.ReadLine());
            int input4 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the marks obtained by student :: ");
            int input5 = int.Parse(Console.ReadLine());

            CheckValid.check(input1, input2, input3, input4, input5);
            Console.ReadLine();
        }
    }
}

