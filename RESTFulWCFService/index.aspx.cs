using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RESTFulWCFService
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvEmployee.DataSource = LoadEmployee();
                gvEmployee.DataBind();
            }
        }

        private DataSet LoadEmployee()
        {
            string constring = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select * from Employees", con))
                {
                    DataSet dsEmployee = new DataSet();
                    con.Open();
                    da.Fill(dsEmployee);
                    con.Close();
                    return dsEmployee;
                }
            }
        }
    }
}