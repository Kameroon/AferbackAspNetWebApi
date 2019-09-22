
using Aferback.Model.Contracts;
using Aferback.Model.Implementations;
using System.Collections.Generic;

namespace Aferback.Repository.Contracts
{
    public interface IEmployeeRepository
    {
        void AddNew(IEmployee employee);
        bool Delete(int id);
        IEnumerable<IEmployee> GetAll();
        IEmployee GetById(int id);
        IEmployee GetByName(string name);
        bool Update(Employee employee);
    }
}
