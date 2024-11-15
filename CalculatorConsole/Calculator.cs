using System;
using System.Data;

namespace BasicApp.CalculatorConsole;

public class Calculator
{
    public static void SimpleCalculatorInputs()
    {
        Console.Title = "Simple Calculator";
        Console.WriteLine("======THE SIMPLE ARITHMETIC CALCULATOR=====");

        try
        {
            bool flag = true;

            do
            {
                Console.Write("Enter your first number: ");
                double firstInput = ConvertInputToNumeric(Console.ReadLine());

                Console.Write("Enter your operator: ");
                string arithmeticOperator = Console.ReadLine();

                Console.Write("Enter your second number: ");
                double secondInput = ConvertInputToNumeric(Console.ReadLine());

                double output = CalculatorEngine(firstInput, secondInput, arithmeticOperator);

                Console.WriteLine($"Result is = {output}");

                string continueOption = string.Empty;

                do
                {
                    Console.Write("Do you want to continue Y/N: ");
                    continueOption = Console.ReadLine();

                } while (continueOption != "y" && continueOption != "n");

                flag = continueOption == "y";

            } while (flag);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ExpressionCalculatorInputs()
    {
        Console.Title = "Advanced Calculator";
        Console.WriteLine("======THE ADVANCED EXPRESSION CALCULATOR=====");

        try
        {
            bool flag = true;

            do
            {
                Console.Write("Enter your expression (e.g., 2 + 2 * 5 / 10): ");
                string expression = Console.ReadLine();

                double output = EvaluateExpression(expression);

                Console.WriteLine($"Result is = {output}");

                string continueOption = string.Empty;

                do
                {
                    Console.Write("Do you want to continue Y/N: ");
                    continueOption = Console.ReadLine().ToLower();

                } while (continueOption != "y" && continueOption != "n");

                flag = continueOption == "y";

            } while (flag);

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static double CalculatorEngine(double argNumber1, double argNumber2, string argOperation)
    {
        var result = argOperation.ToLower() switch
        {
            "add" or "+" => argNumber1 + argNumber2,
            "minus" or "-" => argNumber1 - argNumber2,
            "multiply" or "*" => argNumber1 * argNumber2,
            "divide" or "/" => argNumber1 / argNumber2,
            "modulo" or "%" => argNumber1 % argNumber2,
            _ => throw new InvalidOperationException("Operator not recognized!"),
        };
        return result;
    }

    private static double ConvertInputToNumeric(string argInput)
    {
        if (!double.TryParse(argInput, out double convertedNumber))
        {
            throw new FormatException("Expected a numeric value");
        }

        return convertedNumber;
    }

    private static double EvaluateExpression(string expression)
    {
        try
        {
            // Using DataTable to evaluate expression with BODMAS
            DataTable table = new();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            double result = double.Parse((string)row["expression"]);
            return result;
        }
        catch
        {
            throw new InvalidOperationException("Invalid expression entered!");
        }
    }
}

