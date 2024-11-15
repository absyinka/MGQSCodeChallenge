namespace BasicApp.EmployeeConsole;

public abstract class EmployeeServices
{
    public abstract void CreateEmployee();
    public abstract void ListAllEmployee();
    public abstract Employee ViewEmployee(int id);
    public abstract void UpdateEmployee();
    public abstract void DeleteEmployee(int id);
    public abstract Employee FindByIdOrCode(int id, string code);
    public abstract Employee FindById(int id);
    public abstract Employee FindByCode(string code);
}
