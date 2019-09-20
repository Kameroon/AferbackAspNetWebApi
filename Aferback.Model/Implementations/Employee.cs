
using Aferback.Model.Contracts;
using System.Runtime.Serialization;

namespace Aferback.Model.Implementations
{
    [DataContract]
    public class Employee : IEmployee
    {
        private int _employeeId;
        private string _employeName;
        private string _employeEmail;
        private double _employeSalary;

        [DataMember]
        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        [DataMember]
        public string EmployeName
        {
            get { return _employeName; }
            set { _employeName = value; }
        }

        [DataMember]
        public string EmployeEmail
        {
            get { return _employeEmail; }
            set { _employeEmail = value; }
        }

        [DataMember]
        public double EmployeSalary
        {
            get { return _employeSalary; }
            set { _employeSalary = value; }
        }

    }
}
