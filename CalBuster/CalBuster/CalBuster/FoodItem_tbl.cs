//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalBuster
{
    using System;
    using System.Collections.Generic;
    
    public partial class FoodItem_tbl
    {
        public FoodItem_tbl()
        {
            this.Link_tbl = new HashSet<Link_tbl>();
        }
    
        public int Item_id { get; set; }
        public string Name { get; set; }
        public Nullable<int> GramPerPortion { get; set; }
        public Nullable<double> Protein { get; set; }
        public Nullable<double> Carbs { get; set; }
        public Nullable<double> Sugar { get; set; }
        public Nullable<double> Fat { get; set; }
        public Nullable<double> Sodium { get; set; }
        public Nullable<int> Calories { get; set; }
        public string TypeOf { get; set; }
        public string FoodCatagory { get; set; }
    
        public virtual ICollection<Link_tbl> Link_tbl { get; set; }
    }
}
