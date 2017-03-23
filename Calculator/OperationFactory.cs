
namespace Calculator
{
    class OperationFactory
    {
        public static Operation createOperation(string operation)
        {
            Operation oper = null;
            switch (operation)
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;
                case "/":
                    oper = new OperationDiv();
                    break;
                case "SquareRoot":
                    oper = new OperationSquareRoot();
                    break;
                case ".":
                    oper = new OperationPoint();
                    break;
                case "+/-":
                    oper = new OperationPosAndNeg();
                    break;
                default:
                    break;
            }
            return oper;
        }
    }
}
