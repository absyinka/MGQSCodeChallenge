using System;
using System.Collections.Generic;
using BasicApp.Enums;
using BasicApp.Shared;
using ConsoleTables;

namespace BasicApp.EmployeeConsole;

public class EmployeeService : EmployeeServices
{
    public List<Employee> employees = new();

    public override void CreateEmployee()
    {
        var employeeDto = CreateEmployeeRequest();
        int id = employees.Count != 0 ? employees[employees.Count - 1].Id + 1 : 1;
        string code = Helper.GenerateCode(id);
        DateTime dateJoined = DateTime.Now;

        var employee = new Employee
        {
            Id = id,
            EmployeeCode = code,
            FirstName = employeeDto.FirstName,
            LastName = employeeDto.LastName,
            MiddleName = employeeDto.MiddleName,
            Gender = employeeDto.Gender,
            DateJoined = dateJoined
        };

        var findEmployee = FindByIdOrCode(id, code);

        if (findEmployee == null)
        {
            employees.Add(employee);
            Helper.SuccessTextOutput($"New employee with code \"{employee.EmployeeCode}\" created successfully!");
        }
        else
        {
            Helper.FailureTextOutput($"Employee with {employee.Id} id or {employee.EmployeeCode} already exist!");
        }
    }

    EmployeeDto CreateEmployeeRequest()
    {
        EmployeeDto employeeDto = new();

        Console.Write("Enter Firstname: ");
        employeeDto.FirstName = Console.ReadLine();

        Console.Write("Enter Lastname: ");
        employeeDto.LastName = Console.ReadLine();

        Console.Write("Enter Middlename: ");
        employeeDto.MiddleName = Console.ReadLine();

        int gender = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female\nEnter 3 for RatherNotSay: ", 1, 3);
        employeeDto.Gender = (Gender)gender;

        return employeeDto;
    }

    public override void DeleteEmployee(int id)
    {
        var employee = employees.Find(i => i.Id == id);

        if (employee != null)
        {
            employees.Remove(employee);
            Console.WriteLine($"Successfully removed employee with Id : {id} and Name: {employee.LastName} {employee.FirstName}");
        }
        else
        {
            Console.WriteLine("NOT FOUND");
        }
    }

    public override Employee FindByCode(string code)
    {
        return employees.Find(i => i.EmployeeCode == code);
    }

    public override Employee FindById(int id)
    {
        return employees.Find(i => i.Id == id);
    }

    public override Employee FindByIdOrCode(int id, string code)
    {
        return employees.Find(i => i.Id == id || i.EmployeeCode == code);
    }

    public override void ListAllEmployee()
    {
        if (employees.Count != 0)
        {
            var table = new ConsoleTable("ID", "CODE", "FIRST NAME", "LAST NAME", "OTHER NAME", "GENDER", "DATE JOINED");

            foreach (var emp in employees)
            {
                table.AddRow(emp.Id, emp.EmployeeCode, emp.FirstName, emp.LastName, emp.MiddleName, emp.Gender, emp.DateJoined.ToShortDateString());
            }

            table.Write(Format.Alternative);
        }
        else
        {
            Helper.InfoTextOutput("No record found!");
        }
    }

    public override void UpdateEmployee()
    {
        (int employeeId, EmployeeDto model) = UpdateEmployeeRequest();

        var employee = FindById(employeeId);

        if (employee != null)
        {
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.MiddleName = model.MiddleName;
            employee.Gender = model.Gender;

            Helper.SuccessTextOutput($"Employee record successfully updated!");
        }
        else
        {
            Helper.FailureTextOutput("Record not found");
        }
    }

    (int, EmployeeDto) UpdateEmployeeRequest()
    {
        EmployeeDto model = new();

        Console.Write("Enter ID of employee to update: ");
        int employeeId = int.Parse(Console.ReadLine());

        Console.Write("Enter Firstname: ");
        model.FirstName = Console.ReadLine();

        Console.Write("Enter Lastname: ");
        model.LastName = Console.ReadLine();

        Console.Write("Enter Middlename: ");
        model.MiddleName = Console.ReadLine();

        int genderUpdate = Helper.SelectEnum("Enter employee gender:\nEnter 1 for Male\nEnter 2 for Female\nEnter 3 for RatherNotSay: ", 1, 3);
        model.Gender = (Gender)genderUpdate;

        return (employeeId, model);
    }

    public override Employee ViewEmployee(int id)
    {
        var employee = FindById(id);

        return employee;
    }
}
