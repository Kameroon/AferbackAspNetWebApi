using Aferback.Model.Implementations;
using Aferback.Repository.Contracts;
using Aferback.WebAPI.Application.Helpers.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aferback.WebAPI.Application.Controllers
{
    public class CustomerController : ApiController
    {
        #region -- Fields --
        private readonly ICustomerRepository _customerRepository;
        private readonly IResponse _response;

        #endregion

        #region -- Constructor --
        public CustomerController(ICustomerRepository customerRepository, IResponse response)
        {
            _customerRepository = customerRepository;
            _response = response;
        }
        #endregion

        #region -- Methods --
        // GET: api/Customer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("all")]
        public IHttpActionResult All()
        {
            return Ok(_customerRepository.GetAll());
        }

        #region -- CUSTOM GetById --
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetByID(int id)
        //public Customer GetCustomerId(int id)
        {
            #region -- Custom --
            try
            {
                _response.Data = _customerRepository.GetById(id);
                _response.IsSuccess = true;
                return Ok<IResponse>(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = ex;
                return ResponseMessage(Request.CreateResponse
                    (HttpStatusCode.InternalServerError, _response));
            }
            #endregion

            #region -- Simple methode --
            //var customer = _customerRepository.GetById(id);
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            //return Ok(customer);

            //var customer = _customerRepository.GetById(id);
            //if (customer == null)
            //{
            //    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
            //    {
            //        Content = new StringContent("Custumer doesn't exist", System.Text.Encoding.UTF8, "text/plain"),
            //        StatusCode = HttpStatusCode.NotFound
            //    };

            //    throw new HttpResponseException(response);
            //}
            //return customer;
            #endregion
        }

        [HttpGet]
        [Route("{customerId}")]
        public IHttpActionResult GetEmployee(int customerId)
        {
            var custom = _customerRepository.GetById(customerId);
            if (custom == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Employee doesn't exist", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.NotFound
                };

                throw new HttpResponseException(response);
            }
            return Ok(custom);
        }

        #endregion

        // GET: api/Customer/5
        public Customer Get(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return new Customer();
            }
            return customer;
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }

        #region -- CUSTOM Remove --
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Remove(int id)
        //public Customer Remove(int id)
        {
            #region -- Custom --
            try
            {
                _customerRepository.Delete(id);
                _response.IsSuccess = true;
                return Ok();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = ex;
                return ResponseMessage(Request.CreateResponse
                    (HttpStatusCode.InternalServerError, _response));
            }
            #endregion
        }
        #endregion
        #endregion
    }
}
