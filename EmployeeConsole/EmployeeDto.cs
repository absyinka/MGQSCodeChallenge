using BasicApp.Enums;

namespace BasicApp.EmployeeConsole;

public class EmployeeDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public Gender Gender { get; set; }
}
