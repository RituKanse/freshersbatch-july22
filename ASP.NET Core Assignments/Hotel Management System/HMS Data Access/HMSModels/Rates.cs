using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMS_Data_Access.HMSModels
{
    public partial class Rates
    {
        [Key]
        public int RateId { get; set; }
        public decimal? FirstNightPrice { get; set; }
        public decimal? ExtensionPrice { get; set; }
    }
}
