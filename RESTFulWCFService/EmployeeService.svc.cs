using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using System.ServiceModel.Activation;

namespace RESTFulWCFService
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetEmployees()
        {
            return EmployeeData.GetEmployees();
        }

        public Employee GetEmployee(int EmpId)
        {
            return EmployeeData.GetEmployee(EmpId);
        }

        public bool AddEmployee(Employee emp)
        {
            return EmployeeData.AddEmployee(emp);
        }

        public bool UpdateEmployee(Employee emp)
        {
            return EmployeeData.UpdateEmployee(emp);
        }

        public bool DeleteEmployee(int EmpId)
        {
            return EmployeeData.DeleteEmployee(EmpId);
        }
    }
} 
