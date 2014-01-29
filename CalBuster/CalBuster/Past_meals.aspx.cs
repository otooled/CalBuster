using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.DataVisualization.Charting;


namespace CalBuster
{
    public partial class Past_meals : System.Web.UI.Page
    {
        //checking for userdetails

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userDetails"] != null)
            {
                User nn = ((User)Session["userDetails"]);
                Label lbl = (Label)((MasterPage)this.Master).FindControl("userLoggedIn");       // set user name label at the top
                if (lbl != null)
                {
                    //displaying current name of user logged in
                    lbl.Text = nn.userName;

                }
            }
        }
       

        //funtion to calculate all values protein caloires...... for a meal
        private Calculated_results calcualte_all_values(int pastmealid)
        {
            //creating calculated class to hold caloires fats sugars......
            Calculated_results Calculated_results = new Calculated_results();

            int Meal_id = 0;

            //connet to database
            Calorie_BusterEntities db = new Calorie_BusterEntities();

            //retreving meals based on pastmealsid
            var mealsId = db.PastLink_tbl.Select(a => a).Where(n => n.Past_Meal_id == pastmealid);//FirstOrDefault();

            //creating string builder to display results
            StringBuilder sb = new StringBuilder();

            //generating mealsId
            foreach (var item in mealsId)
            {

                Meal_id = item.Meal_id;
               
            }
   
            //generating list of items from meal_id
            var items = db.Link_tbl.Select(a => a).Where(n => n.Meal_id == Meal_id);//FirstOrDefault();

            //calculating totals for each items
            foreach (var item in items)
            {
                //calcualteing the quanity of items
                var y = db.Link_tbl.Select(a => a).Where(n => n.Item_id == item.Item_id && n.Meal_id == Meal_id).FirstOrDefault();
                var Food_itmes = db.FoodItem_tbl.Select(a => a).Where(n => n.Item_id == item.Item_id);//FirstOrDefault();

                //generating summarys and totals
                foreach (var food_item in Food_itmes)
                {
                    //building summary data
                    sb.Append(y.Quantity);
                    sb.Append(" ");
                    sb.Append(food_item.Name);

                    sb.Append(", ");

                    // genearting totals
                    if (food_item.Calories != null)
                    {
                        int nCalories = (int)food_item.Calories;
                        nCalories *= (int)y.Quantity;
                        Calculated_results.Calories += nCalories;
                    }

                    if (food_item.Sodium != null)
                    {
                        float fSodium = (float)food_item.Sodium;
                        fSodium *= (int)y.Quantity;
                        Calculated_results.Sodium += fSodium;
                    }

                    if (food_item.Carbs != null)
                    {
                        float fCarbs = (float)food_item.Carbs;
                        fCarbs *= (int)y.Quantity;
                        Calculated_results.Carbs += fCarbs;
                    }

                    if (food_item.Sugar != null)
                    {
                        float fSugar = (float)food_item.Sugar;
                        fSugar *= (int)y.Quantity;
                        Calculated_results.Sugar += fSugar;

                    }

                    if (food_item.Fat != null)
                    {
                        float fFat = (float)food_item.Fat;
                        fFat *= (int)y.Quantity;
                        Calculated_results.Fat += fFat;
                    }

                    if (food_item.Protein != null)
                    {
                        float fProtein = (float)food_item.Protein;
                        fProtein *= (int)y.Quantity;
                        Calculated_results.Protein += fProtein;
                    }


                }
            }
            //closing connection to database
            db.Database.Connection.Close();
            db.Dispose();
            //output summary of items to screen
            tbx_Meal.Text += sb.ToString();
            tbx_Meal.Text += System.Environment.NewLine;

            return Calculated_results;
        }


