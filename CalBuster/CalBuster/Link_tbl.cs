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
    
    public partial class Link_tbl
    {
        public int Id { get; set; }
        public Nullable<int> Meal_id { get; set; }
        public Nullable<int> Item_id { get; set; }
        public Nullable<decimal> Quantity { get; set; }
    
        public virtual FoodItem_tbl FoodItem_tbl { get; set; }
        public virtual Meal_tbl Meal_tbl { get; set; }
    }
}
