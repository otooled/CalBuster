using System;
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

            rfvConPassword.Enabled = true;
            rfvDOB.Enabled = true;
            rfvConEmail.Enabled = true;
            rfvPassword1.Enabled = true;
            rfvGender.Enabled = true;
            ((MasterPage)this.Master).FindControl("links").Visible = false;

            if (!Page.IsPostBack)
            {
                string purpose = Request.QueryString["purpose"];
                if (purpose == "change")                            // if user is logged in and wants to change their details
                {
                    rfvConPassword.Enabled = false;
                    rfvDOB.Enabled = false;
                    rfvConEmail.Enabled = false;
                    rfvPassword1.Enabled = false;
                    rfvGender.Enabled = false;
                    if (Session["userDetails"] != null)
                    {
                        User nn = ((User)Session["userDetails"]);       // fill in details
                        var joe = db.User_tbl.Where(a => a.User_id == nn.userId).FirstOrDefault();
                        txtFirstName.Text = joe.Fname;
                        txtSurame.Text = joe.Sname;
                        txtCreateUserName.Text = joe.UserName;
                        txtEmail.Text = joe.Email;
                    }
                }
            }
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
            
            //Add user details to user table
            
            User_tbl us = new User_tbl
                              {
                                  Fname = txtFirstName.Text,
                                  Sname = txtSurame.Text,
                                  Email = txtConfirmEmail.Text,
                                  Gender = rdlGender.SelectedValue,
                                  Password = GetMd5Hash(txtConfirmPassword.Text),
                                  UserName = txtCreateUserName.Text,
                                  //DOB = Convert.ToDateTime(txtDOB.Text)
                                  //DOB = String.Format(txtDay.Text + txtMonth.Text + txtYear.Text)
                              };
            if (chbJoinUp.Checked) { us.joinUp = true; }
            db.User_tbl.Add(us);
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                
                
            }
            
            finally
            {
                
                string timeGone = @"<script type='text/javascript'> if(confirm('You can now log in with your chosen username and password.')) { document.location='Login.aspx?val=true';}</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "timeOut", timeGone, false);
            }

        }

        protected void btnChangeDets_Click(object sender, EventArgs e)
        {
            
           
            if (Session["userDetails"] != null)
            {
                User nn = ((User)Session["userDetails"]);
                var k = db.User_tbl.Find(nn.userId);
                k.Fname = txtFirstName.Text;
                k.Sname = txtSurame.Text;
                k.Email = txtEmail.Text;
                k.UserName = txtCreateUserName.Text;

                try { db.SaveChanges(); }               // add changes
                catch { }              
                Response.Redirect("PlannerPage.aspx");
            }
        }       
    }
}