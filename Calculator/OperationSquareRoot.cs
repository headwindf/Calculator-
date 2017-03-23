using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    class OperationSquareRoot : Operation
    {
        public override double getResult()
        {
            double result;
            try
            {
                Regex reg = new Regex(@"(\+|\-)?(\d+)(\.\d+)?");
                var res = reg.Match(MainForm.calShow).Groups;

                if (res[1].ToString() == "-")
                {
                    throw new Exception("负数不能开根号！");
                }
                result = Math.Sqrt(Convert.ToDouble(MainForm.calShow));
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告");
                return 0;
            }     
        }
    }
}
