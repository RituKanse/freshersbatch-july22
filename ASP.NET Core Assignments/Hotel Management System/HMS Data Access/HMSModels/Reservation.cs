using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HMS_Data_Access.HMSModels
{
    public partial class Reservation
    {
        public Reservation()
        {
            RoomDetails = new HashSet<RoomDetails>();
        }
        [Key]
        public int ReservationId { get; set; }
        public int? Children { get; set; }
        public int? Adults { get; set; }
        public string Status { get; set; }
        public int? NumberOfNights { get; set; }
        public int? GuestId { get; set; }

        public virtual GuestDetails Guest { get; set; }
        public virtual ICollection<RoomDetails> RoomDetails { get; set; }
    }
}
