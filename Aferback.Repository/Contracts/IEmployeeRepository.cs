
using Aferback.Model.Implementations;
using System.Collections.Generic;

namespace Aferback.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        void AddNew(Employee employee);
        bool Delete(int id);
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee GetByName(string name);
        IEnumerable<Employee> PopulateEmployees();
        bool Update(Employee employee);
    }
}
