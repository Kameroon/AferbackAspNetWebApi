using Aferback.Model.Contracts;
using Aferback.Model.Implementations;
using NLog;

namespace Aferback.Repository.Helpers
{
    public class EmployeeHelper
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static IEmployee ManageResult(IEmployee employee, string paramName, string methodeName)
        {
            if (employee != null)
            {
                _logger.Debug($"[EmployeeRepository][{methodeName}][{employee}] Fin récupération d'un employé correspondant à [{paramName}].");
                return employee;
            }
            else
            {
                _logger.Error($"[EmployeeRepository][{methodeName}][{employee}] Aucun result trouvé correspondant à [{paramName}]");
                return new Employee();
            }
        }

    }
}
