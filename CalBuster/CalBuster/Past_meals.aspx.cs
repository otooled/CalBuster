using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
//using System.Windows.Forms.DataVisualization.Charting;
using System.Web.UI.DataVisualization.Charting;


namespace CalBuster
{
    public partial class Past_meals : System.Web.UI.Page
    {
        //Calculated_results Calculated_results = new Calculated_results();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userDetails"] != null)
            {
                User nn = ((User)Session["userDetails"]);
                Label lbl = (Label)((MasterPage)this.Master).FindControl("userLoggedIn");       // set user name label at the top
                if (lbl != null)
                {
                    lbl.Text = nn.userName;
                }
            }
        }
        //first attempt a query passmeals table
        protected void btnCall_Click(object sender, EventArgs e)
        {           

            Calorie_BusterEntities db = new Calorie_BusterEntities();
            
            var dates = db.PastMeal_tbl.Select(a => a).Where(n => n.User_id == 3);//FirstOrDefault();
                        
            StringBuilder sb = new StringBuilder();


            foreach (var item in dates)
            {
                
                /*sb.Append(item.PastMeal_id);
                sb.Append(", ");
                sb.Append(item.User_id);
                sb.Append(", ");
                sb.Append(item.Date);
                sb.Append(System.Environment.NewLine);*/


            }
            //tbxData.Text = sb.ToString();
            db.Database.Connection.Close();
            db.Dispose();
        }

        //funtion to calculate all values protein caloires...... for a meal
        private Calculated_results calcualte_all_values(int pastmealid)
        {
            Calculated_results Calculated_results = new Calculated_results();

            int Meal_id = 0;

            Calorie_BusterEntities db = new Calorie_BusterEntities();
            //var dates = db.PastMeal_tbl.s(a=> a.Date   );
            var mealsId = db.PastLink_tbl.Select(a => a).Where(n => n.Past_Meal_id == pastmealid);//FirstOrDefault();

            //List<DateTime> date = new List<DateTime>();
            StringBuilder sb = new StringBuilder();

            //sb.Append("On the " + Calendar1.SelectedDate.ToShortDateString() + " you ate:");
            //sb.Append(System.Environment.NewLine);

            foreach (var item in mealsId)
            {
                
               // sb.Append(item.PastLink_id);
                //sb.Append(", ");
                //sb.Append(item.Meal_id);
                Meal_id = item.Meal_id;
             //   sb.Append(", ");
               // sb.Append(item.Past_Meal_id);
                //sb.Append(System.Environment.NewLine);


            }


            var meals = db.Meal_tbl.Select(a => a).Where(n => n.meal_id == Meal_id);//FirstOrDefault();

            foreach (var item in meals)
            {
                //date.Add(item.);
                // tbxData.Text = item.ToString();
                //sb.Append(item.meal_id);
                //sb.Append(", ");
                //sb.Append(item.Name);
                //meal_id = item.Meal_id;
                //sb.Append(", ");
                //sb.Append(item.TypeOf);
                //sb.Append(System.Environment.NewLine);

            }
            // tbx_Meal.Text = sb.ToString();

            var items = db.Link_tbl.Select(a => a).Where(n => n.Meal_id == Meal_id);//FirstOrDefault();

            /*List<int> list_of_food_items = new List<int>();

            foreach (var item in items)
            {
                
                //meal_id = item.Meal_id;
                list_of_food_items.Add((int)item.Item_id);
                
            }*/
            //Calculated_results
            //foreach (var item in list_of_food_items)
            foreach (var item in items)
            {
                var y = db.Link_tbl.Select(a => a).Where(n => n.Item_id == item.Item_id && n.Meal_id == Meal_id).FirstOrDefault();
                var Food_itmes = db.FoodItem_tbl.Select(a => a).Where(n => n.Item_id == item.Item_id);//FirstOrDefault();

                foreach (var food_item in Food_itmes)
                {
                    
                   /* sb.Append(food_item.Item_id);
                    sb.Append(", ");  
                    /*/
                    sb.Append(y.Quantity);
                    sb.Append(" ");                    
                    sb.Append(food_item.Name);

                   
                    
                    sb.Append(", ");
                   

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

            db.Database.Connection.Close();
            db.Dispose();
           
            tbx_Meal.Text += sb.ToString();
            tbx_Meal.Text += System.Environment.NewLine;

            return Calculated_results;
        }


        //manually checkin meal id
        protected void btn_meal_Click(object sender, EventArgs e)
        {
            int pastmealid = 0;

            Int32.TryParse(tbx_Past_meal_Id.Text, out pastmealid);

            calcualte_all_values(pastmealid);


        }

        //protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        //{
        //    if (e.Day.Date 
        //}


        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Now)
            {
                //If e.Day.Date < BeginningOfDateRange
                e.Cell.BackColor = System.Drawing.Color.WhiteSmoke;
                e.Day.IsSelectable = false;
            }
            //End If


        }





