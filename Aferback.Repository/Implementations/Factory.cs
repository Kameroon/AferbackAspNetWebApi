using Aferback.Model.Contracts;
using Aferback.Model.Implementations;
using Aferback.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aferback.Repository.Implementations
{
    public class Factory : IFactory
    {
        public IEmployee CreateEmployee() => new Employee();

        public List<IEmployee> CreateEmployees() => new List<IEmployee>();

        public ICustomer CreateCustomer() => new Customer();

        public List<ICustomer> CreateCustomers() => new List<ICustomer>();
    }
}
