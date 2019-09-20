using Aferback.Model.Contracts;
using Aferback.Model.Implementations;
using Aferback.Repository.Contracts;
using Aferback.Repository.Implementations;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using Unity;

namespace Aferback.WebAPI.Application
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            _logger.Debug("==============>  [Application start]  Debut initailisation.  <================");

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Initialiaze();
            _logger.Debug("==============>  [Application start] Fin initailisation.  <================");
        }

        private void Initialiaze()
        {
            //IUnityContainer container = new UnityContainer();

            //_logger.Debug("==============> [Initialize] Debut enregistrement des types.  <================");
            //container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            //container.RegisterType<IEmployee, Employee>();

            //_logger.Debug("==============> [Initialize] Fin enregistrement des types.  <================");
        }
    }
}
