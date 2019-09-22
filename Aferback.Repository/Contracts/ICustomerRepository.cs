using Aferback.Model.Implementations;
using System.Collections.Generic;

namespace Aferback.Repository.Contracts
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> PopulateCustomerData();
    }
}
