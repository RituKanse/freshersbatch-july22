using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMS_Data_Access.HMSModels
{
    public partial class RoomDetails
    {
        public RoomDetails()
        {
            GuestDetails = new HashSet<GuestDetails>();
        }
        [Key]
        public int RoomId { get; set; }
        public int? ReservationId { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int? Period { get; set; }
        public int? ServiceId { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Services Room { get; set; }
        public virtual ICollection<GuestDetails> GuestDetails { get; set; }
    }
}
