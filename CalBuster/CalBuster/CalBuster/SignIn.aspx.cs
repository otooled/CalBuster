using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.Security;

namespace CalBuster
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        //static string connString = WebConfigurationManager.ConnectionStrings["Calorie_BusterEntities"].ConnectionString;

        //SqlConnection conn = new SqlConnection(connString);
        //SqlCommand command = new SqlCommand();
        //SqlDataReader queryResults;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static string GetMd5Hash(string input)
        {
            string output = "";

            using (MD5 md5Hash = MD5.Create())
            {

                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                foreach (byte b in data)
                {
                    output = output + b.ToString("x2");
                }
            }
            return output;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    conn.Open();
            //    command.Connection = conn;

            //    //insert data into the database
            //    command.CommandText = "insert into User_tbl values ('" + txtFirstName.Text + "', '" + GetMd5Hash(txtConfirmPassword.Text) + "')";
            //    command.ExecuteNonQuery();

            //    //read data from the database
            //    //command.CommandText = "select UserName, UserPassword from usersTbl where UserName='Joe'";
            //    //queryResults = command.ExecuteReader();

            //    //if (queryResults.Read())
            //    //    lblDisplay1.Text = queryResults["UserName"] + " has password : " + queryResults["UserPassword"];
            //    //else
            //    //    lblDisplay1.Text = "no such user";

            //    queryResults.Close();

            //}
            //catch (Exception ex)
            //{
            //    //lblEmail.Text = ex.Message;
            //}

            //finally
            //{

            //    conn.Close();
            //}
        }
    }
}