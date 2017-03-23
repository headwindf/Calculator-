using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    class OperationPosAndNeg : Operation
    {
        public override string posAndNeg(string str)
        {
            try
            {
                Regex reg = new Regex(@"^(\-)?");
                var res = reg.Match(str).Groups;
                if (res[1].ToString() == "")//正数
                {
                    str = "-" + str;
                }
                else//负数
                {
                    str = str.Substring(1, str.Length - 1);
                }
                return str;
            }
            catch (Exception)
            {
                MessageBox.Show("发生错误！", "警告");
                return str;
            }
        }
    }
}
