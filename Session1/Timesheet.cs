//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Session1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timesheet
    {
        public int Timesheet_ID_Num { get; set; }
        public Nullable<int> Staff_ID_Num { get; set; }
        public Nullable<System.DateTime> Start_Date_Time { get; set; }
        public Nullable<System.DateTime> End_Date_Time { get; set; }
        public Nullable<decimal> Payment_Amount { get; set; }
    
        public virtual Staff Staff { get; set; }
        public virtual Timesheet Timesheet1 { get; set; }
        public virtual Timesheet Timesheet2 { get; set; }
    }
}
