using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalBuster
{
    public partial class CalBuster : System.Web.UI.MasterPage
    {
        public string userNme
        {
            get { return this.userLoggedIn.Text; }
            set { this.userLoggedIn.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}