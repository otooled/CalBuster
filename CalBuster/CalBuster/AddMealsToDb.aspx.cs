using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalBuster
{
    public partial class AddMealsToDb : System.Web.UI.Page
    {
        Calorie_BusterEntities cd = new Calorie_BusterEntities();
        private List<item> ingregients = new List<item>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;       // reset page to where it was before postback
            if (!Page.IsPostBack)
            {
                Label mylbl = (Label)((MasterPage)this.Master).FindControl("userLoggedIn");     // get label by id from master page
                if (mylbl != null)
                {
                    User user = new User();
                    if (Session["userDetails"] != null) { user = (((User)Session["userDetails"])); }
                    mylbl.Text = user.userName;
                }
                lstDrygoods.SelectedIndex = 0;
                lstmeat.SelectedIndex = 0;
                lstVeg.SelectedIndex = 0;
            }
            if (Page.IsPostBack)
            {
                if (Session["ingreds"] != null) { ingregients = (List<item>)Session["ingreds"]; }
            }
        }

        protected void btnAddMeal_Click(object sender, EventArgs e)     // submit to db
        {
            //var typeOf = cd.FoodItem_tbl.Where(a => a.Item_id == Convert.ToInt32(hdfSelValue.Value)).Select(n => n.TypeOf).FirstOrDefault();
            if (txtName.Text == "" || listToAdd.Items.Count < 1) { txtName.Focus(); return; }
            try
            {
                Meal_tbl din = new Meal_tbl { Name = txtName.Text };        // add new meal
                cd.Meal_tbl.Add(din);
                cd.SaveChanges();
                foreach (var it in ingregients)                             // add all ingredients for that meal
                {
                    var veg = cd.FoodItem_tbl.Where(a => a.Item_id == it.id && a.Name == it.name);
                    if (veg.Count() != 0)
                    {
                        Link_tbl lk = new Link_tbl { Meal_id = din.meal_id, Item_id = it.id, Quantity = it.quantity };
                        cd.Link_tbl.Add(lk);
                    }
                    cd.SaveChanges();
                }
            }
            catch { }
            finally
            {
                ingregients.Clear();                // reset and go back to planner
                listToAdd.Items.Clear();
                Response.Redirect("PlannerPage.aspx");
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)     // add selected food and portion amount to list
        {
            if (txtQuantity.Text == "") { txtQuantity.Focus(); return; }
            item t = new item { id = Convert.ToInt32(hdfSelValue.Value), name = txtSelectedItem.Text, quantity = Convert.ToDecimal(txtQuantity.Text) };
            ingregients.Add(t);
            string gg = string.Format("{0} portions of {1}   ", t.quantity, t.name);
            listToAdd.Items.Add(gg);
            Session.Add("ingreds", ingregients);
            txtQuantity.Text = "";
        }

        protected void lstVeg_SelectedIndexChanged1(object sender, EventArgs e) // check which listbox selected
        {
            txtQuantity.Focus();
            ListBox d = (ListBox)sender;                        // check which food collection it is
            txtSelectedItem.Text = d.SelectedItem.ToString();   // add name and id value for user to click button to add to the list
            hdfSelValue.Value = d.SelectedValue;
            //item s = new item { name = d.SelectedItem.ToString(), id = Convert.ToInt32(d.SelectedValue) };
            //ingregients.Add(s);
            //listToAdd.Items.Add(d.SelectedItem);
        }

        protected void btnBackToPlanner_Click(object sender, EventArgs e)   // go back
        {
            Response.Redirect("PlannerPage.aspx");
        }
    }
}