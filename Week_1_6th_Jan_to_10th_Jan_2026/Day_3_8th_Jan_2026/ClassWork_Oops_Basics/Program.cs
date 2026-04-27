namespace ClassWork_Oops_Basics
{
    class ClassEmployee
    {
        public int EId;
        public String EName;
        public String EDept;
        public int EAge;

        public void setEmployeeDetails()
        {
            Console.WriteLine("Enter employee details below");
            Console.Write("Enter EId : ");
            this.EId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter EName : ");
            this.EName = Console.ReadLine();
            Console.Write("Enter EDept : ");
            this.EDept = Console.ReadLine();
            Console.Write("Enter EAge : ");
            this.EAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nDetails Added Successfully!");
            Console.ReadLine();
        }

        public void getEmployeeDetails()
        {
            Console.WriteLine("\nEmployee's Details :: \n");
            Console.WriteLine("Employee ID : " + this.EId);
            Console.WriteLine("Employee Name : " + this.EName);
            Console.WriteLine("Employee Department : " + this.EDept);
            Console.WriteLine("Employee Age : " + this.EAge);
            Console.WriteLine("\n");
        }

    }

    internal class Program
    {
        static void Main(String[] args)
        {
            ClassEmployee Emp1 = new ClassEmployee();
            ClassEmployee Emp2 = new ClassEmployee();

            Emp1.setEmployeeDetails();
            Emp2.setEmployeeDetails();
            Console.WriteLine("\n\nShowing Details::");
            Emp1.getEmployeeDetails();
            Emp2.getEmployeeDetails();
            Console.ReadLine();
        }
    }
}
