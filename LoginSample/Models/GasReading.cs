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
    
    public partial class GasReading
    {
        public int ID { get; set; }
        public string SocietyID { get; set; }
        public string HouseID { get; set; }
        public string MeterID { get; set; }
        public string IPAddress { get; set; }
        public string Port { get; set; }
        public string Utilityprovider { get; set; }
        public Nullable<long> Reading { get; set; }
        public string Datetimestamp { get; set; }
        public string Timestamp { get; set; }
    }
}
