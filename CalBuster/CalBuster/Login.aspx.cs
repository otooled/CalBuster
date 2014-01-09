﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace CalBuster
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //database 
        Calorie_BusterEntities db = new Calorie_BusterEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> c89d18a0c2e404e2d643744f4eb0beabfc6b814f
            if (!IsPostBack)
            {
                //Create session
                if (Session["userDetails"] != null)
                {
<<<<<<< HEAD
                    User values = (User)Session["userDetails"];
=======
                    User values = (User) Session["userDetails"];
>>>>>>> c89d18a0c2e404e2d643744f4eb0beabfc6b814f
                    txtUserName.Text = values.userName;
                    txtPassword.Text = values.password;
                }
            }
<<<<<<< HEAD
=======
=======
>>>>>>> 7f064d8957f6f5462d4b97fc81416a0e127c1bbc
>>>>>>> c89d18a0c2e404e2d643744f4eb0beabfc6b814f
        }

        protected void btnBmiResult_Click(object sender, EventArgs e)
        {
            //Calculations for BMI Height
            int feetToInches = Convert.ToInt16(txtHeightFeet.Text) * 12;
            int userHeight = Convert.ToInt16(txtHeightInces.Text) + feetToInches;
            decimal heightForBMI = userHeight * userHeight;

            //Variable for weight
            int weight = Convert.ToInt16(txtWeight.Text);

            //Divide heigth by weight
            decimal heightDivWeight = weight / heightForBMI;

            //Bmi formaula constant
            const int BMI_FACTOR = 703;

            //Bmi result
            decimal BMIResult = heightDivWeight * BMI_FACTOR;

            //Display BMI
            if (BMIResult < 18)
            {
                lblDisplayBMI.Text = String.Format("Your BMI is {0:00.0} - BMI underweight", BMIResult);
            }
            else if (BMIResult >= 18 && BMIResult < 25)
            {
                lblDisplayBMI.Text = String.Format("Your BMI is {0:00.0} - BMI healthy", BMIResult);
            }

            else if (BMIResult >= 25 && BMIResult < 30)
            {
                lblDisplayBMI.Text = String.Format("Your BMI is {0:00.0} - BMI Overweight", BMIResult);
            }

            else
            {
                lblDisplayBMI.Text = String.Format("Your BMI is {0:00.0} - BMI obese", BMIResult);
            }

            
        }

        //Delegate
        public delegate void ClearBMI();


        public void ClearText()
        {
            txtHeightFeet.Text = "";
            txtHeightInces.Text = "";
            txtWeight.Text = "";
        }

        public void ClearDisplay()
        {
            lblDisplayBMI.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //Clear BMI result
            ClearBMI cBMI = new ClearBMI(ClearText);
            cBMI();
            cBMI = new ClearBMI(ClearDisplay);
            cBMI();

        }

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignIn.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (IsValid)
            {
                //Add session
                User details = new User { userName = txtUserName.Text, password = txtPassword.Text };
                Session.Add("userDetails", details);
            }

=======
<<<<<<< HEAD
            if (IsValid)
            {
                //Add session
                User details = new User { userName = txtUserName.Text, password = txtPassword.Text};
                Session.Add("userDetails", details);
            }
        }
=======
>>>>>>> c89d18a0c2e404e2d643744f4eb0beabfc6b814f
            string hash=GetMd5Hash(txtPassword.Text);
            var dd = db.User_tbl.Where(a => a.UserName == txtUserName.Text && a.Password == hash).FirstOrDefault();
            if (dd != null)
            {
                Response.Redirect("PlannerPage.aspx");
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
<<<<<<< HEAD
        }       
=======
        }
       
>>>>>>> 7f064d8957f6f5462d4b97fc81416a0e127c1bbc
        
>>>>>>> c89d18a0c2e404e2d643744f4eb0beabfc6b814f
    }
}