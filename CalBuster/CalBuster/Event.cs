using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;

namespace CalBuster
{
    public class Event
    {
        public void sendEmails(string email, string OthersNme, string nme)
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            MailAddress from = new MailAddress("calbuster66@gmail.com", "[ CalBuster ]");
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to);
            if (OthersNme != "today's achiever")                // check if its other member or this one
            {
                message.Body = "Hi " + OthersNme + " . This is an email from CalBuster to let know that " + nme + " hit their target today!!!";
            }
            else
            {
                message.Body = "Hi " + nme + " . Congradulations, you've hit your CalBuster target today!!!";
            }
            message.Subject = "Today's goal acheivers";
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
        }
    }
}