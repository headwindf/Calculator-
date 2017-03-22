using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Operation
    {
        private double numberA = 0.0;
        private double numberB = 0.0;       

        public double NumberA
        {
            get{return numberA;}
            set { numberA = value; }
        }

        public double NumberB
        {
            get{return numberB;}
            set { numberB = value; }
        }

        public virtual double getResult()
        {
            double result = 0.0;
            return result;
        }
    }
}
