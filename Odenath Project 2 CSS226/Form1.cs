using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odenath_Project_2_CSS226
{
    public partial class Form1 : Form
    {

        public String[] NUM // Numbers on the calculator
            = {"0","2","3","4","5","6","7","8","9","0"};
        public String[] BTN_NUM_NAMES // Names of number buttons
            = { "btn_0", "btn_1", "btn_2", "btn_3", "btn_4", 
                  "btn_5", "btn_6", "btn_7", "btn_8", "btn_9" };
        public String[] BTN_OPER_NAMES // Names of operator buttons
            = { "btnEquals", "btnAddition", "btnSubtraction",
                    "btnMultiplication", "btnDivision" };

        public const String DECIMAL = ".";

        private enum OPERATION { equ, add, sub, mul, div, none };

        private int calcOperation;


        private double placeHolder;

        public Form1()
        {
            InitializeComponent();
            resetCalculator();
        }

        public void resetCalculator()
        {
            clearConsole();
            clearValues();
        }

        private void clearConsole()
        {
            txtConsole.Text = NUM[0];
        }

        private void clearValues()
        {
            placeHolder = 0;
            calcOperation = (int)OPERATION.none;
        }

        private bool isClearPlaceHolder()
        {
            return placeHolder == 0;
        }

        private bool isClearConsole()
        {
            return (txtConsole.Text.Equals(NUM[0]) || calcOperation != (int)OPERATION.none);
        }

        private bool isDecimalPresent()
        {
            return txtConsole.Text.Contains(DECIMAL);
        }

        private double getConsoleToNumeric()
        {
            return Convert.ToDouble(txtConsole.Text);
        }

        private void operateValues(int operation)
        {
            calcOperation = operation;

            if (isClearPlaceHolder())
            {
                placeHolder = getConsoleToNumeric();
                return;
            }
            switch (calcOperation)
            {
                case 1:
                    {
                        txtConsole.Text = (placeHolder += getConsoleToNumeric()).ToString();
                        break;
                    }
                case 2:
                    {
                        txtConsole.Text = (placeHolder -= getConsoleToNumeric()).ToString();
                        break;
                    }
                case 3:
                    {
                        txtConsole.Text = (placeHolder *= getConsoleToNumeric()).ToString();
                        break;
                    }
                case 4:
                    {
                        txtConsole.Text = (placeHolder /= getConsoleToNumeric()).ToString();
                        break;
                    }
                default:
                    {
                        Console.Out.WriteLine("Error: undefined calculation - " + calcOperation);
                        break;
                    }
            }

            getConsoleToNumeric();
        }

        private void appendConsole(String content)
        {
            if (isClearConsole())
            {
                if (content.Equals(NUM[0]))
                {
                    return;
                }
                else if (content.Equals(DECIMAL))
                {
                    txtConsole.Text += content;
                }
                else
                {
                    txtConsole.Text = content;
                }
            }
            else
            {
                if (content.Equals(DECIMAL) && isDecimalPresent())
                { 
                    return; 
                }
                txtConsole.Text += content;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetCalculator();
        }

        private void btnSecret_Click(object sender, EventArgs e)
        {
            if (sender.Equals(btnSecret))
            txtConsole.Text = (5318008).ToString();
        }

        private void btnNumClick(object sender, EventArgs e) 
        {
            //Console.Out.Write("asd");
            if (sender.GetType().IsAssignableFrom(new Button().GetType()))
            {
                Button temp = (Button)sender;
                //appendConsole(temp.Text);

                for (int i = 0; i < BTN_NUM_NAMES.Length; i++)
                {
                    if (temp.Name.Equals(BTN_NUM_NAMES[i]))
                    {
                        appendConsole(i.ToString());
                        break;
                    }
                }

            }

        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            appendConsole(DECIMAL);
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            if (sender.GetType().IsAssignableFrom(new Button().GetType()))
            {
                Button temp = (Button)sender;
                //appendConsole(temp.Text);

                if (temp.Name.Equals(BTN_OPER_NAMES[0])) //EQUALS
                {
                    operateValues(calcOperation);
                }
                else if (temp.Name.Equals(BTN_OPER_NAMES[1])) //ADDITION
                {
                    operateValues((int)OPERATION.add);
                }
                else if (temp.Name.Equals(BTN_OPER_NAMES[2])) //SUBTRACTION
                {
                    operateValues((int)OPERATION.sub);
                }
                else if (temp.Name.Equals(BTN_OPER_NAMES[3])) //MULTIPLICATION
                {
                    operateValues((int)OPERATION.mul);
                }
                else if (temp.Name.Equals(BTN_OPER_NAMES[4])) //DIVISION
                {
                    operateValues((int)OPERATION.div);
                }
                else 
                { 
                    Console.Out.WriteLine("DUN GOOFED OPERATION"); 
                }

            
            }
        }

        
    }
}
