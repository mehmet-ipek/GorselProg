namespace GorselProg;

public partial class CalculatorPage : ContentPage
{
    double number1 = 0;
    double number2 = 0;
    string operatorSymbol = "";
    bool isOperationClicked = false;

    public CalculatorPage()
    {
        InitializeComponent();
    }

    private void NumClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        
        if (cScreen.Text == "0" || isOperationClicked)
        {
            cScreen.Text = "";
            isOperationClicked = false;
        }

        
        cScreen.Text += btn.Text;
    }

    private void OperatorClicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        number1 = double.Parse(cScreen.Text);
        operatorSymbol = btn.Text;

        
        lblHistory.Text = $"{number1} {operatorSymbol}";

        isOperationClicked = true;
    }

    private void EqualClicked(object sender, EventArgs e)
    {
        number2 = double.Parse(cScreen.Text);
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
            case "*":
            case "×": 
                result = number1 * number2;
                break;
            case "/":
            case "÷": 
                result = number1 / number2;
                break;
        }

      
        lblHistory.Text = $"{number1} {operatorSymbol} {number2} =";

        
        cScreen.Text = result.ToString();

        
        number1 = result;
        isOperationClicked = true;
    }

    private void Clear_Clicked(object sender, EventArgs e)
    {
        cScreen.Text = "0";
        lblHistory.Text = "";
        number1 = 0;
        number2 = 0;
        operatorSymbol = "";
        isOperationClicked = false;
    }

    private void Square_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        number1 = double.Parse(cScreen.Text);
        var result = number1 * number1;

        lblHistory.Text = $"{number1}² =";
        cScreen.Text = result.ToString();

        isOperationClicked = true;
    }

    private void BackSpaceClicked(object sender, EventArgs e)
    {
        if (cScreen.Text.Length > 1)
            cScreen.Text = cScreen.Text[..^1];
        else
            cScreen.Text = "0";
    }
}
