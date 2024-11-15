using System;

namespace BasicApp.CalculatorConsole;

public class CalculatorMenu
{
    private readonly WageCalculator wageCalculator = new();

    public void CalculatorMainMenu()
    {
        var flag = true;

        while (flag)
        {
            PrintMenu();
            Console.Write("\nPlease enter your option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    string result = wageCalculator.PaymentCalculations();
                    Console.WriteLine(result);
                    break;
                case "2":
                    Calculator.SimpleCalculatorInputs();
                    break;
                case "3":
                    Calculator.ExpressionCalculatorInputs();
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    throw new InvalidOperationException("Invalid selection!");
            }
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("Enter 1 to Access Wages Calculator");
        Console.WriteLine("Enter 2 to Access Simple Arithmetic Calculator");
        Console.WriteLine("Enter 3 to Access Expression Calculator");
        Console.WriteLine("Enter 0 to Go back to main menu");
    }
}
