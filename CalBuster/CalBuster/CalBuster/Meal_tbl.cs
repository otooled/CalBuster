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
    
    public partial class Meal_tbl
    {
        public Meal_tbl()
        {
            this.Link_tbl = new HashSet<Link_tbl>();
            this.PastLink_tbl = new HashSet<PastLink_tbl>();
        }
    
        public int meal_id { get; set; }
        public string Name { get; set; }
        public string TypeOf { get; set; }
    
        public virtual ICollection<Link_tbl> Link_tbl { get; set; }
        public virtual ICollection<PastLink_tbl> PastLink_tbl { get; set; }
    }
}
