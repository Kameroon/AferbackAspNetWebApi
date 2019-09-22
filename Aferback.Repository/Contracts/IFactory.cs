using Aferback.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aferback.Repository.Contracts
{
    public interface IFactory
    {
        IEmployee CreateEmployee();

        List<IEmployee> CreateEmployees();

        ICustomer CreateCustomer();

        List<ICustomer> CreateCustomers();
    }
}
