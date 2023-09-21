using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{

    public partial class MainPage : ContentPage
    {
        private string currentInput = string.Empty;
        private double firstNumber = 0;
        private string selectedOperator = string.Empty;
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnNumberClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            resultEntry.Text = currentInput;
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            selectedOperator = button.Text;
            if (!string.IsNullOrEmpty(currentInput))
            {
                firstNumber = double.Parse(currentInput);
                currentInput = string.Empty;
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            currentInput = string.Empty;
            firstNumber = 0;
            selectedOperator = string.Empty;
            resultEntry.Text = string.Empty;
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentInput) && !string.IsNullOrEmpty(selectedOperator))
            {
                double secondNumber = double.Parse(currentInput);
                double result = 0;

                switch (selectedOperator)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                            result = firstNumber / secondNumber;
                        else
                            resultEntry.Text = "Error";
                        break;
                }

                resultEntry.Text = result.ToString();
                currentInput = result.ToString();
            }
        }
    }
}
