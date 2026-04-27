namespace CustomerServiceCaseStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SupportCenter center = new SupportCenter();

            center.AddTicket("Login Issue");
            center.AddTicket("Payment Failed");
            center.AddTicket("Account Locked");

            string t1 = center.ProcessTicket(); // one element dequeue here
            center.PerformAction("Checked logs");
            center.PerformAction("Reset password");
            center.UndoLastAction();

            string t2 = center.ProcessTicket(); // second element dequeue here
            center.PerformAction("Verified payment");

            while (center.Tickets.Count > 0)
                Console.WriteLine(center.Tickets.Dequeue());
        }
    }
}
