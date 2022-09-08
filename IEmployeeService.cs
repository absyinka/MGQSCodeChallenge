namespace BasicApp
{
    public interface IEmployeeService
    {
        Employee CreateEmployee(EmployeeDto employeeDto);
        void ListAllEmployee();
        Employee ViewEmployee(int id);
        Employee UpdateEmployee(int id, EmployeeDto model);
        void DeleteEmployee(int id);
        Employee FindByIdOrCode(int id, string code);
        Employee FindById(int id);
        Employee FindByCode(string code);
    }
}