using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalBuster
{
    public class Calculated_results
    {
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Sugar { get; set; }
        public float Fat { get; set; }
        public float Sodium { get; set; }
        public int Calories { get; set; }
        public DateTime Date { get; set; }

        public Calculated_results()
        {
            Protein = 0;
            Carbs = 0;
            Sugar = 0;
            Fat = 0;
            Sodium = 0;
            Calories = 0;

        }

    }
}