        //useing calender date to select meal id and calcualte protien, calories.... for that meal
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Calorie_BusterEntities db = new Calorie_BusterEntities();

            Calculated_results calcResults = new Calculated_results();

            var Past_meal_ids = db.PastMeal_tbl.Select(a => a).Where(n => (n.Date.Day == Calendar1.SelectedDate.Day) &&
                                                                          (n.Date.Month == Calendar1.SelectedDate.Month) &&
                                                                          (n.Date.Year == Calendar1.SelectedDate.Year));//FirstOrDefault();

            tbx_Meal.Text = "On the " + Calendar1.SelectedDate.ToShortDateString() + " you ate:" + System.Environment.NewLine;

            List<int> list_of_food_items = new List<int>();

            StringBuilder sb = new StringBuilder();

            foreach (var item in Past_meal_ids)
            {


                
                sb.Append(item.PastMeal_id);
                sb.Append(", ");
                sb.Append(item.User_id);
               
                sb.Append(", ");
                sb.Append(item.Date);
                sb.Append(System.Environment.NewLine);

                //calcResults = calcualte_all_values(item.PastMeal_id);
                calcResults.add( calcualte_all_values(item.PastMeal_id));

                
            }

            db.Database.Connection.Close();
            db.Dispose();
            
            // tbx_Meal.Text ="checking for "+ Calendar1.SelectedDate.ToShortDateString() + ", " + sb.ToString();
            Past_Meals_Table.Rows[1].Cells[0].Text = Calendar1.SelectedDate.ToShortDateString();
            Past_Meals_Table.Rows[1].Cells[1].Text = calcResults.Calories.ToString();
            Past_Meals_Table.Rows[1].Cells[2].Text = calcResults.Carbs.ToString();
            Past_Meals_Table.Rows[1].Cells[3].Text = calcResults.Fat.ToString();
            Past_Meals_Table.Rows[1].Cells[4].Text = calcResults.Protein.ToString();
            Past_Meals_Table.Rows[1].Cells[5].Text = calcResults.Sugar.ToString();
        }

        public List<Calculated_results> GetSevenDays()
        {
            List<Calculated_results> sevenDayData = new List<Calculated_results>();

            Calorie_BusterEntities db = new Calorie_BusterEntities();

            DateTime date = new DateTime(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Day);

            tbx_Meal.Text = "";

            DateTime noDateSelecte = new DateTime(1,1,1);
            if (date.CompareTo(noDateSelecte) == 0)
            {
                tbx_Meal.Text = "No Historical Data Found";
                return sevenDayData;
            }

            

            for (int i = 0; i < 7; i++)
            {
                var Past_meal_ids = db.PastMeal_tbl.Select(a => a).Where(n => (n.Date.Day == date.Day) &&
                                                                              (n.Date.Month == date.Month) &&
                                                                              (n.Date.Year == date.Year));//FirstOrDefault();

                List<int> list_of_food_items = new List<int>();

                tbx_Meal.Text += "On the " + date.ToShortDateString() + " you ate:" + System.Environment.NewLine;

                foreach (var item in Past_meal_ids)
                {
                    Calculated_results calculateValue = calcualte_all_values(item.PastMeal_id);
                    calculateValue.Date = date;
                    sevenDayData.Add(calculateValue);
                }

                date = date.AddDays(-1);

            }

            db.Database.Connection.Close();
            db.Dispose();

            return sevenDayData;
        }

        public void PlotData(String strValue)
        {
            List<Calculated_results> results = GetSevenDays();

            if (results.Count() == 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "No Date Selected", "<script>alert('You have no date selected!');</script>");
                
                return;
            }

            Chart1.DataSource = results;

            // Create a series, and add it to the chart. 
            Series series1 = new Series("My Series");
            Chart1.Series.Add(series1);
            // Adjust the series data members. 
            series1.YValueMembers = strValue;
            series1.XValueMember = "Date";


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