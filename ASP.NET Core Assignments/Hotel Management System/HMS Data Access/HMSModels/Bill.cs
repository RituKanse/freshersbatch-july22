using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMS_Data_Access.HMSModels
{
    public partial class Bill
    {
        [Key]
        public int BillId { get; set; }
        public int? GuestId { get; set; }
        public decimal? Taxes { get; set; }
        public DateTime? IssueDate { get; set; }
        public int? ServiceId { get; set; }
        public int? Unit { get; set; }
        public decimal? CreditCardDetails { get; set; }
        public decimal? Price { get; set; }

        
        public virtual GuestDetails Guest { get; set; }
        public virtual Services Service { get; set; }
    }
}
