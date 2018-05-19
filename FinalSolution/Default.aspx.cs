using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalSolution
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int rows = 0;
            try
            {
               if(txtFName.Text.Trim()!=string.Empty && txtLName.Text.Trim() != string.Empty)
                
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ftbl"].ConnectionString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = con;
                        con.Open();
                        comm.CommandText = "INSERT INTO formtable values(@fname,@lname);";
                        comm.Parameters.AddWithValue("@fname", txtFName.Text);
                        comm.Parameters.AddWithValue("@lname", txtLName.Text);
                          rows=comm.ExecuteNonQuery();
                        //dt.Load(comm.ExecuteReader());

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                //Response.Write("Rows:" + dt.Rows.Count);
                //Response.Write("Rows:" + rows);
                Response.Redirect("HtmlPage1.html");
            }
                
        }
    }
}