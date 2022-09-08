using System;
using System.Collections.Generic;

namespace BasicApp
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> employees = new List<Employee>();
        public Employee CreateEmployee(EmployeeDto employeeDto)
        {
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

            if(findEmployee == null)
            {
                employees.Add(employee);
                return employee;
            }

            return null;
        }

        public void DeleteEmployee(int id)
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

        public Employee FindByCode(string code)
        {
            return employees.Find(i => i.EmployeeCode == code);
        }

        public Employee FindById(int id)
        {
            return employees.Find(i => i.Id == id);
        }

        public Employee FindByIdOrCode(int id, string code)
        {
            return employees.Find(i => i.Id == id || i.EmployeeCode == code);
        }

        public void ListAllEmployee()
        {
            if (employees.Count != 0)
            {
                foreach(var emp in employees)
                {
                    Console.WriteLine($"Id: {emp.Id}\tCode: {emp.EmployeeCode}\tFirstname: {emp.FirstName}\tLastname: {emp.LastName}\tMiddlename: {emp.MiddleName}\tGender: {emp.Gender}\tDateJoined: {emp.DateJoined}");
                }
            }
            else 
            {
                Console.WriteLine("No record found!");
            }
        }

        public Employee UpdateEmployee(int id, EmployeeDto model)
        {
            var employee = FindById(id);

            if (employee != null)
            {
                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.MiddleName = model.MiddleName;
                employee.Gender = model.Gender;

                Console.WriteLine($"Employee record successfully updated!");
            }
            else
            {
                Console.WriteLine("Record not found");
            }

            return employee;
        }

        public Employee ViewEmployee(int id)
        {
            var employee = FindById(id);

            return employee;
        }
    }
}