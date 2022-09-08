using System;

namespace BasicApp
{
    public class Menu
    {
        private readonly IEmployeeService employeeService = new EmployeeService();
        private readonly EmployeeDto employeeDto = new EmployeeDto();
        private readonly Exercise exercise = new Exercise();

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
                        int gender = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female\nEnter 3 for RatherNotSay: ", 1, 3);
                        employeeDto.Gender = (Gender) gender;
                        var employee = employeeService.CreateEmployee(employeeDto);
                        if (employee != null)
                        {
                            Console.WriteLine($"New employee with code \"{employee.EmployeeCode}\" created successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"Employee with {employee.Id} id or {employee.EmployeeCode} already exist!");
                        }
                        break;
                    case "2":
                        employeeService.ListAllEmployee();
                        break;
                    case "4":
                        Console.Write("Enter ID of employee to update: ");
                        int empId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Firstname: ");
                        employeeDto.FirstName = Console.ReadLine();
                        Console.Write("Enter Lastname: ");
                        employeeDto.LastName = Console.ReadLine();
                        Console.Write("Enter Middlename: ");
                        employeeDto.MiddleName = Console.ReadLine();
                        int genderUpdate = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female\nEnter 3 for RatherNotSay: ", 1, 3);
                        employeeDto.Gender = (Gender) genderUpdate;
                        employeeService.UpdateEmployee(empId, employeeDto);
                        break;
                    case "6":
                        var result = exercise.PaymentCalculations();
                        Console.WriteLine(result);
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
            Console.WriteLine("Enter 6 for Payment Calculations");
            Console.WriteLine("Enter 0 to Exit");
        }
    }
}