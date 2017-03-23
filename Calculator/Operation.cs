
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
        //获得结果
        public virtual double getResult()
        {
            double result = 0.0;
            return result;
        }
        //添加小数点
        public virtual string addPoint(string str)
        {
            return str;
        }
        //正负号
        public virtual string posAndNeg(string str)
        {
            return str;
        }
    }
}
