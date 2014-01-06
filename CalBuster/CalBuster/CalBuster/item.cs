using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalBuster
{
    public class item
    {
        public string name { get; set; }
        public int id { get; set; }
        public int gPerItem { get; set; }
        public double protien { get; set; }
        public double carb { get; set; }
        public int cal { get; set; }
        public double sugar { get; set; }
        public double sodium { get; set; }
        public double fat { get; set; }
        public string typeOf { get; set; }
        public int quantity { get; set; }

        public item()
        {
            sodium = 0;
            fat = 0;
            gPerItem = 0;
        }
        public override string ToString()
        {
            return string.Format("{0} portions of {1} ", quantity, name).ToString();
        }
    }
}