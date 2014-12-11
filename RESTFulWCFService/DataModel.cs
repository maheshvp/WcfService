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
        private int _EmpId;
        private string _Name;
        private int _Age;
        private string _Designation;
        private string _Location;

        [DataMember]
        public int EmpId
        {
            get
            {
                return _EmpId;
            }
            set
            {
                _EmpId = value;
            }
        }


        [DataMember]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        [DataMember]
        public Int32 Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }


        [DataMember]
        public string Designation
        {
            get
            {
                return _Designation;
            }
            set
            {
                _Designation = value;
            }
        }


        [DataMember]
        public string Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
            }
        }
    }


    public static class EmployeeData
    {
        public static string constring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        public static List<Employee> GetEmployee()
        {
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

                            emp.EmpId = Convert.ToInt32(sdr["EmpId"].ToString());
                            emp.Name = sdr["Name"].ToString();
                            emp.Age = Convert.ToInt32(sdr["Age"]);
                            emp.Designation = sdr["Designation"].ToString();
                            emp.Location = sdr["Location"].ToString();

                            employee.Add(emp);
                        }
                        con.Close();
                        return employee;
                    }
                }
            }
        }

        public static Employee GetEmployee(int EmpId)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("select top 1 * from Employees where EmpId=" + EmpId, con))
                {
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        Employee emp = new Employee();

                        emp.Name = sdr["Name"].ToString();
                        emp.Age = Convert.ToInt32(sdr["Age"]);
                        emp.Designation = sdr["Designation"].ToString();
                        emp.Location = sdr["Location"].ToString();

                        con.Close();
                        return emp;
                    }
                }
            }
        }

        public static bool AddEmployee(Employee emp)
        {

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("insert into Employees values ('" + emp.Name + "'," + emp.Age + "," + emp.Designation + ",'" + emp.Location + "')", con))
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

        public static bool UpdateEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("update Employees set Name='" + emp.Name + "',Age=" + emp.Age + ",Designation='" + emp.Designation + "',Location='" + emp.Location + "' where EmpId=" + emp.EmpId, con))
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

        public static bool DeleteEmployee(int EmpId)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("delete from Employees where EmpId=" + EmpId, con))
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