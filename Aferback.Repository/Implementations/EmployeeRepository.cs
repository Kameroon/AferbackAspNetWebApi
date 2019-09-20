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

namespace Aferback.Repository.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region -- Fields --
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private List<Employee> _employees = new List<Employee>();
        #endregion

        #region -- Contructor --
        public EmployeeRepository()
        {
            if (_employees?.ToList().Count == 0)
            {
                PopulateEmployees();
            }
        }
        #endregion

        #region -- Methods --

        /// <summary>
        /// -- Add new employee  --
        /// </summary>
        /// <param name="employee"></param>
        public void AddNew(Employee employee)
        {
            _logger.Debug($"[EmployeeRepository][AddNew({employee})] Ajout d'un nouvel employé.");

            var employeList = _employees.ToList();
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

            var selectedEmploye = _employees.Where(empl => empl.EmployeeId == id).FirstOrDefault();

            _logger.Debug($"[EmployeeRepository][Delete({id})] Debut vérification de existance de l'employé.");

            if (selectedEmploye != null)
            {
                _logger.Debug($"[EmployeeRepository][Delete({id})] Debut suppression d'un employé.");
                _employees.ToList().Remove(selectedEmploye);
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
        public IEnumerable<Employee> GetAll()
        {
            _logger.Debug("[EmployeeRepository][GetAll()] Retour la liste des employes.");

            return _employees;
        }


        /// <summary>
        /// --  Get employee by id  --
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee</returns>
        public Employee GetById(int id)
        {
            _logger.Debug($"[EmployeeRepository][GetById({id})] Debut récupération d'un employé par son id.");

            var employee = _employees.Where(empl => empl.EmployeeId == id).FirstOrDefault();

            return EmployeeHelper.ManageResult(employee, id.ToString(), "GetById()");
        }

        /// <summary>
        /// --  Get employee by name --
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Employee</returns>
        public Employee GetByName(string name)
        {
            _logger.Debug($"[EmployeeRepository][GetByName({name})] Debut récupération d'un employé par son nom.");

            var employee = _employees.Where(empl => empl.EmployeName == name).FirstOrDefault();

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

            var selectedEmploye = _employees.Where(empl => empl.EmployeeId == employee.EmployeeId).FirstOrDefault();

            if (selectedEmploye != null)
            {
                // -- 1ere Methode --
                selectedEmploye.EmployeName = employee.EmployeName;
                selectedEmploye.EmployeEmail = employee.EmployeEmail;
                selectedEmploye.EmployeSalary = employee.EmployeSalary;

                // -- 2em Methode --
                var employeLists = _employees.ToList();
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
        public IEnumerable<Employee> PopulateEmployees()
        {
            _logger.Debug("[PopulateEmployees()] Debut chargement de la liste des employés.");

            var employees = new List<Employee>
            {
                new Employee(){ EmployeeId = 100,
                    EmployeName = "Employee 100",
                    EmployeEmail = "Employe100@compagny.com",
                    EmployeSalary = 3270},
                new Employee(){ EmployeeId = 101,
                    EmployeName = "Employee 101",
                    EmployeEmail = "Employe101@compagny.com",
                    EmployeSalary = 3900},
                new Employee(){ EmployeeId = 102,
                    EmployeName = "Employee 102",
                    EmployeEmail = "Employe102@compagny.com",
                    EmployeSalary = 4020},
                new Employee(){ EmployeeId = 103,
                    EmployeName = "Employee 103",
                    EmployeEmail = "Employe103@compagny.com",
                    EmployeSalary = 3750}
            };

            _logger.Debug("[PopulateEmployees()] Fin chargement de la liste des employés.");

            _employees = employees;

            return employees;
        }        

        #endregion
    }
}
