namespace CarInheritance
{
    public abstract class Car
    {
        protected bool isSedan;
        protected string seats;

        public Car(bool isSedan, string seats)
        {
            this.isSedan = isSedan;
            this.seats = seats;
        }

        public bool getIsSedan()
        {
            return isSedan;
        }

        public string getSeats()
        {
            return seats;
        }

        public abstract string getMileage();
    }

    public class WagonR : Car
    {
        private int mileage;

        public WagonR(int mileage) : base(false, "4")
        {
            this.mileage = mileage;
        }

        public override string getMileage()
        {
            return $"{mileage} kmpl";
        }
    }

    public class HondaCity : Car
    {
        private int mileage;

        public HondaCity(int mileage) : base(true, "4")
        {
            this.mileage = mileage;
        }

        public override string getMileage()
        {
            return $"{mileage} kmpl";
        }
    }

    public class InnovaCrysta : Car
    {
        private int mileage;

        public InnovaCrysta(int mileage) : base(false, "6")
        {
            this.mileage = mileage;
        }

        public override string getMileage()
        {
            return $"{mileage} kmpl";
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            int type = Convert.ToInt32(Console.ReadLine().Trim());
            int mileage = Convert.ToInt32(Console.ReadLine().Trim());

            Car car;
            string className;

            switch (type)
            {
                case 0:
                    car = new WagonR(mileage);
                    className = "WagonR";
                    break;
                case 1:
                    car = new HondaCity(mileage);
                    className = "HondaCity";
                    break;
                default:
                    car = new InnovaCrysta(mileage);
                    className = "InnovaCrysta";
                    break;
            }

            string sedanStr = car.getIsSedan() ? "" : "not ";
            string seatsStr = car.getSeats();
            string mileageStr = car.getMileage();

            Console.WriteLine(
                $"A {className} is {sedanStr}Sedan, is {seatsStr}-seater, " +
                $"and has a mileage of around {mileageStr}.");
        }
    }
}
