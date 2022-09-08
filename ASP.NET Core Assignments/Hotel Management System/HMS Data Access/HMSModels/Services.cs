using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMS_Data_Access.HMSModels
{
    public partial class Services
    {
        public Services()
        {
            Bill = new HashSet<Bill>();
        }
        [Key]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public decimal? ServicePrice { get; set; }

        public virtual RoomDetails RoomDetails { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
