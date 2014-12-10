using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace RESTFulWCFService
{   
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetEmployee()
        {
            return EmployeeData.GetEmployee();
        }

        public bool AddEmployee(Employee emp)
        {
            return EmployeeData.AddEmployee(emp);
        }
    }
}
