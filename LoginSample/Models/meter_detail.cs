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
    
    public partial class meter_detail
    {
        public string MiD { get; set; }
        public string HiD { get; set; }
        public string SiD { get; set; }
        public string MBUS_Device_ID { get; set; }
        public string MMiD { get; set; }
        public string UiD { get; set; }
        public string Status { get; set; }
        public string Error_Code { get; set; }
        public string Error_Msg { get; set; }
        public string IP_Address { get; set; }
        public string Port { get; set; }
    
        public virtual house_detail house_details { get; set; }
        public virtual meter_master meter_master { get; set; }
        public virtual site_detail site_details { get; set; }
        public virtual utility_tarrif_master utility_tarrif_master { get; set; }
    }
}