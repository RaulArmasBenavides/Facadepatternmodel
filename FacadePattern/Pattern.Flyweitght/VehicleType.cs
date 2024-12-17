using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Flyweitght
{
    public class VehicleType
    {
        public string Name { get; }
        public string Icon { get; }  

        public VehicleType(string name, string icon)
        {
            Name = name;
            Icon = icon;
        }

        public void Render(int x, int y)
        {
            Console.WriteLine($"Rendering {Name} at ({x}, {y}) with icon {Icon}");
        }
    }

    public class VehicleTypeFactory
    {
        private Dictionary<string, VehicleType> _vehicleTypes = new Dictionary<string, VehicleType>();

        public VehicleType GetVehicleType(string name, string icon)
        {
            if (!_vehicleTypes.ContainsKey(name))
            {
                _vehicleTypes[name] = new VehicleType(name, icon);
                Console.WriteLine($"Created new VehicleType: {name}");
            }
            return _vehicleTypes[name];
        }
    }

    public class Vehicle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public VehicleType Type { get; }

        public Vehicle(int x, int y, VehicleType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Render()
        {
            Type.Render(X, Y);
        }
    }
}
