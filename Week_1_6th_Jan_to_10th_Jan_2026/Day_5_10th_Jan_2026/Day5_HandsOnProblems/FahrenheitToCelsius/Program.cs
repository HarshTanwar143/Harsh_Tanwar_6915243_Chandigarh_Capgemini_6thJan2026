namespace FahrenheitToCelsius
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter temperature in Fahrenheit: ");
            double fahrenheit = double.Parse(Console.ReadLine());

            double output;

            if (fahrenheit < 0)
            {
                output = -1;
            }
            else
            {
                output = (fahrenheit - 32) * 5 / 9;
            }

            Console.WriteLine("Output = " + output);
        }
    }
}
