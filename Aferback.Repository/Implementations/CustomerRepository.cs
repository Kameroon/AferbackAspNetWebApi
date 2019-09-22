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
    public class CustomerRepository : ICustomerRepository
    {
        private IEnumerable<Customer> Customers;

        public CustomerRepository()
        {
            Customers = PopulateCustomerData();
        }

        public void Delete(int id)
        {

        }

        public IEnumerable<Customer> GetAll()
        {
            return Customers;
        }

        public Customer GetById(int id)
        {
            var customers = Customers;
            if (Customers.Where(x => x.CustomerID == id).Any())
            {
                var cust = customers.ToList().Where(c => c.CustomerID == id)
                    .FirstOrDefault();
                return cust;
            }
            throw new NotImplementedException();
        }

        public void Insert(Customer obj)
        {

        }

        public void Save()
        {

        }

        public void Update(Customer obj)
        {

        }

        public IEnumerable<Customer> PopulateCustomerData()
        {
            return new List<Customer>
            {
                new Customer() { CustomerID = 1, FirstName = "John", LastName = "Meaney", Address = "Chicago" },
                new Customer() { CustomerID = 2, FirstName = "Peter", LastName = "Delphine", Address = "New York" },
                new Customer() { CustomerID = 3, FirstName = "Carol", LastName = "Meaney", Address = "Dijon" },
                new Customer() { CustomerID = 4, FirstName = "Farouk", LastName = "Shaw", Address = "New Bell" },
                new Customer() { CustomerID = 5, FirstName = "Amy", LastName = "Donald", Address = "Namtes" }
            };
        }
    }
}
