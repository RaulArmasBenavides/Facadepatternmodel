using Pattern.Factory.AbstractFactory;

namespace Pattern.Factory.Concretions
{
    public class ConcreteProductB2 : IAbstractProductB
    {
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            return "AnotherUsefulFunctionB2";
        }

        public string UsefulFunctionB()
        {
            return "UsefulFunctionB 2! ";
        }
    }
}