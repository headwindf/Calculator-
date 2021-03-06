﻿using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {
        public static string calShow = "";//textBox显示的内容
        private double resultDouble = 0.0;//保存计算结果
        private bool equalStatus = false;//等于号是否被按过

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;//获取或设置一个值，该值指示在将键事件传递到具有焦点的控件前，窗体是否将接收此键事件
            btnNum0.BackgroundImage = new Bitmap(Resource1._0);
            btnNum1.BackgroundImage = new Bitmap(Resource1._1);
            btnNum2.BackgroundImage = new Bitmap(Resource1._2);
            btnNum3.BackgroundImage = new Bitmap(Resource1._3);
            btnNum4.BackgroundImage = new Bitmap(Resource1._4);
            btnNum5.BackgroundImage = new Bitmap(Resource1._5);
            btnNum6.BackgroundImage = new Bitmap(Resource1._6);
            btnNum7.BackgroundImage = new Bitmap(Resource1._7);
            btnNum8.BackgroundImage = new Bitmap(Resource1._8);
            btnNum9.BackgroundImage = new Bitmap(Resource1._9);
            btnAdd.BackgroundImage = new Bitmap(Resource1.add);
            btnSub.BackgroundImage = new Bitmap(Resource1.decrease);
            btnMul.BackgroundImage = new Bitmap(Resource1.mul);
            btnDiv.BackgroundImage = new Bitmap(Resource1.div);
            btnClear.BackgroundImage = new Bitmap(Resource1.clear);
            btnEqual.BackgroundImage = new Bitmap(Resource1.equal);
            btnDel.BackgroundImage = new Bitmap(Resource1.del);
            btnSquareRoot.BackgroundImage = new Bitmap(Resource1.squareRoot);
            btnPoint.BackgroundImage = new Bitmap(Resource1.point);
            btnPosAndNeg.BackgroundImage = new Bitmap(Resource1.posAndNeg);

            this.btnNum0.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNum1.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNum2.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNum3.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNum4.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNum5.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNum6.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNum7.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNum8.Click += new System.EventHandler(this.btnNum_Click);
            this.btnNum9.Click += new System.EventHandler(this.btnNum_Click);

            this.btnAdd.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnSub.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnMul.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnDiv.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnEqual.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnPoint.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnDel.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnClear.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnSquareRoot.Click += new System.EventHandler(this.btnOperation_Click);
            this.btnPosAndNeg.Click += new System.EventHandler(this.btnOperation_Click);

            setBtnEnableMethon(false);//防止一开始点击运算符按钮导致出错
        }

        private void btnNum_Click(object sender,EventArgs e)
        {
            bool res = Regex.IsMatch(calShow, @"^0+$");//匹配全都是0的情况
            bool res1 = Regex.IsMatch(calShow, @"^(\-)?\d+(\.\d+)?(\+|\-|\*|\/)0+$");//匹配第二个操作数是否全都是0的情况
            if (res || res1)//满足其中一个则把前面的0删掉
            {
                btnDel.PerformClick();
            }
            if (equalStatus)//等于号按过之后点数字则直接清除原来的结果
            {
                equalStatus = false;
                calShow = "";
                resultDouble = 0.0;
                txtResual.Text = "";
            }
            Button btn = (Button)sender;
            calShow += btn.Name.ToString().Substring(btn.Name.ToString().Length-1);
            txtResual.Text = calShow;
            setBtnEnableMethon(true);
            btnEqual.Focus();
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {  
            Button btn = sender as Button;
            Operation oper;
            switch (btn.Name)
            {
                case "btnAdd":
                    equalStatus = false;
                    multiDeal();
                    calShow += "+";
                    txtResual.Text = calShow;
                    setBtnEnableMethon(false);
                    break;
                case "btnSub":
                    equalStatus = false;
                    multiDeal();
                    calShow += "-";
                    txtResual.Text = calShow;
                    setBtnEnableMethon(false);
                    break;
                case "btnMul":
                    equalStatus = false;
                    multiDeal();
                    calShow += "*";
                    txtResual.Text = calShow;
                    setBtnEnableMethon(false);
                    break;
                case "btnDiv":
                    equalStatus = false;
                    multiDeal();
                    calShow += "/";
                    txtResual.Text = calShow;
                    setBtnEnableMethon(false);
                    break;
                case "btnEqual":
                    equalStatus = true;
                    multiDeal();
                    break;
                case "btnPoint":
                    if (equalStatus)//等于号按过之后点数字则直接清除原来的结果
                    {
                        equalStatus = false;
                        calShow = "";
                        resultDouble = 0.0;
                        txtResual.Text = "";
                    }
                    oper = OperationFactory.createOperation(".");
                    calShow = oper.addPoint(calShow);
                    txtResual.Text = calShow;
                    setBtnEnableMethon(true);
                    break;
                case "btnDel":
                    if (calShow.Length != 0)
                    {
                        calShow = calShow.Substring(0, calShow.Length - 1);//删除最后一个字符
                    }
                    txtResual.Text = calShow;
                    setBtnEnableMethon(true);
                    break;
                case "btnClear":
                    calShow = "";
                    resultDouble = 0;
                    txtResual.Text = "";
                    break;
                case "btnSquareRoot":
                    multiDeal();//先得出前面表达式的值
                    oper = OperationFactory.createOperation("SquareRoot");   
                    resultDouble = oper.getResult();
                    calShow = resultDouble.ToString();
                    txtResual.Text = calShow;
                    break;
                case "btnPosAndNeg":
                    multiDeal();//先计算结果，再来加正负号
                    oper = OperationFactory.createOperation("+/-");
                    calShow = oper.posAndNeg(calShow);
                    txtResual.Text = calShow;
                    break;
                default:
                    break;
            }
        }

        private void multiDeal()
        {
            try
            {
                //将前面的表达式的值计算出来
                Regex reg = new Regex(@"(\+|\-)?(\d+)(\.\d+)?(\+|\-|\*|\/)(\+|\-)?(\d+)(\.\d+)?");
                var res = reg.Match(calShow).Groups;
                //res[0]    整个匹配的表达式
                //res[1]    第一个操作数的符号
                //res[2]    第一个操作数的整数部分
                //res[3]    第一个操作数的小数部分
                //res[4]    操作符
                //res[5]    第二个操作数的符号
                //res[6]    第二个操作数的整数部分
                //res[7]    第而个操作数的小数部分
                Operation oper;
                switch (res[4].ToString())
                {
                    case "+":
                        oper = OperationFactory.createOperation("+");
                        oper.NumberA = Convert.ToDouble(res[1].ToString() + res[2].ToString() + res[3].ToString());               
                        oper.NumberB = Convert.ToDouble(res[5].ToString() + res[6].ToString() + res[7].ToString());
                        resultDouble = oper.getResult();
                        calShow = resultDouble.ToString();
                        break;
                    case "-":
                        oper = OperationFactory.createOperation("-");
                        oper.NumberA = Convert.ToDouble(res[1].ToString() + res[2].ToString() + res[3].ToString());
                        oper.NumberB = Convert.ToDouble(res[5].ToString() + res[6].ToString() + res[7].ToString());
                        resultDouble = oper.getResult();
                        calShow = resultDouble.ToString();
                        break;
                    case "*":
                        oper = OperationFactory.createOperation("*");
                        oper.NumberA = Convert.ToDouble(res[1].ToString() + res[2].ToString() + res[3].ToString());
                        oper.NumberB = Convert.ToDouble(res[5].ToString() + res[6].ToString() + res[7].ToString());
                        resultDouble = oper.getResult();
                        calShow = resultDouble.ToString();
                        break;
                    case "/":
                        oper = OperationFactory.createOperation("/");
                        oper.NumberA = Convert.ToDouble(res[1].ToString() + res[2].ToString() + res[3].ToString());
                        oper.NumberB = Convert.ToDouble(res[5].ToString() + res[6].ToString() + res[7].ToString());
                        if (oper.NumberB == 0)
                            throw new Exception("除数不能为0！");
                        resultDouble = oper.getResult();
                        calShow = resultDouble.ToString();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "警告");
            }
            txtResual.Text = calShow;
        }

        #region 运算符按键使能与失能
        //设置为false是为了防止连续按运算符按钮发生错误
        private void setBtnEnableMethon(bool nowStatus)
        {
            btnAdd.Enabled = nowStatus;
            btnSub.Enabled = nowStatus;
            btnMul.Enabled = nowStatus;
            btnDiv.Enabled = nowStatus;
            btnEqual.Enabled = nowStatus;
            btnSquareRoot.Enabled = nowStatus;
           // btnPosAndNeg.Enabled = nowStatus;
        }
        #endregion

        private void txtResual_TextChanged(object sender, EventArgs e)
        {
            if (calShow.Length < 10)
            {
                txtResual.Font = new Font(txtResual.Font.Name, 25);
            }
            else if (calShow.Length < 20)
            {
                txtResual.Font = new Font(txtResual.Font.Name, 15);
            }
            else if (calShow.Length < 30)
            {
                txtResual.Font = new Font(txtResual.Font.Name, 11);
            }
            else
            {
                txtResual.Font = new Font(txtResual.Font.Name, 8);
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {   
                case Keys.NumPad0://键盘右边的数字键
                    btnNum0.PerformClick();
                    break;
                case Keys.NumPad1:
                    btnNum1.PerformClick();
                    break;                
                case Keys.NumPad2:
                    btnNum2.PerformClick();
                    break;                
                case Keys.NumPad3:
                    btnNum3.PerformClick();
                    break;
                case Keys.NumPad4:
                    btnNum4.PerformClick();
                    break;
                case Keys.NumPad5:
                    btnNum5.PerformClick();
                    break;
                case Keys.NumPad6:
                    btnNum6.PerformClick();
                    break;
                case Keys.NumPad7:
                    btnNum7.PerformClick();
                    break;
                case Keys.NumPad8:
                    btnNum8.PerformClick();
                    break;
                case Keys.NumPad9:
                    btnNum9.PerformClick();
                    break;
                case Keys.Enter:
                    btnEqual.PerformClick();
                    break;
                case Keys.Add:
                    btnAdd.PerformClick();
                    break;
                case Keys.Subtract:
                    btnSub.PerformClick();
                    break;
                case Keys.Multiply:
                    btnMul.PerformClick();
                    break;
                case Keys.Divide:
                    btnDiv.PerformClick();
                    break;
                case Keys.Back:
                    btnDel.PerformClick();
                    break;
                case Keys.C:
                    btnClear.PerformClick();
                    break;
                case Keys.S:
                    btnSquareRoot.PerformClick();
                    break;
                case Keys.Z:
                    btnPosAndNeg.PerformClick();
                    break;
                case Keys.Decimal:
                    btnPoint.PerformClick();
                    break;
                default:
                    break;
            }
        }
    }
}
