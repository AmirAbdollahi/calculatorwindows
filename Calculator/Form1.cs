using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double number1;
        double number2;
        double localResult;
        double totalResult;

        enum Operations { NONE, ADD, SUBTRACT, MULTIPLY, DIVIDE, MOD, POW, ROOT };
        Operations lastOperation = Operations.NONE;

        List<Operations> operationsList = new List<Operations>();

        double memory = 0;

        string textInClipboard;

        bool shouldResetNumber = false;
        bool equalButtonClicked = false;
        bool isInv = false;
        bool isFE = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void SetTextInLabel(string input)
        {
            label1.Text += " " + textBox1.Text + " " + input;
            textBox1.Text = string.Empty;
        }

        private void SetNumberInTextBox(string input)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = input;
            }
            else
            {
                if (equalButtonClicked)
                {
                    textBox1.Text = input;
                    equalButtonClicked = false;
                }
                else
                {
                    textBox1.Text += input;
                }
            }
        }


        private void btn0_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "0";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("0");
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "1";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("1");
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "2";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("2");
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "3";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("3");
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "4";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("4");
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "5";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("5");
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "6";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("6");
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "7";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("7");
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "8";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("8");
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = "9";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox("9");
            }
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (shouldResetNumber)
            {
                textBox1.Text = ".";
                shouldResetNumber = false;
            }
            else
            {
                SetNumberInTextBox(".");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            else if (textBox1.Text.Length == 1)
            {
                textBox1.Text = "0";
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBox1.Text);

            SetTextInLabel("+");

            if (lastOperation == Operations.MULTIPLY)
            {
                localResult = number1 * num2;

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult *= localResult;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else if (lastOperation == Operations.DIVIDE)
            {
                localResult = number1 / num2;

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult /= localResult;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else if (lastOperation == Operations.POW)
            {
                localResult = Math.Pow(number1, num2);

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult = Math.Pow(number1, num2); ;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else if (lastOperation == Operations.ROOT)
            {
                localResult = Math.Pow(number1, 1.0 / num2);

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult = Math.Pow(number1, 1.0 / num2); ;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else
            {
                label1.Text += textBox1.Text;
                SetTotalResult(num2, lastOperation);
            }

            textBox1.Text = totalResult.ToString();
            shouldResetNumber = true;

            lastOperation = Operations.ADD;
            operationsList.Add(lastOperation);
        }

        private void SetTotalResult(double num2, Operations operation)
        {
            if (label1.Text == string.Empty)
            {
                totalResult = num2;
            }
            else
            {
                if (operation == Operations.ADD)
                {
                    totalResult += num2;
                }
                else if (operation == Operations.SUBTRACT)
                {
                    totalResult -= num2;
                }
                else if (operation == Operations.MULTIPLY)
                {
                    totalResult *= num2;
                }
                else if (operation == Operations.DIVIDE)
                {
                    totalResult /= num2;
                }
                else if (operation == Operations.MOD)
                {
                    totalResult %= num2;
                }
                else if (operation == Operations.POW)
                {
                    totalResult = Math.Pow(totalResult, num2);
                }
                else if (operation == Operations.ROOT)
                {
                    totalResult = Math.Pow(totalResult, -num2);
                }
                else if (operation == Operations.NONE)
                {
                    totalResult = num2;
                }                
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBox1.Text);

            SetTextInLabel("-");

            if (lastOperation == Operations.MULTIPLY)
            {
                localResult = number1 * num2;

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult *= localResult;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else if (lastOperation == Operations.DIVIDE)
            {
                localResult = number1 / num2;

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult /= localResult;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else if (lastOperation == Operations.POW)
            {
                localResult = Math.Pow(number1, num2);

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult = Math.Pow(number1, num2); ;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else if (lastOperation == Operations.ROOT)
            {
                localResult = Math.Pow(number1, 1.0 / num2);

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult = Math.Pow(number1, 1.0 / num2); ;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else
            {
                label1.Text += textBox1.Text;
                SetTotalResult(num2, lastOperation);
            }

            textBox1.Text = totalResult.ToString();
            shouldResetNumber = true;

            lastOperation = Operations.SUBTRACT;
            operationsList.Add(lastOperation);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBox1.Text);

            number1 = Convert.ToDouble(textBox1.Text);
            SetTextInLabel("/");

            label1.Text += textBox1.Text;

            if (lastOperation == Operations.ADD || lastOperation == Operations.SUBTRACT || lastOperation == Operations.POW || lastOperation == Operations.ROOT)
            {

            }
            else
            {
                SetTotalResult(num2, lastOperation);
                textBox1.Text = totalResult.ToString();
                shouldResetNumber = true;
            }

            lastOperation = Operations.DIVIDE;
            operationsList.Add(lastOperation);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBox1.Text);

            number1 = Convert.ToDouble(textBox1.Text);
            SetTextInLabel("*");

            label1.Text += textBox1.Text;

            if (lastOperation == Operations.ADD || lastOperation == Operations.SUBTRACT || lastOperation == Operations.POW || lastOperation == Operations.ROOT)
            {

            }
            else
            {
                SetTotalResult(num2, lastOperation);
                textBox1.Text = totalResult.ToString();
                shouldResetNumber = true;
            }

            lastOperation = Operations.MULTIPLY;
            operationsList.Add(lastOperation);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            equalButtonClicked = true;

            double num2 = Convert.ToDouble(textBox1.Text);

            if (lastOperation == Operations.MULTIPLY)
            {
                localResult = number1 * num2;

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult *= num2;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else if (lastOperation == Operations.DIVIDE)
            {
                localResult = number1 / num2;

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult /= num2;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else if (lastOperation == Operations.POW)
            {
                localResult = Math.Pow(number1, num2);

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult = Math.Pow(number1, num2); ;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else if (lastOperation == Operations.ROOT)
            {
                localResult = Math.Pow(number1, 1.0 / num2);

                if (operationsList.Count > 1)
                {
                    if (operationsList[operationsList.Count - 2] == Operations.ADD)
                    {
                        totalResult += localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.SUBTRACT)
                    {
                        totalResult -= localResult;
                    }
                    else if (operationsList[operationsList.Count - 2] == Operations.MULTIPLY || operationsList[operationsList.Count - 2] == Operations.DIVIDE)
                    {
                        totalResult = Math.Pow(number1, 1.0 / num2); ;
                    }
                }
                else
                {
                    totalResult = localResult;
                }
            }
            else
            {
                label1.Text += textBox1.Text;
                SetTotalResult(num2, lastOperation);
            }

            textBox1.Text = totalResult.ToString();
            shouldResetNumber = true;

            label1.Text = string.Empty;

            localResult = 0;
            totalResult = 0;
            lastOperation = Operations.NONE;
            operationsList.Clear();
        }

        private void btnNeg_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                if (textBox1.Text[0] == '-')
                {
                    textBox1.Text = textBox1.Text.Replace("-", "");
                }
                else
                {
                    textBox1.Text = textBox1.Text.Insert(0, "-");
                }
            }

        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            number1 = 0;
            number2 = 0;
            localResult = 0;
            totalResult = 0;
            lastOperation = Operations.NONE;
            operationsList.Clear();

            label1.Text = string.Empty;
            textBox1.Text = "0";

            equalButtonClicked = false;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);

            label1.Text += " sqrt(" + num.ToString() + ")";

            textBox1.Text = Math.Sqrt(num).ToString();
        }

        private void btnX2_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);

            label1.Text += " sqr(" + num.ToString() + ")";

            textBox1.Text = (num * num).ToString();
        }

        private double Fact(double number)
        {
            double result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        private void btnNFact_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);

            label1.Text += " fact(" + num.ToString() + ")";

            textBox1.Text = Fact(num).ToString();
        }

        private void btnX3_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);

            label1.Text += " cube(" + num.ToString() + ")";

            textBox1.Text = (num * num * num).ToString();
        }



        private void btn10X_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);

            label1.Text += " powten(" + num.ToString() + ")";

            textBox1.Text = Math.Pow(10, num).ToString();
        }



        private void btnLog_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);

            label1.Text += " log(" + num.ToString() + ")";

            textBox1.Text = Math.Log10(num).ToString();
        }

        private void btnSqr3X_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);

            label1.Text += " cuberoot(" + num.ToString() + ")";

            textBox1.Text = Math.Pow(num, 1.0 / 3.0).ToString();
        }

        private void btnRev_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);

            label1.Text += " reciproc(" + num.ToString() + ")";

            textBox1.Text = (1.0 / num).ToString();
        }



        private void btnInv_Click(object sender, EventArgs e)
        {
            if (!isInv)
            {
                EnableInv();
            }
            else
            {
                DisableInv();
            }
        }

        private void EnableInv()
        {
            isInv = true;
            btnInv.BackColor = Color.Orange;

            btnLnEx.Text = "eˣ";
            btnIntFrac.Text = "Frac";
            btnSinhArcsinh.Text = "sinh⁻¹";
            btnSinArcsin.Text = "sin⁻¹";
            btnDmsDeg.Text = "deg";
            btnCoshArccosh.Text = "cosh⁻¹";
            btnCosArccos.Text = "cos⁻¹";
            btnPI2PI.Text = "2*π";
            btnTanhArctanh.Text = "tanh⁻¹";
            btnTanArctan.Text = "tan⁻¹";
            btnSecArcsec.Text = "sec⁻¹";
            btnCosecArccosec.Text = "cosec⁻¹";
        }
        private void DisableInv()
        {
            isInv = false;
            btnInv.BackColor = Color.Transparent;

            btnLnEx.Text = "ln";
            btnIntFrac.Text = "Int";
            btnSinhArcsinh.Text = "sinh";
            btnSinArcsin.Text = "sin";
            btnDmsDeg.Text = "dms";
            btnCoshArccosh.Text = "cosh";
            btnCosArccos.Text = "cos";
            btnPI2PI.Text = "π";
            btnTanhArctanh.Text = "tanh";
            btnTanArctan.Text = "tan";
            btnSecArcsec.Text = "sec";
            btnCosecArccosec.Text = "cosec";
        }

        private void btnLnEx_Click(object sender, EventArgs e)
        {
            if (btnLnEx.Text == "ln")
            {
                double num = Convert.ToDouble(textBox1.Text);

                label1.Text += " ln(" + num.ToString() + ")";

                textBox1.Text = Math.Log(num, Math.E).ToString();
            }
            else if (btnLnEx.Text == "eˣ")
            {
                double num = Convert.ToDouble(textBox1.Text);

                label1.Text += " powe(" + num.ToString() + ")";

                textBox1.Text = Math.Pow(Math.E, num).ToString();
            }
        }

        private void btnIntFrac_Click(object sender, EventArgs e)
        {
            double doubleNum = Convert.ToDouble(textBox1.Text);
            int intNum = (int)doubleNum;

            if (btnIntFrac.Text == "Int")
            {
                label1.Text += " Int(" + doubleNum.ToString() + ")";

                textBox1.Text = intNum.ToString();
            }
            else if (btnIntFrac.Text == "Frac")
            {
                label1.Text += " frac(" + doubleNum.ToString() + ")";

                textBox1.Text = (doubleNum - intNum).ToString();
            }
        }

        private void btnSinhArcsinh_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            double result = 0;

            if (btnSinhArcsinh.Text == "sinh")
            {
                label1.Text += " sinh(" + num.ToString() + ")";
                result = Math.Sinh(num);
            }
            else if (btnSinhArcsinh.Text == "sinh⁻¹")
            {
                label1.Text += " asinh(" + num.ToString() + ")";
                result = Math.Log(num + Math.Sqrt(num * num + 1), Math.E);
            }
            textBox1.Text = result.ToString();
        }

        private void btnSinArcsin_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            double result = 0;

            if (btnSinArcsin.Text == "sin")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " sin(" + num.ToString() + ")";
                    result = Math.Sin(num * Math.PI / 180);
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " sinr(" + num.ToString() + ")";
                    result = Math.Sin(num);
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " sing(" + num.ToString() + ")";
                    result = Math.Sin(num * Math.PI / 200);
                }
            }
            else if (btnSinArcsin.Text == "sin⁻¹")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " asind(" + num.ToString() + ")";
                    result = Math.Asin(num) * 180 / Math.PI;
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " asinr(" + num.ToString() + ")";
                    result = Math.Asin(num);
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " asing(" + num.ToString() + ")";
                    result = Math.Asin(num) * 200 / Math.PI;
                }
            }
            textBox1.Text = result.ToString();
        }

        private void btnCosArccos_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            double result = 0;

            if (btnCosArccos.Text == "cos")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " cos(" + num.ToString() + ")";
                    result = Math.Cos(num * Math.PI / 180);
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " cosr(" + num.ToString() + ")";
                    result = Math.Cos(num);
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " cosg(" + num.ToString() + ")";
                    result = Math.Cos(num * Math.PI / 200);
                }
            }
            else if (btnCosArccos.Text == "cos⁻¹")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " acosd(" + num.ToString() + ")";
                    result = Math.Acos(num) * 180 / Math.PI;
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " acosr(" + num.ToString() + ")";
                    result = Math.Acos(num);
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " acosg(" + num.ToString() + ")";
                    result = Math.Acos(num) * 200 / Math.PI;
                }
            }
            textBox1.Text = result.ToString();
        }

        private void btnTanArctan_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            double result = 0;

            if (btnTanArctan.Text == "tan")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " tan(" + num.ToString() + ")";
                    result = Math.Tan(num * Math.PI / 180);
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " tanr(" + num.ToString() + ")";
                    result = Math.Tan(num);
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " tang(" + num.ToString() + ")";
                    result = Math.Tan(num * Math.PI / 200);
                }
            }
            else if (btnTanArctan.Text == "tan⁻¹")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " atand(" + num.ToString() + ")";
                    result = Math.Atan(num) * 180 / Math.PI;
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " atanr(" + num.ToString() + ")";
                    result = Math.Atan(num);
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " atang(" + num.ToString() + ")";
                    result = Math.Atan(num) * 200 / Math.PI;
                }
            }
            textBox1.Text = result.ToString();
        }

        private void btnPI2PI_Click(object sender, EventArgs e)
        {
            if (btnPI2PI.Text == "π")
            {
                textBox1.Text = Math.PI.ToString();
            }
            else if (btnPI2PI.Text == "2*π")
            {
                textBox1.Text = (2 * Math.PI).ToString();
            }
        }

        private void btnCoshArccosh_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            double result = 0;

            if (btnCoshArccosh.Text == "cosh")
            {
                label1.Text += " cosh(" + num.ToString() + ")";
                result = Math.Cosh(num);
            }
            else if (btnCoshArccosh.Text == "cosh⁻¹")
            {
                label1.Text += " acosh(" + num.ToString() + ")";
                result = Math.Log(num + Math.Sqrt(num * num - 1), Math.E);
            }
            textBox1.Text = result.ToString();
        }

        private void btnTanhArctanh_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            double result = 0;

            if (btnTanhArctanh.Text == "tanh")
            {
                label1.Text += " tanh(" + num.ToString() + ")";
                result = Math.Tanh(num);
            }
            else if (btnTanhArctanh.Text == "tanh⁻¹")
            {
                label1.Text += " atanh(" + num.ToString() + ")";
                result = 0.5 * Math.Log((1 + num) / (1 - num), Math.E);
            }
            textBox1.Text = result.ToString();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textInClipboard = textBox1.Text;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = textInClipboard;
        }

        private void btnMS_Click(object sender, EventArgs e) // memory save
        {
            memory = Convert.ToDouble(textBox1.Text);
            lblMemory.Text = "M";
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            textBox1.Text = memory.ToString();
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memory = 0;
            lblMemory.Text = string.Empty;
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            memory += num;
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            memory -= num;
        }

        private void btnFE_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
            {
                if (isFE == false)
                {
                    isFE = true;
                    btnFE.BackColor = Color.Orange;

                    double num = Convert.ToDouble(textBox1.Text);
                    double result = 0;
                    double counter = 0;

                    if (num > 1)
                    {
                        result = num;
                        counter = 0;
                        while (result >= 10)
                        {
                            result /= 10;
                            counter++;
                        }

                        textBox1.Text = result + "e+" + counter;
                    }
                    else
                    {
                        result = num;
                        counter = 0;
                        while (result <= 1)
                        {
                            result *= 10;
                            counter++;
                        }

                        textBox1.Text = result + "e-" + counter;
                    }
                }
                else
                {
                    isFE = false;
                    btnFE.BackColor = SystemColors.Control;

                    string[] splitter = { "e" };
                    string[] numbersArray = textBox1.Text.Split(splitter, StringSplitOptions.RemoveEmptyEntries);

                    double num = Convert.ToDouble(numbersArray[0]);
                    int pow = Convert.ToInt32(numbersArray[1]);

                    double result = num * Math.Pow(10, pow);
                    textBox1.Text = result.ToString();
                }
            }

        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            textBox1.Text += "e+";
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBox1.Text);

            SetTextInLabel("Mod");

            label1.Text += textBox1.Text;
            SetTotalResult(num2, lastOperation);

            textBox1.Text = totalResult.ToString();
            shouldResetNumber = true;

            lastOperation = Operations.MOD;
            operationsList.Add(lastOperation);
        }

        private void btnDmsDeg_Click(object sender, EventArgs e)
        {
            double input = Convert.ToDouble(textBox1.Text);

            int degree = 0;
            int minute = 0;
            int second = 0;

            double decimalDegree;

            if (btnDmsDeg.Text == "dms")
            {
                decimalDegree = input;

                degree = (int)decimalDegree;
                minute = (int)((decimalDegree - degree) * 60);
                second = (int)((decimalDegree - degree - minute / 60) * 3600);

                label1.Text += " dms(" + input.ToString() + ")";
                textBox1.Text = degree.ToString() + "." + minute.ToString() + second.ToString();
            }
            else if (btnDmsDeg.Text == "deg")
            {
                degree = (int)input;
                minute = (int)((input - degree) * 100);
                second = (int)((((input - degree) * 100) - minute) * 100);

                decimalDegree = degree + minute / 60.0 + second / 3600.0;

                label1.Text += " degress(" + input.ToString() + ")";
                textBox1.Text = decimalDegree.ToString();
            }
        }

        private void btnParOpen_Click(object sender, EventArgs e)
        {
            //label1.Text += "(";
        }

        private void btnParClose_Click(object sender, EventArgs e)
        {
            //SetTextInLabel(")");
        }

        private void btnXY_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBox1.Text);

            number1 = Convert.ToDouble(textBox1.Text);
            SetTextInLabel("^");

            label1.Text += textBox1.Text;

            if (lastOperation == Operations.ADD || lastOperation == Operations.SUBTRACT || lastOperation == Operations.POW || lastOperation == Operations.ROOT)
            {

            }
            else
            {
                SetTotalResult(num2, lastOperation);
                textBox1.Text = totalResult.ToString();
                shouldResetNumber = true;
            }

            lastOperation = Operations.POW;
            operationsList.Add(lastOperation);
        }

        private void btnSqrYX_Click(object sender, EventArgs e)
        {
            double num2 = Convert.ToDouble(textBox1.Text);

            number1 = Convert.ToDouble(textBox1.Text);
            SetTextInLabel("yroot");

            label1.Text += textBox1.Text;

            if (lastOperation == Operations.ADD || lastOperation == Operations.SUBTRACT || lastOperation == Operations.POW || lastOperation == Operations.ROOT)
            {

            }
            else
            {
                SetTotalResult(num2, lastOperation);
                textBox1.Text = totalResult.ToString();
                shouldResetNumber = true;
            }

            lastOperation = Operations.ROOT;
            operationsList.Add(lastOperation);
        }

        private void btnSecArcsec_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            double result = 0;

            if (btnSecArcsec.Text == "sec")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " sec(" + num.ToString() + ")";
                    result = 1 / Math.Cos(num * Math.PI / 180);
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " secr(" + num.ToString() + ")";
                    result = 1 / Math.Cos(num);
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " secg(" + num.ToString() + ")";
                    result = 1 / Math.Cos(num * Math.PI / 200);
                }
            }
            else if (btnSinArcsin.Text == "sec⁻¹")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " asecd(" + num.ToString() + ")";
                    result = (Math.Atan(num / Math.Sqrt(num * num - 1)) + Math.Sign(num - 1) * (2 * Math.Atan(1))) * 180 / Math.PI;                    
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " asecr(" + num.ToString() + ")";
                    result = Math.Atan(num / Math.Sqrt(num * num - 1)) + Math.Sign(num - 1) * (2 * Math.Atan(1));
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " asecg(" + num.ToString() + ")";
                    result = (Math.Atan(num / Math.Sqrt(num * num - 1)) + Math.Sign(num - 1) * (2 * Math.Atan(1))) * 200 / Math.PI;                    
                }
            }
            textBox1.Text = result.ToString();
        }

        private void btnCosecArccosec_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(textBox1.Text);
            double result = 0;

            if (btnSecArcsec.Text == "cosec")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " cosec(" + num.ToString() + ")";
                    result = 1 / Math.Sin(num * Math.PI / 180);
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " cosecr(" + num.ToString() + ")";
                    result = 1 / Math.Sin(num);
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " cosecg(" + num.ToString() + ")";
                    result = 1 / Math.Sin(num * Math.PI / 200);
                }
            }
            else if (btnSinArcsin.Text == "cosec⁻¹")
            {
                if (rbnDeg.Checked == true)
                {
                    label1.Text += " acosecd(" + num.ToString() + ")";
                    result = (Math.Atan(num / Math.Sqrt(num * num - 1)) + Math.Sign(num - 1) * (2 * Math.Atan(1))) * 180 / Math.PI;
                }
                else if (rbnRad.Checked == true)
                {
                    label1.Text += " acosecr(" + num.ToString() + ")";
                    result = Math.Atan(num / Math.Sqrt(num * num - 1)) + Math.Sign(num - 1) * (2 * Math.Atan(1));
                }
                else if (rbnGrad.Checked == true)
                {
                    label1.Text += " acosecg(" + num.ToString() + ")";
                    result = (Math.Atan(num / Math.Sqrt(num * num - 1)) + Math.Sign(num - 1) * (2 * Math.Atan(1))) * 200 / Math.PI;
                }
            }
            textBox1.Text = result.ToString();
        }
    }
}
