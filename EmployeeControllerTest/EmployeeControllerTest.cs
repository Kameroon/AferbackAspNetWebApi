using Aferback.Model.Implementations;
using Aferback.Repository.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeControllerTest
{
    [TestFixture]
    public class EmployeeControllerTest
    {

        #region -- Fields --/// <summary>
        /// -- Our Mock Employees Repository for use in testing --
        /// </summary>
        public readonly IEmployeeRepository MockEmployeeRepository;
        #endregion

        #region -- Constructor --
        public EmployeeControllerTest()
        {
            // -- Get All Employees --
            var employees = PopulateEmployees();

            Mock<IEmployeeRepository> mockEmployeeRepository = new Mock<IEmployeeRepository>();

            // -- Mock the Employees Repository using Moq --
            mockEmployeeRepository.Setup(mer => mer.GetAll()).Returns(employees);

            // -- Return employee by id --
            mockEmployeeRepository.Setup(emp => emp.GetById(It.IsAny<int>()))
                    .Returns((int e) => employees.Where(emp => emp.EmployeeId == e)
                    .FirstOrDefault()
                );

            // -- Return employee by name --
            mockEmployeeRepository.Setup(emp => emp.GetByName(It.IsAny<string>()))
                    .Returns((string e) => employees.Where(emp => emp.EmployeName == e)
                    .FirstOrDefault()
                );

            //// -- Allows us to test Delete an employee --
            //mockEmployeeRepository.Setup(emp => emp.Delete(It.IsAny<int>()))
            //    .Returns((int e) => employees.Where(emp => emp.EmployeeId == e).Single();

            // -- Allows us to test Upd an employee --
            mockEmployeeRepository.Setup(emp => emp.Update(It.IsAny<Employee>())).Returns(
                (Employee employee) =>
                {
                    var original = employees.Where(emp => emp.EmployeeId == employee.EmployeeId).FirstOrDefault();

                    if (original == null)
                    {
                        return false;
                    }

                    employee.EmployeName = employee.EmployeName;
                    employee.EmployeEmail = employee.EmployeEmail;
                    employee.EmployeSalary = employee.EmployeSalary;

                    return true;
                });

            // -- Complete the setup of our Mock Product Repository --
            MockEmployeeRepository = mockEmployeeRepository.Object;
        }
        #endregion

        public IEnumerable<Employee> PopulateEmployees()
        {
            return new List<Employee>
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
        }

        #region -- Methods --
        [Test]
        public void GetAllProduct_ShouldWork()
        {
            var employees = MockEmployeeRepository.GetAll().ToList();

            Assert.IsNotNull(employees);
            Assert.AreEqual(4, employees.Count);
        }

        #region -- TO DO -- Install-Package StructureMap.WebApi2 -Version 3.0.4.125 --
        // -- Install-Package StructureMap.WebApi2 -Version 3.0.4.125 --
        /*
         *  public class MovieController : ApiController
            {
                private readonly IMovieRepository _movieRepo;

                public MovieController(IMovieRepository movieRepo)
                {
                    _movieRepo = movieRepo;
                }

                [HttpGet]
                [Route("all")]
                public IHttpActionResult All()
                {
                    var allMovies = _movieRepo.GetAllMovies();
                    return Ok(allMovies);
                }

                [HttpGet]
                [Route("{id}")]
                public IHttpActionResult GetByID(int id)
                {
                    var movie = _movieRepo.GetByID(id);
                    if(movie == null)
                    {
                        return NotFound();
                    }
                    return Ok(movie);
                }
            }
         * 
         * */

        [Test]
        public void Test_GetByID_ValidID()
        {
            ////Arrange
            //var mockMovieRepo = new Mock<IMovieRepository>();
            //var movieID = 2;
            //mockMovieRepo.Setup(x => x.GetByID(movieID)).Returns(new Movie() { ID = 2 });
            //var controller = new MoviesController(mockMovieRepo.Object);

            ////Act
            //IHttpActionResult response = controller.GetByID(movieID);
            //var contentResult = response as OkNegotiatedContentResult<Movie>;

            ////Assert
            //Assert.IsNotNull(contentResult);
            //Assert.IsNotNull(contentResult.Content);
            //Assert.AreEqual(movieID, contentResult.Content.ID);
        }

        public void Test_GetByID_InvalidID()
        {
            ////Arrange
            //var mockMovieRepo = new Mock<IMovieRepository>();
            //var movieID = 6; //This movie does not exist
            //mockMovieRepo.Setup(x => x.GetByID(movieID)).Returns((Movie)null);
            //var controller = new MoviesController(mockMovieRepo.Object);

            ////Act
            //IHttpActionResult response = controller.GetByID(movieID);
            //var contentResult = response as NotFoundResult;

            ////Assert
            //Assert.IsNotNull(contentResult);
        }
        #endregion

        [Test]
        public void GetAllEmployeeById_GoodIdIsGiving_ShouldWork()
        {
            var employee = new Employee
            {
                EmployeeId = 100,
                EmployeName = "Employee 100",
                EmployeEmail = "Employe100@compagny.com",
                EmployeSalary = 3270
            };

            // -- Try finding a employee by id in mockRepository --
            var testEmployee = MockEmployeeRepository.GetById(employee.EmployeeId);

            Assert.IsTrue(true);
            Assert.IsNotNull(testEmployee); // -- Test if null --
            //Assert.IsInstanceOfType(testEmployee, typeof(Employee)); // -- Test type --
            //Assert.AreEqual(testEmployee, employee); // -- Verify it is the right employee --
        }

        [Test]
        public void GetAllEmployeeByName_GoodNameIsGiving_ShouldWork()
        {
            var employee = new Employee
            {
                EmployeeId = 100,
                EmployeName = "Employee 100",
                EmployeEmail = "Employee mail",
                EmployeSalary = 47200
            };

            // -- Try finding a employee by name --
            var testEmployee = MockEmployeeRepository.GetByName(employee.EmployeName);

            Assert.IsTrue(true);
            Assert.IsNotNull(testEmployee);
            //Assert.IsInstanceOfType(testEmployee, typeof(Employee));
            Assert.AreEqual(employee.EmployeName, testEmployee.EmployeName);
        }

        [Test]
        public void GetAllEmployeeByName_WrongNameIsGiving_Return()
        {
            var employee = new Employee
            {
                EmployeeId = 100,
                EmployeName = "Employee 1000",
                EmployeEmail = "Employee mail",
                EmployeSalary = 47200
            };

            // -- Try finding a employee by name --
            var testEmployee = MockEmployeeRepository.GetByName(employee.EmployeName);

            Assert.IsNull(testEmployee);
            Assert.AreNotEqual(testEmployee, employee);

            //// -- Pour afficher une exception attendue --
            //Assert.That(() => MockEmployeeRepository.GetByName(employee.EmployeName),
            //    Throws.TypeOf<ArgumentException>());
        }

        #endregion
    }
}
