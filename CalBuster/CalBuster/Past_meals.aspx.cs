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

        }
        //first attempt a query passmeals table
        protected void btnCall_Click(object sender, EventArgs e)
        {
            //Calorie_BusterEntities db = new Calorie_BusterEntities();
            //var foods = db.FoodItem_tbl.Select(a => a.Name);
            //List<string> food = new List<string>();
            //foreach (var item in foods)
            //{
            //    food.Add(item);
            //    tbxData.Text = item.ToString();

            //}

            Calorie_BusterEntities db = new Calorie_BusterEntities();
            //var dates = db.PastMeal_tbl.s(a=> a.Date   );
            var dates = db.PastMeal_tbl.Select(a => a).Where(n => n.User_id == 1);//FirstOrDefault();

            //List<DateTime> date = new List<DateTime>();
            StringBuilder sb = new StringBuilder();


            foreach (var item in dates)
            {
                //date.Add(item.);
                // tbxData.Text = item.ToString();
                sb.Append(item.PastMeal_id);
                sb.Append(", ");
                sb.Append(item.User_id);
                sb.Append(", ");
                sb.Append(item.Date);
                sb.Append(System.Environment.NewLine);


            }
            tbxData.Text = sb.ToString();
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

            foreach (var item in mealsId)
            {
                //date.Add(item.);
                // tbxData.Text = item.ToString();
                sb.Append(item.PastLink_id);
                sb.Append(", ");
                sb.Append(item.Meal_id);
                Meal_id = item.Meal_id;
                sb.Append(", ");
                sb.Append(item.Past_Meal_id);
                sb.Append(System.Environment.NewLine);


            }


            var meals = db.Meal_tbl.Select(a => a).Where(n => n.meal_id == Meal_id);//FirstOrDefault();

            foreach (var item in meals)
            {
                //date.Add(item.);
                // tbxData.Text = item.ToString();
                sb.Append(item.meal_id);
                sb.Append(", ");
                sb.Append(item.Name);
                //meal_id = item.Meal_id;
                sb.Append(", ");
                sb.Append(item.TypeOf);
                sb.Append(System.Environment.NewLine);

            }
            // tbx_Meal.Text = sb.ToString();

            var items = db.Link_tbl.Select(a => a).Where(n => n.Meal_id == Meal_id);//FirstOrDefault();

            List<int> list_of_food_items = new List<int>();

            foreach (var item in items)
            {
                //date.Add(item.);
                // tbxData.Text = item.ToString();
                sb.Append(item.Meal_id);
                sb.Append(", ");
                sb.Append(item.Item_id);
                //meal_id = item.Meal_id;
                list_of_food_items.Add((int)item.Item_id);
                sb.Append(", ");
                sb.Append(item.Quantity);
                sb.Append(System.Environment.NewLine);

            }
            //Calculated_results
            foreach (var item in list_of_food_items)
            {
                var Food_itmes = db.FoodItem_tbl.Select(a => a).Where(n => n.Item_id == item);//FirstOrDefault();

                foreach (var food_item in Food_itmes)
                {
                    //date.Add(item.);
                    // tbxData.Text = item.ToString();
                    sb.Append(food_item.Item_id);
                    sb.Append(", ");
                    sb.Append(food_item.Name);
                    //meal_id = item.Meal_id;
                    sb.Append(", ");
                    sb.Append(food_item.Calories);

                    if (food_item.Calories != null)
                    {
                        Calculated_results.Calories += (int)food_item.Calories;
                    }
                    sb.Append(", ");
                    sb.Append(food_item.Sodium);

                    if (food_item.Sodium != null)
                    {
                        Calculated_results.Sodium += (float)food_item.Sodium;
                    }
                    sb.Append(System.Environment.NewLine);

                    sb.Append(", ");
                    sb.Append(food_item.Carbs);

                    if (food_item.Carbs != null)
                    {
                        Calculated_results.Carbs += (float)food_item.Carbs;
                    }

                    sb.Append(", ");
                    sb.Append(food_item.Sugar);

                    if (food_item.Sugar != null)
                    {
                        Calculated_results.Sugar += (float)food_item.Sugar;

                    }
                    sb.Append(", ");
                    sb.Append(food_item.Fat);

                    if (food_item.Fat != null)
                    {
                        Calculated_results.Fat += (float)food_item.Fat;
                    }

                    sb.Append(", ");
                    sb.Append(food_item.Protein);

                    if (food_item.Protein != null)
                    {
                        Calculated_results.Protein += (float)food_item.Protein;
                    }


                }
            }
            sb.Append("total calories ");
            sb.Append(Calculated_results.Calories);
            sb.Append(System.Environment.NewLine);
            sb.Append("total Sodium ");
            sb.Append(Calculated_results.Sodium);
            sb.Append(System.Environment.NewLine);
            sb.Append("total carbs ");
            sb.Append(Calculated_results.Carbs);
            sb.Append(System.Environment.NewLine);
            sb.Append("total sugar ");
            sb.Append(Calculated_results.Sugar);
            sb.Append(System.Environment.NewLine);
            sb.Append("total Fat ");
            sb.Append(Calculated_results.Fat);
            sb.Append(System.Environment.NewLine);
            sb.Append("total protein ");
            sb.Append(Calculated_results.Protein);
            sb.Append(System.Environment.NewLine);
            tbx_Meal.Text = sb.ToString();

            return Calculated_results;
        }


        //manually checkin meal id
        protected void btn_meal_Click(object sender, EventArgs e)
        {
            int pastmealid = 0;

            Int32.TryParse(tbx_Past_meal_Id.Text, out pastmealid);

            calcualte_all_values(pastmealid);


        }
        //useing calender date to select meal id and calcualte protien, calories.... for that meal
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Calorie_BusterEntities db = new Calorie_BusterEntities();

            var Past_meal_ids = db.PastMeal_tbl.Select(a => a).Where(n => (n.Date.Day == Calendar1.SelectedDate.Day) &&
                                                                          (n.Date.Month == Calendar1.SelectedDate.Month) &&
                                                                          (n.Date.Year == Calendar1.SelectedDate.Year));//FirstOrDefault();

            List<int> list_of_food_items = new List<int>();

            StringBuilder sb = new StringBuilder();

            foreach (var item in Past_meal_ids)
            {


                //date.Add(item.);
                // tbxData.Text = item.ToString();
                sb.Append(item.PastMeal_id);
                sb.Append(", ");
                sb.Append(item.User_id);
                //meal_id = item.Meal_id;
                // list_of_food_items.Add((datetime)item.Date);
                sb.Append(", ");
                sb.Append(item.Date);
                sb.Append(System.Environment.NewLine);

                Calculated_results calcResults = calcualte_all_values(item.PastMeal_id);

                Past_Meals_Table.Rows[1].Cells[1].Text = calcResults.Calories.ToString();
                Past_Meals_Table.Rows[1].Cells[2].Text = calcResults.Carbs.ToString();
                Past_Meals_Table.Rows[1].Cells[3].Text = calcResults.Fat.ToString();
                Past_Meals_Table.Rows[1].Cells[4].Text = calcResults.Protein.ToString();
                Past_Meals_Table.Rows[1].Cells[5].Text = calcResults.Sugar.ToString();
            }
            // tbx_Meal.Text ="checking for "+ Calendar1.SelectedDate.ToShortDateString() + ", " + sb.ToString();

        }

        public List<Calculated_results> GetSevenDays()
        {
            List<Calculated_results> sevenDayData = new List<Calculated_results>();

            Calorie_BusterEntities db = new Calorie_BusterEntities();

            DateTime date = new DateTime(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month, Calendar1.SelectedDate.Day);

            for (int i = 0; i < 7; i++)
            {


                var Past_meal_ids = db.PastMeal_tbl.Select(a => a).Where(n => (n.Date.Day == date.Day) &&
                                                                              (n.Date.Month == date.Month) &&
                                                                              (n.Date.Year == date.Year));//FirstOrDefault();

                List<int> list_of_food_items = new List<int>();

                foreach (var item in Past_meal_ids)
                {

                    Calculated_results calculateValue = calcualte_all_values(item.PastMeal_id);
                    calculateValue.Date = date;
                    sevenDayData.Add(calculateValue);


                }

                date = date.AddDays(-1);

            }

            return sevenDayData;
        }

        public void PlotData(String strValue)
        {
            List<Calculated_results> results = GetSevenDays();

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

            //Chart1.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddDays(-7).ToOADate();
            //Chart1.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();

            Chart1.ChartAreas[0].AxisX.Minimum = Calendar1.SelectedDate.AddDays(-7).ToOADate();
            Chart1.ChartAreas[0].AxisX.Maximum = Calendar1.SelectedDate.ToOADate();

            Chart1.ChartAreas[0].AxisY.Title = strValue;
            Chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated90;

            Chart1.ChartAreas[0].AxisX.Title = "Date";

            Chart1.ChartAreas[0].AxisX.Interval = 7;

            //Chart1.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Rotated90;



            Chart1.DataBind();

        }

        protected void JoinQuery_Click(object sender, EventArgs e)
        {
            PlotData("Calories");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PlotData("Calories");
        }

        protected void btnPlotFat_Click(object sender, EventArgs e)
        {
            PlotData("Fat");
        }

        protected void btnPlot_Click(object sender, EventArgs e)
        {

        }



    }
}