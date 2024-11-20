using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.State
{
    public interface ICoffeeMachineState
    {
        void InsertCoin();
        void SelectCoffee();
        void DispenseCoffee();
    }
}
