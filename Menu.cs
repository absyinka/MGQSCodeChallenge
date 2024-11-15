using System;
using BasicApp.CalculatorConsole;
using BasicApp.EmployeeConsole;
using BasicApp.Enums;
using BasicApp.Shared;

namespace BasicApp;

public class Menu
{
    private readonly EmployeeConsoleMenu employeeConsoleMenu = new();
    private readonly CalculatorMenu calculatorMenu = new();

    public void MainMenu()
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
                    employeeConsoleMenu.EmployeeMainMenu();
                    break;
                case "2":
                    calculatorMenu.CalculatorMainMenu();
                    break;
                case "0":
                    flag = false;
                    break;
                default:
                    throw new InvalidOperationException("Unknown operation!");
            }
        }
    }

    public void PrintMenu()
    {
        Console.WriteLine("Enter 1 to Access Employee Console App");
        Console.WriteLine("Enter 2 to Access Calculators");
        Console.WriteLine("Enter 0 to Exit");
    }
}