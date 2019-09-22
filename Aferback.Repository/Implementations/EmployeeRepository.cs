using Aferback.Model.Implementations;
using Aferback.Repository.Contracts;
using Aferback.Repository.Helpers;
using NLog;
using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aferback.Model.Contracts;

namespace Aferback.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region -- Fields --
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public IEnumerable<IEmployee> Employees { get; set; }
        private IFactory _factory;
        #endregion

        #region -- Contructor --
        public EmployeeRepository(IFactory factory)
        {
            _factory = factory;
            Employees = PopulateEmployees();
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// -- Add new employee  --
        /// </summary>
        /// <param name="employee"></param>
        public void AddNew(IEmployee employee)
        {
            _logger.Debug($"[EmployeeRepository][AddNew({employee})] Ajout d'un nouvel employé.");

            var employeList = Employees.ToList();
            employeList.Add(employee);

            _logger.Debug($"[EmployeeRepository][AddNew({employee})] Fin d'un nouvel employé.");
        }

        /// <summary>
        /// -- Delete employee based on id --
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            _logger.Debug($"[EmployeeRepository][Delete({id})] Debut vérification de existance de l'employé.");

            var selectedEmploye = Employees.Where(empl => empl.EmployeeId == id).FirstOrDefault();

            _logger.Debug($"[EmployeeRepository][Delete({id})] Debut vérification de existance de l'employé.");

            if (selectedEmploye != null)
            {
                _logger.Debug($"[EmployeeRepository][Delete({id})] Debut suppression d'un employé.");

                Employees.ToList().Remove(selectedEmploye);

                _logger.Debug($"[EmployeeRepository][Delete({id})] Fin suppression d'un employé.");
                return true;
            }
            else
            {
                _logger.Error($"[EmployeeRepository][Delete({selectedEmploye})] Aucun employé ne correspond à l'indentifiant [{id}].");
                return false;
            }
        }

        /// <summary>
        /// -- Get all employees --
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IEmployee> GetAll()
        {
            _logger.Debug("[EmployeeRepository][GetAll()] Retour la liste des employes.");

            return Employees;
        }
        
        /// <summary>
        /// --  Get employee by id  --
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee</returns>
        public IEmployee GetById(int id)
        {
            _logger.Debug($"[EmployeeRepository][GetById({id})] Debut récupération d'un employé par son id.");

            var employee = Employees.Where(empl => empl.EmployeeId == id).FirstOrDefault();

            return EmployeeHelper.ManageResult(employee, id.ToString(), "GetById()");
        }

        /// <summary>
        /// --  Get employee by name --
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Employee</returns>
        public IEmployee GetByName(string name)
        {
            _logger.Debug($"[EmployeeRepository][GetByName({name})] Debut récupération d'un employé par son nom.");

            var employee = Employees.Where(empl => empl.EmployeName == name).FirstOrDefault();

            return EmployeeHelper.ManageResult(employee, name, "GetByName()");
        }
        
        /// <summary>
        /// --  --
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>bool</returns>
        public bool Update(Employee employee)
        {
            _logger.Debug("[EmployeeRepository][Update(employee)] Debut mise à jour d'un employé.");

            var selectedEmploye = Employees.Where(empl => empl.EmployeeId == employee.EmployeeId).FirstOrDefault();

            if (selectedEmploye != null)
            {
                // -- 1ere Methode --
                selectedEmploye.EmployeName = employee.EmployeName;
                selectedEmploye.EmployeEmail = employee.EmployeEmail;
                selectedEmploye.EmployeSalary = employee.EmployeSalary;

                // -- 2em Methode --
                var employeLists = Employees.ToList();
                employeLists.Remove(selectedEmploye);
                employeLists.Add(employee);

                _logger.Debug("[EmployeeRepository][Update(employee)] Debut mise à jour d'un employé.");

                return true;
            }
            else
            {
                _logger.Error("[EmployeeRepository][Update(employee)] Une erreur s'est produite lors de la mise à jour d'un employé.");
                
                return false;
            }
        }

        /// <summary>
        /// --  Populate employeeList  --
        /// </summary>
        /// <returns>IEnumerable<Employee></returns>
        public IEnumerable<IEmployee> PopulateEmployees()
        {
            _logger.Debug("[PopulateEmployees()] Debut chargement de la liste des employés.");

            var employees = _factory.CreateEmployees();
            var employee = _factory.CreateEmployee();
            employee.EmployeeId = 100;
            employee.EmployeName = "Employee 100";
            employee.EmployeEmail = "Employe100@compagny.com";
            employee.EmployeSalary = 4210;
            employees.Add(employee);

            employee.EmployeeId = 101;
            employee.EmployeName = "Employee 101";
            employee.EmployeEmail = "Employe101@compagny.com";
            employee.EmployeSalary = 4090;
            employees.Add(employee);

            employee.EmployeeId = 102;
            employee.EmployeName = "Employee 102";
            employee.EmployeEmail = "Employe101@compagny.com";
            employee.EmployeSalary = 4580;
            employees.Add(employee);

            employee.EmployeeId = 103;
            employee.EmployeName = "Employee 103";
            employee.EmployeEmail = "Employe103@compagny.com";
            employee.EmployeSalary = 3950;
            employees.Add(employee);

            employee.EmployeeId = 104;
            employee.EmployeName = "Employee 104";
            employee.EmployeEmail = "Employe104@compagny.com";
            employee.EmployeSalary = 4105;
            employees.Add(employee);

            _logger.Debug("[PopulateEmployees()] Fin chargement de la liste des employés.");

            return employees;
        }        

        #endregion
    }
}
