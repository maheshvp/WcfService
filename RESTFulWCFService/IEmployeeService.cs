using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace RESTFulWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        List<Employee> GetEmployees();

        [OperationContract]
        bool AddEmployee(Employee emp);

        [OperationContract]
        Employee GetEmployee(int EmpId);

        [OperationContract]
        bool UpdateEmployee(Employee emp);

        [OperationContract]
        bool DeleteEmployee(int EmpId);
    }
}
