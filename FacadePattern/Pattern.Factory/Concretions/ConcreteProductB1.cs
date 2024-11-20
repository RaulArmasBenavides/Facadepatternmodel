using Pattern.Factory.AbstractFactory;

namespace Pattern.Factory.Concretions
{
    public class ConcreteProductB1 : IAbstractProductB
    {
        public string AnotherUsefulFunctionB(IAbstractProductA collaborator)
        {
            return "AnotherUsefulFunctionB1";
        }

        public string UsefulFunctionB()
        {
            return "UsefulFunctionB 1 ";
        }
    }
}