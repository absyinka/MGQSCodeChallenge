using System;
using BasicApp.Enums;
using BasicApp.Shared;

namespace BasicApp.EmployeeConsole;

public class EmployeeConsoleMenu
{
    private readonly EmployeeService employeeService = new();
    private readonly EmployeeDto employeeDto = new();

    public void EmployeeMainMenu()
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
                    employeeService.CreateEmployee();
                    break;
                case "2":
                    employeeService.ListAllEmployee();
                    break;
                case "4":
                    employeeService.UpdateEmployee();
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
        Console.WriteLine("Enter 1 to Add new Employee");
        Console.WriteLine("Enter 2 to View all Employees");
        Console.WriteLine("Enter 3 to View an Employee");
        Console.WriteLine("Enter 4 to Update an Employee");
        Console.WriteLine("Enter 5 to Delete an Employee");
        Console.WriteLine("Enter 0 to Go back to main menu");
    }
}
