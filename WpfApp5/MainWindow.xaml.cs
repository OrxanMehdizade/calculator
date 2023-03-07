using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private string currentInput = "";
        private string lastOperator = "";
        private double lastNumber = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Content.ToString();
            ResultBox.Text = currentInput;
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (currentInput != "")
            {
                if (lastOperator != "")
                {
                    lastNumber = Calculate(lastNumber, double.Parse(currentInput), lastOperator);
                    ResultBox.Text = lastNumber.ToString();
                }
                else
                {
                    lastNumber = double.Parse(currentInput);
                }
                currentInput = "";
#pragma warning disable CS8601 // Possible null reference assignment.
                lastOperator = button.Content.ToString();
#pragma warning restore CS8601 // Possible null reference assignment.
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (currentInput != "" && lastOperator != "")
            {
                lastNumber = Calculate(lastNumber, double.Parse(currentInput), lastOperator);
                ResultBox.Text = lastNumber.ToString();
                currentInput = "";
                lastOperator = "";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            currentInput = "";
            lastOperator = "";
            lastNumber = 0.0;
            ResultBox.Text = "";
        }

        private double Calculate(double num1, double num2, string op)
        {
            switch (op)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    if (num2 == 0.0)
                    {
                        MessageBox.Show("Error: Cannot divide by zero");
                        return 0.0;
                    }
                    return num1 / num2;
                default:
                    MessageBox.Show("Error: Invalid operator");
                    return 0.0;
            }
        }
    }
}
