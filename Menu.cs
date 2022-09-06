using System;

namespace BasicApp
{
    public class Menu
    {
        private readonly IEmployeeService employeeService = new EmployeeService();
        private readonly EmployeeDto employeeDto = new EmployeeDto();

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
                        Console.Write("Enter Firstname: ");
                        employeeDto.FirstName = Console.ReadLine();
                        Console.Write("Enter Lastname: ");
                        employeeDto.LastName = Console.ReadLine();
                        Console.Write("Enter Middlename: ");
                        employeeDto.MiddleName = Console.ReadLine();
                        var employee = employeeService.CreateEmployee(employeeDto);
                        if (employee != null)
                        {
                            Console.WriteLine($"New employee {employee.FirstName} created successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"Employee with {employee.Id} id or {employee.EmployeeCode} already exist!");
                        }
                        break;
                    case "2":
                        employeeService.ListAllEmployee();
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
            Console.WriteLine("Enter 1 to Add new Employee");
            Console.WriteLine("Enter 2 to View all Employees");
            Console.WriteLine("Enter 3 to View an Employee");
            Console.WriteLine("Enter 4 to Update an Employee");
            Console.WriteLine("Enter 5 to Delete an Employee");
            Console.WriteLine("Enter 0 to Exit");
        }
    }
}