using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
