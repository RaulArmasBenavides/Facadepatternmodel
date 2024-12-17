using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Flyweitght
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new VehicleTypeFactory();

            // Crear tipos de vehículos (Flyweights)
            var carType = factory.GetVehicleType("Car", "car-icon.png");
            var truckType = factory.GetVehicleType("Truck", "truck-icon.png");
            var bikeType = factory.GetVehicleType("Motorcycle", "bike-icon.png");

            // Crear vehículos
            var vehicles = new List<Vehicle>
        {
            new Vehicle(10, 20, carType),
            new Vehicle(15, 25, truckType),
            new Vehicle(20, 30, carType),
            new Vehicle(25, 35, bikeType),
            new Vehicle(30, 40, truckType)
        };

            // Renderizar vehículos
            foreach (var vehicle in vehicles)
            {
                vehicle.Render();
            }
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
