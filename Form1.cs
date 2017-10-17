using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercise1
{
    public partial class Calculator : Form
    {
        string num1 = ""; // initiate first value
        string num2 = ""; // initiate second value
        bool judge = false; // judge weither there are two values to calculate
        int op = 0; // inititate operator
        string result = "";

        public string InputClick(string a) // This function is used to add a single value byte
                                           // when click the certain button from 0 to 9 also "."
        {
           if(op == 0)
            {
                num1 += a;
                return num1;
            }
            else
            {
                num2 += a;
                judge = true;
                return num2;
            }
        }

        public void InputOprtator(int a) // function for press any operator button "+"/"-"/"*"/"/"
        {
            if(judge == true)
            {
                Calculate();
                num1 = result;
            }
            if(result != "")
            {
                num1 = result;
                result = "";
            }
            op = a;
        }

        public void Calculate()            // function for calculate
        {
            switch (op)
            {
                case 1:
                    result = (Convert.ToDouble(num1) + Convert.ToDouble(num2)).ToString();
                    break;
                case 2:
                    result = (Convert.ToDouble(num1) - Convert.ToDouble(num2)).ToString();
                    break;
                case 3:
                    result = (Convert.ToDouble(num1) * Convert.ToDouble(num2)).ToString();
                    break;
                case 4:
                    result = (Convert.ToDouble(num1) / Convert.ToDouble(num2)).ToString();
                    break;
            } // ok
            num1 = "";
            num2 = "";
            Monitor.Text = result.ToString(); // Show the calculation reult
            op = 0;
        }

        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void One_Click(object sender, EventArgs e)  // button 1
        {
            Monitor.Text = InputClick("1");
        }

        private void Two_Click(object sender, EventArgs e)  // button 2
        {
            Monitor.Text = InputClick("2");
        }

        private void Three_Click(object sender, EventArgs e)  // button 3
        {
            Monitor.Text = InputClick("3");
        }

        private void Four_Click(object sender, EventArgs e)  // button 4
        {
            Monitor.Text = InputClick("4");
        }

        private void Five_Click(object sender, EventArgs e)  // button 5
        {
            Monitor.Text = InputClick("5");
        }

        private void Six_Click(object sender, EventArgs e)  // button 6
        {
            Monitor.Text = InputClick("6");
        }

        private void Seven_Click(object sender, EventArgs e) // button 7
        {
            Monitor.Text = InputClick("7");
        }

        private void Eight_Click(object sender, EventArgs e)  // button 8
        {
            Monitor.Text = InputClick("8");
        }

        private void Nine_Click(object sender, EventArgs e)  // button 9
        {
            Monitor.Text = InputClick("9");
        }

        private void Zero_Click(object sender, EventArgs e)  // button 0
        {
            if(Monitor.Text == "" || Monitor.Text == "0")
            {
                Monitor.Text = "0"; // To avoid mutiple "0" showed on the screen
            }
            else
            {
                Monitor.Text = InputClick("0");
            }
            if (op == 4){ // To avoid 0 as divisor
                Monitor.Text = "";
                MessageBox.Show("divisor cannot be ‘0’ ");
            }
        }

        private void Point_Click(object sender, EventArgs e)  // button "."
        {
            if (Monitor.Text == "")
            {
                Monitor.Text = InputClick("0."); // if there no value in screen but press "." button, add "0." automatically
            }
            else
            {
                if(Monitor.Text.IndexOf(".") >= 1) // To limit only one point to assign to
                {
                    Monitor.Text = InputClick("");
                }
                else
                {
                    Monitor.Text = InputClick(".");
                }
            } // ok
        }

        private void Add_Click(object sender, EventArgs e)  // button "+"
        {
            InputOprtator(1);
        }

        private void Minus_Click(object sender, EventArgs e)  // button "-"
        {
            InputOprtator(2);
        }

        private void Multiple_Click(object sender, EventArgs e)  // button "*"
        {
            InputOprtator(3);
        }

        private void Divide_Click(object sender, EventArgs e)  // button "/"
        {
            InputOprtator(4);
        }

        private void Equal_Click(object sender, EventArgs e)  // button "="
        {
            if(judge == true)
            {
                Calculate();
                judge = false;
            }
            else
            {
                if (num2 != "")
                {
                    Monitor.Text = num2;
                }
                else if (num1 != "")
                {
                    Monitor.Text = num1;
                }
                else
                    Monitor.Text = "";
            }
        }
    }
}
