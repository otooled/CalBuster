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
    
    public partial class PastLink_tbl
    {
        public int PastLink_id { get; set; }
        public int Meal_id { get; set; }
        public int Past_Meal_id { get; set; }
    
        public virtual Meal_tbl Meal_tbl { get; set; }
        public virtual PastMeal_tbl PastMeal_tbl { get; set; }
    }
}