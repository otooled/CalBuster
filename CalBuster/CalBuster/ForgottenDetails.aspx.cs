using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalBuster
{
    public partial class ForgottenDetails : System.Web.UI.Page
    {
        public string purpose = "";
        public string linkURL = "";
        public bool userName;
        Calorie_BusterEntities db = new Calorie_BusterEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            purpose = Request.QueryString["purpose"];
            if (purpose == "userName" || purpose == "password")
            {
                forgotUserName.Visible = true;
                changePassword.Visible = false;
            }
            else if (purpose == "passwordChange")
            {
                forgotUserName.Visible = false;
                changePassword.Visible = true;

            }
        }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (purpose == "userName")
            {
                userName = true;
                var nme = db.User_tbl.Where(a => a.Email == txtEmail.Text).FirstOrDefault();
                sendEmailUserName(nme.UserName, userName);
            }
            else if (purpose == "password")
            {
                userName = false;
                linkURL = "http://localhost:50185/ForgottenDetails.aspx?purpose=passwordChange";
                sendEmailUserName(linkURL, userName);
                HttpCookie cookie = new HttpCookie("email");
                cookie.Expires = DateTime.Now + new TimeSpan(2, 0, 0);
                cookie.Value = txtEmail.Text;
                Response.Cookies.Add(cookie);
            }
        }
        public void sendEmailUserName(string nme, bool userName)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            MailAddress from = new MailAddress("calbuster66@gmail.com", "[ CalBuster ]");
            MailAddress to = new MailAddress(txtEmail.Text);
            MailMessage message = new MailMessage(from, to);
            if (userName) { message.Body = "Your User name is: " + nme; }
            else { message.Body = "Please click this link to reset your Password: " + nme; }
            message.Subject = "Your calBuster account details";
            NetworkCredential myCreds = new NetworkCredential("calbuster66@gmail.com", "calbuster");
            client.Credentials = myCreds;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            string timeGone = @"<script type='text/javascript'> if(confirm('An email has been sent with your account information!')) { document.location='Login.aspx?val=true';}</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "timeOut", timeGone, false);
            //lblConfirm.Text = "An email has been sent with your account information";
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

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtFirstPassword.Text == txtSecondPassword.Text)
            {
                if (Request.Cookies["email"] != null)
                {
                    string email = Request.Cookies["email"].Value;
                    var cPass = db.User_tbl.Where(a => a.Email == email).FirstOrDefault();
                    cPass.Password = GetMd5Hash(txtSecondPassword.Text);
                    db.SaveChanges();
                    string timeGone = @"<script type='text/javascript'> if(confirm('You can now log in with your new password!')) { document.location='Login.aspx?val=true';}</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "timeOut", timeGone, false);
                }
                else
                {
                    string timeGone = @"<script type='text/javascript'> if(confirm('Sorry, your link has expired!')) { document.location='Login.aspx?val=true';}</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "timeOut", timeGone, false);
                }
            }
        }
    }
}