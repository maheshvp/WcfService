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
        [WebGet(UriTemplate = "/GetEmployee", ResponseFormat = WebMessageFormat.Json)]
        List<Employee> GetEmployee();

        [OperationContract]
        [WebInvoke(UriTemplate = "/AddEmployee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        bool AddEmployee(Employee emp);
    }
}
