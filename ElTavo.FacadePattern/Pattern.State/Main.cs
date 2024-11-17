using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.State
{
    class Program
    {
        private static void Main(string[] args)
        {
            var coffeeMachine = new CoffeeMachine();
            coffeeMachine.SelectCoffee();
            coffeeMachine.InsertCoin();       // Moneda insertada
            coffeeMachine.SelectCoffee();     // Café seleccionado
            coffeeMachine.DispenseCoffee();   // Dispensando café

            coffeeMachine.DispenseCoffee();   // Error: no hay moneda
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
