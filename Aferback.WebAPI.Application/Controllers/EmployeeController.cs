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
        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
        }
        #endregion

        #region -- Methods --
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetAll();
        }

        // GET: api/Employee/5
        public Employee Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return _employeeRepository.GetById(id);
        }

        [Route("api/Employee/GetByName/{name}")]
        [HttpGet]
        public Employee GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }
            return _employeeRepository.GetByName(name);
        }

        // POST: api/Employee
        public void Post(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _employeeRepository.AddNew(employee);
        }

        // PUT: api/Employee/5
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

        // DELETE: api/Employee/5
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public HttpResponseMessage Add([FromBody] Employee employee)
        {
            try
            {
                //using (EmployeeDBContext dbContext = new EmployeeDBContext())
                //{
                //    dbContext.Employees.Add(employee);
                //    dbContext.SaveChanges();
                //    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                //    message.Headers.Location = new Uri(Request.RequestUri +
                //        employee.ID.ToString());
                //    return message;
                //}
                return null;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        #endregion
    }
}
