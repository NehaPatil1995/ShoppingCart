//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AddtoCart.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_ORDER
    {
        public int O_ID { get; set; }
        public Nullable<int> O_FK_PROD { get; set; }
        public Nullable<int> O_FK_INV { get; set; }
        public Nullable<System.DateTime> O_DATE { get; set; }
        public Nullable<int> O_QTY { get; set; }
        public Nullable<double> O_BILL { get; set; }
        public Nullable<int> O_UNITPRICE { get; set; }
    
        public virtual TBL_INVOICE TBL_INVOICE { get; set; }
        public virtual TBL_PRODUCT TBL_PRODUCT { get; set; }
    }
}
