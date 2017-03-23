
namespace Calculator
{
    class OperationSub : Operation
    {
        public override double getResult()
        {
            double result = 0;
            result = NumberA - NumberB;
            return result;
        }
    }
}
