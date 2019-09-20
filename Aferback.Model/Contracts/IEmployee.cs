namespace Aferback.Model.Contracts
{
    public interface IEmployee
    {
        int EmployeeId { get; set; }
        string EmployeEmail { get; set; }
        string EmployeName { get; set; }
        double EmployeSalary { get; set; }
    }
}
