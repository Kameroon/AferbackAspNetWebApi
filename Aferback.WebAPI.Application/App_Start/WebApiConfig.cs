using Aferback.Model.Contracts;
using Aferback.Model.Implementations;
using Aferback.Repository.Contracts;
using Aferback.Repository.Implementations;
using Aferback.WebAPI.Application.Helpers.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;

namespace Aferback.WebAPI.Application
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // --  Initialise the UnityContainer --
            var container = new UnityContainer();

            // -- Register types --
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IEmployee, Employee>();

            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<ICustomer, Customer>();

            container.RegisterType<IResponse, Response>();

            // --  --
            container.RegisterType<IFactory, Factory>();

            // -- Set the dependency resolver --
            config.DependencyResolver = new UnityResolver(container);


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
