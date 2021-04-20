using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Z.Expressions;


namespace SimpleCalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            trunOffButtons();
        }

        string display = "";

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            display = "";
            CalculatorDisplay.Text = display;
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            if (display.Length > 0)
            {
                display = display.Substring(0, display.Length - 1);
                CalculatorDisplay.Text = display;
            }
        }

        private void BtnOff_Click(object sender, RoutedEventArgs e)
        {
            display = "";
            this.Close();
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            display += 7;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            display += 8;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            display += 9;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            display += 4;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            display += 5;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            display += 6;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            display += 1;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            display += 2;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            display += 3;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            display += ".";
            CalculatorDisplay.Text = display;
            BtnPoint.IsEnabled = false;
            trunOffButtons();
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            display += 0;
            CalculatorDisplay.Text = display;
            trunOnButtons();
        }

        private void BtnDiv_Click(object sender, RoutedEventArgs e)
        {
            display += "/";
            CalculatorDisplay.Text = display;

            BtnPoint.IsEnabled = true;

            trunOffButtons();
        }

        private void BtnMul_Click(object sender, RoutedEventArgs e)
        {
            display += "*";
            CalculatorDisplay.Text = display;

            BtnPoint.IsEnabled = true;

            trunOffButtons();
        }

        private void BtnSub_Click(object sender, RoutedEventArgs e)
        {
            display += "-";
            CalculatorDisplay.Text = display;

            BtnPoint.IsEnabled = true;

            trunOffButtons();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            display += "+";
            CalculatorDisplay.Text = display;

            BtnPoint.IsEnabled = true;

            trunOffButtons();
        }

        public string Filter_Equation(string equation)
        {
            for (int i = equation.Length - 1; i >= 0; i--)
            {
                if (equation[i] == '.')
                {
                    break;
                }

                else if (equation[i] == '+' || equation[i] == '-' || equation[i] == '*' || equation[i] == '/')
                {
                    equation += ".0";
                    break;
                }

                else { }
            }

            return equation;
        }
        private void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result(Filter_Equation(display));
            }

            catch(Exception ex)
            {
                MessageBox.Show("Something Went Wrong...", "Alert!!");
                throw ex;
            }
            
        }

        void trunOffButtons()
        {
            BtnMul.IsEnabled = false;
            BtnDiv.IsEnabled = false;
            BtnSub.IsEnabled = false;
            BtnAdd.IsEnabled = false;
            BtnResult.IsEnabled = false;
        }

        void trunOnButtons()
        {
            BtnMul.IsEnabled = true;
            BtnDiv.IsEnabled = true;
            BtnSub.IsEnabled = true;
            BtnAdd.IsEnabled = true;
            BtnResult.IsEnabled = true;
        }


        private void result(string equation)
        {
            decimal result = Eval.Execute<decimal>(equation);

            display = result.ToString();

            CalculatorDisplay.Text = display;
        }
    }
}
