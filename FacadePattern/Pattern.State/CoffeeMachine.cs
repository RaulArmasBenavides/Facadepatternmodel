using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.State
{
    public class CoffeeMachine
    {
        public ICoffeeMachineState CurrentState { get; set; }
        public ICoffeeMachineState NoCoinState { get; private set; }
        public ICoffeeMachineState CoinInsertedState { get; private set; }
        public ICoffeeMachineState CoffeeSelectedState { get; private set; }

        public CoffeeMachine()
        {
            NoCoinState = new NoCoinState(this);
            CoinInsertedState = new CoinInsertedState(this);
            CoffeeSelectedState = new CoffeeSelectedState(this);

            // Estado inicial
            CurrentState = NoCoinState;
        }

        public void InsertCoin() => CurrentState.InsertCoin();
        public void SelectCoffee() => CurrentState.SelectCoffee();
        public void DispenseCoffee() => CurrentState.DispenseCoffee();
    }

    // Estados concretos
    public class NoCoinState : ICoffeeMachineState
    {
        private readonly CoffeeMachine _machine;

        public NoCoinState(CoffeeMachine machine)
        {
            _machine = machine;
        }

        public void InsertCoin()
        {
            Console.WriteLine("Moneda insertada. Puede seleccionar su café.");
            _machine.CurrentState = _machine.CoinInsertedState;
        }

        public void SelectCoffee()
        {
            Console.WriteLine("Primero debe insertar una moneda.");
        }

        public void DispenseCoffee()
        {
            Console.WriteLine("Primero debe insertar una moneda.");
        }
    }

    public class CoinInsertedState : ICoffeeMachineState
    {
        private readonly CoffeeMachine _machine;

        public CoinInsertedState(CoffeeMachine machine)
        {
            _machine = machine;
        }

        public void InsertCoin()
        {
            Console.WriteLine("Ya hay una moneda insertada. Seleccione su café.");
        }

        public void SelectCoffee()
        {
            Console.WriteLine("Café seleccionado. Preparando...");
            _machine.CurrentState = _machine.CoffeeSelectedState;
        }

        public void DispenseCoffee()
        {
            Console.WriteLine("Seleccione un café primero.");
        }
    }

    public class CoffeeSelectedState : ICoffeeMachineState
    {
        private readonly CoffeeMachine _machine;

        public CoffeeSelectedState(CoffeeMachine machine)
        {
            _machine = machine;
        }

        public void InsertCoin()
        {
            Console.WriteLine("Espere a que el café actual se dispense.");
        }

        public void SelectCoffee()
        {
            Console.WriteLine("Ya seleccionó un café. Espere a que se dispense.");
        }

        public void DispenseCoffee()
        {
            Console.WriteLine("Dispensando café. ¡Disfrútelo!");
            _machine.CurrentState = _machine.NoCoinState; // Regresa al estado inicial
        }
    }
}
