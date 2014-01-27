using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalBuster
{
    public partial class PlannerPage : System.Web.UI.Page
    {

        private string type = "";
        private int counter = 1;
        private int lunchCount = 3;
        private int dinnerCount = 5;
        private int snacksCount = 7;
        //Cal_BusterEntities1 cd = new Cal_BusterEntities1();
        Calorie_BusterEntities cd = new Calorie_BusterEntities();

        private List<item> brekyItems = new List<item>();
        private List<item> lunchItems = new List<item>();
        private List<item> dinnerItems = new List<item>();
        private List<item> snacksItems = new List<item>();
        private bool IsPageRefresh;
        string show = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Page.MaintainScrollPositionOnPostBack = true;
            IsPageRefresh = false;

            if (Page.IsPostBack)
            {
                string h = ViewState["ViewStateId"].ToString();
                string k = Session["SessionId"].ToString();
                if (Session["SessionId"] != null)
                {
                    if (ViewState["ViewStateId"].ToString() != Session["SessionId"].ToString())     // check if its a postback from user clicking refresh
                    {
                        IsPageRefresh = true;
                    }
                    Session["SessionId"] = System.Guid.NewGuid().ToString();
                    ViewState["ViewStateId"] = Session["SessionId"].ToString();
                }
            }
            if (IsPageRefresh == true) { return; }
            if (Page.IsPostBack && IsPageRefresh == false)
            {
                show = (string)Session["show"];
                if (show == "yes") { searchForMeal.Visible = true; titleDiv.Visible = false; }
                else { searchForMeal.Visible = false; titleDiv.Visible = true; }
                if (Session["counter"] != null) { counter = (int)Session["counter"]; }
                if (Session["lunchCount"] != null) { lunchCount = (int)Session["lunchCount"]; }
                if (Session["dinnerCount"] != null) { dinnerCount = (int)Session["dinnerCount"]; }
                if (Session["snacksCount"] != null) { snacksCount = (int)Session["snacksCount"]; }

                if (Session["brekyItems"] != null) { brekyItems = (List<item>)Session["brekyItems"]; }
                if (Session["lunchItems"] != null) { lunchItems = (List<item>)Session["lunchItems"]; }
                if (Session["dinnerItems"] != null) { dinnerItems = (List<item>)Session["dinnerItems"]; }
                if (Session["snacksItems"] != null) { snacksItems = (List<item>)Session["snacksItems"]; }
                int bc = 2;
                int lc = 4;
                int dc = 6;
                int sc = 8;
                type = (string)Session["type"];
                if (brekyItems.Count != 0 || type == "breakfast")
                {
                    bc = 2;
                    foreach (var item in brekyItems)
                    {
                        addRowCalCountOnPostBack(item, bc);
                        bc++;
                    }
                }
                lc = bc + 2;
                if (lunchItems.Count != 0 || type == "lunch")
                {
                    foreach (var item in lunchItems)
                    {
                        addRowCalCountOnPostBack(item, lc);
                        lc++;
                    }
                }
                dc = lc + 2;
                if (dinnerItems.Count != 0 || type == "Dinner")
                {
                    foreach (var item in dinnerItems)
                    {
                        addRowCalCountOnPostBack(item, dc);
                        dc++;
                    }
                }
                sc = dc + 2;
                if (snacksItems.Count != 0 || type == "Snacks")
                {
                    foreach (var item in snacksItems)
                    {
                        addRowCalCountOnPostBack(item, sc);
                        sc++;
                    }
                }
            }

            TreeView1.ExpandDepth = 0;
            TreeView1.RootNodeStyle.ImageUrl = "images/cuts.jpg";
            if (!Page.IsPostBack)
            {
                
                lblDate.Text = string.Format("{0} the {1} of {2} {3}", DateTime.Today.DayOfWeek, DateTime.Now.Day, DateTime.Now.ToString("MMMM"), DateTime.Today.Year);
                searchForMeal.Visible = false;
                Session.Clear();
                brekyItems.Clear();
                lunchItems.Clear();
                dinnerItems.Clear();
                snacksItems.Clear();
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
                var q = from a in cd.FoodItem_tbl
                        where a.TypeOf == "cereal"
                        select a;
                foreach (var item in q)
                {
                    TreeView1.Nodes[0].ChildNodes[0].ChildNodes.Add(new TreeNode(item.Name, item.Item_id.ToString()));
                    
                }
                var fry = cd.Meal_tbl.Where(a => a.TypeOf == "fry");
                foreach (var item in fry)
                {
                    TreeView1.Nodes[0].ChildNodes[1].ChildNodes.Add(new TreeNode(item.Name, item.meal_id.ToString()));
                }
                var eggs = cd.Meal_tbl.Where(a => a.TypeOf == "egg");
                foreach (var item in eggs)
                {
                    TreeView1.Nodes[0].ChildNodes[2].ChildNodes.Add(new TreeNode(item.Name, item.meal_id.ToString()));
                }

                TreeView1.Nodes[1].ChildNodes.Add(new TreeNode("Sandwiches"));
                TreeView1.Nodes[1].ChildNodes.Add(new TreeNode("Wraps"));
                TreeView1.Nodes[1].ChildNodes.Add(new TreeNode("chipper"));
                

                var sambo = cd.FoodItem_tbl.Where(a => a.TypeOf == "sambo");
                foreach (var item in sambo)
                {
                    TreeView1.Nodes[1].ChildNodes[0].ChildNodes.Add(new TreeNode(item.Name, item.Item_id.ToString()));
                }

                var wrap = cd.FoodItem_tbl.Where(a => a.TypeOf == "wrap");
                foreach (var item in wrap)
                {
                    TreeView1.Nodes[1].ChildNodes[1].ChildNodes.Add(new TreeNode(item.Name, item.Item_id.ToString()));
                }

                var chipper = cd.FoodItem_tbl.Where(a => a.TypeOf == "chipper");
                foreach (var item in chipper)
                {
                    TreeView1.Nodes[1].ChildNodes[2].ChildNodes.Add(new TreeNode(item.Name, item.Item_id.ToString()));
                }

                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("Chicken"));
                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("Beef"));
                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("Pork"));
                TreeView1.Nodes[2].ChildNodes.Add(new TreeNode("Fish"));

                var chicken = cd.Meal_tbl.Where(a => a.TypeOf == "chicken");
                foreach (var item in chicken)
                {
                    TreeView1.Nodes[2].ChildNodes[0].ChildNodes.Add(new TreeNode(item.Name, item.meal_id.ToString()));
                }
                var Beef = cd.Meal_tbl.Where(a => a.TypeOf == "Beef");
                foreach (var item in Beef)
                {
                    TreeView1.Nodes[2].ChildNodes[1].ChildNodes.Add(new TreeNode(item.Name, item.meal_id.ToString()));
                }
                var Pork = cd.Meal_tbl.Where(a => a.TypeOf == "Pork");
                foreach (var item in Pork)
                {
                    TreeView1.Nodes[2].ChildNodes[2].ChildNodes.Add(new TreeNode(item.Name, item.meal_id.ToString()));
                }
                var Fish = cd.Meal_tbl.Where(a => a.TypeOf == "Fish");
                foreach (var item in Fish)
                {
                    TreeView1.Nodes[2].ChildNodes[3].ChildNodes.Add(new TreeNode(item.Name, item.meal_id.ToString()));
                }

                TreeView1.Nodes[3].ChildNodes.Add(new TreeNode("Drinks"));
                TreeView1.Nodes[3].ChildNodes.Add(new TreeNode("choclate"));
                TreeView1.Nodes[3].ChildNodes.Add(new TreeNode("Cake"));

                var drinks = cd.FoodItem_tbl.Where(a => a.TypeOf == "drinks");
                foreach (var item in drinks)
                {
                    TreeView1.Nodes[3].ChildNodes[0].ChildNodes.Add(new TreeNode(item.Name, item.Item_id.ToString()));
                }
                var sweets = cd.FoodItem_tbl.Where(a => a.TypeOf == "sweets");
                foreach (var item in sweets)
                {
                    TreeView1.Nodes[3].ChildNodes[1].ChildNodes.Add(new TreeNode(item.Name, item.Item_id.ToString()));
                }
                var cake = cd.FoodItem_tbl.Where(a => a.TypeOf == "cake");
                foreach (var item in cake)
                {
                    TreeView1.Nodes[3].ChildNodes[2].ChildNodes.Add(new TreeNode(item.Name, item.Item_id.ToString()));
                }

                for (int i = 0; i < TreeView1.Nodes.Count; i++)                     // disable all nodes except leaf nodes
                {
                    TreeView1.Nodes[i].SelectAction = TreeNodeSelectAction.None;
                    for (int j = 0; j < TreeView1.Nodes[i].ChildNodes.Count; j++)
                    {
                        TreeView1.Nodes[i].ChildNodes[j].SelectAction = TreeNodeSelectAction.None;
                    }
                }
                ViewState["ViewStateId"] = System.Guid.NewGuid().ToString();
                Session["SessionId"] = ViewState["ViewStateId"].ToString();
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            //Cal_BusterEntities1 db = new Cal_BusterEntities1();
            Calorie_BusterEntities db = new Calorie_BusterEntities();
            var foods = db.FoodItem_tbl.Select(a => a.Name);
            List<string> food = new List<string>();
            foreach (var item in foods)
            {
                food.Add(item);
            }
            return (from m in food where m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select m).Take(count).ToArray();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string word = txtSearch.Text;

            var y = cd.FoodItem_tbl.Where(a => a.Name.Contains(txtSearch.Text)).FirstOrDefault();
            item mm = new item { id = y.Item_id, name = y.Name };
            hidFoodId.Value = mm.id.ToString();
            lblSelectedItem.Text = mm.name;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            LinkButton bt = (LinkButton)sender;
            if (bt.ID == "lnkBtnBreakfast") { counter = 2; type = "breakfast"; }
            else if (bt.ID == "lnkBtnLunch") { lunchCount = 4; type = "lunch"; }
            else if (bt.ID == "lnkBtnDinner") { dinnerCount = 6; type = "Dinner"; }
            else if (bt.ID == "LnkBtnSnacks") { snacksCount = 8; type = "Snacks"; }
            lblTitle.Text = "Add food to your " + type + " catagory";
            searchForMeal.Visible = true;
            titleDiv.Visible = false;
            show = "yes";
            Session.Add("show", show);
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

            if (Session["totalCal"] != null) { TotalsRow.Cells[1].Text = (((int)Session["totalCal"]) + (one.cal)).ToString(); }
            Session.Add("totalCal", (Convert.ToInt32(TotalsRow.Cells[1].Text)));
            if (Session["totalCarb"] != null) { TotalsRow.Cells[2].Text = (((double)Session["totalCarb"]) + (one.carb)).ToString(); }
            Session.Add("totalCarb", (Convert.ToDouble(TotalsRow.Cells[2].Text)));
            if (Session["totalFat"] != null) { TotalsRow.Cells[3].Text = (((double)Session["totalFat"]) + (one.fat)).ToString(); }
            Session.Add("totalFat", (Convert.ToDouble(TotalsRow.Cells[3].Text)));
            if (Session["totalProtien"] != null) { TotalsRow.Cells[4].Text = (((double)Session["totalProtien"]) + (one.protien)).ToString(); }
            Session.Add("totalProtien", (Convert.ToDouble(TotalsRow.Cells[4].Text)));
            if (Session["totalSugar"] != null) { TotalsRow.Cells[5].Text = (((double)Session["totalSugar"]) + (one.sugar)).ToString(); }
            Session.Add("totalSugar", (Convert.ToDouble(TotalsRow.Cells[5].Text)));

        }

        protected void goBack_Click(object sender, EventArgs e)     //button to add selected food to daily record
        {
            if (IsPageRefresh == true) { return; }
            if (type == "breakfast") { counter++; lunchCount++; dinnerCount++; snacksCount++; }
            else if (type == "lunch") { lunchCount++; dinnerCount++; snacksCount++; }
            else if (type == "Dinner") { dinnerCount++; snacksCount++; }
            else if (type == "Snacks") { snacksCount++; }

            item food = new item();
            string nme = lblSelectedItem.Text;
            int y = Convert.ToInt32(hidFoodId.Value);
            var meal = cd.Meal_tbl.Where(n => n.meal_id == y && n.Name == nme).FirstOrDefault();
            if (meal != null)
            {
                food = calcAllDetails(meal);
            }
            var r = cd.FoodItem_tbl.Where(n => n.Item_id == y && n.Name == nme).FirstOrDefault();   // check if its a meal or single food item
            int portions = Convert.ToInt32(txtPortions.Text);
            if (r != null) { food = new item { name = r.Name, id = r.Item_id, cal = (int)r.Calories * portions, carb = (double)r.Carbs * portions, fat = (double)r.Fat * portions, gPerItem = (int)r.GramPerPortion, protien = (double)r.Protein * portions, sodium = (double)r.Sodium * portions, sugar = (double)r.Sugar * portions }; }

            searchForMeal.Visible = false;
            titleDiv.Visible = true;
            show = (string)Session["show"];
            show = "no";
            Session.Add("show", show);
            if (type == "breakfast") { addRowCalCount(food, counter); brekyItems.Add(food); }
            else if (type == "lunch") { addRowCalCount(food, lunchCount); lunchItems.Add(food); }
            else if (type == "Dinner") { addRowCalCount(food, dinnerCount); dinnerItems.Add(food); }
            else if (type == "Snacks") { addRowCalCount(food, snacksCount); snacksItems.Add(food); }

            Session.Add("counter", counter);
            Session.Add("lunchCount", lunchCount);
            Session.Add("dinnerCount", dinnerCount);
            Session.Add("snacksCount", snacksCount);

            Session.Add("brekyItems", brekyItems);
            Session.Add("lunchItems", lunchItems);
            Session.Add("dinnerItems", dinnerItems);
            Session.Add("snacksItems", snacksItems);
        }

        private item calcAllDetails(Meal_tbl meal)
        {
            item food = new item();
            food.name = meal.Name;
            double protien=0, carb=0, sugar=0, fat=0, sodium=0;
            double cal = 0;
            var vg = from a in cd.FoodItem_tbl                           //get each food item from this meal and their quantity
                     join b in cd.Link_tbl on a.Item_id equals b.Item_id
                     where b.Meal_id == meal.meal_id
                     select a;
            foreach (var item in vg)                                    // total prot,carbs... for each one
            {
                var y = cd.Link_tbl.Where(n => n.Item_id == item.Item_id && n.Meal_id == meal.meal_id).FirstOrDefault();
                double qt = (double)y.Quantity;
                protien += (double)item.Protein * qt;
                carb += ((double)item.Carbs) * qt;
                sugar += ((double)item.Sugar) * qt;
                fat += ((double)item.Fat) * qt;
                sodium += ((double)item.Sodium) * qt;
                cal += ((double)item.Calories) * qt;
            }
            food.protien = protien; food.carb = carb; food.sugar = sugar; food.fat = fat;
            food.sodium = sodium; food.cal = (int)cal;
            return food;
        }
        protected void TreeV_SelectedNodeChanged(object sender, EventArgs e)
        {
            
            lblSelectedItem.Text = TreeView1.SelectedNode.Text;
            hidFoodId.Value = TreeView1.SelectedValue.ToString();
        }

        protected void btnAddAllToDb_Click(object sender, EventArgs e)
        {
            PastMeal_tbl pm = new PastMeal_tbl { User_id = 1, Date = DateTime.Now };
            cd.PastMeal_tbl.Add(pm);
            cd.SaveChanges();
            if (brekyItems.Count() != 0)
            {
                foreach (var item in brekyItems)
                {
                    PastLink_tbl pl = new PastLink_tbl { Meal_id = item.id, Past_Meal_id = pm.PastMeal_id };
                    cd.PastLink_tbl.Add(pl);
                    cd.SaveChanges();
                }
            }
            if (lunchItems.Count() != 0)
            {
                foreach (var item in lunchItems)
                {
                    PastLink_tbl pl = new PastLink_tbl { Meal_id = item.id, Past_Meal_id = pm.PastMeal_id };
                    cd.PastLink_tbl.Add(pl);
                    cd.SaveChanges();
                }
            }
            if (dinnerItems.Count() != 0)
            {
                foreach (var item in dinnerItems)
                {
                    PastLink_tbl pl = new PastLink_tbl { Meal_id = item.id, Past_Meal_id = pm.PastMeal_id };
                    cd.PastLink_tbl.Add(pl);
                    cd.SaveChanges();
                }
            }
            if (snacksItems.Count() != 0)
            {
                foreach (var item in snacksItems)
                {
                    PastLink_tbl pl = new PastLink_tbl { Meal_id = item.id, Past_Meal_id = pm.PastMeal_id };
                    cd.PastLink_tbl.Add(pl);
                    cd.SaveChanges();
                }
            }
        }
    }
}