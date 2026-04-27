using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarsManagement
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }

    public class CarsManager
    {
        private List<Car> _cars;

        public CarsManager(List<Car> cars)
        {
            _cars = cars;
        }


        public Car MostExpensiveCar()
        {
            return _cars.OrderByDescending(c => c.Price).First();
        }


        public Car CheapestCar()
        {
            return _cars.OrderBy(c => c.Price).First();
        }


        public int AveragePriceOfCars()
        {
            return (int)Math.Round(_cars.Average(c => c.Price));
        }


        public Dictionary<string, Car> MostExpensiveModelForEachBrand()
        {
            return _cars
                .GroupBy(c => c.Brand)
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderByDescending(c => c.Price).First()
                );
        }
    }

    class CarsManagementSolution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(
                @System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var parts = Console.ReadLine().Trim().Split(' ');
                cars.Add(new Car
                {
                    Brand = parts[0],
                    Model = parts[1],
                    Price = Convert.ToInt32(parts[2])
                });
            }

            CarsManager manager = new CarsManager(cars);

            var mostExpensive = manager.MostExpensiveCar();
            textWriter.WriteLine($"The most expensive car is {mostExpensive.Brand} {mostExpensive.Model}");

            var cheapest = manager.CheapestCar();
            textWriter.WriteLine($"The cheapest car is {cheapest.Brand} {cheapest.Model}");

            textWriter.WriteLine($"The average price of all cars is {manager.AveragePriceOfCars()}");

            var mostExpensiveByBrand = manager.MostExpensiveModelForEachBrand();
            foreach (var kvp in mostExpensiveByBrand)
            {
                textWriter.WriteLine(
                    $"The most expensive model for brand {kvp.Key} is {kvp.Value.Model} having price {kvp.Value.Price}");
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
