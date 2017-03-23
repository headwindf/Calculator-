using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    class OperationPoint : Operation
    {
        public override string addPoint(string str)
        {
            try
            {
                bool res = Regex.IsMatch(str, @"^(\-)?\d+$");//匹配纯数字
                bool res1 = Regex.IsMatch(str, @"^(\-)?\d+(\.\d+)?(\+|\-|\*|\/)\d+$");//匹配第二个操作数是否为整数
                if (res || res1)//满足其中一个则可以添加小数点
                {
                    str += ".";
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
