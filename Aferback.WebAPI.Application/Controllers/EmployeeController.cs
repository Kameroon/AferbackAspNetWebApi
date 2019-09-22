using Aferback.Model.Contracts;
using Aferback.Model.Implementations;
using Aferback.Repository.Contracts;
using Aferback.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aferback.WebAPI.Application.Controllers
{
    public class EmployeeController : ApiController
    {

        // https://dotnettutorials.net/lesson/post-method-in-web-api/
        // - UnitTest - https://docs.microsoft.com/fr-fr/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api

        #region -- Fields --
        private IEmployeeRepository _employeeRepository;
        #endregion

        #region -- Contructor --
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region -- Methods --
        // GET: api/Employee
        public IEnumerable<IEmployee> Get()
        {
            return _employeeRepository.GetAll();
        }
        
        // GET: api/Employee/5
        public IEmployee Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _employeeRepository.GetById(id);
        }

        [Route("api/Employee/GetByName/{name}")]
        [HttpGet]
        public IEmployee GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            return _employeeRepository.GetByName(name);
        }

        // POST: api/Test
        //public void Post([FromBody]string value)
        public void Post(IEmployee employee)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _employeeRepository.AddNew(employee);
        }

        // PUT: api/Test/5
        //public void Put(int id, [FromBody]string value)
        public void Put(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var result = _employeeRepository.Update(employee);

            if (result)
            {
                //throw new 
            }
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var result = _employeeRepository.Delete(id);

            if (result)
            {

            }
        }
        #endregion
    }
}
