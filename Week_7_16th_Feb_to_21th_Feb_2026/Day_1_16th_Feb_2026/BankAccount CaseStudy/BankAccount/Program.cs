namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccountUtil account = new BankAccountUtil(1000);

            Console.WriteLine("Initial Balance: " + account.Balance);

            account.Deposit(500);
            Console.WriteLine("After Deposit: " + account.Balance);

            account.Withdraw(300);
            Console.WriteLine("After Withdraw: " + account.Balance);

            try
            {
                account.Withdraw(2000);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
