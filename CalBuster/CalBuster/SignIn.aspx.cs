﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
            txtFirstName.Focus();
            rgvDob.MinimumValue = DateTime.Today.AddYears(-80).ToShortDateString();
            rgvDob.MaximumValue = DateTime.Today.AddYears(-18).ToShortDateString();
            //rgvDob.MinimumValue = DateTime.Today.AddYears(-80).Date.ToString();
            //rgvDob.MaximumValue = DateTime.Today.AddYears(-18).Date.ToString();

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
                                  Gender = rdlGender.SelectedValue,
                                  Password = GetMd5Hash(txtConfirmPassword.Text),
                                  UserName = txtCreateUserName.Text,
                                  //DOB = String.Format(txtDay.Text + txtMonth.Text + txtYear.Text)
                              };
            db.User_tbl.Add(us);
            db.SaveChanges();
        }

       
        
        
    }
}