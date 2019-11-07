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

        double result = 0;
        string operation = "";
        bool operationDone = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //will clear everyting from textBox
        private void C_Click(object sender, EventArgs e)
        {
            textBox_result.Clear();
            textBox_result.Text = "0";
        }

        //will clear everyting from the whole content
        private void cE_Click(object sender, EventArgs e)
        {
            textBox_result.Clear();
            result = 0;
        }

        //handels the click of buttons, whatever button in clicked it print it to the textBox,
        //and if the text in the tesxtBox is 0 nad the operation is done then it will clear the textBox for furtehr operations.
        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox_result.Text == "0") || (operationDone))
            {
                textBox_result.Clear();
            }
            ///a function for decimal points......

            operationDone = false;
            Button button = (Button)sender;
            textBox_result.Text = textBox_result.Text + button.Text;
        }

        //handels all the operations e.g. + ,- , * , / etc.
        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;
            result = double.Parse(textBox_result.Text);
            operationDone = true;
        }

        //switch will act according to the functions given to the specific type of patter that I have in the text of my buttons. 
        //whatever functionality we put on the pattern, switch carries that pattern with it's functionality.
        //so like, switch will work on my operator_clicks.
        private void equals_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                //Add
                case "+":
                    textBox_result.Text = (result + double.Parse(textBox_result.Text)).ToString();
                    break;

                //Subtract
                case "-":
                    textBox_result.Text = (result - double.Parse(textBox_result.Text)).ToString();
                    break;

                //Product
                case "×":
                    textBox_result.Text = (result * double.Parse(textBox_result.Text)).ToString();
                    break;

                //Divide
                case "/":
                    textBox_result.Text = (result / double.Parse(textBox_result.Text)).ToString();
                    break;

                //Sqaure
                case "x^2":
                    double sq = Math.Pow(result, 2);
                    textBox_result.Text = sq.ToString();
                    break;

                //Power
                //edit this so it uses the second number as a power
                case "x^a":
                    //int secondVal;
                    double power = Math.Pow(result, 5);
                    textBox_result.Text = power.ToString();
                    break;

                //SquareRoot
                case "√x":
                    double sqrt = Math.Sqrt(result);
                    textBox_result.Text = sqrt.ToString();
                    break;

                //Convert To Binary
                case "Convert To Binary":
                    
                    int input = int.Parse(textBox_result.Text);
                    textBox_result.Text = ConvertToBinary(input);
                    break;

                //From Binary to Integer
                case "Integer from Binary":
                    textBox_result.Text = ConvertToInteger(textBox_result.Text);
                    break;
         
                default:
                    break;
            }
        }

        public string ConvertToBinary(int input)
        {
            string binaryResult = "";
            while (input >= 1)
            {
                double remainder = input % 2;
                binaryResult = remainder + binaryResult;
                input = input / 2;
            }
            return binaryResult;
        }
        public string ConvertToInteger(string binaryInput)
        {
            var result = Convert.ToInt32(binaryInput, 2).ToString();
            return result;
        }

    }
}
