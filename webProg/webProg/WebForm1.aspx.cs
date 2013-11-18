using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webProg
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddd.Visible = false;
            //g.Attributes.Add("onclick", "showDiv()");

            if (Page.IsPostBack)
            {
                ddd.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ddd.Visible = true;
            TableRow row1 = new TableRow();
            for (int i = 0; i < 6; i++)
            {               
                TableCell tc = new TableCell();
                tc.Text = "sheds";
                row1.Cells.Add(tc);
                
            }
            row1.Cells[4].Text = "motogus";
            tblAdded.Rows.Add(row1);
        }
        private void showDiv()
        {
            ddd.Visible = true; 
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ddd.Visible = true;
            TableRow row = new TableRow();
            TableRow row1 = new TableRow();

            TableCell tc = new TableCell();
            tc.Text = "sheds";
            row1.Cells.Add(tc);
            tblAdded.Rows.Add(row1);
        }
    }
}