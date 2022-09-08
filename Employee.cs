using System;

namespace BasicApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Gender Gender {get; set;}
        public DateTime DateJoined { get; set; }
    }
}