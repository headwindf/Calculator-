
namespace Calculator
{
    class OperationAdd : Operation
    {
        public override double getResult()
        {
            double result = 0.0;
            result = NumberA + NumberB;
            return result;
        }
    }
}
