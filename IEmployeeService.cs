namespace BasicApp
{
    public interface IEmployeeService
    {
        Employee CreateEmployee(EmployeeDto employeeDto);
        void ListAllEmployee();
        Employee ViewEmployee(int id);
        Employee UpdateEmployee(int id, Employee model);
        void DeleteEmployee(int id);
        Employee FindByIdOrCode(int id, string code);
    }
}