using System;

namespace GorselProg
{
    public partial class ScientificPage : ContentPage
    {
        double number1 = 0;
        double number2 = 0;
        string operatorSymbol = "";
        bool isOperationClicked = false;

        public ScientificPage()
        {
            InitializeComponent();
        }

        private void Num_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (sciScreen.Text == "0" || isOperationClicked)
            {
                sciScreen.Text = "";
                isOperationClicked = false;
            }
            sciScreen.Text += btn.Text;
        }

        private void Operator_Clicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            number1 = double.Parse(sciScreen.Text);
            operatorSymbol = btn.Text;
            lblHistorySci.Text = $"{number1} {operatorSymbol}";
            isOperationClicked = true;
        }

        private void Equal_Clicked(object sender, EventArgs e)
        {
            try
            {
                number2 = double.Parse(sciScreen.Text);
                double result = 0;

                switch (operatorSymbol)
                {
                    case "+":
                        result = number1 + number2;
                        break;
                    case "-":
                    case "?":
                        result = number1 - number2;
                        break;
                    case "×":
                        result = number1 * number2;
                        break;
                    case "÷":
                        if (number2 == 0)
                            throw new DivideByZeroException();
                        result = number1 / number2;
                        break;
                    case "x?":
                        result = Math.Pow(number1, number2);
                        break;
                }

                lblHistorySci.Text = $"{number1} {operatorSymbol} {number2} =";
                sciScreen.Text = result.ToString();
                number1 = result;
                isOperationClicked = true;
            }
            catch (DivideByZeroException)
            {
                sciScreen.Text = "Sýfýra bölünemez";
            }
            catch
            {
                sciScreen.Text = "Hata";
            }
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            sciScreen.Text = "0";
            lblHistorySci.Text = "";
            number1 = 0;
            number2 = 0;
            operatorSymbol = "";
            isOperationClicked = false;
        }

        private void BackSpaceClicked(object sender, EventArgs e)
        {
            if (sciScreen.Text.Length > 1)
                sciScreen.Text = sciScreen.Text[..^1];
            else
                sciScreen.Text = "0";
        }

        private void Square_Clicked(object sender, EventArgs e)
        {
            try
            {
                number1 = double.Parse(sciScreen.Text);
                double result = number1 * number1;
                lblHistorySci.Text = $"{number1}² =";
                sciScreen.Text = result.ToString();
            }
            catch
            {
                sciScreen.Text = "Hata";
            }
        }

        private void Sqrt_Clicked(object sender, EventArgs e)
        {
            try
            {
                number1 = double.Parse(sciScreen.Text);
                if (number1 < 0)
                    throw new Exception();
                double result = Math.Sqrt(number1);
                lblHistorySci.Text = $"?({number1}) =";
                sciScreen.Text = result.ToString();
            }
            catch
            {
                sciScreen.Text = "Geçersiz iþlem";
            }
        }

        private void Power_Clicked(object sender, EventArgs e)
        {
            number1 = double.Parse(sciScreen.Text);
            operatorSymbol = "x?";
            lblHistorySci.Text = $"{number1} ^";
            isOperationClicked = true;
        }

        private void Log_Clicked(object sender, EventArgs e)
        {
            try
            {
                number1 = double.Parse(sciScreen.Text);
                if (number1 <= 0)
                    throw new Exception();
                double result = Math.Log10(number1);
                lblHistorySci.Text = $"log({number1}) =";
                sciScreen.Text = result.ToString();
            }
            catch
            {
                sciScreen.Text = "Geçersiz iþlem";
            }
        }

        private void Ln_Clicked(object sender, EventArgs e)
        {
            try
            {
                number1 = double.Parse(sciScreen.Text);
                if (number1 <= 0)
                    throw new Exception();
                double result = Math.Log(number1);
                lblHistorySci.Text = $"ln({number1}) =";
                sciScreen.Text = result.ToString();
            }
            catch
            {
                sciScreen.Text = "Geçersiz iþlem";
            }
        }

        private void Sin_Clicked(object sender, EventArgs e)
        {
            number1 = double.Parse(sciScreen.Text);
            double result = Math.Sin(number1 * Math.PI / 180);
            lblHistorySci.Text = $"sin({number1}) =";
            sciScreen.Text = result.ToString();
        }

        private void Cos_Clicked(object sender, EventArgs e)
        {
            number1 = double.Parse(sciScreen.Text);
            double result = Math.Cos(number1 * Math.PI / 180);
            lblHistorySci.Text = $"cos({number1}) =";
            sciScreen.Text = result.ToString();
        }

        private void Tan_Clicked(object sender, EventArgs e)
        {
            number1 = double.Parse(sciScreen.Text);
            double result = Math.Tan(number1 * Math.PI / 180);
            lblHistorySci.Text = $"tan({number1}) =";
            sciScreen.Text = result.ToString();
        }
    }
}
