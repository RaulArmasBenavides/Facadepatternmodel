using Pattern.Factory.AbstractFactory;

namespace Pattern.Factory.Concretions
{
    public class ConcreteProductA1 : IAbstractProductA
    {
        public string UsefulFunctionA()
        {
            return "ConcreteProductA1 result ";
        }
    }
}