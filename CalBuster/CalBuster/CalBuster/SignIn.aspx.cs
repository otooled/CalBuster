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

        Calorie_BusterEntities db = new Calorie_BusterEntities();

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
            User_tbl us = new User_tbl
                              {
                                  Fname = txtFirstName.Text,
                                  Sname = txtSurame.Text,
                                  Email = txtConfirmEmail.Text,
                                  Password = GetMd5Hash(txtConfirmPassword.Text),
                                  Gender = rdlGender.SelectedValue
                              };
            db.User_tbl.Add(us);
            db.SaveChanges();
        }
    }
}