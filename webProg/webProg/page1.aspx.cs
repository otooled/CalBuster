using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace webProg
{
    public partial class page1 : System.Web.UI.Page
    {
        private string type = "" ;
        private int counter = 1;
        private int lunchCount = 3;
        
        dbEntities1 cd = new dbEntities1();
        private List<item> brekyItems = new List<item>();
        private List<item> lunchItems = new List<item>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            searchForMeal.Visible = false;
            if (Page.IsPostBack)
            {
                searchForMeal.Visible = true;
                if (Session["counter"] != null) { counter = (int)Session["counter"]; }
                if (Session["lunchCount"] != null) { lunchCount = (int)Session["lunchCount"]; }
                if (Session["brekyItems"] != null) { brekyItems = (List<item>)Session["brekyItems"]; }
                if (Session["lunchItems"] != null) { lunchItems = (List<item>)Session["lunchItems"]; }
                int bc = 2;
                int lc = 4;
                type = (string)Session["type"];                    
                    if (brekyItems.Count != 0 || type == "brek")
                    {
                        bc = 2;
                        foreach (var item in brekyItems)
                        {
                            addRowCalCountOnPostBack(item, bc);
                            bc++;
                        }
                    }
                    lc = bc + 2;
                    if (lunchItems.Count != 0 || type == "lunch" )
                    {
                        
                        foreach (var item in lunchItems)
                        {
                            addRowCalCountOnPostBack(item, lc);
                            lc++;
                        }
                    }
                
            }
            
            TreeView1.ExpandDepth = 0;
            TreeView1.RootNodeStyle.ImageUrl = "images/cuts.jpg";
            if (!Page.IsPostBack)
            {
                for (int i = 1; i < 6; i++)                     // set total to 0
                {
                    TotalsRow.Cells[i].Text = "";
                }
                Session.Add("totalCal", 0);
                Session.Add("totalCarb", 0.0);
                Session.Add("totalFat", 0.0);
                Session.Add("totalProtien", 0.0);
                Session.Add("totalSugar", 0.0);
                lunchItems.Clear();
                brekyItems.Clear();
                TreeView1.Nodes.Add(new TreeNode("Breakfast"));
                TreeView1.Nodes.Add(new TreeNode("Lunch"));
                TreeView1.Nodes.Add(new TreeNode("Dinner"));
                TreeView1.Nodes.Add(new TreeNode("Snacks"));

                TreeView1.Nodes[0].ChildNodes.Add(new TreeNode("Cereals"));
                TreeView1.Nodes[0].ChildNodes.Add(new TreeNode("fries"));
                TreeView1.Nodes[0].ChildNodes.Add(new TreeNode("eggs"));
                var q = from a in cd.dryGoods_tbl
                        where a.typeOf == "cereal"
                        select a;
                foreach (var item in q)
                {
                    TreeView1.Nodes[0].ChildNodes[0].ChildNodes.Add(new TreeNode(item.itemName, item.item_id.ToString()));
                }

                TreeView1.Nodes[0].ChildNodes[1].ChildNodes.Add(new TreeNode("grandChildNode2"));
                TreeView1.Nodes[0].ChildNodes[1].ChildNodes.Add(new TreeNode("grandChildNode2"));
                TreeView1.Nodes[0].ChildNodes[1].ChildNodes.Add(new TreeNode("grandChildNode2"));

                TreeView1.Nodes[0].ChildNodes[2].ChildNodes.Add(new TreeNode("grandChildNode3"));
                TreeView1.Nodes[0].ChildNodes[2].ChildNodes.Add(new TreeNode("grandChildNode3"));
                TreeView1.Nodes[0].ChildNodes[2].ChildNodes.Add(new TreeNode("grandChildNode3"));

                TreeView1.Nodes[1].ChildNodes.Add(new TreeNode("sandwiches"));
                TreeView1.Nodes[1].ChildNodes.Add(new TreeNode("hot food"));
                TreeView1.Nodes[1].ChildNodes.Add(new TreeNode("chipper"));

                TreeView1.Nodes[1].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[1].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[1].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));

                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("sandwiches"));
                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("hot food"));
                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("chipper"));

                TreeView1.Nodes[2].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[2].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[2].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));

                TreeView1.Nodes[3].ChildNodes.Add(new TreeNode("sandwiches"));
                TreeView1.Nodes[3].ChildNodes.Add(new TreeNode("hot food"));
                TreeView1.Nodes[3].ChildNodes.Add(new TreeNode("chipper"));

                TreeView1.Nodes[3].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[3].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
                TreeView1.Nodes[3].ChildNodes[0].ChildNodes.Add(new TreeNode("grandChildNode1"));
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string word = txtSearch.Text;
            var y = (from a in cd.veg_tbl
                     where a.description.Contains(txtSearch.Text) == true
                     select a).FirstOrDefault();
            item mm = new item { id = y.veg_id, name = y.description };
            
            lstPicked.Items.Add(mm.name);
	         
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            LinkButton bt = (LinkButton)sender;
            if (bt.ID == "lnkBtnBreakfast") { counter = 2; type = "brek"; }
            else if (bt.ID == "lnkBtnLunch") { lunchCount = 4; type = "lunch"; }
            searchForMeal.Visible = true;
            title.Visible = false;
            //LinkButton lb = (LinkButton)sender;
            //type = lb.ID;
            Session.Add("type", type);
        }

        private void addRowCalCountOnPostBack(item one, int cc)
        {
            TableRow row = new TableRow();
            for (int i = 0; i < 6; i++)
            {
                TableCell tc = new TableCell();
                tc.CssClass = "alt2";
                row.Cells.Add(tc);
            }
            row.Cells[0].CssClass = "lside";
            row.Cells[0].Text = one.name.ToString();
            row.Cells[1].Text = one.cal.ToString();
            row.Cells[2].Text = one.carb.ToString();
            row.Cells[3].Text = one.fat.ToString();
            row.Cells[4].Text = one.protien.ToString();
            row.Cells[5].Text = one.sugar.ToString();
            tblAdded.Rows.AddAt(cc, row);

            if (Session["totalCal"] != null) { TotalsRow.Cells[1].Text = ((int)Session["totalCal"]).ToString(); }
            if (Session["totalCarb"] != null) { TotalsRow.Cells[2].Text = ((double)Session["totalCarb"]).ToString(); }
            if (Session["totalFat"] != null) { TotalsRow.Cells[3].Text = ((double)Session["totalFat"]).ToString(); }
            if (Session["totalProtien"] != null) { TotalsRow.Cells[4].Text = ((double)Session["totalProtien"]).ToString(); }
            if (Session["totalSugar"] != null) { TotalsRow.Cells[5].Text = ((double)Session["totalSugar"]).ToString(); }
        }

        private void addRowCalCount(item one, int cc)
        {
            TableRow row = new TableRow();
            for (int i = 0; i < 6; i++)
            {
                TableCell tc = new TableCell();
                tc.CssClass = "alt2";
                row.Cells.Add(tc);
            }
            row.Cells[0].CssClass = "lside";
            row.Cells[0].Text = one.name.ToString();
            row.Cells[1].Text = one.cal.ToString();
            row.Cells[2].Text = one.carb.ToString();
            row.Cells[3].Text = one.fat.ToString();
            row.Cells[4].Text = one.protien.ToString();
            row.Cells[5].Text = one.sugar.ToString();
            tblAdded.Rows.AddAt(cc, row);

           if(Session["totalCal"] != null){ TotalsRow.Cells[1].Text = (((int)Session["totalCal"]) + (one.cal)).ToString(); }
           Session.Add("totalCal", (Convert.ToInt32(TotalsRow.Cells[1].Text)));
           if (Session["totalCarb"] != null) { TotalsRow.Cells[2].Text = (((double)Session["totalCarb"]) + (one.carb)).ToString(); }
           Session.Add("totalCarb", (Convert.ToDouble(TotalsRow.Cells[2].Text)));
           if (Session["totalFat"] != null) { TotalsRow.Cells[3].Text = (((double)Session["totalFat"]) + (one.fat)).ToString(); }
           Session.Add("totalFat", (Convert.ToDouble(TotalsRow.Cells[3].Text)));
           if (Session["totalProtien"] != null) { TotalsRow.Cells[4].Text = (((double)Session["totalProtien"]) + (one.protien)).ToString(); }
           Session.Add("totalProtien", (Convert.ToDouble(TotalsRow.Cells[4].Text)));
           if (Session["totalSugar"] != null) { TotalsRow.Cells[5].Text = (((double)Session["totalSugar"]) + (one.sugar)).ToString(); }
           Session.Add("totalSugar", (Convert.ToDouble(TotalsRow.Cells[5].Text)));
            //TotalsRow.Cells[2].Text = ((Convert.ToDouble(TotalsRow.Cells[2].Text)) + (one.carb)).ToString();
            //TotalsRow.Cells[3].Text = ((Convert.ToDouble(TotalsRow.Cells[3].Text)) + (one.fat)).ToString();
            //TotalsRow.Cells[4].Text = ((Convert.ToDouble(TotalsRow.Cells[4].Text)) + (one.protien)).ToString();
            //TotalsRow.Cells[5].Text = ((Convert.ToDouble(TotalsRow.Cells[5].Text)) + (one.sugar)).ToString();

        }

        protected void goBack_Click(object sender, EventArgs e)     //button to add selected food to daily record
        {
            if (type == "brek") { counter++; }
            else if (type == "lunch") { lunchCount++; }
            item food = new item();
            int y = Convert.ToInt32(txtID.Text);
            var r = cd.veg_tbl.Select(a => a).Where(n => n.veg_id == y).FirstOrDefault();
            if (r != null) { food = new item { name = r.description, id = r.veg_id, cal = (int)r.calorie, carb = (double)r.carbs, fat = (double)r.fat, gPerItem = (int)r.kgPerUnit, protien = (double)r.protien, sodium = (double)r.sodium, sugar = (double)r.sugar }; }
            var dry = cd.dryGoods_tbl.Select(a => a).Where(n => n.item_id == y).FirstOrDefault();
            if (dry != null) { food = new item { name = dry.itemName, id = dry.item_id, cal = (int)dry.calorie, carb = (double)dry.carbs, fat = (double)dry.fat, gPerItem = (int)dry.gPerUnit, protien = (double)dry.protien, sodium = (double)dry.sodium, sugar = (double)dry.sugar }; }
            searchForMeal.Visible = false;
            title.Visible = true;
            if (type == "brek") { addRowCalCount(food, counter); brekyItems.Add(food); }
            else if (type == "lunch") { addRowCalCount(food, lunchCount); lunchItems.Add(food); }
            
            Session.Add("counter", counter);
            Session.Add("lunchCount", lunchCount);
            
            Session.Add("brekyItems", brekyItems);
            Session.Add("lunchItems", lunchItems);
        }

        protected void TreeV_SelectedNodeChanged(object sender, EventArgs e)
        {
            lstPicked.Items.Add(TreeView1.SelectedNode.Text);
            txtNme.Text = TreeView1.SelectedNode.Text;
            txtID.Text = TreeView1.SelectedValue.ToString();
            
        }
 
    }
}