        // only allow dates to be picked in past
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Now)
            {
               
                e.Cell.BackColor = System.Drawing.Color.WhiteSmoke;
                e.Day.IsSelectable = false;
            }
     
        }


        //useing calender date to select meal id and calcualte protien, calories.... for that meal
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            int userID = 3;
            //getting current userID from session
            if (Session["userDetails"] != null)
            {
                User nn = ((User)Session["userDetails"]);
                Label lbl = (Label)((MasterPage)this.Master).FindControl("userLoggedIn");       // set user name label at the top
                if (lbl != null)
                {
                    userID = nn.userId;

                }
            }
            //connection to data base
            Calorie_BusterEntities db = new Calorie_BusterEntities();

            Calculated_results calcResults = new Calculated_results();
            //pulling data back form data base for date selected for user logged in 
            var Past_meal_ids = db.PastMeal_tbl.Select(a => a).Where(n => (n.User_id == userID) &&
                                                                          (n.Date.Day == Calendar1.SelectedDate.Day) &&
                                                                          (n.Date.Month == Calendar1.SelectedDate.Month) &&
                                                                          (n.Date.Year == Calendar1.SelectedDate.Year));//FirstOrDefault();
            //output summary 
            tbx_Meal.Text = "On the " + Calendar1.SelectedDate.ToShortDateString() + " you ate:" + System.Environment.NewLine;

            List<int> list_of_food_items = new List<int>();

            StringBuilder sb = new StringBuilder();
            //generating summary data and totals
            foreach (var item in Past_meal_ids)
            {

                sb.Append(item.PastMeal_id);
                sb.Append(", ");
                sb.Append(item.User_id);
                sb.Append(", ");
                sb.Append(item.Date);
                sb.Append(System.Environment.NewLine);
                //accumlating total results  
                calcResults.add(calcualte_all_values(item.PastMeal_id));


            }
            //close connection to database
            db.Database.Connection.Close();
            db.Dispose();

        //outputting total to screen
            Past_Meals_Table.Rows[1].Cells[0].Text = Calendar1.SelectedDate.ToShortDateString();
            Past_Meals_Table.Rows[1].Cells[1].Text = calcResults.Calories.ToString();
            Past_Meals_Table.Rows[1].Cells[2].Text = calcResults.Carbs.ToString();
            Past_Meals_Table.Rows[1].Cells[3].Text = calcResults.Fat.ToString();
            Past_Meals_Table.Rows[1].Cells[4].Text = calcResults.Protein.ToString();
            Past_Meals_Table.Rows[1].Cells[5].Text = calcResults.Sugar.ToString();
        }
        //calculating weeks work of data
        public List<Calculated_results> GetSevenDays()
        {
            int userID = 3;

            if (Session["userDetails"] != null)
            {
                User nn = ((User)Session["userDetails"]);
                Label lbl = (Label)((MasterPage)this.Master).FindControl("userLoggedIn");       // set user name label at the top
                if (lbl != null)
                {
                    userID = nn.userId;

                }
            }
            //creating list for 7days of results
            List<Calculated_results> sevenDayData = new List<Calculated_results>();

            Calorie_BusterEntities db = new Calorie_BusterEntities();

            
            DateTime date = new DateTime(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Day);

            tbx_Meal.Text = "";

            //checking to see if user has date selected
            DateTime noDateSelecte = new DateTime(1, 1, 1);
            if (date.CompareTo(noDateSelecte) == 0)
            {
                tbx_Meal.Text = "No Historical Data Found";
                return sevenDayData;
            }


            // genarting 7days of data
            for (int i = 0; i < 7; i++)
            {
                var Past_meal_ids = db.PastMeal_tbl.Select(a => a).Where(n => (n.User_id == userID) &&
                                                                              (n.Date.Day == date.Day) &&
                                                                              (n.Date.Month == date.Month) &&
                                                                              (n.Date.Year == date.Year));//FirstOrDefault();

                List<int> list_of_food_items = new List<int>();

                tbx_Meal.Text += "On the " + date.ToShortDateString() + " you ate:" + System.Environment.NewLine;

                Calculated_results calculateValue = new Calculated_results();
                calculateValue.Date = date;
                foreach (var item in Past_meal_ids)
                {
                    calculateValue.add(calcualte_all_values(item.PastMeal_id));
                }

                sevenDayData.Add(calculateValue);

                date = date.AddDays(-1);

            }

            db.Database.Connection.Close();
            db.Dispose();

            return sevenDayData;
        }
        //creating plot funtion to plot differnt nutrishinal values
        public void PlotData(String strValue)
        {
            //building list of weeks data
            List<Calculated_results> results = GetSevenDays();

            //if no date selected warn user 
            if (results.Count() == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "No Date Selected", "<script>alert('You have no date selected!');</script>");

                return;
            }
            //set data source for graph
            Chart1.DataSource = results;

            // Create a series, and add it to the chart. 
            Series series1 = new Series("My Series");
            Chart1.Series.Add(series1);
            // Adjust the series data members. 
            series1.YValueMembers = strValue;
            series1.XValueMember = "Date";

            //formatting graph
            series1.ChartType = SeriesChartType.Line;
            series1.MarkerStyle = MarkerStyle.Circle;
            series1.MarkerSize = 3;
            series1.MarkerColor = System.Drawing.Color.Red;
            series1.MarkerBorderColor = System.Drawing.Color.Red;
            series1.Color = System.Drawing.Color.Red;

            Chart1.ChartAreas[0].AxisX.Minimum = Calendar1.SelectedDate.AddDays(-7).ToOADate();
            Chart1.ChartAreas[0].AxisX.Maximum = Calendar1.SelectedDate.ToOADate();

            Chart1.ChartAreas[0].AxisY.Title = strValue;
            Chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated90;

            Chart1.ChartAreas[0].AxisX.Title = "Date";

            Chart1.ChartAreas[0].AxisX.Interval = 7;

            Chart1.DataBind();

        }


        //button click events for nutrishainal values for graph
        protected void btnPlotCalories_Click(object sender, EventArgs e)
        {
            PlotData("Calories");
        }

        protected void btnPlotFat_Click(object sender, EventArgs e)
        {
            PlotData("Fat");
        }

        protected void btnPlotSugar_Click(object sender, EventArgs e)
        {
            PlotData("Sugar");
        }

        protected void btnPlotCarbs_Click(object sender, EventArgs e)
        {
            PlotData("Carbs");
        }
        protected void btnPlotProtein_Click(object sender, EventArgs e)
        {
            PlotData("Protein");
        }

    }
}