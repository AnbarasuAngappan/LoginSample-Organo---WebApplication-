using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginSample.Models
{
    public class ElectricityReadingViewModel
    {
        public IQueryable<Graph> GraphData { get; set; }

        [Required]
        public DateTime? From { get; set; }
        [Required]
        public DateTime? To { get; set; }
    }
}