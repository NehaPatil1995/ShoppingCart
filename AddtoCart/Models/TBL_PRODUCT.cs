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
    
    public partial class TBL_PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PRODUCT()
        {
            this.TBL_ORDER = new HashSet<TBL_ORDER>();
        }
    
        public int PROD_ID { get; set; }
        public string PROD_NAME { get; set; }
        public Nullable<double> PROD_PRICE { get; set; }
        public string PROD_DESC { get; set; }
        public string PROD_IMAGE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_ORDER> TBL_ORDER { get; set; }
    }
}
