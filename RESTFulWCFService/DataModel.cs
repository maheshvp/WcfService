using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Runtime.Serialization;
using System.Data.SqlClient;

namespace RESTFulWCFService
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Int32 Age { get; set; }
        [DataMember]
        public Int64 Salary { get; set; }
        [DataMember]
        public string Designation { get; set; }
    }


    public static class EmployeeData
    {
        public static List<Employee> GetEmployee()
        {
            string constring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Employees", con))
                {
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        List<Employee> employee = new List<Employee>();
                        while (sdr.Read())
                        {
                            Employee emp = new Employee();

                            emp.Name = sdr["Name"].ToString();
                            emp.Age = Convert.ToInt32(sdr["Age"]);
                            emp.Salary = Convert.ToInt64(sdr["Salary"]);
                            emp.Designation = sdr["Designation"].ToString();

                            employee.Add(emp);
                        }
                        con.Close();
                        return employee;
                    }
                }
            }
        }

        public static bool AddEmployee(Employee emp)
        {
            string constring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("insert into Employees values ('" + emp.Name + "'," + emp.Age + "," + emp.Salary + ",'" + emp.Designation + "')", con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

                }
            }
        }
    }
}