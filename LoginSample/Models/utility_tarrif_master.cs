//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginSample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class utility_tarrif_master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public utility_tarrif_master()
        {
            this.meter_details = new HashSet<meter_detail>();
        }
    
        public string UiD { get; set; }
        public string Utility_Provider_Name { get; set; }
        public string Utility_Type { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Tarrif_Master { get; set; }
        public string Taxation { get; set; }
        public string Charge_Back { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<meter_detail> meter_details { get; set; }
    }
}