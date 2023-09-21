using System;
using Xamarin.Forms;

namespace App1.Views
{
    public partial class AboutPage : ContentPage
    {
        private string currentInput = string.Empty;
        private double currentResult = 0;
        private char currentOperator = ' ';

        public AboutPage()
        {
            InitializeComponent();
        }

        private void OnNumberButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;
            currentInput += buttonText;

            // Accedemos al Entry utilizando el campo 'calculatorDisplay'
            calculatorDisplay.Text = currentInput;
        }

        private void OnOperatorButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;

            if (!string.IsNullOrEmpty(currentInput))
            {
                double inputValue = double.Parse(currentInput);
                currentResult = PerformOperation(currentResult, inputValue, currentOperator);
                currentOperator = buttonText[0];
                calculatorDisplay.Text = currentResult.ToString();
                currentInput = string.Empty;
            }
        }

        private void OnEqualsButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double inputValue = double.Parse(currentInput);
                currentResult = PerformOperation(currentResult, inputValue, currentOperator);
                calculatorDisplay.Text = currentResult.ToString();
                currentInput = string.Empty;
                currentOperator = ' ';
            }
        }

        private void OnClearButtonClicked(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            currentResult = 0;
            currentOperator = ' ';
            calculatorDisplay.Text = "0";
        }

        private double PerformOperation(double leftOperand, double rightOperand, char operation)
        {
            switch (operation)
            {
                case '+':
                    return leftOperand + rightOperand;
                case '-':
                    return leftOperand - rightOperand;
                case '*':
                    return leftOperand * rightOperand;
                case '/':
                    if (rightOperand != 0)
                        return leftOperand / rightOperand;
                    else
                        return double.NaN; // Handle division by zero
                default:
                    return rightOperand;
            }
        }
    }
}
